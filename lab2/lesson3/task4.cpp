#include <iostream>
#include <bitset>


using namespace std;


int main(int argc, char const *argv[])
{
    unsigned int a = 15;
    unsigned int b = 53;

    cout << bitset<8>(a) << endl;
    cout << bitset<8>(b) << endl;

    return 0;
}
