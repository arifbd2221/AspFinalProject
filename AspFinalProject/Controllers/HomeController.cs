using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspFinalProject.Models;
using System.Web.Mvc;
using System.Diagnostics;

namespace AspFinalProject.Controllers
{
    public class HomeController : Controller
    {

        AspProjectDBEntitiesCourse db = new AspProjectDBEntitiesCourse();
        AspProjectDBEntities1 db2 = new AspProjectDBEntities1();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCourse()
        {
           
            return View("CreateCourse");
        }


        [HttpPost]
        public ActionResult CreateCourseInfo(Course course)
        {
            List<object> parameters = new List<object>();
            parameters.Add(course.id);
            parameters.Add(course.name);
            parameters.Add(course.semester);
            object[] objectarray = parameters.ToArray();
            //SQL Query function is used only for retrieve sql tables. 
            //To Perform Insert, Update , Delete we use Database.ExecuteSqlCommand which will return affected rows in database table
            int output = db.Database.ExecuteSqlCommand("insert into Course(id,name,semester) values(@p0,@p1,@p2)", objectarray);
            if (output > 0)
            {
                ViewBag.Itemmsg = "Your Course " + course.name + "  is added Successfully";
            }

            return View("CourseCreated");
            
        }


        public ActionResult logut()
        {
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }


        public ActionResult AddCsTc()
        {

            TeacherCourseList teacherCourseList;

            var teachers = db2.Teachers.SqlQuery("select * from Teacher").ToList();
            var courses = db.Courses.SqlQuery("select * from Course").ToList();

            teacherCourseList = new TeacherCourseList(teachers, courses);

            return View(teacherCourseList);

        }



        [HttpPost]
        public ActionResult AddCourseToTeacher(FormCollection  fc)
        {
            string cs_id = fc["Course"].ToString();
            string tc_id = fc["tc_id"].ToString();
            System.Diagnostics.Debug.WriteLine(tc_id+", My debug value here , " + cs_id);


            AspProjectDBEntitiestakenCourse db = new AspProjectDBEntitiestakenCourse();

            List<object> parameters = new List<object>();
            parameters.Add(tc_id);
            parameters.Add(cs_id);

            object[] objectarray = parameters.ToArray();

            db.Database.ExecuteSqlCommand("insert into Tc_Taken_Course(tc_id,cs_id) values(@p0,@p1)", objectarray);

            return View("Success");
        }


        public ActionResult Courses()
        {
            AspProjectDBEntitiesCourse db = new AspProjectDBEntitiesCourse();

            var data = db.Courses.SqlQuery("select * from Course");

            return View(data);
        }

        [HttpPost]
        public ActionResult modifyCourse(FormCollection fc)
        {
            AspProjectDBEntitiesCourse db = new AspProjectDBEntitiesCourse();
            List<object> parameters = new List<object>();
            string c = fc["c_id"].ToString();
            parameters.Add(c);

            object[] objectArray = parameters.ToArray();

            Debug.WriteLine("Hello There "+c);

            db.Database.ExecuteSqlCommand("delete from Course where id=@p0", objectArray);



            return View("Success");
        }


    }
}



/*
 * if (Session["id"] == null)
    {
        Response.Redirect("~/login/index");
    }
 
 * */
