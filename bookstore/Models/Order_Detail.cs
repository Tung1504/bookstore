//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookstore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Detail
    {
        public int book_id { get; set; }
        public int order_id { get; set; }
        public int quantity { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
