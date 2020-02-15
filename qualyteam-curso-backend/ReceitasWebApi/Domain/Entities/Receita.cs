using System;

namespace ReceitasWebApi.Domain.Entities
{
    public class Receita : Entity
    {
        public string Titulo { get; private set; }
        public string ImagemUrl { get; set; }
        public string Ingredientes { get; set; }
        public string Descricao { get; set; }
        public string MetodoDePreparo { get; set; }

        protected Receita()
        {

        }

        public Receita(string titulo)
        {
            if(String.IsNullOrEmpty(titulo))
            {
                throw new Exception();
            }

            Titulo = titulo;
        }
    }
}