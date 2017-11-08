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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns a list of tags. You can return tags from a specific resource by specifying
    /// an ARN, or you can return all tags for a given type of resource, such as clusters,
    /// snapshots, and so on.
    /// 
    ///  
    /// <para>
    /// The following are limitations for <code>DescribeTags</code>: 
    /// </para><ul><li><para>
    /// You cannot specify an ARN and a resource-type value together in the same request.
    /// </para></li><li><para>
    /// You cannot use the <code>MaxRecords</code> and <code>Marker</code> parameters together
    /// with the ARN parameter.
    /// </para></li><li><para>
    /// The <code>MaxRecords</code> parameter can be a range from 10 to 50 results to return
    /// in a request.
    /// </para></li></ul><para>
    /// If you specify both tag keys and tag values in the same request, Amazon Redshift returns
    /// all resources that match any combination of the specified keys and values. For example,
    /// if you have <code>owner</code> and <code>environment</code> for tag keys, and <code>admin</code>
    /// and <code>test</code> for tag values, all resources that have any combination of those
    /// values are returned.
    /// </para><para>
    /// If both tag keys and values are omitted from the request, resources are returned regardless
    /// of whether they have tag keys or values associated with them.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "RSResourceTag")]
    [OutputType("Amazon.Redshift.Model.TaggedResource")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeTags API operation.", Operation = new[] {"DescribeTags"}, LegacyAlias="Get-RSTags")]
    [AWSCmdletOutput("Amazon.Redshift.Model.TaggedResource",
        "This cmdlet returns a collection of TaggedResource objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeTagsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetRSResourceTagCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for which you want to describe the tag or tags. For
        /// example, <code>arn:aws:redshift:us-east-1:123456789:cluster:t1</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource with which you want to view tags. Valid resource types are: </para><ul><li><para>Cluster</para></li><li><para>CIDR/IP</para></li><li><para>EC2 security group</para></li><li><para>Snapshot</para></li><li><para>Cluster security group</para></li><li><para>Subnet group</para></li><li><para>HSM connection</para></li><li><para>HSM certificate</para></li><li><para>Parameter group</para></li><li><para>Snapshot copy grant</para></li></ul><para>For more information about Amazon Redshift resource types and constructing ARNs, go
        /// to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/redshift-iam-access-control-overview.html#redshift-iam-access-control-specify-actions">Specifying
        /// Policy Elements: Actions, Effects, Resources, and Principals</a> in the Amazon Redshift
        /// Cluster Management Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>A tag key or keys for which you want to return all matching resources that are associated
        /// with the specified key or keys. For example, suppose that you have resources tagged
        /// with keys called <code>owner</code> and <code>environment</code>. If you specify both
        /// of these tag keys in the request, Amazon Redshift returns a response with all resources
        /// that have either or both of these tag keys associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter TagValue
        /// <summary>
        /// <para>
        /// <para>A tag value or values for which you want to return all matching resources that are
        /// associated with the specified value or values. For example, suppose that you have
        /// resources tagged with values called <code>admin</code> and <code>test</code>. If you
        /// specify both of these tag values in the request, Amazon Redshift returns a response
        /// with all resources that have either or both of these tag values associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagValues")]
        public System.String[] TagValue { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>A value that indicates the starting point for the next set of response records in
        /// a subsequent request. If a value is returned in a response, you can retrieve the next
        /// set of records by providing this returned marker value in the <code>marker</code>
        /// parameter and retrying the command. If the <code>marker</code> field is empty, all
        /// response records have been retrieved for the request. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number or response records to return in each call. If the number of remaining
        /// response records exceeds the specified <code>MaxRecords</code> value, a value is returned
        /// in a <code>marker</code> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned <code>marker</code> value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
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
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.ResourceName = this.ResourceName;
            context.ResourceType = this.ResourceType;
            if (this.TagKey != null)
            {
                context.TagKeys = new List<System.String>(this.TagKey);
            }
            if (this.TagValue != null)
            {
                context.TagValues = new List<System.String>(this.TagValue);
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
            
            // create request and set iteration invariants
            var request = new Amazon.Redshift.Model.DescribeTagsRequest();
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.TagKeys != null)
            {
                request.TagKeys = cmdletContext.TagKeys;
            }
            if (cmdletContext.TagValues != null)
            {
                request.TagValues = cmdletContext.TagValues;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
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
                        object pipelineOutput = response.TaggedResources;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TaggedResources.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
        
        private Amazon.Redshift.Model.DescribeTagsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeTags");
            try
            {
                #if DESKTOP
                return client.DescribeTags(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeTagsAsync(request);
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
            public System.String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public System.String ResourceName { get; set; }
            public System.String ResourceType { get; set; }
            public List<System.String> TagKeys { get; set; }
            public List<System.String> TagValues { get; set; }
        }
        
    }
}
