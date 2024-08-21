using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }
}
