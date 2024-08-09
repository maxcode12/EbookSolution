namespace Ebookapp.API.Dtos.Response;

public class Response
{
    public bool ISuccess { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
    public List<string> Errors { get; set; }



}
