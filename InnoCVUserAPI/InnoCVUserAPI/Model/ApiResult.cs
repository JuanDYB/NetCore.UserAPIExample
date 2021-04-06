namespace InnoCVUserAPI.Model
{
    /// <summary>
    /// Custom Api result class to represent result with message and error core
    /// </summary>
    public class ApiResult
    {
        public ushort Code { get; set; }
        public string Message { get; set; }
    }
}
