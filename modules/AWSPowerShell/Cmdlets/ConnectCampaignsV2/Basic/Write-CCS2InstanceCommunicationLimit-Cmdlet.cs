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
    /// Put the instance communication limits. This API is idempotent.
    /// </summary>
    [Cmdlet("Write", "CCS2InstanceCommunicationLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 PutInstanceCommunicationLimits API operation.", Operation = new[] {"PutInstanceCommunicationLimits"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCCS2InstanceCommunicationLimitCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllChannelSubtypes_CommunicationLimitsList
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommunicationLimitsConfig_AllChannelSubtypes_CommunicationLimitsList")]
        public Amazon.ConnectCampaignsV2.Model.CommunicationLimit[] AllChannelSubtypes_CommunicationLimitsList { get; set; }
        #endregion
        
        #region Parameter ConnectInstanceId
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
        public System.String ConnectInstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CCS2InstanceCommunicationLimit (PutInstanceCommunicationLimits)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse, WriteCCS2InstanceCommunicationLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllChannelSubtypes_CommunicationLimitsList != null)
            {
                context.AllChannelSubtypes_CommunicationLimitsList = new List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit>(this.AllChannelSubtypes_CommunicationLimitsList);
            }
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsRequest();
            
            
             // populate CommunicationLimitsConfig
            request.CommunicationLimitsConfig = new Amazon.ConnectCampaignsV2.Model.InstanceCommunicationLimitsConfig();
            Amazon.ConnectCampaignsV2.Model.CommunicationLimits requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes = null;
            
             // populate AllChannelSubtypes
            var requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypesIsNull = true;
            requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes = new Amazon.ConnectCampaignsV2.Model.CommunicationLimits();
            List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit> requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList = null;
            if (cmdletContext.AllChannelSubtypes_CommunicationLimitsList != null)
            {
                requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList = cmdletContext.AllChannelSubtypes_CommunicationLimitsList;
            }
            if (requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList != null)
            {
                requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes.CommunicationLimitsList = requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList;
                requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypesIsNull = false;
            }
             // determine if requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes should be set to null
            if (requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypesIsNull)
            {
                requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes = null;
            }
            if (requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes != null)
            {
                request.CommunicationLimitsConfig.AllChannelSubtypes = requestCommunicationLimitsConfig_communicationLimitsConfig_AllChannelSubtypes;
            }
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
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
        
        private Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "PutInstanceCommunicationLimits");
            try
            {
                return client.PutInstanceCommunicationLimitsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit> AllChannelSubtypes_CommunicationLimitsList { get; set; }
            public System.String ConnectInstanceId { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.PutInstanceCommunicationLimitsResponse, WriteCCS2InstanceCommunicationLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
