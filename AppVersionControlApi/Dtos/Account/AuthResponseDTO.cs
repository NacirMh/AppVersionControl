namespace AppVersionControlApi.Dtos.Account
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
