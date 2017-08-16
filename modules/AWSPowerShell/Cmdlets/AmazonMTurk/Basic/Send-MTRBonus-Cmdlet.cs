/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// The <code>SendBonus</code> operation issues a payment of money from your account
    /// to a Worker. This payment happens separately from the reward you pay to the Worker
    /// when you approve the Worker's assignment. The SendBonus operation requires the Worker's
    /// ID and the assignment ID as parameters to initiate payment of the bonus. You must
    /// include a message that explains the reason for the bonus payment, as the Worker may
    /// not be expecting the payment. Amazon Mechanical Turk collects a fee for bonus payments,
    /// similar to the HIT listing fee. This operation fails if your account does not have
    /// enough funds to pay for both the bonus and the fees.
    /// </summary>
    [Cmdlet("Send", "MTRBonus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SendBonus operation against Amazon MTurk Service.", Operation = new[] {"SendBonus"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the WorkerId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.MTurk.Model.SendBonusResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMTRBonusCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AssignmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the assignment for which this bonus is paid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String BonusAmount { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>A message that explains the reason for the bonus payment. The Worker receiving the
        /// bonus can see this message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String UniqueRequestToken { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>The ID of the Worker being paid the bonus.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WorkerId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the WorkerId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WorkerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MTRBonus (SendBonus)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssignmentId = this.AssignmentId;
            context.BonusAmount = this.BonusAmount;
            context.Reason = this.Reason;
            context.UniqueRequestToken = this.UniqueRequestToken;
            context.WorkerId = this.WorkerId;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.WorkerId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendBonusAsync(request);
                return task.Result;
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
        }
        
    }
}
