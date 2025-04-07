SELECT * FROM PULPIT
SELECT * FROM FACULTY
SELECT * FROM PROFESSION


USE UNIVER
--1
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
FROM PROFESSION,PULPIT,FACULTY
	WHERE PROFESSION.FACULTY = PULPIT.FACULTY AND PULPIT.FACULTY=FACULTY.FACULTY
		AND
	PROFESSION_NAME IN (SELECT PROFESSION_NAME FROM PROFESSION WHERE (PROFESSION_NAME LIKE'%����������%'
																		or PROFESSION_NAME LIKE '����������%'))

--2
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
FROM PROFESSION,PULPIT INNER JOIN FACULTY
ON FACULTY.FACULTY=PULPIT.FACULTY
	WHERE PROFESSION.FACULTY = PULPIT.FACULTY
		AND
	PROFESSION_NAME IN (SELECT PROFESSION_NAME FROM PROFESSION WHERE (PROFESSION_NAME LIKE'%����������%'
																		or PROFESSION_NAME LIKE '����������%'))



--3
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
	FROM 
PROFESSION
INNER JOIN PULPIT ON
	PROFESSION.FACULTY = PULPIT.FACULTY
		AND
	PROFESSION_NAME LIKE'%����������%' OR PROFESSION_NAME LIKE '����������%'
INNER JOIN FACULTY ON 
FACULTY.FACULTY=PULPIT.FACULTY

--4
--SELECT * FROM AUDITORIUM

SELECT AUDITORIUM, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY
FROM AUDITORIUM
WHERE AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = '��-�' 
    ORDER BY AUDITORIUM_CAPACITY DESC
)
OR AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = '��-�' 
    ORDER BY AUDITORIUM_CAPACITY DESC
)
OR AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = '��' 
   ORDER BY AUDITORIUM_CAPACITY DESC
)ORDER BY AUDITORIUM_CAPACITY DESC;

--5
--SELECT * FROM FACULTY
--SELECT * FROM PULPIT

SELECT FACULTY 
FROM FACULTY 
WHERE NOT EXISTS
(
	SELECT *
    FROM PULPIT
    WHERE PULPIT.FACULTY = FACULTY.FACULTY
);

--6
--SELECT * FROM PROGRESS


SELECT 
(SELECT AVG(NOTE) FROM PROGRESS
		WHERE SUBJECT LIKE '����')[����],
(SELECT AVG(NOTE) FROM PROGRESS
		WHERE SUBJECT LIKE '��')[��],
(SELECT AVG(NOTE) FROM PROGRESS
		WHERE SUBJECT LIKE '����')[����]

--7
SELECT SUBJECT,NOTE FROM PROGRESS
	WHERE NOTE>=ALL (SELECT NOTE FROM PROGRESS
						WHERE SUBJECT LIKE '����')

--8
SELECT SUBJECT,NOTE FROM PROGRESS
	WHERE NOTE>=ANY (SELECT NOTE FROM PROGRESS
						WHERE SUBJECT LIKE '����')

--*
--SELECT * FROM STUDENT ORDER BY BDAY DESC
--SELECT 
--DISTINCT
--a.NAME, a.BDAY FROM STUDENT a 
	--CROSS JOIN STUDENT b 
	--WHERE (MONTH(a.BDAY)=MONTH(b.BDAY) AND DAY(a.BDAY)=DAY(b.BDAY)) AND (a.NAME!=b.NAME)
	--ORDER BY MONTH(a.BDAY),DAY(a.BDAY) DESC


SELECT a.NAME, a.BDAY FROM STUDENT a
WHERE ( SELECT COUNT(*) 
		FROM STUDENT b 
			WHERE 
			MONTH(a.BDAY) = MONTH(b.BDAY) 
			AND DAY(a.BDAY) = DAY(b.BDAY)) > 1 
ORDER BY MONTH(BDAY), DAY(BDAY);

-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
USE DM_MyBase
SELECT * FROM ����������
SELECT * FROM ������
SELECT * FROM ������


--1
SELECT ����������.��������_�����,������.��������_������  
FROM ����������,������,������
	WHERE ����������.���_����������=������.���_���������� AND ������.������� = ������.�������
		AND
	��������_������ IN (SELECT ��������_������ FROM ������ WHERE (��������_������ LIKE'��%'))
																		


--2

SELECT ����������.��������_�����,������.��������_������  
FROM ����������,������ INNER JOIN ������
	ON ������.������� = ������.�������
	WHERE ����������.���_����������=������.���_���������� 
		AND
	��������_������ IN (SELECT ��������_������ FROM ������ WHERE (��������_������ LIKE'��%'))





--3

SELECT ����������.��������_�����,������.��������_������  
FROM ������
INNER JOIN ����������
	ON ������.���_���������� = ����������.���_����������
INNER JOIN ������ 
	ON ������.������� = ������.�������
		AND
	 ��������_������ LIKE'��%'

--4
SELECT �������,����������_���������� FROM ������
	WHERE ����������_���������� IN (SELECT TOP(1) ����������_���������� FROM ������ ORDER BY ����������_���������� DESC)



--5
SELECT * FROM ������
SELECT * FROM ������

SELECT ��������_������
FROM ������
WHERE NOT EXISTS
(
	SELECT *
    FROM ������
	WHERE ������.������� = ������.�������
);

--6
SELECT * FROM ������


SELECT 
(SELECT AVG(����) FROM ������
		WHERE ��������_������ LIKE '�����')[�����],
(SELECT AVG(����) FROM ������
		WHERE ��������_������ LIKE '����')[����]

--7
SELECT ��������_������,���� FROM ������
	WHERE ����>ALL (SELECT ���� FROM ������
						WHERE ��������_������ LIKE '�����')

--8
SELECT ��������_������,���� FROM ������
	WHERE ����>ANY (SELECT ���� FROM ������
						WHERE ��������_������ LIKE '�����')

