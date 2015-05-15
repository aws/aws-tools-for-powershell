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
using Amazon.Runtime;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Represents an AWS session credential from the Web Identity Federation (WIF) API.
    /// </summary>
    public class AWSWebIdentityCredentials : SessionAWSCredentials
    {
        public AWSWebIdentityCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration)
            : base(awsAccessKeyId, awsSecretAccessKey, token)
        {
            this.Expiration = expiration;
        }

        public AWSWebIdentityCredentials(Credentials credentials)
            : base(credentials.AccessKeyId,credentials.SecretAccessKey,credentials.SessionToken)
        {
            this.Expiration = credentials.Expiration;
        }

        /// <summary>
        /// The time when the token will expire.
        /// </summary>
        public DateTime Expiration { get; private set; }
    }
}
