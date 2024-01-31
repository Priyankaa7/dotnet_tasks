using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstapi.Models;

public partial class UserTable
{
    [Required(ErrorMessage = "Mandatory field")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Mandatory field")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }
}
