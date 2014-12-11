using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FormulaConstructorMvc.Models;

namespace FormulaConstructorMvc.Controllers
{
    public class FormulaController : Controller
    {
        private string[] _independentVariables = new string[] {"MIBK(X1)", "NIPR(X2)", "O2CN(X3)"};
        private string[] _responses = new string[] { "TEMP(Y1)", "PRES(Y2)", "CONC(Y3)" };
        private string[] _mathFunctions = new string[] { "ABS", "SIN", "COS" };

        public ActionResult Index()
        {
            var selectListVariables = new List<SelectListItem>();
            FillSelectListVariables(selectListVariables, _independentVariables);

            var selectListResponses = new List<SelectListItem>();
            FillSelectListVariables(selectListResponses, _responses);

            var selectListMathFunctions = new List<SelectListItem>();
            FillSelectListMathFunctions(selectListMathFunctions, _mathFunctions);

            var model = new IndexViewModel
            {
                IndependentVariables = selectListVariables,
                Responses = selectListResponses,
                MathFunctions = selectListMathFunctions
            };

            return View(model);
        }

        private void FillSelectListVariables(List<SelectListItem> selectList, string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                selectList.Add(new SelectListItem
                {
                    Text = data[i],
                    Value = GetValueOfVaribale(data[i])
                });
            }
        }

        private string GetValueOfVaribale(string variable)
        {
            return variable.Substring(variable.IndexOf('(') + 1, variable.Length - variable.LastIndexOf(')') + 1);
        }

        private void FillSelectListMathFunctions(List<SelectListItem> selectList, string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                selectList.Add(new SelectListItem
                {
                    Text = data[i],
                    Value = data[i] + "()"
                });
            }
        }
    }
}
