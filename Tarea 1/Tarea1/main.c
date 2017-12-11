#include <stdio.h>
#include <stdlib.h>

typedef struct Nodo
{
    int numero;
    struct Nodo *sigiente;
    struct Nodo *anterior;
}tNodo;

typedef tNodo *Nodo_;
typedef tNodo *Primero_Lista;

void Insertar(Primero_Lista *lista, int n);
void Eliminar(Primero_Lista *lista, int n);
void Mostrar(Primero_Lista lista);

int main()
{
    Primero_Lista plista = NULL;
    int numero, opcion;

    do {
        printf("\n 1.Insertar Dato Numerico");
        printf("\n 2.Eliminar Dato");
        printf("\n 3.Mostrar Lista");
        printf("\n 4.Salir");
        printf("\n\n Ingrese una opcion: ");

        scanf("%d", &opcion);

        switch (opcion) {
        case 1:
            printf("\n Ingrese el dato a insertar: ");
            scanf("%d",&numero);
            Insertar(&plista, numero);
            break;

        case 2:
            printf("\n Ingrese el dato a eliminar: ");
            scanf("%d",&numero);
            Eliminar(&plista, numero);
            break;

        case 3:
            printf("\n Contenido: \n");
            Mostrar(plista);

            break;
        default:
            break;
        }

    } while (opcion != 4);

//    printf("Hello World!\n");
//    Primero_Lista plista = NULL;

//    Insertar(&plista, 20);
//    Insertar(&plista, 10);
//    Insertar(&plista, 40);
//    Insertar(&plista, 30);
//    Insertar(&plista, 25);

//    Mostrar(plista);

    return 0;
}

void Insertar(Primero_Lista *lista, int n)
{
    Nodo_ nuevo, tmp;

    nuevo = (Nodo_)malloc(sizeof(tNodo));
    nuevo->numero = n;

    tmp = *lista;
    if(tmp)
    {
        while(tmp->anterior)
        {
            tmp = tmp->anterior;
        }
    }

    if(!tmp || tmp->numero > n)
    {
        nuevo->sigiente = tmp;
        nuevo->anterior = NULL;
        if(tmp)
        {
            tmp->anterior = nuevo;
        }
        if(!*lista)
        {
            *lista = nuevo;
        }
    }
    else
    {
        while(tmp->sigiente && tmp->sigiente->numero <= n)
        {
            tmp = tmp->sigiente;
        }

        nuevo->sigiente = tmp->sigiente;
        tmp->sigiente = nuevo;
        nuevo->anterior = tmp;
        if(nuevo->sigiente)
        {
            nuevo->sigiente->anterior = nuevo;
        }
    }
}

void Eliminar(Primero_Lista *lista, int n)
{
    Nodo_ tmp;

    tmp = *lista;

    while (tmp && tmp->numero < n) {
        tmp = tmp->sigiente;
    }
    while (tmp && tmp->numero > n) {
        tmp = tmp->anterior;
    }

    if(!tmp || tmp->numero != n)
        return;

    if(tmp == *lista)
    {
        if(tmp->anterior)
        {
            *lista = tmp->anterior;
        }
        else
        {
            *lista = tmp->sigiente;
        }
    }

    if(tmp->anterior)
    {
        tmp->anterior->sigiente = tmp->sigiente;
    }

    if(tmp->sigiente)
    {
        tmp->sigiente->anterior = tmp->anterior;
    }

    free(tmp);
}

void Mostrar(Primero_Lista lista)
{
    Nodo_ tmp = lista;

    if(!lista)
    {
        printf("La lista esta vacia \n");
        return;
    }


    while (tmp->anterior) {
        tmp = tmp->anterior;
    }

    while (tmp) {
        printf("%d <--> ", tmp->numero);
        tmp = tmp->sigiente;
    }
    printf("\n");
}
