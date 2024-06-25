namespace Response
{
    public class RequestResult
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public object? Result  { get; set; }
        public object? Token  { get; set; }

    }
}
