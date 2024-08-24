using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public interface IDataIngestion
    {
        void IngestData();
    }
    public class DataIngestion : IDataIngestion
    {
        public void IngestData()
        {
            // Logic to ingest data using Apache Kafka
        }
    }

}
