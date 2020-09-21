namespace MBP.Services.Notes.BLL
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            ServiceResponseType = ServiceResponseType.Success;
        }

        public ServiceResponseType ServiceResponseType { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}