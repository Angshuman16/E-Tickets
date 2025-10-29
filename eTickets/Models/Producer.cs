using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer:IEntityBase
    {


        [Key]    // Annotations 


       
        public int Id { get; set; }


        [Display(Name = "Profile Picture URL")]
        public string profilepicUrl { get; set; }


        [Display(Name = "Full Name")]
        public string fullName { get; set; }


        [Display(Name = "Biography")]
        public string Bio { get; set; }


        //Relationships

        public List<Movies> Movies { get; set; }


    }

}
