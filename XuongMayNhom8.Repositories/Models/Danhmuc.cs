using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class Danhmuc
{
    public int Madm { get; set; }

    public string Tendm { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
