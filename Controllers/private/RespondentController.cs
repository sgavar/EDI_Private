using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class RespondentController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Respondent/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from r in db.vwRespondent
                select new Models.Private.RespondentViewModel ()
                {
                    Id = r.Id,
                    Parent = (
                        from stub in db.ActivityStub
                        where stub.Id == r.ParentId
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = r.ParentId,
                            Name = stub.Name
                        }).First (),
                    Type = r.Type,
                    Description = r.Description,
                    Keywords = r.Keywords,
                    ResponseVoluntary = r.ResponseVoluntary ?? false,
                    ResponseMandatory = r.ResponseMandatory ?? false,
                    ResponseRequiredForBenefits = r.ResponseRequiredForBenefits ?? false,
                    ResponseRequirementDescription = r.ResponseRequirementDescription,
                    ResponseRequirementReason = r.ResponseRequirementReason,
                    PopulationSizeEstimated = r.PopulationSizeEstimated,
                    PopulationSize = r.PopulationSize,
                    PopulationSizeDescription = r.PopulationSizeDescription,
                    ResponseSizeEstimated = r.ResponseSizeEstimated,
                    ResponseSize = r.ResponseSize,
                    ResponseRateEstimated = r.ResponseRateEstimated,
                    ResponseRate = r.ResponseRate,
                    ResponseRateDescription = r.ResponseRateDescription,
                    Burden = r.Burden,
                    BurdenPerRespondent = r.BurdenPerRespondent,
                    BurdenPerRespondentSurvey = r.BurdenPerRespondentSurvey,
                    BurdenPerRespondentAssessment = r.BurdenPerRespondentAssessment,
                    ConsentExplicit = r.ConsentExplicit ?? false,
                    ConsentImplicit = r.ConsentImplicit ?? false,
                    ConsentNotApplicable = r.ConsentNotApplicable ?? false,
                    ConsentForm = r.ConsentForm,
                    Population = r.Population,
                    PopulationDescription = r.PopulationDescription,
                    ResponseType = r.ResponseType,
                    ResponseTypeDescription = r.ResponseTypeDescription,
                    ResponseMode = r.ResponseMode,
                    ResponseModeDescription = r.ResponseModeDescription,
                    AdditionalLanguageInstrument = r.AdditionalLanguageInstrument,
                    AdditionalLanguageInterpreter = r.AdditionalLanguageInterpreter,
                    IncentiveCashValue = r.IncentiveCashValue,
                    IncentiveCashDescription = r.IncentiveCashDescription,
                    IncentiveNonCashValue = r.IncentiveNonCashValue,
                    IncentiveNonCashDescription = r.IncentiveNonCashDescription,
                    IncentiveJustification = r.IncentiveJustification,
                    ConfidentialityLaw = r.ConfidentialityLaw,
                    VoluntaryConfidentialStatementInstrument = r.VoluntaryConfidentialStatementInstrument,
                    VoluntaryConfidentialStatementContactMaterial = r.VoluntaryConfidentialStatementContactMaterial,
                    VoluntaryConfidentialStatementFaq = r.VoluntaryConfidentialStatementFaq,
                    VoluntaryConfidentialStatementBrochure = r.VoluntaryConfidentialStatementBrochure,
                    FollowUpInformedConsentStatement = r.FollowUpInformedConsentStatement,
                    FollowUpInformedConsentLocation = r.FollowUpInformedConsentLocation,
                    PaperworkReductionActStatement = r.PaperworkReductionActStatement,
                    PaperworkReductionActLocation = r.PaperworkReductionActLocation
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View (viewModel);
        }

        // GET: /Respondent/Id
        [HttpGet]
        public ActionResult GetRespondentDetail (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from r in db.vwRespondent
                where r.Id == id
                select new Models.Private.RespondentViewModel ()
                {
                    Id = r.Id,
                    Parent = (
                        from stub in db.ActivityStub
                        where stub.Id == r.ParentId
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = r.ParentId,
                            Name = stub.Name
                        }).First (),
                    Type = r.Type,
                    Description = r.Description,
                    Keywords = r.Keywords,
                    ResponseVoluntary = r.ResponseVoluntary ?? false,
                    ResponseMandatory = r.ResponseMandatory ?? false,
                    ResponseRequiredForBenefits = r.ResponseRequiredForBenefits ?? false,
                    ResponseRequirementDescription = r.ResponseRequirementDescription,
                    ResponseRequirementReason = r.ResponseRequirementReason,
                    PopulationSizeEstimated = r.PopulationSizeEstimated,
                    PopulationSize = r.PopulationSize,
                    PopulationSizeDescription = r.PopulationSizeDescription,
                    ResponseSizeEstimated = r.ResponseSizeEstimated,
                    ResponseSize = r.ResponseSize,
                    ResponseRateEstimated = r.ResponseRateEstimated,
                    ResponseRate = r.ResponseRate,
                    ResponseRateDescription = r.ResponseRateDescription,
                    Burden = r.Burden,
                    BurdenPerRespondent = r.BurdenPerRespondent,
                    BurdenPerRespondentSurvey = r.BurdenPerRespondentSurvey,
                    BurdenPerRespondentAssessment = r.BurdenPerRespondentAssessment,
                    ConsentExplicit = r.ConsentExplicit ?? false,
                    ConsentImplicit = r.ConsentImplicit ?? false,
                    ConsentNotApplicable = r.ConsentNotApplicable ?? false,
                    ConsentForm = r.ConsentForm,
                    Population = r.Population,
                    PopulationDescription = r.PopulationDescription,
                    ResponseType = r.ResponseType,
                    ResponseTypeDescription = r.ResponseTypeDescription,
                    ResponseMode = r.ResponseMode,
                    ResponseModeDescription = r.ResponseModeDescription,
                    AdditionalLanguageInstrument = r.AdditionalLanguageInstrument,
                    AdditionalLanguageInterpreter = r.AdditionalLanguageInterpreter,
                    IncentiveCashValue = r.IncentiveCashValue,
                    IncentiveCashDescription = r.IncentiveCashDescription,
                    IncentiveNonCashValue = r.IncentiveNonCashValue,
                    IncentiveNonCashDescription = r.IncentiveNonCashDescription,
                    IncentiveJustification = r.IncentiveJustification,
                    ConfidentialityLaw = r.ConfidentialityLaw,
                    VoluntaryConfidentialStatementInstrument = r.VoluntaryConfidentialStatementInstrument,
                    VoluntaryConfidentialStatementContactMaterial = r.VoluntaryConfidentialStatementContactMaterial,
                    VoluntaryConfidentialStatementFaq = r.VoluntaryConfidentialStatementFaq,
                    VoluntaryConfidentialStatementBrochure = r.VoluntaryConfidentialStatementBrochure,
                    FollowUpInformedConsentStatement = r.FollowUpInformedConsentStatement,
                    FollowUpInformedConsentLocation = r.FollowUpInformedConsentLocation,
                    PaperworkReductionActStatement = r.PaperworkReductionActStatement,
                    PaperworkReductionActLocation = r.PaperworkReductionActLocation
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View ("Index", viewModel);
        }
    }
}