using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmazoniaVeiculos.Models;
using AmazoniaVeiculos.Factories;

namespace AmazoniaVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IncluirVeiculo _incluirVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;
        private readonly ConsultarVeiculo _consultarVeiculo;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _incluirVeiculo = new IncluirVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);
            _consultarVeiculo = new ConsultarVeiculo(veiculoRepository);

        }
        public async Task<IActionResult> Index()
        {
            var listaVeiculos = await _consultarVeiculo.ListarTodosVeiculos();
            var listaVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(listaVeiculos);

            return View(listaVeiculosViewModel);
        }
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(VeiculoViewModel VeiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = VeiculoFactory.MapearVeiculo(VeiculoViewModel);

                await _incluirVeiculo.Executar(veiculo);

                return RedirectToAction("Index");
            }

            return View(VeiculoViewModel);
        }

        public async Task<IActionResult> Alterar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPeloId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return View(veiculoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(veiculoViewModel);
            }

            var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

            await _alterarVeiculo.Executar(id, veiculo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPeloId(id);

            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }


            await _excluirVeiculo.Executar(veiculo);

            return RedirectToAction("Index");
        }
    }
}
