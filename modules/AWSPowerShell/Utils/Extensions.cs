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
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Amazon.Runtime;
using Amazon.Util.Internal;

namespace Amazon.PowerShell.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Creates an AWSCredentials instance with access and secret keys (and possibly token)
        /// from StoredProfileAWSCredentials. This avoids storing "reference" credentials (credentials
        /// that are pointing to a credentials source).
        /// </summary>
        /// <param name="stored"></param>
        /// <returns></returns>
        public static AWSCredentials ToKeyedCredentials(this StoredProfileAWSCredentials stored)
        {
            var ic = stored.GetCredentials();

            if (ic.UseToken)
                return new SessionAWSCredentials(ic.AccessKey, ic.SecretKey, ic.Token);
            else
                return new BasicAWSCredentials(ic.AccessKey, ic.SecretKey);
        }
    }
}
