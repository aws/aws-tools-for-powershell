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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Retrieve all the deliverability data for a specific campaign. This data is available
    /// for a campaign only if the campaign sent email by using a domain that the Deliverability
    /// dashboard is enabled for (<c>PutDeliverabilityDashboardOption</c> operation).
    /// </summary>
    [Cmdlet("Get", "PINEDomainDeliverabilityCampaign")]
    [OutputType("Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email GetDomainDeliverabilityCampaign API operation.", Operation = new[] {"GetDomainDeliverabilityCampaign"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse))]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign or Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse",
        "This cmdlet returns an Amazon.PinpointEmail.Model.DomainDeliverabilityCampaign object.",
        "The service call response (type Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPINEDomainDeliverabilityCampaignCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CampaignId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the campaign. Amazon Pinpoint automatically generates and
        /// assigns this identifier to a campaign. This value is not the same as the campaign
        /// identifier that Amazon Pinpoint assigns to campaigns that you create and manage by
        /// using the Amazon Pinpoint API or the Amazon Pinpoint console.</para>
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
        public System.String CampaignId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainDeliverabilityCampaign'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse).
        /// Specifying the name of a property of type Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainDeliverabilityCampaign";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CampaignId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CampaignId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CampaignId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse, GetPINEDomainDeliverabilityCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CampaignId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CampaignId = this.CampaignId;
            #if MODULAR
            if (this.CampaignId == null && ParameterWasBound(nameof(this.CampaignId)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignRequest();
            
            if (cmdletContext.CampaignId != null)
            {
                request.CampaignId = cmdletContext.CampaignId;
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
        
        private Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "GetDomainDeliverabilityCampaign");
            try
            {
                #if DESKTOP
                return client.GetDomainDeliverabilityCampaign(request);
                #elif CORECLR
                return client.GetDomainDeliverabilityCampaignAsync(request).GetAwaiter().GetResult();
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
            public System.String CampaignId { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.GetDomainDeliverabilityCampaignResponse, GetPINEDomainDeliverabilityCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainDeliverabilityCampaign;
        }
        
    }
}
