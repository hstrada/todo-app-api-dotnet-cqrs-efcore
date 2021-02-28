using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    // vai gerenciar um ou mais comandos
    public interface IHandler<T> where T : ICommand // desde que t seja um icommand -> passa pelo contrato
    {
        // padronizou o retorno da aplicação, estamos falando de escrita da aplicação
        ICommandResult Handle(T command);
    }
}