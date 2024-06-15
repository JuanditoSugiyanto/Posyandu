-- Buat database
CREATE DATABASE posyandu;
GO

-- Gunakan database
USE posyandu;
GO

-- Tabel balita
CREATE TABLE balita (
    idAnak VARCHAR(255) PRIMARY KEY NOT NULL,
    namaOrangtua VARCHAR(255) NOT NULL,
    namaAnak VARCHAR(255) NOT NULL,
    tanggalLahir DATE NOT NULL,
    umur INT NOT NULL,
    jenisKelamin VARCHAR(10) NOT NULL,
    alamat VARCHAR(255) NOT NULL,
    namaPosyandu VARCHAR(255) NOT NULL,
    beratBadan INT NOT NULL,
    tinggiBadan INT NOT NULL,
    statusGizi VARCHAR(255)
);
GO

-- Tabel userAccount
CREATE TABLE userAccount (
    NIK VARCHAR(16) PRIMARY KEY NOT NULL,
    role VARCHAR(10) NOT NULL CHECK (role IN ('orangtua', 'kader')),
    password VARCHAR(255) NOT NULL
);
GO

-- Tabel orangtua
CREATE TABLE orangtua (
    idOrangtua VARCHAR(255) PRIMARY KEY NOT NULL,
    NIK VARCHAR(16) NOT NULL,
    idAnak VARCHAR(255) NOT NULL,
    namaOrangtua VARCHAR(100) NOT NULL,
    noTelp VARCHAR(13) NOT NULL,
    FOREIGN KEY (NIK) REFERENCES userAccount(NIK),
    FOREIGN KEY (idAnak) REFERENCES balita(idAnak)
);
GO

-- Tabel petugas
CREATE TABLE petugas (
    NIK VARCHAR(16) PRIMARY KEY NOT NULL,
    namaPetugas VARCHAR(255) NOT NULL,
    noTelp VARCHAR(13) NOT NULL CHECK (noTelp NOT LIKE '%[^0-9]%'),
    peran VARCHAR(25) NOT NULL,
    FOREIGN KEY (NIK) REFERENCES userAccount(NIK)
);
GO

-- Tabel penerimaObatCacing
CREATE TABLE penerimaObatCacing (
    idAnak VARCHAR(255) PRIMARY KEY NOT NULL,
    pemberianAbendazole BIT NOT NULL,
    FOREIGN KEY (idAnak) REFERENCES balita(idAnak)
);
GO

-- Tabel polaMakan
CREATE TABLE polaMakan (
    idAnak VARCHAR(255) PRIMARY KEY NOT NULL,
    daftarMakan VARCHAR(100) NOT NULL,
    intervensiGizi VARCHAR(100) NOT NULL,
    teksturMakanan VARCHAR(100) NOT NULL,
    frekuensiMakan VARCHAR(100) NOT NULL,
    FOREIGN KEY (idAnak) REFERENCES balita(idAnak)
);
GO

-- Tabel kebersihanGigiAnak
CREATE TABLE kebersihanGigiAnak (
    idAnak VARCHAR(255) PRIMARY KEY NOT NULL,
    tanggalPeriksa DATE NOT NULL,
    kebersihanGigi BIT,
    karies BIT,
    FOREIGN KEY (idAnak) REFERENCES balita(idAnak)
);
GO

-- Tabel pemberianVitaminA
CREATE TABLE pemberianVitaminA (
    idAnak VARCHAR(255) PRIMARY KEY NOT NULL,
    jenisVitaminA VARCHAR(5) NOT NULL CHECK (jenisVitaminA IN ('BIRU', 'MERAH')),
    FOREIGN KEY (idAnak) REFERENCES balita(idAnak)
);
GO
