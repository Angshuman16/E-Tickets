using eTickets.Data.Base;
using eTickets.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movies:IEntityBase
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public  double Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public MovieCategory MovieCategory { get; set; }  // What is enum?   --> Named Constants

        //Relationships

        public List<Actor_Movie> Actors_Movies { get; set; }


        //Reln with Cinema


        public int CinemaId {  get; set; }

        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }



        //Reln with Producer


        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }





    }
}
