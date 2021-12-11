using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Databases
{
    class ClassFile1
    {
        static void Main(string[] args)
        {
            string str = "Server=localhost;Database=student;Uid=root;Password=srujana";
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand command = conn.CreateCommand();
            command.

        }
    }
}






/*using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Databases
{
    class ClassFile1
    {
        public static void Main(string[] args)
        {
            string str = @"server=localhost; database=student; userid=root; password=srujana;";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "SELECT * FROM details";
                MySqlCommand cmd = new MySqlCommand(cmdtext,con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
            catch(MySqlException err)
            {
                Console.WriteLine(err);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            Console.Read();
        }
        
    }
}
*/