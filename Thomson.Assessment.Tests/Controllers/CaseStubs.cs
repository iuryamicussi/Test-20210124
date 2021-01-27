using System.Collections.Generic;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Tests.Controllers
{
    public class CaseStubs
    {
        public static IEnumerable<Case> CaseList()
        {
            var caseList = new List<Case>{
                {new Case()},
                {new Case()},
                {new Case()},
                {new Case()},
                {new Case()}
            };

            return caseList;
        }

    }
}