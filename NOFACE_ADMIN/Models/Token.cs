namespace NOFACE_ADMIN.Models
{
    public class Token
    {
        public Token(string data, string refreshToken)
        {
            this.data = data;
            RefreshToken = refreshToken;
        }

        public string data { get; set; }

        public string RefreshToken { get; set; }
    }
}