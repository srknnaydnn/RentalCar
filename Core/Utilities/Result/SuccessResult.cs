﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {

        public SuccessResult(bool success, string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
