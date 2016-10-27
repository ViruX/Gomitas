using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;

namespace Datos
{
    public class ConsultaSQL
    {
        private SqlCommand _Comando;
        private SqlDataReader _Lector;
        private DataTable _Tabla;
        private SqlParameter _Parametro;
        private SqlTransaction _Transaccion;
        private string _Conexion;
        private string _Consulta;
        private bool _MultipleQuery;

        public string Conexion
        {
            get
            {
                return this._Conexion;
            }
            set
            {
                this._Conexion = value;
                if (this._Comando == null)
                    return;
                this._Comando.Connection = this.ObtenerConexion(this._Conexion);
            }
        }

        public string Consulta
        {
            get
            {
                return this._Comando.CommandText;
            }
            set
            {
                this._Comando.CommandText = value;
            }
        }

        public bool MultipleQuery
        {
            get
            {
                return this._MultipleQuery;
            }
            set
            {
                this._MultipleQuery = value;
            }
        }

        public ConsultaSQL()
        {
            this._Comando = new SqlCommand();
            this._Comando.Connection = this.ObtenerConexion();
            this._Comando.CommandText = this._Consulta;
            this._Tabla = new DataTable();
            this._Lector = (SqlDataReader)null;
        }

        public ConsultaSQL(string Consulta)
        {
            this._Comando = new SqlCommand();
            this._Comando.Connection = this.ObtenerConexion();
            this._Comando.CommandText = Consulta;
            this._Tabla = new DataTable();
            this._Lector = (SqlDataReader)null;
        }

        public ConsultaSQL(string Consulta, string NombreConexion)
        {
            this._Comando = new SqlCommand();
            this._Comando.Connection = this.ObtenerConexion(NombreConexion);
            this._Comando.CommandText = Consulta;
            this._Tabla = new DataTable();
            this._Lector = (SqlDataReader)null;
        }

        ~ConsultaSQL()
        {
        }

        public void AgregarParametro(string Nombre, SqlDbType Tipo, object Valor)
        {
            this._Parametro = new SqlParameter(Nombre, Tipo);
            this._Parametro.Value = this.ControlarValorParametro(Tipo, Valor);
            this._Comando.Parameters.Add(this._Parametro);
        }

        public void ModificarParametro(string Nombre, object valor)
        {
            this._Comando.Parameters[Nombre].Value = this.ControlarValorParametro(this._Comando.Parameters[Nombre].SqlDbType, valor);
        }

        public void QuitarParametro(string Nombre)
        {
            this._Comando.Parameters.Remove((object)Nombre);
        }

        public void BorrarParametros()
        {
            this._Comando.Parameters.Clear();
        }

        public void Ejecutar()
        {
            if (this._Comando.Connection.State != ConnectionState.Open)
                this._Comando.Connection.Open();
            this._Comando.ExecuteNonQuery();
            this.Cerrar();
        }

        public int EjecutarEscalar()
        {
            if (this._Comando.Connection.State != ConnectionState.Open)
                this._Comando.Connection.Open();
            int num = int.Parse(this._Comando.ExecuteScalar().ToString());
            this.Cerrar();
            return num;
        }

        public int EjecutarYDevolverID()
        {
            if (this._Comando.Connection.State != ConnectionState.Open)
                this._Comando.Connection.Open();
            if (this._Comando.CommandText.Substring(this._Comando.CommandText.Length - 1, 1) != ";")
                this._Comando.CommandText += ";";
            this._Comando.CommandText += "SELECT @@IDENTITY;";
            int num = int.Parse(this._Comando.ExecuteScalar().ToString());
            this.Cerrar();
            return num;
        }

        public DataTable ObtenerTabla()
        {
            try
            {
                if (this._Comando.Connection.State != ConnectionState.Open)
                    this._Comando.Connection.Open();
                this._Tabla.Load((IDataReader)this._Comando.ExecuteReader());
            }
            catch { }

            this.Cerrar();
            return this._Tabla;
        }

        public SqlDataReader ObtenerDataReader()
        {
            if (this._Lector == null)
                this.EjecutarLector();
            return this._Lector;
        }

        public object Campo(string Nombre)
        {
            if (this._Lector == null)
                return (object)"";
            try
            {
                return this._Lector[Nombre];
            }
            catch
            {
                return (object)"";
            }
        }

        public string CampoString(string Nombre)
        {
            if (this._Lector == null)
                return "";
            try
            {
                return this._Lector[Nombre].ToString();
            }
            catch
            {
                return "";
            }
        }

        public int CampoInt(string Nombre)
        {
            if (this._Lector == null)
                return -1;
            try
            {
                return int.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return -1;
            }
        }

        public Decimal CampoDecimal(string Nombre)
        {
            if (this._Lector == null)
                return new Decimal(-1);
            try
            {
                return Decimal.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return new Decimal(-1);
            }
        }

        public double CampoDouble(string Nombre)
        {
            if (this._Lector == null)
                return -1.0;
            try
            {
                return double.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return -1.0;
            }
        }

