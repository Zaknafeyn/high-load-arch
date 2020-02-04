CREATE EXTENSION postgres_fdw;

-- CREATE SERVER test_main_server 
-- FOREIGN DATA WRAPPER postgres_fdw 
-- OPTIONS( host '127.0.0.1', port '5432', dbname 'Test' );

-- CREATE USER MAPPING FOR root
-- SERVER test_main_server
-- OPTIONS (user 'root', password '111');

CREATE SERVER test_shard_1
FOREIGN DATA WRAPPER postgres_fdw 
OPTIONS( host 'shard-1', port '5432', dbname 'Test' );

CREATE USER MAPPING FOR root
SERVER test_shard_1
OPTIONS (user 'root', password '111');

CREATE DATABASE TEST;

CREATE FOREIGN TABLE Test_1 (
  Id integer NOT NULL,
  FirstName varchar(30) NOT NULL,
  SecondName varchar(30) NOT NULL,
  Phone varchar(17) NOT NULL,
  BirthDate date NOT NULL,
  BirthDay integer NOT NULL,
  BirthMonth integer NOT NULL,
  BirthYear integer NOT NULL
) 
SERVER test_main_server 
OPTIONS (schema_name 'public', table_name 'test');

CREATE FOREIGN TABLE Test_2 (
  Id integer NOT NULL,
  FirstName varchar(30) NOT NULL,
  SecondName varchar(30) NOT NULL,
  Phone varchar(17) NOT NULL,
  BirthDate date NOT NULL,
  BirthDay integer NOT NULL,
  BirthMonth integer NOT NULL,
  BirthYear integer NOT NULL
) 
SERVER test_shard_1
OPTIONS (schema_name 'public', table_name 'test');

-- CREATE INDEX BirthDateBTree on Test USING BTREE (BirthDate);
-- CREATE INDEX BirthDateHash on Test USING HASH (BirthDate);
-- CREATE INDEX BirthDayBTree on Test USING BTREE (BirthDay);
-- CREATE INDEX BirthDayHash on Test USING HASH (BirthDay);
-- CREATE INDEX BirthMonthBTree on Test USING BTREE (BirthMonth);
-- CREATE INDEX BirthMonthHash on Test USING HASH (BirthMonth);
-- CREATE INDEX BirthYearBTree on Test USING BTREE (BirthYear);
-- CREATE INDEX BirthYearHash on Test USING HASH (BirthYear);

CREATE VIEW Test AS
  SELECT * FROM Test_1
  UNION ALL
  SELECT * FROM Test_2;



CREATE RULE test_insert AS ON INSERT TO Test
DO INSTEAD NOTHING;
CREATE RULE test_update AS ON UPDATE TO Test
DO INSTEAD NOTHING;
CREATE RULE test_delete AS ON DELETE TO Test
DO INSTEAD NOTHING;


CREATE RULE test_insert_to_1 AS ON INSERT TO Test
WHERE ( BirthYear <= 50 )
DO INSTEAD INSERT INTO Test_1 VALUES (NEW.*);

CREATE RULE test_insert_to_2 AS ON INSERT TO Test
WHERE ( BirthYear > 50 )
DO INSTEAD INSERT INTO Test_2 VALUES (NEW.*);

