using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Teacher
    {

        public int Id { get; set; }
       
        public string? Name { get; set; }

        public string Description { get; set; }

        [Key]
        public int Taccessid { get; set; }

    }
}
