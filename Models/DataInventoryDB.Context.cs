﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DataInventoryEntities : DbContext
    {
        public DataInventoryEntities()
            : base("name=DataInventoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblCollection> tblCollection { get; set; }
        public DbSet<tblContact> tblContact { get; set; }
        public DbSet<tblData> tblData { get; set; }
        public DbSet<tblDataset_> tblDataset_ { get; set; }
        public DbSet<tblDetail> tblDetail { get; set; }
        public DbSet<tblDFLink_> tblDFLink_ { get; set; }
        public DbSet<tblElement_> tblElement_ { get; set; }
        public DbSet<tblElementData> tblElementData { get; set; }
        public DbSet<tblEVLink_> tblEVLink_ { get; set; }
        public DbSet<tblFELink_> tblFELink_ { get; set; }
        public DbSet<tblFile_> tblFile_ { get; set; }
        public DbSet<tblFollow_Up> tblFollow_Up { get; set; }
        public DbSet<tblProgram> tblProgram { get; set; }
        public DbSet<tblRespondent> tblRespondent { get; set; }
        public DbSet<tblSDLink_> tblSDLink_ { get; set; }
        public DbSet<tblStudy> tblStudy { get; set; }
        public DbSet<tblValue_> tblValue_ { get; set; }
        public DbSet<tblValueData> tblValueData { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<uspExportFileVariable_Result> uspExportFileVariable(Nullable<System.Guid> fileID, Nullable<int> studyID)
        {
            var fileIDParameter = fileID.HasValue ?
                new ObjectParameter("fileID", fileID) :
                new ObjectParameter("fileID", typeof(System.Guid));
    
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspExportFileVariable_Result>("uspExportFileVariable", fileIDParameter, studyIDParameter);
        }
    
        public virtual int uspExportSeriesVariable(string variableList, string cbSeriesVarAll, Nullable<int> seriesID, string searchTerm, string searchType)
        {
            var variableListParameter = variableList != null ?
                new ObjectParameter("variableList", variableList) :
                new ObjectParameter("variableList", typeof(string));
    
            var cbSeriesVarAllParameter = cbSeriesVarAll != null ?
                new ObjectParameter("cbSeriesVarAll", cbSeriesVarAll) :
                new ObjectParameter("cbSeriesVarAll", typeof(string));
    
            var seriesIDParameter = seriesID.HasValue ?
                new ObjectParameter("seriesID", seriesID) :
                new ObjectParameter("seriesID", typeof(int));
    
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspExportSeriesVariable", variableListParameter, cbSeriesVarAllParameter, seriesIDParameter, searchTermParameter, searchTypeParameter);
        }
    
        public virtual int uspExportStudyVariable(Nullable<int> studyID, string variableList, string cbSeriesVarAll, string searchTerm, string searchType)
        {
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            var variableListParameter = variableList != null ?
                new ObjectParameter("variableList", variableList) :
                new ObjectParameter("variableList", typeof(string));
    
            var cbSeriesVarAllParameter = cbSeriesVarAll != null ?
                new ObjectParameter("cbSeriesVarAll", cbSeriesVarAll) :
                new ObjectParameter("cbSeriesVarAll", typeof(string));
    
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspExportStudyVariable", studyIDParameter, variableListParameter, cbSeriesVarAllParameter, searchTermParameter, searchTypeParameter);
        }
    
        public virtual ObjectResult<uspGetSeriesFile_Result> uspGetSeriesFile(Nullable<int> seriesID)
        {
            var seriesIDParameter = seriesID.HasValue ?
                new ObjectParameter("seriesID", seriesID) :
                new ObjectParameter("seriesID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetSeriesFile_Result>("uspGetSeriesFile", seriesIDParameter);
        }
    
        public virtual ObjectResult<uspGetStudyDetail_Result> uspGetStudyDetail(Nullable<int> studyID, string studyType)
        {
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            var studyTypeParameter = studyType != null ?
                new ObjectParameter("studyType", studyType) :
                new ObjectParameter("studyType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetStudyDetail_Result>("uspGetStudyDetail", studyIDParameter, studyTypeParameter);
        }
    
        public virtual ObjectResult<uspGetStudyFile_Result> uspGetStudyFile(Nullable<int> studyID)
        {
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetStudyFile_Result>("uspGetStudyFile", studyIDParameter);
        }
    
        public virtual int uspGetStudyQuestionnaire(Nullable<int> studyID, string studyType)
        {
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            var studyTypeParameter = studyType != null ?
                new ObjectParameter("studyType", studyType) :
                new ObjectParameter("studyType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspGetStudyQuestionnaire", studyIDParameter, studyTypeParameter);
        }
    
        public virtual int uspPopulateData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateData");
        }
    
        public virtual int uspPopulateElementData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateElementData");
        }
    
        public virtual int uspPopulateFollowupDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateFollowupDetail");
        }
    
        public virtual int uspPopulateRespondent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateRespondent");
        }
    
        public virtual int uspPopulateSeriesDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateSeriesDetail");
        }
    
        public virtual int uspPopulateStudyDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateStudyDetail");
        }
    
        public virtual int uspPopulateValueData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPopulateValueData");
        }
    
        public virtual ObjectResult<uspSearchDataBySeries_Result> uspSearchDataBySeries(string searchTerm, string searchType)
        {
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspSearchDataBySeries_Result>("uspSearchDataBySeries", searchTermParameter, searchTypeParameter);
        }
    
        public virtual int uspSearchDataByStudy(Nullable<int> programID, string searchTerm, string searchType)
        {
            var programIDParameter = programID.HasValue ?
                new ObjectParameter("programID", programID) :
                new ObjectParameter("programID", typeof(int));
    
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchDataByStudy", programIDParameter, searchTermParameter, searchTypeParameter);
        }
    
        public virtual int uspSearchVariableDataBySeries(Nullable<int> seriesID, string searchTerm, string searchType, Nullable<int> page, string sortColumn, string sortDirection)
        {
            var seriesIDParameter = seriesID.HasValue ?
                new ObjectParameter("seriesID", seriesID) :
                new ObjectParameter("seriesID", typeof(int));
    
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            var pageParameter = page.HasValue ?
                new ObjectParameter("page", page) :
                new ObjectParameter("page", typeof(int));
    
            var sortColumnParameter = sortColumn != null ?
                new ObjectParameter("sortColumn", sortColumn) :
                new ObjectParameter("sortColumn", typeof(string));
    
            var sortDirectionParameter = sortDirection != null ?
                new ObjectParameter("sortDirection", sortDirection) :
                new ObjectParameter("sortDirection", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchVariableDataBySeries", seriesIDParameter, searchTermParameter, searchTypeParameter, pageParameter, sortColumnParameter, sortDirectionParameter);
        }
    
        public virtual int uspSearchVariableDataByStudy(Nullable<int> studyID, string searchTerm, string searchType, Nullable<int> page, string sortColumn, string sortDirection)
        {
            var studyIDParameter = studyID.HasValue ?
                new ObjectParameter("studyID", studyID) :
                new ObjectParameter("studyID", typeof(int));
    
            var searchTermParameter = searchTerm != null ?
                new ObjectParameter("searchTerm", searchTerm) :
                new ObjectParameter("searchTerm", typeof(string));
    
            var searchTypeParameter = searchType != null ?
                new ObjectParameter("searchType", searchType) :
                new ObjectParameter("searchType", typeof(string));
    
            var pageParameter = page.HasValue ?
                new ObjectParameter("page", page) :
                new ObjectParameter("page", typeof(int));
    
            var sortColumnParameter = sortColumn != null ?
                new ObjectParameter("sortColumn", sortColumn) :
                new ObjectParameter("sortColumn", typeof(string));
    
            var sortDirectionParameter = sortDirection != null ?
                new ObjectParameter("sortDirection", sortDirection) :
                new ObjectParameter("sortDirection", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchVariableDataByStudy", studyIDParameter, searchTermParameter, searchTypeParameter, pageParameter, sortColumnParameter, sortDirectionParameter);
        }
    }
}
