using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using duEco.Model;
//using RestSharp; --TODO
using Newtonsoft.Json;

using Xamarin.Forms;

namespace duEco
{
    public class Index : ContentPage
    {
        private Model.UsuarioModel usuarioLogin;
      
        public Index()
        {
            #region UsuarioDePrueba
            Model.UsuarioModel userTest = new Model.UsuarioModel
            {
                nombre = "John Doe",
                email = "john.d@mail.com",
                password = "1234"
            };
            #endregion

            StackLayout stackLayout = new StackLayout();
            stackLayout.Padding = 30;
            stackLayout.Spacing = 10;
             
            var title = new Label
            {
                Text = "Bienvenido a duEco",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stackLayout.Children.Add(title);

            var email = new Entry
            {
                Text = userTest.email,
                Placeholder = "E-Mail",
            };
            stackLayout.Children.Add(email);

            var password = new Entry
            {
                Text = userTest.password,
                Placeholder = "Contraseña",
                IsPassword = true
            };
            stackLayout.Children.Add(password);

            var login = new Button
            {
                Text = "Login"
            };
            login.Clicked += OnButtonClicked;
            stackLayout.Children.Add(login);

            var aboutButton = new Button
            {
                Text = "Sobre nosotros"
            };
            stackLayout.Children.Add(aboutButton);

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
            stackLayout.Children.Add(signupButton);

                  
            usuarioLogin = new Model.UsuarioModel
            {
                email = email.Text,
                password = password.Text
             };
                     

            var underlineLabel = new Label
            {
                Text = "Si no posee cuenta Registrese",
                TextDecorations = TextDecorations.Underline,
                TextColor = Color.DarkRed
            };
            stackLayout.Children.Add(underlineLabel);

            Content = stackLayout;
        }       

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (validarUsuario(usuarioLogin))
            {
                await Navigation.PushAsync(new View.Home());
            }
            else
            {
                await DisplayAlert("Error", "Email y/o password incorrectos", "OK");
            }
        }

        private bool validarUsuario(UsuarioModel usuarioLogin)
        {
            return Servicio.UsuarioServicio.UsuarioExiste(usuarioLogin);
        }
    }
}