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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Permanently deletes a <a>RateBasedRule</a>. You can't delete a rule if it's still
    /// used in any <code>WebACL</code> objects or if it still includes any predicates, such
    /// as <code>ByteMatchSet</code> objects.
    /// </para><para>
    /// If you just want to remove a rule from a <code>WebACL</code>, use <a>UpdateWebACL</a>.
    /// </para><para>
    /// To permanently delete a <code>RateBasedRule</code> from AWS WAF, perform the following
    /// steps:
    /// </para><ol><li><para>
    /// Update the <code>RateBasedRule</code> to remove predicates, if any. For more information,
    /// see <a>UpdateRateBasedRule</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>DeleteRateBasedRule</code> request.
    /// </para></li><li><para>
    /// Submit a <code>DeleteRateBasedRule</code> request.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Remove", "WAFRRateBasedRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional DeleteRateBasedRule API operation.", Operation = new[] {"DeleteRateBasedRule"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveWAFRRateBasedRuleCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
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
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para>The <code>RuleId</code> of the <a>RateBasedRule</a> that you want to delete. <code>RuleId</code>
        /// is returned by <a>CreateRateBasedRule</a> and by <a>ListRateBasedRules</a>.</para>
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
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WAFRRateBasedRule (DeleteRateBasedRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse, RemoveWAFRRateBasedRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleId = this.RuleId;
            #if MODULAR
            if (this.RuleId == null && ParameterWasBound(nameof(this.RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFRegional.Model.DeleteRateBasedRuleRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
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
        
        private Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.DeleteRateBasedRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "DeleteRateBasedRule");
            try
            {
                #if DESKTOP
                return client.DeleteRateBasedRule(request);
                #elif CORECLR
                return client.DeleteRateBasedRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public System.String RuleId { get; set; }
            public System.Func<Amazon.WAFRegional.Model.DeleteRateBasedRuleResponse, RemoveWAFRRateBasedRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
