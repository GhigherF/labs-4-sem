//#include <tchar.h>
//#include <iostream>
//#include <iomanip> 
//#include "Salesman.h"
//#define N 5
//int _tmain(int argc, _TCHAR* argv[])
//{
//    setlocale(LC_ALL, "rus");
//    int d[N][N] = { //0   1    2    3     4        
//                  {  INF,  6, 24,  INF,   3},    //  0
//                  { 3,   INF,  18,  65,  81},    //  1
//                  { 5,  18,   INF,  86,   52},    //  2 
//                  { 20,  55,  12,   INF,   9},    //  3
//                  { 90,  69,  55,  16,    INF} };   //  4  
//    int r[N];                     // результат 
//    int s = salesman(
//        N,          // [in]  количество городов 
//        (int*)d,          // [in]  массив [n*n] расстояний 
//        r           // [out] массив [n] маршрут 0 x x x x  
//
//    );
//    std::cout << std::endl << "-- Задача коммивояжера -- ";
//    std::cout << std::endl << "-- количество  городов: " << N;
//    std::cout << std::endl << "-- матрица расстояний : ";
//    for (int i = 0; i < N; i++)
//    {
//        std::cout << std::endl;
//        for (int j = 0; j < N; j++)
//
//            if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";
//
//            else std::cout << std::setw(3) << "INF" << " ";
//    }
//    std::cout << std::endl << "-- оптимальный маршрут: ";
//    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
//    std::cout << std::endl << "-- длина маршрута     : " << s;
//    std::cout << std::endl;
//    system("pause");
//    return 0;
//}





#include <vector>
#include  <iostream>
#include <algorithm>
#include "salesman.h"
using namespace std;
#define V 5
#define MAX 1000000
int tsp(int graph[][V], int s)
{
    vector<int> vertex;
    for (int i = 0; i < V; i++)
        if (i != s)
            vertex.push_back(i);
    int min_cost = MAX;
    while (next_permutation(vertex.begin(), vertex.end()))
    {
        int current_cost = 0;
        int j = s;
        for (int i = 0; i < vertex.size(); i++) {
            current_cost += graph[j][vertex[i]];
            j = vertex[i];
        }
        current_cost += graph[j][s];
        min_cost = min(min_cost, current_cost);
        return min_cost;
    }
}
//int main()
//{
//    int graph[][V] = {
//     { INF, 6, 24, INF,3 }
//    ,{ 3, INF, 18, 65, 81},
//    {5,18,INF,86,52},
//    { 20, 55, INF, 86, 52},
//    { 90, 69, 55, 15,INF }};
//    int s = 0;
//    cout << tsp(graph, s) << endl;
//    return 0;
//}