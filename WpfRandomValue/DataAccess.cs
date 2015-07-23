using FirebirdSql.Data.FirebirdClient;
using MyStreamSpace;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRandomValue
{
    class DataAccess
    {
        private string connectionString;

        public ObservableCollection<Model> ModelCollection()
        {
            ObservableCollection<Model> observableCollection = new ObservableCollection<Model>();
            // ICollection<ValueModel> randomCollection = null;
            connectionString = GlobalSetting.CreateConectionString(
                 @"C:\Users\user\Documents\visual studio 2013\Projects\WpfRandomValue\WPFDatabase.fdb",
                 "SYSDBA", "masterkey", "WIN1250");
            using (FbConnection conn = new FbConnection(connectionString))
            {
                conn.Open();

                var command = new FbCommand();
                command.Connection = conn;
                command.CommandText = @"select * from NUMBERTABLE";

                using (var dataRead = command.ExecuteReader())
                {
                    while (dataRead.Read())
                    {
                        observableCollection.Add(new Model(int.Parse(dataRead.GetString(0)), int.Parse(dataRead.GetString(1))));
                    }
                }
            }
            return observableCollection;
        }

        public List<int> GenerateSecond(ObservableCollection<Model> observableCollection)
        {
            HashSet<int> hashSet = new HashSet<int>();

            observableCollection
                .Select(x => x.NUMBER)
                .ToList()
                .ForEach(x => hashSet.Add(x));


            ObservableCollection<int> list = new ObservableCollection<int>();
            using (BCRandomStream randomStream = new BCRandomStream(100))
            {
                //for (int i = 0; i < observableCollection.Count; i++)
                //{
                    var num = randomStream.Read();
                    if (hashSet.Contains(num))
                        hashSet.Add(num);

                    List<int> lista=  Enumerable.Range(0,observableCollection.Count)
                        .Select(i => randomStream.Read())
                        .Where(x => hashSet.Contains(x)).ToList();
            //    }
                

            return lista;
            }
            
}

        public object CleanTable()
        {
            connectionString = GlobalSetting.CreateConectionString(
                @"C:\Users\user\Documents\visual studio 2013\Projects\WpfRandomValue\WPFDatabase.fdb",
                "SYSDBA", "masterkey", "WIN1250");
            using (var conn = new FbConnection(connectionString))
            {
                conn.Open();

                    var command = new FbCommand();
                    command.Connection = conn;
                    command.CommandText = "DELETE FROM NUMBERTABLE";
                    //command.Parameters.Add();
                    return command.ExecuteScalar();
            }
        }

        public object Generate(int maxValue)
        {
            connectionString = GlobalSetting.CreateConectionString(
                @"C:\Users\user\Documents\visual studio 2013\Projects\WpfRandomValue\WPFDatabase.fdb",
                "SYSDBA", "masterkey", "WIN1250");
            using (var conn = new FbConnection(connectionString))
            {
                conn.Open();

                using (BCRandomStream randomStream = new BCRandomStream(maxValue))
                {
                    var command = new FbCommand();
                    command.Connection = conn;
                    command.CommandText = string.Format("INSERT INTO NUMBERTABLE(NUMBER) VALUES (@number)");//,     );
                    
                    FbParameter param = new FbParameter();
                    param.ParameterName = "@number";
                    param.Value = randomStream.Read();

                    command.Parameters.Add(param);
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
