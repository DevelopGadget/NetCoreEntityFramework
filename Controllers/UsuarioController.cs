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
  }
}
