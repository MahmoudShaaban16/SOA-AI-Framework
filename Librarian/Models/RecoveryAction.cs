﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Models
{
    public class RecoveryAction
    {
        public string? ActionId { get; set; }
        public string? FailureId { get; set; }
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Success { get; set; }
    }
}