-- Tabel balita
CREATE TABLE balita (
    NIK VARCHAR(16) PRIMARY KEY,
    FOREIGN KEY (namaOrangtua) REFERENCES orangtua(namaOrangtua),
    namaAnak VARCHAR(100) NOT NULL,
    tanggalLahir DATE NOT NULL,
    umur INT NOT NULL,
    jenisKelamin VARCHAR(10) CHECK (jenisKelamin IN ('laki-laki', 'perempuan')),
    alamat VARCHAR(255) NOT NULL,
    namaPosyandu VARCHAR(255),
    beratBadan INT,
    tinggiBadan INT, 
    statusGizi VARCHAR(255)
);


-- Tabel userAccount
CREATE TABLE userAccount (
    NIK VARCHAR(16) PRIMARY KEY,
    peran VARCHAR(10) CHECK (peran IN ('orangtua', 'kader')),
    kataSandi VARCHAR(255) NOT NULL
);


-- Tabel orangtua
CREATE TABLE orangtua (
    NIK VARCHAR (16) PRIMARY KEY NOT NULL,
    FOREIGN KEY (NIK) REFERENCES userAccount(NIK),
    NIK VARCHAR (16) PRIMARY KEY,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    namaOrangtua VARCHAR(100) NOT NULL,
    noTelp VARCHAR(13),  
);


-- Tabel petugas
CREATE TABLE petugas (
    NIK VARCHAR(16) PRIMARY KEY NOT NULL,
    FOREIGN KEY (NIK) REFERENCES userAccount(NIK),
    namaPetugas VARCHAR(255) NOT NULL,
    noTelp VARCHAR(13) CHECK (noTelp NOT LIKE '%[^0-9]%'),
    peran VARCHAR(25),
);

CREATE TABLE RecordTimbangPersonal (
    NIK INT PRIMARY KEY,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    namaAnak VARCHAR(255) NOT NULL,
    FOREIGN KEY (namaAnak) REFERENCES balita(namaAnak),
    Tanggal_Timbang DATE NOT NULL,
    Berat_Badan INT NOT NULL,
    Tinggi_Badan INT NOT NULL,
    Status_Gizi VARCHAR(255) NOT NULL
);



-- Tabel penerimaObatCacing
CREATE TABLE penerimaObatCacing (
    NIK VARCHAR(16) PRIMARY KEY,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    namaAnak VARCHAR(100) NOT NULL,
    FOREIGN KEY (namaAnak) REFERENCES balita(namaAnak),
    PRIMARY KEY (ID_Anak, Nama_Anak),
    pemberianAbendazole BIT NOT NULL
);


-- Tabel polaMakan
CREATE TABLE polaMakan (
    NIK VARCHAR(16) PRIMARY KEY,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    namaAnak VARCHAR (100),
    FOREIGN KEY (namaAnak) REFERENCES balita(namaAnak),
    daftarMakan VARCHAR(100) NOT NULL,
    intervensiGizi VARCHAR(100) NOT NULL,
    teksturMakanan VARCHAR(100) NOT NULL,
    frekuensiMakan VARCHAR(100) NOT NULL
);


-- Tabel kebersihanGigiAnak
CREATE TABLE kebersihanGigiAnak (
    NIK VARCHAR(16) PRIMARY KEY,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    namaAnak VARCHAR (100),
    FOREIGN KEY (namaAnak) REFERENCES balita(namaAnak),
    jenisKelamin VARCHAR(10) CHECK (jenisKelamin IN ('laki-laki', 'perempuan')),
    FOREIGN KEY (jenisKelamin) REFERENCES balita(jenisKelamin),
    tanggalPeriksa DATE NOT NULL,
    kebersihanGigi BIT,
    karies BIT
);


-- Tabel pemberianVitaminA
CREATE TABLE pemberianVitaminA (
    NIK VARCHAR(16) PRIMARY KEY NOT NULL,
    FOREIGN KEY (NIK) REFERENCES balita(NIK),
    jenisVitaminA VARCHAR(5) NOT NULL CHECK (jenisVitaminA IN ('BIRU', 'MERAH'))
);

