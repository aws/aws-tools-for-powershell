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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Executes an action on a target resource.
    /// </summary>
    [Cmdlet("Start", "IOTSWAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT SiteWise ExecuteAction API operation.", Operation = new[] {"ExecuteAction"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.ExecuteActionResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTSiteWise.Model.ExecuteActionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTSiteWise.Model.ExecuteActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTSWActionCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionDefinitionId
        /// <summary>
        /// <para>
        /// <para>The ID of the action definition.</para>
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
        public System.String ActionDefinitionId { get; set; }
        #endregion
        
        #region Parameter ResolveTo_AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset that the resource resolves to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResolveTo_AssetId { get; set; }
        #endregion
        
        #region Parameter TargetResource_AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetResource_AssetId { get; set; }
        #endregion
        
        #region Parameter TargetResource_ComputationModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the computation model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetResource_ComputationModelId { get; set; }
        #endregion
        
        #region Parameter ActionPayload_StringValue
        /// <summary>
        /// <para>
        /// <para>The payload of the action in a JSON string.</para>
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
        public System.String ActionPayload_StringValue { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ActionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.ExecuteActionResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.ExecuteActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ActionId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTSWAction (ExecuteAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.ExecuteActionResponse, StartIOTSWActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionDefinitionId = this.ActionDefinitionId;
            #if MODULAR
            if (this.ActionDefinitionId == null && ParameterWasBound(nameof(this.ActionDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionPayload_StringValue = this.ActionPayload_StringValue;
            #if MODULAR
            if (this.ActionPayload_StringValue == null && ParameterWasBound(nameof(this.ActionPayload_StringValue)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionPayload_StringValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ResolveTo_AssetId = this.ResolveTo_AssetId;
            context.TargetResource_AssetId = this.TargetResource_AssetId;
            context.TargetResource_ComputationModelId = this.TargetResource_ComputationModelId;
            
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
            var request = new Amazon.IoTSiteWise.Model.ExecuteActionRequest();
            
            if (cmdletContext.ActionDefinitionId != null)
            {
                request.ActionDefinitionId = cmdletContext.ActionDefinitionId;
            }
            
             // populate ActionPayload
            var requestActionPayloadIsNull = true;
            request.ActionPayload = new Amazon.IoTSiteWise.Model.ActionPayload();
            System.String requestActionPayload_actionPayload_StringValue = null;
            if (cmdletContext.ActionPayload_StringValue != null)
            {
                requestActionPayload_actionPayload_StringValue = cmdletContext.ActionPayload_StringValue;
            }
            if (requestActionPayload_actionPayload_StringValue != null)
            {
                request.ActionPayload.StringValue = requestActionPayload_actionPayload_StringValue;
                requestActionPayloadIsNull = false;
            }
             // determine if request.ActionPayload should be set to null
            if (requestActionPayloadIsNull)
            {
                request.ActionPayload = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ResolveTo
            var requestResolveToIsNull = true;
            request.ResolveTo = new Amazon.IoTSiteWise.Model.ResolveTo();
            System.String requestResolveTo_resolveTo_AssetId = null;
            if (cmdletContext.ResolveTo_AssetId != null)
            {
                requestResolveTo_resolveTo_AssetId = cmdletContext.ResolveTo_AssetId;
            }
            if (requestResolveTo_resolveTo_AssetId != null)
            {
                request.ResolveTo.AssetId = requestResolveTo_resolveTo_AssetId;
                requestResolveToIsNull = false;
            }
             // determine if request.ResolveTo should be set to null
            if (requestResolveToIsNull)
            {
                request.ResolveTo = null;
            }
            
             // populate TargetResource
            request.TargetResource = new Amazon.IoTSiteWise.Model.TargetResource();
            System.String requestTargetResource_targetResource_AssetId = null;
            if (cmdletContext.TargetResource_AssetId != null)
            {
                requestTargetResource_targetResource_AssetId = cmdletContext.TargetResource_AssetId;
            }
            if (requestTargetResource_targetResource_AssetId != null)
            {
                request.TargetResource.AssetId = requestTargetResource_targetResource_AssetId;
            }
            System.String requestTargetResource_targetResource_ComputationModelId = null;
            if (cmdletContext.TargetResource_ComputationModelId != null)
            {
                requestTargetResource_targetResource_ComputationModelId = cmdletContext.TargetResource_ComputationModelId;
            }
            if (requestTargetResource_targetResource_ComputationModelId != null)
            {
                request.TargetResource.ComputationModelId = requestTargetResource_targetResource_ComputationModelId;
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
        
        private Amazon.IoTSiteWise.Model.ExecuteActionResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.ExecuteActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "ExecuteAction");
            try
            {
                return client.ExecuteActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActionDefinitionId { get; set; }
            public System.String ActionPayload_StringValue { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ResolveTo_AssetId { get; set; }
            public System.String TargetResource_AssetId { get; set; }
            public System.String TargetResource_ComputationModelId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.ExecuteActionResponse, StartIOTSWActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ActionId;
        }
        
    }
}
