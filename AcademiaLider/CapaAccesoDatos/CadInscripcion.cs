﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using AcademiaLider.Core;
using AcademiaLider.Entidades;

namespace AcademiaLider.CapaAccesoDatos
{
    class CadInscripcion
    {
        public CadInscripcion()
        {

        }

        public bool Crear(Inscripcion objInscripcion)
        {
            bool respuesta = false;
            String sql = "INSERT INTO inscripcion (cod_participante, cod_evento, cod_fecha, cod_nota) " +
                "VALUES (CONCAT(@cod_participante, @cod_evento, @cod_fecha, @cod_nota)";
            int filas;
            try
            {
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                comando.Parameters.AddWithValue("@cod_participante", objInscripcion.CodParticipante);
                comando.Parameters.AddWithValue("@cod_evento", objInscripcion.CodEvento);
                comando.Parameters.AddWithValue("@fecha", objInscripcion.Fecha);
                comando.Parameters.AddWithValue("@nota", objInscripcion.Nota);
                filas = comando.ExecuteNonQuery();
                bd.Cerrar();
                if (filas > 0)
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return respuesta;
        }

        public bool Modificar(Inscripcion objInscripcion)
        {
            bool respuesta = false;
            String sql = "UPDATE inscripcion SET cod_participante=@cod_participante, cod_evento=@cod_evento, fecha=@fecha, nota=@nota WHERE codigo=@codigo";
            int filas;
            try
            {
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                comando.Parameters.AddWithValue("@cod_participante", objInscripcion.CodParticipante);
                comando.Parameters.AddWithValue("@cod_evento", objInscripcion.CodEvento);
                comando.Parameters.AddWithValue("@fecha", objInscripcion.Fecha);
                comando.Parameters.AddWithValue("@nota", objInscripcion.Nota);
                comando.Parameters.AddWithValue("@codigo", objInscripcion.Codigo);
                filas = comando.ExecuteNonQuery();
                bd.Cerrar();
                if (filas > 0)
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return respuesta;
        }

        public bool Eliminar(int codigo)
        {
            bool respuesta = false;
            String sql = "DELETE FROM inscripcion WHERE codigo=@codigo";
            int filas;
            try
            {
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                comando.Parameters.AddWithValue("@codigo", codigo);
                filas = comando.ExecuteNonQuery();
                bd.Cerrar();
                if (filas > 0)
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return respuesta;
        }

        public Inscripcion Obtener(int codigo)
        {
            Inscripcion objInscripcion = new Inscripcion();
            try
            {
                String sql = "SELECT * FROM inscripcion WHERE codigo=@codigo";
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                comando.Parameters.AddWithValue("@codigo", codigo);
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    objInscripcion.Codigo = Convert.ToInt32(datos["codigo"]);
                    objInscripcion.CodParticipante = datos["cod_participante"].ToString();
                    objInscripcion.CodEvento = datos["cod_evento"].ToString();
                    objInscripcion.Fecha = datos["fecha"].ToString();
                    objInscripcion.Nota = Convert.ToInt32(datos["nota"].ToString());
                }
                bd.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return objInscripcion;
        }

        public DataTable Listar()
        {
            String sql = "SELECT t1.codigo, concat(t2.nombres, ' ', t2.ap_paterno, ' ', t2.ap_materno) AS participante, t3.nombre AS evento, t1.fecha, t1.nota " +
                "FROM inscripcion t1 " +
                "INNER JOIN participantes t2 ON t1.cod_participante=t2.codigo " +
                "INNER JOIN eventos t3 ON t1.cod_evento=t3.codigo";
            DataTable tabla = new DataTable();
            try
            {
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                SqlDataReader datos = comando.ExecuteReader();
                tabla.Load(datos);
                datos.Close();
                bd.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Buscar(String criterio)
        {
            String sql = "SELECT t1.codigo, concat(t2.nombres, ' ', t2.ap_paterno, ' ', t2.ap_materno) AS participante, t3.nombre AS evento, t1.fecha, t1.nota " +
                "FROM inscripcion t1 " +
                "INNER JOIN participantes t2 ON t1.cod_participante=t2.codigo " +
                "INNER JOIN eventos t3 ON t1.cod_evento=t3.codigo " +
                "WHERE t1.codigo LIKE CONCAT('%',@criterio,'%') " +
                "OR t2.nombres LIKE CONCAT('%',@criterio,'%') " +
                "OR t2.ap_paterno LIKE CONCAT('%',@criterio,'%') " +
                "OR t2.ap_materno LIKE CONCAT('%',@criterio,'%') " +
                "OR t3.nombre LIKE CONCAT('%',@criterio,'%') " +
                "OR t1.fecha LIKE CONCAT('%',@criterio,'%')" +
                "OR t1.nota LIKE CONCAT('%',@criterio,'%') ";
            DataTable tabla = new DataTable();
            try
            {
                ConexionBaseDatos bd = new ConexionBaseDatos();
                SqlCommand comando = new SqlCommand(sql, bd.Conectar());
                comando.Parameters.Add("@criterio", SqlDbType.VarChar);
                comando.Parameters["@criterio"].Value = criterio;
                SqlDataReader datos = comando.ExecuteReader();
                tabla.Load(datos);
                datos.Close();
                bd.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error en la consulta: " + ex.Message);
            }
            return tabla;
        }
    }
}
