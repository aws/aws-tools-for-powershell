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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Registers a capability for an OpenSearch UI application. Use this operation to enable
    /// specific capabilities, such as AI features, for a given application. The capability
    /// configuration defines the type and settings of the capability to register. For more
    /// information about the AI features, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/application-ai-assistant.html">Agentic
    /// AI for OpenSearch UI</a>.
    /// </summary>
    [Cmdlet("Register", "OSCapability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.RegisterCapabilityResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service RegisterCapability API operation.", Operation = new[] {"RegisterCapability"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.RegisterCapabilityResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.RegisterCapabilityResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.RegisterCapabilityResponse object containing multiple properties."
    )]
    public partial class RegisterOSCapabilityCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapabilityConfig_AiConfig
        /// <summary>
        /// <para>
        /// <para>Configuration settings for AI-powered capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.OpenSearchService.Model.AIConfig CapabilityConfig_AiConfig { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the OpenSearch UI application to register the capability
        /// for.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter CapabilityName
        /// <summary>
        /// <para>
        /// <para>The name of the capability to register. Must be between 3 and 30 characters and contain
        /// only alphanumeric characters and hyphens. This identifies the type of capability being
        /// enabled for the application. For registering AI Assistant capability, use <c>ai-capability</c></para>
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
        public System.String CapabilityName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.RegisterCapabilityResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.RegisterCapabilityResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapabilityName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-OSCapability (RegisterCapability)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.RegisterCapabilityResponse, RegisterOSCapabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapabilityConfig_AiConfig = this.CapabilityConfig_AiConfig;
            context.CapabilityName = this.CapabilityName;
            #if MODULAR
            if (this.CapabilityName == null && ParameterWasBound(nameof(this.CapabilityName)))
            {
                WriteWarning("You are passing $null as a value for parameter CapabilityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.RegisterCapabilityRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate CapabilityConfig
            var requestCapabilityConfigIsNull = true;
            request.CapabilityConfig = new Amazon.OpenSearchService.Model.CapabilityBaseRequestConfig();
            Amazon.OpenSearchService.Model.AIConfig requestCapabilityConfig_capabilityConfig_AiConfig = null;
            if (cmdletContext.CapabilityConfig_AiConfig != null)
            {
                requestCapabilityConfig_capabilityConfig_AiConfig = cmdletContext.CapabilityConfig_AiConfig;
            }
            if (requestCapabilityConfig_capabilityConfig_AiConfig != null)
            {
                request.CapabilityConfig.AiConfig = requestCapabilityConfig_capabilityConfig_AiConfig;
                requestCapabilityConfigIsNull = false;
            }
             // determine if request.CapabilityConfig should be set to null
            if (requestCapabilityConfigIsNull)
            {
                request.CapabilityConfig = null;
            }
            if (cmdletContext.CapabilityName != null)
            {
                request.CapabilityName = cmdletContext.CapabilityName;
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
        
        private Amazon.OpenSearchService.Model.RegisterCapabilityResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.RegisterCapabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "RegisterCapability");
            try
            {
                return client.RegisterCapabilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Amazon.OpenSearchService.Model.AIConfig CapabilityConfig_AiConfig { get; set; }
            public System.String CapabilityName { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.RegisterCapabilityResponse, RegisterOSCapabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
