--1
USE UNIVER
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],FACULTY,PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY ROLLUP (FACULTY,PROFESSION,SUBJECT);

--2
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],FACULTY,PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY CUBE (FACULTY,PROFESSION,SUBJECT);

--3
SELECT * FROM FACULTY


SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT

SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT

--4
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT
INTERSECT
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT

--5
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT
EXCEPT
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '����')
GROUP BY FACULTY,PROFESSION,SUBJECT

--1
USE DM_MyBase
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������

SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ROLLUP(������.���_����������,������.�������)

--2

SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY CUBE(������.���_����������,������.�������)

--3

SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������

SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION ALL
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������


--4


SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
INTERSECT
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION ALL
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������

--5

SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
EXCEPT
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������
UNION ALL
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������

