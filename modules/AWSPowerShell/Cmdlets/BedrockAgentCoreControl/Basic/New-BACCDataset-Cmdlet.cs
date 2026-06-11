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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a new dataset resource asynchronously. Returns immediately with status CREATING.
    /// Poll <c>GetDataset</c> until status transitions to ACTIVE or CREATE_FAILED.
    /// </summary>
    [Cmdlet("New", "BACCDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse object containing multiple properties."
    )]
    public partial class NewBACCDatasetCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para> Human-readable name for the dataset. Must be unique within the account. Immutable
        /// after creation. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the dataset. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Source_InlineExamples_Example
        /// <summary>
        /// <para>
        /// <para> Examples to add. Each example is assigned an auto-generated UUID. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_InlineExamples_Examples")]
        public Amazon.Runtime.Documents.Document[] Source_InlineExamples_Example { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> Optional KMS key ARN for server-side encryption on service Amazon S3 writes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Source_S3Source_S3Uri
        /// <summary>
        /// <para>
        /// <para> Amazon S3 URI of the JSONL file (for example, <c>s3://my-bucket/path/to/examples.jsonl</c>).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_S3Source_S3Uri { get; set; }
        #endregion
        
        #region Parameter SchemaType
        /// <summary>
        /// <para>
        /// <para> Versioned schema type governing the structure of examples. Immutable after creation.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.DatasetSchemaType")]
        public Amazon.BedrockAgentCoreControl.DatasetSchemaType SchemaType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A map of tag keys and values to assign to the dataset. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse, NewBACCDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.KmsKeyArn = this.KmsKeyArn;
            context.SchemaType = this.SchemaType;
            #if MODULAR
            if (this.SchemaType == null && ParameterWasBound(nameof(this.SchemaType)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source_InlineExamples_Example != null)
            {
                context.Source_InlineExamples_Example = new List<Amazon.Runtime.Documents.Document>(this.Source_InlineExamples_Example);
            }
            context.Source_S3Source_S3Uri = this.Source_S3Source_S3Uri;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateDatasetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.SchemaType != null)
            {
                request.SchemaType = cmdletContext.SchemaType;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.BedrockAgentCoreControl.Model.DataSourceType();
            Amazon.BedrockAgentCoreControl.Model.InlineExamplesSource requestSource_source_InlineExamples = null;
            
             // populate InlineExamples
            var requestSource_source_InlineExamplesIsNull = true;
            requestSource_source_InlineExamples = new Amazon.BedrockAgentCoreControl.Model.InlineExamplesSource();
            List<Amazon.Runtime.Documents.Document> requestSource_source_InlineExamples_source_InlineExamples_Example = null;
            if (cmdletContext.Source_InlineExamples_Example != null)
            {
                requestSource_source_InlineExamples_source_InlineExamples_Example = cmdletContext.Source_InlineExamples_Example;
            }
            if (requestSource_source_InlineExamples_source_InlineExamples_Example != null)
            {
                requestSource_source_InlineExamples.Examples = requestSource_source_InlineExamples_source_InlineExamples_Example;
                requestSource_source_InlineExamplesIsNull = false;
            }
             // determine if requestSource_source_InlineExamples should be set to null
            if (requestSource_source_InlineExamplesIsNull)
            {
                requestSource_source_InlineExamples = null;
            }
            if (requestSource_source_InlineExamples != null)
            {
                request.Source.InlineExamples = requestSource_source_InlineExamples;
                requestSourceIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.S3Source requestSource_source_S3Source = null;
            
             // populate S3Source
            var requestSource_source_S3SourceIsNull = true;
            requestSource_source_S3Source = new Amazon.BedrockAgentCoreControl.Model.S3Source();
            System.String requestSource_source_S3Source_source_S3Source_S3Uri = null;
            if (cmdletContext.Source_S3Source_S3Uri != null)
            {
                requestSource_source_S3Source_source_S3Source_S3Uri = cmdletContext.Source_S3Source_S3Uri;
            }
            if (requestSource_source_S3Source_source_S3Source_S3Uri != null)
            {
                requestSource_source_S3Source.S3Uri = requestSource_source_S3Source_source_S3Source_S3Uri;
                requestSource_source_S3SourceIsNull = false;
            }
             // determine if requestSource_source_S3Source should be set to null
            if (requestSource_source_S3SourceIsNull)
            {
                requestSource_source_S3Source = null;
            }
            if (requestSource_source_S3Source != null)
            {
                request.Source.S3Source = requestSource_source_S3Source;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateDataset");
            try
            {
                return client.CreateDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DatasetName { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyArn { get; set; }
            public Amazon.BedrockAgentCoreControl.DatasetSchemaType SchemaType { get; set; }
            public List<Amazon.Runtime.Documents.Document> Source_InlineExamples_Example { get; set; }
            public System.String Source_S3Source_S3Uri { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateDatasetResponse, NewBACCDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
