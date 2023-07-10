create database przychodnia
GO
use [przychodnia]
GO

CREATE TABLE lekarze (
id_lekarza bigint identity(1,1) primary key,
imie varchar(30) not null,
nazwisko varchar(30) not null,
pwk char(7) not null unique check (pwk like '[1-9][0-9][0-9][0-9][0-9][0-9][0-9]' ), --PWK - prawo wykonywania zawodu
index idx_prawo_wyk_zawodu (pwk)
);
CREATE TABLE nazwy_specjalizacji(
id_specjalizacji bigint identity(1,1) primary key,
nazwa_specjalizacji varchar(50) not null
);
CREATE TABLE lekarze_specjalisci(
id_lekSpecjalista bigint identity(1,1) primary key,
id_specjalizacji bigint not null,
id_lekarza bigint not null,
FOREIGN KEY (id_specjalizacji) REFERENCES nazwy_specjalizacji(id_specjalizacji) ON DELETE CASCADE,
FOREIGN KEY (id_lekarza) references lekarze (id_lekarza) ON DELETE CASCADE
);

CREATE TABLE pacjenci(
id_pacjenta bigint identity(1,1) primary key,
imie varchar(30) NOT NULL,
nazwisko varchar(30) NOT NULL,
pesel char(11) NOT NULL unique check (pesel not like '%[^0-9]%' and len(pesel)=11),
index idx_pesel_pacjenta (pesel)
);
CREATE TABLE choroby(
id_choroby varchar(5) NOT NULL primary key check (id_choroby like '[A-Z][0-9][0-9][.][0-9]'),
nazwa_choroby varchar(60) not null);

CREATE TABLE medykamenty(
id_medykamentu bigint NOT NULL identity(1,1) primary key,
nazwa_medykamentu varchar(50) NOT NULL);

CREATE TABLE porady_lekarskie(
id_porady bigint NOT NULL identity(1,1) primary key,
id_lekarzaS bigint NOT NULL,
id_pacjenta bigint NOT NULL,
[data] smalldatetime NOT NULL check ((DATEPART(minute,[data]) % 15 = 0) and [data] < GETDATE()),
FOREIGN KEY (id_lekarzaS) REFERENCES lekarze_specjalisci(id_lekSpecjalista) ON DELETE CASCADE,
FOREIGN KEY (id_pacjenta) REFERENCES pacjenci(id_pacjenta) ON DELETE NO ACTION,
constraint pacjent_godzina unique (id_pacjenta, [data]), --constraint zabraniający umówienia więcej niż 1 porady dla pacjenta w tym samym czasie
constraint lekarz_godzina unique (id_lekarzaS, [data]) --constraint zabraniający umówienia 2 porad w tym samym czasie dla lekarza
);
CREATE TABLE diagnozy(
id_diagnozy bigint NOT NULL identity(1,1) primary key,
id_choroby varchar(5) not null,
id_porady bigint not null,
FOREIGN KEY (id_choroby) REFERENCES choroby(id_choroby) ON DELETE NO ACTION,
FOREIGN KEY (id_porady) REFERENCES porady_lekarskie(id_porady) ON DELETE NO ACTION,
);
CREATE TABLE medykamenty_zalecone(
id_zalecenia bigint NOT NULL identity(1,1) primary key,
id_medykamentu bigint not null,
id_diagnozy bigint not null,
dawkowanie varchar(30) not null,
FOREIGN KEY (id_medykamentu) references medykamenty(id_medykamentu) ON DELETE NO ACTION,
FOREIGN KEY (id_diagnozy) REFERENCES diagnozy(id_diagnozy) ON DELETE NO ACTION
); 


--INSERTY DANYCH 

insert into lekarze (imie, nazwisko, pwk)
values
('Jan', 'Kowal', '1234567'),
('Andrzej', 'Bobrowski', '2345678'),
('Joanna', 'Bator', '5678901'),
('Kamila', 'Poznanska', '1596452'),
('Krzysztof', 'Wilaszek', '1239874'),
('Barbara', 'Jasnosz', '1254789'),
('Józef', 'Augustyński', '9631254');
GO
insert into nazwy_specjalizacji values
('choroby wewnętrzne'),
('alergologia'), ('kardiologia'), ('endokrynologia'),
('choroby płuc'), ('neurologia'), ('ortopedia i traumatologia narządu ruchu'),
('medycyna pracy');
GO

insert into lekarze_specjalisci (id_specjalizacji, id_lekarza) values
('1', '1'), ('2', '2'), ('3', '3'), ('4', '4'), ('1', '5'), ('1', '6'), ('2', '3'), ('6', '2'), ('1', '2');
GO
insert into pacjenci (imie, nazwisko, pesel) values
('Marcin', 'Hiccups', '02345690110'),
('Katarzyna', 'Boligłowa', '74234578901'),
('Patryk', 'Bolinoga', '90234569874'),
('Józef', 'Babiński', '01234569875'),
('Anna', 'Cohen', '92234569825'),
('Maria', 'Ulcer', '81212569825'),
('Daria', 'Cushing', '61231269825');
GO
insert into choroby (id_choroby, nazwa_choroby) values
('M41.3','Skolioza wynikająca z budowy klatki piersiowej'),
('Q76.2', 'Wrodzony kręgozmyk'), 
('T79.6', 'Pourazowe niedokrwienie mięśnia'), 
('F63.3', 'Trichotillomania'),
('F51.0','Bezsenność nieorganiczna'), 
('D55.3', 'Niedokrwistość zależna od zaburzeń przemian nukleotydów'),
('D52.8','Inne niedokrwistości z niedoboru kwasu foliowego'),
('B26.8','Choroba wywołana przez wirus świnki z innymi powikłaniami'),
('A15.2', 'Gruźlica płuc potwierdzona histologicznie'),
('A08.0','Zapalenie jelit wywołane przez rotawirusy'),
('J10.0', 'Grypa z zapaleniem płuc');

insert into medykamenty values 
('Acti-Globin (tabletki)'), 
('Aethoxysklerol 0,5% (roztwór do wstrzykiwań)'), 
('Alantan (maść)'),
('Amoksiklav (tabletki powlekane)'), 
('Ibuprofen'), 
('Paracetamol');
insert into porady_lekarskie (id_lekarzaS, id_pacjenta, [data])
values
('1', '1','2022-02-10 10:00'),
('2', '4', '2023-01-11 9:15'),
('1', '5', '2023-01-11 9:15'),
('1', '7', '2022-12-12 8:00'),
('9', '1', '2022-12-10 9:00'),
('9', '6', '2022-12-11 9:15'),
('4', '6', '2022-12-11 9:30'),
('1', '3','2022-02-10 10:30'),
('1', '3','2022-02-10 10:45');

insert into diagnozy(id_choroby, id_porady) values
('M41.3','5'),
('F51.0', '2'),
('F51.0', '3'),
('J10.0', '4'),
('D55.3', '5'),
('A08.0', '5'),
('J10.0', '6'),
('J10.0', '7');

INSERT INTO medykamenty_zalecone (id_medykamentu, id_diagnozy, dawkowanie) VALUES
('1', '1', '2x dziennie 1 tabletka'),
('1', '2', '2x dziennie 2 tabletki'),
('3', '3', '2x dziennie'),
('6', '3', '150mg 2x dziennie'),
('5', '3', '1 tabletka 2x dziennie'),
('5', '4', '1 tabletka 2x dziennie'),
('5', '2', '1 tabletka 2x dziennie'),
('6', '8', '1 tabletka 2x dziennie');


