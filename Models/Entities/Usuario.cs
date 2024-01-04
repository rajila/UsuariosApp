using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
	public class Usuario
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string FullName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        public int? Estado { get; set; }
    }
}