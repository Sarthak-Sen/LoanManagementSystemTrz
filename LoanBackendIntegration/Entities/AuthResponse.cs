namespace LoanBackendIntegration.Entities
{
    public class AuthResponse
    {
        public string? Email { get; set; }
        public string? Token { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int CreditScore { get; set; }

        public string Role { get; set; }

    }

}
