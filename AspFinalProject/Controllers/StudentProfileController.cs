using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProject.Models;

namespace AspFinalProject.Controllers
{
    public class StudentProfileController : Controller
    {

        AspProjectDBEntities1 db = new AspProjectDBEntities1();


        public ActionResult UpdateProfile(Student student)
        {
            return View("Index", student);
        }


        // GET: StudentProfile
        public ActionResult Index()
        {

            var data = db.Students.SqlQuery("select * from Student").ToList();

            return View(data);
        }

       

        public ActionResult EditStudentProfile()
        {

            return View("EditStuden");
        }



        // POST: StudentProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {

            // TODO: Add update logic here

            List<object> parameters = new List<object>();

            parameters.Add(student.id);
            parameters.Add(student.name);
            parameters.Add(student.department);
            parameters.Add(student.semester);
            parameters.Add(student.batch);
            parameters.Add(student.gender);
            parameters.Add(student.section);
            parameters.Add(student.phone);

            object[] objectarray = parameters.ToArray();

            int output = db.Database.ExecuteSqlCommand("update Student set id=@p0,name=@p1,department=@p2,semester=@p3,batch=@p4,section=@p5,phone=@p6 where id=@p0", objectarray);
            if (output > 0)
            {
                ViewBag.Itemmsg = "Your Product id " + student.id + "  is updated seccussfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Itemmsg = "Nothing Updated";
            }

            return View();
        }

       
    }
}
