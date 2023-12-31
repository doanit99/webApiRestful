﻿using Dapper;
using Doan.WebApiRestful.Data.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.WebApiRestful.Data
{
	public class DapperHelper : IDapperHelper
	{
		private readonly string connectString = string.Empty;
		public DapperHelper(IConfiguration configuration)
		{
			connectString = configuration.GetConnectionString("DefaultConnection");
		}

		public void ExecuteNotReturn(string query, DynamicParameters parammeters = null)
		{
			using (var dbConnection = new SqlConnection(connectString))
			{
				dbConnection.ExecuteAsync(query, parammeters, commandType: CommandType.Text);
			}
		}

		public async Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null)
		{
			using (var dbConnection = new SqlConnection(connectString))
			{
				return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parammeters, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
			}
		}

		public async Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null)
		{
			using (var dbConnection = new SqlConnection(connectString))
			{
				return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.Text);
			}
		}

		public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters parammeters = null)
		{
			using (var dbConnection = new SqlConnection(connectString))
			{
				return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.StoredProcedure);
			}
		}

	}
}
