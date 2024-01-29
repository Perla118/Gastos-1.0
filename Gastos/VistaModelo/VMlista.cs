using Gastos.Datos;
using Gastos.Modelo;
using Gastos.Vista;
using Gastos.VistaModelo.VMthg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gastos.VistaModelo
{
    public class VMlista : BaseViewModel
    {
        #region VARIABLES
        private double _presupuesto;
        private double _diferenciaPresupuesto;
        List<Mgastos> _Listagastos;
        //ObservableCollection<Mgastos> _Listagastos;
        #endregion
        #region CONSTRUCTOR
        public VMlista(INavigation navigation)
        {
            Navigation = navigation;
            MostrarRegistros();
        }
        #endregion
        #region OBJETOS
        public double DiferenciaPresupuesto
        {
            get { return _diferenciaPresupuesto; }
            set
            {
                if (_diferenciaPresupuesto != value)
                {
                    _diferenciaPresupuesto = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Presupuesto
        {
            get { return _presupuesto; }
            set
            {
                if (_presupuesto != value)
                {
                    _presupuesto = value;
                    OnPropertyChanged();
                    CalcularDiferenciaPresupuesto();
                }
            }
        }
        public List<Mgastos> Listagastos
        {
            get { return _Listagastos; }
            set
            {
                _Listagastos = value;
                OnpropertyChanged(nameof(Listagastos));
            }
        }
        //public ObservableCollection<Mgastos> Listagastos
        //{
        //    get { return _Listagastos; }
        //    set
        //    {
        //        SetValue(ref _Listagastos, value);
        //        OnPropertyChanged(nameof(Listagastos));
        //    }
        //}
        public async Task MostrarRegistros()
        {
            var function = new Dregistro();
            Listagastos = await function.MostrarRegistros();
        }
        #endregion
        #region PROCESOS
        private void CalcularDiferenciaPresupuesto()
        {
            double diferencia = Presupuesto - Listagastos.Sum(g => g.Monto);
            DiferenciaPresupuesto = diferencia;
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