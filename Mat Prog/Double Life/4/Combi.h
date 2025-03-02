#pragma once 
namespace combi
{
    struct accomodation  // ��������� ���������� 
    {
        short  n;      // ���������� ��������� ��������� ���������  
        short  m;      // ���������� ��������� � ���������� 
        short* sset;   // ������ �������� �������� ����������  
        xcombination* cgen;   // ��������� �� ��������� ���������
        permutation* pgen;   // ��������� �� ��������� ������������
        unsigned __int64 na;  // ����� ���������� 0, ..., count()-1 

        accomodation(short n = 1, short m = 1);  // �����������  
        void reset();     // �������� ���������, ������ ������� 
        short getfirst(); // ������������ ������ ������ ��������   
        short getnext();  // ������������ ��������� ������ ��������  
        short ntx(short i); // �������� i-� ������� ������� ��������  
        unsigned __int64 count() const;  // ����� ���������� ���������� 
    };
}