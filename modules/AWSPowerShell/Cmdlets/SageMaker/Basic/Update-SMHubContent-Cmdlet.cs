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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates SageMaker hub content (either a <c>Model</c> or <c>Notebook</c> resource).
    /// 
    ///  
    /// <para>
    /// You can update the metadata that describes the resource. In addition to the required
    /// request fields, specify at least one of the following fields to update:
    /// </para><ul><li><para><c>HubContentDescription</c></para></li><li><para><c>HubContentDisplayName</c></para></li><li><para><c>HubContentMarkdown</c></para></li><li><para><c>HubContentSearchKeywords</c></para></li><li><para><c>SupportStatus</c></para></li></ul><para>
    /// For more information about hubs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/jumpstart-curated-hubs.html">Private
    /// curated hubs for foundation model access control in JumpStart</a>.
    /// </para><note><para>
    /// If you want to update a <c>ModelReference</c> resource in your hub, use the <c>UpdateHubContentResource</c>
    /// API instead.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SMHubContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateHubContentResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateHubContent API operation.", Operation = new[] {"UpdateHubContent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateHubContentResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateHubContentResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateHubContentResponse object containing multiple properties."
    )]
    public partial class UpdateSMHubContentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HubContentDescription
        /// <summary>
        /// <para>
        /// <para>The description of the hub content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentDescription { get; set; }
        #endregion
        
        #region Parameter HubContentDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the hub content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentDisplayName { get; set; }
        #endregion
        
        #region Parameter HubContentMarkdown
        /// <summary>
        /// <para>
        /// <para>A string that provides a description of the hub content. This string can include links,
        /// tables, and standard markdown formatting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentMarkdown { get; set; }
        #endregion
        
        #region Parameter HubContentName
        /// <summary>
        /// <para>
        /// <para>The name of the hub content resource that you want to update.</para>
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
        public System.String HubContentName { get; set; }
        #endregion
        
        #region Parameter HubContentSearchKeyword
        /// <summary>
        /// <para>
        /// <para>The searchable keywords of the hub content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HubContentSearchKeywords")]
        public System.String[] HubContentSearchKeyword { get; set; }
        #endregion
        
        #region Parameter HubContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the resource that you want to update. Only specify a <c>Model</c>
        /// or <c>Notebook</c> resource for this API. To update a <c>ModelReference</c>, use the
        /// <c>UpdateHubContentReference</c> API instead.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.HubContentType")]
        public Amazon.SageMaker.HubContentType HubContentType { get; set; }
        #endregion
        
        #region Parameter HubContentVersion
        /// <summary>
        /// <para>
        /// <para>The hub content version that you want to update. For example, if you have two versions
        /// of a resource in your hub, you can update the second version.</para>
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
        public System.String HubContentVersion { get; set; }
        #endregion
        
        #region Parameter HubName
        /// <summary>
        /// <para>
        /// <para>The name of the SageMaker hub that contains the hub content you want to update. You
        /// can optionally use the hub ARN instead.</para>
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
        public System.String HubName { get; set; }
        #endregion
        
        #region Parameter SupportStatus
        /// <summary>
        /// <para>
        /// <para>Indicates the current status of the hub content resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.HubContentSupportStatus")]
        public Amazon.SageMaker.HubContentSupportStatus SupportStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateHubContentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateHubContentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HubContentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMHubContent (UpdateHubContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateHubContentResponse, UpdateSMHubContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HubContentDescription = this.HubContentDescription;
            context.HubContentDisplayName = this.HubContentDisplayName;
            context.HubContentMarkdown = this.HubContentMarkdown;
            context.HubContentName = this.HubContentName;
            #if MODULAR
            if (this.HubContentName == null && ParameterWasBound(nameof(this.HubContentName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HubContentSearchKeyword != null)
            {
                context.HubContentSearchKeyword = new List<System.String>(this.HubContentSearchKeyword);
            }
            context.HubContentType = this.HubContentType;
            #if MODULAR
            if (this.HubContentType == null && ParameterWasBound(nameof(this.HubContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentVersion = this.HubContentVersion;
            #if MODULAR
            if (this.HubContentVersion == null && ParameterWasBound(nameof(this.HubContentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SupportStatus = this.SupportStatus;
            
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
            var request = new Amazon.SageMaker.Model.UpdateHubContentRequest();
            
            if (cmdletContext.HubContentDescription != null)
            {
                request.HubContentDescription = cmdletContext.HubContentDescription;
            }
            if (cmdletContext.HubContentDisplayName != null)
            {
                request.HubContentDisplayName = cmdletContext.HubContentDisplayName;
            }
            if (cmdletContext.HubContentMarkdown != null)
            {
                request.HubContentMarkdown = cmdletContext.HubContentMarkdown;
            }
            if (cmdletContext.HubContentName != null)
            {
                request.HubContentName = cmdletContext.HubContentName;
            }
            if (cmdletContext.HubContentSearchKeyword != null)
            {
                request.HubContentSearchKeywords = cmdletContext.HubContentSearchKeyword;
            }
            if (cmdletContext.HubContentType != null)
            {
                request.HubContentType = cmdletContext.HubContentType;
            }
            if (cmdletContext.HubContentVersion != null)
            {
                request.HubContentVersion = cmdletContext.HubContentVersion;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
            }
            if (cmdletContext.SupportStatus != null)
            {
                request.SupportStatus = cmdletContext.SupportStatus;
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
        
        private Amazon.SageMaker.Model.UpdateHubContentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateHubContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateHubContent");
            try
            {
                return client.UpdateHubContentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HubContentDescription { get; set; }
            public System.String HubContentDisplayName { get; set; }
            public System.String HubContentMarkdown { get; set; }
            public System.String HubContentName { get; set; }
            public List<System.String> HubContentSearchKeyword { get; set; }
            public Amazon.SageMaker.HubContentType HubContentType { get; set; }
            public System.String HubContentVersion { get; set; }
            public System.String HubName { get; set; }
            public Amazon.SageMaker.HubContentSupportStatus SupportStatus { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateHubContentResponse, UpdateSMHubContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
