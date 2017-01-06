using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;
using System.IO;
using System.Net;

public partial class Listado : System.Web.UI.Page
{
    public string HTML_Categorias = "";
    public string HTML_ProductosInicio = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HTML_Categorias = (new Utiles()).ObtenerHTMLCategorias();
            HTML_ProductosInicio = ObtenerProductosInicio();
        }
    }

    protected string ObtenerProductosInicio()
    {
        string retorno = "";
        ConsultaSQL consulta = new ConsultaSQL("SELECT * FROM Productos ORDER BY NewId()", "Gomitas");
        DataTable dtTabla = consulta.ObtenerTabla();

        foreach (DataRow row in dtTabla.Rows)
        {
            string imgUrl = "";
            //if (File.Exists("http://localhost:52780/productos/" + row["codigo"].ToString() + ".png"))
            //{
            //    imgUrl = "http://localhost:52780/productos/" + row["codigo"].ToString() + ".png";
            //}
            //else
            //{
            //    imgUrl = "/productos/img_nd.png";
            //}

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:52780/productos/" + row["codigo"].ToString() + ".png");
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                imgUrl = "http://localhost:52780/productos/" + row["codigo"].ToString() + ".png";
            }
            catch
            {
                // image doesn't exist, set to default picture
                imgUrl = "/img/img_nd.png";
            }

            retorno += "<div class='grid_1_of_4 images_1_of_4'>";
            retorno += "	<a href = 'Preview.aspx?c=" + row["codigo"].ToString() + "'><img src='" + imgUrl + "' alt='' /></a>";
            retorno += "	<h2>" + row["nombre"].ToString() + "</h2>";
            retorno += "    <div class='price-details'>";
            retorno += "	    <div class='price-number'>";
            if (decimal.Parse(row["p_promo"].ToString()) > 0)
            {
                retorno += "			<p><span class='rupees'>" + String.Format("{0:C}", decimal.Parse(row["p_promo"].ToString())) + "</span></p>";
            }
            else
            {
                retorno += "			<p><span class='rupees'>" + String.Format("{0:C}", decimal.Parse(row["p_lista"].ToString())) + "</span></p>";
            }
            
            retorno += "		</div>";
            retorno += "        <div class='add-cart'>";
            retorno += "			<h4><a href = 'Preview.aspx?c=" + row["codigo"].ToString() + "'><i class='fa fa-shopping-cart' aria-hidden='true'></i>&nbsp;Agregar</a></h4>";
            retorno += "			</div>";
            retorno += "        <div class='clear'></div>";
            retorno += "	</div>";
            retorno += "</div>";

        }

        return retorno;
    }
}