CREATE DATABASE 'localhost:C:\TerritoriesDB\TERRITORIES.GDB'
USER 'SYSDBA' PASSWORD '**********'
PAGE_SIZE 4096
DEFAULT CHARACTER SET NONE;

/* Generators */
CREATE SEQUENCE G_ADDRESSESIDADDRESSESGEN0;

ALTER SEQUENCE G_ADDRESSESIDADDRESSESGEN0 RESTART WITH 1;
CREATE SEQUENCE G_CITIESIDCITYGEN1;

ALTER SEQUENCE G_CITIESIDCITYGEN1 RESTART WITH 1;
CREATE SEQUENCE G_DEPARTMENTSIDDEPARTMENTGEN2;

ALTER SEQUENCE G_DEPARTMENTSIDDEPARTMENTGEN2 RESTART WITH 14;
CREATE SEQUENCE G_TERRITORIESIDTERRITORYGEN3;

ALTER SEQUENCE G_TERRITORIESIDTERRITORYGEN3 RESTART WITH 1;

/* Procedures */
SET TERM ^ ;
RECREATE PROCEDURE ADDRESSES_ADD
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_ADDWITHPK
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_DELETEALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_DELTEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_GETALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_GETALLBYCITY
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_GETALLBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_RESETID (
 NEWID INTEGER)
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE ADDRESSES_UPDATEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_ADD
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_ADDWITHPK
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_DELETEALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_DELTEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_GETALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_GETBYDEPARTMENT
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_GETBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_RESETID (
 NEWID INTEGER)
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE CITIES_UPDATEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_ADD
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_ADDWITHPK
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_DELETEALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_DELTEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_GETALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_GETBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_RESETID (
 NEWID INTEGER)
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE DEPARTMENTS_UPDATEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE PUBLISHERS_GETBYCITY
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_ADD
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_ADDWITHPK
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_DELETEALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_DELTEBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_GETALL
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_GETBYID
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_RESETID (
 NEWID INTEGER)
AS 
BEGIN
  /* Procedure text */
END^

RECREATE PROCEDURE TERRITORIES_UPDATEBYID
AS 
BEGIN
  /* Procedure text */
END^
SET TERM ; ^

/* Tables */
CREATE TABLE "Addresses" (
  "IdAddress"     INTEGER NOT NULL,
  "Street"        VARCHAR(80) NOT NULL,
  "Number"        VARCHAR(50),
  "Corner1"       VARCHAR(80),
  "Corner2"       VARCHAR(80),
  "Phone1"        VARCHAR(15),
  "Phone2"        VARCHAR(15),
  "Description"   VARCHAR(200),
  "Map1"          VARCHAR(15),
  "Map2"          VARCHAR(15),
  "IdTerritory"   INTEGER,
  "IdCity"        INTEGER NOT NULL,
  "AddressData"   VARCHAR(50),
  "CustomField1"  VARCHAR(200),
  "CustomField2"  VARCHAR(200),
  "Lat"           DOUBLE PRECISION,
  "Lng"           DOUBLE PRECISION
);

CREATE TABLE "Cities" (
  "IdCity"        INTEGER NOT NULL,
  "Name"          VARCHAR(80) NOT NULL,
  "IdDepartment"  INTEGER NOT NULL,
  "Area"          BLOB SUB_TYPE TEXT
);

CREATE TABLE "Departments" (
  "IdDepartment"  INTEGER NOT NULL,
  "Name"          VARCHAR(80) NOT NULL,
  "Area"          BLOB SUB_TYPE TEXT
);

CREATE TABLE "Publishers" (
  "IdPublisher"  INTEGER NOT NULL,
  "Name"         VARCHAR(80) NOT NULL,
  "Address"      BLOB SUB_TYPE TEXT,
  "IdCity"       INTEGER,
  "Notes"        BLOB SUB_TYPE TEXT NOT NULL,
  "Phone1"       VARCHAR(30),
  "Phone2"       VARCHAR(30),
  "Zip"          VARCHAR(15)
);

