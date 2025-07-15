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
    /// Amazon.S3Vectors.IAmazonS3Vectors.GetVectorBucket
    /// </summary>
    [Cmdlet("Get", "S3VVectorBucket")]
    [OutputType("Amazon.S3Vectors.Model.VectorBucket")]
    [AWSCmdlet("Calls the Amazon S3 Vectors GetVectorBucket API operation.", Operation = new[] {"GetVectorBucket"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.GetVectorBucketResponse))]
    [AWSCmdletOutput("Amazon.S3Vectors.Model.VectorBucket or Amazon.S3Vectors.Model.GetVectorBucketResponse",
        "This cmdlet returns an Amazon.S3Vectors.Model.VectorBucket object.",
        "The service call response (type Amazon.S3Vectors.Model.GetVectorBucketResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3VVectorBucketCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VectorBucketArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the vector bucket to retrieve information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketArn { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket to retrieve information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VectorBucket'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.GetVectorBucketResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.GetVectorBucketResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VectorBucket";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VectorBucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VectorBucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VectorBucketName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.GetVectorBucketResponse, GetS3VVectorBucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VectorBucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.S3Vectors.Model.GetVectorBucketRequest();
            
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
        
        private Amazon.S3Vectors.Model.GetVectorBucketResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.GetVectorBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "GetVectorBucket");
            try
            {
                #if DESKTOP
                return client.GetVectorBucket(request);
                #elif CORECLR
                return client.GetVectorBucketAsync(request).GetAwaiter().GetResult();
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
            public System.String VectorBucketArn { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.GetVectorBucketResponse, GetS3VVectorBucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VectorBucket;
        }
        
    }
}
