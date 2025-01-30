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
using Amazon.BackupGateway;
using Amazon.BackupGateway.Model;

namespace Amazon.PowerShell.Cmdlets.BUGW
{
    /// <summary>
    /// This action sets the bandwidth rate limit schedule for a specified gateway. By default,
    /// gateways do not have a bandwidth rate limit schedule, which means no bandwidth rate
    /// limiting is in effect. Use this to initiate a gateway's bandwidth rate limit schedule.
    /// </summary>
    [Cmdlet("Write", "BUGWBandwidthRateLimitSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Backup Gateway PutBandwidthRateLimitSchedule API operation.", Operation = new[] {"PutBandwidthRateLimitSchedule"}, SelectReturnType = typeof(Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse))]
    [AWSCmdletOutput("System.String or Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteBUGWBandwidthRateLimitScheduleCmdlet : AmazonBackupGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BandwidthRateLimitInterval
        /// <summary>
        /// <para>
        /// <para>An array containing bandwidth rate limit schedule intervals for a gateway. When no
        /// bandwidth rate limit intervals have been scheduled, the array is empty.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("BandwidthRateLimitIntervals")]
        public Amazon.BackupGateway.Model.BandwidthRateLimitInterval[] BandwidthRateLimitInterval { get; set; }
        #endregion
        
        #region Parameter GatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway. Use the <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/API_BGW_ListGateways.html"><c>ListGateways</c></a> operation to return a list of gateways for your account and
        /// Amazon Web Services Region.</para>
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
        public System.String GatewayArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse).
        /// Specifying the name of a property of type Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BUGWBandwidthRateLimitSchedule (PutBandwidthRateLimitSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse, WriteBUGWBandwidthRateLimitScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BandwidthRateLimitInterval != null)
            {
                context.BandwidthRateLimitInterval = new List<Amazon.BackupGateway.Model.BandwidthRateLimitInterval>(this.BandwidthRateLimitInterval);
            }
            #if MODULAR
            if (this.BandwidthRateLimitInterval == null && ParameterWasBound(nameof(this.BandwidthRateLimitInterval)))
            {
                WriteWarning("You are passing $null as a value for parameter BandwidthRateLimitInterval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayArn = this.GatewayArn;
            #if MODULAR
            if (this.GatewayArn == null && ParameterWasBound(nameof(this.GatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleRequest();
            
            if (cmdletContext.BandwidthRateLimitInterval != null)
            {
                request.BandwidthRateLimitIntervals = cmdletContext.BandwidthRateLimitInterval;
            }
            if (cmdletContext.GatewayArn != null)
            {
                request.GatewayArn = cmdletContext.GatewayArn;
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
        
        private Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse CallAWSServiceOperation(IAmazonBackupGateway client, Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Gateway", "PutBandwidthRateLimitSchedule");
            try
            {
                #if DESKTOP
                return client.PutBandwidthRateLimitSchedule(request);
                #elif CORECLR
                return client.PutBandwidthRateLimitScheduleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BackupGateway.Model.BandwidthRateLimitInterval> BandwidthRateLimitInterval { get; set; }
            public System.String GatewayArn { get; set; }
            public System.Func<Amazon.BackupGateway.Model.PutBandwidthRateLimitScheduleResponse, WriteBUGWBandwidthRateLimitScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayArn;
        }
        
    }
}
