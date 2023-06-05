using System;
using System.Collections.Generic;
using System.Text;

namespace PhilipsHueService.Model
{
    public class Appdata
    {
        public int version { get; set; }
        public string data { get; set; }
    }

    public class Scene
    {
        public string name { get; set; }
        public string type { get; set; }
        public string group { get; set; }
        public List<string> lights { get; set; }
        public string owner { get; set; }
        public bool recycle { get; set; }
        public bool locked { get; set; }
        public Appdata appdata { get; set; }
        public string picture { get; set; }
        public string image { get; set; }
        public DateTime lastupdated { get; set; }
        public int version { get; set; }

    }
}
