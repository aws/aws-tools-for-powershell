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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Updates the campaign source with a campaign. This API is idempotent.
    /// </summary>
    [Cmdlet("Update", "CCS2CampaignSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 UpdateCampaignSource API operation.", Operation = new[] {"UpdateCampaignSource"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCS2CampaignSourceCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventTrigger_CustomerProfilesDomainArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EventTrigger_CustomerProfilesDomainArn")]
        public System.String EventTrigger_CustomerProfilesDomainArn { get; set; }
        #endregion
        
        #region Parameter Source_CustomerProfilesSegmentArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_CustomerProfilesSegmentArn { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCS2CampaignSource (UpdateCampaignSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse, UpdateCCS2CampaignSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_CustomerProfilesSegmentArn = this.Source_CustomerProfilesSegmentArn;
            context.EventTrigger_CustomerProfilesDomainArn = this.EventTrigger_CustomerProfilesDomainArn;
            
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
            var request = new Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.ConnectCampaignsV2.Model.Source();
            System.String requestSource_source_CustomerProfilesSegmentArn = null;
            if (cmdletContext.Source_CustomerProfilesSegmentArn != null)
            {
                requestSource_source_CustomerProfilesSegmentArn = cmdletContext.Source_CustomerProfilesSegmentArn;
            }
            if (requestSource_source_CustomerProfilesSegmentArn != null)
            {
                request.Source.CustomerProfilesSegmentArn = requestSource_source_CustomerProfilesSegmentArn;
                requestSourceIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.EventTrigger requestSource_source_EventTrigger = null;
            
             // populate EventTrigger
            var requestSource_source_EventTriggerIsNull = true;
            requestSource_source_EventTrigger = new Amazon.ConnectCampaignsV2.Model.EventTrigger();
            System.String requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn = null;
            if (cmdletContext.EventTrigger_CustomerProfilesDomainArn != null)
            {
                requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn = cmdletContext.EventTrigger_CustomerProfilesDomainArn;
            }
            if (requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn != null)
            {
                requestSource_source_EventTrigger.CustomerProfilesDomainArn = requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn;
                requestSource_source_EventTriggerIsNull = false;
            }
             // determine if requestSource_source_EventTrigger should be set to null
            if (requestSource_source_EventTriggerIsNull)
            {
                requestSource_source_EventTrigger = null;
            }
            if (requestSource_source_EventTrigger != null)
            {
                request.Source.EventTrigger = requestSource_source_EventTrigger;
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
        
        private Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "UpdateCampaignSource");
            try
            {
                return client.UpdateCampaignSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String Source_CustomerProfilesSegmentArn { get; set; }
            public System.String EventTrigger_CustomerProfilesDomainArn { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.UpdateCampaignSourceResponse, UpdateCCS2CampaignSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
