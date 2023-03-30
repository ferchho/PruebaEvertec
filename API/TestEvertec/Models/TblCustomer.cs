using System;
using System.Collections.Generic;

namespace TestEvertec.Models;

public partial class TblCustomer
{
    public int IdCustomer { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? Birthdate { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public int? CivilStatus { get; set; }

    public bool? Brothers { get; set; }
}
