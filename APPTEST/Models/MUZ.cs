using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTEST.Models
{
    public class MUZ
    {
        [Key] public int MuzID { get; set; }

        [Required(ErrorMessage = "Podaj Nazwe")]
        [Column(TypeName = "nvarchar(50)")] public string MuzName { get; set; }
        [Column(TypeName = "nvarchar(250)")] public string? Opis { get; set; }

        [Required(ErrorMessage = "Wprowadź Link")]
        [Column(TypeName = "nvarchar(100)")] public string Link { get; set; }
    }
}
