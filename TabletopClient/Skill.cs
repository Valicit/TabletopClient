//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TabletopClient
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skill
    {
        public int id { get; set; }
        public int max_level { get; set; }
        public Nullable<int> mp_cost { get; set; }
        public Nullable<double> potency { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> class_id { get; set; }
    
        public virtual Class Class { get; set; }
    }
}
