using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Honeywell.Tools.GraphicsMatch.Library
{


    public interface IDatabaseManager
    {

        string ConnectionString
        {
            get;
            set;
        }
         
        object FetchDataFrom_DB(string pistr_Query, OutputDBDataType pieDBType,OleDbParameter[] piarrOledbParams);


        int ExecuteParameterizedNonQuery(string pistrQuery, OleDbParameter[] piarrOledbParams, CommandType pie_CmdType);

        object ExecuteParameterizedScalarQuery(string pistrQuery, OleDbParameter[] piarrOledbParams);

        bool UpdataDataTable(DataTable piDBObject, string pistr_Query);
         
        bool UpdateDataTo_DB(Object piDBObject, string pistr_Query);

        bool UpdateData(Object piDBObject, string pistr_Query);
         
        int InsertRecord(string pistr_Query, string pistr_ParameterName, object loobj_ParamData);

        DataTable GetSchema();

        bool OpenDatabase();

        object ExecuteReaderOrScalarOrNonQuery(string pistr_Query, OutputDBDataType pieOutputType);

        int ExecuteQuery(string pistr_Query);


        DataTable GetSchema(Guid pio_SchemaGuid, object[] pio_Restrictions);
         
        bool CheckDatabase(out string pistr_StatusMessage);


        bool CloseConnection();
         
        void BulkUpdateToDb(object piData, string piStrSelectQuery);
         
        DataSet FillDataSet(string pistrSelectQuery);

        void BulkUpdate(int i32PointID, Dictionary<string, string> pidtParams);

    }
}
