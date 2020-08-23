using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace layout1_devcrux
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MeusEventos = ObterEvento();
            this.BindingContext = this;
        }

        public ObservableCollection<Evento> MeusEventos { get; set; }

        public ObservableCollection<Evento> ObterEvento()
        {
            return new ObservableCollection<Evento>
            {
                new Evento { Titulo = "Xamarin Forms Masterclass", Imagem = "banner.png", Venue = "Register Online", Duracao = "07:30 UTC - 09:30 UTC", Data = new DateTime(2020, 6, 8), Descricao = "This masterclass was design to help you take your Xamarin Forms Development to the next level. Register here: https://bit.ly/2XbkoTG"},
                new Evento { Titulo = "Training: WDC Solution", Imagem = "onlinetraining.jpg", Venue = "Zoom Meeting", Duracao = "07:30 UTC - 09:30 UTC", Data = new DateTime(2020, 6, 9), Descricao = "Want to maximize your European vacation? Move through Europe with ease & discover how to travel around Europe by train with as little as possible."},
                new Evento { Titulo = "World Dogs Championship", Imagem = "dogs.jgp", Venue = "Virtual Challenge", Duracao = "07:30 UTC - 09:30 UTC", Data = new DateTime(2020, 6, 10), Descricao = "A dog earns a championship with wins at a specified number of conformation shows, where a judge evaluates a dog's breed type and how closely the dog approaches the ideal represented in its breed's standard."},
                new Evento { Titulo = "Book Review Conference", Imagem = "bookclub.jpg", Venue = "Online", Duracao = "07:30 UTC - 09:30 UTC", Data = new DateTime(2020, 6, 11), Descricao = "And whether you are a publishing insider or simply a book nerd, you should be able to find something to suit you in this list of events in 2020."},
                new Evento { Titulo = "Tea Ceremony", Imagem = "tea.jpg", Venue = "Virtual Meetup", Duracao = "07:30 UTC - 09:30 UTC", Data = new DateTime(2020, 6, 12), Descricao = "The tea ceremony sees the simple task of preparing a drink for a guest elevated to an art form, an intricate series of movements performed in strict order."}
            };
        }

        private async Task AbrirAnimacao(View v, uint length = 250)
        {
            v.RotationX = -90;
            v.IsVisible = true;
            v.Opacity = 0;
            _ = v.FadeTo(1, length);
            await v.RotateXTo(0, length);
        }

        private async Task FecharAnimacao(View v, uint length = 250)
        {
            _ = v.FadeTo(0, length);
            await v.RotateXTo(-90, length);
            v.IsVisible = false;
        }

        private async void Expandir(object s, EventArgs t)
        {
            var expander = s as Expander;
            var imgView = expander.FindByName<Grid>("ImagemView");
            var detalhesView = expander.FindByName<Grid>("DetalhesView");

            if(expander.IsExpanded){
                await AbrirAnimacao(imgView);
                await AbrirAnimacao(detalhesView);
            }
            else
            {
                await FecharAnimacao(imgView);
                await FecharAnimacao(detalhesView);
            }
        }
    }

    public class Evento
    {
        public string Titulo { get; set; }
        public string Venue { get; set; }
        public string Duracao { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public DateTime Data { get; set; }
    }
}
