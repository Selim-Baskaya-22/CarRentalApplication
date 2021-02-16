using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ModelYearBrandNameDto:IDto
    {
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
    }
}
