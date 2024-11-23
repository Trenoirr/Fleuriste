drop database if exists fleurs;
create database if not exists fleurs;
use fleurs;

drop table if exists Clients;
create table if not exists Clients(
Nom varchar(40),
Prénom varchar(40),
NumTel varchar(20),
Mdp varchar(40),
AdressFact varchar(100),
CarteCredit varchar(16),
Fidélité varchar(6),
Courriel varchar(50),
Primary key(Courriel));
INSERT INTO Clients (Nom, Prénom, NumTel, Mdp, AdressFact, CarteCredit, Fidélité, Courriel)
VALUES 
('Dupont', 'Jean', '0654321098', 'mdp123', '3 rue des Lilas, 75014 Paris', '1234567890123456', 'Bronze', 'jean.dupont@gmail.com'),
('Martin', 'Sophie', '0665432189', 'sophie123', '12 rue de la Pompe, 75116 Paris', '2345678901234567', 'Aucune', 'sophie.martin@yahoo.fr'),
('Lefèvre', 'Lucie', '0676543210', 'azerty123', '7 avenue des Champs-Elysées, 75008 Paris', '3456789012345678', 'OR', 'lucie.lefevre@hotmail.com'),
('Garcia', 'Pierre', '0654321789', 'pierre123', '25 rue de la Paix, 75001 Paris', '4567890123456789', 'Aucune', 'pierre.garcia@gmail.com'),
('Morin', 'Claire', '0676543218', 'clair123', '14 avenue des Ternes, 75017 Paris', '5678901234567890', 'Bronze', 'claire.morin@hotmail.fr'),
('Moreau', 'Luc', '0665432198', 'luc123', '2 rue de la République, 69002 Lyon', '6789012345678901', 'OR', 'luc.moreau@gmail.com'),
('Giraud', 'Aurélie', '0654321876', 'aurelie123', '9 avenue des Gobelins, 75013 Paris', '7890123456789012', 'Aucune', 'aurelie.giraud@yahoo.fr'),
('Durand', 'François', '0676543120', 'francois123', '45 rue de la Roquette, 75011 Paris', '8901234567890123', 'Bronze', 'francois.durand@hotmail.com'),
('Dubois', 'Marie', '0665432167', 'marie123', '11 avenue de la Grande Armée, 75116 Paris', '9012345678901234', 'OR', 'marie.dubois@gmail.com'),
('Roux', 'Julien', '0654321938', 'julien123', '22 rue de la Pompe, 75016 Paris', '0123456789012345', 'Aucune', 'julien.roux@yahoo.fr'),
('Chevalier', 'Caroline', '0676543298', 'caroline123', '5 avenue de la République, 69001 Lyon', '1234567890123456', 'Bronze', 'caroline.chevalier@hotmail.fr'),
('Blanchard', 'Paul', '0665432123', 'paul123', '8 rue des Archives, 75004 Paris', '2345678901234567', 'OR', 'paul.blanchard@gmail.com'),
('Renaud', 'Anne', '0654321834', 'anne123', '18 avenue de la Grande Armée, 75017 Paris', '3456789012345678', 'Aucune', 'anne.renaud@yahoo.fr');

drop table if exists Assemblage;
create table if not exists Assemblage(

NomBouquet varchar(20),
Prix double,
Gerbera int, 
Ginger int,
Glaïeul int,
Marguerite int,
Rose int,
SaugeSclarée int,
Vase bool,
Primary key(NomBouquet));
insert into Assemblage values
('Gros Merci',45,4,4,4,0,0,1, false),
('Amoureux',65,0,0,0,0,30,0,false),
('Exotique',40,2,1,5,0,0,3,false),
('Maman',80,3,0,25,0,15,0,false),
('Vive la mariée',120,10,0,0,0,30,0,false),
('Arc en ciel de rose',25,0,0,0,0,12,0,false),
('Bouquet personnalisé',0,0,0,0,0,0,0,false);

drop table if exists Commande;
create table if not exists Commande(
Numcom varchar(20),
Courriel varchar(50),
Prix double,
EtatLivraison varchar(30),
DateCom date,
NomBouquet varchar(20),
NumMag int,
Primary key(numcom,NumMag),
foreign key (courriel) references Clients(courriel),
foreign key(NomBouquet) references Assemblage(NomBouquet));
INSERT INTO Commande (Numcom, Courriel, Prix, EtatLivraison, DateCom, NomBouquet,NumMag) VALUES
('00001', 'jean.dupont@gmail.com', 45, 'VINV', '2023-04-15', 'Gros Merci',1),
('00002', 'sophie.martin@yahoo.fr', 65, 'CL', '2023-02-02', 'Amoureux',2),
('00003', 'lucie.lefevre@hotmail.com', 40, 'CAL', '2023-04-18', 'Exotique',1),
('00004', 'pierre.garcia@gmail.com', 45, 'VINV', '2023-04-17', 'Gros Merci',1),
('00005', 'claire.morin@hotmail.fr', 120, 'CL', '2023-01-10', 'Vive la mariée',1),
('00006', 'luc.moreau@gmail.com', 25, 'VINV', '2023-04-19', 'Arc en ciel de rose',1),
('00007', 'aurelie.giraud@yahoo.fr', 22.5, 'CL', '2023-02-05', 'Bouquet personnalisé',2),
('00008', 'francois.durand@hotmail.com', 80, 'VINV', '2023-04-19', 'Maman',2),
('00009', 'marie.dubois@gmail.com', 65, 'VINV', '2023-04-16', 'Amoureux',1),
('00010', 'julien.roux@yahoo.fr', 40, 'CL', '2023-02-14', 'Exotique',2),
('00011', 'caroline.chevalier@hotmail.fr', 62, 'CPAV', '2023-04-18', 'Bouquet personnalisé',1),
('00012', 'paul.blanchard@gmail.com', 120, 'CL', '2023-03-06', 'Vive la mariée',1),
('00013', 'anne.renaud@yahoo.fr', 25, 'VINV', '2023-04-13', 'Arc en ciel de rose',1),
('00014', 'jean.dupont@gmail.com', 39.75, 'CAL', '2023-04-20', 'Bouquet personnalisé',2),
('00015', 'luc.moreau@gmail.com', 80, 'CL', '2023-02-01', 'Maman',1),
('00016', 'francois.durand@hotmail.com', 20, 'CPAV', '2023-04-14', 'Bouquet personnalisé',2),
('00017', 'caroline.chevalier@hotmail.fr', 25, 'CAL', '2023-04-19','Arc en ciel de rose',2),
('00018', 'paul.blanchard@gmail.com', 120, 'CL', '2023-01-28','Vive la mariée',2),
('00019', 'anne.renaud@yahoo.fr', 12.25, 'CPAV', '2023-04-12','Bouquet personnalisé',1),
('00020', 'sophie.martin@yahoo.fr', 120, 'CL', '2023-01-18','Vive la mariée',1);

drop table if exists Fleurs;
create table if not exists Fleurs(
Nom varchar(20),
Prix double,
Stock int,
StockCrit bool,
Primary key(Nom));
insert into Fleurs values
('Gerbera',5,30,false),
('Ginger',4,35,false),
('Glaïeul',1,60,false),
('Marguerite',2.25,50,false),
('Rose',2.5,100,false),
('Sauge sclarée',8.5,25,false);