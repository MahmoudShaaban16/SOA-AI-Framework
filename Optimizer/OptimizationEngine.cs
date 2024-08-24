using Librarian.Models;

namespace Optimizer
{
    public interface IOptimizationEngine
    {
        void OptimizeModel();
    }
    public class OptimizationEngine : IOptimizationEngine
    {
        public void OptimizeModel()
        {
            // Logic to optimize the model using Optuna
        }
    }
    public class OptimizationResult
    {
        public string? ModelId { get; set; }
        public double PerformanceScore { get; set; }
        public DateTime OptimizedAt { get; set; }
    }
}
