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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates a new bucket with the supplied name and permissions.
    /// </summary>
    [Cmdlet("New", "S3Bucket", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType("Amazon.S3.Model.S3Bucket")]
    [AWSCmdlet("Invokes the PutBucket operation against Amazon S3.", Operation = new [] {"PutBucket"})]
    [AWSCmdletOutput("Amazon.S3.Model.S3Bucket",
        "Returns an Amazon.S3.Model.S3Bucket instance representing the new bucket.",
        "The service response (type Amazon.S3.Model.PutBucketResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        /// <summary>
        /// The name that will be given to the new bucket. This name needs to be
        /// unique across Amazon S3.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }

        /// <summary>
        /// Specifies the name of the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v3/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter]
        public System.String CannedACLName { get; set; }

        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// </summary>
        [Parameter]
        public SwitchParameter PublicReadOnly { get; set; }

        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// </summary>
        [Parameter]
        public SwitchParameter PublicReadWrite { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "New-S3Bucket (PutBucket)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName
            };

            if (!string.IsNullOrEmpty(this.CannedACLName))
            {
                context.CannedACL = this.CannedACLName;
                //try
                //{
                //    context.CannedACL = (S3CannedACL)Enum.Parse(typeof(S3CannedACL), this.CannedACLName, true);
                //}
                //catch (ArgumentException e)
                //{
                //    string errMsg = "Invalid CannedACLName parameter value; allowable values: " + string.Join(", ", Enum.GetNames(typeof(S3CannedACL)));
                //    ThrowArgumentError(errMsg, this.CannedACLName, e);
                //}
            }
            else if (this.PublicReadOnly.IsPresent)
                context.CannedACL = S3CannedACL.PublicRead;
            else if (this.PublicReadWrite.IsPresent)
                context.CannedACL = S3CannedACL.PublicReadWrite;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new PutBucketRequest();
            
            if (cmdletContext.BucketName != null)
                request.BucketName = cmdletContext.BucketName;

            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;

            // Forcibly set a location constraint to match whatever Region argument was used 
            // with the cmdlet; this will prevent S3 issuing the "unspecified location constraint 
            // didn't match" message, potentially confusing new users.
            request.BucketRegionName = cmdletContext.Region.SystemName;

            ServiceCalls.PushServiceRequest(request, this.MyInvocation);

            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = client.PutBucket(request);

                    // since S3 bucket has only a name and a creation date, take a simple route to
                    // emit the instance rather than a ListBuckets/search approach
                    var s3Bucket = new S3Bucket {BucketName = cmdletContext.BucketName, CreationDate = DateTime.UtcNow};

                    // headers are no longer returned in sdk v2
                    //string[] headers = response.Headers.GetValues("Date");
                    //if (headers != null && headers.Any())
                    //{
                    //    DateTime dt;
                    //    DateTime.TryParse(headers[0], out dt);
                    //    s3Bucket.CreationDate = dt;
                    //}
                    //else 

                    output = new CmdletOutput
                    {
                        PipelineOutput = s3Bucket,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                    this.WriteError(new ErrorRecord(e,
                                                    string.Format("Failed to create the specified bucket.\r\nAmazon S3 error: {0}", e.Message),
                                                    ErrorCategory.InvalidOperation, this));
                }

                return output;
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
            public S3CannedACL CannedACL { get; set; }
        }
        
    }
}
