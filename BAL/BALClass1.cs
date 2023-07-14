using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;

namespace BAL
{
    public class BALClass1
    {
        DALClass1 objdal = new DALClass1();

        public void Insertdetails(string HearingNametxt, string HearingVenuetxt, string txtDate, string HearingTimetxt, string LineOfActivitytxt, string RegionalOfficetxt,
            string ExecutiveSummaryTelugu, string ExecutiveSummaryEnglish, string EIAReport, string OtherDocumentOne, string OtherDocumentTwo)
        {
            try
            {
                objdal.Insertdetails(HearingNametxt, HearingVenuetxt, txtDate, HearingTimetxt, LineOfActivitytxt, RegionalOfficetxt, ExecutiveSummaryTelugu,
                    ExecutiveSummaryEnglish, EIAReport, OtherDocumentOne, OtherDocumentTwo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Getdetails()
        {
            try
            {
                DataSet ds = objdal.Getdetails();
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
                DataSet ds = objdal.Selectdetails();
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Updatedetails(int IDtxt, string HearingNametxt, string MeetingsFile)
        {
            try
            {
                objdal.Updatedetails(IDtxt, HearingNametxt, MeetingsFile);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
