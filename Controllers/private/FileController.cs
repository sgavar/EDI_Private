using System;
using System.Linq;
using System.Web.Mvc;
using DataInventory.Private.Models;
using DataInventory.Models;

namespace DataInventory.Private.Controllers
{
    public class FileController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /File/
        [HttpGet]
        public ActionResult Index()
        {
            return View (
                from f in db.vwFile
                select new FileViewModel ()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Format = f.Format,
                    Dataset = f.Dataset,
                    Restriction = f.Restriction,
                    Location = f.Location,
                    LocationDescription = f.LocationDescription,
                    Collections =
                        from link in db.vwFileCollectionLink
                        where link.FileId == f.Id
                        join stub in db.vwCollectionStub on link.CollectionId equals stub.Id
                        select new CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Elements =
                        from e in db.vwElement
                        where e.ParentId == f.Id
                        select new ElementViewModel ()
                        {
                            Name = e.Name,
                            Type = e.Type,
                            Label = e.Label,
                            LabelExtended = e.LabelExtended,
                            Question = e.Question,
                            Values =
                                from v in db.vwValue
                                where v.ParentId == e.Id
                                select new ValueViewModel ()
                                {
                                    Option = v.Option,
                                    Value = v.Value
                                }
                        }
                });
        }

        // GET: /File/id
        [HttpGet]
        public ActionResult GetFileDetail (Guid Id)
        {
            return View ("Index",
                from f in db.vwFile
                where f.Id == Id
                select new FileViewModel ()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Format = f.Format,
                    Dataset = f.Dataset,
                    Restriction = f.Restriction,
                    Location = f.Location,
                    LocationDescription = f.LocationDescription,
                    Collections =
                        from link in db.vwFileCollectionLink
                        where link.FileId == f.Id
                        join stub in db.vwCollectionStub on link.CollectionId equals stub.Id
                        select new CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Elements =
                        from e in db.vwElement
                        where e.ParentId == f.Id
                        select new ElementViewModel ()
                        {
                            Name = e.Name,
                            Type = e.Type,
                            Label = e.Label,
                            LabelExtended = e.LabelExtended,
                            Question = e.Question,
                            Values =
                                from v in db.vwValue
                                where v.ParentId == e.Id
                                select new ValueViewModel ()
                                {
                                    Option = v.Option,
                                    Value = v.Value
                                }
                        }
                });
        }
    }
}