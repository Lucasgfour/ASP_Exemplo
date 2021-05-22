using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ASP_Exemplo.Recursos;
using ASP_Exemplo.Controllers;
using ASP_Exemplo.Model;

namespace ASP_Exemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase {
        [HttpGet]
        public String MeuGET() {
            ObjectDao<Veiculo> oDao = new ObjectDao<Veiculo>();
            return JsonConvert.SerializeObject(oDao.listar());
        }

        [HttpGet("{codigo}")]
        public String GetById([FromRoute] int codigo) {
            ObjectDao<Veiculo> oDao = new ObjectDao<Veiculo>();
            return JsonConvert.SerializeObject(oDao.consultar(codigo));
        }
    }
}
