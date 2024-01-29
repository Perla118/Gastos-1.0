using Gastos.Datos;
using Gastos.Modelo;
using Gastos.Vista;
using Gastos.VistaModelo.VMthg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gastos.VistaModelo
{
    public class VMlista : BaseViewModel
    {
        #region VARIABLES
        ObservableCollection<Mgastos> _Listagastos;
        #endregion
        #region CONSTRUCTOR
        public VMlista(INavigation navigation)
        {
            Navigation = navigation;
            MostrarGastos();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<Mgastos> Listagastos
        {
            get { return _Listagastos; }
            set
            {
                SetValue(ref _Listagastos, value);
                OnPropertyChanged(nameof(Listagastos));
            }
        }
        #endregion
        #region PROCESOS
        public async Task MostrarGastos()
        {
            var function = new Dregistro();
            var registros = await Task.Run(() => function.MostrarRegistros());

            //var registros = await function.MostrarRegistros();

            // Punto de control: Verificar si los datos se están recuperando correctamente
            Console.WriteLine($"Número de registros: {registros.Count}");

            Listagastos = new ObservableCollection<Mgastos>(registros);
            OnPropertyChanged(nameof(Listagastos));
        }
        public async Task Regresar()
        {
            await Navigation.PushAsync(new MainPage());
        }
        #endregion
        #region COMANDOS
        public ICommand Regresarcommand => new Command(async () => await Regresar());
        #endregion
    }
}