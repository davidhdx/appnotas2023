using Nutricion.Pages;

namespace Nutricion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //ObtenerNombreSecure();
        }

        private async void btnDatos_Clicked(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            await SecureStorage.SetAsync("nombre", txtNombre.Text);
        }

        /*private async void ObtenerNombre()
        {
            var nombre = Preferences.Get("nombre", "no existe");
            if (nombre != "no existe")
            {
                //txtNombre.Text = nombre;
                //await Navigation.PushAsync(new DatosPage(nombre));
                Preferences.Remove("nombre");
            }
        }*/

        private async void ObtenerNombreSecure()
        {
            var nombre = await SecureStorage.GetAsync("nombre");

            if (nombre != null)
            {
                //txtNombre.Text = nombre;
                //await Navigation.PushAsync(new DatosPage(nombre));
                SecureStorage.Remove("nombre");
            }
        }
    }

    
}