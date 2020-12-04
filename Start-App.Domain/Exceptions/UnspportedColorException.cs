/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;

namespace Start_App.Domain.Exceptions
{
    public class UnspportedColorException : Exception
    {
        public UnspportedColorException(string code)
            : base($"Colour \"{code}\" is unsupported.")
        {

        }
    }
}
