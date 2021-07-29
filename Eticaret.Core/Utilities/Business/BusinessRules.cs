using Eticaret.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Core.Utilities.Business
{
    //Bu bölüm Business için bir iş kuralıdır. Eğer kuralı gerçekleşirse hatayı göndeirir. Gerçekleşmezse null gönderir.
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }

}
