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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Retrieves the <code>PublicAccessBlock</code> configuration for an Amazon S3 bucket.
    /// To use this operation, you must have the <code>s3:GetBucketPublicAccessBlock</code>
    /// permission. For more information about Amazon S3 permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html">Specifying
    /// Permissions in a Policy</a>.
    /// 
    ///  <important><para>
    /// When Amazon S3 evaluates the <code>PublicAccessBlock</code> configuration for a bucket
    /// or an object, it checks the <code>PublicAccessBlock</code> configuration for both
    /// the bucket (or the bucket that contains the object) and the bucket owner's account.
    /// If the <code>PublicAccessBlock</code> settings are different between the bucket and
    /// the account, Amazon S3 uses the most restrictive combination of the bucket-level and
    /// account-level settings.
    /// </para></important><para>
    /// For more information about when Amazon S3 considers a bucket or an object public,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/access-control-block-public-access.html#access-control-block-public-access-policy-status">The
    /// Meaning of "Public"</a>.
    /// </para><para>
    /// The following operations are related to <code>GetPublicAccessBlock</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/access-control-block-public-access.html">Using
    /// Amazon S3 Block Public Access</a></para></li><li><para><a>PutPublicAccessBlock</a></para></li><li><para><a>GetPublicAccessBlock</a></para></li><li><para><a>DeletePublicAccessBlock</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3PublicAccessBlock")]
    [OutputType("Amazon.S3.Model.PublicAccessBlockConfiguration")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetPublicAccessBlock API operation.", Operation = new[] {"GetPublicAccessBlock"}, SelectReturnType = typeof(Amazon.S3.Model.GetPublicAccessBlockResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.PublicAccessBlockConfiguration or Amazon.S3.Model.GetPublicAccessBlockResponse",
        "This cmdlet returns an Amazon.S3.Model.PublicAccessBlockConfiguration object.",
        "The service call response (type Amazon.S3.Model.GetPublicAccessBlockResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3PublicAccessBlockCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the Amazon S3 bucket whose Public Access Block configuration you want
        /// to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PublicAccessBlockConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetPublicAccessBlockResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetPublicAccessBlockResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PublicAccessBlockConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetPublicAccessBlockResponse, GetS3PublicAccessBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.GetPublicAccessBlockRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.GetPublicAccessBlockResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetPublicAccessBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetPublicAccessBlock");
            try
            {
                #if DESKTOP
                return client.GetPublicAccessBlock(request);
                #elif CORECLR
                return client.GetPublicAccessBlockAsync(request).GetAwaiter().GetResult();
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String BucketName { get; set; }
            public System.Func<Amazon.S3.Model.GetPublicAccessBlockResponse, GetS3PublicAccessBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PublicAccessBlockConfiguration;
        }
        
    }
}
