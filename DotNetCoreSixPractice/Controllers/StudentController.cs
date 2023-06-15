using DotNetCoreSixPractice.Data;
using DotNetCoreSixPractice.Models.MainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSixPractice.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;

        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
        }










        //READ
        //read the data from the database and display it to a view to show the data gathered
        public async Task<IActionResult> Index()
        {
            var studentsList = await db.Students.ToListAsync();
            return View(studentsList);
        }











        //GET CREATE
        //get data from a view where there is a form to get user input through input fields
        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        //POST CREATE
        //post the data that received from GET as the value of the properties handled by the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            //check if Name property is null
            if (student.Name == null)
            {
                ModelState.AddModelError("Name", "Please provide a complete and correct name.");
            }
            //check if Age property is not lessthan or equal to zero
            if (student.Age <= 0)
            {
                ModelState.AddModelError("Age", "Age must be greater than or equal to 1.");
            }
            //check if Course property is null
            if (student.CourseYearSec == null)
            {
                ModelState.AddModelError("CourseYearSec", "The CourseYearSec field is required.");
            }
            //check if Email property is null
            if (student.Email == null)
            {
                ModelState.AddModelError("Email", "Do not hesitate, Your Email is secured here.");
            }

            if (ModelState.IsValid)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {            
                return View(student);
            }
        }

















        //GET EDIT
        //edit data that is displayed in the database
        //displays te existing data of the id that is selected
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = await db.Students.FindAsync(id); //store in variable the id number that is found from the database
            //var studentFromDbFirst = await db.Students.FirstOrDefaultAsync(x => x.Id == id); //match the id that is stored in studentFromDb to the Id property of our Student class
            //var studentFromDbSingle = await db.Students.SingleOrDefaultAsync(x => x.Id == id);

            if (studentFromDb == null) //check if id exist
            {
                return NotFound();
            }
            return View(studentFromDb); //if yes return to Edit View. Edit view looks like the Create View
        }

        //POST EDIT
        //edit the data and post the updated data back to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            //check if Name property is null
            if (student.Name == null)
            {
                ModelState.AddModelError("Name", "Please provide a complete and correct name.");
            }
            //check if Age property is not lessthan or equal to zero
            if (student.Age <= 0)
            {
                ModelState.AddModelError("Age", "Age must be greater than or equal to 1.");
            }
            //check if Course property is null
            if (student.CourseYearSec == null)
            {
                ModelState.AddModelError("CourseYearSec", "The CourseYearSec field is required.");
            }
            //check if Email property is null
            if (student.Email == null)
            {
                ModelState.AddModelError("Email", "Do not hesitate, Your Email is secured here.");
            }

            if (ModelState.IsValid)
            {
                 db.Students.Update(student);
                 db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }

















        //GET DELETE
        //delete data that is displayed in the database
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = db.Students.Find(id); //store in variable the id number that is found from the database
            //var studentFromDbFirst = await db.Students.FirstOrDefaultAsync(x => x.Id == id); //match the id that is stored in studentFromDb to the Id property of our Student class
            //var studentFromDbSingle = await db.Students.SingleOrDefaultAsync(x => x.Id == id);

            if (studentFromDb == null) //check if id exist
            {
                return NotFound();
            }
            return View(studentFromDb); //if yes return to Edit View. Edit view looks like the Create View
        }

        //POST DELETE
        //delete the data and post the updated data back to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? id)
        {
            Student? studentFound = db.Students.Find(id);

            if(studentFound==null)
            {
                return NotFound();
            }

            db.Students.Remove(studentFound);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
