#include <iostream>
#include "constants.h"

double readDouble();
double getDistance(double initialHeight, int seconds);

int main(int argc, char const *argv[])
{
    double h = readDouble();

    for (int i = 0; i < 6; i++)
    {
        double distance = getDistance(h, i);
        if (distance >= 0.0)
        {
            std::cout << i << ": " << distance << std::endl;
        }
    }
    
    return 0;
}

double readDouble() {
    double v = 0.0;
    std::cin >> v;
    return v;
}

double getDistance(double initialHeight, int seconds) {
    return initialHeight
            - (myConstants::gravity * seconds * seconds) / 2;
}
