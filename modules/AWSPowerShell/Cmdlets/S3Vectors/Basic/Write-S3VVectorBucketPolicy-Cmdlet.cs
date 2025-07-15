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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

namespace Amazon.PowerShell.Cmdlets.S3V
{
    /// <summary>
    /// Amazon.S3Vectors.IAmazonS3Vectors.PutVectorBucketPolicy
    /// </summary>
    [Cmdlet("Write", "S3VVectorBucketPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Vectors PutVectorBucketPolicy API operation.", Operation = new[] {"PutVectorBucketPolicy"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3VVectorBucketPolicyCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The <c>JSON</c> that defines the policy. For more information about bucket policies
        /// for S3 Vectors, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-bucket-policy.html">Managing
        /// vector bucket policies</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter VectorBucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the vector bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketArn { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Policy parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Policy' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Policy' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3VVectorBucketPolicy (PutVectorBucketPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse, WriteS3VVectorBucketPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Policy;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VectorBucketArn = this.VectorBucketArn;
            context.VectorBucketName = this.VectorBucketName;
            
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
            var request = new Amazon.S3Vectors.Model.PutVectorBucketPolicyRequest();
            
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.VectorBucketArn != null)
            {
                request.VectorBucketArn = cmdletContext.VectorBucketArn;
            }
            if (cmdletContext.VectorBucketName != null)
            {
                request.VectorBucketName = cmdletContext.VectorBucketName;
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
        
        private Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.PutVectorBucketPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "PutVectorBucketPolicy");
            try
            {
                #if DESKTOP
                return client.PutVectorBucketPolicy(request);
                #elif CORECLR
                return client.PutVectorBucketPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Policy { get; set; }
            public System.String VectorBucketArn { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.PutVectorBucketPolicyResponse, WriteS3VVectorBucketPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
