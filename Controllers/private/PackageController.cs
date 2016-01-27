using System.Web.Mvc;
using DataInventory.Private.Models;
using DataInventory.Models;

namespace DataInventory.Private.Controllers
{
    public class PackageController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Package/
        [HttpGet]
        public ActionResult Index()
        {
            return View (
                from p in db.vwPackage
                select new PackageViewModel ()
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
                        select new ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        }
                });
        }

        // GET: /Package/Id
        [HttpGet]
        public ActionResult GetPackageDetail (int Id)
        {
            return View ("Index",
                from p in db.vwPackage
                where p.Id == Id
                select new PackageViewModel ()
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
                        select new ActivityStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        }
                });
        }
    }
}