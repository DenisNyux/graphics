#include <iostream>


double readDouble();
char readChar();
double calculate(char op, double l, double r);
bool isOpeatorSupported(char op);


int main(int argc, char const *argv[])
{
    double a = readDouble();
    double b = readDouble();

    char op = readChar();

    double result = calculate(op, a, b);

    if (isOpeatorSupported(op))
    {
        std::cout << result << std::endl;
    }

    return 0;
}

double readDouble() {
    double v = 0.0;
    std::cin >> v;
    return v;
}

char readChar() {
    char ch = '0';
    std::cin >> ch;
    return ch;
}

bool isOpeatorSupported(char op) {
    return op == '+'
            || op == '-'
            || op == '*'
            || op == '/';
}

double calculate(char op, double l, double r) {
    double result = 0.0;

    switch (op)
    {
    case '+':
        result = l + r;
        break;
    case '-':
        result = l - r;
        break;
    case '*':
        result = l * r;
        break;
    case '/':
        result = l / r;
        break;
    }

    return result;
}
