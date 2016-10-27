using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;

public partial class Listado : System.Web.UI.Page
{
    public string HTML_Categorias = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HTML_Categorias = CargaCategorias();
        }
    }

    protected string CargaCategorias()
    {
        string retorno = "";
        ConsultaSQL consulta = new ConsultaSQL("SELECT * FROM Categorias", "Gomitas");
        DataTable dtTabla = consulta.ObtenerTabla();

        foreach (DataRow row in dtTabla.Rows)
        {
            retorno += "<li><a href='#'>" + row["descrip"].ToString() + "</a></li>";
        }

        return retorno;
    }
}