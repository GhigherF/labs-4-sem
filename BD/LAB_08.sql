--1
CREATE VIEW [Преподаватель] as
SELECT * FROM TEACHER
SELECT * FROM [Преподаватель]

--2
SELECT * FROM FACULTY
SELECT * FROM PULPIT 
ORDER BY FACULTY

CREATE VIEW[Количество кафедр] as
SELECT FACULTY,COUNT(FACULTY)[COUNT] FROM PULPIT
GROUP BY FACULTY

--3
CREATE VIEW Аудитории(AUDITORIUM,AUDITORIUM_NAME) as
SELECT AUDITORIUM,AUDITORIUM_NAME FROM AUDITORIUM
WHERE (AUDITORIUM_TYPE like 'ЛК%') 

SELECT * FROM [Аудитории]
DROP VIEW [Аудитории]
INSERT [Аудитории] VALUES ('NEWNEWnew','NEW')
SELECT * FROM [Аудитории]
UPDATE [Аудитории] SET AUDITORIUM='UPDATED' WHERE (AUDITORIUM = 'NEW')

--4
CREATE VIEW Аудитории(AUDITORIUM,AUDITORIUM_NAME) as
SELECT AUDITORIUM,AUDITORIUM_NAME FROM AUDITORIUM
WHERE (AUDITORIUM_TYPE like 'ЛК%') WITH CHECK OPTION
INSERT [Аудитории] VALUES ('ЛК','NEW')

--5
CREATE VIEW [Дисциплины] as
SELECT TOP 50 * FROM SUBJECT
ORDER BY SUBJECT

DROP VIEW [Дисциплины]


--6
ALTER VIEW[Количество кафедр]  WITH SCHEMABINDING as
SELECT p.FACULTY,COUNT(p.FACULTY)[COUNT] FROM dbo.PULPIT p
GROUP BY p.FACULTY

SELECT * FROM [Количество кафедр]

-----------

--1
USE DM_MyBase
CREATE VIEW [Деталь] as
SELECT * FROM ДЕТАЛИ

SELECT * FROM [Деталь]

--2
SELECT * FROM FACULTY
SELECT * FROM PULPIT 
ORDER BY FACULTY

CREATE VIEW[Количество деталей] as
SELECT Артикул,COUNT(артикул)[COUNT] FROM ЗАКАЗЫ
GROUP BY Артикул

SELECT * FROM [Количество деталей]

--3
CREATE VIEW ЗаказЦы(Артикул,Код_поставщика) as
SELECT Артикул,Код_Поставщика FROM ЗАКАЗЫ
WHERE (Артикул > 300) 

SELECT * FROM ЗаказЦы

--4
CREATE VIEW ЗаказЦы(Артикул,Код_поставщика) as
SELECT Артикул,Код_Поставщика FROM ЗАКАЗЫ
WHERE (Артикул > 300) WITH CHECK OPTION

--5
CREATE VIEW [ПОСТАВКИ] as
SELECT TOP 50 * FROM ПОСТАВЩИКИ
ORDER BY Код_Поставщика

SELECT * FROM [ПОСТАВКИ]

F
--6
ALTER VIEW[Количество деталей] WITH SCHEMABINDING as
SELECT t.Артикул,COUNT(t.Артикул)[COUNT] FROM dbo.ЗАКАЗЫ t
GROUP BY t.Артикул 

SELECT * FROM [Количество деталей]