CREATE TABLE "Territories" (
  "IdTerritory"  INTEGER NOT NULL,
  "Number"       INTEGER,
  "Name"         VARCHAR(80) NOT NULL,
  "Area"         BLOB SUB_TYPE TEXT
);

CREATE TABLE "Tours" (
  "IdTerritory"  INTEGER NOT NULL,
  "BeginDate"    TIMESTAMP NOT NULL,
  "EndDate"      TIMESTAMP,
  "TourNumber"   INTEGER NOT NULL,
  "IdPublisher"  INTEGER
);
COMMIT;

/* Constraints */
ALTER TABLE "Addresses"
  ADD CONSTRAINT "PK_Addresses"
  PRIMARY KEY ("IdAddress");

ALTER TABLE "Cities"
  ADD PRIMARY KEY ("IdCity");

ALTER TABLE "Departments"
  ADD PRIMARY KEY ("IdDepartment");

ALTER TABLE "Publishers"
  ADD PRIMARY KEY ("IdPublisher");

ALTER TABLE "Territories"
  ADD PRIMARY KEY ("IdTerritory");

ALTER TABLE "Tours"
  ADD PRIMARY KEY ("IdTerritory", "TourNumber");

COMMIT;
/* Foreign Keys */
ALTER TABLE "Addresses"
  ADD CONSTRAINT ADDRESSESKEY0
  FOREIGN KEY ("IdCity")
    REFERENCES "Cities"("IdCity")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

ALTER TABLE "Addresses"
  ADD CONSTRAINT ADDRESSESKEY1
  FOREIGN KEY ("IdTerritory")
    REFERENCES "Territories"("IdTerritory")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

ALTER TABLE "Cities"
  ADD CONSTRAINT CITIESKEY0
  FOREIGN KEY ("IdDepartment")
    REFERENCES "Departments"("IdDepartment")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

ALTER TABLE "Publishers"
  ADD CONSTRAINT PUBLISHERSKEY0
  FOREIGN KEY ("IdCity")
    REFERENCES "Cities"("IdCity")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

ALTER TABLE "Tours"
  ADD CONSTRAINT TOURSKEY0
  FOREIGN KEY ("IdPublisher")
    REFERENCES "Publishers"("IdPublisher")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

ALTER TABLE "Tours"
  ADD CONSTRAINT TOURSKEY1
  FOREIGN KEY ("IdTerritory")
    REFERENCES "Territories"("IdTerritory")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

/* Procedures */
SET TERM ^ ;
ALTER PROCEDURE ADDRESSES_ADD
AS 
BEGIN
 NEWID = GEN_ID(G_ADDRESSESIDADDRESSESGEN0, 1);
  INSERT INTO "Addresses" ("IdAddress","Street", "Number", "Corner1", "Corner2", "Phone1", "Phone2", "Description", "Map1", "Map2", "IdTerritory", "IdCity", "AddressData", "CustomField1", "CustomField2", "Lat", "Lng")
  VALUES (:NEWID, :"STREET", :"NUMBER", :"CORNER1", :"CORNER2", :"PHONE1", :"PHONE2", :"DESCRIPTION", :"MAP1", :"MAP2", :"IDTERRITORY", :"IDCITY", :"ADDRESSDATA", :"CUSTOMFIELD1", :"CUSTOMFIELD2", :"LAT", :"LNG");

END^

ALTER PROCEDURE ADDRESSES_ADDWITHPK
AS 
BEGIN
  INSERT INTO "Addresses" ("IdAddress","Street", "Number", "Corner1", "Corner2", "Phone1", "Phone2", "Description", "Map1", "Map2", "IdTerritory", "IdCity", "AddressData", "CustomField1", "CustomField2", "Lat", "Lng")
  VALUES (:IDADDRESS, :"STREET", :"NUMBER", :"CORNER1", :"CORNER2", :"PHONE1", :"PHONE2", :"DESCRIPTION", :"MAP1", :"MAP2", :"IDTERRITORY", :"IDCITY", :"ADDRESSDATA", :"CUSTOMFIELD1", :"CUSTOMFIELD2", :"LAT", :"LNG");

END^

