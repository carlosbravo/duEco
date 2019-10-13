using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using RestSharp; --TODO
using Newtonsoft.Json;

using Xamarin.Forms;

namespace duEco
{
    public class Index : ContentPage
    {
        public Index()
        {
            var title = new Label
            {
                Text = "Bienvenido a duEco",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var aboutButton = new Button
            {
                Text = "Sobre nosotros"
            };

            var signupButton = new Button
            {
                Text = "Registro"
            };

            // Here we are implementing a click event using lambda expressions
            // when a user clicks the `aboutButton` they will navigate to the
            // About Us page.
            aboutButton.Clicked += (object sender, EventArgs e) => {
                Navigation.PushAsync(new SobreNosotros());
            };

            // Navigation to the Signup Page (Note: We haven't created this page yet)
            signupButton.Clicked += (object sender, EventArgs e) => {
                Navigation.PushAsync(new Registro());
            };

            Model.UsuarioModel userTest = new Model.UsuarioModel
            {
                nombre = "John Doe", email="john.d@mail.com", password="1234"
            };

            var email = new Entry
            {
                Text = userTest.email,
                Placeholder = "E-Mail",
            };

            var password = new Entry
            {
                Text = userTest.password,
                Placeholder = "Contraseña",
                IsPassword = true
            };

            var login = new Button
            {
                Text = "Login"
            };

            login.Clicked += OnButtonClicked;

            // With the `PushModalAsync` method we navigate the user
            // the the orders page and do not give them an option to
            // navigate back to the Homepage by clicking the back button

            //login.Clicked += (sender, e) => {
            //    Navigation.PushModalAsync(new OrdersPage());
            //};

            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = { title, email, password, login, signupButton, aboutButton }
            };
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Home());
        }
    }
}