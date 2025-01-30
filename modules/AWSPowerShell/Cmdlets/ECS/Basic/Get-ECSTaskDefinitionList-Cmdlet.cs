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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Returns a list of task definitions that are registered to your account. You can filter
    /// the results by family name with the <c>familyPrefix</c> parameter or by status with
    /// the <c>status</c> parameter.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECSTaskDefinitionList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListTaskDefinitions API operation.", Operation = new[] {"ListTaskDefinitions"}, SelectReturnType = typeof(Amazon.ECS.Model.ListTaskDefinitionsResponse), LegacyAlias="Get-ECSTaskDefinitions")]
    [AWSCmdletOutput("System.String or Amazon.ECS.Model.ListTaskDefinitionsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ECS.Model.ListTaskDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECSTaskDefinitionListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FamilyPrefix
        /// <summary>
        /// <para>
        /// <para>The full family name to filter the <c>ListTaskDefinitions</c> results with. Specifying
        /// a <c>familyPrefix</c> limits the listed task definitions to task definition revisions
        /// that belong to that family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FamilyPrefix { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>The order to sort the results in. Valid values are <c>ASC</c> and <c>DESC</c>. By
        /// default, (<c>ASC</c>) task definitions are listed lexicographically by family name
        /// and in ascending numerical order by revision so that the newest task definitions in
        /// a family are listed last. Setting this parameter to <c>DESC</c> reverses the sort
        /// order on family name and revision. This is so that the newest task definitions in
        /// a family are listed first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.SortOrder")]
        public Amazon.ECS.SortOrder Sort { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The task definition status to filter the <c>ListTaskDefinitions</c> results with.
        /// By default, only <c>ACTIVE</c> task definitions are listed. By setting this parameter
        /// to <c>INACTIVE</c>, you can view task definitions that are <c>INACTIVE</c> as long
        /// as an active task or service still references them. If you paginate the resulting
        /// output, be sure to keep the <c>status</c> value constant in each subsequent request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.TaskDefinitionStatus")]
        public Amazon.ECS.TaskDefinitionStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of task definition results that <c>ListTaskDefinitions</c> returned
        /// in paginated output. When this parameter is used, <c>ListTaskDefinitions</c> only
        /// returns <c>maxResults</c> results in a single page along with a <c>nextToken</c> response
        /// element. The remaining results of the initial request can be seen by sending another
        /// <c>ListTaskDefinitions</c> request with the returned <c>nextToken</c> value. This
        /// value can be between 1 and 100. If this parameter isn't used, then <c>ListTaskDefinitions</c>
        /// returns up to 100 results and a <c>nextToken</c> value if applicable.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a <c>ListTaskDefinitions</c> request indicating
        /// that more results are available to fulfill the request and further calls will be needed.
        /// If <c>maxResults</c> was provided, it is possible the number of results to be fewer
        /// than <c>maxResults</c>.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskDefinitionArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.ListTaskDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.ListTaskDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskDefinitionArns";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.ListTaskDefinitionsResponse, GetECSTaskDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FamilyPrefix = this.FamilyPrefix;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Sort = this.Sort;
            context.Status = this.Status;
            
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
            var request = new Amazon.ECS.Model.ListTaskDefinitionsRequest();
            
            if (cmdletContext.FamilyPrefix != null)
            {
                request.FamilyPrefix = cmdletContext.FamilyPrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ECS.Model.ListTaskDefinitionsRequest();
            if (cmdletContext.FamilyPrefix != null)
            {
                request.FamilyPrefix = cmdletContext.FamilyPrefix;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = cmdletContext.Sort;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.TaskDefinitionArns.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ECS.Model.ListTaskDefinitionsResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ListTaskDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ListTaskDefinitions");
            try
            {
                #if DESKTOP
                return client.ListTaskDefinitions(request);
                #elif CORECLR
                return client.ListTaskDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public System.String FamilyPrefix { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ECS.SortOrder Sort { get; set; }
            public Amazon.ECS.TaskDefinitionStatus Status { get; set; }
            public System.Func<Amazon.ECS.Model.ListTaskDefinitionsResponse, GetECSTaskDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskDefinitionArns;
        }
        
    }
}
