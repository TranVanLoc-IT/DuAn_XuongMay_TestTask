using System;
using System.Collections.Generic;

namespace XuongMayNhom8.Repositories.Models;

public partial class Sanpham
{
    public int Masp { get; set; }

    public int? Madm { get; set; }

    public string Tensp { get; set; } = null!;

    public decimal? GiaBan { get; set; }

    public string? Mota { get; set; }

    public int? SoLuongCon { get; set; }

    public string? XuatXu { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual Danhmuc? MadmNavigation { get; set; }
}
