using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }


    [HttpPost("items/delete")]
    public ActionResult Delete()
    {
      Item.ClearAll();
      //return View();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}")]

    public ActionResult Show(int id)
    {
      Item foundItem = Item.Find(id);
      Category category = Category.Find(id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", foundItem);
      model.Add("category", category);
      return View(model);
    }
  }
}