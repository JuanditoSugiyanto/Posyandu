//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Posyandu
{
    using System;
    using System.Collections.Generic;
    
    public partial class balita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public balita()
        {
            this.kebersihanGigiAnaks = new HashSet<kebersihanGigiAnak>();
            this.penerimaObatCacings = new HashSet<penerimaObatCacing>();
            this.polaMakans = new HashSet<polaMakan>();
            this.RecordTimbangPersonals = new HashSet<RecordTimbangPersonal>();
        }
    
        public string NIK { get; set; }
        public string namaAnak { get; set; }
        public System.DateTime tanggalLahir { get; set; }
        public int umur { get; set; }
        public string jenisKelamin { get; set; }
        public string alamat { get; set; }
        public string namaPosyandu { get; set; }
        public Nullable<double> beratBadan { get; set; }
        public Nullable<double> tinggiBadan { get; set; }
        public string statusGizi { get; set; }
        public string namaOrangtua { get; set; }
        public string NIK_OrangTua { get; set; }
    
        public virtual orangtua orangtua { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kebersihanGigiAnak> kebersihanGigiAnaks { get; set; }
        public virtual pemberianVitaminA pemberianVitaminA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<penerimaObatCacing> penerimaObatCacings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<polaMakan> polaMakans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecordTimbangPersonal> RecordTimbangPersonals { get; set; }
        public virtual orangtua orangtua1 { get; set; }
    }
}
