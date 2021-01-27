using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Thomson.Assessment.Infrastructure.DAL;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase, ICaseController
    {
        private readonly ILogger<CaseController> _logger;
        private readonly ICaseRepository _caseRepository;

        public CaseController(ILogger<CaseController> logger, ICaseRepository caseRepository)
        {
            _logger = logger;
            _caseRepository = caseRepository;
        }

        /// <summary>
        /// List all cases
        /// </summary>
        /// <returns>A list of cases</returns>
        [HttpGet()]
        public async Task<IEnumerable<Case>> Get() =>
            await _caseRepository.GetAll();

        /// <summary>
        /// Find a specific case by its number
        /// </summary>
        /// <param name="caseNumber">The case number identifier to be retrieved</param>
        /// <returns>The case with the provided identifier</returns>
        [HttpGet("byCaseNumber")]
        public async Task<Case> Get(string caseNumber) =>
            await _caseRepository.Get(caseNumber);

        /// <summary>
        /// Create a new case
        /// </summary>
        /// <param name="myCase">The case to be created</param>
        /// <returns>A boolean with true if the specified case was really created or false if it was not.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Case myCase)
        {
            var caseInDb = await _caseRepository.Get(myCase.Number);
            if(!(caseInDb is null))
            {
                return BadRequest(new { errors = "Case already exists in the database."});
            }

            return Ok(await _caseRepository.Create(myCase));
        }
            

        /// <summary>
        /// Update an existing case
        /// </summary>
        /// <param name="myCase">The case with its new attributes</param>
        /// <returns>A boolean with true if the specified case was really updated or false if it was not.</returns>
        [HttpPut]
        public async Task<bool> Put(Case myCase) =>
            await _caseRepository.Update(myCase);

        /// <summary>
        /// Delete a case
        /// </summary>
        /// <param name="caseNumber">The case number identifier to be deleted</param>
        /// <returns>A boolean with true if the specified case was really deleted or false if it was not.</returns>
        [HttpDelete]
        public async Task<bool> Delete(string caseNumber) =>
            await _caseRepository.Delete(caseNumber);

    }
}
