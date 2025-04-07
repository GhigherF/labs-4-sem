CREATE TABLE ПОСТАВЩИКИ
(
Код_Поставщика int NOT NULL,
Название_Фирмы nvarchar(30) NOT NULL,
Адрес nvarchar(30) NOT NULL,
Телефон nvarchar(13) NOT NULL,
CONSTRAINT PK_ПОСТАВЩИКИ PRIMARY KEY(Код_Поставщика)
);

CREATE TABLE ДЕТАЛИ
(
Артикул int NOT NULL,
Название_Детали nvarchar(30) NOT NULL,
Цена int NOT NULL,
CONSTRAINT PK_ДЕТАЛИ PRIMARY KEY(АРТИКУЛ)
);

CREATE TABLE ЗАКАЗЫ
(
Код_Заказа int NOT NULL,
Код_Поставщика int NOT NULL,
Артикул int NOT NULL,
Количество_на_складе int NOT NULL,
Количество_Заказанных int NOT NULL,
Дата_Заказа date NOT NULL,
CONSTRAINT PK_ЗАКАЗЫ PRIMARY KEY(Код_Заказа)
);

