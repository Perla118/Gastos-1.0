using Gastos.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gastos.VistaModelo.VMthg
{
    public class VMmenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        #endregion
        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new RegistrarGastos());
        }
        public async Task IrALista()
        {
            await Navigation.PushAsync(new Listaregistros());
        }
        public async Task IrAPresupuesto()
        {
            await Navigation.PushAsync(new Presupuesto());
        }
        public async Task IrAListaPresupuesto()
        {
            await Navigation.PushAsync(new ListaPresupuesto());
        }
        #endregion
        #region COMANDOS
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand Listacommand => new Command(async () => await IrALista());
        public ICommand Presupuestocommand => new Command(async () => await IrAPresupuesto());
        public ICommand ListaPresupuesto => new Command(async () => await IrAListaPresupuesto());

        #endregion
    }
}