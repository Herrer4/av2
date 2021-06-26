using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazoniaVeiculos.Models;


namespace AmazoniaVeiculos.Factories
{
    public static class VeiculoFactory
    {
        public static VeiculoViewModel MapearVeiculoViewModel(Veiculo veiculo)
        {
            var veiculoViewModel = new VeiculoViewModel
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                KM = veiculo.Km,
                Ano = veiculo.Ano
            };

            return veiculoViewModel;
        }

        public static Veiculo MapearVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = new Veiculo(
                veiculoViewModel.Marca,
                veiculoViewModel.Modelo,
                veiculoViewModel.KM,
                veiculoViewModel.Ano
                );
            return veiculo;
        }

        public static IEnumerable<VeiculoViewModel> MapearListaVeiculoViewModel(IEnumerable<Veiculo> veiculos)
        {
            var lista = new List<VeiculoViewModel>();
            foreach (var item in veiculos)
            {
                lista.Add(MapearVeiculoViewModel(item));
            }

            return lista;
        }
    }
}
