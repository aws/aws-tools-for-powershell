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
    /// Updates the contents of a SageMaker hub for a <c>ModelReference</c> resource. A <c>ModelReference</c>
    /// allows you to access public SageMaker JumpStart models from within your private hub.
    /// 
    ///  
    /// <para>
    /// When using this API, you can update the <c>MinVersion</c> field for additional flexibility
    /// in the model version. You shouldn't update any additional fields when using this API,
    /// because the metadata in your private hub should match the public JumpStart model's
    /// metadata.
    /// </para><note><para>
    /// If you want to update a <c>Model</c> or <c>Notebook</c> resource in your hub, use
    /// the <c>UpdateHubContent</c> API instead.
    /// </para></note><para>
    /// For more information about adding model references to your hub, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/jumpstart-curated-hubs-admin-guide-add-models.html">
    /// Add models to a private hub</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMHubContentReference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateHubContentReferenceResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateHubContentReference API operation.", Operation = new[] {"UpdateHubContentReference"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateHubContentReferenceResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateHubContentReferenceResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateHubContentReferenceResponse object containing multiple properties."
    )]
    public partial class UpdateSMHubContentReferenceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter HubContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the resource that you want to update. Only specify a <c>ModelReference</c>
        /// resource for this API. To update a <c>Model</c> or <c>Notebook</c> resource, use the
        /// <c>UpdateHubContent</c> API instead.</para>
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
        
        #region Parameter MinVersion
        /// <summary>
        /// <para>
        /// <para>The minimum hub content version of the referenced model that you want to use. The
        /// minimum version must be older than the latest available version of the referenced
        /// model. To support all versions of a model, set the value to <c>1.0.0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MinVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateHubContentReferenceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateHubContentReferenceResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMHubContentReference (UpdateHubContentReference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateHubContentReferenceResponse, UpdateSMHubContentReferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HubContentName = this.HubContentName;
            #if MODULAR
            if (this.HubContentName == null && ParameterWasBound(nameof(this.HubContentName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentType = this.HubContentType;
            #if MODULAR
            if (this.HubContentType == null && ParameterWasBound(nameof(this.HubContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinVersion = this.MinVersion;
            
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
            var request = new Amazon.SageMaker.Model.UpdateHubContentReferenceRequest();
            
            if (cmdletContext.HubContentName != null)
            {
                request.HubContentName = cmdletContext.HubContentName;
            }
            if (cmdletContext.HubContentType != null)
            {
                request.HubContentType = cmdletContext.HubContentType;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
            }
            if (cmdletContext.MinVersion != null)
            {
                request.MinVersion = cmdletContext.MinVersion;
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
        
        private Amazon.SageMaker.Model.UpdateHubContentReferenceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateHubContentReferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateHubContentReference");
            try
            {
                return client.UpdateHubContentReferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HubContentName { get; set; }
            public Amazon.SageMaker.HubContentType HubContentType { get; set; }
            public System.String HubName { get; set; }
            public System.String MinVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateHubContentReferenceResponse, UpdateSMHubContentReferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
