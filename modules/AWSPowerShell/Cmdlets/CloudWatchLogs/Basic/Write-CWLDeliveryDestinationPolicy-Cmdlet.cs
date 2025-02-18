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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates and assigns an IAM policy that grants permissions to CloudWatch Logs to deliver
    /// logs cross-account to a specified destination in this account. To configure the delivery
    /// of logs from an Amazon Web Services service in another account to a logs delivery
    /// destination in the current account, you must do the following:
    /// 
    ///  <ul><li><para>
    /// Create a delivery source, which is a logical object that represents the resource that
    /// is actually sending the logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliverySource.html">PutDeliverySource</a>.
    /// </para></li><li><para>
    /// Create a <i>delivery destination</i>, which is a logical object that represents the
    /// actual delivery destination. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestination.html">PutDeliveryDestination</a>.
    /// </para></li><li><para>
    /// Use this operation in the destination account to assign an IAM policy to the destination.
    /// This policy allows delivery to that destination. 
    /// </para></li><li><para>
    /// Create a <i>delivery</i> by pairing exactly one delivery source and one delivery destination.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_CreateDelivery.html">CreateDelivery</a>.
    /// </para></li></ul><para>
    /// Only some Amazon Web Services services support being configured as a delivery source.
    /// These services are listed as <b>Supported [V2 Permissions]</b> in the table at <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/AWS-logs-and-resource-policy.html">Enabling
    /// logging from Amazon Web Services services.</a></para><para>
    /// The contents of the policy must include two statements. One statement enables general
    /// logs delivery, and the other allows delivery to the chosen destination. See the examples
    /// for the needed policies.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDeliveryDestinationPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.Policy")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutDeliveryDestinationPolicy API operation.", Operation = new[] {"PutDeliveryDestinationPolicy"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.Policy or Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.Policy object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLDeliveryDestinationPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliveryDestinationName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery destination to assign this policy to.</para>
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
        public System.String DeliveryDestinationName { get; set; }
        #endregion
        
        #region Parameter DeliveryDestinationPolicy
        /// <summary>
        /// <para>
        /// <para>The contents of the policy.</para>
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
        public System.String DeliveryDestinationPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryDestinationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDeliveryDestinationPolicy (PutDeliveryDestinationPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse, WriteCWLDeliveryDestinationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryDestinationName = this.DeliveryDestinationName;
            #if MODULAR
            if (this.DeliveryDestinationName == null && ParameterWasBound(nameof(this.DeliveryDestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryDestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryDestinationPolicy = this.DeliveryDestinationPolicy;
            #if MODULAR
            if (this.DeliveryDestinationPolicy == null && ParameterWasBound(nameof(this.DeliveryDestinationPolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryDestinationPolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyRequest();
            
            if (cmdletContext.DeliveryDestinationName != null)
            {
                request.DeliveryDestinationName = cmdletContext.DeliveryDestinationName;
            }
            if (cmdletContext.DeliveryDestinationPolicy != null)
            {
                request.DeliveryDestinationPolicy = cmdletContext.DeliveryDestinationPolicy;
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
        
        private Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutDeliveryDestinationPolicy");
            try
            {
                return client.PutDeliveryDestinationPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeliveryDestinationName { get; set; }
            public System.String DeliveryDestinationPolicy { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutDeliveryDestinationPolicyResponse, WriteCWLDeliveryDestinationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
