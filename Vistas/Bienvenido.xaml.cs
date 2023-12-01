using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Threading;
using ClasesBase;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for Bienvenido.xaml
    /// </summary>
    public partial class Bienvenido : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Usuario usu = new Usuario();
        string role;

        public Bienvenido(string rol)
        {
            //usu = usuarioLogeado;
            role = rol;
            timer.Tick += new EventHandler(WaitingEvent);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
            InitializeComponent();
            lblWelcomee.Content = lblWelcomee.Content.ToString().Replace("@usuariolog", role);
            ReproducirSonido("Audio/bienvenido.mp3");
        }

        public void WaitingEvent(object source, EventArgs e)
        {
            Main oMenuPrincipal = new Main(role);
            oMenuPrincipal.Show();
            timer.Stop();
            this.Close();
        }


        /// <summary>
        /// METODO QUE AÑADE SONIDOS A CIERTOS BOTONES
        /// </summary>
        /// <param name="path"></param>
        private void ReproducirSonido(string path)
        {
            Uri uriSonido;
            if (Uri.TryCreate(path, UriKind.Relative, out uriSonido))
            {
                mediaElement.Source = uriSonido;
                mediaElement.Play();
            }

        }

    }
}
