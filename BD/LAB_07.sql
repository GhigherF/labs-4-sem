--1
USE UNIVER
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],FACULTY,PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY ROLLUP (FACULTY,PROFESSION,SUBJECT);

--2
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],FACULTY,PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY CUBE (FACULTY,PROFESSION,SUBJECT);

--3
SELECT * FROM FACULTY


SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT

SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT

--4
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT
INTERSECT
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT

--5
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION 
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT
EXCEPT
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ТОВ')
GROUP BY FACULTY,PROFESSION,SUBJECT
UNION ALL
SELECT ROUND(AVG(CAST(NOTE AS FLOAT)),2)[AVG],PROFESSION,SUBJECT FROM
STUDENT INNER JOIN GROUPS 
ON STUDENT.IDGROUP = GROUPS.IDGROUP
INNER JOIN PROGRESS 
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE (FACULTY LIKE 'ИДиП')
GROUP BY FACULTY,PROFESSION,SUBJECT

--1
USE DM_MyBase
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул

SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ROLLUP(ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул)

--2

SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY CUBE(ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул)

--3

SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул

SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION ALL
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул


--4


SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
INTERSECT
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION ALL
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул

--5

SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
EXCEPT
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Кол%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул
UNION ALL
SELECT ROUND(AVG(CAST(Количество_Заказанных AS FLOAT)),2)[AVG],ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул FROM
ЗАКАЗЫ INNER JOIN ДЕТАЛИ
ON ДЕТАЛИ.Артикул = ЗАКАЗЫ.Артикул
INNER JOIN ПОСТАВЩИКИ
ON ПОСТАВЩИКИ.Код_Поставщика = ЗАКАЗЫ.Код_Поставщика
WHERE (Название_Детали LIKE 'Ков%' OR Название_Детали LIKE 'Ном%' )
GROUP BY ЗАКАЗЫ.Код_Поставщика,ЗАКАЗЫ.Артикул

