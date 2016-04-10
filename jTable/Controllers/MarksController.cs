using jTable.Entities;
using jTable.Models;
using jTableMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jTable.Controllers
{
    public class MarksController : Controller
    {
        // GET: Marks
        public ActionResult Index()
        {
            return View();
        }

        #region GetStudentMarks
        /// <summary>
        /// GetStudentMarks
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStudentMarks()
        {
            MarkDbContext db = new MarkDbContext();

            try
            {
                List<Mark> lstMarks = new List<Mark>();
                lstMarks = db.Marks.ToList();
                return Json(new { Result = "OK", Record = lstMarks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        } 
        #endregion

        #region Create
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(Mark model)
        {
            MarkDbContext db = new MarkDbContext();
            try
            {
                model.ID = Guid.NewGuid().ToString();
                db.Marks.Add(model);
                db.SaveChanges();
                return Json(new{Result="OK",Records=model},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
           
        } 
        #endregion

        #region Edit
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Mark model)
        {
            MarkDbContext db = new MarkDbContext();
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });

                //throw;
            }
        } 
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string ID)
        {
            MarkDbContext db = new MarkDbContext();
            try
            {
                //删除，是先找到，在删除
                Mark marks = db.Marks.Find(ID);
                db.Marks.Remove(marks);
                db.SaveChanges();
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
                //throw;
            }
        } 
        #endregion
    }
}