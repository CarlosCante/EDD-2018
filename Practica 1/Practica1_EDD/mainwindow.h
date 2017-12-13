#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <colaavionesaterrizan.h>
#include <colapersonas.h>
#include <listaescritorios.h>


namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_2_clicked();

    void on_pushButton_clicked();

    void ActualizarGrafica();

    void SiguienteTurnoAvionesAterrizan();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
