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
    /// Inserts or deletes <a>ActivatedRule</a> objects in a <c>WebACL</c>. Each <c>Rule</c>
    /// identifies web requests that you want to allow, block, or count. When you update a
    /// <c>WebACL</c>, you specify the following values:
    /// </para><ul><li><para>
    /// A default action for the <c>WebACL</c>, either <c>ALLOW</c> or <c>BLOCK</c>. AWS WAF
    /// performs the default action if a request doesn't match the criteria in any of the
    /// <c>Rules</c> in a <c>WebACL</c>.
    /// </para></li><li><para>
    /// The <c>Rules</c> that you want to add or delete. If you want to replace one <c>Rule</c>
    /// with another, you delete the existing <c>Rule</c> and add the new one.
    /// </para></li><li><para>
    /// For each <c>Rule</c>, whether you want AWS WAF to allow requests, block requests,
    /// or count requests that match the conditions in the <c>Rule</c>.
    /// </para></li><li><para>
    /// The order in which you want AWS WAF to evaluate the <c>Rules</c> in a <c>WebACL</c>.
    /// If you add more than one <c>Rule</c> to a <c>WebACL</c>, AWS WAF evaluates each request
    /// against the <c>Rules</c> in order based on the value of <c>Priority</c>. (The <c>Rule</c>
    /// that has the lowest value for <c>Priority</c> is evaluated first.) When a web request
    /// matches all the predicates (such as <c>ByteMatchSets</c> and <c>IPSets</c>) in a <c>Rule</c>,
    /// AWS WAF immediately takes the corresponding action, allow or block, and doesn't evaluate
    /// the request against the remaining <c>Rules</c> in the <c>WebACL</c>, if any. 
    /// </para></li></ul><para>
    /// To create and configure a <c>WebACL</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Create and update the predicates that you want to include in <c>Rules</c>. For more
    /// information, see <a>CreateByteMatchSet</a>, <a>UpdateByteMatchSet</a>, <a>CreateIPSet</a>,
    /// <a>UpdateIPSet</a>, <a>CreateSqlInjectionMatchSet</a>, and <a>UpdateSqlInjectionMatchSet</a>.
    /// </para></li><li><para>
    /// Create and update the <c>Rules</c> that you want to include in the <c>WebACL</c>.
    /// For more information, see <a>CreateRule</a> and <a>UpdateRule</a>.
    /// </para></li><li><para>
    /// Create a <c>WebACL</c>. See <a>CreateWebACL</a>.
    /// </para></li><li><para>
    /// Use <c>GetChangeToken</c> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <a>UpdateWebACL</a> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateWebACL</c> request to specify the <c>Rules</c> that you want to
    /// include in the <c>WebACL</c>, to specify the default action, and to associate the
    /// <c>WebACL</c> with a CloudFront distribution. 
    /// </para><para>
    /// The <c>ActivatedRule</c> can be a rule group. If you specify a rule group as your
    /// <c>ActivatedRule</c> , you can exclude specific rules from that rule group.
    /// </para><para>
    /// If you already have a rule group associated with a web ACL and want to submit an <c>UpdateWebACL</c>
    /// request to exclude certain rules from that rule group, you must first remove the rule
    /// group from the web ACL, the re-insert it again, specifying the excluded rules. For
    /// details, see <a>ActivatedRule$ExcludedRules</a> . 
    /// </para></li></ol><para>
    /// Be aware that if you try to add a RATE_BASED rule to a web ACL without setting the
    /// rule type when first creating the rule, the <a>UpdateWebACL</a> request will fail
    /// because the request tries to add a REGULAR rule (the default rule type) with the specified
    /// ID, which does not exist. 
    /// </para><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFWebACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateWebACL API operation.", Operation = new[] {"UpdateWebACL"}, SelectReturnType = typeof(Amazon.WAF.Model.UpdateWebACLResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAF.Model.UpdateWebACLResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAF.Model.UpdateWebACLResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFWebACLCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter DefaultAction_Type
        /// <summary>
        /// <para>
        /// <para>Specifies how you want AWS WAF to respond to requests that match the settings in a
        /// <c>Rule</c>. Valid settings include the following:</para><ul><li><para><c>ALLOW</c>: AWS WAF allows requests</para></li><li><para><c>BLOCK</c>: AWS WAF blocks requests</para></li><li><para><c>COUNT</c>: AWS WAF increments a counter of the requests that match all of the
        /// conditions in the rule. AWS WAF then continues to inspect the web request based on
        /// the remaining rules in the web ACL. You can't specify <c>COUNT</c> for the default
        /// action for a <c>WebACL</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAF.WafActionType")]
        public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of updates to make to the <a>WebACL</a>.</para><para>An array of <c>WebACLUpdate</c> objects that you want to insert into or delete from
        /// a <a>WebACL</a>. For more information, see the applicable data types:</para><ul><li><para><a>WebACLUpdate</a>: Contains <c>Action</c> and <c>ActivatedRule</c></para></li><li><para><a>ActivatedRule</a>: Contains <c>Action</c>, <c>OverrideAction</c>, <c>Priority</c>,
        /// <c>RuleId</c>, and <c>Type</c>. <c>ActivatedRule|OverrideAction</c> applies only when
        /// updating or adding a <c>RuleGroup</c> to a <c>WebACL</c>. In this case, you do not
        /// use <c>ActivatedRule|Action</c>. For all other update requests, <c>ActivatedRule|Action</c>
        /// is used instead of <c>ActivatedRule|OverrideAction</c>. </para></li><li><para><a>WafAction</a>: Contains <c>Type</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Updates")]
        public Amazon.WAF.Model.WebACLUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter WebACLId
        /// <summary>
        /// <para>
        /// <para>The <c>WebACLId</c> of the <a>WebACL</a> that you want to update. <c>WebACLId</c>
        /// is returned by <a>CreateWebACL</a> and by <a>ListWebACLs</a>.</para>
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
        public System.String WebACLId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.UpdateWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.UpdateWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WebACLId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WebACLId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WebACLId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebACLId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFWebACL (UpdateWebACL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.UpdateWebACLResponse, UpdateWAFWebACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WebACLId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultAction_Type = this.DefaultAction_Type;
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAF.Model.WebACLUpdate>(this.Update);
            }
            context.WebACLId = this.WebACLId;
            #if MODULAR
            if (this.WebACLId == null && ParameterWasBound(nameof(this.WebACLId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebACLId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.UpdateWebACLRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            
             // populate DefaultAction
            var requestDefaultActionIsNull = true;
            request.DefaultAction = new Amazon.WAF.Model.WafAction();
            Amazon.WAF.WafActionType requestDefaultAction_defaultAction_Type = null;
            if (cmdletContext.DefaultAction_Type != null)
            {
                requestDefaultAction_defaultAction_Type = cmdletContext.DefaultAction_Type;
            }
            if (requestDefaultAction_defaultAction_Type != null)
            {
                request.DefaultAction.Type = requestDefaultAction_defaultAction_Type;
                requestDefaultActionIsNull = false;
            }
             // determine if request.DefaultAction should be set to null
            if (requestDefaultActionIsNull)
            {
                request.DefaultAction = null;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
            }
            if (cmdletContext.WebACLId != null)
            {
                request.WebACLId = cmdletContext.WebACLId;
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
        
        private Amazon.WAF.Model.UpdateWebACLResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateWebACL");
            try
            {
                #if DESKTOP
                return client.UpdateWebACL(request);
                #elif CORECLR
                return client.UpdateWebACLAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
            public List<Amazon.WAF.Model.WebACLUpdate> Update { get; set; }
            public System.String WebACLId { get; set; }
            public System.Func<Amazon.WAF.Model.UpdateWebACLResponse, UpdateWAFWebACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
