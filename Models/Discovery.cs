using System.Collections.Generic;

namespace Bouzin.Models
{
    public class Discovery
    {
        //String url, ICollection Container
        public string url { get; set; }
        public ICollection<Container> containers { get; set;} = new List<Container>();
    }
}