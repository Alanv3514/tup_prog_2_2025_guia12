using Ejercicio_2.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        private const string sysBinFile = "serial.bin";
        int nroRegistro = 0;
        public Sistema sys = new Sistema();
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (File.Exists(sysBinFile))
            {//Cargo la configuracion binaria
                try
                {
                    using (FileStream fs = new FileStream(sysBinFile, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        sys = (Sistema)formatter.Deserialize(fs);
                        nroRegistro = sys.NroOrden;

                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la configuración binaria: {ex.Message}. Usando valores por defecto.");
                }

            }

                //tengo la lista por default de autos en la consecionaria
                List<Auto> autosIniciales = new List<Auto>
                {
                    new Auto(1, "Modelo A", 15000),
                    new Auto(2, "Modelo B", 20000),
                    new Auto(3, "Modelo C", 25000),
                    new Auto(4, "Modelo D", 30000),
                    new Auto(5, "Modelo E", 35000)
                };
                //cargo los autos al listbox de autos en la consecionaria
                listBox1.Items.AddRange(autosIniciales.ToArray());
            

        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(sysBinFile, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs, sys);

                    MessageBox.Show("Configuración binaria guardada con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la configuración binaria: {ex.Message}");
            }
        }
        
        private void btnCrearCamion_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            int cantidad = Convert.ToInt32(tbCapacidad.Text);

            nroRegistro = sys.GenerarCamion(fecha, cantidad);

            MessageBox.Show($"Camión creado con Nro de Orden: {nroRegistro}");

            btnCargarCamion.Enabled = true;
            btnCrearCamion.Enabled = false;
            btnCerrarCamion.Enabled = true;
        }

        private void btnCargarCamion_Click(object sender, EventArgs e)
        {
            Auto a = listBox1.SelectedItem as Auto;
            listBox1.Items.Remove(a);
            sys.CargarCamion(nroRegistro, a);
            listBox2.Items.Add(a);

            btnDescargar.Enabled = true;
            if (listBox1.Items.Count == 0)
            {
                btnCargarCamion.Enabled = false;
            }
        }

        private void btnDescargarCamion_Click(object sender, EventArgs e)
        {
            Auto a = sys.DescargarCamion(nroRegistro);
            listBox1.Items.Add(a);
            listBox2.Items.Remove(a);
            if(listBox2.Items.Count == 0)
            {
                btnDescargar.Enabled = false;
            }
        }

        private void btnCerrarCamion_Click(object sender, EventArgs e)
        {
            sys.CerrarCamion(nroRegistro);
            listBox2.Items.Clear();

            btnCargarCamion.Enabled = false;
            btnCerrarCamion.Enabled = false;
            btnDescargarCamion.Enabled = false;
            btnDescargar.Enabled = false;
            btnCrearCamion.Enabled = true;
        }

        private void btnRecibirCamion_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd= new SaveFileDialog();
            sfd.Filter = "(*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ruta = sfd.FileName;
                DateTime f = DateTime.Parse(ruta.Split(';')[0]);
                int lineas = 0;

                using (StreamReader sw = new StreamReader(ruta))
                {
                    
                    string[] cDato = ruta.Split(';');//campo0 es el numero de registro, campo 1 es la fecha y la cantidad de lineas sera la capacidad
                    
                    //agrego los autos del camion al listbox2
                    while (!sw.EndOfStream)
                    {
                        lineas++;
                        string linea = sw.ReadLine();
                        string[] datos = linea.Split(';');
                        int nroRegistroAuto = int.Parse(datos[0]);
                        string modelo = datos[1];
                        double precio = double.Parse(datos[2]);
                        Auto auto = new Auto(nroRegistroAuto, modelo, precio);
                        listBox2.Items.Add(auto);
                    }
                    Camion camion = new Camion(f, lineas);
                    foreach (Auto auto in listBox2.Items)
                    {
                        camion.CargarVehiculo(auto);
                    }

                    sys.RecibirCamion(camion);
                }
                btnDescargar.Enabled = true;
                MessageBox.Show("Camion recibido, cargado al sistema y al listbox2.");
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            //este metodo descarga todo el camion en la lista de autos de la consecionaria
            Auto a;
            do
            {
                a = sys.DescargarCamion(nroRegistro);
                if(a!=null)
                {
                    listBox1.Items.Add(a);
                    listBox2.Items.Remove(a);
                }
            } while (a != null);
            btnDescargar.Enabled = false;

        }
    }
}
