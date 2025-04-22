SELECT * FROM PULPIT
SELECT * FROM FACULTY
SELECT * FROM PROFESSION


USE UNIVER
--1
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
FROM PROFESSION,PULPIT,FACULTY
	WHERE PROFESSION.FACULTY = PULPIT.FACULTY AND PULPIT.FACULTY=FACULTY.FACULTY
		AND
	PROFESSION_NAME IN (SELECT PROFESSION_NAME FROM PROFESSION WHERE (PROFESSION_NAME LIKE'%технология%'
																		or PROFESSION_NAME LIKE 'технологии%'))

--2
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
FROM PROFESSION,PULPIT INNER JOIN FACULTY
ON FACULTY.FACULTY=PULPIT.FACULTY
	WHERE PROFESSION.FACULTY = PULPIT.FACULTY
		AND
	PROFESSION_NAME IN (SELECT PROFESSION_NAME FROM PROFESSION WHERE (PROFESSION_NAME LIKE'%технология%'
																		or PROFESSION_NAME LIKE 'технологии%'))



--3
SELECT PULPIT.PULPIT,FACULTY.FACULTY_NAME,PROFESSION.PROFESSION_NAME
	FROM 
PROFESSION
INNER JOIN PULPIT ON
	PROFESSION.FACULTY = PULPIT.FACULTY
		AND
	PROFESSION_NAME LIKE'%технология%' OR PROFESSION_NAME LIKE 'технологии%'
INNER JOIN FACULTY ON 
FACULTY.FACULTY=PULPIT.FACULTY

--4
--SELECT * FROM AUDITORIUM

SELECT AUDITORIUM, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY
FROM AUDITORIUM
WHERE AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = 'ЛК-К' 
    ORDER BY AUDITORIUM_CAPACITY DESC
)
OR AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = 'ЛБ-К' 
    ORDER BY AUDITORIUM_CAPACITY DESC
)
OR AUDITORIUM IN (
    SELECT TOP(1) AUDITORIUM 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_TYPE = 'ЛК' 
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
		WHERE SUBJECT LIKE 'СУБД')[СУБД],
(SELECT AVG(NOTE) FROM PROGRESS
		WHERE SUBJECT LIKE 'КГ')[КГ],
(SELECT AVG(NOTE) FROM PROGRESS
		WHERE SUBJECT LIKE 'ОАиП')[ОАиП]

--7
SELECT SUBJECT,NOTE FROM PROGRESS
	WHERE NOTE>=ALL (SELECT NOTE FROM PROGRESS
						WHERE SUBJECT LIKE 'ОАиП')

--8
SELECT SUBJECT,NOTE FROM PROGRESS
	WHERE NOTE>=ANY (SELECT NOTE FROM PROGRESS
						WHERE SUBJECT LIKE 'ОАиП')

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
SELECT * FROM ПОСТАВЩИКИ
SELECT * FROM ДЕТАЛИ
SELECT * FROM ЗАКАЗЫ


--1
SELECT ПОСТАВЩИКИ.Название_фирмы,ДЕТАЛИ.Название_Детали  
FROM ПОСТАВЩИКИ,ДЕТАЛИ,ЗАКАЗЫ
	WHERE ПОСТАВЩИКИ.Код_Поставщика=ЗАКАЗЫ.Код_Поставщика AND ЗАКАЗЫ.Артикул = ДЕТАЛИ.Артикул
		AND
	Название_Детали IN (SELECT Название_Детали FROM ДЕТАЛИ WHERE (Название_Детали LIKE'ру%'))
																		


--2

SELECT ПОСТАВЩИКИ.Название_фирмы,ДЕТАЛИ.Название_Детали  
FROM ПОСТАВЩИКИ,ДЕТАЛИ INNER JOIN ЗАКАЗЫ
	ON ЗАКАЗЫ.Артикул = ДЕТАЛИ.Артикул
	WHERE ПОСТАВЩИКИ.Код_Поставщика=ЗАКАЗЫ.Код_Поставщика 
		AND
	Название_Детали IN (SELECT Название_Детали FROM ДЕТАЛИ WHERE (Название_Детали LIKE'ру%'))





--3

SELECT ПОСТАВЩИКИ.Название_фирмы,ДЕТАЛИ.Название_Детали  
FROM ЗАКАЗЫ
INNER JOIN ПОСТАВЩИКИ
	ON ЗАКАЗЫ.Код_Поставщика = ПОСТАВЩИКИ.Код_Поставщика
INNER JOIN ДЕТАЛИ 
	ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
		AND
	 Название_Детали LIKE'ру%'

--4
SELECT Артикул,Количество_Заказанных FROM ЗАКАЗЫ
	WHERE Количество_Заказанных IN (SELECT TOP(1) Количество_Заказанных FROM ЗАКАЗЫ ORDER BY Количество_Заказанных DESC)



--5
SELECT * FROM ЗАКАЗЫ
SELECT * FROM ДЕТАЛИ

SELECT Название_Детали
FROM ДЕТАЛИ
WHERE NOT EXISTS
(
	SELECT *
    FROM ЗАКАЗЫ
	WHERE ЗАКАЗЫ.Артикул = ДЕТАЛИ.Артикул
);

--6
SELECT * FROM ДЕТАЛИ


SELECT 
(SELECT AVG(Цена) FROM ДЕТАЛИ
		WHERE Название_Детали LIKE 'Колёса')[Колёса],
(SELECT AVG(Цена) FROM ДЕТАЛИ
		WHERE Название_Детали LIKE 'Руль')[Руль]

--7
SELECT Название_Детали,Цена FROM ДЕТАЛИ
	WHERE Цена>ALL (SELECT Цена FROM ДЕТАЛИ
						WHERE Название_Детали LIKE 'Колёса')

--8
SELECT Название_Детали,Цена FROM ДЕТАЛИ
	WHERE Цена>ANY (SELECT Цена FROM ДЕТАЛИ
						WHERE Название_Детали LIKE 'Колёса')

