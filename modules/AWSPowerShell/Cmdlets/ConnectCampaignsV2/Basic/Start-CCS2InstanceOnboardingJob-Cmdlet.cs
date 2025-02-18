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
    /// Onboard the specific Amazon Connect instance to Connect Campaigns.
    /// </summary>
    [Cmdlet("Start", "CCS2InstanceOnboardingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCampaignsV2.Model.InstanceOnboardingJobStatus")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 StartInstanceOnboardingJob API operation.", Operation = new[] {"StartInstanceOnboardingJob"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse))]
    [AWSCmdletOutput("Amazon.ConnectCampaignsV2.Model.InstanceOnboardingJobStatus or Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse",
        "This cmdlet returns an Amazon.ConnectCampaignsV2.Model.InstanceOnboardingJobStatus object.",
        "The service call response (type Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCCS2InstanceOnboardingJobCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter EncryptionConfig_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? EncryptionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_EncryptionType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectCampaignsV2.EncryptionType")]
        public Amazon.ConnectCampaignsV2.EncryptionType EncryptionConfig_EncryptionType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_KeyArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfig_KeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectInstanceOnboardingJobStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse).
        /// Specifying the name of a property of type Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectInstanceOnboardingJobStatus";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CCS2InstanceOnboardingJob (StartInstanceOnboardingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse, StartCCS2InstanceOnboardingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfig_Enabled = this.EncryptionConfig_Enabled;
            #if MODULAR
            if (this.EncryptionConfig_Enabled == null && ParameterWasBound(nameof(this.EncryptionConfig_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionConfig_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfig_EncryptionType = this.EncryptionConfig_EncryptionType;
            context.EncryptionConfig_KeyArn = this.EncryptionConfig_KeyArn;
            
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
            var request = new Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobRequest();
            
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
            }
            
             // populate EncryptionConfig
            var requestEncryptionConfigIsNull = true;
            request.EncryptionConfig = new Amazon.ConnectCampaignsV2.Model.EncryptionConfig();
            System.Boolean? requestEncryptionConfig_encryptionConfig_Enabled = null;
            if (cmdletContext.EncryptionConfig_Enabled != null)
            {
                requestEncryptionConfig_encryptionConfig_Enabled = cmdletContext.EncryptionConfig_Enabled.Value;
            }
            if (requestEncryptionConfig_encryptionConfig_Enabled != null)
            {
                request.EncryptionConfig.Enabled = requestEncryptionConfig_encryptionConfig_Enabled.Value;
                requestEncryptionConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.EncryptionType requestEncryptionConfig_encryptionConfig_EncryptionType = null;
            if (cmdletContext.EncryptionConfig_EncryptionType != null)
            {
                requestEncryptionConfig_encryptionConfig_EncryptionType = cmdletContext.EncryptionConfig_EncryptionType;
            }
            if (requestEncryptionConfig_encryptionConfig_EncryptionType != null)
            {
                request.EncryptionConfig.EncryptionType = requestEncryptionConfig_encryptionConfig_EncryptionType;
                requestEncryptionConfigIsNull = false;
            }
            System.String requestEncryptionConfig_encryptionConfig_KeyArn = null;
            if (cmdletContext.EncryptionConfig_KeyArn != null)
            {
                requestEncryptionConfig_encryptionConfig_KeyArn = cmdletContext.EncryptionConfig_KeyArn;
            }
            if (requestEncryptionConfig_encryptionConfig_KeyArn != null)
            {
                request.EncryptionConfig.KeyArn = requestEncryptionConfig_encryptionConfig_KeyArn;
                requestEncryptionConfigIsNull = false;
            }
             // determine if request.EncryptionConfig should be set to null
            if (requestEncryptionConfigIsNull)
            {
                request.EncryptionConfig = null;
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
        
        private Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "StartInstanceOnboardingJob");
            try
            {
                return client.StartInstanceOnboardingJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectInstanceId { get; set; }
            public System.Boolean? EncryptionConfig_Enabled { get; set; }
            public Amazon.ConnectCampaignsV2.EncryptionType EncryptionConfig_EncryptionType { get; set; }
            public System.String EncryptionConfig_KeyArn { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.StartInstanceOnboardingJobResponse, StartCCS2InstanceOnboardingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectInstanceOnboardingJobStatus;
        }
        
    }
}
