namespace Bouzin.Models
{
    public class Container
    {
        //String id, String Name, String imgName, String dockerFile, String discoveryURL, Int port
        public string id { get; set; }
        public string name { get; set; }
        public string imgName { get; set; }
        public string dockerFile { get; set; }
        public string discoveryURL { get; set; }
        public int port { get; set; }
    }
}