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
    /// Inserts or deletes <a>RegexMatchSetUpdate</a> objects (filters) in a <a>RegexPatternSet</a>.
    /// For each <code>RegexPatternSet</code> object, you specify the following values: 
    /// 
    ///  <ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change a <code>RegexPatternSet</code>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The regular expression pattern that you want AWS WAF to look for. For more information,
    /// see <a>RegexPatternSet</a>. 
    /// </para></li></ul><para>
    ///  For example, you can create a <code>RegexPatternString</code> such as <code>B[a@]dB[o0]t</code>.
    /// AWS WAF will match this <code>RegexPatternString</code> to:
    /// </para><ul><li><para>
    /// BadBot
    /// </para></li><li><para>
    /// BadB0t
    /// </para></li><li><para>
    /// B@dBot
    /// </para></li><li><para>
    /// B@dB0t
    /// </para></li></ul><para>
    /// To create and configure a <code>RegexPatternSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Create a <code>RegexPatternSet.</code> For more information, see <a>CreateRegexPatternSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <code>UpdateRegexPatternSet</code> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateRegexPatternSet</code> request to specify the regular expression
    /// pattern that you want AWS WAF to watch for.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRegexPatternSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateRegexPatternSet API operation.", Operation = new[] {"UpdateRegexPatternSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateRegexPatternSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFRegexPatternSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter RegexPatternSetId
        /// <summary>
        /// <para>
        /// <para>The <code>RegexPatternSetId</code> of the <a>RegexPatternSet</a> that you want to
        /// update. <code>RegexPatternSetId</code> is returned by <a>CreateRegexPatternSet</a>
        /// and by <a>ListRegexPatternSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RegexPatternSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>RegexPatternSetUpdate</code> objects that you want to insert into
        /// or delete from a <a>RegexPatternSet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.RegexPatternSetUpdate[] Update { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RegexPatternSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRegexPatternSet (UpdateRegexPatternSet)"))
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
            context.RegexPatternSetId = this.RegexPatternSetId;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.RegexPatternSetUpdate>(this.Update);
            }
            
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
            var request = new Amazon.WAF.Model.UpdateRegexPatternSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.RegexPatternSetId != null)
            {
                request.RegexPatternSetId = cmdletContext.RegexPatternSetId;
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
        
        private Amazon.WAF.Model.UpdateRegexPatternSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateRegexPatternSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateRegexPatternSet");
            try
            {
                #if DESKTOP
                return client.UpdateRegexPatternSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRegexPatternSetAsync(request);
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
            public System.String RegexPatternSetId { get; set; }
            public List<Amazon.WAF.Model.RegexPatternSetUpdate> Updates { get; set; }
        }
        
    }
}
