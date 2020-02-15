using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
using ReceitasWebApi.Domain.ViewModel;
using ReceitasWebApi.Infrastructure;

namespace ReceitasWebApi.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly Context _context;
        public ReceitaService(Context context)
        {
            _context = context;
        }

        public async Task<ReceitaViewModel[]> GetAll()
        {
            return await _context.Receitas.Select(receita=> new ReceitaViewModel(){
                Id = receita.Id, 
                Title = receita.Titulo,
                Description = receita.Descricao,
                Preparation = receita.MetodoDePreparo,
                Ingredients = receita.Ingredientes,
                ImageUrl = receita.ImagemUrl
            }).ToArrayAsync();
        }

        public async Task<ReceitaViewModel> GetOne(Guid id)
        {
            var receita = await _context.Receitas.FirstOrDefaultAsync(receita => receita.Id == id);
            return new ReceitaViewModel()
            {
                Id = receita.Id,
                Title = receita.Titulo,
                Description = receita.Descricao,
                Preparation = receita.MetodoDePreparo,
                Ingredients = receita.Ingredientes,
                ImageUrl = receita.ImagemUrl
            };
        }

        public async Task Insert(Receita receita)
        {
            if(String.IsNullOrEmpty(receita.Titulo))
            {
                throw new InvalidOperationException("O título é vazio ou nulo");
            }

            if(receita.Titulo.Length >= 60)
            {
                throw new InvalidOperationException("O título contém mais de 60 Strings");
            }
            _context.Receitas.Add(receita);
            
            await _context.SaveChangesAsync();
        }
    }
}