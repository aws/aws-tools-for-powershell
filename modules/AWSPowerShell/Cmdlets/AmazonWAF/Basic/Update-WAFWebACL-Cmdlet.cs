/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Inserts or deletes <a>ActivatedRule</a> objects in a <code>WebACL</code>. Each <code>Rule</code>
    /// identifies web requests that you want to allow, block, or count. When you update a
    /// <code>WebACL</code>, you specify the following values:
    /// 
    ///  <ul><li>A default action for the <code>WebACL</code>, either <code>ALLOW</code>
    /// or <code>BLOCK</code>. AWS WAF performs the default action if a request doesn't match
    /// the criteria in any of the <code>Rules</code> in a <code>WebACL</code>.</li><li>The
    /// <code>Rules</code> that you want to add and/or delete. If you want to replace one
    /// <code>Rule</code> with another, you delete the existing <code>Rule</code> and add
    /// the new one.</li><li>For each <code>Rule</code>, whether you want AWS WAF to allow
    /// requests, block requests, or count requests that match the conditions in the <code>Rule</code>.</li><li>The order in which you want AWS WAF to evaluate the <code>Rules</code> in a <code>WebACL</code>.
    /// If you add more than one <code>Rule</code> to a <code>WebACL</code>, AWS WAF evaluates
    /// each request against the <code>Rules</code> in order based on the value of <code>Priority</code>.
    /// (The <code>Rule</code> that has the lowest value for <code>Priority</code> is evaluated
    /// first.) When a web request matches all of the predicates (such as <code>ByteMatchSets</code>
    /// and <code>IPSets</code>) in a <code>Rule</code>, AWS WAF immediately takes the corresponding
    /// action, allow or block, and doesn't evaluate the request against the remaining <code>Rules</code>
    /// in the <code>WebACL</code>, if any. </li><li>The CloudFront distribution that you
    /// want to associate with the <code>WebACL</code>.</li></ul><para>
    /// To create and configure a <code>WebACL</code>, perform the following steps:
    /// </para><ol><li>Create and update the predicates that you want to include in <code>Rules</code>.
    /// For more information, see <a>CreateByteMatchSet</a>, <a>UpdateByteMatchSet</a>, <a>CreateIPSet</a>,
    /// <a>UpdateIPSet</a>, <a>CreateSqlInjectionMatchSet</a>, and <a>UpdateSqlInjectionMatchSet</a>.</li><li>Create and update the <code>Rules</code> that you want to include in the <code>WebACL</code>.
    /// For more information, see <a>CreateRule</a> and <a>UpdateRule</a>.</li><li>Create
    /// a <code>WebACL</code>. See <a>CreateWebACL</a>.</li><li>Use <code>GetChangeToken</code>
    /// to get the change token that you provide in the <code>ChangeToken</code> parameter
    /// of an <a>UpdateWebACL</a> request.</li><li>Submit an <code>UpdateWebACL</code> request
    /// to specify the <code>Rules</code> that you want to include in the <code>WebACL</code>,
    /// to specify the default action, and to associate the <code>WebACL</code> with a CloudFront
    /// distribution. </li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFWebACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateWebACL operation against AWS WAF.", Operation = new[] {"UpdateWebACL"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateWebACLResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateWAFWebACLCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter DefaultAction_Type
        /// <summary>
        /// <para>
        /// <para>Specifies how you want AWS WAF to respond to requests that match the settings in a
        /// <code>Rule</code>. Valid settings include the following:</para><ul><li><code>ALLOW</code>: AWS WAF allows requests</li><li><code>BLOCK</code>:
        /// AWS WAF blocks requests</li><li><code>COUNT</code>: AWS WAF increments a counter
        /// of the requests that match all of the conditions in the rule. AWS WAF then continues
        /// to inspect the web request based on the remaining rules in the web ACL. You can't
        /// specify <code>COUNT</code> for the default action for a <code>WebACL</code>.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WAF.WafActionType")]
        public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of updates to make to the <a>WebACL</a>.</para><para>An array of <code>WebACLUpdate</code> objects that you want to insert into or delete
        /// from a <a>WebACL</a>. For more information, see the applicable data types:</para><ul><li><a>WebACLUpdate</a>: Contains <code>Action</code> and <code>ActivatedRule</code></li><li><a>ActivatedRule</a>: Contains <code>Action</code>, <code>Priority</code>, and
        /// <code>RuleId</code></li><li><a>WafAction</a>: Contains <code>Type</code></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.WebACLUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter WebACLId
        /// <summary>
        /// <para>
        /// <para>The <code>WebACLId</code> of the <a>WebACL</a> that you want to update. <code>WebACLId</code>
        /// is returned by <a>CreateWebACL</a> and by <a>ListWebACLs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WebACLId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WebACLId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFWebACL (UpdateWebACL)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ChangeToken = this.ChangeToken;
            context.DefaultAction_Type = this.DefaultAction_Type;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.WebACLUpdate>(this.Update);
            }
            context.WebACLId = this.WebACLId;
            
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
            bool requestDefaultActionIsNull = true;
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
            if (cmdletContext.Updates != null)
            {
                request.Updates = cmdletContext.Updates;
            }
            if (cmdletContext.WebACLId != null)
            {
                request.WebACLId = cmdletContext.WebACLId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.WAF.Model.UpdateWebACLResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateWebACLRequest request)
        {
            return client.UpdateWebACL(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public Amazon.WAF.WafActionType DefaultAction_Type { get; set; }
            public List<Amazon.WAF.Model.WebACLUpdate> Updates { get; set; }
            public System.String WebACLId { get; set; }
        }
        
    }
}
