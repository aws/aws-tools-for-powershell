/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Deletes an S3 bucket, optionally deleting remaining bucket content first (non-empty buckets cannot be deleted).
    /// </summary>
    [Cmdlet("Remove", "S3Bucket", SupportsShouldProcess=true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.S3.Model.DeleteBucketResponse")]
    [AWSCmdlet("Deletes an Amazon S3 bucket. "
                + "Use the -DeleteBucketContent switch to delete any objects and/or object versions the bucket contains prior to bucket deletion (non-empty buckets cannot be deleted).",
                    Operation = new [] {"DeleteBucket"}, SelectReturnType = typeof(Amazon.S3.Model.DeleteBucketResponse)
    )]
    [AWSCmdletOutput("Amazon.S3.Model.DeleteBucketResponse",
        "This cmdlet returns an Amazon.S3.Model.DeleteBucketResponse object containing multiple properties. The object can be returned by specifying '-Select *'."
    )]
    public class RemoveS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// Specifies the bucket being deleted.
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets </b> - When you use this operation with a directory bucket,
        /// you must use path-style requests in the format <c>https://s3express-control.<i>region_code</i>.amazonaws.com/<i>bucket-name</i>
        /// </c>. Virtual-hosted-style requests aren't supported. Directory bucket names must
        /// be unique in the chosen Availability Zone. Bucket names must also follow the format
        /// <c> <i>bucket_base_name</i>--<i>az_id</i>--x-s3</c> (for example, <c> <i>amzn-s3-demo-bucket</i>--<i>usw2-az1</i>--x-s3</c>).
        /// For information about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i> 
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter DeleteBucketContent
        /// <summary>
        /// <para>
        /// If set, all remaining objects and/or object versions in the bucket are deleted proir to the bucket itself 
        /// being deleted.
        /// </para>
        /// <para>Default: Off.</para>
        /// <para>
        /// Buckets that contain objects cannot be deleted.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteObjects")]
        public SwitchParameter DeleteBucketContent { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.DeleteBucketResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.DeleteBucketResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "*";
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Remove-S3Bucket (DeleteBucket)"))
                return;

            var context = new CmdletContext
            {
                BucketName = this.BucketName,
                DeleteObjects = this.DeleteBucketContent
            };

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.DeleteBucketResponse, RemoveS3BucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            CmdletOutput output;
            if (cmdletContext.DeleteObjects)
            {
                output = null;
#if DESKTOP
                AmazonS3Util.DeleteS3BucketWithObjects(Client,
                                                       cmdletContext.BucketName, 
                                                       new S3DeleteBucketWithObjectsOptions 
                                                       { 
                                                           ContinueOnError = false 
                                                       });
#elif CORECLR
                AmazonS3Util.DeleteS3BucketWithObjectsAsync(Client,
                                                             cmdletContext.BucketName,
                                                             new S3DeleteBucketWithObjectsOptions
                                                             {
                                                                 ContinueOnError = false
                                                             }).Wait();
#else
#error "Unknown build edition"
#endif
            }
            else
            {
                var request = new DeleteBucketRequest {BucketName = cmdletContext.BucketName};

                using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
                {
                    try
                    {
                        var response = CallAWSServiceOperation(client, request);
                        object pipelineOutput = null;
                        pipelineOutput = cmdletContext.Select(response, this);
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                        };
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                }
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

#endregion

        #region AWS Service Operation Call

        private Amazon.S3.Model.DeleteBucketResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "DeleteBucket");

            try
            {
#if DESKTOP
                return client.DeleteBucket(request);
#elif CORECLR
                return client.DeleteBucketAsync(request).GetAwaiter().GetResult();
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
            public String BucketName { get; set; }
            public bool DeleteObjects { get; set; }
            public System.Func<Amazon.S3.Model.DeleteBucketResponse, RemoveS3BucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
