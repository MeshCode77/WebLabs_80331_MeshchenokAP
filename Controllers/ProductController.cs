using System.Linq;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using WebLabsV05.DAL.Entities;
using Lab1.Extensions;
using WebLabsV05.DAL.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Lab1.Controllers
{
    public class ProductController : Controller
    {
        private ILogger _logger;
        ApplicationDbContext _context;
        int _pageSize;

        public List<Dish> _dishes;
        List<DishGroup> _dishGroups;
        private ApplicationDbContext context;
        private ILogger logger;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
            //SetupData();
        }


        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {

            var groupMame = group.HasValue ? _context.DishGroups.Find(group.Value)?.GroupName : "all groups";
            _logger.LogInformation($"info: group={groupMame}, page ={ pageNo}");

            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);

            ViewData["Groups"] = _context.DishGroups;

            // Получить id текущей группы и поместить в TempData

            var currentGroup = group.HasValue ? group.Value : 0;

            ViewData["CurrentGroup"] = currentGroup;

            //var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListPartial", ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
            }
                return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }


        //private void SetupData()
        //{
        //    _dishGroups = new List<DishGroup>
        //    {
        //        new DishGroup {DishGroupId=1, GroupName="Стартеры"},
        //        new DishGroup {DishGroupId=2, GroupName="Салаты"},
        //        new DishGroup {DishGroupId=3, GroupName="Супы"},
        //        new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
        //        new DishGroup {DishGroupId=5, GroupName="Напитки"},
        //        new DishGroup {DishGroupId=6, GroupName="Десерты"}
        //    };

        //    _dishes = new List<Dish>
        //    {
        //        new Dish {DishId = 1, DishName="Суп-харчо",
        //            Description="Очень острый, невкусный",Calories =200, DishGroupId=3, Image="soup_1.jpg" },
        //        new Dish { DishId = 2, DishName="Борщ",
        //            Description="Много сала, без сметаны",Calories =330, DishGroupId=3, Image="soup_2.jpg" },
        //        new Dish { DishId = 3, DishName="Котлета пожарская",Description="Хлеб - 80%, Морковь - 20%",
        //            Calories =635, DishGroupId=4, Image="steak_1.jpg" },
        //        new Dish { DishId = 4, DishName="Макароны по-флотски",Description="С охотничьей колбаской",
        //            Calories =524, DishGroupId=4, Image="pasta_1.jpg" },
        //        new Dish { DishId = 5, DishName="Компот",Description="Быстро растворимый, 2 литра",
        //            Calories =180, DishGroupId=5, Image="lemonade_1.jpg" }
        //    };
        //}
    }
}