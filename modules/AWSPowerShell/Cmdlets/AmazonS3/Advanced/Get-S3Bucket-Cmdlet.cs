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
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Retrieves one or more S3Bucket instances describing a set of buckets.
    /// </summary>
    [Cmdlet("Get", "S3Bucket")]
    [OutputType("Amazon.S3.Model.S3Bucket")]
    [AWSCmdlet("Lists your Amazon S3 buckets.", Operation = new [] {"ListBuckets"})]
    [AWSCmdletOutput("Amazon.S3.Model.S3Bucket", 
                     "The cmdlet returns 0 or more Amazon.S3.Model.S3Bucket instances.",
                     "The service response (type Amazon.S3.Model.ListBucketsResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        #region Parameter BucketName
        /// <summary>
        /// If set, returns a single S3Bucket instance mapping to the specified bucket.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
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

            // prepare standard parameters

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new ListBucketsRequest();

            ServiceCalls.PushServiceRequest(request, this.MyInvocation);

            // have to retrieve all buckets and then filter out the specific one if needed; this is
            // a non-paging api, we get all data in one hit
            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);

                    object pipelineOutput;
                    if (string.IsNullOrEmpty(cmdletContext.BucketName))
                        pipelineOutput = response.Buckets;
                    else
                    {
                        var list = new List<S3Bucket>
                                       {
                                           response.Buckets.FirstOrDefault(
                                               b => b.BucketName == cmdletContext.BucketName)
                                       };
                        pipelineOutput = list;
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                return output;
            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.S3.Model.ListBucketsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListBucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "ListBuckets");

            try
            {
#if DESKTOP
                return client.ListBuckets(request);
#elif CORECLR
                return client.ListBucketsAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }

                throw;
            }
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public string BucketName { get; set; }
        }

    }
}
