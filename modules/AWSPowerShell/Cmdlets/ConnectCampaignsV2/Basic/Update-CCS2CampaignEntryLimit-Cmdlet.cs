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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Updates the entry limits config for a campaign. This API is idempotent.
    /// </summary>
    [Cmdlet("Update", "CCS2CampaignEntryLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 UpdateCampaignEntryLimits API operation.", Operation = new[] {"UpdateCampaignEntryLimits"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCS2CampaignEntryLimitCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter EntryLimitsConfig_MaxEntryCount
        /// <summary>
        /// <para>
        /// <para>Maximum number of times a participant can enter the campaign. A value of 0 indicates
        /// unlimited entries. Values of 1 or greater specify the exact number of entries allowed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? EntryLimitsConfig_MaxEntryCount { get; set; }
        #endregion
        
        #region Parameter EntryLimitsConfig_MinEntryInterval
        /// <summary>
        /// <para>
        /// <para>Minimum time interval that must pass before a participant can enter the campaign again.</para>
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
        public System.String EntryLimitsConfig_MinEntryInterval { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCS2CampaignEntryLimit (UpdateCampaignEntryLimits)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse, UpdateCCS2CampaignEntryLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EntryLimitsConfig_MaxEntryCount = this.EntryLimitsConfig_MaxEntryCount;
            #if MODULAR
            if (this.EntryLimitsConfig_MaxEntryCount == null && ParameterWasBound(nameof(this.EntryLimitsConfig_MaxEntryCount)))
            {
                WriteWarning("You are passing $null as a value for parameter EntryLimitsConfig_MaxEntryCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntryLimitsConfig_MinEntryInterval = this.EntryLimitsConfig_MinEntryInterval;
            #if MODULAR
            if (this.EntryLimitsConfig_MinEntryInterval == null && ParameterWasBound(nameof(this.EntryLimitsConfig_MinEntryInterval)))
            {
                WriteWarning("You are passing $null as a value for parameter EntryLimitsConfig_MinEntryInterval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsRequest();
            
            
             // populate EntryLimitsConfig
            var requestEntryLimitsConfigIsNull = true;
            request.EntryLimitsConfig = new Amazon.ConnectCampaignsV2.Model.EntryLimitsConfig();
            System.Int32? requestEntryLimitsConfig_entryLimitsConfig_MaxEntryCount = null;
            if (cmdletContext.EntryLimitsConfig_MaxEntryCount != null)
            {
                requestEntryLimitsConfig_entryLimitsConfig_MaxEntryCount = cmdletContext.EntryLimitsConfig_MaxEntryCount.Value;
            }
            if (requestEntryLimitsConfig_entryLimitsConfig_MaxEntryCount != null)
            {
                request.EntryLimitsConfig.MaxEntryCount = requestEntryLimitsConfig_entryLimitsConfig_MaxEntryCount.Value;
                requestEntryLimitsConfigIsNull = false;
            }
            System.String requestEntryLimitsConfig_entryLimitsConfig_MinEntryInterval = null;
            if (cmdletContext.EntryLimitsConfig_MinEntryInterval != null)
            {
                requestEntryLimitsConfig_entryLimitsConfig_MinEntryInterval = cmdletContext.EntryLimitsConfig_MinEntryInterval;
            }
            if (requestEntryLimitsConfig_entryLimitsConfig_MinEntryInterval != null)
            {
                request.EntryLimitsConfig.MinEntryInterval = requestEntryLimitsConfig_entryLimitsConfig_MinEntryInterval;
                requestEntryLimitsConfigIsNull = false;
            }
             // determine if request.EntryLimitsConfig should be set to null
            if (requestEntryLimitsConfigIsNull)
            {
                request.EntryLimitsConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "UpdateCampaignEntryLimits");
            try
            {
                return client.UpdateCampaignEntryLimitsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? EntryLimitsConfig_MaxEntryCount { get; set; }
            public System.String EntryLimitsConfig_MinEntryInterval { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.UpdateCampaignEntryLimitsResponse, UpdateCCS2CampaignEntryLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
