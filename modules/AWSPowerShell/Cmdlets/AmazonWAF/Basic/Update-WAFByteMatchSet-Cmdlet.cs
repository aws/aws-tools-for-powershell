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
    /// Inserts or deletes <a>ByteMatchTuple</a> objects (filters) in a <a>ByteMatchSet</a>.
    /// For each <code>ByteMatchTuple</code> object, you specify the following values: 
    /// 
    ///  <ul><li>Whether to insert or delete the object from the array. If you want to change
    /// a <code>ByteMatchSetUpdate</code> object, you delete the existing object and add a
    /// new one.</li><li>The part of a web request that you want AWS WAF to inspect, such
    /// as a query string or the value of the <code>User-Agent</code> header. </li><li>The
    /// bytes (typically a string that corresponds with ASCII characters) that you want AWS
    /// WAF to look for. For more information, including how you specify the values for the
    /// AWS WAF API and the AWS CLI or SDKs, see <code>TargetString</code> in the <a>ByteMatchTuple</a>
    /// data type. </li><li>Where to look, such as at the beginning or the end of a query
    /// string.</li><li>Whether to perform any conversions on the request, such as converting
    /// it to lowercase, before inspecting it for the specified string.</li></ul><para>
    /// For example, you can add a <code>ByteMatchSetUpdate</code> object that matches web
    /// requests in which <code>User-Agent</code> headers contain the string <code>BadBot</code>.
    /// You can then configure AWS WAF to block those requests.
    /// </para><para>
    /// To create and configure a <code>ByteMatchSet</code>, perform the following steps:
    /// </para><ol><li>Create a <code>ByteMatchSet.</code> For more information, see <a>CreateByteMatchSet</a>.</li><li>Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <code>UpdateByteMatchSet</code> request.</li><li>Submit an <code>UpdateByteMatchSet</code>
    /// request to specify the part of the request that you want AWS WAF to inspect (for example,
    /// the header or the URI) and the value that you want AWS WAF to watch for.</li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFByteMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateByteMatchSet operation against AWS WAF.", Operation = new[] {"UpdateByteMatchSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateByteMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateWAFByteMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter ByteMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>ByteMatchSetId</code> of the <a>ByteMatchSet</a> that you want to update.
        /// <code>ByteMatchSetId</code> is returned by <a>CreateByteMatchSet</a> and by <a>ListByteMatchSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ByteMatchSetId { get; set; }
        #endregion
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>ByteMatchSetUpdate</code> objects that you want to insert into or
        /// delete from a <a>ByteMatchSet</a>. For more information, see the applicable data types:</para><ul><li><a>ByteMatchSetUpdate</a>: Contains <code>Action</code> and <code>ByteMatchTuple</code></li><li><a>ByteMatchTuple</a>: Contains <code>FieldToMatch</code>, <code>PositionalConstraint</code>,
        /// <code>TargetString</code>, and <code>TextTransformation</code></li><li><a>FieldToMatch</a>:
        /// Contains <code>Data</code> and <code>Type</code></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.ByteMatchSetUpdate[] Update { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ByteMatchSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFByteMatchSet (UpdateByteMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ByteMatchSetId = this.ByteMatchSetId;
            context.ChangeToken = this.ChangeToken;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.ByteMatchSetUpdate>(this.Update);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WAF.Model.UpdateByteMatchSetRequest();
            
            if (cmdletContext.ByteMatchSetId != null)
            {
                request.ByteMatchSetId = cmdletContext.ByteMatchSetId;
            }
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.Updates != null)
            {
                request.Updates = cmdletContext.Updates;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateByteMatchSet(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ByteMatchSetId { get; set; }
            public System.String ChangeToken { get; set; }
            public List<Amazon.WAF.Model.ByteMatchSetUpdate> Updates { get; set; }
        }
        
    }
}
