using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://miniproy-82877-default-rtdb.firebaseio.com/");
    }
}
