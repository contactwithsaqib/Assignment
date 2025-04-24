using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Assignment.Model
{
    public static class ModelStateExtensions
    {
        public static Dictionary<string, string[]> ToDictionary(this ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string[]>();
            foreach (var state in modelState)
            {
                var errorMessages = new List<string>();
                foreach (var error in state.Value.Errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
                errors.Add(state.Key, errorMessages.ToArray());
            }
            return errors;
        }
    }
}
