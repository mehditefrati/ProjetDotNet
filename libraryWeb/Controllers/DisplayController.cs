using library.Data;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using library.Models;

namespace library.Controllers
{
    public class DisplayController : Controller
    {
        Subscriber curentsubscriber = new Subscriber();
        private readonly ApplicationDbContext _db;

        public DisplayController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _db.Books;
            return View(books);
        }

        public IActionResult Details(int id) {
			Book book = _db.Books.FirstOrDefault(d => d.BookId == id);
            if (book == null)
            {
                return NotFound(); // or handle the case where the document is not found
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Reserve(int documentId,int reservationDays)
        {
            // Retrieve the Document from the database
            var book = _db.Books.FirstOrDefault(d => d.BookId == documentId);

            if (book == null)
            {
                // Handle the case where the document is not found
                return NotFound();
            }

            // Check if the document is available
            if (book.Copies > 0)
            {
                
                double total = book.Price ?? 0; // Assuming Price is nullable
                                                     // You can add more logic here to calculate the total based on your requirements

                // Create a Reservation object
                var reservation = new Reservation
                {
                    AdherentID = Convert.ToInt32(HttpContext.Session.GetString("id")) ,
                    BookID = documentId,
                    ReservationDate = DateTime.Now,
                    IsReturned = false
                };

                // Calculate ReturnDate based on the ReservedDate and the user-provided reservation period
                reservation.ReturnDate = reservation.ReservationDate.AddDays(reservationDays);


                // Save the Reservation to the database
                _db.Reservations.Add(reservation);
                _db.SaveChanges();

                // Update the Document with the Reservation information
                book.Copies = book.Copies - 1;
                _db.Books.Update(book);

                _db.SaveChanges();

                //using (var client = new SmtpClient())
                //{
                //    client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);

                //    // Use your Outlook email address and the application-specific password
                //    client.Authenticate("lepas12879@tanlanav.com", "Reset your password");

                //    var message = new MimeMessage();

                //    message.From.Add(new MailboxAddress("Test", "lepas12879@tanlanav.com"));
                //    message.To.Add(new MailboxAddress("Test", "oummany.rico@gmail.com"));
                //    message.Subject = "Reservation Completed";

                //    // Add your email content here
                //    message.Body = new TextPart("plain")
                //    {
                //        Text = "Your reservation has been completed. Thank you!"
                //    };

                //    client.Send(message);
                //    client.Disconnect(true);
                //}



                return RedirectToAction("Index"); // Redirect to the appropriate action after reservation
            }

            // Handle the case where the document is not available
            return RedirectToAction("Details", new { id = documentId }); // Redirect back to the Details view
        }
    }
}

