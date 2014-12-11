using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaConstructor
{
    public partial class Index : System.Web.UI.Page
    {
        private string[] _independentVariables = new string[] { "MIBK(X1)", "NIPR(X2)", "O2CN(X3)" };
        private string[] _responses = new string[] { "TEMP(Y1)", "PRES(Y2)", "CONC(Y3)" };
        private string[] _mathFunctions = new string[] { "ABS", "SIN", "COS" };

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDropDownListData();
            LoadPageScripts();
        }

        private void LoadPageScripts()
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "ExitScript",
                "<script language=javascript>" +
                "function exit() {var exit = confirm(\"Хотите закрыть страницу?\");" +
                "if (exit) {window.close();} else {return false;}}</script>");

            ClientScript.RegisterStartupScript(Page.GetType(), "OnChangeScript",
                "<script language=javascript>" +
                @"function OnChange(dropdown)
                {
                    var myindex = dropdown.selectedIndex;
                    var SelectedValue = dropdown.options[myindex].value;
                    insertAtCursor(SelectedValue);

                    return true;
                }</script>");

            ClientScript.RegisterStartupScript(Page.GetType(), "InsertAtCursorScript",
                "<script language=javascript>" +
                @"function insertAtCursor(text) {
                    var field = document.getElementById('Formula');

                    if (document.selection) {
                        var range = document.selection.createRange();

                        if (!range || range.parentElement() != field) {
                            field.focus();
                            range = field.createTextRange();
                            range.collapse(false);
                        }
                        range.text = text;
                        range.collapse(false);
                        range.select();
                    } else {
                        field.focus();
                        var val = field.value;
                        var selStart = field.selectionStart;
                        var caretPos = selStart + text.length;
                        field.value = val.slice(0, selStart) + text + val.slice(field.selectionEnd);
                        field.setSelectionRange(caretPos, caretPos);
                    }
                }</script>");

            ButtonOk.Attributes["onclick"] = "exit();";
            ButtonCancel.Attributes["onclick"] = "exit();";
            ButtonHelp.Attributes["onclick"] = "return false;";
            IndependentVariables.Attributes["onchange"] = "OnChange(this);";
            IndependentVariables.Attributes["onmousedown"] = "this.value = '';";
            Responses.Attributes["onchange"] = "OnChange(this);";
            Responses.Attributes["onmousedown"] = "this.value = '';";
            MathFunctions.Attributes["onchange"] = "OnChange(this);";
            MathFunctions.Attributes["onmousedown"] = "this.value = '';";
        }

        private void LoadDropDownListData()
        {
            IndependentVariables.Items.Clear();
            Responses.Items.Clear();
            MathFunctions.Items.Clear();

            var selectListVariables = new List<ListItem>();
            FillSelectListVariables(selectListVariables, _independentVariables);

            var selectListResponses = new List<ListItem>();
            FillSelectListVariables(selectListResponses, _responses);

            var selectListMathFunctions = new List<ListItem>();
            FillSelectListMathFunctions(selectListMathFunctions, _mathFunctions);

            foreach (var item in selectListVariables)
            {
                IndependentVariables.Items.Add(item);
            }

            foreach (var item in selectListResponses)
            {
                Responses.Items.Add(item);
            }

            foreach (var item in selectListMathFunctions)
            {
                MathFunctions.Items.Add(item);
            }
        }

        private void FillSelectListVariables(List<ListItem> selectList, string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                selectList.Add(new ListItem
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

        private void FillSelectListMathFunctions(List<ListItem> selectList, string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                selectList.Add(new ListItem
                {
                    Text = data[i],
                    Value = data[i] + "()"
                });
            }
        }

        protected void IndependentVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = IndependentVariables.SelectedValue;
            Formula.Text += selectedValue;
        }
    }
}