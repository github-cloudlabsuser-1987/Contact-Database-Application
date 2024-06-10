using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        // This action returns the 'Index' view which displays a list of all users.
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        // This action returns the 'Details' view for a specific user identified by the 'id' parameter.
        public ActionResult Details(int id)
        {
            // Find the user in the list using the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a 404 Not Found status
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, pass the user data to the 'Details' view
            return View(user);
        }

        // GET: User/Create
        // This action returns the 'Create' view which allows the user to enter information for a new user.
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // This action handles the POST request when a user submits the 'Create' form.
        [HttpPost]
        public ActionResult Create(User user)
        {
            // If the model state is valid, add the new user to the list and redirect to the 'Index' view
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the 'Create' view with the current user data
            return View(user);
        }

        // GET: User/Edit/5
        // This action returns the 'Edit' view for a specific user identified by the 'id' parameter.
        public ActionResult Edit(int id)
        {
            // Find the user in the list using the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a 404 Not Found status
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, pass the user data to the 'Edit' view
            return View(user);
        }

        // POST: User/Edit/5
        // This action handles the POST request when a user submits the 'Edit' form.
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // If the model state is valid, update the user in the list and redirect to the 'Index' view
            if (ModelState.IsValid)
            {
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);

                // If the user doesn't exist, return a 404 Not Found status
                if (existingUser == null)
                {
                    return HttpNotFound();
                }

                // Update the user's properties
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Update other properties as needed

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the 'Edit' view with the current user data
            return View(user);
        }

        // GET: User/Delete/5
        // This action returns the 'Delete' view for a specific user identified by the 'id' parameter.
        public ActionResult Delete(int id)
        {
            // Find the user in the list using the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a 404 Not Found status
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, pass the user data to the 'Delete' view
            return View(user);
        }

        // POST: User/Delete/5
        // This action handles the POST request when a user confirms the deletion of a user.
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user in the list using the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user exists, remove the user from the list
            if (user != null)
            {
                userlist.Remove(user);
            }

            // Redirect to the 'Index' view
            return RedirectToAction("Index");
        }


    }
}
