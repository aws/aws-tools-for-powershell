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
    /// Returns the <a>SizeConstraintSet</a> specified by <code>SizeConstraintSetId</code>.
    /// </summary>
    [Cmdlet("Get", "WAFSizeConstraintSet")]
    [OutputType("Amazon.WAF.Model.SizeConstraintSet")]
    [AWSCmdlet("Invokes the GetSizeConstraintSet operation against AWS WAF.", Operation = new[] {"GetSizeConstraintSet"})]
    [AWSCmdletOutput("Amazon.WAF.Model.SizeConstraintSet",
        "This cmdlet returns a SizeConstraintSet object.",
        "The service call response (type Amazon.WAF.Model.GetSizeConstraintSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetWAFSizeConstraintSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter SizeConstraintSetId
        /// <summary>
        /// <para>
        /// <para>The <code>SizeConstraintSetId</code> of the <a>SizeConstraintSet</a> that you want
        /// to get. <code>SizeConstraintSetId</code> is returned by <a>CreateSizeConstraintSet</a>
        /// and by <a>ListSizeConstraintSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SizeConstraintSetId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SizeConstraintSetId = this.SizeConstraintSetId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.GetSizeConstraintSetRequest();
            
            if (cmdletContext.SizeConstraintSetId != null)
            {
                request.SizeConstraintSetId = cmdletContext.SizeConstraintSetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SizeConstraintSet;
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
        
        private static Amazon.WAF.Model.GetSizeConstraintSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.GetSizeConstraintSetRequest request)
        {
            return client.GetSizeConstraintSet(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String SizeConstraintSetId { get; set; }
        }
        
    }
}
