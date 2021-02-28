using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository) // definicao de uma dependencia, para funcionar, precisa do repository
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, sua tarefa está errada.",
                    command.Notifications
                );

            // gera o todoitem
            var todo = new TodoItem(command.Title, command.Date, command.User);

            // salva no banco
            _repository.Create(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

    }
}