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
    
    public partial class tblRespondent
    {
        public int Respondent_ID { get; set; }
        public Nullable<int> Collection_ID { get; set; }
        public string Respondent_Type { get; set; }
        public string Respondent_Type_Detail { get; set; }
        public string Topics { get; set; }
        public Nullable<int> Expected_Sample_Size { get; set; }
        public Nullable<int> Actual_Sample_Size { get; set; }
        public Nullable<double> Response_Rate_Estimated { get; set; }
        public Nullable<double> Response_Rate_Actual { get; set; }
        public string Final_Data_Format { get; set; }
        public string Required_Response_Detail { get; set; }
        public string Response_Requirement_Reason { get; set; }
        public Nullable<bool> Explicit_Consent { get; set; }
        public Nullable<bool> Implicit_Consent { get; set; }
        public string VC_Language_IC { get; set; }
        public Nullable<bool> Respondent_Age_0_2 { get; set; }
        public Nullable<bool> Respondent_Age_3_5 { get; set; }
        public Nullable<bool> Respondent_Age_6_21 { get; set; }
        public Nullable<bool> Respondent_Age_Older_Than_21 { get; set; }
        public Nullable<bool> Respondent_Age_NA { get; set; }
        public Nullable<bool> Respondent_Pre_K { get; set; }
        public Nullable<bool> Respondent_Elementary { get; set; }
        public Nullable<bool> Respondent_Middle { get; set; }
        public Nullable<bool> Respondent_High_School { get; set; }
        public Nullable<bool> Respondent_Postsecondary { get; set; }
        public Nullable<bool> Respondent_Graduate { get; set; }
        public Nullable<bool> Respondent_Continued_Technical_Ed { get; set; }
        public Nullable<bool> Respondent_Adult_Education { get; set; }
        public Nullable<bool> Respondent_Education_Level_NA { get; set; }
        public string Respondent_Other_Population { get; set; }
        public string Respondent_Population_Detail { get; set; }
        public Nullable<bool> Administrative_Records { get; set; }
        public Nullable<bool> Address_Update { get; set; }
        public Nullable<bool> List_Data { get; set; }
        public Nullable<bool> Recruitment { get; set; }
        public Nullable<bool> Coordination_Help { get; set; }
        public Nullable<bool> Screener { get; set; }
        public Nullable<bool> Assessment { get; set; }
        public Nullable<bool> Survey { get; set; }
        public Nullable<bool> Abbreviated_Survey { get; set; }
        public Nullable<bool> Program_Reporting { get; set; }
        public Nullable<bool> EDFacts { get; set; }
        public Nullable<bool> CPS { get; set; }
        public Nullable<bool> NSLDS { get; set; }
        public string Other_Response_Type { get; set; }
        public Nullable<int> Paper { get; set; }
        public Nullable<int> Phone__Not_CATI_ { get; set; }
        public Nullable<int> CATI { get; set; }
        public Nullable<int> Web { get; set; }
        public Nullable<int> Email { get; set; }
        public Nullable<int> F2F__Not_CAPI_ { get; set; }
        public Nullable<int> CAPI { get; set; }
        public Nullable<int> Spreadsheet { get; set; }
        public Nullable<int> PRS { get; set; }
        public string Other_Collection_Mode { get; set; }
        public string Collection_Mode_Detail { get; set; }
        public string Other_Languages { get; set; }
        public string Interpreters { get; set; }
        public Nullable<bool> Feasibility_Calls { get; set; }
        public Nullable<bool> Pretest { get; set; }
        public Nullable<bool> Cog_Labs { get; set; }
        public Nullable<bool> Focus_Groups { get; set; }
        public Nullable<bool> PIlot_Test { get; set; }
        public Nullable<bool> Field_Test { get; set; }
        public Nullable<int> Program_ID { get; set; }
        public Nullable<int> Study_ID { get; set; }
        public Nullable<int> Follow_up_ID { get; set; }
        public string Authorizing_Law { get; set; }
    }
}
