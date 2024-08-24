using Librarian.Models;

namespace Responder.Services
{

    public interface IResponderService
    {
        // Method to execute a recovery action in response to a service failure
        void ExecuteRecoveryAction(RecoveryAction action);

        // Method to log the outcome of a recovery action
        void LogActionResult(string actionId, bool success);
    }
    public class ResponderService : IResponderService
    {
        public void ExecuteRecoveryAction(RecoveryAction action)
        {
            throw new NotImplementedException();
        }

        public void LogActionResult(string actionId, bool success)
        {
            throw new NotImplementedException();
        }
    }
}
