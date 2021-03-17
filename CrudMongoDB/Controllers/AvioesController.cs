using CrudMongoDB.Config;
using CrudMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Controllers
{
    public class AvioesController : Controller
    {
        private readonly AviaoContexto _aviaoContexto;

        public AvioesController(IOptions<ConfigDB> opcoes)
        {
            _aviaoContexto = new AviaoContexto(opcoes);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _aviaoContexto.Avioes.Find(a => true).ToListAsync());
        }

        [HttpGet]
        public IActionResult NovoAviao()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoAviao(Aviao aviao)
        {
            aviao.AviaoId = Guid.NewGuid();
            await _aviaoContexto.Avioes.InsertOneAsync(aviao);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarAviao(Guid aviaoId)
        {
            Aviao aviao = await _aviaoContexto.Avioes.Find(a => a.AviaoId == aviaoId).FirstOrDefaultAsync();
            return View(aviao);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarAviao(Aviao aviao)
        {
            await _aviaoContexto.Avioes.ReplaceOneAsync(a => a.AviaoId == aviao.AviaoId, aviao);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirAviao(Guid aviaoId)
        {
            await _aviaoContexto.Avioes.DeleteOneAsync(a => a.AviaoId == aviaoId);
            return RedirectToAction(nameof(Index));
        }
    }
}
