#include <iostream>
#include <chrono>
#include <tchar.h>
#include <iomanip>
#include "Boat.h"
#define NN 35
#define MM 6
int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");

    int V = 1500,
        v[] = { 345, 678, 123, 890, 456, 210, 567, 789, 134, 678,
         345, 890, 234, 567, 456, 789, 123, 678, 345, 890,
         567, 234, 456, 789, 678,427,715,195,682,829,723,278,414,318,681},
        c[NN] = { 45, 120, 75, 30, 110, 60, 90, 15, 105, 50,
          80, 25, 95, 40, 85, 20, 100, 35, 70, 55,
          65, 10, 115, 45, 130,11,82,120,34,100,14,145,67,92,23};
    short  r[MM];
    auto start =  clock();
    int cc = boat(
        V,   // [in]  максимальный вес груза
        MM,  // [in]  количество мест для контейнеров     
        NN,  // [in]  всего контейнеров  
        v,   // [in]  вес каждого контейнера  
        c,   // [in]  доход от перевозки каждого контейнера     
        r    // [out] результат: индексы выбранных контейнеров  
    );
    auto end = clock();
    std::cout << std::endl << "- Задача о размещении контейнеров на судне";
    std::cout << std::endl << "- общее количество контейнеров    : " << NN;
    std::cout << std::endl << "- количество мест для контейнеров : " << MM;
    std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
    std::cout << std::endl << "- вес контейнеров                 : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : " << cc;
    std::cout << std::endl << "- общий вес выбранных контейнеров : ";
    int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
    std::cout << std::endl << std::endl;
std::cout << "-------------------------------------------------------------" << std::endl;
    std::cout << std::endl << "Время выполнения: " << (double)(end - start) / CLOCKS_PER_SEC << " секунд"<<std::endl;
    system("pause");
    return 0;
}