using System.Data;

namespace GamesReview.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Img { get; set; }

        public int Nota { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string reviwer { get; set; }

    }
}