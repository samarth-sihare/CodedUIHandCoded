using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIHandCoded
{
    class CustomUtilityMethods
    {

        //Few Methods for Html

        ///<summary>
        ///Few methods for HTML Table
        ///</summary>
        ///
        private HtmlCell cellByStringContaining(int columnIndex, HtmlTable table, string cellText)
        {
            HtmlCell cell = new HtmlCell(table);
            cell.TechnologyName = "Web";
            cell.SearchProperties.Add(HtmlCell.PropertyNames.ColumnIndex, columnIndex.ToString());
            cell.SearchProperties.Add(HtmlCell.PropertyNames.FriendlyName, cellText, PropertyExpressionOperator.Contains);

            return cell;
        }

        private HtmlCell cellByRowColumnIndex(int rowIndex, int columnIndex, HtmlTable table)
        {
            HtmlCell cell = new HtmlCell(table);
            cell.TechnologyName = "Web";
            cell.SearchProperties.Add(HtmlCell.PropertyNames.RowIndex, rowIndex.ToString());
            cell.SearchProperties.Add(HtmlCell.PropertyNames.ColumnIndex, columnIndex.ToString());

            return cell;
        }

        private HtmlRow getRowContaining(string text, HtmlTable table)
        {
            HtmlRow row = new HtmlRow(table);
            row.SearchProperties.Add(HtmlRow.PropertyNames.InnerText, text, PropertyExpressionOperator.Contains);
            return row;
        }

        //This method can check a checkbox in a table that has certain string in its row
        //This method may be modified to get Table parameter accordingly
        public void checkCheckBoxWithStringInRow(string companyName, HtmlTable table)
        {
            HtmlCheckBox countryChkBox = new HtmlCheckBox(this.getRowContaining(companyName, table));

            if (countryChkBox.Checked == false)
                Mouse.Click(countryChkBox);

        }


    }
}
