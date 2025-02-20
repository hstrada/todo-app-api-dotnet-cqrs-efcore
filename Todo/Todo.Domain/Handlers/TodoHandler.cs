using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
            IHandler<CreateTodoCommand>,
            IHandler<UpdateTodoCommand>,
            IHandler<MarkTodoAsDoneCommand>,
            IHandler<MarkTodoAsUndoneCommand>
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

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, sua tarefa está errada.",
                    command.Notifications
                );

            // recupera o todo (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // altera o titulo
            todo.UpdateTitle(command.Title);

            // salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, sua tarefa está errada.",
                    command.Notifications
                );

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, sua tarefa está errada.",
                    command.Notifications
                );

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }
    }
}