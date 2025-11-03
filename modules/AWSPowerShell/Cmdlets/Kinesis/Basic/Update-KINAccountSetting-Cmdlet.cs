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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Updates the account-level settings for Amazon Kinesis Data Streams.
    /// 
    ///  
    /// <para>
    /// Updating account settings is a synchronous operation. Upon receiving the request,
    /// Kinesis Data Streams will return immediately with your account’s updated settings.
    /// </para><para><b>API limits</b></para><ul><li><para>
    /// Certain account configurations have minimum commitment windows. Attempting to update
    /// your settings prior to the end of the minimum commitment window might have certain
    /// restrictions.
    /// </para></li><li><para>
    /// This API has a call limit of 5 transactions per second (TPS) for each Amazon Web Services
    /// account. TPS over 5 will initiate the <c>LimitExceededException</c>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "KINAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput or Amazon.Kinesis.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput object.",
        "The service call response (type Amazon.Kinesis.Model.UpdateAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINAccountSettingCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MinimumThroughputBillingCommitment_Status
        /// <summary>
        /// <para>
        /// <para>The desired status of the minimum throughput billing commitment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kinesis.MinimumThroughputBillingCommitmentInputStatus")]
        public Amazon.Kinesis.MinimumThroughputBillingCommitmentInputStatus MinimumThroughputBillingCommitment_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MinimumThroughputBillingCommitment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MinimumThroughputBillingCommitment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MinimumThroughputBillingCommitment_Status), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateAccountSettingsResponse, UpdateKINAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MinimumThroughputBillingCommitment_Status = this.MinimumThroughputBillingCommitment_Status;
            #if MODULAR
            if (this.MinimumThroughputBillingCommitment_Status == null && ParameterWasBound(nameof(this.MinimumThroughputBillingCommitment_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter MinimumThroughputBillingCommitment_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.UpdateAccountSettingsRequest();
            
            
             // populate MinimumThroughputBillingCommitment
            var requestMinimumThroughputBillingCommitmentIsNull = true;
            request.MinimumThroughputBillingCommitment = new Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentInput();
            Amazon.Kinesis.MinimumThroughputBillingCommitmentInputStatus requestMinimumThroughputBillingCommitment_minimumThroughputBillingCommitment_Status = null;
            if (cmdletContext.MinimumThroughputBillingCommitment_Status != null)
            {
                requestMinimumThroughputBillingCommitment_minimumThroughputBillingCommitment_Status = cmdletContext.MinimumThroughputBillingCommitment_Status;
            }
            if (requestMinimumThroughputBillingCommitment_minimumThroughputBillingCommitment_Status != null)
            {
                request.MinimumThroughputBillingCommitment.Status = requestMinimumThroughputBillingCommitment_minimumThroughputBillingCommitment_Status;
                requestMinimumThroughputBillingCommitmentIsNull = false;
            }
             // determine if request.MinimumThroughputBillingCommitment should be set to null
            if (requestMinimumThroughputBillingCommitmentIsNull)
            {
                request.MinimumThroughputBillingCommitment = null;
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
        
        private Amazon.Kinesis.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateAccountSettings");
            try
            {
                return client.UpdateAccountSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Kinesis.MinimumThroughputBillingCommitmentInputStatus MinimumThroughputBillingCommitment_Status { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateAccountSettingsResponse, UpdateKINAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MinimumThroughputBillingCommitment;
        }
        
    }
}
