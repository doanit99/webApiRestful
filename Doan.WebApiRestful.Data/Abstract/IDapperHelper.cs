using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.WebApiRestful.Data.Abstract
{
	public interface IDapperHelper
	{
		void ExecuteNotReturn(string query, DynamicParameters parammeters = null);
		Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null);
		Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null);
		Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters parammeters = null);
	}
}
