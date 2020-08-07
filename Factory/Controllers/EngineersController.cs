using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    public readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer, int machineId)
    {
      _db.Engineers.Add(engineer);
      if (machineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer engineer, int machineId)
    {
      if (machineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      if (machineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}