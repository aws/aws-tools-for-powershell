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
    /// The <c>NotifyWorkers</c> operation sends an email to one or more Workers that you
    /// specify with the Worker ID. You can specify up to 100 Worker IDs to send the same
    /// message with a single call to the NotifyWorkers operation. The NotifyWorkers operation
    /// will send a notification email to a Worker only if you have previously approved or
    /// rejected work from the Worker.
    /// </summary>
    [Cmdlet("Send", "MTRWorkerNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MTurk.Model.NotifyWorkersFailureStatus")]
    [AWSCmdlet("Calls the Amazon MTurk Service NotifyWorkers API operation.", Operation = new[] {"NotifyWorkers"}, SelectReturnType = typeof(Amazon.MTurk.Model.NotifyWorkersResponse))]
    [AWSCmdletOutput("Amazon.MTurk.Model.NotifyWorkersFailureStatus or Amazon.MTurk.Model.NotifyWorkersResponse",
        "This cmdlet returns a collection of Amazon.MTurk.Model.NotifyWorkersFailureStatus objects.",
        "The service call response (type Amazon.MTurk.Model.NotifyWorkersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMTRWorkerNotificationCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MessageText
        /// <summary>
        /// <para>
        /// <para>The text of the email message to send. Can include up to 4,096 characters</para>
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
        public System.String MessageText { get; set; }
        #endregion
        
        #region Parameter Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the email message to send. Can include up to 200 characters.</para>
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
        public System.String Subject { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>A list of Worker IDs you wish to notify. You can notify upto 100 Workers at a time.</para>
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
        [Alias("WorkerIds")]
        public System.String[] WorkerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotifyWorkersFailureStatuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.NotifyWorkersResponse).
        /// Specifying the name of a property of type Amazon.MTurk.Model.NotifyWorkersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotifyWorkersFailureStatuses";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MTRWorkerNotification (NotifyWorkers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.NotifyWorkersResponse, SendMTRWorkerNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MessageText = this.MessageText;
            #if MODULAR
            if (this.MessageText == null && ParameterWasBound(nameof(this.MessageText)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subject = this.Subject;
            #if MODULAR
            if (this.Subject == null && ParameterWasBound(nameof(this.Subject)))
            {
                WriteWarning("You are passing $null as a value for parameter Subject which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WorkerId != null)
            {
                context.WorkerId = new List<System.String>(this.WorkerId);
            }
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
            var request = new Amazon.MTurk.Model.NotifyWorkersRequest();
            
            if (cmdletContext.MessageText != null)
            {
                request.MessageText = cmdletContext.MessageText;
            }
            if (cmdletContext.Subject != null)
            {
                request.Subject = cmdletContext.Subject;
            }
            if (cmdletContext.WorkerId != null)
            {
                request.WorkerIds = cmdletContext.WorkerId;
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
        
        private Amazon.MTurk.Model.NotifyWorkersResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.NotifyWorkersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "NotifyWorkers");
            try
            {
                #if DESKTOP
                return client.NotifyWorkers(request);
                #elif CORECLR
                return client.NotifyWorkersAsync(request).GetAwaiter().GetResult();
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
            public System.String MessageText { get; set; }
            public System.String Subject { get; set; }
            public List<System.String> WorkerId { get; set; }
            public System.Func<Amazon.MTurk.Model.NotifyWorkersResponse, SendMTRWorkerNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotifyWorkersFailureStatuses;
        }
        
    }
}
