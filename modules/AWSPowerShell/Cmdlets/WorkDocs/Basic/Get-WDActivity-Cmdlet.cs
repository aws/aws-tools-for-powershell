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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Describes the user activities in a specified time period.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WDActivity")]
    [OutputType("Amazon.WorkDocs.Model.Activity")]
    [AWSCmdlet("Calls the Amazon WorkDocs DescribeActivities API operation.", Operation = new[] {"DescribeActivities"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.DescribeActivitiesResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.Activity or Amazon.WorkDocs.Model.DescribeActivitiesResponse",
        "This cmdlet returns a collection of Amazon.WorkDocs.Model.Activity objects.",
        "The service call response (type Amazon.WorkDocs.Model.DescribeActivitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWDActivityCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActivityType
        /// <summary>
        /// <para>
        /// <para>Specifies which activity types to include in the response. If this field is left empty,
        /// all activity types are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActivityTypes")]
        public System.String ActivityType { get; set; }
        #endregion
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter UtcEndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp that determines the end time of the activities. The response includes
        /// the activities performed before the specified timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcEndTime { get; set; }
        #endregion
        
        #region Parameter IncludeIndirectActivity
        /// <summary>
        /// <para>
        /// <para>Includes indirect activities. An indirect activity results from a direct activity
        /// performed on a parent resource. For example, sharing a parent folder (the direct activity)
        /// shares all of the subfolders and documents within the parent folder (the indirect
        /// activity).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeIndirectActivities")]
        public System.Boolean? IncludeIndirectActivity { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The ID of the organization. This is a mandatory parameter when using administrative
        /// API (SigV4) requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The document or folder ID for which to describe activity types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter UtcStartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp that determines the starting time of the activities. The response includes
        /// the activities performed after the specified timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcStartTime { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the user who performed the action. The response includes activities pertaining
        /// to this user. This is an optional parameter and is only applicable for administrative
        /// API (SigV4) requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EndTimeUtc instead. Setting either EndTime or EndTimeUtc
        /// results in both EndTime and EndTimeUtc being assigned, the latest assignment to either
        /// one of the two property is reflected in the value of both. EndTime is provided for
        /// backwards compatibility only and assigning a non-Utc DateTime to it results in the
        /// wrong timestamp being passed to the service.</para><para>The timestamp that determines the end time of the activities. The response includes
        /// the activities performed before the specified timestamp.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcEndTime instead.")]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use StartTimeUtc instead. Setting either StartTime or
        /// StartTimeUtc results in both StartTime and StartTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. StartTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The timestamp that determines the starting time of the activities. The response includes
        /// the activities performed after the specified timestamp.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcStartTime instead.")]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserActivities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.DescribeActivitiesResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.DescribeActivitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserActivities";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.DescribeActivitiesResponse, GetWDActivityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivityType = this.ActivityType;
            context.AuthenticationToken = this.AuthenticationToken;
            context.UtcEndTime = this.UtcEndTime;
            context.IncludeIndirectActivity = this.IncludeIndirectActivity;
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.Marker = this.Marker;
            context.OrganizationId = this.OrganizationId;
            context.ResourceId = this.ResourceId;
            context.UtcStartTime = this.UtcStartTime;
            context.UserId = this.UserId;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StartTime = this.StartTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.WorkDocs.Model.DescribeActivitiesRequest();
            
            if (cmdletContext.ActivityType != null)
            {
                request.ActivityTypes = cmdletContext.ActivityType;
            }
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            if (cmdletContext.IncludeIndirectActivity != null)
            {
                request.IncludeIndirectActivities = cmdletContext.IncludeIndirectActivity.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new System.ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.", nameof(this.EndTime));
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new System.ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.", nameof(this.StartTime));
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
            var request = new Amazon.WorkDocs.Model.DescribeActivitiesRequest();
            if (cmdletContext.ActivityType != null)
            {
                request.ActivityTypes = cmdletContext.ActivityType;
            }
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            if (cmdletContext.IncludeIndirectActivity != null)
            {
                request.IncludeIndirectActivities = cmdletContext.IncludeIndirectActivity.Value;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new System.ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.", nameof(this.EndTime));
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new System.ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.", nameof(this.StartTime));
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 999. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 999 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(999, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.UserActivities.Count;
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.WorkDocs.Model.DescribeActivitiesResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.DescribeActivitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "DescribeActivities");
            try
            {
                #if DESKTOP
                return client.DescribeActivities(request);
                #elif CORECLR
                return client.DescribeActivitiesAsync(request).GetAwaiter().GetResult();
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
            public System.String ActivityType { get; set; }
            public System.String AuthenticationToken { get; set; }
            public System.DateTime? UtcEndTime { get; set; }
            public System.Boolean? IncludeIndirectActivity { get; set; }
            public int? Limit { get; set; }
            public System.String Marker { get; set; }
            public System.String OrganizationId { get; set; }
            public System.String ResourceId { get; set; }
            public System.DateTime? UtcStartTime { get; set; }
            public System.String UserId { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.WorkDocs.Model.DescribeActivitiesResponse, GetWDActivityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserActivities;
        }
        
    }
}
