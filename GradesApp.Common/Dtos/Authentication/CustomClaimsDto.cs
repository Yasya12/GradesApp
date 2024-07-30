using System.ComponentModel;

namespace GradesApp.Common.Dtos.Authentication;

public class CustomClaimsDto
{
    [DefaultValue(false)]
    public bool admin { get; set; }
}