using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace car
{
    public partial class MainPage : ContentPage
    {
        CarouselView carouselView;
        public MainPage()
        {
            Title = "Temperament"; // заголовок страницы

            // создание списка темпераментов с их свойствами
            var temperaments = new List<Temperament>
            {
                new Temperament
                {
                    Name = "Koleeriline",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/07/male-3823124_1920-1536x1024.jpg",
                    MoreInfoUrl = "https://heypersonality.com/choleric/",
                    Description = "Koolerid on energilised, agressiivsed ja kirglikud."
                },
                new Temperament
                {
                    Name = "Melanhoolne",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Melancholy-man.jpg-1536x863.jpg",
                    MoreInfoUrl = "https://heypersonality.com/melancholy/",
                    Description = "Melanhoolikud on analüütilised, targad ja vaiksed."
                },
                new Temperament
                {
                    Name = "Sanguine",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Sanguine-temperament-1536x1022.jpg",
                    MoreInfoUrl = "https://heypersonality.com/sanguine/",
                    Description = "Sangviinid on sotsiaalsed, karismaatilised ja elurõõmsad."
                },
                new Temperament
                {
                    Name = "Flegmaatiline",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Phlegmatic-temperament-1536x1024.jpg",
                    MoreInfoUrl = "https://heypersonality.com/phlegmatic/",
                    Description = "Flegmaatikud on lõdvestunud, rahulikud ja vaiksed."
                }
            };

            // инициализация и настройка карусели
            carouselView = new CarouselView
            {
                ItemsSource = temperaments, // источник данных для карусели
                ItemTemplate = new DataTemplate(() =>
                {
                    // создание и настройка метки для названия
                    var nameLabel = new Label
                    {
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    // создание и настройка изображения
                    var imageView = new Image
                    {
                        HeightRequest = 200,
                        WidthRequest = 200,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    imageView.SetBinding(Image.SourceProperty, "ImageUrl");

                    // создание жеста нажатия для изображения
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        var temp = (Temperament)((Image)s).BindingContext;
                        DisplayAlert("Kirjeldus", temp.Description, "OK");
                    };
                    imageView.GestureRecognizers.Add(tapGestureRecognizer);

                    // создание и настройка метки для ссылки на дополнительную информацию
                    var moreInfoLabel = new Label { TextColor = Color.Blue, HorizontalOptions = LayoutOptions.Center };
                    moreInfoLabel.SetBinding(Label.TextProperty, "MoreInfoUrl");

                    // создание вертикального стека и добавление в него элементов
                    return new StackLayout
                    {
                        Children = { nameLabel, imageView, moreInfoLabel },
                        Spacing = 10
                    };
                })
            };

            // установка карусели как содержимого страницы
            Content = carouselView;
        }
    }
}
