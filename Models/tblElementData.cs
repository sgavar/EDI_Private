//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataInventory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblElementData
    {
        public int Data_ID { get; set; }
        public Nullable<int> Program_ID { get; set; }
        public Nullable<int> Study_ID { get; set; }
        public Nullable<System.Guid> Element_ID { get; set; }
        public string Element_Name { get; set; }
        public string Element_Label { get; set; }
        public string Element_Extended_Definition { get; set; }
        public string Element_Question { get; set; }
        public string Searchable_Data { get; set; }
        public string Value_Data { get; set; }
        public Nullable<int> Value_Count { get; set; }
        public string File_List { get; set; }
        public string File_List_Export { get; set; }
    }
}
