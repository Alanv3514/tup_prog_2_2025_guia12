using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2.Modelos
{
    [Serializable]
    public class Sistema
    {
        public int NroOrden { get; set; }

        private List<Camion> listaCamiones = new List<Camion>();
        private List<Auto> listaAuto = new List<Auto>();

        public Sistema()
        {
            NroOrden = 0;
        }

        public void RecibirCamion(Camion unCamion)
        {
            if (unCamion.NroRegistro != NroOrden)
            {
             foreach (Camion camion in listaCamiones)
                {
                    if (camion.NroRegistro == unCamion.NroRegistro)
                    {
                        throw new Exception("El camion ya fue recibido");
                    }
                }
                listaCamiones.Add(unCamion);
            }
                NroOrden = unCamion.NroRegistro;
        }

        public Auto DescargarCamion(int nroRegistroCamion)
        {
            Auto res = null;
            foreach (Camion camion in listaCamiones)
            {
                if(camion.NroRegistro == nroRegistroCamion)
                {
                    res = camion.RetirarVehiculo();
                    listaAuto.Add(res);
                    return res;
                }
            }
            return res;
        }

        public int GenerarCamion(DateTime fecha, int cantidad)
        {
            Camion nuevoCamion = new Camion(fecha, cantidad);
            NroOrden++;
            nuevoCamion.NroRegistro = NroOrden;
            listaCamiones.Add(nuevoCamion);
            return nuevoCamion.NroRegistro;
        }

        public void CargarCamion(int nroOrden, Auto unAuto)
        {
            foreach (Camion camion in listaCamiones)
            {
                if(camion.NroRegistro == nroOrden)
                {
                    camion.CargarVehiculo(unAuto);
                    listaAuto.Remove(unAuto);
                    return;
                }
            }
            throw new Exception("No se encontro el camion");
        }

        public void CerrarCamion(int nro)
        {
            Camion camion = null;

            foreach (Camion c in listaCamiones)
            {
                if (c.NroRegistro == NroOrden)
                {
                    camion = c;
                }
            }
            if (camion != null)
            {

                {
                    string path = camion.ToString() + ".csv";

                    MessageBox.Show(path);

                    FileStream fs = null;
                    StreamWriter sw = null;
                    try
                    {

                        fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        sw = new StreamWriter(fs);

                        sw.WriteLine("NroRegistro;Modelo");
                        foreach (string linea in camion.VerCarga())
                        {
                            sw.WriteLine(linea);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear el archivo CSV: {ex.Message}");
                    }
                    finally
                    {
                        if (sw != null) sw.Close();
                        if (fs != null) fs.Close();
                    }
                }
            }
        }
    }
}
