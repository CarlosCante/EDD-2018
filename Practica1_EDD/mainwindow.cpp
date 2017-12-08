#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <numeroaleatorio.h>
#include <QDebug>

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
    for (int var = 0; var < 5; ++var) {
        qDebug() << QString::number(GenerarNumero(15,20));
    }

}
