#include <iostream>


using namespace std;


int main(int argc, char const *argv[])
{
    cout << (5 > 3 && 4 < 8) << endl;
    cout << (4 > 6 && true) << endl;
    cout << (3 >= 3 || false) << endl;
    cout << ((true || false) ? 4 : 5) << endl;

    return 0;
}
