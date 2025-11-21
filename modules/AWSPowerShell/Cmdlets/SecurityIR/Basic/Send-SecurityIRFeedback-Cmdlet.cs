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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Send feedback based on response investigation action
    /// </summary>
    [Cmdlet("Send", "SecurityIRFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Security Incident Response SendFeedback API operation.", Operation = new[] {"SendFeedback"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.SendFeedbackResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityIR.Model.SendFeedbackResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityIR.Model.SendFeedbackResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendSecurityIRFeedbackCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>Send feedback based on request caseID</para>
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
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>Send feedback based on request comments</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ResultId
        /// <summary>
        /// <para>
        /// <para>Send feedback based on request result ID</para>
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
        public System.String ResultId { get; set; }
        #endregion
        
        #region Parameter Usefulness
        /// <summary>
        /// <para>
        /// <para>Required enum value indicating user assessment of result q.....</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityIR.UsefulnessRating")]
        public Amazon.SecurityIR.UsefulnessRating Usefulness { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.SendFeedbackResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.CaseId),
                nameof(this.ResultId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SecurityIRFeedback (SendFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.SendFeedbackResponse, SendSecurityIRFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment = this.Comment;
            context.ResultId = this.ResultId;
            #if MODULAR
            if (this.ResultId == null && ParameterWasBound(nameof(this.ResultId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResultId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Usefulness = this.Usefulness;
            #if MODULAR
            if (this.Usefulness == null && ParameterWasBound(nameof(this.Usefulness)))
            {
                WriteWarning("You are passing $null as a value for parameter Usefulness which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityIR.Model.SendFeedbackRequest();
            
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.ResultId != null)
            {
                request.ResultId = cmdletContext.ResultId;
            }
            if (cmdletContext.Usefulness != null)
            {
                request.Usefulness = cmdletContext.Usefulness;
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
        
        private Amazon.SecurityIR.Model.SendFeedbackResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.SendFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "SendFeedback");
            try
            {
                return client.SendFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CaseId { get; set; }
            public System.String Comment { get; set; }
            public System.String ResultId { get; set; }
            public Amazon.SecurityIR.UsefulnessRating Usefulness { get; set; }
            public System.Func<Amazon.SecurityIR.Model.SendFeedbackResponse, SendSecurityIRFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
