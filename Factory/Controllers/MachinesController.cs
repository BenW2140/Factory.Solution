using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    public readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine, int engineerId)
    {
      _db.Machines.Add(machine);
      if (engineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(machines => machines.Engineers)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisMachine);
    }

  }
}