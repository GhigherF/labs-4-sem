SELECT * FROM ������

INSERT INTO ������ VALUES

(112,'�������',5,100),
(451,'������',70,50),
(423,'�����',32,21),
(666,'������',12,120),
(786,'������',50,12),
(612,'������',130,9),
(211,'�����������',40,30)

SELECT * FROM ����������

INSERT INTO ���������� VALUES

(3,'��� "�"','��.׸���','+375294561876'),
(4,'��� "�"','��.��������','+375294281476'),
(5,'��� "�"','�.���','+375296261196'),
(6,'��� "�"','��.����','+375335461826'),
(7,'��� "�"','�.���','+375334268256'),
(8,'�� "�"','�.��','+375334451216'),
(9,'�� "�"','��.�����','+375334121576'),
(10,'�� "�"','��.������','+375334512311')


SELECT * FROM ������

DELETE ������ WHERE (����������_����������=12) 

INSERT INTO ������ VALUES
(3,2,786,20,'12-30-2024',NULL),
(4,5,69,41,'12-30-2024',NULL),
(5,4,69,90,'04-12-2024',NULL),
(6,5,451,120,'04-21-2025',NULL),
(7,8,786,140,'09-16-2025',NULL),
(8,6,612,52,'12-25-2025',NULL),
(9,7,451,42,'08-18-2025',NULL),
(10,9,69,70,'07-28-2025',NULL)



USE UNIVER

---1

SELECT * FROM AUDITORIUM ORDER BY AUDITORIUM_TYPE

SELECT 
AUDITORIUM.AUDITORIUM_TYPE,
min(AUDITORIUM_CAPACITY)[MIN],
avg(AUDITORIUM_CAPACITY)[AVG],
max(AUDITORIUM_CAPACITY)[MAX],
count(*)[COUNT],
SUM(AUDITORIUM_CAPACITY)[SUM]
FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE 
ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
WHERE (AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE)
GROUP BY AUDITORIUM.AUDITORIUM_TYPE

---2

SELECT COUNT(*) FROM PROGRESS

SELECT NOTE,COUNT(*)[COUNT] 
from PROGRESS
GROUP BY NOTE
ORDER BY NOTE

SELECT T.������,COUNT(*)[COUNT]
FROM (
    SELECT 
        NOTE,
        CASE 
            WHEN NOTE <=6 THEN '�� ���'
            WHEN NOTE >=6 THEN '���'
        END [������]
    FROM 
        PROGRESS
) AS T
GROUP BY 
    ������


--3



SELECT * FROM STUDENT INNER JOIN PROGRESS
ON STUDENT.IDSTUDENT= PROGRESS.IDSTUDENT
INNER JOIN GROUPS ON
STUDENT.IDGROUP = GROUPS.IDGROUP

SELECT ROUND(AVG(CAST (NOTE AS FLOAT(4))),2)[AVG],FACULTY,PROFESSION,YEAR_FIRST FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
GROUP BY FACULTY,PROFESSION,YEAR_FIRST

--4
SELECT * FROM STUDENT INNER JOIN PROGRESS
ON STUDENT.IDSTUDENT= PROGRESS.IDSTUDENT
INNER JOIN GROUPS ON
STUDENT.IDGROUP = GROUPS.IDGROUP

SELECT ROUND(AVG(CAST (NOTE AS FLOAT(4))),2)[AVG],FACULTY,PROFESSION,YEAR_FIRST FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE SUBJECT LIKE '����' OR  SUBJECT LIKE '��'
GROUP BY FACULTY,PROFESSION,YEAR_FIRST

--5	
SELECT * FROM FACULTY
SELECT * FROM GROUPS
SELECT * FROM STUDENT
SELECT * FROM PROGRESS

SELECT * FROM STUDENT INNER JOIN GROUPS ON
GROUPS.IDGROUP=STUDENT.IDGROUP
INNER JOIN PROGRESS ON
PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
WHERE(GROUPS.IDGROUP=19)


SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2),PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE '���')
GROUP BY PROFESSION,SUBJECT


--6
SELECT * FROM PROGRESS

SELECT NOTE,COUNT(NOTE)[COUNT] FROM PROGRESS 
GROUP BY NOTE
HAVING (NOTE = 8 OR NOTE = 9)
ORDER BY NOTE  DESC

--///////////////////////////////

--1
USE DM_MyBase
SELECT * FROM ������
SELECT * FROM ������
SELECT * FROM ����������

SELECT �������,AVG(����������_����������)[AVG],MAX(����������_����������)[MAX],MIN(����������_����������)[MIN],COUNT(����������_����������)[COUNT] FROM ������
GROUP BY ������� 

--2
SELECT COUNT(*)[COUNT],[���-��]
FROM (
    SELECT 
        CASE 
            WHEN ����������_���������� <=30 THEN '��������'
            WHEN ����������_���������� >=30 AND ����������_���������� <50 THEN '���������'
            WHEN ����������_���������� >=50  THEN '������'
        END [���-��]
    FROM 
        ������
) AS T
GROUP BY T.[���-��]

--3


SELECT ������.�������, ������.���_����������,ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG] FROM ������ INNER JOIN
������ ON ������.������� = ������.�������
INNER JOIN  ���������� 
ON ����������.���_���������� = ������.���_����������
GROUP BY ������.�������,������.���_����������

--4


SELECT ������.�������, ������.���_����������,ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG] FROM ������ INNER JOIN
������ ON ������.������� = ������.�������
INNER JOIN  ���������� 
ON ����������.���_���������� = ������.���_����������
WHERE (������.������� = 228)
GROUP BY ������.�������,������.���_����������

--5
SELECT ROUND(AVG(CAST(����������_���������� AS FLOAT)),2)[AVG],������.���_����������,������.������� FROM
������ INNER JOIN ������
ON ������.������� = ������.�������
INNER JOIN ����������
ON ����������.���_���������� = ������.���_����������
WHERE (��������_������ LIKE '���%' OR ��������_������ LIKE '���%' )
GROUP BY ������.���_����������,������.�������

--6
SELECT ��������_������,���� FROM ������ 
GROUP BY ����,��������_������
HAVING ���� > 80