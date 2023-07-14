using System;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL1;

namespace PublicHearings
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        BALClass1 objbal = new BALClass1();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Selectdetails1();
            }
        }

        public void Selectdetails1()

        {
            try
            {
                DataSet ds = objbal.Selectdetails();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}