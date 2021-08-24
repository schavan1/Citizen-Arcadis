namespace CitizenArcadis.Client.UI.Models.Response
{
    public class FunctionResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

        public string Information { get; set; }
    }
}
