using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProject.Models;

namespace AspFinalProject.Controllers
{
    public class TeacherController : Controller
    {

        AspProjectDBEntities1 db = new AspProjectDBEntities1();


        // GET: Teacher
        public ActionResult Index()
        {
            var data = db.Students.SqlQuery("select * from Teacher").ToList();

            return View(data);
        }

        public ActionResult EditTeacherProfile()
        {

            return View("EditTeacher");
        }



        // POST: StudentProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {

            // TODO: Add update logic here

            List<object> parameters = new List<object>();

            parameters.Add(teacher.id);
            parameters.Add(teacher.name);
            parameters.Add(teacher.department);
            parameters.Add(teacher.designation);
            parameters.Add(teacher.phone);
            parameters.Add(teacher.gender);

            object[] objectarray = parameters.ToArray();

            int output = db.Database.ExecuteSqlCommand("update Teacher set id=@p0,name=@p1,department=@p2,designation=@p3,phone=@p4 ,gender=@p5 where id=@p0", objectarray);
            if (output > 0)
            {
                ViewBag.Itemmsg = "Your Product id " + teacher.id + "  is updated seccussfully";
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