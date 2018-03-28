create or replace trigger insert_date 
before insert on salarii 
for each row
DECLARE
 cas_p float;
 cass_p float;
 impozit_p float;
 
BEGIN 
   select cas into cas_p from procente; 
   select cass into cass_p from procente;
   select impozit into impozit_p from procente;  
   :NEW.total_brut := :new.salar_baza*(1 + :NEW.spor/100) + :NEW.premii_brute;
   :NEW.cass := cass_p * :NEW.total_brut;
   :NEW.cas := cas_p * :NEW.total_brut;
   :NEW.brut_impz := :new.total_brut - :new.CAS - :new.cass;
   :NEW.impozit := :NEW.brut_impz * impozit_p;
   
   :NEW.virat_card := :new.total_brut - :new.impozit - :new.cas - :new.cass - :new.retineri;
  END;
  /
  =========================================================
create or replace trigger insert_date_update 
before update of salar_baza,spor,premii_brute,retineri on salarii 
for each row
DECLARE
 cas_p float;
 cass_p float;
 impozit_p float;
 
BEGIN 
   select cas into cas_p from procente; 
   select cass into cass_p from procente;
   select impozit into impozit_p from procente;  
   :NEW.total_brut := :new.salar_baza*(1 + :NEW.spor/100) + :NEW.premii_brute;
   :NEW.cass := cass_p * :NEW.total_brut;
   :NEW.cas := cas_p * :NEW.total_brut;
   :NEW.brut_impz := :new.total_brut - :new.cas - :new.cass;
   :NEW.impozit := :NEW.brut_impz * impozit_p;
   
   :NEW.virat_card := :new.total_brut - :new.impozit - :new.cas - :new.cass - :new.retineri;
  END;
  /
  
  ==========================================================
create or replace trigger modificare_procente
before update of cas,cass,impozit on procente
for each row
declare 
cas_n float;
cass_n float;
impozit_n float;
BEGIN

	cas_n := :NEW.cas;
	cass_n := :NEW.cass;
	impozit_n := :NEW.impozit;

	update salarii set total_brut =  salar_baza*(1 + spor/100) + premii_brute;
	update salarii set cass = cass_n * total_brut;
	update salarii set cas = cas_n * total_brut;
	update salarii set brut_impz = total_brut - cas - cass;
	update salarii set impozit = brut_impz * impozit_n;
		
	update salarii set virat_card = total_brut - impozit - cas - cass - retineri;
END;	