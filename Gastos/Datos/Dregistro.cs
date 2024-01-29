using Firebase.Database;
using Firebase.Database.Query;
using Gastos.Conexion;
using Gastos.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Datos
{
    public class Dregistro
    {
        public async Task InsertarGasto(Mgastos parametros)
        {
            await Cconexion.firebase
                .Child("Gastos")
                .PostAsync(new Mgastos()
                {
                    Concepto = parametros.Concepto,
                    Descripcion = parametros.Descripcion,
                    Monto = parametros.Monto,
                    //Fecha = parametros.Fecha,
                });
        }

        public async Task GuardarPresu(Mpresu parametros)
        {
            await Cconexion.firebase
                .Child("Presu")
                .PostAsync(new Mpresu()
                {
                    Presupuesto = parametros.Presupuesto,
                });
        }
        public async Task<ObservableCollection<Mgastos>> MostrarRegistros()
        {
            var data = await Task.Run(() => Cconexion.firebase
                 .Child("Gastos")
                 .AsObservable<Mgastos>()
                 .AsObservableCollection());
            return data;
        }
        //public async Task EliminarRegistro(string nroOrden)
        //{
        //    var deleteRegistro = (await Cconexion.firebase.Child("Gastos")
        //        .OnceAsync<Mgastos>()).Where(a => a.Object.NroOrden == nroOrden).FirstOrDefault();
        //    await Cconexion.firebase
        //        .Child("Gastos")
        //        .Child(deleteRegistro.Key)
        //        .DeleteAsync();
        //}
    }
}
