#include "funcs.h"


int main(int argc, char const *argv[])
{
    int a = readNumber();
    int b = readNumber();

    int ans = a + b;

    writeAnswer(ans);

    return 0;
}
