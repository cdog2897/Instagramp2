namespace Instagramp_2.Models
{
    public class SearchTermModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
   

        public SearchTermModel(string name, string description, string imgURL)
        {
            this.name = name;
            this.description = description;
            this.imgURL = imgURL;
        }
        public SearchTermModel()
        {
        }
    }
}
