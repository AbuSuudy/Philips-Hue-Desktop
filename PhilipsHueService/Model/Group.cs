using System.Collections.Generic;

namespace PhilipsHueService.Model
{

    public class Action
    {
        public bool on { get; set; }
        public int bri { get; set; }
        public int ct { get; set; }
        public string alert { get; set; }
        public string colormode { get; set; }
    }

    public class Group
    {
        public string name { get; set; }
        public List<string> lights { get; set; }
        public List<object> sensors { get; set; }
        public string type { get; set; }
        public StateGroup state { get; set; }
        public bool recycle { get; set; }
        public string @class { get; set; }
        public Action action { get; set; }
    }

    public class StateGroup
    {
        public bool all_on { get; set; }
        public bool any_on { get; set; }
    }


}
