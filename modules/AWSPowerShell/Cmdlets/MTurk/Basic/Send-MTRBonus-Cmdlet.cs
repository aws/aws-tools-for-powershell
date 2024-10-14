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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>SendBonus</c> operation issues a payment of money from your account to a Worker.
    /// This payment happens separately from the reward you pay to the Worker when you approve
    /// the Worker's assignment. The SendBonus operation requires the Worker's ID and the
    /// assignment ID as parameters to initiate payment of the bonus. You must include a message
    /// that explains the reason for the bonus payment, as the Worker may not be expecting
    /// the payment. Amazon Mechanical Turk collects a fee for bonus payments, similar to
    /// the HIT listing fee. This operation fails if your account does not have enough funds
    /// to pay for both the bonus and the fees.
    /// </summary>
    [Cmdlet("Send", "MTRBonus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service SendBonus API operation.", Operation = new[] {"SendBonus"}, SelectReturnType = typeof(Amazon.MTurk.Model.SendBonusResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.SendBonusResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.SendBonusResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendMTRBonusCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssignmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the assignment for which this bonus is paid.</para>
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
        public System.String AssignmentId { get; set; }
        #endregion
        
        #region Parameter BonusAmount
        /// <summary>
        /// <para>
        /// <para> The Bonus amount is a US Dollar amount specified using a string (for example, "5"
        /// represents $5.00 USD and "101.42" represents $101.42 USD). Do not include currency
        /// symbols or currency codes. </para>
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
        public System.String BonusAmount { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>A message that explains the reason for the bonus payment. The Worker receiving the
        /// bonus can see this message.</para>
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
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter UniqueRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this request, which allows you to retry the call on error
        /// without granting multiple bonuses. This is useful in cases such as network timeouts
        /// where it is unclear whether or not the call succeeded on the server. If the bonus
        /// already exists in the system from a previous call using the same UniqueRequestToken,
        /// subsequent calls will return an error with a message containing the request ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UniqueRequestToken { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>The ID of the Worker being paid the bonus.</para>
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
        public System.String WorkerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.SendBonusResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkerId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MTRBonus (SendBonus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.SendBonusResponse, SendMTRBonusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssignmentId = this.AssignmentId;
            #if MODULAR
            if (this.AssignmentId == null && ParameterWasBound(nameof(this.AssignmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssignmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BonusAmount = this.BonusAmount;
            #if MODULAR
            if (this.BonusAmount == null && ParameterWasBound(nameof(this.BonusAmount)))
            {
                WriteWarning("You are passing $null as a value for parameter BonusAmount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            #if MODULAR
            if (this.Reason == null && ParameterWasBound(nameof(this.Reason)))
            {
                WriteWarning("You are passing $null as a value for parameter Reason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UniqueRequestToken = this.UniqueRequestToken;
            context.WorkerId = this.WorkerId;
            #if MODULAR
            if (this.WorkerId == null && ParameterWasBound(nameof(this.WorkerId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.SendBonusRequest();
            
            if (cmdletContext.AssignmentId != null)
            {
                request.AssignmentId = cmdletContext.AssignmentId;
            }
            if (cmdletContext.BonusAmount != null)
            {
                request.BonusAmount = cmdletContext.BonusAmount;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.UniqueRequestToken != null)
            {
                request.UniqueRequestToken = cmdletContext.UniqueRequestToken;
            }
            if (cmdletContext.WorkerId != null)
            {
                request.WorkerId = cmdletContext.WorkerId;
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
        
        private Amazon.MTurk.Model.SendBonusResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.SendBonusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "SendBonus");
            try
            {
                #if DESKTOP
                return client.SendBonus(request);
                #elif CORECLR
                return client.SendBonusAsync(request).GetAwaiter().GetResult();
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
            public System.String AssignmentId { get; set; }
            public System.String BonusAmount { get; set; }
            public System.String Reason { get; set; }
            public System.String UniqueRequestToken { get; set; }
            public System.String WorkerId { get; set; }
            public System.Func<Amazon.MTurk.Model.SendBonusResponse, SendMTRBonusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
