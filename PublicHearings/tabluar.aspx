<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabluar.aspx.cs" Inherits="PublicHearings.tabluar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">  
     <a class="navbar-brand" href="#">Tabulator with C#</a>  
     <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">  
         <span class="navbar-toggler-icon"></span>  
     </button>  
  
     <div class="collapse navbar-collapse" id="navbarColor01">  
         <ul class="navbar-nav mr-auto">  
             <li class="nav-item active">  
                 <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>  
             </li>  
         </ul>  
     </div>  
 </nav>
    <form id="form1" runat="server">
        <div>
                </div>
    </form>
            <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <br />  
    <h3>Tabulator with C# basic(Converting the HTML Table into Tabulator table</h3>  
    <br />  
    <div class="row">  
        <div class="col-12 tabulator-example">  
            <table class="table table-condensed table-striped table-hover table-sm tabulator_table">  
                <thead>  
                    <tr class="table-primary">  
                        <th scope="col">#</th>  
                        <th scope="col">Customer Name</th>  
                        <th scope="col">Email</th>  
                        <th scope="col">Company</th>  
                        <th scope="col">Street</th>  
                        <th scope="col">City</th>  
                        <th scope="col">Region</th>  
                        <th scope="col">Country</th>  
                    </tr>  
                </thead>  
                <tbody>  
                    <%=GetTableRow()%>  
                </tbody>  
            </table>  
        </div>  
    </div>  
  
    <script type="text/javascript">  
        $(document).ready(function () {
            var table = new Tabulator(".tabulator_table", {
                height: "70vh",
                layout: "fitDataStretch",
                pagination: "local",
                paginationSize: 10,
                paginationSizeSelector: [10, 20, 30, 50, 100]
            });
        });
    </script>  
</asp:Content> 
    
</body>
</html>
