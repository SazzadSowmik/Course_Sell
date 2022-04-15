using CourseSell.DataAccess;
using CourseSell.DataAccess.Repository;
using CourseSell.DataAccess.Repository.IRepository;
using CourseSell.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseSellWeb.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
        return View(objCoverTypeList);
    }
    //get
    public IActionResult Create()
    {
        return View();
    }
    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid) {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Course Type created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //get
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0) {
            return NotFound();
        }
        //var CoverTypeFromDb = _db.CoverType.Find(id);
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        //var CoverTypeFromDbSingle = _db.CoverType.SingleOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null) {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }
    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Course Type updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var CoverTypeFromDb = _db.CoverType.Find(id);
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        //var CoverTypeFromDbSingle = _db.CoverType.SingleOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }
    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST (int? id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null) {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Course Type deleted successfully";
        return RedirectToAction("Index");
    }
}

