using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
using ReceitasWebApi.Infrastructure;
using ReceitasWebApi.Services;
using Xunit;

namespace ReceitasWebApiTests.Domain.Services
{
    public class ReceitaServiceTests
    {
        IReceitaService _service;
        Context _context;

        public ReceitaServiceTests()
        {
            var option = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new Context(option);
            _service = new ReceitaService(_context);
        }

        [Fact]
        public void Insert_DeveSalvarUmaReceita()
        {
            var novaReceita = new Receita("Feijoada");
                
            _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(1);

            var receitaDoBanco = _context.Receitas.FirstOrDefault();
            receitaDoBanco.Titulo.Should().Be(novaReceita.Titulo);
        }
        [Fact]
        public void Insert_TitudoDeveSerObrigatorio()
        {
            var novaReceita = new Receita("");
            
            Func<Task> acao = () => _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(0);

            acao.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("O título é vazio ou nulo");
        }

         [Fact]
        public void Insert_TituloDeveConter60Strings()
        {
            var novaReceita = new Receita("abcsdefrgthyjukthygtfredfrgthygtftdgrjhfyrhfjgyrhftgrhtyfjgyhthfhdfhhfghfgjhufgfghgf");
            
            
            Func<Task> acao = () => _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(0);

            acao.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("O título contém mais de 60 Strings");
        }
        [Fact]
        public async Task GetAll_DeveRetornarTodasAsReceitasAsync()
        {
            var feijoada = new Receita("Feijoada")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredients",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            var burguer = new Receita("burguer")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredients",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            _context.Receitas.AddRange(feijoada,burguer);
            _context.SaveChanges();

            var retorno = await _service.GetAll();
            retorno.Should().HaveCount(2);
            var feijoadaDoRetorno = retorno.FirstOrDefault(receita => receita.Title == feijoada.Titulo);
            
            feijoadaDoRetorno.Should().NotBeNull();
            feijoadaDoRetorno.ImageUrl.Should().Be(feijoada.ImagemUrl);
            feijoadaDoRetorno.Ingredients.Should().Be(feijoada.Ingredientes);
            feijoadaDoRetorno.Description.Should().Be(feijoada.Descricao);
            feijoadaDoRetorno.Preparation.Should().Be(feijoada.MetodoDePreparo);

        }

          [Fact]
        public async Task GetOne()
        {
            var feijoada = new Receita("Feijoada")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredients",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            var burguer = new Receita("burguer")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredients",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            _context.Receitas.AddRange(feijoada,burguer);
            _context.SaveChanges();

            var retorno = await _service.GetOne(feijoada.Id);

            
            
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(feijoada.Id);
            retorno.ImageUrl.Should().Be(feijoada.ImagemUrl);
            retorno.Ingredients.Should().Be(feijoada.Ingredientes);
            retorno.Preparation.Should().Be(feijoada.MetodoDePreparo);
            retorno.Description.Should().Be(feijoada.Descricao);




        }
    }
}