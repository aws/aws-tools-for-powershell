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
    /// Creates a <a>SqlInjectionMatchSet</a>, which you use to allow, block, or count requests
    /// that contain snippets of SQL code in a specified part of web requests. AWS WAF searches
    /// for character sequences that are likely to be malicious strings.
    /// 
    ///  
    /// <para>
    /// To create and configure a <code>SqlInjectionMatchSet</code>, perform the following
    /// steps:
    /// </para><ol><li>Use <a>GetChangeToken</a> to get the change token that you provide in the
    /// <code>ChangeToken</code> parameter of a <code>CreateSqlInjectionMatchSet</code> request.</li><li>Submit a <code>CreateSqlInjectionMatchSet</code> request.</li><li>Use <code>GetChangeToken</code>
    /// to get the change token that you provide in the <code>ChangeToken</code> parameter
    /// of an <a>UpdateSqlInjectionMatchSet</a> request.</li><li>Submit an <a>UpdateSqlInjectionMatchSet</a>
    /// request to specify the parts of web requests in which you want to allow, block, or
    /// count malicious SQL code.</li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFSqlInjectionMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAF.Model.CreateSqlInjectionMatchSetResponse")]
    [AWSCmdlet("Invokes the CreateSqlInjectionMatchSet operation against AWS WAF.", Operation = new[] {"CreateSqlInjectionMatchSet"})]
    [AWSCmdletOutput("Amazon.WAF.Model.CreateSqlInjectionMatchSetResponse",
        "This cmdlet returns a Amazon.WAF.Model.CreateSqlInjectionMatchSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewWAFSqlInjectionMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the <a>SqlInjectionMatchSet</a> that you're creating.
        /// You can't change <code>Name</code> after you create the <code>SqlInjectionMatchSet</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAFSqlInjectionMatchSet (CreateSqlInjectionMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ChangeToken = this.ChangeToken;
            context.Name = this.Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.CreateSqlInjectionMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.WAF.Model.CreateSqlInjectionMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.CreateSqlInjectionMatchSetRequest request)
        {
            return client.CreateSqlInjectionMatchSet(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
