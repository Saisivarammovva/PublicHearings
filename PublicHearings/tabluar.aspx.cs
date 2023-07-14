using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicHearings
{
    public partial class tabluar : System.Web.UI.Page
    {
        private Repository repository = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.repository = new Repository();
            }

        }
        public class Repository
        {
            public readonly SqlConnection Conn = null;

            public Repository()
            {
                this.Conn = new SqlConnection(ConfigurationManager.AppSettings["DB"].ToString());
            }

            /// <summary>  
            /// This method will get the list of Customer from database table CustomerRawInfo.  
            /// </summary>  
            /// <returns>List of customers in datatable</returns>  
            public DataTable GetCustomers()
            {
                string Query = string.Empty;
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = null;

                try
                {
                    Query = "SELECT ROW_NUMBER() OVER (ORDER BY CUSTOMERNAME) ROW_NUM,CUSTOMERNAME,EMAIL,COMPANY,STREET,CITY,REGION,COUNTRY FROM CUSTOMERRAWINFO WITH(NOLOCK)";
                    SqlCommand sqlCommand = new SqlCommand(Query, Conn);
                    Conn.Open();

                    // create data adapter  
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    // this will query your database and return the result to your datatable  
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    dataTable = null;
                }
                finally
                {
                    Conn.Close();
                    sqlDataAdapter.Dispose();
                }

                return dataTable;
            }
        }
        

    
        /// <summary>  
        /// This method will return the prepare html table body  
        /// </summary>  
        /// <returns>string html table body</returns>  
        public string GetTableRow()
        {
            string result = string.Empty;
            string htmlTr = string.Empty;
            string htmlTd = string.Empty;

            DataTable dataTable = new DataTable();

            try
            {
                // Get the data from the database repository  
                dataTable = this.repository.GetCustomers();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            // append the data to each cell of a row  
                            htmlTd += "<td>" + item + "</td>";
                        }

                        // append the row data to table row  
                        htmlTr += "<tr>" + htmlTd + "</tr>";

                        // clear for the next row cell data so that previous data will not append  
                        htmlTd = string.Empty;
                    }
                }

                result = htmlTr;
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            finally
            {
                dataTable = null;
            }
            return result;
        }
    }
}