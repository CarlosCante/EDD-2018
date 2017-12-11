#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <numeroaleatorio.h>
#include <QDebug>
#include <fstream>
#include <QMessageBox>

ColaAvionesAterrizan* CAA = new ColaAvionesAterrizan();
ColaPersonas* CP = new ColaPersonas();
int NumeroAviones;

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
    NumeroAviones = ui->NoAviones->text().toInt();
    CAA->IngresarAvion();

    NumeroAviones--;
    ActualizarGrafica();

}


void MainWindow::on_pushButton_clicked()
{

    SiguienteTurnoAvionesAterrizan();

    ActualizarGrafica();
}

void MainWindow::ActualizarGrafica()
{
    ofstream myfile;
    myfile.open ("Grafica.dot");
    myfile << "digraph G {\n";

    myfile << CAA->GenerarSubGrafo();
    myfile << CP->GenerarSubGrafo(0);

    myfile << "}\n";
    myfile.close();
    system("dot -Tpng Grafica.dot -o Grafica.png");

    QPixmap pix("Grafica.png");
    ui->Diagrama->setPixmap(pix.scaled(ui->Diagrama->width(),ui->Diagrama->height()));

}

void MainWindow::SiguienteTurnoAvionesAterrizan()
{
    if(NumeroAviones > 0)//Verifica que aun aigan aviones por llegar, si es asi lo ingresa a la cola
    {
        CAA->IngresarAvion();
        NumeroAviones--;
    }

    CAA->Ultimo->Turnos_D--;//Disminuye un turno al avion que esta al frente de la cola

    /*Si acaban los turos nesesarios del avion actual
     * lo saca de la lista e ingresa sus pasajeros a la
     * cola de pasajeros en espera de las mesas de registro
     */

    if(CAA->Ultimo->Turnos_D <= 0)
    {
        CP->CargarPasajeros(CAA->Ultimo->No_Pasajeros);
        CAA->SacarAvion();
    }
}
