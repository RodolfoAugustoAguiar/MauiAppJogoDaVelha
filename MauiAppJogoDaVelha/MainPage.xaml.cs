namespace MauiAppJogoDaVelha;

public partial class MainPage : ContentPage
{
    string vez = "X";

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        btn.Text = vez;

        if (vez == "X")
            vez = "O";
        else
            vez = "X";

        await VerificarVitoria();
    }

    async Task VerificarVitoria()
    {
        if (Ganhou("X"))
        {
            await DisplayAlert("Parabéns!", "O jogador X ganhou!", "OK");
            Zerar();
            return;
        }

        if (Ganhou("O"))
        {
            await DisplayAlert("Parabéns!", "O jogador O ganhou!", "OK");
            Zerar();
            return;
        }

        if (Empatou())
        {
            await DisplayAlert("Empate", "Ninguém venceu a partida.", "OK");
            Zerar();
        }
    }

    bool Ganhou(string simbolo)
    {
        return

        // Linhas
        (btn10.Text == simbolo && btn11.Text == simbolo && btn12.Text == simbolo) ||
        (btn20.Text == simbolo && btn21.Text == simbolo && btn22.Text == simbolo) ||
        (btn30.Text == simbolo && btn31.Text == simbolo && btn32.Text == simbolo) ||

        // Colunas
        (btn10.Text == simbolo && btn20.Text == simbolo && btn30.Text == simbolo) ||
        (btn11.Text == simbolo && btn21.Text == simbolo && btn31.Text == simbolo) ||
        (btn12.Text == simbolo && btn22.Text == simbolo && btn32.Text == simbolo) ||

        // Diagonais
        (btn10.Text == simbolo && btn21.Text == simbolo && btn32.Text == simbolo) ||
        (btn12.Text == simbolo && btn21.Text == simbolo && btn30.Text == simbolo);
    }

    bool Empatou()
    {
        return
            !btn10.IsEnabled &&
            !btn11.IsEnabled &&
            !btn12.IsEnabled &&
            !btn20.IsEnabled &&
            !btn21.IsEnabled &&
            !btn22.IsEnabled &&
            !btn30.IsEnabled &&
            !btn31.IsEnabled &&
            !btn32.IsEnabled;
    }

    void Zerar()
    {
        btn10.Text = "";
        btn11.Text = "";
        btn12.Text = "";

        btn20.Text = "";
        btn21.Text = "";
        btn22.Text = "";

        btn30.Text = "";
        btn31.Text = "";
        btn32.Text = "";

        btn10.IsEnabled = true;
        btn11.IsEnabled = true;
        btn12.IsEnabled = true;

        btn20.IsEnabled = true;
        btn21.IsEnabled = true;
        btn22.IsEnabled = true;

        btn30.IsEnabled = true;
        btn31.IsEnabled = true;
        btn32.IsEnabled = true;

        vez = "X";
    }
}