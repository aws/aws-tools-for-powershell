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
    /// Inserts or deletes <a>SizeConstraint</a> objects (filters) in a <a>SizeConstraintSet</a>.
    /// For each <code>SizeConstraint</code> object, you specify the following values: 
    /// 
    ///  <ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change a <code>SizeConstraintSetUpdate</code>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The part of a web request that you want AWS WAF to evaluate, such as the length of
    /// a query string or the length of the <code>User-Agent</code> header.
    /// </para></li><li><para>
    /// Whether to perform any transformations on the request, such as converting it to lowercase,
    /// before checking its length. Note that transformations of the request body are not
    /// supported because the AWS resource forwards only the first <code>8192</code> bytes
    /// of your request to AWS WAF.
    /// </para></li><li><para>
    /// A <code>ComparisonOperator</code> used for evaluating the selected part of the request
    /// against the specified <code>Size</code>, such as equals, greater than, less than,
    /// and so on.
    /// </para></li><li><para>
    /// The length, in bytes, that you want AWS WAF to watch for in selected part of the request.
    /// The length is computed after applying the transformation.
    /// </para></li></ul><para>
    /// For example, you can add a <code>SizeConstraintSetUpdate</code> object that matches
    /// web requests in which the length of the <code>User-Agent</code> header is greater
    /// than 100 bytes. You can then configure AWS WAF to block those requests.
    /// </para><para>
    /// To create and configure a <code>SizeConstraintSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Create a <code>SizeConstraintSet.</code> For more information, see <a>CreateSizeConstraintSet</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <code>UpdateSizeConstraintSet</code> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateSizeConstraintSet</code> request to specify the part of the
    /// request that you want AWS WAF to inspect (for example, the header or the URI) and
    /// the value that you want AWS WAF to watch for.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFSizeConstraintSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateSizeConstraintSet operation against AWS WAF.", Operation = new[] {"UpdateSizeConstraintSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateSizeConstraintSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFSizeConstraintSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter SizeConstraintSetId
        /// <summary>
        /// <para>
        /// <para>The <code>SizeConstraintSetId</code> of the <a>SizeConstraintSet</a> that you want
        /// to update. <code>SizeConstraintSetId</code> is returned by <a>CreateSizeConstraintSet</a>
        /// and by <a>ListSizeConstraintSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SizeConstraintSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>SizeConstraintSetUpdate</code> objects that you want to insert into
        /// or delete from a <a>SizeConstraintSet</a>. For more information, see the applicable
        /// data types:</para><ul><li><para><a>SizeConstraintSetUpdate</a>: Contains <code>Action</code> and <code>SizeConstraint</code></para></li><li><para><a>SizeConstraint</a>: Contains <code>FieldToMatch</code>, <code>TextTransformation</code>,
        /// <code>ComparisonOperator</code>, and <code>Size</code></para></li><li><para><a>FieldToMatch</a>: Contains <code>Data</code> and <code>Type</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.SizeConstraintSetUpdate[] Update { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SizeConstraintSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFSizeConstraintSet (UpdateSizeConstraintSet)"))
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
            context.SizeConstraintSetId = this.SizeConstraintSetId;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.SizeConstraintSetUpdate>(this.Update);
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
            var request = new Amazon.WAF.Model.UpdateSizeConstraintSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.SizeConstraintSetId != null)
            {
                request.SizeConstraintSetId = cmdletContext.SizeConstraintSetId;
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
        
        private Amazon.WAF.Model.UpdateSizeConstraintSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateSizeConstraintSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateSizeConstraintSet");
            #if DESKTOP
            return client.UpdateSizeConstraintSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateSizeConstraintSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public System.String SizeConstraintSetId { get; set; }
            public List<Amazon.WAF.Model.SizeConstraintSetUpdate> Updates { get; set; }
        }
        
    }
}
