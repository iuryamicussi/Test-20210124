using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Controllers
{
    public interface ICaseController
    {
         Task<IEnumerable<Case>> Get();

         Task<Case> Get(string caseNumber);

         Task<IActionResult> Post(Case myCase);

         Task<bool> Put(Case myCase);

         Task<bool> Delete(string caseNumber);
    }
}