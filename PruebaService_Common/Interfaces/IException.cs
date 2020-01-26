using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public interface IException
    {
        int StatusCode { get; set; }
        string DetailMessage { get; set; }
    }
}
