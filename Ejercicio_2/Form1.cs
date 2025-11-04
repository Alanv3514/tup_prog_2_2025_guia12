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
            btnRecibirCamion.Enabled = false;
        }

        private void btnCargarCamion_Click(object sender, EventArgs e)
        {
            try
            {
                Auto a = listBox1.SelectedItem as Auto;
                listBox1.Items.Remove(a);
                sys.CargarCamion(nroRegistro, a);
                listBox2.Items.Add(a);

                btnDescargar.Enabled = true;
                btnDescargarCamion.Enabled = true;
                if (listBox1.Items.Count == 0)
                {
                    btnCargarCamion.Enabled = false;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnDescargarCamion_Click(object sender, EventArgs e)
        {
            try
            {
                Auto a = sys.DescargarCamion(nroRegistro);
                listBox1.Items.Add(a);
                listBox2.Items.Remove(a);
                if(listBox2.Items.Count == 0)
                {
                    btnDescargar.Enabled = false;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
}

        private void btnCerrarCamion_Click(object sender, EventArgs e)
        {
            try
            {
                sys.CerrarCamion(nroRegistro);
                listBox2.Items.Clear();

                btnCargarCamion.Enabled = false;
                btnCerrarCamion.Enabled = false;
                btnDescargarCamion.Enabled = false;
                btnDescargar.Enabled = false;
                btnCrearCamion.Enabled = true;
                btnRecibirCamion.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnRecibirCamion_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.Filter = "(*.csv)|*.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string ruta = sfd.FileName;
                    string[] fDato = Path.GetFileNameWithoutExtension(ruta).Split('_');


                    // Suponiendo que la fecha está en cDato[1] y en formato "dd-MM-aaaa"
                    DateTime f = DateTime.ParseExact(fDato[1], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    int lineas = 0;


                    using (StreamReader sw = new StreamReader(ruta))
                    {
                        //agrego los autos del camion al listbox2
                        while (!sw.EndOfStream)
                        {
                            string linea = sw.ReadLine();
                            if (lineas > 0)
                            {

                                string[] datos = linea.Split(';');
                                MessageBox.Show($"linea {lineas}>"+linea);
                                int nroRegistroAuto = int.Parse(datos[0]);
                                string modelo = datos[1];
                                double precio = double.Parse(datos[2]);


                                Auto auto = new Auto(nroRegistroAuto, modelo, precio);
                                listBox2.Items.Add(auto);
                            }

                            lineas++;
                        }

                        Camion camion = new Camion(f, lineas);

                        foreach (Auto auto in listBox2.Items)
                        {
                            camion.CargarVehiculo(auto);
                        }

                        sys.RecibirCamion(camion);
                        nroRegistro = camion.NroRegistro;
                    }

                    btnDescargar.Enabled = true;
                    btnCargarCamion.Enabled = true;
                    btnDescargarCamion.Enabled = true;
                    btnCerrarCamion.Enabled = true;
                    MessageBox.Show("Camion recibido, cargado al sistema y al listbox2.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                //este metodo descarga todo el camion en la lista de autos de la consecionaria
                Auto a=null;
                do
                {
                    a = sys.DescargarCamion(nroRegistro);
                    if (a != null)
                    {
                        listBox1.Items.Add(a);
                        listBox2.Items.Remove(a);
                    }
                } while (a != null);
                btnDescargar.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void tbCapacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
