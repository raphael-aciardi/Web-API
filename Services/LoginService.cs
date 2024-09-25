using Web_API.Models;

namespace Web_API.Services
{
    public class LoginService : ILoginService
    {
        private readonly List<Login> _users = new List<Login>
        {
            // Armazene a senha hash em vez da senha em texto simples
            new Login { Id = 1, Email = "admin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password123") }
        };

        // Implementação do método Authenticate
        public Login Authenticate(string email, string password)
        {
            // Localiza o usuário pelo email
            var user = _users.SingleOrDefault(x => x.Email == email);

            // Verifica se o usuário existe e se a senha fornecida é correta
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null; // Retorna null se a autenticação falhar

            return user; // Retorna o usuário se a autenticação for bem-sucedida
        }
    }
}
