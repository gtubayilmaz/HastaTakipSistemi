namespace KlinikWeb.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TcNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string? UserId { get; set; } // Identity tablosundaki kullanıcı ID'si


        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
