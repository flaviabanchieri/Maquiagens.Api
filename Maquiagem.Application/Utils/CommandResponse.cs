namespace Maquiagem.Application.Utils
{
	public class CommandResponse
	{
		public bool Success { get; private set; }
		public string Message { get; private set; }

		public CommandResponse(bool success, string message = "")
		{
			Success = success;
			Message = message;
		}

		public CommandResponse()
		{
		}

		public static CommandResponse Ok(string message = "Operação realizada com sucesso!")
			=> new CommandResponse(true, message);

		public static CommandResponse Fail(string message = "Erro ao processar a operação.")
			=> new CommandResponse(false, message);
	}
}
