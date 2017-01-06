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


/// <summary>
/// Descripción breve de Utiles
/// </summary>
public class Utiles
{
    public string ObtenerHTMLCategorias()
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