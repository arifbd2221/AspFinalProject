using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProject.Models;

namespace AspFinalProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (AspProjectDBEntities2 dataModel = new AspProjectDBEntities2())
            {

                var userDetails = dataModel.Users.Where(x => x.name == user.name &&
                                    x.pass == user.pass
                                    ).FirstOrDefault();

                string w = Request.Form["UserType"].ToString();


                if (userDetails == null)
                {
                    user.ErroMsg = "Wrong user name or password";

                    return View("Index", user);
                }
                else
                {
                    Session["user_id"] = userDetails.id;
                    Session["user_name"] = userDetails.name;
                    Session["who"] = userDetails.who;

                    

                    if (w.Equals("admin"))
                    {

                        //string sql = "SELECT Student.id,Address.city,Address.street,Address.zip FROM Student RIGHT JOIN Address ON Student.id = Address.id";


                        return RedirectToAction("Index", "Home");
                    }

                    else if (w.Equals("student"))
                    {
                        return RedirectToAction("EditStudentProfile", "StudentProfile");
                    }

                    else if (w.Equals("teacher"))
                    {
                        return RedirectToAction("EditTeacher", "Teacher");
                    }

                   
                }

            }


            return View();
        }


        public ActionResult logut()
        {
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }

    }
}