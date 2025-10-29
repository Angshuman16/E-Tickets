using eTickets.Data.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor:IEntityBase
    {


        [Key]    // Annotations 
        public int Id { get; set; }


        [Display(Name="Profile Picture URL")]
        [Required(ErrorMessage = "Profile Pic is a Required Field")]
        public string  ProfilePicUrl  { get; set; }


        [Display(Name = "FullName")]
        [Required(ErrorMessage = " FullName of the Actor is a Required Field")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="FullName must be Between 3 and 50 Characters")]
        public string FullName { get; set; }


        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Biography is a Required Field")]
        public string Bio { get; set; }


        //Relationship


        public List<Actor_Movie> Actors_Movies { get; set; }


    }
}
