#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <numeroaleatorio.h>
#include <QDebug>
#include <fstream>
#include <QMessageBox>

ColaAvionesAterrizan* CAA = new ColaAvionesAterrizan();
ColaPersonas* CP = new ColaPersonas();
ListaEscritorios* LE = new ListaEscritorios();
ListaMaletas* LM = new ListaMaletas();
ListaMantenimiento* LMN = new ListaMantenimiento();

int NumeroAviones;
int NumEscritorios;
int turno;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_2_clicked()
{
    turno = 1;
    NumeroAviones = ui->NoAviones->text().toInt();
    NumEscritorios = ui->NoEscritorios->text().toInt();

    LE->CargarEscritorios(NumEscritorios);
    CAA->IngresarAvion();
    LMN->CargarEstaciones(ui->NoEstaciones->text().toInt());


    NumeroAviones--;
    ActualizarGrafica();
    ui->Consola->append("-----------TURNO " + QString::number(turno) + "-------------\n");

    ui->Consola->append("**********AVIONES*********");
    ui->Consola->append("Avion Arribado = 1\n");

    ui->Consola->append("**********MALETAS*********");
    ui->Consola->append("Cantidad de Maletas = " + QString::number(LM->CantidadDeMaletas()) + "\n");

    ui->Consola->append(LE->EstadoActual());
    ui->Consola->append(LMN->EstadoActual());

}


void MainWindow::on_pushButton_clicked()
{
    turno++;
    ui->Consola->append("-----------TURNO " + QString::number(turno) + "-------------\n");
    SiguienteTurnoAvionesAterrizan();
    SiguienteTurnoMantenimiento();
    SiguienteTurnoRegistro();

    ActualizarGrafica();

    ui->Consola->append("**********AVIONES*********");
    if(NumeroAviones >= 0)
    {
        ui->Consola->append("Avion Arribado = " + QString::number(CAA->Primero->ID) + "\n");
    }
    else
    {
        ui->Consola->append("Avion Arribado = Ninguno\n");
    }


    ui->Consola->append("**********MALETAS*********");
    ui->Consola->append("Cantidad de Maletas = " + QString::number(LM->CantidadDeMaletas()) + "\n");

    ui->Consola->append(LE->EstadoActual());
    ui->Consola->append(LMN->EstadoActual());

}

void MainWindow::ActualizarGrafica()
{
    ofstream myfile;
    myfile.open ("Grafica.dot");
    myfile << "digraph G {\n";
    myfile << "rankdir=\"UD\";\n";

    myfile << CAA->GenerarSubGrafo();
    myfile << CP->GenerarSubGrafo(0);
    myfile << LE->GenerarSubgrafo();
    myfile << LM->GenerarSubGrafo();
    myfile << LMN->GenerarSubGrafo();

    myfile << "}\n";
    myfile.close();
    system("dot -Tpng Grafica.dot -o Grafica.png");

    QPixmap pix("Grafica.png");
    ui->Diagrama->setPixmap(pix.scaled(ui->Diagrama->width(),ui->Diagrama->height()));

}

void MainWindow::SiguienteTurnoAvionesAterrizan()
{
    if(CAA->Primero != nullptr)
    {
        if(NumeroAviones > 0)//Verifica que aun aigan aviones por llegar, si es asi lo ingresa a la cola
        {
            CAA->IngresarAvion();

        }
        NumeroAviones--;
        CAA->Ultimo->Turnos_D--;//Disminuye un turno al avion que esta al frente de la cola

        /*Si acaban los turos nesesarios del avion actual
         * lo saca de la lista e ingresa sus pasajeros a la
         * cola de pasajeros en espera de las mesas de registro
         */

        if(CAA->Ultimo->Turnos_D <= 0)
        {
            CP->CargarPasajeros(CAA->Ultimo->No_Pasajeros,LM);
            LMN->ColaAv->IngresarAvion(CAA->SacarAvion());
        }
    }

}

void MainWindow::SiguienteTurnoMantenimiento()
{
    LMN->PasarTurnoMAntenimiento();
    LMN->CargarAviones();

}

void MainWindow::SiguienteTurnoRegistro()
{
    LE->PasarTurno(LM);
    LE->CargarPersonas(CP);

}
