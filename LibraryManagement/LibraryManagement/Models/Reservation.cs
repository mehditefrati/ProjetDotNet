using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }
        public Reservation(int adherentID, int bookID, DateTime reservationDate, DateTime returnDate, bool isReturned)
        {
            AdherentID = adherentID;
            BookID = bookID;
            ReservationDate = reservationDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;
        }
        public Reservation(int reservationID, int adherentID, int bookID, DateTime reservationDate, DateTime returnDate, bool isReturned)
        {
            ReservationID = reservationID;
            AdherentID = adherentID;
            BookID = bookID;
            ReservationDate = reservationDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;
        }
        public int ReservationID { get; set; }
        public int AdherentID { get; set; }
        public int BookID { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
