using System;
using System.Collections.Generic;
using System.Text;

namespace SmartChoiceApp.Models
{
    public class PestilentInsect
    {
        public string ProductDetailID { get; set; }
        public string PestilentInsectID { get; set; }
        public string ProductID { get; set; }
        public List<string> Images { get; set; }
        public List<string> Solution { get; set; }
    }
}
