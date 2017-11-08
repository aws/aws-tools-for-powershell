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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>ListReviewPolicyResultsForHIT</code> operation retrieves the computed results
    /// and the actions taken in the course of executing your Review Policies for a given
    /// HIT. For information about how to specify Review Policies when you call CreateHIT,
    /// see Review Policies. The ListReviewPolicyResultsForHIT operation can return results
    /// for both Assignment-level and HIT-level review results.
    /// </summary>
    [Cmdlet("Get", "MTRReviewPolicyResultList")]
    [OutputType("Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse")]
    [AWSCmdlet("Calls the Amazon MTurk Service ListReviewPolicyResultsForHIT API operation.", Operation = new[] {"ListReviewPolicyResultsForHIT"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse",
        "This cmdlet returns a Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMTRReviewPolicyResultListCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the HIT to retrieve review results for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HITId { get; set; }
        #endregion
        
        #region Parameter PolicyLevel
        /// <summary>
        /// <para>
        /// <para> The Policy Level(s) to retrieve review results for - HIT or Assignment. If omitted,
        /// the default behavior is to retrieve all data for both policy levels. For a list of
        /// all the described policies, see Review Policies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PolicyLevels")]
        public System.String[] PolicyLevel { get; set; }
        #endregion
        
        #region Parameter RetrieveAction
        /// <summary>
        /// <para>
        /// <para> Specify if the operation should retrieve a list of the actions taken executing the
        /// Review Policies and their outcomes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetrieveActions")]
        public System.Boolean RetrieveAction { get; set; }
        #endregion
        
        #region Parameter RetrieveResult
        /// <summary>
        /// <para>
        /// <para> Specify if the operation should retrieve a list of the results computed by the Review
        /// Policies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetrieveResults")]
        public System.Boolean RetrieveResult { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Limit the number of results returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HITId = this.HITId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.PolicyLevel != null)
            {
                context.PolicyLevels = new List<System.String>(this.PolicyLevel);
            }
            if (ParameterWasBound("RetrieveAction"))
                context.RetrieveActions = this.RetrieveAction;
            if (ParameterWasBound("RetrieveResult"))
                context.RetrieveResults = this.RetrieveResult;
            
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
            var request = new Amazon.MTurk.Model.ListReviewPolicyResultsForHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PolicyLevels != null)
            {
                request.PolicyLevels = cmdletContext.PolicyLevels;
            }
            if (cmdletContext.RetrieveActions != null)
            {
                request.RetrieveActions = cmdletContext.RetrieveActions.Value;
            }
            if (cmdletContext.RetrieveResults != null)
            {
                request.RetrieveResults = cmdletContext.RetrieveResults.Value;
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
        
        private Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.ListReviewPolicyResultsForHITRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "ListReviewPolicyResultsForHIT");
            try
            {
                #if DESKTOP
                return client.ListReviewPolicyResultsForHIT(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListReviewPolicyResultsForHITAsync(request);
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
            public System.String HITId { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> PolicyLevels { get; set; }
            public System.Boolean? RetrieveActions { get; set; }
            public System.Boolean? RetrieveResults { get; set; }
        }
        
    }
}