ALTER PROCEDURE ADDRESSES_DELETEALL
AS 
BEGIN
  DELETE FROM "Addresses";
  NUM_RECS = ROW_COUNT;
  SUSPEND;
END^

ALTER PROCEDURE ADDRESSES_DELTEBYID
AS 
BEGIN
  DELETE FROM "Addresses"
  WHERE "IdAddress" = :ID;
  SUSPEND;
END^

ALTER PROCEDURE ADDRESSES_GETALL
AS 
BEGIN
   FOR SELECT "IdAddress", "Street", "Number", "Corner1", "Corner2", "Phone1", "Phone2", "Description", "Map1", "Map2", "IdTerritory", "IdCity", "AddressData", "CustomField1", "CustomField2", "Lat", "Lng"
   FROM "Addresses"
   INTO :"IDADDRESS", :"STREET", :"NUMBER", :"CORNER1", :"CORNER2", :"PHONE1", :"PHONE2", :"DESCRIPTION", :"MAP1", :"MAP2", :"IDTERRITORY", :"IDCITY", :"ADDRESSDATA", :"CUSTOMFIELD1", :"CUSTOMFIELD2", :"LAT", :"LNG"
   DO BEGIN
    SUSPEND;
    END
END^

ALTER PROCEDURE ADDRESSES_GETALLBYCITY
AS 
BEGIN
   FOR SELECT "IdAddress", "Street", "Number", "Corner1", "Corner2", "Phone1", "Phone2", "Description", "Map1", "Map2", "IdTerritory", "IdCity", "AddressData", "CustomField1", "CustomField2", "Lat", "Lng"
   FROM "Addresses" A  
   WHERE A."IdCity" = :CITY
   INTO :"IDADDRESS", :"STREET", :"NUMBER", :"CORNER1", :"CORNER2", :"PHONE1", :"PHONE2", :"DESCRIPTION", :"MAP1", :"MAP2", :"IDTERRITORY", :"IDCITY", :"ADDRESSDATA", :"CUSTOMFIELD1", :"CUSTOMFIELD2", :"LAT", :"LNG"
   DO BEGIN
    SUSPEND;
    END
END^

ALTER PROCEDURE ADDRESSES_GETALLBYID
AS 
BEGIN
   FOR SELECT "IdAddress", "Street", "Number", "Corner1", "Corner2", "Phone1", "Phone2", "Description", "Map1", "Map2", "IdTerritory", "IdCity", "AddressData", "CustomField1", "CustomField2", "Lat", "Lng"
   FROM "Addresses" A  
   WHERE A."IdAddress" = :ID
   INTO :"IDADDRESS", :"STREET", :"NUMBER", :"CORNER1", :"CORNER2", :"PHONE1", :"PHONE2", :"DESCRIPTION", :"MAP1", :"MAP2", :"IDTERRITORY", :"IDCITY", :"ADDRESSDATA", :"CUSTOMFIELD1", :"CUSTOMFIELD2", :"LAT", :"LNG"
   DO BEGIN
    SUSPEND;
    END
END^

ALTER PROCEDURE ADDRESSES_RESETID (
 NEWID INTEGER)
AS 
declare variable aux2 integer;
declare variable aux1 integer;
BEGIN
   AUX1 = GEN_ID(G_ADDRESSESIDADDRESSESGEN0, - (GEN_ID(G_ADDRESSESIDADDRESSESGEN0, 0))) ;
   AUX2 = GEN_ID(G_ADDRESSESIDADDRESSESGEN0, NEWID);
END^

ALTER PROCEDURE ADDRESSES_UPDATEBYID
AS 
BEGIN
  update "Addresses"  A
  set A."Street" = :"STREET",
      A."Number" = :"NUMBER",
      A."Corner1" = :"CORNER1",
      A."Corner2" = :"CORNER2",
      A."Phone1" = :"PHONE1",
      A."Phone2" = :"PHONE2",
      A."Description" = :"DESCRIPTION",
      A."Map1" = :"MAP1",
      A."Map2" = :"MAP2",
      A."IdTerritory" = :"IDTERRITORY",
      A."IdCity" = :"IDCITY",
      A."AddressData" = :"ADDRESSDATA",
      A."CustomField1" = :"CUSTOMFIELD1",
      A."CustomField2" = :"CUSTOMFIELD2",
      A."Lat" = :"LAT",
      A."Lng" = :"LNG"
  where A."IdAddress" = :IDADDRESS;
