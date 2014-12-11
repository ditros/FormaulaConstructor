using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormulaConstructorMvc.Models
{
    public class IndexViewModel
    {
        public List<SelectListItem> IndependentVariables { get; set; }
        public List<SelectListItem> Responses { get; set; }
        public List<SelectListItem> MathFunctions { get; set; }
    }
}