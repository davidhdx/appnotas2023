using Newtonsoft.Json;
using Nutricion.Models;
using System.Text;

namespace Nutricion.Pages;

public partial class NewNotePage : ContentPage
{
    private readonly HttpClient client = new HttpClient();
    public NewNotePage()
	{
		InitializeComponent();
        txtTitle.Text = "";
        txtText.Text = "";
        btnCreateNote.Text = "Create Note";
    }

    public NewNotePage(Note note)
    {
        InitializeComponent();
        txtTitle.Text = note.title;
        txtText.Text = note.text;
        btnCreateNote.Text = "Edit Note";
    }

    private void btnCreateNote_Clicked(object sender, EventArgs e)
    {   

		if (txtTitle.Text == null || txtText.Text == null)
        {
            DisplayAlert("Alert", "Fill the spaces", "Ok");
            return;
        }

        Note note = new Note
        {
            title = txtTitle.Text,
            text = txtText.Text,
            lastModified = DateTime.Now
        };

        registerAPI(note);
    }

    private async void registerAPI(Note note)
    {
        string url = "https://notesappservice.azurewebsites.net/api/Note/register";

        string jsonNote = JsonConvert.SerializeObject(note);
        StringContent content = new StringContent(
            jsonNote, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Saved", "Note saved successfully", "Ok");
        }
        else
        {
            App.IMCrepository.addRegisterNote(note);
        }
        await Navigation.PopAsync();
    }
    
    



}