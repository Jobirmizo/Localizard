﻿using System.ComponentModel.DataAnnotations;

namespace Localizard.Domain.ViewModel;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    public string Useranme { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}