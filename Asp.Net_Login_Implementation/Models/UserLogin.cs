﻿using System;
using System.Collections.Generic;

namespace Asp.Net_Login_Implementation.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
