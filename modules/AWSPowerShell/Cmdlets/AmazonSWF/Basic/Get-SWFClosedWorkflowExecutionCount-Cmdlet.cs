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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns the number of closed workflow executions within the given domain that meet
    /// the specified filtering criteria.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not exactly
    /// reflect recent updates and changes.
    /// </para></note><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <code>Resource</code> element with the domain name to limit the action to only
    /// specified domains.
    /// </para></li><li><para>
    /// Use an <code>Action</code> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <code>Condition</code> element with
    /// the appropriate keys.
    /// </para><ul><li><para><code>tagFilter.tag</code>: String constraint. The key is <code>swf:tagFilter.tag</code>.
    /// </para></li><li><para><code>typeFilter.name</code>: String constraint. The key is <code>swf:typeFilter.name</code>.
    /// </para></li><li><para><code>typeFilter.version</code>: String constraint. The key is <code>swf:typeFilter.version</code>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <code>cause</code> parameter is set to <code>OPERATION_NOT_PERMITTED</code>.
    /// For details and example IAM policies, see <a href="http://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SWFClosedWorkflowExecutionCount")]
    [OutputType("Amazon.SimpleWorkflow.Model.WorkflowExecutionCount")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service CountClosedWorkflowExecutions API operation.", Operation = new[] {"CountClosedWorkflowExecutions"})]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.WorkflowExecutionCount",
        "This cmdlet returns a Amazon.SimpleWorkflow.Model.WorkflowExecutionCount object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSWFClosedWorkflowExecutionCountCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain containing the workflow executions to count.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter CloseTimeFilter_LatestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the latest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CloseTimeFilter_LatestDate { get; set; }
        #endregion
        
        #region Parameter StartTimeFilter_LatestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the latest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTimeFilter_LatestDate { get; set; }
        #endregion
        
        #region Parameter TypeFilter_Name
        /// <summary>
        /// <para>
        /// <para> Name of the workflow type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TypeFilter_Name { get; set; }
        #endregion
        
        #region Parameter CloseTimeFilter_OldestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the oldest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CloseTimeFilter_OldestDate { get; set; }
        #endregion
        
        #region Parameter StartTimeFilter_OldestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the oldest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTimeFilter_OldestDate { get; set; }
        #endregion
        
        #region Parameter CloseStatusFilter_Status
        /// <summary>
        /// <para>
        /// <para> The close status that must match the close status of an execution for it to meet
        /// the criteria of this filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleWorkflow.CloseStatus")]
        public Amazon.SimpleWorkflow.CloseStatus CloseStatusFilter_Status { get; set; }
        #endregion
        
        #region Parameter TagFilter_Tag
        /// <summary>
        /// <para>
        /// <para> Specifies the tag that must be associated with the execution for it to meet the filter
        /// criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TagFilter_Tag { get; set; }
        #endregion
        
        #region Parameter TypeFilter_Version
        /// <summary>
        /// <para>
        /// <para>Version of the workflow type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TypeFilter_Version { get; set; }
        #endregion
        
        #region Parameter ExecutionFilter_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The workflowId to pass of match the criteria of this filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionFilter_WorkflowId { get; set; }
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
            
            context.CloseStatusFilter_Status = this.CloseStatusFilter_Status;
            if (ParameterWasBound("CloseTimeFilter_LatestDate"))
                context.CloseTimeFilter_LatestDate = this.CloseTimeFilter_LatestDate;
            if (ParameterWasBound("CloseTimeFilter_OldestDate"))
                context.CloseTimeFilter_OldestDate = this.CloseTimeFilter_OldestDate;
            context.Domain = this.Domain;
            context.ExecutionFilter_WorkflowId = this.ExecutionFilter_WorkflowId;
            if (ParameterWasBound("StartTimeFilter_LatestDate"))
                context.StartTimeFilter_LatestDate = this.StartTimeFilter_LatestDate;
            if (ParameterWasBound("StartTimeFilter_OldestDate"))
                context.StartTimeFilter_OldestDate = this.StartTimeFilter_OldestDate;
            context.TagFilter_Tag = this.TagFilter_Tag;
            context.TypeFilter_Name = this.TypeFilter_Name;
            context.TypeFilter_Version = this.TypeFilter_Version;
            
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
            var request = new Amazon.SimpleWorkflow.Model.CountClosedWorkflowExecutionsRequest();
            
            
             // populate CloseStatusFilter
            bool requestCloseStatusFilterIsNull = true;
            request.CloseStatusFilter = new Amazon.SimpleWorkflow.Model.CloseStatusFilter();
            Amazon.SimpleWorkflow.CloseStatus requestCloseStatusFilter_closeStatusFilter_Status = null;
            if (cmdletContext.CloseStatusFilter_Status != null)
            {
                requestCloseStatusFilter_closeStatusFilter_Status = cmdletContext.CloseStatusFilter_Status;
            }
            if (requestCloseStatusFilter_closeStatusFilter_Status != null)
            {
                request.CloseStatusFilter.Status = requestCloseStatusFilter_closeStatusFilter_Status;
                requestCloseStatusFilterIsNull = false;
            }
             // determine if request.CloseStatusFilter should be set to null
            if (requestCloseStatusFilterIsNull)
            {
                request.CloseStatusFilter = null;
            }
            
             // populate CloseTimeFilter
            bool requestCloseTimeFilterIsNull = true;
            request.CloseTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_LatestDate = null;
            if (cmdletContext.CloseTimeFilter_LatestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_LatestDate = cmdletContext.CloseTimeFilter_LatestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_LatestDate != null)
            {
                request.CloseTimeFilter.LatestDate = requestCloseTimeFilter_closeTimeFilter_LatestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_OldestDate = null;
            if (cmdletContext.CloseTimeFilter_OldestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_OldestDate = cmdletContext.CloseTimeFilter_OldestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_OldestDate != null)
            {
                request.CloseTimeFilter.OldestDate = requestCloseTimeFilter_closeTimeFilter_OldestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
             // determine if request.CloseTimeFilter should be set to null
            if (requestCloseTimeFilterIsNull)
            {
                request.CloseTimeFilter = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate ExecutionFilter
            bool requestExecutionFilterIsNull = true;
            request.ExecutionFilter = new Amazon.SimpleWorkflow.Model.WorkflowExecutionFilter();
            System.String requestExecutionFilter_executionFilter_WorkflowId = null;
            if (cmdletContext.ExecutionFilter_WorkflowId != null)
            {
                requestExecutionFilter_executionFilter_WorkflowId = cmdletContext.ExecutionFilter_WorkflowId;
            }
            if (requestExecutionFilter_executionFilter_WorkflowId != null)
            {
                request.ExecutionFilter.WorkflowId = requestExecutionFilter_executionFilter_WorkflowId;
                requestExecutionFilterIsNull = false;
            }
             // determine if request.ExecutionFilter should be set to null
            if (requestExecutionFilterIsNull)
            {
                request.ExecutionFilter = null;
            }
            
             // populate StartTimeFilter
            bool requestStartTimeFilterIsNull = true;
            request.StartTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestStartTimeFilter_startTimeFilter_LatestDate = null;
            if (cmdletContext.StartTimeFilter_LatestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_LatestDate = cmdletContext.StartTimeFilter_LatestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_LatestDate != null)
            {
                request.StartTimeFilter.LatestDate = requestStartTimeFilter_startTimeFilter_LatestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
            System.DateTime? requestStartTimeFilter_startTimeFilter_OldestDate = null;
            if (cmdletContext.StartTimeFilter_OldestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_OldestDate = cmdletContext.StartTimeFilter_OldestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_OldestDate != null)
            {
                request.StartTimeFilter.OldestDate = requestStartTimeFilter_startTimeFilter_OldestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
             // determine if request.StartTimeFilter should be set to null
            if (requestStartTimeFilterIsNull)
            {
                request.StartTimeFilter = null;
            }
            
             // populate TagFilter
            bool requestTagFilterIsNull = true;
            request.TagFilter = new Amazon.SimpleWorkflow.Model.TagFilter();
            System.String requestTagFilter_tagFilter_Tag = null;
            if (cmdletContext.TagFilter_Tag != null)
            {
                requestTagFilter_tagFilter_Tag = cmdletContext.TagFilter_Tag;
            }
            if (requestTagFilter_tagFilter_Tag != null)
            {
                request.TagFilter.Tag = requestTagFilter_tagFilter_Tag;
                requestTagFilterIsNull = false;
            }
             // determine if request.TagFilter should be set to null
            if (requestTagFilterIsNull)
            {
                request.TagFilter = null;
            }
            
             // populate TypeFilter
            bool requestTypeFilterIsNull = true;
            request.TypeFilter = new Amazon.SimpleWorkflow.Model.WorkflowTypeFilter();
            System.String requestTypeFilter_typeFilter_Name = null;
            if (cmdletContext.TypeFilter_Name != null)
            {
                requestTypeFilter_typeFilter_Name = cmdletContext.TypeFilter_Name;
            }
            if (requestTypeFilter_typeFilter_Name != null)
            {
                request.TypeFilter.Name = requestTypeFilter_typeFilter_Name;
                requestTypeFilterIsNull = false;
            }
            System.String requestTypeFilter_typeFilter_Version = null;
            if (cmdletContext.TypeFilter_Version != null)
            {
                requestTypeFilter_typeFilter_Version = cmdletContext.TypeFilter_Version;
            }
            if (requestTypeFilter_typeFilter_Version != null)
            {
                request.TypeFilter.Version = requestTypeFilter_typeFilter_Version;
                requestTypeFilterIsNull = false;
            }
             // determine if request.TypeFilter should be set to null
            if (requestTypeFilterIsNull)
            {
                request.TypeFilter = null;
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
        
        private Amazon.SimpleWorkflow.Model.CountClosedWorkflowExecutionsResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.CountClosedWorkflowExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service", "CountClosedWorkflowExecutions");
            try
            {
                #if DESKTOP
                return client.CountClosedWorkflowExecutions(request);
                #elif CORECLR
                return client.CountClosedWorkflowExecutionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleWorkflow.CloseStatus CloseStatusFilter_Status { get; set; }
            public System.DateTime? CloseTimeFilter_LatestDate { get; set; }
            public System.DateTime? CloseTimeFilter_OldestDate { get; set; }
            public System.String Domain { get; set; }
            public System.String ExecutionFilter_WorkflowId { get; set; }
            public System.DateTime? StartTimeFilter_LatestDate { get; set; }
            public System.DateTime? StartTimeFilter_OldestDate { get; set; }
            public System.String TagFilter_Tag { get; set; }
            public System.String TypeFilter_Name { get; set; }
            public System.String TypeFilter_Version { get; set; }
        }
        
    }
}
