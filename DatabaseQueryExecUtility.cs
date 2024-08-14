using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

namespace Honeywell.Tools.DBUtility
{
    public class DatabaseQueryExecUtility
    {
        public enum DatabaseOutputType
        {
            [Description("Returns a Dataset as the output")]
            Dataset,
            [Description("Returns a DataTable as the output")]
            DataTable,
            [Description("Returns a DataRow as the output")]
            DataRow,
            [Description("Retruns float value as the output e.g Max of (Id) ")]
            Single,            
            [Description("In this scenario the ExecuteNonQuery would be called.")]
            None
        };

        private readonly string _connectionString;
        private OleDbConnection _oledbConnection;

        public DatabaseQueryExecUtility(string dataBasePath)
        {
            _connectionString = DatabaseConnectionUtility.GetConnectionString(dataBasePath);
            _oledbConnection = new OleDbConnection(_connectionString);
        }

        public object ReadDataFromDb(string queryString, DatabaseOutputType outputDbType, OleDbParameter[] oleDbParameters)
        {
            dynamic result = null;

            switch (outputDbType)
            {
                case DatabaseOutputType.Dataset:

                    result = (DataSet)ReadDataset(queryString, new DataSet());
                    break;

                case DatabaseOutputType.DataTable:

                    result = ReadDataTable(queryString, oleDbParameters, new DataTable());
                    break;

                case DatabaseOutputType.Single:

                    result = ReadScalarAndNonQuery(queryString, outputDbType);
                    break;

                case DatabaseOutputType.None:

                    result = ReadScalarAndNonQuery(queryString, outputDbType);
                    break;

                case DatabaseOutputType.DataRow:
                    result = ReadDataRow(queryString, oleDbParameters, new DataTable());
                    break;
                
                default:
                    break;
            }
            return result;
        }

        private DataSet ReadDataset(string queryString, DataSet userData)
        {
            OleDbDataAdapter oleDbDataAdapter;
            using (var oleDbConnection = GetOleDatabaseAdapter(queryString, out oleDbDataAdapter))
            {
                try
                {
                    oleDbDataAdapter.Fill(userData);
                }
                catch (OleDbException)
                {
                    throw new Exception("Server doesn't exist/Acess is denied");
                }
                finally
                {
                    oleDbConnection.Close();
                }
                return userData;
            }
        }

        private OleDbConnection GetOleDatabaseAdapter(string queryString, out OleDbDataAdapter oleDbDataAdapter)
        {
            try
            {
                var oleDbConnection = OpenConnection(new OleDbConnection(_connectionString));
                oleDbDataAdapter = new OleDbDataAdapter
                {
                    SelectCommand = new OleDbCommand
                    {
                        Connection = oleDbConnection,
                        CommandType = CommandType.Text,
                        CommandText = queryString
                    }
                };
                return oleDbConnection;
            }
            catch (Exception)
            {
                throw new Exception("Server doesn't exist/Acess is denied");
            }            
        }

        private OleDbConnection GetOleDatabaseAdapter(string queryString, OleDbCommand oleDbCommand, out OleDbDataAdapter oleDbDataAdapter)
        {
            try
            {
                var oleDbConnection = OpenConnection(new OleDbConnection(_connectionString));

                oleDbCommand.Connection = oleDbConnection;
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = queryString;    

                oleDbDataAdapter = new OleDbDataAdapter
                {
                    SelectCommand = oleDbCommand
                };
                return oleDbConnection;
            }
            catch (Exception)
            {
                throw new Exception("Server doesn't exist/Acess is denied");
            }
        }

        private OleDbConnection OpenConnection(OleDbConnection oleDbConnection)
        {
            try
            {
                oleDbConnection.Open();
                return oleDbConnection;
            }
            catch (Exception)
            {
                throw new Exception("Unable to establish Database connecton.");
                throw;
            }            
        }

        private DataTable ReadDataTable(string queryString, OleDbParameter[] oleDbParameters, DataTable dataTable)
        {
            OleDbDataAdapter oleDbDataAdapter;
            using (OleDbConnection oleDbConnection = GetOleDatabaseAdapter(queryString, out oleDbDataAdapter))
            {

                if (oleDbParameters != null)
                {
                    oleDbDataAdapter.SelectCommand.Parameters.AddRange(oleDbParameters);
                }
                try
                {
                    oleDbDataAdapter.Fill(dataTable);
                }
                catch (OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    oleDbConnection.Close();
                }
                return dataTable;
            }
        }

        private object ReadScalarAndNonQuery(string queryString, DatabaseOutputType databaseOutputType)
        {
            object result = null;
            OleDbCommand oleDbCommand = new OleDbCommand {CommandTimeout = 60};
            OleDbConnection oleDbConnection;

            try
            {
                OleDbDataAdapter oleDbDataAdapter;
                oleDbConnection = GetOleDatabaseAdapter(queryString, oleDbCommand, out oleDbDataAdapter);
            }
            catch (OleDbException)
            {
                throw new Exception("Server doesn't exist/Acess is denied");
            }

            try
            {
                if (databaseOutputType.Equals(DatabaseOutputType.Single))
                {
                    result = oleDbCommand.ExecuteScalar();
                }
                else if (databaseOutputType.Equals(DatabaseOutputType.None))
                {
                    try
                    {
                        result = oleDbCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }                
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oleDbConnection.Close();                
            }
            return result;
        }

        private DataRow ReadDataRow(string queryString, OleDbParameter[] oleDbParameters, DataTable dataTable)
        {
            DataRow dataRow = null;
            OleDbDataAdapter oleDbDataAdapter;
            OleDbConnection oleDbConnection;
            using (oleDbConnection = GetOleDatabaseAdapter(queryString, out oleDbDataAdapter))
            {

                if (oleDbParameters != null)
                {
                    oleDbDataAdapter.SelectCommand.Parameters.AddRange(oleDbParameters);
                }
                try
                {
                    oleDbDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        dataRow = dataTable.Rows[0];
                    }
                }
                catch (OleDbException)
                {
                    throw new Exception("Server doesn't exist/Acess is denied");
                }
                finally
                {
                    oleDbConnection.Close();
                }
                return dataRow;
            }
        }
    }
}
