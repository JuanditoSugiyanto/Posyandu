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
    
    public partial class userAccount
    {
        public string NIK { get; set; }
        public string peran { get; set; }
        public string kataSandi { get; set; }
    
        public virtual orangtua orangtua { get; set; }
        public virtual petuga petuga { get; set; }
    }
}
