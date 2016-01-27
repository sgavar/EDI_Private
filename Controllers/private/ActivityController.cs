using System.Linq;
using System.Web.Mvc;
using DataInventory.Models;
using DataInventory.Private.Models;

namespace DataInventory.Private.Controllers
{
    public class ActivityController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Activity/
        [HttpGet]
        public ActionResult Index()
        {
            return View (
                from a in db.vwActivity
                select new ActivityViewModel ()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Parent =
                        (from stub in db.vwCollectionStub
                         where stub.Id == a.ParentId
                         select new CollectionStubViewModel ()
                         {
                             Id = a.ParentId,
                             Name = stub.Name
                         })
                        .Single (),
                    ActivityType = a.ActivityType,
                    Cost = (decimal?)a.Cost,
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
                        select new RespondentStubViewModel ()
                        {
                            Id = stub.Id,
                            Description = stub.Description
                        },
                    Packages =
                        from link in db.vwActivityPackageLink
                        where link.CollectionId == a.Id
                        join stub in db.PackageStub on link.PackageId equals stub.Id
                        select new PackageStubViewModel ()
                        {
                            Id = stub.Id,
                            ReferenceNumber = stub.ReferenceNumber
                        }
                });
        }

        // GET: /Activity/Id
        [HttpGet]
        public ActionResult GetActivityDetail (int Id)
        {
            return View ("Index",
                from a in db.vwActivity
                where a.Id == Id
                select new ActivityViewModel ()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Parent =
                        (from stub in db.vwCollectionStub
                         where stub.Id == a.ParentId
                         select new CollectionStubViewModel ()
                         {
                             Id = a.ParentId,
                             Name = stub.Name
                         })
                        .Single (),
                    ActivityType = a.ActivityType,
                    Cost = (decimal?)a.Cost,
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
                        select new RespondentStubViewModel ()
                        {
                            Id = stub.Id,
                            Description = stub.Description
                        },
                    Packages =
                        from link in db.vwActivityPackageLink
                        where link.CollectionId == a.Id
                        join stub in db.PackageStub on link.PackageId equals stub.Id
                        select new PackageStubViewModel ()
                        {
                            Id = stub.Id,
                            ReferenceNumber = stub.ReferenceNumber
                        }
                });
        }
    }
}