using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Thomson.Assessment.Infrastructure.DAL;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Infrastructure.DAL
{
    public class CaseSQLWithDapperRepository : ICaseRepository
    {
        private readonly IDbConnection _dbConnection;

        public CaseSQLWithDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Case>> GetAll() =>
             await _dbConnection.QueryAsync<Case>("Select * From Cases");

        public async Task<Case> Get(string caseNumber) =>
            await _dbConnection
                .QueryFirstOrDefaultAsync<Case>("Select * From Cases Where Number = @CaseNumber", new { CaseNumber = caseNumber });


        public async Task<bool> Create(Case myCase)
        {
            var sqlInsert = "Insert Into Cases (Number,CourtName,ResponsibleName) Values (@Number, @CourtName, @ResponsibleName)";
            var affectedRows = await _dbConnection
                                    .ExecuteAsync(
                                        sqlInsert,
                                        new { Number = myCase.Number, CourtName = myCase.CourtName, ResponsibleName = myCase.ResponsibleName }
                                    );
            
            return affectedRows > 0;
        }

        public async Task<bool> Update(Case myCase)
        {
            var sqlInsert = "Update Cases Set CourtName = @CourtName, ResponsibleName = @ResponsibleName Where Number = @Number";
            var affectedRows = await _dbConnection
                                    .ExecuteAsync(
                                        sqlInsert,
                                        new { Number = myCase.Number, CourtName = myCase.CourtName, ResponsibleName = myCase.ResponsibleName }
                                    );
            
            return affectedRows > 0;
        }

        public async Task<bool> Delete(string caseNumber)
        {
            var sqlInsert = "Delete From Cases Where Number = @Number";
            var affectedRows = await _dbConnection
                                    .ExecuteAsync(
                                        sqlInsert,
                                        new { Number = caseNumber }
                                    );
            
            return affectedRows > 0;
        }
    }
}