using pMoviles_ITM.Services;
using pMoviles_ITM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using pMoviles_ITM.Datos;
using System.IO;

namespace pMoviles_ITM
{
    public partial class App : Application
    {
        private clsBasesDatos _Basedatos;

        public clsBasesDatos BasesDatos
        {
            get
            {
                if(_Basedatos== null)
                {
                    _Basedatos = new clsBasesDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
                }
                return _Basedatos;
            }
            
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            BasesDatos.CrearTablas();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
