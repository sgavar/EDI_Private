using System;
using System.Linq;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers.Private
{
    public class FileController : Controller
    {
        private readonly DataInventoryEntities db = new DataInventoryEntities ();

        // GET: /File/
        [HttpGet]
        public ActionResult Index ()
        {
            var viewModel = (
                from f in db.vwFile
                select new Models.Private.FileViewModel ()
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
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Elements =
                        from e in db.vwElement
                        where e.ParentId == f.Id
                        select new Models.Private.ElementViewModel ()
                        {
                            Name = e.Name,
                            Type = e.Type,
                            Label = e.Label,
                            LabelExtended = e.LabelExtended,
                            Question = e.Question,
                            Values =
                                from v in db.vwValue
                                where v.ParentId == e.Id
                                select new Models.Private.ValueViewModel ()
                                {
                                    Option = v.Option,
                                    Value = v.Value
                                }
                        }
                }).ToList ();

            if (viewModel == null)
            {
                return new HttpNotFoundResult ();
            }

            return View (viewModel);
        }

        // GET: /File/id
        [HttpGet]
        public ActionResult GetFileDetail (Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (System.Net.HttpStatusCode.BadRequest);
            }

            var viewModel = (
                from f in db.vwFile
                where f.Id == id
                select new Models.Private.FileViewModel ()
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
                        select new Models.Private.CollectionStubViewModel ()
                        {
                            Id = stub.Id,
                            Name = stub.Name
                        },
                    Elements =
                        from e in db.vwElement
                        where e.ParentId == f.Id
                        select new Models.Private.ElementViewModel ()
                        {
                            Name = e.Name,
                            Type = e.Type,
                            Label = e.Label,
                            LabelExtended = e.LabelExtended,
                            Question = e.Question,
                            Values =
                                from v in db.vwValue
                                where v.ParentId == e.Id
                                select new Models.Private.ValueViewModel ()
                                {
                                    Option = v.Option,
                                    Value = v.Value
                                }
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