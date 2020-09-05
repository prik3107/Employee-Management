using RegistrationAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationAndLogin.Controllers
{
    public class EmpController : Controller
    {
        [HttpGet]
        // GET: Emp
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]EMP emp)
        {
            try
            {
                //Save to Database
                using (MyDatabaseEntities de = new MyDatabaseEntities())
                {
                    de.EMPs.Add(emp);
                    de.SaveChanges();
                    return RedirectToAction("Index1", "Emp");
                }
            }
            catch
            {
                return View();
            }
        }
        /******************************** Index1 ************************************/
        public ActionResult Index1()
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {    
                //View Database list
                return View(db.EMPs.OrderBy(s => s.Id).ToList());           
            }
        }

        /******************************** Edit ************************************/
        [HttpGet]
        // GET: Emp 
        public ActionResult Edit(int id)
        {
            using (MyDatabaseEntities db1 = new MyDatabaseEntities())
            {
                //Fetch the Id for editing
                var std = db1.EMPs.Where(s => s.Id == id).FirstOrDefault();
                return View(std);
            }
        }
        [HttpPost]
        public ActionResult Edit(EMP emp1)
        {
            using (MyDatabaseEntities updtDb = new MyDatabaseEntities())
            {
                //Updating the list in DB
                var updtEmp = updtDb.EMPs.Where(s => s.Id == emp1.Id).FirstOrDefault();
                updtDb.EMPs.Remove(updtEmp);
                //Adding the record
                updtDb.EMPs.Add(emp1);
                //Saving the record in the db
                updtDb.SaveChanges();
                return RedirectToAction("Index1", "Emp");
            }
        }
        /******************************** Delete ************************************/
        [HttpGet]
        // GET: Emp
        public ActionResult Delete(EMP emp2)
        {
            using (MyDatabaseEntities deleteDb = new MyDatabaseEntities())
            {
                var del1 = deleteDb.EMPs.Where(s => s.Id == emp2.Id).FirstOrDefault();
                //Removing record by Id
                deleteDb.EMPs.Remove(del1);
                //Saving the record
                deleteDb.SaveChanges();
                return RedirectToAction("Index1", "Emp");
            }
        }
    }
}
