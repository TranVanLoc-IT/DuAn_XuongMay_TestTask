using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class Chuyen
{
    public int Machuyen { get; set; }

    public int? Socn { get; set; }

    public string? Nhiemvu { get; set; }

    public string? Vitri { get; set; }

    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();
}
