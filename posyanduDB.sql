CREATE DATABASE posyandu;

CREATE TABLE balita (
	NIK VARCHAR (16) PRIMARY KEY NOT NULL,
	idAnak VARCHAR (255) NOT NULL,
	namaOrantua VARCHAR (255) NOT NULL,
	tanggalLahir DATE NOT NULL,
	umur INT NOT NULL,
	jenisKelamin VARCHAR (10) NOT NULL,
	alamat VARCHAR(255) NOT NULL,
	namaPosyandu VARCHAR (255) NOT NULL,
	beratBadan	INT NOT NULL,
	tinggiBadan INT NOT NULL,
	statusGizi VARCHAR
	);

CREATE TABLE orangtua (
	FOREIGN KEY (NIK) REFERENCES userAccount(NIK),
	FOREIGN KEY (idAnak) REFERENCES balita(idAnak),
	idOrangtua VARCHAR,
	namaOrangtua VARCHAR (100) NOT NULL,
	noTelp VARCHAR (13) NOT NULL
);


CREATE TABLE userAccount (
    NIK VARCHAR(16) PRIMARY KEY NOT NULL,
    role VARCHAR(10) NOT NULL CHECK (role IN ('orangtua', 'kader')),
	password VARCHAR (8) NOT NULL 
);

CREATE TABLE petugas(
	FOREIGN KEY (NIK) REFERENCES userAccount(NIK),
	namaPetugas VARCHAR (255) NOT NULL,
	noTelp VARCHAR (13) NOT NULL CONSTRAINT noTelp CHECK (noTelp NOT LIKE '%[^0-9]%'),
	peran Varchar (25) NOT NULL
);

	