using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FailurePrediction
{
    public interface IModelVersioning
    {
        void VersionModel();
    }
    public class ModelVersioning : IModelVersioning
    {
        public void VersionModel()
        {
            // Logic to handle model versioning using MLFlow
        }
    }
}
