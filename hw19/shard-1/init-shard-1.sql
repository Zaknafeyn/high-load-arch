CREATE DATABASE TEST owner root;

CREATE TABLE Test_1 (
  Id integer NOT NULL PRIMARY KEY,
  FirstName varchar(30) NOT NULL,
  SecondName varchar(30) NOT NULL,
  Phone varchar(17) NOT NULL,
  BirthDate date NOT NULL,
  BirthDay integer NOT NULL,
  BirthMonth integer NOT NULL,
  BirthYear integer NOT NULL
) ;

CREATE INDEX BirthDateBTree on Test_1 USING BTREE (BirthDate);
CREATE INDEX BirthDateHash on Test_1 USING HASH (BirthDate);
CREATE INDEX BirthDayBTree on Test_1 USING BTREE (BirthDay);
CREATE INDEX BirthDayHash on Test_1 USING HASH (BirthDay);
CREATE INDEX BirthMonthBTree on Test_1 USING BTREE (BirthMonth);
CREATE INDEX BirthMonthHash on Test_1 USING HASH (BirthMonth);
CREATE INDEX BirthYearBTree on Test_1 USING BTREE (BirthYear);
CREATE INDEX BirthYearHash on Test_1 USING HASH (BirthYear);