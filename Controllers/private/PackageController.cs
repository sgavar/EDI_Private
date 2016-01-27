using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class PackageController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Package/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from p in db.vwPackage
                select new Models.Private.PackageViewModel ()
                {
                    Id = p.Id,
                    ICRAS = p.ICRAS,
                    EDICS = p.EDICS,
                    ICRReferenceNumber = p.ICRReferenceNumber,
                    OMBControlNumber = p.OMBControlNumber,
                    CFDA = p.CFDA,
                    Keywords = p.Keywords,
                    Abstract = p.Abstract,
                    NoticeType = p.NoticeType,
                    IssueDate = p.IssueDate,
                    ExpirationDate = p.ExpirationDate,
                    TermsOfClearance = p.TermsOfClearance,
                    NumberRespondents = p.NumberRespondents,
                    NumberResponses = p.NumberResponses,
                    PercentCollectedElectronically = p.PercentCollectedElectronically,
                    BurdenTotal = p.BurdenTotal,
                    BurdenChange = p.BurdenChange,
                    BurdenAdjustment = p.BurdenAdjustment,
                    BurdenExplanation = p.BurdenExplanation,
                    PublicComment = p.PublicComment,
                    PublicCommentResponse = p.PublicCommentResponse,
                    OMBPassback = p.OMBPassback,
                    AuthorizingLawCited = p.AuthorizingLawCited,
                    AuthorizingLawText = p.AuthorizingLawText,
                    ContractorConfidentialityFormLocation = p.ContractorConfidentialityFormLocation,
                    Activities =
                        from link in db.vwActivityPackageLink
                        where link.PackageId == p.Id
                        join stub in db.vwCollectionStub on link.CollectionId equals stub.Id
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        }
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View (viewModel);
        }

        // GET: /Package/id
        [HttpGet]
        public ActionResult GetPackageDetail (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from p in db.vwPackage
                where p.Id == id
                select new Models.Private.PackageViewModel ()
                {
                    Id = p.Id,
                    ICRAS = p.ICRAS,
                    EDICS = p.EDICS,
                    ICRReferenceNumber = p.ICRReferenceNumber,
                    OMBControlNumber = p.OMBControlNumber,
                    CFDA = p.CFDA,
                    Keywords = p.Keywords,
                    Abstract = p.Abstract,
                    NoticeType = p.NoticeType,
                    IssueDate = p.IssueDate,
                    ExpirationDate = p.ExpirationDate,
                    TermsOfClearance = p.TermsOfClearance,
                    NumberRespondents = p.NumberRespondents,
                    NumberResponses = p.NumberResponses,
                    PercentCollectedElectronically = p.PercentCollectedElectronically,
                    BurdenTotal = p.BurdenTotal,
                    BurdenChange = p.BurdenChange,
                    BurdenAdjustment = p.BurdenAdjustment,
                    BurdenExplanation = p.BurdenExplanation,
                    PublicComment = p.PublicComment,
                    PublicCommentResponse = p.PublicCommentResponse,
                    OMBPassback = p.OMBPassback,
                    AuthorizingLawCited = p.AuthorizingLawCited,
                    AuthorizingLawText = p.AuthorizingLawText,
                    ContractorConfidentialityFormLocation = p.ContractorConfidentialityFormLocation,
                    Activities =
                        from link in db.vwActivityPackageLink
                        where link.PackageId == p.Id
                        join stub in db.vwCollectionStub on link.CollectionId equals stub.Id
                        select new Models.Private.ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
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