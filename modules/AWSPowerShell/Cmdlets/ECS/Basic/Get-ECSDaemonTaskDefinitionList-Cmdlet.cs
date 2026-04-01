/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Returns a list of daemon task definitions that are registered to your account. You
    /// can filter the results by family name, status, or both to find daemon task definitions
    /// that match your criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECSDaemonTaskDefinitionList")]
    [OutputType("Amazon.ECS.Model.DaemonTaskDefinitionSummary")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListDaemonTaskDefinitions API operation.", Operation = new[] {"ListDaemonTaskDefinitions"}, SelectReturnType = typeof(Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.DaemonTaskDefinitionSummary or Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.ECS.Model.DaemonTaskDefinitionSummary objects.",
        "The service call response (type Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECSDaemonTaskDefinitionListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>The exact name of the daemon task definition family to filter results with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Family { get; set; }
        #endregion
        
        #region Parameter FamilyPrefix
        /// <summary>
        /// <para>
        /// <para>The full family name to filter the <c>ListDaemonTaskDefinitions</c> results with.
        /// Specifying a <c>familyPrefix</c> limits the listed daemon task definitions to daemon
        /// task definition families that start with the <c>familyPrefix</c> string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FamilyPrefix { get; set; }
        #endregion
        
        #region Parameter Revision
        /// <summary>
        /// <para>
        /// <para>The revision filter to apply. Specify <c>LAST_REGISTERED</c> to return only the last
        /// registered revision for each daemon task definition family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DaemonTaskDefinitionRevisionFilter")]
        public Amazon.ECS.DaemonTaskDefinitionRevisionFilter Revision { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>The order to sort the results. Valid values are <c>ASC</c> and <c>DESC</c>. By default
        /// (<c>ASC</c>), daemon task definitions are listed in ascending order by family name
        /// and revision number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.SortOrder")]
        public Amazon.ECS.SortOrder Sort { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The daemon task definition status to filter the <c>ListDaemonTaskDefinitions</c> results
        /// with. By default, only <c>ACTIVE</c> daemon task definitions are listed. If you set
        /// this parameter to <c>DELETE_IN_PROGRESS</c>, only daemon task definitions that are
        /// in the process of being deleted are listed. If you set this parameter to <c>ALL</c>,
        /// all daemon task definitions are listed regardless of status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DaemonTaskDefinitionStatusFilter")]
        public Amazon.ECS.DaemonTaskDefinitionStatusFilter Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of daemon task definition results that <c>ListDaemonTaskDefinitions</c>
        /// returned in paginated output. When this parameter is used, <c>ListDaemonTaskDefinitions</c>
        /// only returns <c>maxResults</c> results in a single page along with a <c>nextToken</c>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <c>ListDaemonTaskDefinitions</c> request with the returned <c>nextToken</c>
        /// value. This value can be between 1 and 100. If this parameter isn't used, then <c>ListDaemonTaskDefinitions</c>
        /// returns up to 100 results and a <c>nextToken</c> value if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a <c>ListDaemonTaskDefinitions</c> request
        /// indicating that more results are available to fulfill the request and further calls
        /// will be needed. If <c>maxResults</c> was provided, it's possible for the number of
        /// results to be fewer than <c>maxResults</c>.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DaemonTaskDefinitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DaemonTaskDefinitions";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse, GetECSDaemonTaskDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Family = this.Family;
            context.FamilyPrefix = this.FamilyPrefix;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Revision = this.Revision;
            context.Sort = this.Sort;
            context.Status = this.Status;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ECS.Model.ListDaemonTaskDefinitionsRequest();
            
            if (cmdletContext.Family != null)
            {
                request.Family = cmdletContext.Family;
            }
            if (cmdletContext.FamilyPrefix != null)
            {
                request.FamilyPrefix = cmdletContext.FamilyPrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Revision != null)
            {
                request.Revision = cmdletContext.Revision;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = cmdletContext.Sort;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ListDaemonTaskDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ListDaemonTaskDefinitions");
            try
            {
                return client.ListDaemonTaskDefinitionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Family { get; set; }
            public System.String FamilyPrefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ECS.DaemonTaskDefinitionRevisionFilter Revision { get; set; }
            public Amazon.ECS.SortOrder Sort { get; set; }
            public Amazon.ECS.DaemonTaskDefinitionStatusFilter Status { get; set; }
            public System.Func<Amazon.ECS.Model.ListDaemonTaskDefinitionsResponse, GetECSDaemonTaskDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DaemonTaskDefinitions;
        }
        
    }
}
