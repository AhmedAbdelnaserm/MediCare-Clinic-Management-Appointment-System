using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MediCare.Common.Dto
{
    public class UpdateClinicRequestDto
{
    public string EnName { get; set; } = string.Empty;
    public string EnDescription { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public int AreaId { get; set; }
}
}