        public long CampoLong(string Nombre)
        {
            if (this._Lector == null)
                return -1;
            try
            {
                return long.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return -1;
            }
        }

        public bool CampoBool(string Nombre)
        {
            if (this._Lector == null)
                return false;
            try
            {
                return bool.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return false;
            }
        }

        public DateTime CampoDateTime(string Nombre)
        {
            if (this._Lector == null)
                return DateTime.MinValue;
            try
            {
                return DateTime.Parse(this._Lector[Nombre].ToString());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public bool ExistenRegistros()
        {
            if (this._Lector == null)
                this.EjecutarLector();
            bool flag = this._Lector.Read();
            if (!flag && !this.MultipleQuery)
                this.Cerrar();
            return flag;
        }

        public void SiguienteConsulta()
        {
            if (this._Lector == null || this._Lector.IsClosed)
                return;
            this._Lector.NextResult();
        }

        public void Cerrar()
        {
            if (this._Lector != null)
            {
                this._Lector.Close();
                this._Lector.Dispose();
                this._Lector = (SqlDataReader)null;
            }
            if (this._Comando == null)
                return;
            if (this._Comando.Connection.State == ConnectionState.Open)
                this._Comando.Connection.Close();
            if (this._Comando.Connection != null)
                this._Comando.Connection.Dispose();
            this._Comando.Parameters.Clear();
            this._Comando.Dispose();
            this._Comando = (SqlCommand)null;
        }

        public void EscribirConsulta()
        {
            this.EscribirConsulta(false);
        }

        public void EscribirConsulta(bool Corte)
        {
            string s = "";
            if (this._Comando != null)
            {
                foreach (SqlParameter sqlParameter in (DbParameterCollection)this._Comando.Parameters)
                {
                    s = s + (object)"DECLARE " + sqlParameter.ParameterName + " " + (string)(object)sqlParameter.SqlDbType + "</br>";
                    s = s + "SET " + sqlParameter.ParameterName + " = ";
                    if (sqlParameter.SqlDbType == SqlDbType.DateTime)
                    {
                        DateTime result;
                        if (DateTime.TryParse(sqlParameter.Value.ToString(), out result))
                            s = s + "'" + result.ToString("dd/MM/yyyy HH:mm:ss") + "'";
                        else
                            s = string.Concat(new object[4]
                            {
                (object) s,
                (object) "'",
                sqlParameter.Value,
                (object) "'"
                            });
                    }
                    else if (sqlParameter.Value != DBNull.Value)
                    {
                        if (sqlParameter.SqlDbType == SqlDbType.Char || sqlParameter.SqlDbType == SqlDbType.VarChar || (sqlParameter.SqlDbType == SqlDbType.NChar || sqlParameter.SqlDbType == SqlDbType.NText) || sqlParameter.SqlDbType == SqlDbType.NVarChar || sqlParameter.SqlDbType == SqlDbType.Text)
                            s = string.Concat(new object[4]
                            {
                (object) s,
                (object) "'",
                sqlParameter.Value,
                (object) "'"
                            });
                        else
                            s += (string)sqlParameter.Value;
                    }
                    else
                        s += "NULL";
                    s += "</br>";
                }
                s += this._Comando.CommandText;
            }
            HttpContext.Current.Response.Write(s);
            if (!Corte)
                return;
            this.Cerrar();
            HttpContext.Current.Response.End();
        }

        public void NuevaTransaccion()
        {
            if (this._Comando.Connection.State != ConnectionState.Open)
                this._Comando.Connection.Open();
            this._Transaccion = this._Comando.Connection.BeginTransaction("MEGA");
            this._Comando.Transaction = this._Transaccion;
        }

        public void EjecutarBloqueTransaccion()
        {
            if (this._Comando.Connection.State != ConnectionState.Open)
                this._Comando.Connection.Open();
            this._Comando.ExecuteNonQuery();
        }

        public void ConfirmarTransaccion()
        {
            this._Transaccion.Commit();
        }

        public void AnularTransaccion()
        {
            this._Transaccion.Rollback();
            this.Cerrar();
        }

        private SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            return sqlConnection;
        }

        private SqlConnection ObtenerConexion(string Nombre)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings[Nombre].ConnectionString;
            return sqlConnection;
        }

        private void EjecutarLector()
        {
            if (this._Comando.Connection.State == ConnectionState.Open)
                return;
            this._Comando.Connection.Open();
            this._Lector = this._Comando.ExecuteReader();
        }

        private object ControlarValorParametro(SqlDbType Tipo, object Valor)
        {
            object obj = Valor;
            if ((Tipo == SqlDbType.VarChar || Tipo == SqlDbType.Char || (Tipo == SqlDbType.NVarChar || Tipo == SqlDbType.NChar) || Tipo == SqlDbType.Text) && Valor.ToString().Contains("'"))
                obj = (object)Valor.ToString().Replace("'", "'");
            return obj;
        }
    }
}
