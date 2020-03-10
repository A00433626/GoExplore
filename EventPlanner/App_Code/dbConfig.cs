using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.App_Code
{
    public class dbConfig
    {
        internal class SPArgBuild
        {
            internal string parameterName = "";
            internal string parameterValue = "";
            /// <summary>
            /// Write full data type, such as SqlDBType.VarChar.
            /// </summary>
            internal string pramValueType = "";
            internal string prameterDirection = "";
            /// <summary>
            /// Use to create SP Argument Build conestruction.
            /// </summary>
            /// <param name="pramName">SP Argument Parameter Name.</param>
            /// <param name="pramValue">SP Argument Parameter Value.</param>
            internal SPArgBuild(string pramName, string pramValue, string pramValueType, string PramDirection)
            {
                this.parameterName = pramName;
                this.parameterValue = pramValue;
                this.pramValueType = pramValueType;
                this.prameterDirection = PramDirection;
            }

        }

        public static DataTable RunStoredProcedure(DataTable dt, string spName, ArrayList spPramArrList)
        {
            string dbConnStr = ConfigurationManager.ConnectionStrings["GoExplore_DB"].ToString();
            SqlConnection conn = new SqlConnection(dbConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = spName;

            string spPramName = "";
            string spPramValue = "";
            string spPramDataType = "";
            string spParamDirection = "";
            for (int i = 0; i < spPramArrList.Count; i++)
            {
                spPramName = ((SPArgBuild)spPramArrList[i]).parameterName;
                spPramValue = ((SPArgBuild)spPramArrList[i]).parameterValue;
                spPramDataType = ((SPArgBuild)spPramArrList[i]).pramValueType;
                spParamDirection = ((SPArgBuild)spPramArrList[i]).prameterDirection;

                SqlParameter pram = null;
                #region SQL DB TYPE AND VALUE ASSIGNMENT
                switch (spPramDataType.ToUpper())
                {
                    case "BIGINT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.BigInt);
                        pram.Value = spPramValue;
                        break;

                    case "BINARY":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Binary);
                        pram.Value = spPramValue;
                        break;

                    case "BIT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Bit);
                        pram.Value = spPramValue;
                        break;

                    case "CHAR":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Char);
                        pram.Value = spPramValue;
                        break;

                    case "DATETIME":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.DateTime);
                        pram.Value = spPramValue;
                        break;

                    case "DECIMAL":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Decimal);
                        pram.Value = spPramValue;
                        break;

                    case "FLOAT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Float);
                        pram.Value = spPramValue;
                        break;

                    case "IMAGE":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Image);
                        pram.Value = spPramValue;
                        break;

                    case "INT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Int);
                        pram.Value = Convert.ToInt32(spPramValue);
                        break;

                    case "MONEY":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Money);
                        pram.Value = spPramValue;
                        break;

                    case "NCHAR":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.NChar);
                        pram.Value = spPramValue;
                        break;

                    case "NTEXT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.NText);
                        pram.Value = spPramValue;
                        break;

                    case "NVARCHAR":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.NVarChar);
                        pram.Value = spPramValue;
                        break;

                    case "REAL":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Real);
                        pram.Value = spPramValue;
                        break;

                    case "SMALLDATETIME":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.SmallDateTime);
                        pram.Value = spPramValue;
                        break;

                    case "SMALLINT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.SmallInt);
                        pram.Value = spPramValue;
                        break;

                    case "SMALLMONEY":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.SmallMoney);
                        pram.Value = spPramValue;
                        break;

                    case "TEXT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Text);
                        pram.Value = spPramValue;
                        break;

                    case "TIMESTAMP":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Timestamp);
                        pram.Value = spPramValue;
                        break;

                    case "TINYINT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.TinyInt);
                        pram.Value = spPramValue;
                        break;

                    case "UDT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Udt);
                        pram.Value = spPramValue;
                        break;

                    case "UMIQUEIDENTIFIER":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.UniqueIdentifier);
                        pram.Value = spPramValue;
                        break;

                    case "VARBINARY":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.VarBinary);
                        pram.Value = spPramValue;
                        break;

                    case "VARCHAR":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.VarChar);
                        pram.Value = spPramValue;
                        break;

                    case "VARIANT":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Variant);
                        pram.Value = spPramValue;
                        break;

                    case "XML":
                        pram = cmd.Parameters.Add(spPramName, SqlDbType.Xml);
                        pram.Value = spPramValue;
                        break;
                }
                #endregion
                #region SQL Parameter Direction
                switch (spParamDirection.ToUpper())
                {
                    case "I":
                        pram.Direction = ParameterDirection.Input;
                        break;
                    case "O":
                        pram.Direction = ParameterDirection.Output;
                        break;
                    case "IO":
                        pram.Direction = ParameterDirection.InputOutput;
                        break;
                    case "R":
                        pram.Direction = ParameterDirection.ReturnValue;
                        break;
                    default:
                        pram.Direction = ParameterDirection.Input;
                        break;
                }
                #endregion
            }

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            adap.Fill(dt);
            conn.Close();
            return dt;

        }
    }
}