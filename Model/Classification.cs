using SQLite;

namespace Organizador_Apollo.Model
{
#nullable enable
    [Table("classification")]
    public class Classification
    {
        [PrimaryKey]
        [NotNull]
        public string? Name {  get; set; }
        public string? Description { get; set; }
    }
}
