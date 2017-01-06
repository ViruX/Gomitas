using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class preview : System.Web.UI.Page
{
    public string HTML_Categorias = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HTML_Categorias = (new Utiles()).ObtenerHTMLCategorias();
    }
}