--1
CREATE VIEW [�������������] as
SELECT * FROM TEACHER
SELECT * FROM [�������������]

--2
SELECT * FROM FACULTY
SELECT * FROM PULPIT 
ORDER BY FACULTY

CREATE VIEW[���������� ������] as
SELECT FACULTY,COUNT(FACULTY)[COUNT] FROM PULPIT
GROUP BY FACULTY

--3
CREATE VIEW ���������(AUDITORIUM,AUDITORIUM_NAME) as
SELECT AUDITORIUM,AUDITORIUM_NAME FROM AUDITORIUM
WHERE (AUDITORIUM_TYPE like '��%') 

SELECT * FROM [���������]
DROP VIEW [���������]
INSERT [���������] VALUES ('NEWNEWnew','NEW')
SELECT * FROM [���������]
UPDATE [���������] SET AUDITORIUM='UPDATED' WHERE (AUDITORIUM = 'NEW')

--4
CREATE VIEW ���������(AUDITORIUM,AUDITORIUM_NAME) as
SELECT AUDITORIUM,AUDITORIUM_NAME FROM AUDITORIUM
WHERE (AUDITORIUM_TYPE like '��%') WITH CHECK OPTION
INSERT [���������] VALUES ('��','NEW')

--5
CREATE VIEW [����������] as
SELECT TOP 50 * FROM SUBJECT
ORDER BY SUBJECT

DROP VIEW [����������]


--6
ALTER VIEW[���������� ������]  WITH SCHEMABINDING as
SELECT p.FACULTY,COUNT(p.FACULTY)[COUNT] FROM dbo.PULPIT p
GROUP BY p.FACULTY

SELECT * FROM [���������� ������]

-----------

--1
USE DM_MyBase
CREATE VIEW [������] as
SELECT * FROM ������

SELECT * FROM [������]

--2
SELECT * FROM FACULTY
SELECT * FROM PULPIT 
ORDER BY FACULTY

CREATE VIEW[���������� �������] as
SELECT �������,COUNT(�������)[COUNT] FROM ������
GROUP BY �������

SELECT * FROM [���������� �������]

--3
CREATE VIEW �������(�������,���_����������) as
SELECT �������,���_���������� FROM ������
WHERE (������� > 300) 

SELECT * FROM �������

--4
CREATE VIEW �������(�������,���_����������) as
SELECT �������,���_���������� FROM ������
WHERE (������� > 300) WITH CHECK OPTION

--5
CREATE VIEW [��������] as
SELECT TOP 50 * FROM ����������
ORDER BY ���_����������

SELECT * FROM [��������]

F
--6
ALTER VIEW[���������� �������] WITH SCHEMABINDING as
SELECT t.�������,COUNT(t.�������)[COUNT] FROM dbo.������ t
GROUP BY t.������� 

SELECT * FROM [���������� �������]