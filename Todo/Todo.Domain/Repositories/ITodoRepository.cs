using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    // não quer a aplicacao acoplada, aqui mantém só os contratos para o repositório, repository pattern
    public interface ITodoRepository
    {
        // definicao do nosso contrato, abstracao do repositorio, como ele vai salvar, é problema de infra
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem GetById(Guid id, string user);
    }
}