using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string MovieName { get; set; }

        public DateTime MovieYear { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int Price { get; set; }
    }
}