END^

ALTER PROCEDURE CITIES_ADD
AS 
BEGIN
  NEWID = GEN_ID(G_CITIESIDCITYGEN1, 1);
  INSERT INTO "Cities" ("IdCity", "Name", "IdDepartment", "Area")
  VALUES (:NEWID, :"NAME", :"IDDEPARTMENT", :"AREA");

END^

ALTER PROCEDURE CITIES_ADDWITHPK
AS 
BEGIN
  INSERT INTO "Cities" ("IdCity", "Name", "IdDepartment", "Area")
  VALUES (:ID, :"NAME", :"IDDEPARTMENT", :"AREA");

END^

ALTER PROCEDURE CITIES_DELETEALL
AS 
BEGIN
  DELETE FROM "Cities";
  NUM_RECS = ROW_COUNT;
  SUSPEND;
END^

ALTER PROCEDURE CITIES_DELTEBYID
AS 
BEGIN
  DELETE FROM "Cities"
  WHERE "IdCity" = :ID;
  SUSPEND;
END^

ALTER PROCEDURE CITIES_GETALL
AS 
begin
  FOR SELECT C."IdCity", C."Name", C."Area",C."IdDepartment"
  FROM "Cities" C
  INTO :ID, :NAME, :AREA, :IDDEPARTMENT
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE CITIES_GETBYDEPARTMENT
AS 
begin
  FOR SELECT C."IdCity", C."Name", C."Area",C."IdDepartment"
  FROM "Cities" C
  WHERE C."IdDepartment" = :DEPARTMENT
  INTO :IDCITY, :NAME, :AREA, :IDDEPARTMENT
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE CITIES_GETBYID
AS 
begin
  FOR SELECT C."IdCity", C."Name", C."Area",C."IdDepartment"
  FROM "Cities" C
  WHERE C."IdCity" = :ID
  INTO :IDCITY, :NAME, :AREA, :IDDEPARTMENT
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE CITIES_RESETID (
 NEWID INTEGER)
AS 
declare variable aux2 integer;
declare variable aux1 integer;
BEGIN
   AUX1 = GEN_ID(G_CITIESIDCITYGEN1, - (GEN_ID(G_CITIESIDCITYGEN1, 0))) ;
   AUX2 = GEN_ID(G_CITIESIDCITYGEN1, NEWID);
END^

ALTER PROCEDURE CITIES_UPDATEBYID
AS 
begin
  UPDATE "Cities" C
  SET C."Name" = :NAME,   C."Area" = :AREA, C."IdDepartment" = :IDDEPARTMENT
  WHERE C."IdCity" = :ID;
end^

ALTER PROCEDURE DEPARTMENTS_ADD
AS 
BEGIN
  NEWID = GEN_ID(G_DEPARTMENTSIDDEPARTMENTGEN2, 1);
  INSERT INTO "Departments"("IdDepartment","Name","Area")
  VALUES (:NEWID,:NAME, :AREA);
  SUSPEND;
END^

ALTER PROCEDURE DEPARTMENTS_ADDWITHPK
AS 
BEGIN
  INSERT INTO "Departments"("IdDepartment","Name","Area")
  VALUES (:ID,:NAME, :AREA);
  SUSPEND;
END^

ALTER PROCEDURE DEPARTMENTS_DELETEALL
AS 
BEGIN
  DELETE FROM "Departments";
  NUM_RECS = ROW_COUNT;
  SUSPEND;
END^

ALTER PROCEDURE DEPARTMENTS_DELTEBYID
AS 
BEGIN
  DELETE FROM "Departments"
  WHERE "IdDepartment" = :ID;
  SUSPEND;
END^

