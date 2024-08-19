using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XuongMayNhom8.Repositories.Models;

public partial class Donhang
{
    public int Madon { get; set; }

    public DateOnly? Ngaydat { get; set; }

    public int? Soluong { get; set; }

    public int? Masp { get; set; }

    [JsonIgnore] // remove it in swagger CUD method
    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();

    [JsonIgnore]
    public virtual Sanpham? MaspNavigation { get; set; }
}
