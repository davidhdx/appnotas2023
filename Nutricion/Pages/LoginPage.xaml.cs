using Newtonsoft.Json;
using Nutricion.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Nutricion.Pages;
public partial class LoginPage : ContentPage
{	private readonly HttpClient client = new HttpClient();
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void btnRegister_Clicked(object sender, EventArgs e) 
	{
		string url = "https://notesappservice.azurewebsites.net/api/Accounts/register";
		User usuario = new User();
		usuario.UserName = txtUsername.Text;
		usuario.Password = txtPwd.Text;

		string jsonUser = JsonConvert.SerializeObject(usuario);
		StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
		var respuesta = await client.PostAsync(url, content);
		var tokenString = respuesta.Content.ReadAsStringAsync();
		var json = JsonConvert.DeserializeObject<UserToken>(tokenString.Result);
        

        if (respuesta.IsSuccessStatusCode)
		{
			await SecureStorage.SetAsync("token", json.Token);
		}
	
        await Navigation.PushAsync(new NotesPage());
    }
}