ALTER PROCEDURE DEPARTMENTS_GETALL
AS 
begin
  FOR SELECT D."IdDepartment", D."Name", D."Area"
  FROM "Departments" D
  INTO :ID, :NAME, :AREA
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE DEPARTMENTS_GETBYID
AS 
begin
  for select D."IdDepartment", D."Name", D."Area"
  from "Departments" D  
  where D."IdDepartment" = :ID
  into :"IDDEPARTMENT", :"NAME", :"AREA"
  do begin
  suspend;
  end
end^

ALTER PROCEDURE DEPARTMENTS_RESETID (
 NEWID INTEGER)
AS 
declare variable aux2 integer;
declare variable aux1 integer;
BEGIN
   AUX1 = GEN_ID(G_DEPARTMENTSIDDEPARTMENTGEN2, - (GEN_ID(G_DEPARTMENTSIDDEPARTMENTGEN2, 0))) ;
   AUX2 = GEN_ID(G_DEPARTMENTSIDDEPARTMENTGEN2, NEWID);
END^

ALTER PROCEDURE DEPARTMENTS_UPDATEBYID
AS 
begin
  UPDATE "Departments" D
  SET D."Name" = :NAME,   D."Area" = :AREA
  WHERE D."IdDepartment" = :ID;
end^

ALTER PROCEDURE PUBLISHERS_GETBYCITY
AS 
BEGIN
       FOR SELECT "IdPublisher", "Name", "Address", "IdCity", "Notes", "Phone1", "Phone2", "Zip"
       FROM "Publishers" P
       INTO :"IDPUBLISHER", :"NAME", :"ADDRESS", :"IDCITY", :"NOTES", :"PHONE1", :"PHONE2", :"ZIP"
       DO BEGIN
        SUSPEND;
       END
END^

ALTER PROCEDURE TERRITORIES_ADD
AS 
BEGIN
  NEWID = GEN_ID(G_TERRITORIESIDTERRITORYGEN3, 1);
  INSERT INTO "Territories"("IdTerritory","Name","Number","Area")
  VALUES (:NEWID,:NAME, :NUMBER, :AREA);
  SUSPEND;
END^

ALTER PROCEDURE TERRITORIES_ADDWITHPK
AS 
BEGIN
  INSERT INTO "Territories"("IdTerritory","Name","Number","Area")
  VALUES (:ID,:NAME, :NUMBER, :AREA);
  SUSPEND;
END^

ALTER PROCEDURE TERRITORIES_DELETEALL
AS 
BEGIN
  DELETE FROM "Territories";
  NUM_RECS = ROW_COUNT;
  SUSPEND;
END^

ALTER PROCEDURE TERRITORIES_DELTEBYID
AS 
BEGIN
  DELETE FROM "Territories"
  WHERE "IdTerritory" = :ID;
  SUSPEND;
END^

ALTER PROCEDURE TERRITORIES_GETALL
AS 
begin
  FOR SELECT T."IdTerritory", T."Name", T."Number", T."Area"
  FROM "Territories" T
  INTO :IDTERRITORY, :NAME, :NUMBER, :AREA
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE TERRITORIES_GETBYID
AS 
begin
  FOR SELECT T."IdTerritory", T."Name", T."Number", T."Area"
  FROM "Territories" T
  WHERE T."IdTerritory" = :ID
  INTO :IDTERRITORY, :NAME, :NUMBER, :AREA
  DO BEGIN
    SUSPEND;
  END
end^

ALTER PROCEDURE TERRITORIES_RESETID (
 NEWID INTEGER)
AS 
declare variable aux2 integer;
declare variable aux1 integer;
BEGIN
   AUX1 = GEN_ID(G_TERRITORIESIDTERRITORYGEN3, - (GEN_ID(G_TERRITORIESIDTERRITORYGEN3, 0))) ;
   AUX2 = GEN_ID(G_TERRITORIESIDTERRITORYGEN3, NEWID);
END^

ALTER PROCEDURE TERRITORIES_UPDATEBYID
AS 
begin
  UPDATE "Territories" T
  SET T."Name" = :NAME, T."Number" = :NUMBER,  T."Area" = :AREA
  WHERE T."IdTerritory" = :ID;
end^
SET TERM ; ^

/* Grants */
GRANT EXECUTE
  ON PROCEDURE DEPARTMENTS_ADD
TO PUBLIC;

