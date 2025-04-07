SELECT * FROM ДЕТАЛИ

INSERT INTO ДЕТАЛИ VALUES

(112,'Мигалки',5,100),
(451,'Номера',70,50),
(423,'Диски',32,21),
(666,'Стекло',12,120),
(786,'Краска',50,12),
(612,'Коврик',130,9),
(211,'Подголовник',40,30)

SELECT * FROM ПОСТАВЩИКИ

INSERT INTO ПОСТАВЩИКИ VALUES

(3,'ООО "В"','Ул.Чёрта','+375294561876'),
(4,'ОАО "В"','Ул.Криулина','+375294281476'),
(5,'ОАО "В"','Д.Два','+375296261196'),
(6,'ОАО "В"','Ул.Улик','+375335461826'),
(7,'ОАО "В"','Д.Нет','+375334268256'),
(8,'ИП "В"','Д.Да','+375334451216'),
(9,'ИП "В"','Ул.Всего','+375334121576'),
(10,'ИП "В"','Ул.Ничего','+375334512311')


SELECT * FROM ЗАКАЗЫ

DELETE ЗАКАЗЫ WHERE (Количество_Заказанных=12) 

INSERT INTO ЗАКАЗЫ VALUES
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

SELECT T.ОЦЕНКА,COUNT(*)[COUNT]
FROM (
    SELECT 
        NOTE,
        CASE 
            WHEN NOTE <=6 THEN 'НЕ ГУД'
            WHEN NOTE >=6 THEN 'ГУД'
        END [ОЦЕНКА]
    FROM 
        PROGRESS
) AS T
GROUP BY 
    ОЦЕНКА


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
WHERE SUBJECT LIKE 'ОАиП' OR  SUBJECT LIKE 'БД'
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
WHERE (FACULTY LIKE 'ТОВ')
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
SELECT * FROM ДЕТАЛИ
SELECT * FROM ЗАКАЗЫ
SELECT * FROM ПОСТАВЩИКИ

SELECT Артикул,AVG(Количество_Заказанных)[AVG],MAX(Количество_Заказанных)[MAX],MIN(Количество_Заказанных)[MIN],COUNT(Количество_Заказанных)[COUNT] FROM ЗАКАЗЫ
GROUP BY Артикул 

--2
SELECT COUNT(*)[COUNT],[КОЛ-ВО]
FROM (
    SELECT 
        CASE 
            WHEN Количество_Заказанных <=30 THEN 'Маловато'
            WHEN Количество_Заказанных >=30 AND Количество_Заказанных <50 THEN 'Нормально'
            WHEN Количество_Заказанных >=50  THEN 'Хорошо'
        END [КОЛ-ВО]
    FROM 
        ЗАКАЗЫ
) AS T
GROUP BY T.[КОЛ-ВО]

--3


SELECT ЗАКАЗЫ.Артикул, ЗАКАЗЫ.Код_Поставщика,ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG] FROM ЗАКАЗЫ INNER JOIN
ДЕТАЛИ ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN  ПОСТАВЩИКИ 
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
GROUP BY ЗАКАЗЫ.Артикул,ЗАКАЗЫ.Код_Поставщика

--4


SELECT ЗАКАЗЫ.Артикул, ЗАКАЗЫ.Код_Поставщика,ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG] FROM ЗАКАЗЫ INNER JOIN
ДЕТАЛИ ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN  ПОСТАВЩИКИ 
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (ЗАКАЗЫ.Артикул = 228)
GROUP BY ЗАКАЗЫ.Артикул,ЗАКАЗЫ.Код_Поставщика

--5
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул

--6
SELECT Название_Детали,Цена FROM ДЕТАЛИ 
GROUP BY Цена,Название_Детали
HAVING Цена > 80