using System.Data;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Thomson.Assessment.Model.Validators
{
    public class CaseValidator : AbstractValidator<Case>
    {
        private const int COURTNAME_MAXLENGTH = 1000;
        private const int RESPONSIBLENAME_MAXLENGTH = 1000;
        private const string CASENUMBER_REGEX = @"\d{7}-\d{2}.\d{4}.\d{1}.\d{2}.\d{4}";
        
        public CaseValidator()
        {
            RuleFor(x => x.Number)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(25)
                .Must(BeAValidCaseNumber).WithMessage("Invalid Case Number. Accepted format: (NNNNNNN-NN.NNNN.N.NN.NNNN)");

            RuleFor(x => x.CourtName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(COURTNAME_MAXLENGTH);

            RuleFor(x => x.ResponsibleName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(COURTNAME_MAXLENGTH);
        }

        private bool BeAValidCaseNumber(string caseNumber) =>
            Regex.Match(caseNumber,CASENUMBER_REGEX).Success;
    }
}