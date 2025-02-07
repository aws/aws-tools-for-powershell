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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Provision a new traffic policy resource.
    /// </summary>
    [Cmdlet("New", "MMGRTrafficPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateTrafficPolicy API operation.", Operation = new[] {"CreateTrafficPolicy"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateTrafficPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.CreateTrafficPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.CreateTrafficPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMMGRTrafficPolicyCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultAction
        /// <summary>
        /// <para>
        /// <para>Default action instructs the traﬃc policy to either Allow or Deny (block) messages
        /// that fall outside of (or not addressed by) the conditions of your policy statements</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// <para>Conditional statements for filtering email traffic.</para>
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
        [Alias("PolicyStatements")]
        public Amazon.MailManager.Model.PolicyStatement[] PolicyStatement { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for the resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MailManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the traffic policy resource.</para>
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
        public System.String TrafficPolicyName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that Amazon SES uses to recognize subsequent retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficPolicyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateTrafficPolicyResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateTrafficPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficPolicyId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficPolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRTrafficPolicy (CreateTrafficPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateTrafficPolicyResponse, NewMMGRTrafficPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DefaultAction = this.DefaultAction;
            #if MODULAR
            if (this.DefaultAction == null && ParameterWasBound(nameof(this.DefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxMessageSizeByte = this.MaxMessageSizeByte;
            if (this.PolicyStatement != null)
            {
                context.PolicyStatement = new List<Amazon.MailManager.Model.PolicyStatement>(this.PolicyStatement);
            }
            #if MODULAR
            if (this.PolicyStatement == null && ParameterWasBound(nameof(this.PolicyStatement)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStatement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MailManager.Model.Tag>(this.Tag);
            }
            context.TrafficPolicyName = this.TrafficPolicyName;
            #if MODULAR
            if (this.TrafficPolicyName == null && ParameterWasBound(nameof(this.TrafficPolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.CreateTrafficPolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MailManager.Model.CreateTrafficPolicyResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateTrafficPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateTrafficPolicy");
            try
            {
                #if DESKTOP
                return client.CreateTrafficPolicy(request);
                #elif CORECLR
                return client.CreateTrafficPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.MailManager.AcceptAction DefaultAction { get; set; }
            public System.Int32? MaxMessageSizeByte { get; set; }
            public List<Amazon.MailManager.Model.PolicyStatement> PolicyStatement { get; set; }
            public List<Amazon.MailManager.Model.Tag> Tag { get; set; }
            public System.String TrafficPolicyName { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateTrafficPolicyResponse, NewMMGRTrafficPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficPolicyId;
        }
        
    }
}
