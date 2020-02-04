CREATE EXTENSION postgres_fdw;

CREATE SERVER test_shard_1
FOREIGN DATA WRAPPER postgres_fdw 
OPTIONS( host 'shard-1', port '5432', dbname 'root' );

CREATE USER MAPPING FOR root
SERVER test_shard_1
OPTIONS (user 'root', password '111');


CREATE SERVER test_shard_2
FOREIGN DATA WRAPPER postgres_fdw 
OPTIONS( host 'shard-2', port '5432', dbname 'root' );

CREATE USER MAPPING FOR root
SERVER test_shard_2
OPTIONS (user 'root', password '111');

CREATE TABLE Test (
  Id integer NOT NULL,
  FirstName varchar(30) NOT NULL,
  SecondName varchar(30) NOT NULL,
  Phone varchar(17) NOT NULL,
  BirthDate date NOT NULL,
  BirthDay integer NOT NULL,
  BirthMonth integer NOT NULL,
  BirthYear integer NOT NULL
) PARTITION BY RANGE (BirthYear);

CREATE FOREIGN TABLE Test_1  PARTITION OF Test
FOR VALUES FROM (MINVALUE) TO (50)
SERVER test_shard_1;

CREATE FOREIGN TABLE Test_2  PARTITION OF Test
FOR VALUES FROM (50) TO (MAXVALUE)
SERVER test_shard_2;
--OPTIONS (schema_name 'public', table_name 'test');
