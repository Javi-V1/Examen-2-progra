using Capa_Acceso_Datos.Txt;
using Capa_Logica.Ayudante;
using Capa_Modelo.Articulo;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Capa_Logica.Orquestador
{
    public class OrquestadorExamen
    {
        private Ayudante_JSON ayudante;
        private Lectura_Txt lectura;
        private Escritura_Txt escritura;
        public List<Articulo> articulos;

        public List<Articulo> articulo1;
        public List<Articulo> articulo2;
        public List<Articulo> articulo3;

        public OrquestadorExamen()
        {
            ayudante = new Ayudante_JSON();
            lectura = new Lectura_Txt();
            escritura = new Escritura_Txt();
            articulos = new List<Articulo>();

            articulo1 = new List<Articulo>();
            articulo2 = new List<Articulo>();
            articulo3 = new List<Articulo>();
        }

        public List<Articulo> ObtenerListaArticulos()
        {
            string contenido1 = lectura.Lee_Archivo("../Articulos1.txt");
            string contenido2 = lectura.Lee_Archivo("../Articulos2.txt");
            string contenido3 = lectura.Lee_Archivo("../Articulos3.txt");
            
            articulo1 = ayudante.Deserialize_Modelo<List<Articulo>>(contenido1);
            articulo2 = ayudante.Deserialize_Modelo<List<Articulo>>(contenido2);
            articulo3 = ayudante.Deserialize_Modelo<List<Articulo>>(contenido3);

            articulos.AddRange(articulo1);
            articulos.AddRange(articulo2);
            articulos.AddRange(articulo3);

            return articulos;
        }
        public bool AgregarListaArticulos(List<Articulo> _articulos)
        {
            try
            {
                string jsonArticulos = ayudante.Serialice_Modelo(_articulos);
                escritura.Escriba_En_TxT(jsonArticulos, "../", "Articulos4.txt");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarArticulos2(int cantidad)
        {
            try
            {
                if (cantidad < 0)
                {
                    return false;
                }

                string contenido = lectura.Lee_Archivo("../Articulos2.txt");
                List<Articulo> _articulos = ayudante.Deserialize_Modelo<List<Articulo>>(contenido);

                foreach (Articulo articulo in _articulos)
                {
                    articulo.Cantidad = cantidad;
                }

                string jsonArticulos = ayudante.Serialice_Modelo(_articulos);
                escritura.Escriba_En_TxT(jsonArticulos, "../", "Articulos2.txt");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
        public bool EliminarArticulos()
        {
            try
            {
                string contenido1 = lectura.Lee_Archivo("../Articulos1.txt");
                List<Articulo> _articulos1 = ayudante.Deserialize_Modelo<List<Articulo>>(contenido1);
                string contenido2 = lectura.Lee_Archivo("../Articulos3.txt");
                List<Articulo> _articulos3 = ayudante.Deserialize_Modelo<List<Articulo>>(contenido2);


                List<Articulo> articulosNoEliminados1 = new List<Articulo>();
                List<Articulo> articulosNoEliminados3 = new List<Articulo>();

                foreach (Articulo articulo in _articulos1)
                {
                    if(articulo.IdArticulo >= 15)
                    {
                        articulosNoEliminados1.Add(articulo);
                    }
                }
                foreach (Articulo articulo in _articulos3)
                {
                    if (articulo.IdArticulo >= 15)
                    {
                        articulosNoEliminados3.Add(articulo);   
                    }
                }

                string jsonArticulos = ayudante.Serialice_Modelo(articulosNoEliminados1);
                escritura.Escriba_En_TxT(jsonArticulos, "../", "Articulos1.txt");

                jsonArticulos = ayudante.Serialice_Modelo(articulosNoEliminados3);
                escritura.Escriba_En_TxT(jsonArticulos, "../", "Articulos3.txt");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
