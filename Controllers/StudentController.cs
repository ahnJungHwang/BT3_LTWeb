using Microsoft.AspNetCore.Mvc;
using BT3.Models;
using System.Collections.Generic;
using System.Linq;

namespace BT3.Controllers
{
    public class StudentController : Controller
    {
        // Static list to store registered students (simulating a database)
        public static List<Student> registeredStudents = new List<Student>();

        // 1. Action Index với View là trang đăng kí chuyên ngành
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // 3. Trang kết quả sau khi Đăng ký (/Student/ShowKQ)
        [HttpPost]
        public IActionResult ShowKQ(Student student)
        {
            if (student != null)
            {
                // Thêm vào danh sách
                registeredStudents.Add(student);

                // 4. Cho biết số lượng SV đã Đăng ký cùng ngành học với bạn
                int count = registeredStudents.Count(s => s.ChuyenNganh == student.ChuyenNganh);
                ViewBag.SoLuong = count;
            }

            return View(student);
        }
    }
}
