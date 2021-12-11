using System;
using System.Data;
using MySql.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Permissions;

namespace DatabaseBank
{
    public class SQLCommands
    {
        public static void Main()
        {
        }

        public void DeleteAccount(string name)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;

            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "delete from account where AccName=@name";
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@name", name);
                /*reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                }*/
                Console.WriteLine("Account deleted");
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool CheckBankAvailability(string name)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "SELECT count(*) FROM bank where BankName=@name";
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (Convert.ToInt32(reader.GetValue(0)) > 0);
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return false;
        }

        public bool CheckAccountAvailability(string Id)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "SELECT count(*) FROM account where AccId=@Id";
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (Convert.ToInt32(reader.GetValue(0)) > 0);
                }
            }
            catch (MySqlException err)
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
            return false;
        }

        public bool CheckNewAccountAvailability(string name)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "SELECT count(*) FROM account where AccName=@name";
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (Convert.ToInt32(reader.GetValue(0)) > 0);
                }
            }
            catch (MySqlException err)
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
            return false;
        }

        public void SelectBank()
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "SELECT BankName FROM bank";
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
            catch (MySqlException err)
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
        }

        public string SelectBankProperty(string name,string st)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext="";
                if (st == "Id")
                {
                    cmdtext = "SELECT Id FROM bank where BankName=@name";
                }
                else if(st== "IMPSSameBank")
                {
                    cmdtext = "SELECT IMPSSameBank FROM bank where BankName=@name";
                }
                else if(st == "IMPSotherBank")
                {
                    cmdtext = "SELECT IMPSOtherBank FROM bank where BankName=@name";
                }
                else if (st == "RTGS")
                {
                    cmdtext = "SELECT RTGS FROM bank where BankName=@name";
                }
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (MySqlException err)
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
            return " ";
        }

        public string SelectAccountProperty(string Id, string st)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");
                string cmdtext = "";
                if (st == "Id")
                {
                    cmdtext = "SELECT AccId FROM account where AccId=@Id";
                }
                else if (st == "Balance")
                {
                    cmdtext = "SELECT Balance FROM account where AccId=@Id";
                }
                else if (st == "CIF")
                {
                    cmdtext = "SELECT CIF FROM account where AccId=@Id";
                }
                else if (st == "Password")
                {
                    cmdtext = "SELECT Password FROM account where AccId=@Id";
                }
                
                MySqlCommand cmd = new MySqlCommand(cmdtext, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (MySqlException err)
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
            return " ";
        }

        public Tuple<string, decimal> SelectRevertTransaction(string Id)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");

                MySqlCommand cmd;

                string cmdtext = "SELECT DestinationId,Amount FROM transaction WHERE transid=@Id";
                cmd = new MySqlCommand(cmdtext, con);

                cmd.Parameters.AddWithValue("@Id", Id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return Tuple.Create(reader.GetString(0), Convert.ToDecimal(reader.GetString(1)));
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            decimal d = 0;
            return Tuple.Create(" ",d);
        }

        public void SelectTransactionHistory(string Id)
        {
            string str = @"Server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);
                con.Open();
                Console.WriteLine("Connected");

                MySqlCommand cmd;
                
                string  cmdtext = "SELECT * FROM transaction WHERE userid=@Id";
                    cmd = new MySqlCommand(cmdtext, con);

                    cmd.Parameters.AddWithValue("@Id", Id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0) + reader.GetString(1));
                    }
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }


        public void InsertAccount(string id, string name, decimal balance,string Password, string mobile,DateTime UpdatedOn,string gender,string CreatedBy,DateTime createdOn,string CIF)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into account(AccId,AccName,Balance,Password,Gender,Mobile,CreatedBy,CreatedOn,UpdatedOn,CIF) values" +
                        " (?AccId,?AccName,?Balance,?Password,?Gender,?Mobile,?CreatedBy,?CreatedOn,?UpdatedOn,?CIF);", conn))
                    {
                        cmd.Parameters.Add("?AccId", MySqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("?AccName", MySqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("?Balance", MySqlDbType.Decimal).Value = balance;
                        cmd.Parameters.Add("?Password", MySqlDbType.VarChar).Value = Password;
                        cmd.Parameters.Add("?Gender", MySqlDbType.VarChar).Value = gender;
                        cmd.Parameters.Add("?Mobile", MySqlDbType.VarChar).Value = mobile;
                        cmd.Parameters.Add("?CreatedBy", MySqlDbType.VarChar).Value = CreatedBy;
                        cmd.Parameters.Add("?CreatedOn", MySqlDbType.DateTime).Value = createdOn;
                        cmd.Parameters.Add("?UpdatedOn", MySqlDbType.DateTime).Value = UpdatedOn;
                        
                        cmd.Parameters.Add("?CIF", MySqlDbType.VarChar).Value = CIF;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed");
        }

        public void InsertTransaction(string transid,string id,string BankId, decimal balance, DateTime UpdateOn, decimal amount, string destinationId, string destinationBankId)
        {

            //string connStr = "server=localhost;user=root;database=bankapp;port=3306;password=srujana";
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";


            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into transaction(transactionId,bankid,userid,Amount,UpdatedOn,Balance,DestinationId,DestinationBankId) values (?transactionId,?bankid,?userid,?Amount,?UpdatedOn,?Balance,?DestinationId,?DestinationBankId);", conn))
                    {
                        cmd.Parameters.Add("?transactionId", MySqlDbType.VarChar).Value = transid;
                        cmd.Parameters.Add("?bankid", MySqlDbType.VarChar).Value = BankId;
                        cmd.Parameters.Add("?userid", MySqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("?Balance", MySqlDbType.Decimal).Value = balance;
                        cmd.Parameters.Add("?Amount", MySqlDbType.Decimal).Value = amount;
                        cmd.Parameters.Add("?UpdatedOn", MySqlDbType.DateTime).Value = UpdateOn;
                        cmd.Parameters.Add("?DestinationId", MySqlDbType.VarChar).Value = destinationId;
                        cmd.Parameters.Add("?DestinationBankId", MySqlDbType.VarChar).Value = destinationBankId;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed.");
        }

        public void InsertBankStaff(string id, string name, string Password, string mobile)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into bankstaff(StaffId, StaffName, password, Mobile) values (?StaffId, ?StaffName, ?password, ?Mobile);", conn))
                    {
                        cmd.Parameters.Add("?StaffName", MySqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("?StaffId", MySqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("?password", MySqlDbType.VarChar).Value = Password;
                        cmd.Parameters.Add("?Mobile", MySqlDbType.VarChar).Value = mobile;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed.");
        }
        public void InsertBank(string Id, string name, DateTime CreatedOn)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();


            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into bank (Id,BankName,CreatedOn) VALUES (?Id,?BankName,?CreatedOn);", conn))
                    {
                        cmd.Parameters.Add("?Id", MySqlDbType.VarChar).Value = Id;
                        cmd.Parameters.Add("?BankName", MySqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("?CreatedOn", MySqlDbType.DateTime).Value = CreatedOn;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed.");
        }

        public void UpdateAccountParameters(string AccountId, string parameter, string st)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    string cmdtext = "";
                    if (st == "Password")
                    {
                        cmdtext = "UPDATE account SET Password=?Password WHERE AccId=@AccountId";
                        using (MySqlCommand cmd = new MySqlCommand(cmdtext, conn))
                        {
                            cmd.Parameters.Add("?Password", MySqlDbType.VarChar).Value = parameter;
                            cmd.Parameters.AddWithValue("@AccountId", AccountId);
                            Console.WriteLine("Connecting to MySQL...");
                            conn.Open();
                        }
                    }
                    else if (st == "Mobile")
                    {
                        cmdtext = "UPDATE account SET Mobile=?Mobile WHERE AccId=@AccountId";
                        using (MySqlCommand cmd = new MySqlCommand(cmdtext, conn))
                        {
                            cmd.Parameters.Add("?Mobile", MySqlDbType.VarChar).Value = parameter;
                            cmd.Parameters.AddWithValue("@AccountId", AccountId);
                            Console.WriteLine("Connecting to MySQL...");
                            conn.Open();
                        }
                    }
                    else if (st == "Gender")
                    {
                        cmdtext = "UPDATE account SET Gender=?Gender WHERE AccId=@AccountId";
                        using (MySqlCommand cmd = new MySqlCommand(cmdtext, conn))
                        {
                            cmd.Parameters.Add("?Gender", MySqlDbType.VarChar).Value = parameter;
                            cmd.Parameters.AddWithValue("@AccountId", AccountId);
                            Console.WriteLine("Connecting to MySQL...");
                            conn.Open();
                        }
                    }
                    
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed. ");
        }

        public void UpdateAccount(string AccountId, decimal amount, DateTime UpdateOn)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE account SET Balance=Balance+?Balance,UpdatedOn=?UpdatedOn WHERE AccId=@AccountId", conn))
                    {
                        cmd.Parameters.Add("?Balance", MySqlDbType.Decimal).Value = amount;
                        cmd.Parameters.Add("?UpdatedOn", MySqlDbType.DateTime).Value = UpdateOn;
                        cmd.Parameters.AddWithValue("@AccountId", AccountId);
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed. ");
        }

        public void UpdateTransaction(string name)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into bank (Id,BankName,AccId,StaffId) VALUES ('mik29112021',?BankName,'qwr29112021','zxx29112021');", conn))
                    {
                        cmd.Parameters.Add("?BankName", MySqlDbType.VarChar).Value = name;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed. ");
        }

        public void UpdateBankStaff(string name)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into bank (Id,BankName,AccId,StaffId) VALUES ('mik29112021',?BankName,'qwr29112021','zxx29112021');", conn))
                    {
                        cmd.Parameters.Add("?BankName", MySqlDbType.VarChar).Value = name;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed.");
        }
        public void UpdateBank(string name)
        {
            string connStr = @"server = localhost; user id = root; database = bankapp; allowuservariables = True; password=srujana";

            MySqlConnection conn1 = new MySqlConnection(connStr);
            conn1.Open();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into bank (Id,BankName,AccId,StaffId) VALUES ('mik29112021',?BankName,'qwr29112021','zxx29112021');", conn))
                    {
                        cmd.Parameters.Add("?BankName", MySqlDbType.VarChar).Value = name;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                        }
                        rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                conn.Close();
            }
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.Read();
        }

    }
}
