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
    /// The <code>ApproveAssignment</code> operation approves the results of a completed
    /// assignment. 
    /// 
    ///  
    /// <para>
    ///  Approving an assignment initiates two payments from the Requester's Amazon.com account
    /// 
    /// </para><ul><li><para>
    ///  The Worker who submitted the results is paid the reward specified in the HIT. 
    /// </para></li><li><para>
    ///  Amazon Mechanical Turk fees are debited. 
    /// </para></li></ul><para>
    ///  If the Requester's account does not have adequate funds for these payments, the call
    /// to ApproveAssignment returns an exception, and the approval is not processed. You
    /// can include an optional feedback message with the approval, which the Worker can see
    /// in the Status section of the web site. 
    /// </para><para>
    ///  You can also call this operation for assignments that were previous rejected and
    /// approve them by explicitly overriding the previous rejection. This only works on rejected
    /// assignments that were submitted within the previous 30 days and only if the assignment's
    /// related HIT has not been deleted. 
    /// </para>
    /// </summary>
    [Cmdlet("Approve", "MTRAssignment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service ApproveAssignment API operation.", Operation = new[] {"ApproveAssignment"}, SelectReturnType = typeof(Amazon.MTurk.Model.ApproveAssignmentResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.ApproveAssignmentResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.ApproveAssignmentResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveMTRAssignmentCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AssignmentId
        /// <summary>
        /// <para>
        /// <para> The ID of the assignment. The assignment must correspond to a HIT created by the
        /// Requester. </para>
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
        public System.String AssignmentId { get; set; }
        #endregion
        
        #region Parameter OverrideRejection
        /// <summary>
        /// <para>
        /// <para> A flag indicating that an assignment should be approved even if it was previously
        /// rejected. Defaults to <code>False</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OverrideRejection { get; set; }
        #endregion
        
        #region Parameter RequesterFeedback
        /// <summary>
        /// <para>
        /// <para> A message for the Worker, which the Worker can see in the Status section of the web
        /// site. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequesterFeedback { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.ApproveAssignmentResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssignmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssignmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssignmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssignmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-MTRAssignment (ApproveAssignment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.ApproveAssignmentResponse, ApproveMTRAssignmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssignmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssignmentId = this.AssignmentId;
            #if MODULAR
            if (this.AssignmentId == null && ParameterWasBound(nameof(this.AssignmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssignmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OverrideRejection = this.OverrideRejection;
            context.RequesterFeedback = this.RequesterFeedback;
            
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
            var request = new Amazon.MTurk.Model.ApproveAssignmentRequest();
            
            if (cmdletContext.AssignmentId != null)
            {
                request.AssignmentId = cmdletContext.AssignmentId;
            }
            if (cmdletContext.OverrideRejection != null)
            {
                request.OverrideRejection = cmdletContext.OverrideRejection.Value;
            }
            if (cmdletContext.RequesterFeedback != null)
            {
                request.RequesterFeedback = cmdletContext.RequesterFeedback;
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
        
        private Amazon.MTurk.Model.ApproveAssignmentResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.ApproveAssignmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "ApproveAssignment");
            try
            {
                #if DESKTOP
                return client.ApproveAssignment(request);
                #elif CORECLR
                return client.ApproveAssignmentAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? OverrideRejection { get; set; }
            public System.String RequesterFeedback { get; set; }
            public System.Func<Amazon.MTurk.Model.ApproveAssignmentResponse, ApproveMTRAssignmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
