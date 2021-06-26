using System;
using System.Collections.Generic;
using System.Text;
using AmazoniaVeiculos.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class Veiculo
{
	public Veiculo(string marca, string modelo, string km, string ano)
	{
		Marca = marca;
		Modelo = modelo;
		Km = km;
		Ano = ano;
	}
	
	public int Id { get; private set; }
	public string Marca { get; private set; }
	public string Modelo { get; private set; }
	public string Km { get; private set; }
	public string Ano { get; private set; }

	public IEnumerable<Conteudo> Conteudos { get; private set; }

	public void AtualizarVeiculo(string marca, string modelo, string km, string ano)
    {
		this.Marca = marca;
		this.Modelo = modelo;
		this.Km = km;
		this.Ano = ano;
	}
}

public class Conteudo
{
}