using System;
using System.Collections.Generic;
using Livros.Interfaces;

namespace Livros 
{
    public class LivroRepositorio : IRepositorio<Livro>
    {
        private List<Livro> listaLivro = new List<Livro>();
            public void Atualiza(int id, Livro objeto)
            {
                listaLivro[id] = objeto;
            }

            public void Exclui(int id)
            {
                listaLivro[id].Excluir();
            }

            public void Insere(Livro ojeto)
            {
                listaLivro.Add(ojeto);
            }

            public List<Livro> Lista()
            {
                return listaLivro;
            }

            public int ProximoId()
            {
                return listaLivro.Count;
            }

            public Livro RetornaPorId(int id)
            {
                return listaLivro[id];
            }
    }
}