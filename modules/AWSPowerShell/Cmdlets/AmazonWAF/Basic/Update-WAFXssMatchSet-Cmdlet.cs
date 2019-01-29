/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Inserts or deletes <a>XssMatchTuple</a> objects (filters) in an <a>XssMatchSet</a>.
    /// For each <code>XssMatchTuple</code> object, you specify the following values:
    /// 
    ///  <ul><li><para><code>Action</code>: Whether to insert the object into or delete the object from
    /// the array. To change an <code>XssMatchTuple</code>, you delete the existing object
    /// and add a new one.
    /// </para></li><li><para><code>FieldToMatch</code>: The part of web requests that you want AWS WAF to inspect
    /// and, if you want AWS WAF to inspect a header or custom query parameter, the name of
    /// the header or parameter.
    /// </para></li><li><para><code>TextTransformation</code>: Which text transformation, if any, to perform on
    /// the web request before inspecting the request for cross-site scripting attacks.
    /// </para><para>
    /// You can only specify a single type of TextTransformation.
    /// </para></li></ul><para>
    /// You use <code>XssMatchSet</code> objects to specify which CloudFront requests that
    /// you want to allow, block, or count. For example, if you're receiving requests that
    /// contain cross-site scripting attacks in the request body and you want to block the
    /// requests, you can create an <code>XssMatchSet</code> with the applicable settings,
    /// and then configure AWS WAF to block the requests. 
    /// </para><para>
    /// To create and configure an <code>XssMatchSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateXssMatchSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateIPSet</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateXssMatchSet</code> request to specify the parts of web requests
    /// that you want AWS WAF to inspect for cross-site scripting attacks.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFXssMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateXssMatchSet API operation.", Operation = new[] {"UpdateXssMatchSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateXssMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFXssMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>XssMatchSetUpdate</code> objects that you want to insert into or
        /// delete from an <a>XssMatchSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>XssMatchSetUpdate</a>: Contains <code>Action</code> and <code>XssMatchTuple</code></para></li><li><para><a>XssMatchTuple</a>: Contains <code>FieldToMatch</code> and <code>TextTransformation</code></para></li><li><para><a>FieldToMatch</a>: Contains <code>Data</code> and <code>Type</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.XssMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter XssMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>XssMatchSetId</code> of the <code>XssMatchSet</code> that you want to update.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFXssMatchSet (UpdateXssMatchSet)"))
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
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.XssMatchSetUpdate>(this.Update);
            }
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
            var request = new Amazon.WAF.Model.UpdateXssMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.Updates != null)
            {
                request.Updates = cmdletContext.Updates;
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
        
        private Amazon.WAF.Model.UpdateXssMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateXssMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateXssMatchSet");
            try
            {
                #if DESKTOP
                return client.UpdateXssMatchSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateXssMatchSetAsync(request);
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
            public List<Amazon.WAF.Model.XssMatchSetUpdate> Updates { get; set; }
            public System.String XssMatchSetId { get; set; }
        }
        
    }
}
