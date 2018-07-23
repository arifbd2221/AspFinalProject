using System.Collections.Generic;

namespace AspFinalProject.Models
{

    public class TeacherCourseList
    {

        List<Teacher> teachers;
        List<Course> courses;

        public TeacherCourseList(List<Teacher> teachers, List<Course> courses)
        {
            this.teachers = teachers;
            this.courses = courses;

        }


        public List<Teacher> GetTeachers()
        {
            return teachers;
        }

        public List<Course> GetCourses()
        {
            return courses;
        }

        public List<string> GetCourseID()
        {
            List<string> courseID = new List<string>();

            foreach(Course c in courses)
            {
                courseID.Add(c.id);
            }

            return courseID;
        }
    }

}