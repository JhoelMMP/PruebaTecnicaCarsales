
namespace RickAndMorty.Domain.Entities
{
    public class Episodio
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public string airDate { get; set; }
        
        public string episode { get; set; }
        
        public string[] characters { get; set; }

        public string url { get; set; }

        public string created { get; set; }

       
        private Episodio() { }

        // Constructor público para crear la entidad
        private Episodio(int id, string name, string airDate, string episode, string[] characters, string url, string created)
        {
            this.id = id;
            this.name = name;
            this.airDate = airDate;
            this.episode = episode;
            this.characters = characters;
            this.url = url;
            this.created = created;
        }
    }
}
