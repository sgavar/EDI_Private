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
    
    public partial class uspGetStudyFile_Result
    {
        public System.Guid fileID { get; set; }
        public string fileName { get; set; }
        public string datasetTitle { get; set; }
        public string fileLocation { get; set; }
        public string fileLocationDetail { get; set; }
        public string fileDataFormat { get; set; }
        public int studyID { get; set; }
        public string studyName { get; set; }
    }
}
