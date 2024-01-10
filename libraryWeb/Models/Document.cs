namespace library.Models
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Availability { get; set; }
        public int? BorrowerID { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? ReservationID { get; set; }
        public Reservation? Reservation { get; set; }
        public byte[]? Image { get; set; }

    }
}
