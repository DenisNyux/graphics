#include <iostream>
#include "funcs.h"


int readNumber() {
    int num = 0;
    std::cin >> num;
    return num;
}

void writeAnswer(int v) {
    std::cout << v << std::endl;
}
