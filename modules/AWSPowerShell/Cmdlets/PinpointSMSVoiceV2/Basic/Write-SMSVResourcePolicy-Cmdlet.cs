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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Attaches a resource-based policy to a AWS End User Messaging SMS and Voice resource(phone
    /// number, sender Id, phone poll, or opt-out list) that is used for sharing the resource.
    /// A shared resource can be a Pool, Opt-out list, Sender Id, or Phone number. For more
    /// information about resource-based policies, see <a href="https://docs.aws.amazon.com/sms-voice/latest/userguide/shared-resources.html">Working
    /// with shared resources</a> in the <i>AWS End User Messaging SMS User Guide</i>.
    /// </summary>
    [Cmdlet("Write", "SMSVResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse object containing multiple properties."
    )]
    public partial class WriteSMSVResourcePolicyCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The JSON formatted resource-based policy to attach.</para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS End User Messaging SMS and Voice resource
        /// to attach the resource-based policy to.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMSVResourcePolicy (PutResourcePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse, WriteSMSVResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "PutResourcePolicy");
            try
            {
                return client.PutResourcePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Policy { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.PutResourcePolicyResponse, WriteSMSVResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
