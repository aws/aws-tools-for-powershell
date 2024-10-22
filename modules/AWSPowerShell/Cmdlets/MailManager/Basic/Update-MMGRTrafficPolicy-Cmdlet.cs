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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Update attributes of an already provisioned traffic policy resource.
    /// </summary>
    [Cmdlet("Update", "MMGRTrafficPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager UpdateTrafficPolicy API operation.", Operation = new[] {"UpdateTrafficPolicy"}, SelectReturnType = typeof(Amazon.MailManager.Model.UpdateTrafficPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.MailManager.Model.UpdateTrafficPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MailManager.Model.UpdateTrafficPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMMGRTrafficPolicyCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultAction
        /// <summary>
        /// <para>
        /// <para>Default action instructs the traﬃc policy to either Allow or Deny (block) messages
        /// that fall outside of (or not addressed by) the conditions of your policy statements</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MailManager.AcceptAction")]
        public Amazon.MailManager.AcceptAction DefaultAction { get; set; }
        #endregion
        
        #region Parameter MaxMessageSizeByte
        /// <summary>
        /// <para>
        /// <para>The maximum message size in bytes of email which is allowed in by this traffic policy—anything
        /// larger will be blocked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxMessageSizeBytes")]
        public System.Int32? MaxMessageSizeByte { get; set; }
        #endregion
        
        #region Parameter PolicyStatement
        /// <summary>
        /// <para>
        /// <para>The list of conditions to be updated for filtering email traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyStatements")]
        public Amazon.MailManager.Model.PolicyStatement[] PolicyStatement { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the traffic policy that you want to update.</para>
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
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the traffic policy resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficPolicyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.UpdateTrafficPolicyResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficPolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MMGRTrafficPolicy (UpdateTrafficPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.UpdateTrafficPolicyResponse, UpdateMMGRTrafficPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultAction = this.DefaultAction;
            context.MaxMessageSizeByte = this.MaxMessageSizeByte;
            if (this.PolicyStatement != null)
            {
                context.PolicyStatement = new List<Amazon.MailManager.Model.PolicyStatement>(this.PolicyStatement);
            }
            context.TrafficPolicyId = this.TrafficPolicyId;
            #if MODULAR
            if (this.TrafficPolicyId == null && ParameterWasBound(nameof(this.TrafficPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyName = this.TrafficPolicyName;
            
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
            var request = new Amazon.MailManager.Model.UpdateTrafficPolicyRequest();
            
            if (cmdletContext.DefaultAction != null)
            {
                request.DefaultAction = cmdletContext.DefaultAction;
            }
            if (cmdletContext.MaxMessageSizeByte != null)
            {
                request.MaxMessageSizeBytes = cmdletContext.MaxMessageSizeByte.Value;
            }
            if (cmdletContext.PolicyStatement != null)
            {
                request.PolicyStatements = cmdletContext.PolicyStatement;
            }
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
            }
            if (cmdletContext.TrafficPolicyName != null)
            {
                request.TrafficPolicyName = cmdletContext.TrafficPolicyName;
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
        
        private Amazon.MailManager.Model.UpdateTrafficPolicyResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.UpdateTrafficPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "UpdateTrafficPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateTrafficPolicy(request);
                #elif CORECLR
                return client.UpdateTrafficPolicyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MailManager.AcceptAction DefaultAction { get; set; }
            public System.Int32? MaxMessageSizeByte { get; set; }
            public List<Amazon.MailManager.Model.PolicyStatement> PolicyStatement { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public System.String TrafficPolicyName { get; set; }
            public System.Func<Amazon.MailManager.Model.UpdateTrafficPolicyResponse, UpdateMMGRTrafficPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
