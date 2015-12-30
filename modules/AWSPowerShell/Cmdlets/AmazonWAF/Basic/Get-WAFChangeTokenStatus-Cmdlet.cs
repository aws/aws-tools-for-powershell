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
    /// Returns the status of a <code>ChangeToken</code> that you got by calling <a>GetChangeToken</a>.
    /// <code>ChangeTokenStatus</code> is one of the following values:
    /// 
    ///  <ul><li><code>PROVISIONED</code>: You requested the change token by calling <code>GetChangeToken</code>,
    /// but you haven't used it yet in a call to create, update, or delete an AWS WAF object.</li><li><code>PENDING</code>: AWS WAF is propagating the create, update, or delete request
    /// to all AWS WAF servers.</li><li><code>IN_SYNC</code>: Propagation is complete.</li></ul>
    /// </summary>
    [Cmdlet("Get", "WAFChangeTokenStatus")]
    [OutputType("Amazon.WAF.ChangeTokenStatus")]
    [AWSCmdlet("Invokes the GetChangeTokenStatus operation against AWS WAF.", Operation = new[] {"GetChangeTokenStatus"})]
    [AWSCmdletOutput("Amazon.WAF.ChangeTokenStatus",
        "This cmdlet returns a ChangeTokenStatus object.",
        "The service call response (type Amazon.WAF.Model.GetChangeTokenStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetWAFChangeTokenStatusCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The change token for which you want to get the status. This change token was previously
        /// returned in the <code>GetChangeToken</code> response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ChangeToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ChangeToken = this.ChangeToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.GetChangeTokenStatusRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetChangeTokenStatus(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeTokenStatus;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
        }
        
    }
}
