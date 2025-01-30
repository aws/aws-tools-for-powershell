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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Returns the <a>RuleGroup</a> that is specified by the <c>RuleGroupId</c> that you
    /// included in the <c>GetRuleGroup</c> request.
    /// </para><para>
    /// To view the rules in a rule group, use <a>ListActivatedRulesInRuleGroup</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFRuleGroup")]
    [OutputType("Amazon.WAF.Model.RuleGroup")]
    [AWSCmdlet("Calls the AWS WAF GetRuleGroup API operation.", Operation = new[] {"GetRuleGroup"}, SelectReturnType = typeof(Amazon.WAF.Model.GetRuleGroupResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.RuleGroup or Amazon.WAF.Model.GetRuleGroupResponse",
        "This cmdlet returns an Amazon.WAF.Model.RuleGroup object.",
        "The service call response (type Amazon.WAF.Model.GetRuleGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAFRuleGroupCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RuleGroupId
        /// <summary>
        /// <para>
        /// <para>The <c>RuleGroupId</c> of the <a>RuleGroup</a> that you want to get. <c>RuleGroupId</c>
        /// is returned by <a>CreateRuleGroup</a> and by <a>ListRuleGroups</a>.</para>
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
        public System.String RuleGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.GetRuleGroupResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.GetRuleGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleGroupId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.GetRuleGroupResponse, GetWAFRuleGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RuleGroupId = this.RuleGroupId;
            #if MODULAR
            if (this.RuleGroupId == null && ParameterWasBound(nameof(this.RuleGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.GetRuleGroupRequest();
            
            if (cmdletContext.RuleGroupId != null)
            {
                request.RuleGroupId = cmdletContext.RuleGroupId;
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
        
        private Amazon.WAF.Model.GetRuleGroupResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.GetRuleGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "GetRuleGroup");
            try
            {
                #if DESKTOP
                return client.GetRuleGroup(request);
                #elif CORECLR
                return client.GetRuleGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String RuleGroupId { get; set; }
            public System.Func<Amazon.WAF.Model.GetRuleGroupResponse, GetWAFRuleGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleGroup;
        }
        
    }
}
