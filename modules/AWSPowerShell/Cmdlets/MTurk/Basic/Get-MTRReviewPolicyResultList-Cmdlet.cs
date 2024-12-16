/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// The <c>ListReviewPolicyResultsForHIT</c> operation retrieves the computed results
    /// and the actions taken in the course of executing your Review Policies for a given
    /// HIT. For information about how to specify Review Policies when you call CreateHIT,
    /// see Review Policies. The ListReviewPolicyResultsForHIT operation can return results
    /// for both Assignment-level and HIT-level review results.<br/><br/>In the AWS.Tools.MTurk module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MTRReviewPolicyResultList")]
    [OutputType("Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse")]
    [AWSCmdlet("Calls the Amazon MTurk Service ListReviewPolicyResultsForHIT API operation.", Operation = new[] {"ListReviewPolicyResultsForHIT"}, SelectReturnType = typeof(Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse))]
    [AWSCmdletOutput("Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse",
        "This cmdlet returns an Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse object containing multiple properties."
    )]
    public partial class GetMTRReviewPolicyResultListCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HITId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the HIT to retrieve review results for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveActions")]
        public System.Boolean? RetrieveAction { get; set; }
        #endregion
        
        #region Parameter RetrieveResult
        /// <summary>
        /// <para>
        /// <para> Specify if the operation should retrieve a list of the results computed by the Review
        /// Policies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveResults")]
        public System.Boolean? RetrieveResult { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Limit the number of results returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.MTurk module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse).
        /// Specifying the name of a property of type Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse, GetMTRReviewPolicyResultListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HITId = this.HITId;
            #if MODULAR
            if (this.HITId == null && ParameterWasBound(nameof(this.HITId)))
            {
                WriteWarning("You are passing $null as a value for parameter HITId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.PolicyLevel != null)
            {
                context.PolicyLevel = new List<System.String>(this.PolicyLevel);
            }
            context.RetrieveAction = this.RetrieveAction;
            context.RetrieveResult = this.RetrieveResult;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MTurk.Model.ListReviewPolicyResultsForHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PolicyLevel != null)
            {
                request.PolicyLevels = cmdletContext.PolicyLevel;
            }
            if (cmdletContext.RetrieveAction != null)
            {
                request.RetrieveActions = cmdletContext.RetrieveAction.Value;
            }
            if (cmdletContext.RetrieveResult != null)
            {
                request.RetrieveResults = cmdletContext.RetrieveResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MTurk.Model.ListReviewPolicyResultsForHITRequest();
            
            if (cmdletContext.HITId != null)
            {
                request.HITId = cmdletContext.HITId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PolicyLevel != null)
            {
                request.PolicyLevels = cmdletContext.PolicyLevel;
            }
            if (cmdletContext.RetrieveAction != null)
            {
                request.RetrieveActions = cmdletContext.RetrieveAction.Value;
            }
            if (cmdletContext.RetrieveResult != null)
            {
                request.RetrieveResults = cmdletContext.RetrieveResult.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        #endif
        
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
                return client.ListReviewPolicyResultsForHITAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> PolicyLevel { get; set; }
            public System.Boolean? RetrieveAction { get; set; }
            public System.Boolean? RetrieveResult { get; set; }
            public System.Func<Amazon.MTurk.Model.ListReviewPolicyResultsForHITResponse, GetMTRReviewPolicyResultListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
