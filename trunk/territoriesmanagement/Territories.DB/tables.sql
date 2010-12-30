/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Addresses" (
    "IdAddress"                INTEGER NOT NULL,
    "Street"                   VARCHAR(80) CHARACTER SET UTF8 NOT NULL,
    "Number"                   VARCHAR(50),
    "Corner1"                  VARCHAR(80) CHARACTER SET UTF8,
    "Corner2"                  VARCHAR(80) CHARACTER SET UTF8,
    "Phone1"                   VARCHAR(15),
    "Phone2"                   VARCHAR(15),
    "Description"              VARCHAR(200) CHARACTER SET UTF8,
    "Map1"                     VARCHAR(30),
    "Map2"                     VARCHAR(30),
    "IdTerritory"              INTEGER,
    "IdCity"                   INTEGER NOT NULL,
    "AddressData"              VARCHAR(50) CHARACTER SET UTF8,
    "CustomField1"             VARCHAR(200) CHARACTER SET UTF8,
    "CustomField2"             VARCHAR(200) CHARACTER SET UTF8,
    "Lat"                      DOUBLE PRECISION,
    "Lng"                      DOUBLE PRECISION,
    "InternalTerritoryNumber"  INTEGER
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Addresses" ADD CONSTRAINT "PK_Addresses" PRIMARY KEY ("IdAddress");


/******************************************************************************/
/*                                Foreign Keys                                */
/******************************************************************************/

ALTER TABLE "Addresses" ADD CONSTRAINT ADDRESSESKEY0 FOREIGN KEY ("IdCity") REFERENCES "Cities" ("IdCity");
ALTER TABLE "Addresses" ADD CONSTRAINT ADDRESSESKEY1 FOREIGN KEY ("IdTerritory") REFERENCES "Territories" ("IdTerritory");

/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Cities" (
    "IdCity"        INTEGER NOT NULL,
    "Name"          VARCHAR(80) CHARACTER SET UTF8 NOT NULL,
    "IdDepartment"  INTEGER NOT NULL,
    "Area"          BLOB SUB_TYPE 1 SEGMENT SIZE 80
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Cities" ADD PRIMARY KEY ("IdCity");


/******************************************************************************/
/*                                Foreign Keys                                */
/******************************************************************************/

ALTER TABLE "Cities" ADD CONSTRAINT CITIESKEY0 FOREIGN KEY ("IdDepartment") REFERENCES "Departments" ("IdDepartment");

/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Departments" (
    "IdDepartment"  INTEGER NOT NULL,
    "Name"          VARCHAR(80) CHARACTER SET UTF8 NOT NULL,
    "Area"          BLOB SUB_TYPE 1 SEGMENT SIZE 80
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Departments" ADD PRIMARY KEY ("IdDepartment");

/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Publishers" (
    "IdPublisher"  INTEGER NOT NULL,
    "Name"         VARCHAR(80) CHARACTER SET UTF8 NOT NULL,
    "Address"      BLOB SUB_TYPE 1 SEGMENT SIZE 80 CHARACTER SET UTF8,
    "IdCity"       INTEGER,
    "Notes"        BLOB SUB_TYPE 1 SEGMENT SIZE 80 CHARACTER SET UTF8 NOT NULL,
    "Phone1"       VARCHAR(30),
    "Phone2"       VARCHAR(30),
    "Zip"          VARCHAR(15)
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Publishers" ADD PRIMARY KEY ("IdPublisher");


/******************************************************************************/
/*                                Foreign Keys                                */
/******************************************************************************/

ALTER TABLE "Publishers" ADD CONSTRAINT PUBLISHERSKEY0 FOREIGN KEY ("IdCity") REFERENCES "Cities" ("IdCity");

/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Territories" (
    "IdTerritory"  INTEGER NOT NULL,
    "Number"       INTEGER,
    "Name"         VARCHAR(80) CHARACTER SET UTF8 NOT NULL,
    "Area"         BLOB SUB_TYPE 1 SEGMENT SIZE 80
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Territories" ADD PRIMARY KEY ("IdTerritory");

/******************************************************************************/
/*                                   Tables                                   */
/******************************************************************************/



CREATE TABLE "Tours" (
    "IdTerritory"  INTEGER NOT NULL,
    "BeginDate"    TIMESTAMP NOT NULL,
    "EndDate"      TIMESTAMP,
    "TourNumber"   INTEGER NOT NULL,
    "IdPublisher"  INTEGER
);




/******************************************************************************/
/*                                Primary Keys                                */
/******************************************************************************/

ALTER TABLE "Tours" ADD PRIMARY KEY ("IdTerritory", "TourNumber");


/******************************************************************************/
/*                                Foreign Keys                                */
/******************************************************************************/

ALTER TABLE "Tours" ADD CONSTRAINT TOURSKEY0 FOREIGN KEY ("IdPublisher") REFERENCES "Publishers" ("IdPublisher");
ALTER TABLE "Tours" ADD CONSTRAINT TOURSKEY1 FOREIGN KEY ("IdTerritory") REFERENCES "Territories" ("IdTerritory");
