#include <numeroaleatorio.h>

int GenerarNumero(int limite_i, int limite_s)
{
    unsigned __int64 r;
    r = __rdtsc();
    srand(r);

    return limite_i + rand() % ((limite_s + 1) - limite_i);
}
