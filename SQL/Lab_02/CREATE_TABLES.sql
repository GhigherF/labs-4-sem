CREATE TABLE ����������
(
���_���������� int NOT NULL,
��������_����� nvarchar(30) NOT NULL,
����� nvarchar(30) NOT NULL,
������� nvarchar(13) NOT NULL,
CONSTRAINT PK_���������� PRIMARY KEY(���_����������)
);

CREATE TABLE ������
(
������� int NOT NULL,
��������_������ nvarchar(30) NOT NULL,
���� int NOT NULL,
CONSTRAINT PK_������ PRIMARY KEY(�������)
);

CREATE TABLE ������
(
���_������ int NOT NULL,
���_���������� int NOT NULL,
������� int NOT NULL,
����������_��_������ int NOT NULL,
����������_���������� int NOT NULL,
����_������ date NOT NULL,
CONSTRAINT PK_������ PRIMARY KEY(���_������)
);

