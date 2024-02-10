using SQLite;

namespace Organizador_Apollo.Model
{
    [Table("material")]
    public class Material
    {
        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        [NotNull]
        public string? Name { get; set; }
        public  string? TypeMeasure { get; set; }
        [NotNull]
        public  string? Classification { get; set; }
        public double? Wide { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
    }
}
