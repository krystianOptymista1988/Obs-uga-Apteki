using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Apteki.Modele
{
    public static class ExceptionExtensions
    {
        public static string GetFullMessage(this Exception ex)
        {
            var message = ex.Message;
            var inner = ex.InnerException;

            while (inner != null)
            {
                message += " --> " + inner.Message;
                inner = inner.InnerException;
            }

            return message;
        }
    }

}
