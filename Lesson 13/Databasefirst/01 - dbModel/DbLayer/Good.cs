//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01___dbModel.DbLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Good
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}