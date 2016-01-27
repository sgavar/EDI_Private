using System.Linq;
using System.Web.Mvc;
using DataInventory.Private.Models;
using DataInventory.Models;

namespace DataInventory.Private.Controllers
{
    public class SeriesController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /Series/
        [HttpGet]
        public ActionResult Index ()
        {
            return View (
                from s in db.vwSeries
                select new SeriesViewModel ()
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
                        select new CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        }
                });
        }

        // GET: /Series/id
        [HttpGet]
        public ActionResult GetSeriesDetail (int Id)
        {
            return View ("Index",
                from s in db.vwSeries
                where s.Id == Id
                select new SeriesViewModel ()
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
                        select new CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        }
                });
        }
    }
}