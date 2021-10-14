using System.Collections.Generic;

namespace linq
{
    class RootObject
    {
        public string type { get; set; }

        public List<Feature> features { get; set; }
    }

    class Feature
    {
        public string type { get; set; }

        public Properties properties { get; set; }
    }

    class Properties
    {
        public string neighborhood { get; set; }
    }
}
