CREATE DATABASE cleanMode
USE cleanMode
CREATE TABLE customers (
	customer_id int IDENTITY(1,1) PRIMARY KEY,
	email_address varchar(255),
	first_name varchar(255),
	last_name varchar(255),
	physical_address varchar(255)
)
CREATE TABLE quotes (
	quote_id int IDENTITY(1,1) PRIMARY KEY,
	customer_id int FOREIGN KEY REFERENCES customers(customer_id),
	quote real,
	quote_summary varchar(255)
)
CREATE TABLE roomTypes (
	roomType_id int IDENTITY(1,1) PRIMARY KEY,
	roomType varchar(255)
)
CREATE TABLE quoteRoomTypes (
	quote_id int FOREIGN KEY REFERENCES quotes(quote_id),
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id)

)
CREATE TABLE bedrooms (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE livingrooms (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE bathrooms (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE kitchens (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE entrance (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
	CREATE TABLE basement (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE garage (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE diningroom (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
CREATE TABLE stairs (
	roomType_id int FOREIGN KEY REFERENCES roomTypes(roomType_id),
	price_per_sqft real
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'jsebujangwe3265@conestogac.on.ca',
	'Joseph',
	'Sebujangwe',
	'124 Becker Street'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'jjaramillomejia0773@conestogac.on.ca',
	'Jose',
	'Mejia',
	'555 Queen Street'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'jbrookshaw7234@conestogac.on.ca',
	'Jackson',
	'Brookshaw',
	'2 Adelaide Street'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'connormc@gmail.com',
	'Connor',
	'McGregor',
	'23 O''Hare Street'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'shaka2@gmail.com',
	'Shaka',
	'Zulu',
	'54 Salonga Ave'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'dtrumpjr@gmail.com',
	'Donald',
	'Trump',
	'Trump Tower'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'jtrudeau@gmail.com',
	'Justin',
	'Trudeau',
	'Rideau Cottage'
)
INSERT INTO customers (
	email_address,
	first_name,
	last_name,
	physical_address
) VALUES (
	'jbiden1@gmail.com',
	'Joseph',
	'Biden',
	'White House'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Bedroom'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Bathroom'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Diningroom'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Livingroom'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Garage'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Entrance'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Kitchen'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Basement'
)
INSERT INTO roomTypes (
	roomType
) VALUES (
	'Stairs'
)
INSERT INTO bedrooms (
	roomType_id,
	price_per_sqft
) VALUES (
	1,
	4.18
)
INSERT INTO bathrooms (
	roomType_id,
	price_per_sqft
) VALUES (
	2,
	6.17
)
INSERT INTO kitchens (
	roomType_id,
	price_per_sqft
) VALUES (
	7,
	9.9
)
INSERT INTO livingrooms (
	roomType_id,
	price_per_sqft
) VALUES (
	4,
	5.18
)
INSERT INTO entrance (
	roomType_id,
	price_per_sqft
) VALUES (
	6,
	1.58
)
INSERT INTO basement (
	roomType_id,
	price_per_sqft
) VALUES (
	8,
	4.18
)
INSERT INTO garage (
	roomType_id,
	price_per_sqft
) VALUES (
	5,
	4.18
)INSERT INTO stairs (
	roomType_id,
	price_per_sqft
) VALUES (
	9 ,
	1.58
)
INSERT INTO diningroom (
	roomType_id,
	price_per_sqft
) VALUES (
	3,
	4.18
)



;


