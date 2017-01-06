using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature_Inspection
{
    class FeatureInfo
    {
        public FeatureInfo Parent { get; set; }
        public string Feature { get; set; }
        public string Nominal { get; set; }
        public string Plus { get; set; }
        public string Minus { get; set; }
        public List<string> Children {  get { Children.Add(Feature);
                                               Children.Add(Nominal);
                                               Children.Add(Plus);
                                               Children.Add(Minus);
                                               return Children; } }

        public FeatureInfo(string feature, string nominal, string plus, string minus)
        {
            Feature = feature;
            Nominal = nominal;
            Plus = nominal;
            Minus = minus;
        }

        
    }
}
