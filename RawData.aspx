<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RawData.aspx.vb" Inherits="Library.RawData" %>


<%  Response.WriteFile("Header_Nav.html") %>

<div class ="container">

    <div class="main">

        <h1>Raw Data</h1>

        <p>

            This is a page which shows the Raw Data 

        </p>

       <table class ="data">

           <tr class="data">

               <th class="data">Title</th>
               <th class="data">Author</th>
               <th class="data">Publisher</th>
               <th class="data">ISBN</th>
               <th class="data">Value</th>

               </tr>
           <tr class="data">

           <td class="data">The 100</td>
           <td class="data">Kass Morgan</td>
           <td class="data">Little Brown</td>
           <td class="data">1234567890</td>
           <td class="data">50</td>

               </tr>

           </table>

    </div>

</div>

<%  Response.WriteFile("footer.html") %>
