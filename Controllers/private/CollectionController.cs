using System;
using System.Linq;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class CollectionController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();
        
        // GET: /CollectionDetail/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from c in db.vwCollection
                select new Models.Private.CollectionViewModel ()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    OldName1 = c.OldName1,
                    OldName1Symbol = c.OldName1Symbol,
                    OldName1Duration = c.OldName1Duration,
                    OldName2 = c.OldName2,
                    OldName2Symbol = c.OldName2Symbol,
                    OldName2Duration = c.OldName2Duration,
                    Parent = (
                        from s in db.vwSeries
                        where s.Id == c.ParentId
                        select new Models.Private.SeriesStubViewModel ()
                        {
                            Id = c.ParentId,
                            Name = s.Name
                        }).First (),
                    Investigator = c.Investigator,
                    BureauCode = c.BureauCode,
                    ProgramCode = c.ProgramCode,
                    Website = new Uri (c.Website),
                    Keywords = c.Keywords,
                    Description = c.Description,
                    AuthorizingLaw = c.AuthorizingLaw,
                    TotalCost = (decimal?) c.TotalCost,
                    TotalCostYears = c.TotalCostYears,
                    TotalCostDescription = c.TotalCostDescription,
                    CollectionUniverse = c.CollectionUniverse ?? false,
                    CollectionSample = c.CollectionSample ?? false,
                    CollectionLongitudinal = c.CollectionLongitudinal ?? false,
                    CollectionCrossSectional = c.CollectionCrossSectional ?? false,
                    CollectionProgramMonitoring = c.CollectionProgramMonitoring ?? false,
                    CollectionGranteeReporting = c.CollectionGranteeReporting ?? false,
                    CollectionVoluntary = c.CollectionVoluntary ?? false,
                    CollectionMandatory = c.CollectionMandatory ?? false,
                    CollectionRequiredForBenefits = c.CollectionRequiredForBenefits ?? false,
                    CollectionRequirementDescription = c.CollectionRequirementDescription,
                    CollectionRequirementReason = c.CollectionRequirementReason,
                    Sorn = c.Sorn,
                    SornUrl = new Uri (c.SornUrl),
                    ConfidentialityRestrictions = c.ConfidentialityRestrictions,
                    PII_DI = c.PII_DI ?? false,
                    PIA = c.PIA ?? false,
                    DataCouldBePublic = c.DataCouldBePublic ?? false,
                    PublicationStatisticsType = c.PublicationStatisticsType,
                    PublicationStatisticsUrl = new Uri (c.PublicationStatisticsUrl),
                    PublicationStatisticsDate = c.PublicationStatisticsDate,
                    PublicationDataUrl = new Uri (c.PublicationDataUrl),
                    PublicationDataDate = c.PublicationDataDate,
                    PublicationRestrictedUseDataDate = c.PublicationRestrictedUseDataDate,
                    SubjectPopulation = c.SubjectPopulation,
                    SubjectPopulationDescription = c.SubjectPopulationDescription,
                    DataLevelsAvailable = c.DataLevelsAvailable,
                    DataLevelPublic = c.DataLevelPublic,
                    DataLevelDescription = c.DataLevelDescription,
                    PreviousCollection = (
                        from stub in db.vwCollectionStub
                        where stub.Id == c.PreviousCollectionId
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = c.PreviousCollectionId,
                            Name = stub.Name
                        }).FirstOrDefault (),
                    Contacts =
                        from con in db.vwContact
                        where con.ParentId == c.Id
                        select new Models.Private.ContactViewModel ()
                        {
                            Id = con.Id,
                            SortOrder = con.SortOrder,
                            FirstName = con.FirstName,
                            LastName = con.LastName,
                            EmailAddress = con.EmailAddress,
                            TelephoneNumber = con.TelephoneNumber
                        },
                    Activities =
                        from stub in db.vwActivityStub
                        where stub.ParentId == c.Id
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Files =
                        from stub in db.vwFileStub
                        where stub.ParentId == c.Id
                        select new Models.Private.FileStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name,
                            Format = stub.Format,
                            Title = stub.Title,
                            Restriction = stub.Restriction
                        }
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View (viewModel);
        }

        // GET: /CollectionDetail/id
        [HttpGet]
        public ActionResult GetCollectionDetail (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from c in db.vwCollection
                where c.Id == id
                select new Models.Private.CollectionViewModel ()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    OldName1 = c.OldName1,
                    OldName1Symbol = c.OldName1Symbol,
                    OldName1Duration = c.OldName1Duration,
                    OldName2 = c.OldName2,
                    OldName2Symbol = c.OldName2Symbol,
                    OldName2Duration = c.OldName2Duration,
                    Parent = (
                        from s in db.vwSeries
                        where s.Id == c.ParentId
                        select new Models.Private.SeriesStubViewModel ()
                        {
                            Id = c.ParentId,
                            Name = s.Name
                        }).First (),
                    Investigator = c.Investigator,
                    BureauCode = c.BureauCode,
                    ProgramCode = c.ProgramCode,
                    Website = new Uri (c.Website),
                    Keywords = c.Keywords,
                    Description = c.Description,
                    AuthorizingLaw = c.AuthorizingLaw,
                    TotalCost = (decimal?) c.TotalCost,
                    TotalCostYears = c.TotalCostYears,
                    TotalCostDescription = c.TotalCostDescription,
                    CollectionUniverse = c.CollectionUniverse ?? false,
                    CollectionSample = c.CollectionSample ?? false,
                    CollectionLongitudinal = c.CollectionLongitudinal ?? false,
                    CollectionCrossSectional = c.CollectionCrossSectional ?? false,
                    CollectionProgramMonitoring = c.CollectionProgramMonitoring ?? false,
                    CollectionGranteeReporting = c.CollectionGranteeReporting ?? false,
                    CollectionVoluntary = c.CollectionVoluntary ?? false,
                    CollectionMandatory = c.CollectionMandatory ?? false,
                    CollectionRequiredForBenefits = c.CollectionRequiredForBenefits ?? false,
                    CollectionRequirementDescription = c.CollectionRequirementDescription,
                    CollectionRequirementReason = c.CollectionRequirementReason,
                    Sorn = c.Sorn,
                    SornUrl = new Uri (c.SornUrl),
                    ConfidentialityRestrictions = c.ConfidentialityRestrictions,
                    PII_DI = c.PII_DI ?? false,
                    PIA = c.PIA ?? false,
                    DataCouldBePublic = c.DataCouldBePublic ?? false,
                    PublicationStatisticsType = c.PublicationStatisticsType,
                    PublicationStatisticsUrl = new Uri (c.PublicationStatisticsUrl),
                    PublicationStatisticsDate = c.PublicationStatisticsDate,
                    PublicationDataUrl = new Uri (c.PublicationDataUrl),
                    PublicationDataDate = c.PublicationDataDate,
                    PublicationRestrictedUseDataDate = c.PublicationRestrictedUseDataDate,
                    SubjectPopulation = c.SubjectPopulation,
                    SubjectPopulationDescription = c.SubjectPopulationDescription,
                    DataLevelsAvailable = c.DataLevelsAvailable,
                    DataLevelPublic = c.DataLevelPublic,
                    DataLevelDescription = c.DataLevelDescription,
                    PreviousCollection = (
                        from stub in db.vwCollectionStub
                        where stub.Id == c.PreviousCollectionId
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = c.PreviousCollectionId,
                            Name = stub.Name
                        }).FirstOrDefault (),
                    Contacts =
                        from con in db.vwContact
                        where con.ParentId == c.Id
                        select new Models.Private.ContactViewModel ()
                        {
                            Id = con.Id,
                            SortOrder = con.SortOrder,
                            FirstName = con.FirstName,
                            LastName = con.LastName,
                            EmailAddress = con.EmailAddress,
                            TelephoneNumber = con.TelephoneNumber
                        },
                    Activities =
                        from stub in db.vwActivityStub
                        where stub.ParentId == c.Id
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Files =
                        from stub in db.vwFileStub
                        where stub.ParentId == c.Id
                        select new Models.Private.FileStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name,
                            Format = stub.Format,
                            Title = stub.Title,
                            Restriction = stub.Restriction
                        }
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View ("Index", viewModel);
        }
    }
}