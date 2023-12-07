using Newtonsoft.Json;
using Nutricion;
using Nutricion.Models;
using System.Net.Http.Headers;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nutricion.Pages;

public partial class NotesPage : ContentPage
{
	private HttpClient client = new HttpClient();
    public List<Note> lista;
    public NotesPage()
	{
		InitializeComponent();
		getNotes();
	}

	public async void getNotes()
	{
		string url = "https://notesappservice.azurewebsites.net/api/Note/list";
		client.DefaultRequestHeaders.Authorization = 
			new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("token"));
		var respuesta = client.GetAsync(url);
        lista = App.IMCrepository.getAllNotes();

        if (respuesta.Result.IsSuccessStatusCode)
		{
            var json = await respuesta.Result.Content.ReadAsStringAsync();
            lista = JsonConvert.DeserializeObject<List<Note>>(json);
        }
        lstNotes.ItemsSource = lista;
        if (lista.Count == 0)
            await DisplayAlert("Empty", "No notes", "Ok");
    }

    private async void btnNewNote_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NewNotePage());
        getNotes();
    }
    private void btnRefresh_Clicked(object sender, EventArgs e)
    {
        getNotes();
    }

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        Note editingNote = ((Button)sender).BindingContext as Note;
        App.IMCrepository.deleteNote(editingNote);
        await Navigation.PushAsync(new NewNotePage(editingNote));
        getNotes();
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        Note deletingNote = ((Button)sender).BindingContext as Note;
        App.IMCrepository.deleteNote(deletingNote);
        getNotes();
    }
}