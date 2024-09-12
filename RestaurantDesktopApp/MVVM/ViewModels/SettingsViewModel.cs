using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantDesktopApp.MVVM.ViewModels
{
    public class SettingsViewModel
    {
        //Campos
        #region Campos

        private bool _isInitialized;

        private const string NameKey = "name";

        private const string TaxPercentageKey = "tax";

        #endregion


        //Constructor
        #region Constructor



        #endregion


        //Metodos
        #region Metodos
        public async ValueTask InitializeAsync()
        {
            if (_isInitialized) return;

            _isInitialized = true;

            var name = Preferences.Default.Get<string?>(NameKey, null);

            if (name is null)
            {
                do
                {
                    name = await Shell.Current.DisplayPromptAsync("Nombre", "Escribe tu nombre");
                }
                while (string.IsNullOrEmpty(name));      
                
                Preferences.Default.Set(NameKey, name);
            }

            WeakReferenceMessenger.Default.Send(NameChangedMessage.From(name));
        }

        public int GetTaxPercentage() => Preferences.Default.Get<int>(TaxPercentageKey, 0);

        public void SetTaxPercentage(int taxPercentage) => Preferences.Default.Set(TaxPercentageKey, taxPercentage);

        #endregion


        //Comandos
        #region Comandos



        #endregion


    }
}
