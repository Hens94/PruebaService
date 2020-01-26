namespace System
{
    public interface IException
    {
        int StatusCode { get; set; }
        string DetailMessage { get; set; }
    }
}
