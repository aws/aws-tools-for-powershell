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
    /// Adds examples to the dataset's DRAFT.
    /// 
    ///  
    /// <para><strong>Validation:</strong> All examples are validated against the dataset's schemaType
    /// before any writes occur. If any example fails validation, the entire batch is rejected
    /// with ValidationException — no examples are written (all-or-nothing semantics).
    /// </para><para><strong>Asynchronous:</strong> Operates in-place on DRAFT. No version bump occurs.
    /// Use CreateDatasetVersion to publish DRAFT as a new numbered version.
    /// </para><para><strong>State guard:</strong> Returns ConflictException (DATASET_NOT_READY) if the
    /// dataset status is not in {DRAFT, ACTIVE}.
    /// </para><para><strong>Request size limit:</strong> Max 5 MB total request body. Max 1000 examples
    /// per call.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "BACCDatasetExample", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer AddDatasetExamples API operation.", Operation = new[] {"AddDatasetExamples"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse object containing multiple properties."
    )]
    public partial class AddBACCDatasetExampleCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the dataset to add examples to. </para>
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter Source_InlineExamples_Example
        /// <summary>
        /// <para>
        /// <para>Examples to add. Each example is assigned an auto-generated UUID.</para><para />
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
        
        #region Parameter Source_S3Source_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 URI of the JSONL file (e.g. s3://my-bucket/path/to/examples.jsonl).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_S3Source_S3Uri { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-BACCDatasetExample (AddDatasetExamples)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse, AddBACCDatasetExampleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source_InlineExamples_Example != null)
            {
                context.Source_InlineExamples_Example = new List<Amazon.Runtime.Documents.Document>(this.Source_InlineExamples_Example);
            }
            context.Source_S3Source_S3Uri = this.Source_S3Source_S3Uri;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "AddDatasetExamples");
            try
            {
                return client.AddDatasetExamplesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetId { get; set; }
            public List<Amazon.Runtime.Documents.Document> Source_InlineExamples_Example { get; set; }
            public System.String Source_S3Source_S3Uri { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.AddDatasetExamplesResponse, AddBACCDatasetExampleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
