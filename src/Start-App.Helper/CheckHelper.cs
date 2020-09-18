// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;

namespace Start_App.Helper
{
    public static class CheckHelper
    {
        public static void ArgumentNullCheck<T>(T arg)
        {
            if(arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
        }
    }
}
