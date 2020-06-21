using Lab1.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebLabsV05.DAL.Data;
using WebLabsV05.DAL.Entities;
using Xunit;

namespace Lab1.Tests
{
    public class ProductControllerTests 
    {
        //public ILogger logger;

        //[Theory]
        //[MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        //public void ControllerGetsProperPage(int page, int qty, int id, ILogger logger)
        //{
            // Arrange
            // объекта класса ControllerContext
        //    var controllerContex = new ControllerContext();
        //    // объект для HttpContext
        //    var httpContext = new DefaultHttpContext();
        //    httpContext.Request.Headers.Add("x-requested-with", "");
        //    // поместить HttpContext в ControllerContext
        //    controllerContex.HttpContext = httpContext;
        //    // настройка для сонтекста базы данных
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseInMemoryDatabase(databaseName: "TestDb")
        //    .Options;
        //    // создать контекст
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        // заполнить контекст данными
        //        context.Dishes.AddRange(
        //        new List<Dish>
        //        {
        //            new Dish{ DishId=1},
        //            new Dish{ DishId=2},
        //            new Dish{ DishId=3},
        //            new Dish{ DishId=4},
        //            new Dish{ DishId=5}
        //        });
        //        context.DishGroups.Add(new DishGroup
        //        { GroupName = "fake group" });
        //        context.SaveChanges();
        //        // создать объект контроллера
        //        var controller = new ProductController(context, logger)
        //        {
        //            ControllerContext = controllerContex
        //        };
        //        // Act
        //        var result = controller.Index(pageNo: page, group: null) as
        //        ViewResult;
        //        var model = result?.Model as List<Dish>;
        //        // Assert
        //        Assert.NotNull(model);
        //        Assert.Equal(qty, model.Count);
        //        Assert.Equal(id, model[0].DishId);
        //    }
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //    }
        //}

        //[Fact]
   //     public void ControllerSelectsGroup()
   //     {

   //         var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
			//var context = new ApplicationDbContext(options);

   //         // arrange
   //         var controller = new ProductController(context, logger);
   //         var data = TestData.GetDishesList();
   //         controller._dishes = data;
   //         var comparer = Comparer<Dish>
   //         .GetComparer((d1, d2) => d1.DishId.Equals(d2.DishId));
   //         // act
   //         var result = controller.Index(2) as ViewResult;
   //         var model = result.Model as List<Dish>;
   //         // assert
   //         Assert.Equal(2, model.Count);
   //         Assert.Equal(data[2], model[0], comparer);
   //     }
    }
}
