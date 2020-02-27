using Microsoft.Extensions.Options;
using SPSX.CORE.FMEA.COMMON;
using SPSX.CORE.FMEA.ENTITY.Model.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPSX.CORE.FMEA.DA.FormsDA
{
    public class ControlMethodDA
    {
        public static string FMEADBConnectionstring;
        public static int SqlConnectionTimeout;

        private readonly IOptions<ConfigurationManager> _configurationService;

        public ControlMethodDA(IOptions<ConfigurationManager> configurationService)
        {
            _configurationService = configurationService;
            FMEADBConnectionstring = _configurationService.Value.FMEADBConnection;
            SqlConnectionTimeout = _configurationService.Value.SqlConnectionTimeout;
        }

        public IEnumerable<ControlMethod> GetAll()
        {
            //get
            {
                List<ControlMethod> prodCharacteristics = new List<ControlMethod>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(FMEADBConnectionstring))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandText = "FMEA_SP_GetAllProdCharacteristicsRecords";
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandTimeout = SqlConnectionTimeout;

                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                ControlMethod pdChar = new ControlMethod()
                                {
                                    PD_Characteristics_ID = reader.GetInt32(reader.GetOrdinal(FMEAConstants.PD_Characteristics_ID)),
                                    PD_Characteristics_Desc = reader.IsDBNull(reader.GetOrdinal(FMEAConstants.PD_Characteristics_Desc)) ? null : reader.GetString(reader.GetOrdinal(FMEAConstants.PD_Characteristics_Desc)),
                                };
                                prodCharacteristics.Add(pdChar);
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return prodCharacteristics;
            }
        }
    }
}
