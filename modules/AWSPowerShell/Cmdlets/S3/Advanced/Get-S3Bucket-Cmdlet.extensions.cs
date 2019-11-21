/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public partial class GetS3BucketCmdlet
    {
        #region Parameter BucketName
        /// <summary>
        /// If set, returns a single S3Bucket instance mapping to the specified bucket.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            if (ParameterWasBound(nameof(this.Select)) && BucketName != null)
            {
                throw new System.ArgumentException("-BucketName cannot be used when -Select is specified.", nameof(this.BucketName));
            }
        }

        protected override void ProcessOutput(CmdletOutput cmdletOutput)
        {
            if (cmdletOutput == null)
                return;

            if (!string.IsNullOrEmpty(this.BucketName) && cmdletOutput.PipelineOutput is List<S3Bucket> buckets)
            {
                cmdletOutput.PipelineOutput = buckets.Where(b => b.BucketName == this.BucketName).ToList();
            }

            base.ProcessOutput(cmdletOutput);
        }
    }
}
