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
using System.Threading;
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3V
{
    /// <summary>
    /// Amazon.S3Vectors.IAmazonS3Vectors.PutVectors
    /// </summary>
    [Cmdlet("Write", "S3VVector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Vectors PutVectors API operation.", Operation = new[] {"PutVectors"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.PutVectorsResponse))]
    [AWSCmdletOutput("None or Amazon.S3Vectors.Model.PutVectorsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Vectors.Model.PutVectorsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3VVectorCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IndexArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the vector index where you want to write vectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexArn { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index where you want to write vectors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket that contains the vector index. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Vector
        /// <summary>
        /// <para>
        /// <para>The vectors to add to a vector index. The number of vectors in a single request must
        /// not exceed the resource capacity, otherwise the request will be rejected with the
        /// error <c>ServiceUnavailableException</c> with the error message "Currently unable
        /// to handle the request".</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Vectors")]
        public Amazon.S3Vectors.Model.PutInputVector[] Vector { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.PutVectorsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VectorBucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3VVector (PutVectors)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.PutVectorsResponse, WriteS3VVectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IndexArn = this.IndexArn;
            context.IndexName = this.IndexName;
            context.VectorBucketName = this.VectorBucketName;
            if (this.Vector != null)
            {
                context.Vector = new List<Amazon.S3Vectors.Model.PutInputVector>(this.Vector);
            }
            #if MODULAR
            if (this.Vector == null && ParameterWasBound(nameof(this.Vector)))
            {
                WriteWarning("You are passing $null as a value for parameter Vector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.S3Vectors.Model.PutVectorsRequest();
            
            if (cmdletContext.IndexArn != null)
            {
                request.IndexArn = cmdletContext.IndexArn;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.VectorBucketName != null)
            {
                request.VectorBucketName = cmdletContext.VectorBucketName;
            }
            if (cmdletContext.Vector != null)
            {
                request.Vectors = cmdletContext.Vector;
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
        
        private Amazon.S3Vectors.Model.PutVectorsResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.PutVectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "PutVectors");
            try
            {
                return client.PutVectorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IndexArn { get; set; }
            public System.String IndexName { get; set; }
            public System.String VectorBucketName { get; set; }
            public List<Amazon.S3Vectors.Model.PutInputVector> Vector { get; set; }
            public System.Func<Amazon.S3Vectors.Model.PutVectorsResponse, WriteS3VVectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
