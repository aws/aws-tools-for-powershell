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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns a list of the Amazon SageMaker notebook instances in the requester's account
    /// in an AWS Region.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SMNotebookInstanceList")]
    [OutputType("Amazon.SageMaker.Model.NotebookInstanceSummary")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListNotebookInstances API operation.", Operation = new[] {"ListNotebookInstances"})]
    [AWSCmdletOutput("Amazon.SageMaker.Model.NotebookInstanceSummary",
        "This cmdlet returns a collection of NotebookInstanceSummary objects.",
        "The service call response (type Amazon.SageMaker.Model.ListNotebookInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetSMNotebookInstanceListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalCodeRepositoryEqual
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances with associated with the specified git
        /// repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdditionalCodeRepositoryEquals")]
        public System.String AdditionalCodeRepositoryEqual { get; set; }
        #endregion
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances that were created after the specified
        /// time (timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances that were created before the specified
        /// time (timestamp). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter DefaultCodeRepositoryContain
        /// <summary>
        /// <para>
        /// <para>A string in the name or URL of a Git repository associated with this notebook instance.
        /// This filter returns only notebook instances associated with a git repository with
        /// a name that contains the specified string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DefaultCodeRepositoryContains")]
        public System.String DefaultCodeRepositoryContain { get; set; }
        #endregion
        
        #region Parameter LastModifiedTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances that were modified after the specified
        /// time (timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime LastModifiedTimeAfter { get; set; }
        #endregion
        
        #region Parameter LastModifiedTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances that were modified before the specified
        /// time (timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime LastModifiedTimeBefore { get; set; }
        #endregion
        
        #region Parameter NameContain
        /// <summary>
        /// <para>
        /// <para>A string in the notebook instances' name. This filter returns only notebook instances
        /// whose name contains the specified string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NameContains")]
        public System.String NameContain { get; set; }
        #endregion
        
        #region Parameter NotebookInstanceLifecycleConfigNameContain
        /// <summary>
        /// <para>
        /// <para>A string in the name of a notebook instances lifecycle configuration associated with
        /// this notebook instance. This filter returns only notebook instances associated with
        /// a lifecycle configuration with a name that contains the specified string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotebookInstanceLifecycleConfigNameContains")]
        public System.String NotebookInstanceLifecycleConfigNameContain { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort results by. The default is <code>Name</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.NotebookInstanceSortKey")]
        public Amazon.SageMaker.NotebookInstanceSortKey SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.NotebookInstanceSortOrder")]
        public Amazon.SageMaker.NotebookInstanceSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>A filter that returns only notebook instances with the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.SageMaker.NotebookInstanceStatus")]
        public Amazon.SageMaker.NotebookInstanceStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of notebook instances to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> If the previous call to the <code>ListNotebookInstances</code> is truncated, the
        /// response includes a <code>NextToken</code>. You can use this token in your subsequent
        /// <code>ListNotebookInstances</code> request to fetch the next set of notebook instances.
        /// </para><note><para>You might specify a filter or a sort order in your request. When response is truncated,
        /// you must use the same values for the filer and sort order in the next request. </para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            
            context.AdditionalCodeRepositoryEquals = this.AdditionalCodeRepositoryEqual;
            if (ParameterWasBound("CreationTimeAfter"))
                context.CreationTimeAfter = this.CreationTimeAfter;
            if (ParameterWasBound("CreationTimeBefore"))
                context.CreationTimeBefore = this.CreationTimeBefore;
            context.DefaultCodeRepositoryContains = this.DefaultCodeRepositoryContain;
            if (ParameterWasBound("LastModifiedTimeAfter"))
                context.LastModifiedTimeAfter = this.LastModifiedTimeAfter;
            if (ParameterWasBound("LastModifiedTimeBefore"))
                context.LastModifiedTimeBefore = this.LastModifiedTimeBefore;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NameContains = this.NameContain;
            context.NextToken = this.NextToken;
            context.NotebookInstanceLifecycleConfigNameContains = this.NotebookInstanceLifecycleConfigNameContain;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatusEquals = this.StatusEqual;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.ListNotebookInstancesRequest();
            if (cmdletContext.AdditionalCodeRepositoryEquals != null)
            {
                request.AdditionalCodeRepositoryEquals = cmdletContext.AdditionalCodeRepositoryEquals;
            }
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.DefaultCodeRepositoryContains != null)
            {
                request.DefaultCodeRepositoryContains = cmdletContext.DefaultCodeRepositoryContains;
            }
            if (cmdletContext.LastModifiedTimeAfter != null)
            {
                request.LastModifiedTimeAfter = cmdletContext.LastModifiedTimeAfter.Value;
            }
            if (cmdletContext.LastModifiedTimeBefore != null)
            {
                request.LastModifiedTimeBefore = cmdletContext.LastModifiedTimeBefore.Value;
            }
            if (cmdletContext.NameContains != null)
            {
                request.NameContains = cmdletContext.NameContains;
            }
            if (cmdletContext.NotebookInstanceLifecycleConfigNameContains != null)
            {
                request.NotebookInstanceLifecycleConfigNameContains = cmdletContext.NotebookInstanceLifecycleConfigNameContains;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEquals != null)
            {
                request.StatusEquals = cmdletContext.StatusEquals;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("MaxResult");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxResults))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxResults);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.NotebookInstances;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.NotebookInstances.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMaker.Model.ListNotebookInstancesResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListNotebookInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListNotebookInstances");
            try
            {
                #if DESKTOP
                return client.ListNotebookInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListNotebookInstancesAsync(request);
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
            public System.String AdditionalCodeRepositoryEquals { get; set; }
            public System.DateTime? CreationTimeAfter { get; set; }
            public System.DateTime? CreationTimeBefore { get; set; }
            public System.String DefaultCodeRepositoryContains { get; set; }
            public System.DateTime? LastModifiedTimeAfter { get; set; }
            public System.DateTime? LastModifiedTimeBefore { get; set; }
            public int? MaxResults { get; set; }
            public System.String NameContains { get; set; }
            public System.String NextToken { get; set; }
            public System.String NotebookInstanceLifecycleConfigNameContains { get; set; }
            public Amazon.SageMaker.NotebookInstanceSortKey SortBy { get; set; }
            public Amazon.SageMaker.NotebookInstanceSortOrder SortOrder { get; set; }
            public Amazon.SageMaker.NotebookInstanceStatus StatusEquals { get; set; }
        }
        
    }
}
