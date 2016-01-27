using System.Linq;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class ActivityController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Activity/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from a in db.vwActivity
                select new Models.Private.ActivityViewModel ()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Parent = (
                        from stub in db.vwCollectionStub
                        where stub.Id == a.ParentId
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = a.ParentId,
                            Name = stub.Name
                        }).First (),
                    ActivityType = a.ActivityType,
                    Cost = (decimal?) a.Cost,
                    CostYears = a.CostYears,
                    CostDescription = a.CostDescription,
                    RecruitmentStartDateEstimated = a.RecruitmentStartDateEstimated,
                    CollectionStartDateEstimated = a.CollectionStartDateEstimated,
                    CollectionStartDate = a.CollectionStartDate,
                    CollectionEndDateEstimated = a.CollectionEndDateEstimated,
                    CollectionEndDate = a.CollectionEndDate,
                    DateDescription = a.DateDescription,
                    DataCollectionAgentType = a.DataCollectionAgentType,
                    DataCollectionAgentPrimary = a.DataCollectionAgentPrimary,
                    DataCollectionAgentNonPrimary = a.DataCollectionAgentNonPrimary,
                    ConfidentialityLaw = a.ConfidentialityLaw,
                    VoluntaryConfidentialStatement = a.VoluntaryConfidentialStatement,
                    VoluntaryConfidentialStatementRespondent = a.VoluntaryConfidentialStatementRespondent,
                    ExperimentDescription = a.ExperimentDescription,
                    ExperimentResults = a.ExperimentResults,
                    Respondents =
                        from stub in db.vwRespondentStub
                        where stub.ParentId == a.Id
                        select new Models.Private.RespondentStubViewModel ()
                        {
                            Id = stub.Id,
                            Description = stub.Description
                        },
                    Packages =
                        from link in db.vwActivityPackageLink
                        where link.CollectionId == a.Id
                        join stub in db.PackageStub on link.PackageId equals stub.Id
                        select new Models.Private.PackageStubViewModel ()
                        {
                            Id = stub.Id,
                            ReferenceNumber = stub.ReferenceNumber
                        }
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View (viewModel);
        }

        // GET: /Activity/id
        [HttpGet]
        public ActionResult GetActivityDetail (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from a in db.vwActivity
                where a.Id == id
                select new Models.Private.ActivityViewModel ()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Parent = (
                        from stub in db.vwCollectionStub
                        where stub.Id == a.ParentId
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = a.ParentId,
                            Name = stub.Name
                        }).First (),
                    ActivityType = a.ActivityType,
                    Cost = (decimal?) a.Cost,
                    CostYears = a.CostYears,
                    CostDescription = a.CostDescription,
                    RecruitmentStartDateEstimated = a.RecruitmentStartDateEstimated,
                    CollectionStartDateEstimated = a.CollectionStartDateEstimated,
                    CollectionStartDate = a.CollectionStartDate,
                    CollectionEndDateEstimated = a.CollectionEndDateEstimated,
                    CollectionEndDate = a.CollectionEndDate,
                    DateDescription = a.DateDescription,
                    DataCollectionAgentType = a.DataCollectionAgentType,
                    DataCollectionAgentPrimary = a.DataCollectionAgentPrimary,
                    DataCollectionAgentNonPrimary = a.DataCollectionAgentNonPrimary,
                    ConfidentialityLaw = a.ConfidentialityLaw,
                    VoluntaryConfidentialStatement = a.VoluntaryConfidentialStatement,
                    VoluntaryConfidentialStatementRespondent = a.VoluntaryConfidentialStatementRespondent,
                    ExperimentDescription = a.ExperimentDescription,
                    ExperimentResults = a.ExperimentResults,
                    Respondents =
                        from stub in db.vwRespondentStub
                        where stub.ParentId == a.Id
                        select new Models.Private.RespondentStubViewModel ()
                        {
                            Id = stub.Id,
                            Description = stub.Description
                        },
                    Packages =
                        from link in db.vwActivityPackageLink
                        where link.CollectionId == a.Id
                        join stub in db.PackageStub on link.PackageId equals stub.Id
                        select new Models.Private.PackageStubViewModel ()
                        {
                            Id = stub.Id,
                            ReferenceNumber = stub.ReferenceNumber
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