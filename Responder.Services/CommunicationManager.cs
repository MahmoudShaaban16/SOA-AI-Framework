namespace Responder.Services
{
    public interface ICommunicationManager
    {
        void SendCommunication();
    }
    public class CommunicationManager : ICommunicationManager
    {
        public void SendCommunication()
        {
            // Logic for sending communications using Celery
        }
    }
}
