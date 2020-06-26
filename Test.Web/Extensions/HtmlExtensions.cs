using System.Linq;
using System.Web.Mvc;

namespace Test.Web.Extensions
{
    public static class HtmlExtensions
    {
        public static string GetFirstError(this ModelStateDictionary modelState) =>
            modelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)).FirstOrDefault();
    }
}