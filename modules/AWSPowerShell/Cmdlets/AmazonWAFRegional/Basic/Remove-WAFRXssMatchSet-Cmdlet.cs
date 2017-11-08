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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// Permanently deletes an <a>XssMatchSet</a>. You can't delete an <code>XssMatchSet</code>
    /// if it's still used in any <code>Rules</code> or if it still contains any <a>XssMatchTuple</a>
    /// objects.
    /// 
    ///  
    /// <para>
    /// If you just want to remove an <code>XssMatchSet</code> from a <code>Rule</code>, use
    /// <a>UpdateRule</a>.
    /// </para><para>
    /// To permanently delete an <code>XssMatchSet</code> from AWS WAF, perform the following
    /// steps:
    /// </para><ol><li><para>
    /// Update the <code>XssMatchSet</code> to remove filters, if any. For more information,
    /// see <a>UpdateXssMatchSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>DeleteXssMatchSet</code> request.
    /// </para></li><li><para>
    /// Submit a <code>DeleteXssMatchSet</code> request.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Remove", "WAFRXssMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional DeleteXssMatchSet API operation.", Operation = new[] {"DeleteXssMatchSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAFRegional.Model.DeleteXssMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveWAFRXssMatchSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter XssMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>XssMatchSetId</code> of the <a>XssMatchSet</a> that you want to delete.
        /// <code>XssMatchSetId</code> is returned by <a>CreateXssMatchSet</a> and by <a>ListXssMatchSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String XssMatchSetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("XssMatchSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WAFRXssMatchSet (DeleteXssMatchSet)"))
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
            context.XssMatchSetId = this.XssMatchSetId;
            
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
            var request = new Amazon.WAFRegional.Model.DeleteXssMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.XssMatchSetId != null)
            {
                request.XssMatchSetId = cmdletContext.XssMatchSetId;
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
        
        private Amazon.WAFRegional.Model.DeleteXssMatchSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.DeleteXssMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "DeleteXssMatchSet");
            try
            {
                #if DESKTOP
                return client.DeleteXssMatchSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteXssMatchSetAsync(request);
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
            public System.String XssMatchSetId { get; set; }
        }
        
    }
}
