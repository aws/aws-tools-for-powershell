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
    /// Returns vector attributes. To specify the vector index, you can either use both the
    /// vector bucket name and the vector index name, or use the vector index Amazon Resource
    /// Name (ARN). 
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3vectors:GetVectors</c> permission to use this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3VVector")]
    [OutputType("Amazon.S3Vectors.Model.GetOutputVector")]
    [AWSCmdlet("Calls the Amazon S3 Vectors GetVectors API operation.", Operation = new[] {"GetVectors"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.GetVectorsResponse))]
    [AWSCmdletOutput("Amazon.S3Vectors.Model.GetOutputVector or Amazon.S3Vectors.Model.GetVectorsResponse",
        "This cmdlet returns a collection of Amazon.S3Vectors.Model.GetOutputVector objects.",
        "The service call response (type Amazon.S3Vectors.Model.GetVectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3VVectorCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IndexArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexArn { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The names of the vectors you want to return attributes for. </para><para />
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
        [Alias("Keys")]
        public System.String[] Key { get; set; }
        #endregion
        
        #region Parameter ReturnData
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include the vector data in the response. The default value is
        /// <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnData { get; set; }
        #endregion
        
        #region Parameter ReturnMetadata
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include metadata in the response. The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnMetadata { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket that contains the vector index. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Vectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.GetVectorsResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.GetVectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Vectors";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.GetVectorsResponse, GetS3VVectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IndexArn = this.IndexArn;
            context.IndexName = this.IndexName;
            if (this.Key != null)
            {
                context.Key = new List<System.String>(this.Key);
            }
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnData = this.ReturnData;
            context.ReturnMetadata = this.ReturnMetadata;
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
            var request = new Amazon.S3Vectors.Model.GetVectorsRequest();
            
            if (cmdletContext.IndexArn != null)
            {
                request.IndexArn = cmdletContext.IndexArn;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.Key != null)
            {
                request.Keys = cmdletContext.Key;
            }
            if (cmdletContext.ReturnData != null)
            {
                request.ReturnData = cmdletContext.ReturnData.Value;
            }
            if (cmdletContext.ReturnMetadata != null)
            {
                request.ReturnMetadata = cmdletContext.ReturnMetadata.Value;
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
        
        private Amazon.S3Vectors.Model.GetVectorsResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.GetVectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "GetVectors");
            try
            {
                return client.GetVectorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Key { get; set; }
            public System.Boolean? ReturnData { get; set; }
            public System.Boolean? ReturnMetadata { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.GetVectorsResponse, GetS3VVectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Vectors;
        }
        
    }
}
