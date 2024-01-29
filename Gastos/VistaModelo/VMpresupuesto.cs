using Gastos.Datos;
using Gastos.Modelo;
using Gastos.Vista;
using Gastos.VistaModelo.VMthg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gastos.VistaModelo
{
    public class VMpresupuesto : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private bool _camposLlenos;
        double _presupuesto;

        #endregion
        #region CONSTRUCTOR
        public VMpresupuesto(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public double Presupuesto
        {
            get { return _presupuesto; }
            set
            {
                SetValue(ref _presupuesto, value);
                VerificarCamposLlenos();
            }
        }
        public bool CamposLlenos
        {
            get { return _camposLlenos; }
            set
            {
                if (_camposLlenos != value)
                {
                    _camposLlenos = value;
                    OnPropertyChanged(nameof(CamposLlenos));
                }
            }
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarPresu()
        {
            try
            {
                var function = new Dregistro();
                var parametros = new Mpresu();
                parametros.Presupuesto = Presupuesto;

                await function.GuardarPresu(parametros);
                await Regresar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar presupuesto: {ex.Message}");
            }
        }

        public async Task Regresar()
        {
            await Navigation.PushAsync(new MainPage());
        }
        public async Task Siguiente()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void VerificarCamposLlenos()
        {
            CamposLlenos = Presupuesto > 0;
        }
        #endregion
        #region COMANDOS
        public ICommand Regresarcommand => new Command(async () => await Regresar());
        public ICommand Presucommand => new Command(async () => await InsertarPresu());
        public ICommand SiguienteCommand => new Command(async () => await Siguiente());
        #endregion
    }
}