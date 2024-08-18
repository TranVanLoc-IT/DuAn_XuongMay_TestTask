using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class Congviec
{
    public int Macv { get; set; }

    public int? Machuyen { get; set; }

    public int? Madh { get; set; }

    public int? Soluong { get; set; }

    public string? Tencv { get; set; }

    public string? Thoigian { get; set; }

    public virtual Chuyen? MachuyenNavigation { get; set; }

    public virtual Donhang? MadhNavigation { get; set; }
}
