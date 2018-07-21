using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreSql.Models;

namespace NetCoreSql.Controllers
{
  [Route("Users")]
  public class UsuarioController : Controller
  {
    private readonly DbContextApp Context;

    public UsuarioController(DbContextApp Cont) => Context = Cont;

    [HttpGet]
    public IActionResult Get() => Ok(Context.Usuarios.ToList());

    [HttpGet("{Id}")]
    public IActionResult Get(string Id)
    {
      var Item = Context.Usuarios.FirstOrDefault(item => item.Id == Id);
      if (Item == null) return NotFound();
      return Ok(Item);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Usuario Data)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      await Context.Usuarios.AddAsync(Data);
      await Context.SaveChangesAsync();
      return Ok("Creado");
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put([FromBody] Usuario Data, string Id){
      if(Data.Id != Id) return NotFound();
      Context.Entry(Data).State = EntityState.Modified;
      await Context.SaveChangesAsync();
      return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(string Id)
    {
      var Item = Context.Usuarios.FirstOrDefault(item => item.Id == Id);
      if (Item == null) return NotFound();
      Context.Usuarios.Remove(Item);
      await Context.SaveChangesAsync();
      return Ok("Eliminado");
    }
  }
}
