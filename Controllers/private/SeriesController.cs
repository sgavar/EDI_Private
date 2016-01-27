using System.Linq;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class SeriesController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Series/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from s in db.vwSeries
                select new Models.Private.SeriesViewModel ()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Symbol = s.Symbol,
                    OldName1 = s.OldName1,
                    OldName1Symbol = s.OldName1Symbol,
                    OldName1Duration = s.OldName1Duration,
                    OldName2 = s.OldName,
                    OldName2Symbol = s.OldName2Symbol,
                    OldName2Duration = s.OldName2Duration,
                    ParentOrganization = s.ParentOrganization,
                    Description = s.Description,
                    Collections =
                        from stub in db.vwCollectionStub
                        where stub.ParentId == s.Id
                        select new Models.Private.CollectionStubViewModel ()
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

        // GET: /Series/id
        [HttpGet]
        public ActionResult GetSeriesDetail (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from s in db.vwSeries
                where s.Id == id
                select new Models.Private.SeriesViewModel ()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Symbol = s.Symbol,
                    OldName1 = s.OldName1,
                    OldName1Symbol = s.OldName1Symbol,
                    OldName1Duration = s.OldName1Duration,
                    OldName2 = s.OldName,
                    OldName2Symbol = s.OldName2Symbol,
                    OldName2Duration = s.OldName2Duration,
                    ParentOrganization = s.ParentOrganization,
                    Description = s.Description,
                    Collections =
                        from stub in db.vwCollectionStub
                        where stub.ParentId == s.Id
                        select new Models.Private.CollectionStubViewModel ()
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