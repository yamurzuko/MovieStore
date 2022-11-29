using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Actor
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Name { get; set; }

		public string Surname { get; set; }

		public List<Movie> StarringMoovies { get; set; }
    }
}

