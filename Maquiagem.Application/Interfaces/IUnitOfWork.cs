using Maquiagem.Application.Utils;

namespace Maquiagem.Application.Interfaces
{
	public interface IUnitOfWork
	{
		CommandResponse Commit();
	}
}
