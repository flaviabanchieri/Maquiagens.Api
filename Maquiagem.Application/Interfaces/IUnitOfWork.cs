﻿using Maquiagem.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquiagem.Application.Interfaces
{
	public interface IUnitOfWork
	{
		CommandResponse Commit();
	}
}
