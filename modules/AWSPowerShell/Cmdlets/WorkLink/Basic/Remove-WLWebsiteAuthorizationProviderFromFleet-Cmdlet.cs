/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WorkLink;
using Amazon.WorkLink.Model;

namespace Amazon.PowerShell.Cmdlets.WL
{
    /// <summary>
    /// Disassociates a website authorization provider from a specified fleet. After the disassociation,
    /// users can't load any associated websites that require this authorization provider.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Remove", "WLWebsiteAuthorizationProviderFromFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkLink DisassociateWebsiteAuthorizationProvider API operation.", Operation = new[] {"DisassociateWebsiteAuthorizationProvider"}, SelectReturnType = typeof(Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse))]
    [AWSCmdletOutput("None or Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("Amazon WorkLink is no longer supported. This will be removed in a future version of the SDK.")]
    public partial class RemoveWLWebsiteAuthorizationProviderFromFleetCmdlet : AmazonWorkLinkClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizationProviderId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the authorization provider.</para>
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
        public System.String AuthorizationProviderId { get; set; }
        #endregion
        
        #region Parameter FleetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the fleet.</para>
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
        public System.String FleetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WLWebsiteAuthorizationProviderFromFleet (DisassociateWebsiteAuthorizationProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse, RemoveWLWebsiteAuthorizationProviderFromFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthorizationProviderId = this.AuthorizationProviderId;
            #if MODULAR
            if (this.AuthorizationProviderId == null && ParameterWasBound(nameof(this.AuthorizationProviderId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationProviderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetArn = this.FleetArn;
            #if MODULAR
            if (this.FleetArn == null && ParameterWasBound(nameof(this.FleetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderRequest();
            
            if (cmdletContext.AuthorizationProviderId != null)
            {
                request.AuthorizationProviderId = cmdletContext.AuthorizationProviderId;
            }
            if (cmdletContext.FleetArn != null)
            {
                request.FleetArn = cmdletContext.FleetArn;
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
        
        private Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse CallAWSServiceOperation(IAmazonWorkLink client, Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkLink", "DisassociateWebsiteAuthorizationProvider");
            try
            {
                #if DESKTOP
                return client.DisassociateWebsiteAuthorizationProvider(request);
                #elif CORECLR
                return client.DisassociateWebsiteAuthorizationProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthorizationProviderId { get; set; }
            public System.String FleetArn { get; set; }
            public System.Func<Amazon.WorkLink.Model.DisassociateWebsiteAuthorizationProviderResponse, RemoveWLWebsiteAuthorizationProviderFromFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
