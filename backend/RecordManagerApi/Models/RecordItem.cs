using System.ComponentModel.DataAnnotations.Schema;

namespace RecordManagerApi.Models;

public class RecordItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }
}