namespace KlinikWeb.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
