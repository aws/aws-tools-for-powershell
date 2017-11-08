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
    /// Permanently deletes a <a>RegexMatchSet</a>. You can't delete a <code>RegexMatchSet</code>
    /// if it's still used in any <code>Rules</code> or if it still includes any <code>RegexMatchTuples</code>
    /// objects (any filters).
    /// 
    ///  
    /// <para>
    /// If you just want to remove a <code>RegexMatchSet</code> from a <code>Rule</code>,
    /// use <a>UpdateRule</a>.
    /// </para><para>
    /// To permanently delete a <code>RegexMatchSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Update the <code>RegexMatchSet</code> to remove filters, if any. For more information,
    /// see <a>UpdateRegexMatchSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>DeleteRegexMatchSet</code> request.
    /// </para></li><li><para>
    /// Submit a <code>DeleteRegexMatchSet</code> request.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Remove", "WAFRegexMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF DeleteRegexMatchSet API operation.", Operation = new[] {"DeleteRegexMatchSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.DeleteRegexMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveWAFRegexMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter RegexMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>RegexMatchSetId</code> of the <a>RegexMatchSet</a> that you want to delete.
        /// <code>RegexMatchSetId</code> is returned by <a>CreateRegexMatchSet</a> and by <a>ListRegexMatchSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RegexMatchSetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RegexMatchSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WAFRegexMatchSet (DeleteRegexMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ChangeToken = this.ChangeToken;
            context.RegexMatchSetId = this.RegexMatchSetId;
            
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
            var request = new Amazon.WAF.Model.DeleteRegexMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.RegexMatchSetId != null)
            {
                request.RegexMatchSetId = cmdletContext.RegexMatchSetId;
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
        
        private Amazon.WAF.Model.DeleteRegexMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.DeleteRegexMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "DeleteRegexMatchSet");
            try
            {
                #if DESKTOP
                return client.DeleteRegexMatchSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteRegexMatchSetAsync(request);
                return task.Result;
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
            public System.String RegexMatchSetId { get; set; }
        }
        
    }
}
