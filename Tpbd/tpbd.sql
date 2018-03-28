CREATE TABLE Angajati (Nr_Crt int PRIMARY KEY, Nume varchar(100) not null, Prenume varchar(100) not null, Functie varchar(100) not null, 
Salar_Baza int null, Spor int default 0, Premii_Brute int default 0, Total_Brut int null, Brut_Impozabil int null, 
CAS int null, CASS int null, Impozit int null, Retineri int default 0, Virat_Card int null, Poza varchar(100) null);

########################################not_used
create or replace trigger tr1_insert
before insert on Angajati
for each row
begin
:new.Nr_Crt := Nr_Crt_Seq.nextval;
end;
/
########################################

CREATE SEQUENCE Nr_Crt_Seq;

create or replace trigger tr2_insert
before insert on Angajati
for each row
declare 
CAS_var float;
CASS_var float;
Impozit_var float;
begin
select CAS into CAS_var from Procente;
select CASS into CASS_var from Procente;
select Impozit into Impozit_var from Procente;
:NEW.Nr_Crt := Nr_Crt_Seq.nextval;
:NEW.Total_Brut := :NEW.Salar_Baza*(1+:NEW.Spor/100)+:NEW.Premii_Brute; 
:NEW.CAS := :NEW.Total_Brut * CAS_var;
:NEW.CASS := :NEW.Total_Brut * CASS_var;
:NEW.Brut_Impozabil := :NEW.Total_Brut - :NEW.CAS - :NEW.CASS; 
:NEW.Impozit := :NEW.Brut_Impozabil * Impozit_var;
:NEW.Virat_Card := :NEW.Total_Brut - :NEW.Impozit - :NEW.CAS - :NEW.CASS - :NEW.Retineri;
end;
/

######################################################not_used
create or replace trigger tr3_update
before update on Angajati
for each row
declare 
CAS_var float;
CASS_var float;
Impozit_var float;
begin
select CAS into CAS_var from Procente;
select CASS into CASS_var from Procente;
select Impozit into Impozit_var from Procente;
:NEW.Total_Brut := :NEW.Salar_Baza*(1+:NEW.Spor/100)+:NEW.Premii_Brute; 
:NEW.CAS := :NEW.Total_Brut * CAS_var;
:NEW.CASS := :NEW.Total_Brut * CASS_var;
:NEW.Brut_Impozabil := :NEW.Total_Brut - :NEW.CAS - :NEW.CASS; 
:NEW.Impozit := :NEW.Brut_Impozabil * Impozit_var;
:NEW.Virat_Card := :NEW.Total_Brut - :NEW.Impozit - :NEW.CAS - :NEW.CASS - :NEW.Retineri;
end;
/
######################################################

####update_angajati
create or replace trigger tr4_update
before update of Salar_Baza, Spor, Premii_Brute, Retineri on Angajati
for each row
declare 
CAS_var float;
CASS_var float;
Impozit_var float;
begin
select CAS into CAS_var from Procente;
select CASS into CASS_var from Procente;
select Impozit into Impozit_var from Procente;
:NEW.Total_Brut := :NEW.Salar_Baza*(1+:NEW.Spor/100)+:NEW.Premii_Brute; 
:NEW.CAS := :NEW.Total_Brut * CAS_var;
:NEW.CASS := :NEW.Total_Brut * CASS_var;
:NEW.Brut_Impozabil := :NEW.Total_Brut - :NEW.CAS - :NEW.CASS; 
:NEW.Impozit := :NEW.Brut_Impozabil * Impozit_var;
:NEW.Virat_Card := :NEW.Total_Brut - :NEW.Impozit - :NEW.CAS - :NEW.CASS - :NEW.Retineri;
end;
/

///////////procente
create or replace trigger tr4_update_procente
before update of CAS, CASS, Impozit on Procente
for each row
declare 
CAS_var float;
CASS_var float;
Impozit_var float;
begin
CAS_var := :NEW.CAS;
CASS_var := :NEW.CASS;
Impozit_var := :NEW.Impozit;
update  Angajati set Total_Brut = Salar_Baza * (1 + Spor / 100) + Premii_Brute;
update  Angajati set CAS = Total_Brut * CAS_var;
update  Angajati set CASS = Total_Brut * CASS_var;
update  Angajati set Impozit = Total_Brut * Impozit_var;
update  Angajati set Brut_Impozabil = Total_Brut - CAS - CASS;  
update  Angajati set Impozit = Brut_Impozabil * Impozit_var ;
update  Angajati set Virat_Card = Total_Brut - Impozit - CAS - CASS - Retineri;
end;
/


INSERT INTO Angajati (Nume,Prenume,Functie,Salar_Baza,Spor,Premii_Brute,Retineri) VALUES ('Moga','Delia','SwTL',4000, 10, 0, 0)
UPDATE Angajati SET Salar_Baza= 2000 Where Nr_Crt = 16;

CREATE TABLE Procente(CAS float not null, CASS float not null, Impozit float not null, Parola varchar(100) not null);

INSERT INTO Procente (CAS, CASS, Impozit) VALUES (10, 25, 10);
UPDATE Procente SET CAS = 0.1, CASS = 0.24, Impozit = 0.1, Parola = 'pass' WHERE Parola = 'parola123';

UPDATE Procente SET CAS = '0,1', CASS = '0,24', Impozit = '0,1', Parola = 'pass' WHERE Parola = 'parola123';
UPDATE Procente SET CAS = '0,1', CASS = '0,24', Impozit = '0,1'  WHERE Parola = 'pass1';
                                     
							
CREATE SEQUENCE seq;
  MINVALUE 1
  START WITH 1
  INCREMENT BY 1
  CACHE 20;
  
  DROP SEQUENCE supplier_seq;