﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
