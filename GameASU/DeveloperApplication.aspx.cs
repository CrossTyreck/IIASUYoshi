using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameASU
{
    public partial class DeveloperApplication : System.Web.UI.Page
    {

        

        protected void Page_Load()
        {
            
        }

        protected void CheckDevRole_Click(object sender, EventArgs e)
        {
            if (!acceptTerms.Checked)
            {
                TermsLabel.ForeColor = System.Drawing.Color.Red;
                TermsLabel.Text = "Please accept the terms to become a developer.";
            }
            else
            {
                //dole out developer role!
            }
        }

      
    }
}