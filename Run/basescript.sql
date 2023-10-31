SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP ROLE IF EXISTS simbirgoadmin;
CREATE ROLE simbirgoadmin LOGIN SUPERUSER PASSWORD 'simbirgoadmin';

ALTER DATABASE simbirgo OWNER TO postgres;

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

ALTER SCHEMA public OWNER TO pg_database_owner;

CREATE TABLE public."Accounts" (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	username varchar NOT NULL,
	"password" varchar NOT NULL,
	isadmin bool NOT NULL DEFAULT false,
	balance numeric NOT NULL,
	CONSTRAINT accounts_pk PRIMARY KEY (id)
);

CREATE TABLE public."Rents" (
	id int8 NOT NULL,
	transportid int8 NOT NULL,
	userid int8 NOT NULL,
	timestart varchar NOT NULL,
	timeend varchar NULL,
	priceofunit numeric NOT NULL,
	pricetype int4 NOT NULL,
	finalprice numeric NULL,
	CONSTRAINT rents_pk PRIMARY KEY (id)
);

CREATE TABLE public."Transports" (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	ownerid int8 NOT NULL,
	transporttype varchar NOT NULL,
	model varchar NOT NULL,
	color varchar NOT NULL,
	identifier varchar NOT NULL,
	description varchar NULL,
	latitude numeric NOT NULL,
	longitude numeric NOT NULL,
	minuteprice numeric NULL,
	dayprice numeric NULL,
	canberented bool NOT NULL,
	CONSTRAINT transports_pk PRIMARY KEY (id)
);