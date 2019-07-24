using BasicDotNetCore.Models;
using BasicDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BasicDotNetCore.Controllers
{
    public class ItemGroupController : Controller
    {
        //DatabaseContext _databaseContext;
        //public ItemGroupController(DatabaseContext databaseContext)
        //{
        //    _databaseContext = databaseContext;
        //}
        //https://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/
        ItemGroupService _itemGroupService;
        ItemService _itemService;
        public ItemGroupController(ItemGroupService itemGroupService, ItemService itemService)
        {
            _itemGroupService = itemGroupService;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var r = _itemService.Load("T");
            return View();
        }

        public JsonResult LoadItem(string search)
        {
            var r = _itemService.Load("T");
            var Datax = r.Where(x => x.Description.Contains(search)).ToList();
            List<Data> newObj = new List<Data>(); 
            foreach (var item in Datax)
            {
                newObj.Add(new Data { Id= item.Id, Name = item.Name});
            }
            return Json(new { Data = newObj });
        }

        class Data
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemGroup itemGroupx)
        {
            try
            {
                //ItemGroup itemGroup = new ItemGroup()
                //{
                //    Name = "Test",
                //    Description = "Des"
                //};

                //_itemGroupService.Save(itemGroup);

                var itemGroup = _itemGroupService.Get(1);
                Item item = new Item()
                {

                    Name = "Test Item",
                    Description = "Des",
                    ItemGroup = itemGroup
                };


                _itemService.Save(item);
            }
            catch (System.Exception)
            {

                throw;
            }

            return View();
        }

        public IActionResult Edit()
        {
            try
            {
                var data = _itemGroupService.Get(1);
                //ItemGroup itemGroup = new ItemGroup()
                //{
                //    Name = "Test",
                //    Description = "Des"
                //};

                data.Name = "Update Test";
                _itemGroupService.Update(data);
            }
            catch (System.Exception)
            {

                throw;
            }

            return View();
        }
    }
}