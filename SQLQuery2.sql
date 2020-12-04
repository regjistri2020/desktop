
Create table Administrator
(
AdminID int Primary Key,
Emri varchar(50),
Mbiemri varchar(50),
AdminPass varchar(50),
Roli varchar(50) 
);

Create table Mesues
(
MesuesID int Primary Key,
Emri varchar(50),
Mbiemri varchar(50),
Lenda1 int,
Lenda2 int,
MesuesPass varchar(50),
Gjinia char(10) 
);

Create table Klasa
(
KlasaID int Primary Key,
Emri varchar(50),
MesuesID int,
Niveli varchar(50), 
FOREIGN KEY (MesuesID) REFERENCES Mesues(MesuesID)
);


Create table Nxenes
(
NxenesID int Primary Key,
Emri varchar(50),
Mbiemri varchar(50),
NxesesPass varchar(50),
EmriBabait varchar(50),
EmriMamase varchar(50),
ProfesioniBabait varchar(50),
ProfesioniMamase varchar(50),
NrTelPrind int,
Gjinia char(10),
Ditelindja datetime,
Adresa varchar(50),
KlasaID int,
FOREIGN KEY (KlasaID) REFERENCES Klasa(KlasaID)
);

Create table Lendet 
(
LendaID int Primary Key,
EmerLende varchar(50),
KlasaID int
);

Create table Notat
(
NotaID int Primary Key,
LendaID int,
NxenesID int,
MesuesID int,
DataNotes int,
TemaMesimore varchar(30) 

FOREIGN KEY (MesuesID) REFERENCES Mesues(MesuesID),
FOREIGN KEY (NxenesID) REFERENCES Nxenes(NxenesID),
FOREIGN KEY (LendaID) REFERENCES Lendet(LendaID)
);



Create table Jep_Mesim 
(
MesuesID int,
LendaID int,
KlasaID int,

FOREIGN KEY (MesuesID) REFERENCES Mesues(MesuesID),
FOREIGN KEY (LendaID) REFERENCES Lendet(LendaID),
FOREIGN KEY (KlasaID) REFERENCES Klasa(KlasaID)
);