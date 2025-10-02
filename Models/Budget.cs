namespace dotnet_mvc_first_app.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public decimal TotalBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRepeat { get; set; }
        public string Status { get; set; }
    }
}
