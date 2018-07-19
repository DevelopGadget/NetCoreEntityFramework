using System.ComponentModel.DataAnnotations;

namespace NetCoreSql.Models
{
  public class Usuario
  {
    [Required]
    public string Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string ImageUrl { get; set; }
    public int Edad { get; set; }

    public Usuario(string id, string nombre, string imageUrl, int edad)
    {
      this.Id = id;
      this.Nombre = nombre;
      this.ImageUrl = imageUrl;
      this.Edad = edad;
    }
  }
}