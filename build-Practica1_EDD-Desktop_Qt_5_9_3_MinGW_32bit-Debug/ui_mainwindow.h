/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.9.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QLineEdit *NoAviones;
    QLabel *label_2;
    QLineEdit *NoEscritorios;
    QLabel *label_3;
    QLineEdit *NoEstaciones;
    QLabel *label_4;
    QLabel *Diagrama;
    QTextEdit *Consola;
    QPushButton *pushButton;
    QPushButton *pushButton_2;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(1030, 709);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        NoAviones = new QLineEdit(centralWidget);
        NoAviones->setObjectName(QStringLiteral("NoAviones"));
        NoAviones->setGeometry(QRect(10, 30, 113, 20));
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(10, 10, 71, 16));
        NoEscritorios = new QLineEdit(centralWidget);
        NoEscritorios->setObjectName(QStringLiteral("NoEscritorios"));
        NoEscritorios->setGeometry(QRect(130, 30, 113, 20));
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(130, 10, 81, 16));
        NoEstaciones = new QLineEdit(centralWidget);
        NoEstaciones->setObjectName(QStringLiteral("NoEstaciones"));
        NoEstaciones->setGeometry(QRect(250, 30, 113, 20));
        label_4 = new QLabel(centralWidget);
        label_4->setObjectName(QStringLiteral("label_4"));
        label_4->setGeometry(QRect(250, 10, 81, 16));
        label_4->setFrameShadow(QFrame::Plain);
        label_4->setLineWidth(1);
        Diagrama = new QLabel(centralWidget);
        Diagrama->setObjectName(QStringLiteral("Diagrama"));
        Diagrama->setGeometry(QRect(10, 60, 791, 561));
        Diagrama->setFrameShape(QFrame::Box);
        Consola = new QTextEdit(centralWidget);
        Consola->setObjectName(QStringLiteral("Consola"));
        Consola->setGeometry(QRect(810, 60, 201, 561));
        pushButton = new QPushButton(centralWidget);
        pushButton->setObjectName(QStringLiteral("pushButton"));
        pushButton->setGeometry(QRect(430, 630, 111, 23));
        pushButton_2 = new QPushButton(centralWidget);
        pushButton_2->setObjectName(QStringLiteral("pushButton_2"));
        pushButton_2->setGeometry(QRect(380, 30, 75, 23));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 1030, 21));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MainWindow->setStatusBar(statusBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", Q_NULLPTR));
        label_2->setText(QApplication::translate("MainWindow", "No. Aviones", Q_NULLPTR));
        label_3->setText(QApplication::translate("MainWindow", "No. Escritorios", Q_NULLPTR));
        label_4->setText(QApplication::translate("MainWindow", "No. Estaciones", Q_NULLPTR));
        Diagrama->setText(QApplication::translate("MainWindow", "TextLabel", Q_NULLPTR));
        pushButton->setText(QApplication::translate("MainWindow", "Siguiente Turno", Q_NULLPTR));
        pushButton_2->setText(QApplication::translate("MainWindow", "Inicio", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
