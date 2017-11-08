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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Returns descriptions for existing environments.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EBEnvironment")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EnvironmentDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk DescribeEnvironments API operation.", Operation = new[] {"DescribeEnvironments"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EnvironmentDescription",
        "This cmdlet returns a collection of EnvironmentDescription objects.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentIds")]
        public System.String[] EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentNames")]
        public System.String[] EnvironmentName { get; set; }
        #endregion
        
        #region Parameter IncludedDeletedBackTo
        /// <summary>
        /// <para>
        /// <para> If specified when <code>IncludeDeleted</code> is set to <code>true</code>, then environments
        /// deleted after this date are displayed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime IncludedDeletedBackTo { get; set; }
        #endregion
        
        #region Parameter IncludeDeleted
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include deleted environments:</para><para><code>true</code>: Environments that have been deleted after <code>IncludedDeletedBackTo</code>
        /// are displayed.</para><para><code>false</code>: Do not include deleted environments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeDeleted { get; set; }
        #endregion
        
        #region Parameter VersionLabel
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>For a paginated request. Specify a maximum number of environments to include in each
        /// response.</para><para>If no <code>MaxRecords</code> is specified, all available environments are retrieved
        /// in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>For a paginated request. Specify a token from a previous response page to retrieve
        /// the next response page. All other parameter values must be identical to the ones specified
        /// in the initial request.</para><para>If no <code>NextToken</code> is specified, the first page is retrieved.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
            
            context.ApplicationName = this.ApplicationName;
            if (this.EnvironmentId != null)
            {
                context.EnvironmentIds = new List<System.String>(this.EnvironmentId);
            }
            if (this.EnvironmentName != null)
            {
                context.EnvironmentNames = new List<System.String>(this.EnvironmentName);
            }
            if (ParameterWasBound("IncludedDeletedBackTo"))
                context.IncludedDeletedBackTo = this.IncludedDeletedBackTo;
            if (ParameterWasBound("IncludeDeleted"))
                context.IncludeDeleted = this.IncludeDeleted;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.NextToken = this.NextToken;
            context.VersionLabel = this.VersionLabel;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsRequest();
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentIds != null)
            {
                request.EnvironmentIds = cmdletContext.EnvironmentIds;
            }
            if (cmdletContext.EnvironmentNames != null)
            {
                request.EnvironmentNames = cmdletContext.EnvironmentNames;
            }
            if (cmdletContext.IncludedDeletedBackTo != null)
            {
                request.IncludedDeletedBackTo = cmdletContext.IncludedDeletedBackTo.Value;
            }
            if (cmdletContext.IncludeDeleted != null)
            {
                request.IncludeDeleted = cmdletContext.IncludeDeleted.Value;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 1000;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxRecords))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxRecords);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Environments;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Environments.Count;
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
                    // The service has a maximum page size of 1000 and the user has set a retrieval limit.
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
        
        private Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "DescribeEnvironments");
            try
            {
                #if DESKTOP
                return client.DescribeEnvironments(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeEnvironmentsAsync(request);
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
            public System.String ApplicationName { get; set; }
            public List<System.String> EnvironmentIds { get; set; }
            public List<System.String> EnvironmentNames { get; set; }
            public System.DateTime? IncludedDeletedBackTo { get; set; }
            public System.Boolean? IncludeDeleted { get; set; }
            public int? MaxRecords { get; set; }
            public System.String NextToken { get; set; }
            public System.String VersionLabel { get; set; }
        }
        
    }
}
