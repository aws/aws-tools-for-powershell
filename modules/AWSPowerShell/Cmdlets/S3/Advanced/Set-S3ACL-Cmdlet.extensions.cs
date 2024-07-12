/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public partial class SetS3ACLCmdlet
    {
        #region Parameter PublicReadOnly
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// This parameter is obsolete. Use CannedACL instead.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete. Use CannedACL instead.")]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// This parameter is obsolete. Use CannedACL instead.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete. Use CannedACL instead.")]
        public SwitchParameter PublicReadWrite { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            cmdletContext.Key = AmazonS3Helper.CleanKey(this.Key);
            base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, cmdletContext.Key);

            if (string.IsNullOrEmpty(this.CannedACL))
            {
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
                if (this.PublicReadOnly.IsPresent)
                {
                    cmdletContext.CannedACL = S3CannedACL.PublicRead;
                }
                else if (this.PublicReadWrite.IsPresent)
                {
                    cmdletContext.CannedACL = S3CannedACL.PublicReadWrite;
                }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            }
        }
    }
}
