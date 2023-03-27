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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Creates a SIP rule, which can be used to run a SIP media application as a target for
    /// a specific trigger type. For more information about SIP rules, see <a href="https://docs.aws.amazon.com/chime-sdk/latest/ag/manage-sip-applications.html">Managing
    /// SIP media applications and rules</a> in the <i>Amazon Chime SDK Administrator Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMVOSipRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.SipRule")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateSipRule API operation.", Operation = new[] {"CreateSipRule"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.SipRule or Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.SipRule object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMVOSipRuleCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        #region Parameter Disabled
        /// <summary>
        /// <para>
        /// <para>Disables or enables a SIP rule. You must disable SIP rules before you can delete them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Disabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SIP rule.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TargetApplication
        /// <summary>
        /// <para>
        /// <para>List of SIP media applications, with priority and AWS Region. Only one SIP application
        /// per AWS Region can be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetApplications")]
        public Amazon.ChimeSDKVoice.Model.SipRuleTargetApplication[] TargetApplication { get; set; }
        #endregion
        
        #region Parameter TriggerType
        /// <summary>
        /// <para>
        /// <para>The type of trigger assigned to the SIP rule in <code>TriggerValue</code>, currently
        /// <code>RequestUriHostname</code> or <code>ToPhoneNumber</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.SipRuleTriggerType")]
        public Amazon.ChimeSDKVoice.SipRuleTriggerType TriggerType { get; set; }
        #endregion
        
        #region Parameter TriggerValue
        /// <summary>
        /// <para>
        /// <para>If <code>TriggerType</code> is <code>RequestUriHostname</code>, the value can be the
        /// outbound host name of a Voice Connector. If <code>TriggerType</code> is <code>ToPhoneNumber</code>,
        /// the value can be a customer-owned phone number in the E164 format. The <code>SipMediaApplication</code>
        /// specified in the <code>SipRule</code> is triggered if the request URI in an incoming
        /// SIP request matches the <code>RequestUriHostname</code>, or if the <code>To</code>
        /// header in the incoming SIP request matches the <code>ToPhoneNumber</code> value.</para>
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
        public System.String TriggerValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SipRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SipRule";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOSipRule (CreateSipRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse, NewCHMVOSipRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Disabled = this.Disabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetApplication != null)
            {
                context.TargetApplication = new List<Amazon.ChimeSDKVoice.Model.SipRuleTargetApplication>(this.TargetApplication);
            }
            context.TriggerType = this.TriggerType;
            #if MODULAR
            if (this.TriggerType == null && ParameterWasBound(nameof(this.TriggerType)))
            {
                WriteWarning("You are passing $null as a value for parameter TriggerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TriggerValue = this.TriggerValue;
            #if MODULAR
            if (this.TriggerValue == null && ParameterWasBound(nameof(this.TriggerValue)))
            {
                WriteWarning("You are passing $null as a value for parameter TriggerValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateSipRuleRequest();
            
            if (cmdletContext.Disabled != null)
            {
                request.Disabled = cmdletContext.Disabled.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TargetApplication != null)
            {
                request.TargetApplications = cmdletContext.TargetApplication;
            }
            if (cmdletContext.TriggerType != null)
            {
                request.TriggerType = cmdletContext.TriggerType;
            }
            if (cmdletContext.TriggerValue != null)
            {
                request.TriggerValue = cmdletContext.TriggerValue;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateSipRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateSipRule");
            try
            {
                #if DESKTOP
                return client.CreateSipRule(request);
                #elif CORECLR
                return client.CreateSipRuleAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Disabled { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.SipRuleTargetApplication> TargetApplication { get; set; }
            public Amazon.ChimeSDKVoice.SipRuleTriggerType TriggerType { get; set; }
            public System.String TriggerValue { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateSipRuleResponse, NewCHMVOSipRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SipRule;
        }
        
    }
}
