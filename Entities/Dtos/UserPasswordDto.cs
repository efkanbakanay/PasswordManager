using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserPasswordDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string RecordDefinition { get; set; }
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
