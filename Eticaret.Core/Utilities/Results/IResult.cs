using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Core.Utilities.Results
{
    public interface IResult
    {
        //Yapılan İşlem Durumu
        bool Success { get; }
        //Yapılan İşlem Mesajı
        string Message { get; }
    }
}
