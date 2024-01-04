using System;
namespace Cliente.Models.Screens
{
	public class UsuarioScreen
	{
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}