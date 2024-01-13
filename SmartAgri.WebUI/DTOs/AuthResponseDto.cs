﻿namespace SmartAgri.WebUI.DTOs
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public int RoleId { get; set; }
    }
}
