using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class Donhang
{
    public int Madon { get; set; }

    public DateOnly? Ngaydat { get; set; }

    public int? Soluong { get; set; }

    public int? Masp { get; set; }

    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();

    public virtual Sanpham? MaspNavigation { get; set; }
}
