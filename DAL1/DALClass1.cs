using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL1
{
    public class DALClass1
    {
        public void Insertdetails(string HearingNametxt, string HearingVenuetxt, string txtDate, string HearingTimetxt, string LineOfActivitytxt, string RegionalOfficetxt, string ExecutiveSummaryTelugu, string ExecutiveSummaryEnglish, string EIAReport, string OtherDocumentOne, string OtherDocumentTwo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert_Publichearings", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hearing_Name_Location", HearingNametxt);
                    cmd.Parameters.AddWithValue("@Hearing_Venue", HearingVenuetxt);
                    cmd.Parameters.AddWithValue("@Hearing_Date", txtDate);
                    cmd.Parameters.AddWithValue("@Hearing_Time", HearingTimetxt);
                    cmd.Parameters.AddWithValue("@Line_Of_Activity", LineOfActivitytxt);
                    cmd.Parameters.AddWithValue("@Regional_Office", RegionalOfficetxt);
                    cmd.Parameters.AddWithValue("@Executive_Summary_Telugu", ExecutiveSummaryTelugu);
                    cmd.Parameters.AddWithValue("@Executive_Summary_English", ExecutiveSummaryEnglish);
                    cmd.Parameters.AddWithValue("@EIA_Report", EIAReport);

                    if (!string.IsNullOrEmpty(OtherDocumentOne))
                    {

                        cmd.Parameters.AddWithValue("@Other_Document_One", OtherDocumentOne);
                    }
                    else
                    {

                        cmd.Parameters.AddWithValue("@Other_Document_One", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(OtherDocumentTwo))
                    {
                        cmd.Parameters.AddWithValue("@Other_Document_Two", OtherDocumentTwo);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Other_Document_Two", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public DataSet Getdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("Get_Publichearings", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataSet Selectdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select_Publichearings", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Updatedetails(int IDtxt, string HearingNametxt, string MeetingsFile)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update_Publichearings", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SNO", IDtxt);
                    cmd.Parameters.AddWithValue("@Hearing_Name_Location", HearingNametxt);
                    cmd.Parameters.AddWithValue("@Meetings_File", MeetingsFile);
                    cmd.ExecuteReader();
                    con.Close();


                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
    }
}
