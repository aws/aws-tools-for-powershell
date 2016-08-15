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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3.Util;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Tests that an S3 Bucket exists
    /// </summary>
    [Cmdlet("Test", "S3Bucket")]
    [OutputType(typeof(bool))]
    [AWSCmdlet("Tests that an S3 bucket exists.")]
    [AWSCmdletOutput("System.Boolean", "Returns true if the bucket exists, false if it doesn't. Returns true even if the bucket exists but belong to a different account.")]
    public class TestS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket to test existence and access.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }

        #endregion

        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  BucketName = this.BucketName
                              };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
#if DESKTOP
                var exists = AmazonS3Util.DoesS3BucketExist(client, cmdletContext.BucketName);
#elif CORECLR
                var exists = AmazonS3Util.DoesS3BucketExistAsync(client, cmdletContext.BucketName).Result;
#else
#error "Unknown build edition"
#endif
                var output = new CmdletOutput
                {
                    PipelineOutput = exists
                };
                return output;
            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
        }
    }
}
