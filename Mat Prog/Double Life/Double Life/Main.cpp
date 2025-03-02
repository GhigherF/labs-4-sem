#include <tchar.h>
#include <iostream>
#include "Combi.h" //1/4
#include "Knapsack.h"
#include <time.h>
#include <iomanip> 
#include "Boat.h"
//#define NN 4  //2
//#define NN (sizeof(c)/sizeof(int)) //3
#define NN (sizeof(v)/sizeof(int))
//#define MM 3 //5
#define MM 6 //6
#define SPACE(n) std::setw(n)<<" " //6
int _tmain(int argc, _TCHAR* argv[])
{
    //1
    // 
    //setlocale(LC_ALL, "rus");
    //char  AA[][2] = { "A", "B", "C", "D" };
    //std::cout << std::endl << " - ��������� ��������� ���� ����������� -";
    //std::cout << std::endl << "�������� ���������: ";
    //std::cout << "{ ";
    //for (int i = 0; i < sizeof(AA) / 2; i++)
    //    std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    //std::cout << "}";
    //std::cout << std::endl << "��������� ���� �����������  ";
    //combi::subset s1(sizeof(AA) / 2);         // �������� ����������   
    //int  n = s1.getfirst();                // ������ (������) ������������    
    //while (n >= 0)                          // ���� ���� ������������ 
    //{
    //    std::cout << std::endl << "{ ";
    //    for (int i = 0; i < n; i++)
    //        std::cout << AA[s1.ntx(i)] << ((i < n - 1) ? ", " : " ");
    //    std::cout << "}";
    //    n = s1.getnext();                   // c�������� ������������ 
    //};
    //std::cout << std::endl << "�����: " << s1.count() << std::endl;
    //system("pause");
    //return 0;



    //2
    // 
    //setlocale(LC_ALL, "rus");
    //int V = 100,                // ����������� �������              
    //    v[] = { 25, 30, 60, 20 },     // ������ �������� ������� ����  
    //    c[] = { 25, 10, 20, 30 };     // ��������� �������� ������� ���� 
    //short m[NN];                // ���������� ��������� ������� ����  {0,1}   

    //int maxcc = knapsack_s(

    //    V,   // [in]  ����������� ������� 
    //    NN,  // [in]  ���������� ����� ��������� 
    //    v,   // [in]  ������ �������� ������� ����  
    //    c,   // [in]  ��������� �������� ������� ����     
    //    m    // [out] ���������� ��������� ������� ����  
    //);

    //std::cout << std::endl << "-------- ������ � ������� --------- ";
    //std::cout << std::endl << "- ���������� ��������� : " << NN;
    //std::cout << std::endl << "- ����������� �������  : " << V;
    //std::cout << std::endl << "- ������� ���������    : ";
    //for (int i = 0; i < NN; i++) std::cout << v[i] << " ";
    //std::cout << std::endl << "- ��������� ���������  : ";
    //for (int i = 0; i < NN; i++) std::cout << v[i] * c[i] << " ";
    //std::cout << std::endl << "- ����������� ��������� �������: " << maxcc;
    //std::cout << std::endl << "- ��� �������: ";
    //int s = 0; for (int i = 0; i < NN; i++) s += m[i] * v[i];
    //std::cout << s;
    //std::cout << std::endl << "- ������� ��������: ";
    //for (int i = 0; i < NN; i++) std::cout << " " << m[i];
    //std::cout << std::endl << std::endl;

    //system("pause");
    //return 0;



    //3
    // 
    //setlocale(LC_ALL, "rus");
    //int V = 15,              // ����������� �������              
    //    v[] = { 25, 56, 67, 40, 20, 27, 37, 33, 33, 44, 53, 12,
    //           60, 75, 12, 55, 54, 42, 43, 14, 30, 37, 31, 12 },
    //    c[] = { 15, 26, 27, 43, 16, 26, 42, 22, 34, 12, 33, 30,
    //           12, 45, 60, 41, 33, 11, 14, 12, 25, 41, 30, 40 };
    //short m[NN];
    //int maxcc = 0;
    //clock_t t1, t2;
    //std::cout << std::endl << "-------- ������ � ������� --------- ";
    //std::cout << std::endl << "- ����������� �������  : " << V;
    //std::cout << std::endl << "-- ���������� ------ ����������������� -- ";
    //std::cout << std::endl << "    ���������          ����������  ";
    //for (int i = 14; i <= NN; i++)
    //{
    //    t1 = clock();
    //    maxcc = knapsack_s(V, i, v, c, m);
    //    t2 = clock();
    //    std::cout << std::endl << "       " << std::setw(2) << i
    //        << "               " << std::setw(5) << (t2 - t1);
    //}
    //std::cout << std::endl << std::endl;
    //system("pause");
    //return 0;


    //4
    //
   /* setlocale(LC_ALL, "rus");
    char  AA[][2] = { "A", "B", "C", "D", "E" };
    std::cout << std::endl << " --- ��������� ��������� ---";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)

        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ��������� ";
    combi::xcombination xc(sizeof(AA) / 2, 3);
    std::cout << "�� " << xc.n << " �� " << xc.m;
    int  n = xc.getfirst();
    while (n >= 0)
    {

        std::cout << std::endl << xc.nc << ": { ";

        for (int i = 0; i < n; i++)


            std::cout << AA[xc.ntx(i)] << ((i < n - 1) ? ", " : " ");

        std::cout << "}";

        n = xc.getnext();
    };
    std::cout << std::endl << "�����: " << xc.count() << std::endl;
    system("pause");
    return 0;*/

    //5
    //
//setlocale(LC_ALL, "rus");
//int V = 1000,
//v[] = { 100,  200,   300,  400,  500,  150 },
//c[NN] = { 10,   15,    20,   25,   30,  25 };
//short  r[MM];
//int cc = boat(
//    V,   // [in]  ������������ ��� �����
//    MM,  // [in]  ���������� ���� ��� �����������     
//    NN,  // [in]  ����� �����������  
//    v,   // [in]  ��� ������� ����������  
//    c,   // [in]  ����� �� ��������� ������� ����������     
//    r    // [out] ���������: ������� ��������� �����������  
//);
//std::cout << std::endl << "- ������ � ���������� ����������� �� �����";
//std::cout << std::endl << "- ����� ���������� �����������    : " << NN;
//std::cout << std::endl << "- ���������� ���� ��� ����������� : " << MM;
//std::cout << std::endl << "- ����������� �� ���������� ����  : " << V;
//std::cout << std::endl << "- ��� �����������                 : ";
//for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
//std::cout << std::endl << "- ����� �� ���������              : ";
//for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
//std::cout << std::endl << "- ������� ���������� (0,1,...,m-1): ";
//for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
//std::cout << std::endl << "- ����� �� ���������              : " << cc;
//std::cout << std::endl << "- ����� ��� ��������� ����������� : ";
//int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
//std::cout << std::endl << std::endl;
//system("pause");
//return 0;


//6
//
//setlocale(LC_ALL, "rus");
//int V = 1000,
//v[] = { 250, 560, 670, 400, 200, 270, 370, 330, 330, 440, 530, 120,
//       200, 270, 370, 330, 330, 440, 700, 120, 550, 540, 420, 170,
//       600, 700, 120, 550, 540, 420, 430, 140, 300, 370, 310, 120 };
//int c[NN] = { 15,26,  27,  43,  16,  26,  42,  22,  34,  12,  33,  30,
//           42,22,  34,  43,  16,  26,  14,  12,  25,  41,  17,  28,
//           12,45,  60,  41,  33,  11,  14,  12,  25,  41,  30,  40 };
//short r[MM];
//int maxcc = 0;
//clock_t t1, t2;
//std::cout << std::endl << "-- ������ �� ����������� �������� ����� -- ";
//std::cout << std::endl << "-  ����������� �� ����    : " << V;
//std::cout << std::endl << "-  ���������� ����        : " << MM;
//std::cout << std::endl << "-- ���������� ------ ����������������� -- ";
//std::cout << std::endl << "   �����������        ����������  ";
//for (int i = 24; i <= NN; i++)
//{
//    t1 = clock();
//    int maxcc = boat(V, MM, i, v, c, r);
//    t2 = clock();
//    std::cout << std::endl << SPACE(7) << std::setw(2) << i
//        << SPACE(15) << std::setw(5) << (t2 - t1);
//}
//std::cout << std::endl << std::endl;
//system("pause");
//return 0;

//7
//
//setlocale(LC_ALL, "rus");
//char  AA[][2] = { "A", "B", "C", "D" };
//std::cout << std::endl << " --- ��������� ������������ ---";
//std::cout << std::endl << "�������� ���������: ";
//std::cout << "{ ";
//for (int i = 0; i < sizeof(AA) / 2; i++)
//
//    std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
//std::cout << "}";
//std::cout << std::endl << "��������� ������������ ";
//combi::permutation p(sizeof(AA) / 2);
//__int64  n = p.getfirst();
//while (n >= 0)
//{
//    std::cout << std::endl << std::setw(4) << p.np << ": { ";
//
//    for (int i = 0; i < p.n; i++)
//
//        std::cout << AA[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");
//
//    std::cout << "}";
//
//    n = p.getnext();
//};
//std::cout << std::endl << "�����: " << p.count() << std::endl;
//system("pause");
//return 0;


//8
//
    setlocale(LC_ALL, "rus");
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " --- ��������� ������������ ---";
    std::cout << std::endl << "�������� ���������: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)

        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "��������� ������������ ";
    combi::permutation p(sizeof(AA) / 2);
    __int64  n = p.getfirst();
    while (n >= 0)
    {
        std::cout << std::endl << std::setw(4) << p.np << ": { ";

        for (int i = 0; i < p.n; i++)

            std::cout << AA[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");

        std::cout << "}";

        n = p.getnext();
    };
    std::cout << std::endl << "�����: " << p.count() << std::endl;
    system("pause");
    return 0;



}
