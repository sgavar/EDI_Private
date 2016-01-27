using System;
using System.Collections.Generic;

// Only create new Views for those classes
namespace DataInventory.Models.Private
{
    // Create as a new View
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string OldName1 { get; set; }
        public string OldName1Symbol { get; set; }
        public string OldName1Duration { get; set; }
        public string OldName2 { get; set; }
        public string OldName2Symbol { get; set; }
        public string OldName2Duration { get; set; }
        public string ParentOrganization { get; set; }
        public string Description { get; set; }
        public IEnumerable<CollectionStubViewModel> Collections { get; set; }
    }

    public struct SeriesStubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Create as a new View
    public class CollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string OldName1 { get; set; }
        public string OldName1Symbol { get; set; }
        public string OldName1Duration { get; set; }
        public string OldName2 { get; set; }
        public string OldName2Symbol { get; set; }
        public string OldName2Duration { get; set; }
        public SeriesStubViewModel Parent { get; set; }
        public string Investigator { get; set; }
        public string BureauCode { get; set; }
        public string ProgramCode { get; set; }
        public Uri Website { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string AuthorizingLaw { get; set; }
        public decimal? TotalCost { get; set; }
        public string TotalCostYears { get; set; }
        public string TotalCostDescription { get; set; }
        public bool CollectionUniverse { get; set; }
        public bool CollectionSample { get; set; }
        public bool CollectionLongitudinal { get; set; }
        public bool CollectionCrossSectional { get; set; }
        public bool CollectionProgramMonitoring { get; set; }
        public bool CollectionGranteeReporting { get; set; }
        public bool CollectionVoluntary { get; set; }
        public bool CollectionMandatory { get; set; }
        public bool CollectionRequiredForBenefits { get; set; }
        public string CollectionRequirementDescription { get; set; }
        public string CollectionRequirementReason { get; set; }
        public string Sorn { get; set; }
        public Uri SornUrl { get; set; }
        public string ConfidentialityRestrictions { get; set; }
        public bool PII_DI { get; set; }
        public bool PIA { get; set; }
        public bool DataCouldBePublic { get; set; }
        public string PublicationStatisticsType { get; set; }
        public Uri PublicationStatisticsUrl { get; set; }
        public DateTime? PublicationStatisticsDate { get; set; }
        public Uri PublicationDataUrl { get; set; }
        public DateTime? PublicationDataDate { get; set; }
        public DateTime? PublicationRestrictedUseDataDate { get; set; }
        public string SubjectPopulation { get; set; }
        public string SubjectPopulationDescription { get; set; }
        public string DataLevelsAvailable { get; set; }
        public string DataLevelPublic { get; set; }
        public string DataLevelDescription { get; set; }
        public CollectionStubViewModel PreviousCollection { get; set; }
        public IEnumerable<ContactViewModel> Contacts { get; set; }
        public IEnumerable<ActivityStubViewModel> Activities { get; set; }
        public IEnumerable<FileStubViewModel> Files { get; set; }
    }

    public struct CollectionStubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct ContactViewModel
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
    }

    // Create as a new View
    public class ActivityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CollectionStubViewModel Parent { get; set; }
        public string ActivityType { get; set; }
        public decimal? Cost { get; set; }
        public string CostYears { get; set; }
        public string CostDescription { get; set; }
        public DateTime? RecruitmentStartDateEstimated { get; set; }
        public DateTime? CollectionStartDateEstimated { get; set; }
        public DateTime? CollectionStartDate { get; set; }
        public DateTime? CollectionEndDateEstimated { get; set; }
        public DateTime? CollectionEndDate { get; set; }
        public string DateDescription { get; set; }
        public string DataCollectionAgentType { get; set; }
        public string DataCollectionAgentPrimary { get; set; }
        public string DataCollectionAgentNonPrimary { get; set; }
        public string ConfidentialityLaw { get; set; }
        public string VoluntaryConfidentialStatement { get; set; }
        public string VoluntaryConfidentialStatementRespondent { get; set; }
        public string ExperimentDescription { get; set; }
        public string ExperimentResults { get; set; }
        public IEnumerable<RespondentStubViewModel> Respondents { get; set; }
        public IEnumerable<PackageStubViewModel> Packages { get; set; }
    }

    public struct ActivityStubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Create as a new View
    public class RespondentViewModel
    {
        public int Id { get; set; }
        public ActivityStubViewModel Parent { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public bool ResponseVoluntary { get; set; }
        public bool ResponseMandatory { get; set; }
        public bool ResponseRequiredForBenefits { get; set; }
        public string ResponseRequirementDescription { get; set; }
        public string ResponseRequirementReason { get; set; }
        public int? PopulationSizeEstimated { get; set; }
        public int? PopulationSize { get; set; }
        public string PopulationSizeDescription { get; set; }
        public int? ResponseSizeEstimated { get; set; }
        public int? ResponseSize { get; set; }
        public double? ResponseRateEstimated { get; set; }
        public double? ResponseRate { get; set; }
        public string ResponseRateDescription { get; set; }
        public int? Burden { get; set; }
        public int? BurdenPerRespondent { get; set; }
        public int? BurdenPerRespondentSurvey { get; set; }
        public int? BurdenPerRespondentAssessment { get; set; }
        public bool ConsentExplicit { get; set; }
        public bool ConsentImplicit { get; set; }
        public bool ConsentNotApplicable { get; set; }
        public string ConsentForm { get; set; }
        public string Population { get; set; }
        public string PopulationDescription { get; set; }
        public string ResponseType { get; set; }
        public string ResponseTypeDescription { get; set; }
        public string ResponseMode { get; set; }
        public string ResponseModeDescription { get; set; }
        public string AdditionalLanguageInstrument { get; set; }
        public string AdditionalLanguageInterpreter { get; set; }
        public string IncentiveCashValue { get; set; }
        public string IncentiveCashDescription { get; set; }
        public string IncentiveNonCashValue { get; set; }
        public string IncentiveNonCashDescription { get; set; }
        public string IncentiveJustification { get; set; }
        public string ConfidentialityLaw { get; set; }
        public string VoluntaryConfidentialStatementInstrument { get; set; }
        public string VoluntaryConfidentialStatementContactMaterial { get; set; }
        public string VoluntaryConfidentialStatementFaq { get; set; }
        public string VoluntaryConfidentialStatementBrochure { get; set; }
        public string FollowUpInformedConsentStatement { get; set; }
        public string FollowUpInformedConsentLocation { get; set; }
        public string PaperworkReductionActStatement { get; set; }
        public string PaperworkReductionActLocation { get; set; }
    }

    public struct RespondentStubViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    // Create as a new View
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string ICRAS { get; set; }
        public string EDICS { get; set; }
        public string ICRReferenceNumber { get; set; }
        public string OMBControlNumber { get; set; }
        public string CFDA { get; set; }
        public string Keywords { get; set; }
        public string Abstract { get; set; }
        public string NoticeType { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string TermsOfClearance { get; set; }
        public int? NumberRespondents { get; set; }
        public int? NumberResponses { get; set; }
        public double? PercentCollectedElectronically { get; set; }
        public int? BurdenTotal { get; set; }
        public int? BurdenChange { get; set; }
        public int? BurdenAdjustment { get; set; }
        public string BurdenExplanation { get; set; }
        public string PublicComment { get; set; }
        public string PublicCommentResponse { get; set; }
        public string OMBPassback { get; set; }
        public string AuthorizingLawCited { get; set; }
        public string AuthorizingLawText { get; set; }
        public string ContractorConfidentialityFormLocation { get; set; }
        public IEnumerable<ActivityStubViewModel> Activities { get; set; }
    }

    public struct PackageStubViewModel
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
    }

    // Create as a new View
    public class FileViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Dataset { get; set; }
        public string Restriction { get; set; }
        public string Location { get; set; }
        public string LocationDescription { get; set; }
        public IEnumerable<CollectionStubViewModel> Collections { get; set; }
        public IEnumerable<ElementViewModel> Elements { get; set; }
    }

    public struct FileStubViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Title { get; set; }
        public string Restriction { get; set; }
    }

    public struct ElementViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string LabelExtended { get; set; }
        public string Question { get; set; }
        public IEnumerable<ValueViewModel> Values { get; set; }
    }

    public struct ValueViewModel
    {
        public string Option { get; set; }
        public string Label { get; set; }
    }
}