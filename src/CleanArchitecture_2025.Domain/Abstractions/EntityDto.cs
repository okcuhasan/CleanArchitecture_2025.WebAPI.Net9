﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Domain.Abstractions
{
    public abstract class EntityDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
    }
}
