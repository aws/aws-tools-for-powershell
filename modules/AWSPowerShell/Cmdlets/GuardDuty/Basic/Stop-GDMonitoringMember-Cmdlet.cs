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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Stops GuardDuty monitoring for the specified member accounts. Use the <c>StartMonitoringMembers</c>
    /// operation to restart monitoring for those accounts.
    /// 
    ///  
    /// <para>
    /// With <c>autoEnableOrganizationMembers</c> configuration for your organization set
    /// to <c>ALL</c>, you'll receive an error if you attempt to stop monitoring the member
    /// accounts in your organization.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "GDMonitoringMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GuardDuty.Model.UnprocessedAccount")]
    [AWSCmdlet("Calls the Amazon GuardDuty StopMonitoringMembers API operation.", Operation = new[] {"StopMonitoringMembers"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.StopMonitoringMembersResponse))]
    [AWSCmdletOutput("Amazon.GuardDuty.Model.UnprocessedAccount or Amazon.GuardDuty.Model.StopMonitoringMembersResponse",
        "This cmdlet returns a collection of Amazon.GuardDuty.Model.UnprocessedAccount objects.",
        "The service call response (type Amazon.GuardDuty.Model.StopMonitoringMembersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopGDMonitoringMemberCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>A list of account IDs for the member accounts to stop monitoring.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the detector associated with the GuardDuty administrator account
        /// that is monitoring member accounts.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
        /// GuardDuty console, or run the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_ListDetectors.html">ListDetectors</a>
        /// API.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnprocessedAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.StopMonitoringMembersResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.StopMonitoringMembersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnprocessedAccounts";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-GDMonitoringMember (StopMonitoringMembers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.StopMonitoringMembersResponse, StopGDMonitoringMemberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GuardDuty.Model.StopMonitoringMembersRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
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
        
        private Amazon.GuardDuty.Model.StopMonitoringMembersResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.StopMonitoringMembersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "StopMonitoringMembers");
            try
            {
                return client.StopMonitoringMembersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.String DetectorId { get; set; }
            public System.Func<Amazon.GuardDuty.Model.StopMonitoringMembersResponse, StopGDMonitoringMemberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnprocessedAccounts;
        }
        
    }
}
