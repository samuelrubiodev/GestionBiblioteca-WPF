using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.ConexionBD
{
    internal class ConexionBD
    {
        private static MySqlConnection conn = null;
        private static String SERVIDOR = "192.168.56.101";
        private static uint PUERTO = 3306;
        private static String BD = "biblioteca";
        private static String USUARIO = "samuel";
        private static String PASSWORD = "samuelrbr20";

        private static ConexionBD instance = null;
        /*1.	private: Este modificador de acceso indica que el campo padlock solo es accesible dentro de la clase conexionBasketBBDD.
         * 2.	static: Significa que padlock pertenece a la clase conexionBasketBBDD en sí misma, no a instancias individuales de la clase. Solo habrá una única instancia de padlock para toda la clase.
         * 3.	readonly: Este modificador asegura que el campo padlock solo puede ser asignado una vez, ya sea en su declaración o en el constructor de la clase. No puede ser modificado después de su inicialización.
         * 4.	object padlock: Declara una variable llamada padlock de tipo object. En este caso, object es la clase base de todos los tipos en C#.
         * 5.	= new object();: Inicializa padlock con una nueva instancia de object.
         * Propósito: El propósito de padlock es actuar como un cerrojo (lock) para asegurar que el acceso al bloque de código dentro de lock (padlock) esté sincronizado. Esto es crucial en el patrón Singleton para evitar que múltiples hilos creen múltiples instancias de la clase conexionBasketBBDD.*/
        private static readonly object padlock = new object();
        private MySqlConnectionStringBuilder builder;
        private MySqlConnection conexionBD;

        private ConexionBD()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVIDOR;
            builder.UserID = USUARIO;
            builder.Password = PASSWORD;
            builder.Database = BD;
            conexionBD = new MySqlConnection(builder.ConnectionString);
        }

        public static ConexionBD Instance
        {
            get
            {
                /*La línea lock (padlock) se utiliza para asegurar que el acceso al bloque de código dentro de las llaves {} esté sincronizado, es decir, 
                 * que solo un hilo pueda ejecutarlo a la vez. Esto es especialmente importante en el contexto de la creación de instancias singleton 
                 * para evitar que múltiples hilos creen múltiples instancias de la clase.
                 * En este caso, padlock es un objeto estático y readonly que se utiliza como un cerrojo para garantizar que solo un hilo pueda acceder 
                 * al bloque de código que sigue, asegurando así que solo se cree una única instancia de conexionBasketBBDD.*/
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConexionBD();
                    }
                    return instance;
                }
            }
        }

        public MySqlConnection getConection()
        {
            return conexionBD;
        }
    }
}
