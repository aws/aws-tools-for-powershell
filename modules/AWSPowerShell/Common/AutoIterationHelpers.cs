/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

//
// Collection of helper methods to allow similar handling of different 
// marker and other types used in auto-iteration code
//
namespace Amazon.PowerShell.Common
{
    internal static class AutoIterationHelpers
    {
        public static bool HasValue(string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static bool HasValue(int? i)
        {
            return i.HasValue;
        }


        public static int ConvertEmitLimitToint(int limit)
        {
            return limit;
        }
        public static int ConvertEmitLimitToInt32(int limit)
        {
            return limit;
        }
        public static string ConvertEmitLimitToString(int limit)
        {
            return limit.ToString(CultureInfo.InvariantCulture);
        }

        public static int ConvertEmitLimitToServiceTypeint(int limit)
        {
            return limit;
        }
        public static int ConvertEmitLimitToServiceTypeInt32(int limit)
        {
            return limit;
        }
        public static string ConvertEmitLimitToServiceTypeString(int limit)
        {
            return limit.ToString(CultureInfo.InvariantCulture);
        }
    
    }
}
