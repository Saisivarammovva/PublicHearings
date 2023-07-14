using BAL;
using System;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;

namespace PublicHearings
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BALClass1 objbal = new BALClass1();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Getdetails1();
            }
            //Response.Redirect("WebForm2.aspx");
            //Server.Transfer("WebForm2.aspx");
        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                string ExecutiveSummaryTelugu = SaveFile("EStelugu", FileUpload1);
                string ExecutiveSummaryEnglish = SaveFile("Esenglish", FileUpload2);
                string EIAReport = SaveFile("EIAreport", FileUpload3);
                string OtherDocumentOne = SaveFile("ODone", FileUpload4);
                string OtherDocumentTwo = SaveFile("ODtwo", FileUpload5);
                objbal.Insertdetails(HearingNametxt.Text, HearingVenuetxt.Text, txtDate.Text, HearingTimetxt.Text, LineOfActivitytxt.Text, RegionalOfficetxt.Text,
                    ExecutiveSummaryTelugu, ExecutiveSummaryEnglish, EIAReport, OtherDocumentOne, OtherDocumentTwo);

                HearingNametxt.Text = "";
                HearingVenuetxt.Text = "";
                txtDate.Text = "";
                HearingTimetxt.Text = "";
                LineOfActivitytxt.Text = "";
                RegionalOfficetxt.Text = "";


                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string SaveFile(string filetype, FileUpload fileUpload)
        {
            string path = ConfigurationManager.AppSettings["UploadPath"];

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                string ret = Regex.Replace(fileName.Trim(), "[^a-zA-Z0-9_.]+", "");
                string pathSave = path + "\\" + ret + Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(pathSave);
                return pathSave;
            }
            return null;
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["UploadPath"];
                FileUpload MeetFile = GridView1.Rows[e.RowIndex].FindControl("meetingfile") as FileUpload;
                if (MeetFile.HasFile)
                {
                    Label HidLabel = GridView1.Rows[e.RowIndex].FindControl("HearingID") as Label;
                    Label HnameLabel = GridView1.Rows[e.RowIndex].FindControl("HearingName") as Label;
                    int Hid = Convert.ToInt32(HidLabel.Text);
                    string Hname = HnameLabel.Text;

                    string fileName = Path.GetFileNameWithoutExtension(MeetFile.FileName);
                    string ret = Regex.Replace(fileName.Trim(), "[^a-zA-Z0-9_.]+", "");
                    string pathSave = path + "\\" + ret + Path.GetExtension(MeetFile.FileName);
                    MeetFile.SaveAs(pathSave);
                    objbal.Updatedetails(Hid, Hname, pathSave);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Getdetails1()
        {
            try
            {
                DataSet ds = objbal.Getdetails();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        

        //private SqlConnection con;
        //private SqlCommand com;
        //private string constr, query;
        //private const string ASCENDING = " ASC";
        //private const string DESCENDING = " DESC";
        //DataTable dt;
        //private void connection()
        //{
        //    constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
        //    con = new SqlConnection(constr);
        //    con.Open();

        //}


        //private void Bindgrid()
        //{
        //    connection();
        //    query = "select *from Employee";//not recommended this i have written just for example,write stored procedure for security    
        //    com = new SqlCommand(query, con);
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    ViewState["Paging"] = dt;
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    con.Close();
        //}
        //protected void Gridpaging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    GridView1.DataSource = ViewState["Paging"];
        //    GridView1.DataBind();
        //}

        //public SortDirection CurrentSortDirection
        //{
        //    get
        //    {
        //        if (ViewState["sortDirection"] == null)
        //        {
        //            ViewState["sortDirection"] = SortDirection.Ascending;
        //        }
        //        return (SortDirection)ViewState["sortDirection"];
        //    }
        //    set
        //    {
        //        ViewState["sortDirection"] = value;
        //    }
        //}
        //protected void Gridsorting(object sender, GridViewSortEventArgs e)
        //{
        //    string ColumnTosort = e.SortExpression;

        //    if (CurrentSortDirection == SortDirection.Ascending)
        //    {
        //        CurrentSortDirection = SortDirection.Descending;
        //        SortGridView(ColumnTosort, DESCENDING);
        //    }
        //    else
        //    {
        //        CurrentSortDirection = SortDirection.Ascending;
        //        SortGridView(ColumnTosort, ASCENDING);
        //    }

        //}

        //private void SortGridView(string sortExpression, string direction)
        //{
        //    //  You can cache the DataTable for improving performance    
        //    dynamic dt = ViewState["Paging"];
        //    DataTable dtsort = dt;
        //    DataView dv = new DataView(dtsort);
        //    dv.Sort = sortExpression + direction;

        //    GridView1.DataSource = dv;
        //    GridView1.DataBind();
        //}
    }

}





