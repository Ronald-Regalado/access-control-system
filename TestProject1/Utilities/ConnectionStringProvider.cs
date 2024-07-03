using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Tests.Utilities
{/// <summary>
/// Proveedor de string de conexion
/// </summary>
    public static class ConnectionStringProvider
    {/// <summary>
     /// Obtiene string de conexion para las pruebas
     /// </summary>
     /// <returns></returns>
        public static string GetConnectionString() => "Data Source = Data.sqlite";
    }
}
