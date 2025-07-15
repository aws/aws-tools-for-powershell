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
    /// Amazon.S3Vectors.IAmazonS3Vectors.CreateIndex
    /// </summary>
    [Cmdlet("New", "S3VIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Vectors CreateIndex API operation.", Operation = new[] {"CreateIndex"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.CreateIndexResponse))]
    [AWSCmdletOutput("None or Amazon.S3Vectors.Model.CreateIndexResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Vectors.Model.CreateIndexResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewS3VIndexCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataType
        /// <summary>
        /// <para>
        /// <para>The data type of the vectors to be inserted into the vector index. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Vectors.DataType")]
        public Amazon.S3Vectors.DataType DataType { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the vectors to be inserted into the vector index. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Dimension { get; set; }
        #endregion
        
        #region Parameter DistanceMetric
        /// <summary>
        /// <para>
        /// <para>The distance metric to be used for similarity search. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Vectors.DistanceMetric")]
        public Amazon.S3Vectors.DistanceMetric DistanceMetric { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index to create. </para>
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
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_NonFilterableMetadataKey
        /// <summary>
        /// <para>
        /// <para>Non-filterable metadata keys allow you to enrich vectors with additional context during
        /// storage and retrieval. Unlike default metadata keys, these keys can’t be used as query
        /// filters. Non-filterable metadata keys can be retrieved but can’t be searched, queried,
        /// or filtered. You can access non-filterable metadata keys of your vectors after finding
        /// the vectors. For more information about non-filterable metadata keys, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-vectors.html">Vectors</a>
        /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-limitations.html">Limitations
        /// and restrictions</a> in the <i>Amazon S3 User Guide</i>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_NonFilterableMetadataKeys")]
        public System.String[] MetadataConfiguration_NonFilterableMetadataKey { get; set; }
        #endregion
        
        #region Parameter VectorBucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the vector bucket to create the vector index in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketArn { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket to create the vector index in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.CreateIndexResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3VIndex (CreateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.CreateIndexResponse, NewS3VIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataType = this.DataType;
            #if MODULAR
            if (this.DataType == null && ParameterWasBound(nameof(this.DataType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Dimension = this.Dimension;
            #if MODULAR
            if (this.Dimension == null && ParameterWasBound(nameof(this.Dimension)))
            {
                WriteWarning("You are passing $null as a value for parameter Dimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistanceMetric = this.DistanceMetric;
            #if MODULAR
            if (this.DistanceMetric == null && ParameterWasBound(nameof(this.DistanceMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter DistanceMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetadataConfiguration_NonFilterableMetadataKey != null)
            {
                context.MetadataConfiguration_NonFilterableMetadataKey = new List<System.String>(this.MetadataConfiguration_NonFilterableMetadataKey);
            }
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
            var request = new Amazon.S3Vectors.Model.CreateIndexRequest();
            
            if (cmdletContext.DataType != null)
            {
                request.DataType = cmdletContext.DataType;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimension = cmdletContext.Dimension.Value;
            }
            if (cmdletContext.DistanceMetric != null)
            {
                request.DistanceMetric = cmdletContext.DistanceMetric;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            
             // populate MetadataConfiguration
            var requestMetadataConfigurationIsNull = true;
            request.MetadataConfiguration = new Amazon.S3Vectors.Model.MetadataConfiguration();
            List<System.String> requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey = null;
            if (cmdletContext.MetadataConfiguration_NonFilterableMetadataKey != null)
            {
                requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey = cmdletContext.MetadataConfiguration_NonFilterableMetadataKey;
            }
            if (requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey != null)
            {
                request.MetadataConfiguration.NonFilterableMetadataKeys = requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey;
                requestMetadataConfigurationIsNull = false;
            }
             // determine if request.MetadataConfiguration should be set to null
            if (requestMetadataConfigurationIsNull)
            {
                request.MetadataConfiguration = null;
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
        
        private Amazon.S3Vectors.Model.CreateIndexResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.CreateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "CreateIndex");
            try
            {
                return client.CreateIndexAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3Vectors.DataType DataType { get; set; }
            public System.Int32? Dimension { get; set; }
            public Amazon.S3Vectors.DistanceMetric DistanceMetric { get; set; }
            public System.String IndexName { get; set; }
            public List<System.String> MetadataConfiguration_NonFilterableMetadataKey { get; set; }
            public System.String VectorBucketArn { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.CreateIndexResponse, NewS3VIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
