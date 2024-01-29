using Gastos.Datos;
using Gastos.Modelo;
using Gastos.Vista;
using Gastos.VistaModelo.VMthg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gastos.VistaModelo
{
    public class VMregistro : BaseViewModel
    {
        #region VARIABLES
        private bool _camposLlenos;
        string _concepto;
        string _descripcion;
        double _monto;
        //DateTime _fechagasto;
        #endregion
        #region CONSTRUCTOR
        public VMregistro(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Concepto
        {
            get { return _concepto; }
            set { SetValue(ref _concepto, value);
                VerificarCamposLlenos();}
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value);
                VerificarCamposLlenos();}
        }
        public double Monto
        {
            get { return _monto; }
            set { SetValue(ref _monto, value);
                VerificarCamposLlenos();}
        }
        //public DateTime Fecha
        //{
        //    get { return _fechagasto; }
        //    set
        //    {
        //        SetValue(ref _fechagasto, value);
        //        VerificarCamposLlenos();
        //    }
        //}
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
        #endregion
        #region PROCESOS
        public async Task InsertarRegistro()
        {
            var function = new Dregistro();
            var parametros = new Mgastos();
            parametros.Concepto = Concepto;
            parametros.Descripcion = Descripcion;
            parametros.Monto = Monto;

            //parametros.Fecha = DateTime.Now;

            await function.InsertarGasto(parametros);
            await Regresar();
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
            CamposLlenos = !string.IsNullOrWhiteSpace(Concepto) &&
                           !string.IsNullOrWhiteSpace(Descripcion) &&
                           Monto > 0;
                           //Fecha != null; 
        }
        #endregion
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await InsertarRegistro());
        public ICommand Regresarcommand => new Command(async () => await Regresar());
        public ICommand SiguienteCommand => new Command(async ()=> await Siguiente());
        #endregion
    }
}