CREATE DATABASE posyandu;

CREATE TABLE balita (
	idAnak VARCHAR (255) PRIMARY KEY NOT NULL,
	namaOrantua VARCHAR (255) NOT NULL,
	namaAnak VARCHAR (225) NOT NULL,
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


CREATE TABLE penerimaObatCacing (
	FOREIGN KEY (idAnak) REFERENCES userAccount(idAnak),
	FOREIGN KEY (namaAnak) REFERENCES userAccount(namaAnak),
	pemberianAbendazole BIT NOT NULL,
);

CREATE TABLE polaMakan(
	FOREIGN KEY (idAnak) REFERENCES userAccount(idAnak),
	FOREIGN KEY (namaAnak) REFERENCES userAccount(namaAnak),
	daftarMakan VARCHAR (100) NOT NULL,
	intervensiGizi VARCHAR (100) NOT NULL,
	teksturMakanan VARCHAR (100) NOT NULL,
	frekuensiMakan VARCHAR (100) NOT NULL,
);


CREATE TABLE kebersihanGigiAnak (
	FOREIGN KEY (idAnak) REFERENCES userAccount(idAnak),
	FOREIGN KEY (namaAnak) REFERENCES userAccount(namaAnak),
	FOREIGN KEY (jenisKelamin) REFERENCES userAccount(jenisKelamin),
	tanggalPeriksa DATE NOT NULL,
	kebersihanGigi BIT,
	karies BIT
);


CREATE TABLE pemberianVitaminA(
	FOREIGN KEY (idAnak) REFERENCES userAccount(idAnak),
	FOREIGN KEY (namaAnak) REFERENCES userAccount(namaAnak),
	FOREIGN KEY (jenisKelamin) REFERENCES userAccount(jenisKelamin),
	jenisVitaminA VARCHAR(5) NOT NULL CHECK (jenisVitaminA IN ('BIRU', 'MERAH'))
);