using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataInventory.Models
{
    public class SeriesViewModel
    {
        public int seriesID { get; set; }
        public string seriesName { get; set; }
        //public string investigator { get; set; }
        public string seriesDesc { get; set; }
        public string studyList { get; set; }        
        public string investigatorList { get; set; }
        public bool searchVariables { get; set; }
        public int studyCount { get; set; }
    }

    public class StudyViewModel
    {
        public int studyID { get; set; }
        public string studyName { get; set; }
        public string studyAlternativeTitle { get; set; }
        public string studyPreviousTitle { get; set; }
        public string investigator { get; set; }
        public string studySummary { get; set; }
        public int seriesID { get; set; }
        public string seriesName { get; set; }
        public string persistentURL { get; set; }
        public string subjectTerms { get; set; }
        public string geographicCoverage { get; set; }
        public string timePeriod { get; set; }
        public string collectionDate { get; set; }
        public string periodicity { get; set; }
        public string observationUnit { get; set; }
        public string studyPopulation { get; set; }
        public string studyDataTypes { get; set; }
        public string dataCollectionPurpose { get; set; }
        public string authorizingLaw { get; set; }
        public string sorn { get; set; }
        public string targetPopulationAgeRange { get; set; }
        public string targetPopulationEducationLevel { get; set; }
        public string initialReport { get; set; }
        public string dataAvailability { get; set; }
        public string restrictedUseDate { get; set; }
        //public string couldBePublic { get; set; }
        public bool searchVariables { get; set; }
        public string bureauCode { get; set; }
        public string programCode { get; set; }
        public string jsonUniqueIdentifier { get; set; }
        public string sornURL { get; set; }
        public string publicAccessLevel { get; set; }
        public string confidentialityRestrictions { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
    }

    public class VariableViewModel
    {
        public Guid variableID { get; set; }
        public string variableName { get; set; }
        public string variableLabel { get; set; }
        public string variableExtendedDefn { get; set; }
        public string variableDetail { get; set; }
        public int studyID { get; set; }
        public string studyName { get; set; }
        //public string fileName { get; set; }
        public string fileList { get; set; }
        public string valueList { get; set; }        
        //public Int32 valueCount { get; set; }
        public Int32 totalRows { get; set; }
        //public int rowNum { get; set; }
        public Int32 firstRow { get; set; }
        public Int32 lastRow { get; set; }
        public Int32 lastPage { get; set; }
    }

    public class ValueViewModel
    {
        public Guid valueID { get; set; }
        public string valueOption { get; set; }
        public string valueLabel { get; set; }
    }

    public class FileViewModel
    {
        public Guid fileID { get; set; }
        public string fileName { get; set; }
        public string datasetTitle { get; set; }
        public string fileLocation { get; set; }
        public string fileLocationDetail { get; set; }
        public string fileDataFormat { get; set; }
        public int studyID { get; set; }
        public string studyName { get; set; }        
    }

    public class QuestionnaireViewModel
    {
        public int questionnaireID { get; set; }
        public string respondentType { get; set; }
        public string respondentTypeDetail { get; set; }
        public string responseRates { get; set; }
        public string observationUnit { get; set; }
        public string questionnaireDataTypes { get; set; }
        public string dataCollectionPurpose { get; set; }
        public string authorizingLaw { get; set; }
        public string confidentialityPledge { get; set; }
        public string consentType { get; set; }
        public string sampleSize { get; set; }
        public string targetPopulationAgeRange { get; set; }
        public string targetPopulationEducationLevel { get; set; }
        public string dataCollectionMode { get; set; }
    }

    public class SearchStudyViewModel
    {
        public int studyID { get; set; }
        public string studyName { get; set; }
        public int variableCount { get; set; }
        //public string searchTerm { get; set; }
        //public string searchType { get; set; }
    }

    public class SearchSeriesStudyViewModel
    {
        public SeriesViewModel series { get; set; }
        public IEnumerable<SearchStudyViewModel> studyList { get; set; }        
    }

    public class SeriesStudyViewModel
    {
        public SeriesViewModel series { get; set; }
        public string studyList { get; set; }
    }

    public class SeriesVariableViewModel
    {
        public SeriesViewModel series { get; set; }
        public IEnumerable<VariableViewModel> variableList { get; set; }
    }

    public class SeriesFileViewModel
    {
        public SeriesViewModel series { get; set; }
        public IEnumerable<FileViewModel> fileList { get; set; }
    }

    public class StudyVariableViewModel
    {
        public StudyViewModel study { get; set; }
        public IEnumerable<VariableViewModel> variableList { get; set; }
    }

    public class VariableValueViewModel
    {
        public VariableViewModel variable { get; set; }
        public IEnumerable<ValueViewModel> valueList { get; set; }
    }

    public class StudyFileViewModel
    {
        public StudyViewModel study { get; set; }
        public IEnumerable<FileViewModel> fileList { get; set; }
    }

    public class StudyQuestionnaireViewModel
    {
        public StudyViewModel study { get; set; }
        public IEnumerable<QuestionnaireViewModel> questionnaireList { get; set; }
    }
}