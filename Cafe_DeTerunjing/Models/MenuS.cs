using System.ComponentModel.DataAnnotations;



namespace Cafe_DeTerunjing.Models
{
    public class MenuS
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
