﻿using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Application
{
    public class CreateApplicationDTO
    {
        [Required]
        public string Name { get; set; }

    }
}