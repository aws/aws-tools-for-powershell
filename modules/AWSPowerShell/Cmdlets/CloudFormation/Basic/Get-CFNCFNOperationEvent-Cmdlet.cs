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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns CloudFormation events based on flexible query criteria. Groups events by operation
    /// ID, enabling you to focus on individual stack operations during deployment.
    /// 
    ///  
    /// <para>
    /// An operation is any action performed on a stack, including stack lifecycle actions
    /// (Create, Update, Delete, Rollback), change set creation, nested stack creation, and
    /// automatic rollbacks triggered by failures. Each operation has a unique identifier
    /// (Operation ID) and represents a discrete change attempt on the stack.
    /// </para><para>
    /// Returns different types of events including:
    /// </para><ul><li><para><b>Progress events</b> - Status updates during stack operation execution.
    /// </para></li><li><para><b>Validation errors</b> - Failures from CloudFormation Early Validations.
    /// </para></li><li><para><b>Provisioning errors</b> - Resource creation and update failures.
    /// </para></li><li><para><b>Hook invocation errors</b> - Failures from CloudFormation Hook during stack operations.
    /// </para></li></ul><note><para>
    /// One of <c>ChangeSetName</c>, <c>OperationId</c> or <c>StackName</c> must be specified
    /// as input.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFNCFNOperationEvent")]
    [OutputType("Amazon.CloudFormation.Model.OperationEvent")]
    [AWSCmdlet("Calls the AWS CloudFormation DescribeEvents API operation.", Operation = new[] {"DescribeEvents"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DescribeEventsResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.OperationEvent or Amazon.CloudFormation.Model.DescribeEventsResponse",
        "This cmdlet returns a collection of Amazon.CloudFormation.Model.OperationEvent objects.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFNCFNOperationEventCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the change set for which you want to retrieve
        /// events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter Filters_FailedEvent
        /// <summary>
        /// <para>
        /// <para>When set to true, only returns failed events within the operation. This helps quickly
        /// identify root causes for a failed operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_FailedEvents")]
        public System.Boolean? Filters_FailedEvent { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the operation for which you want to retrieve events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or unique stack ID for which you want to retrieve events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of items to return. (You received this token from a previous
        /// call.)</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DescribeEventsResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.DescribeEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationEvents";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DescribeEventsResponse, GetCFNCFNOperationEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeSetName = this.ChangeSetName;
            context.Filters_FailedEvent = this.Filters_FailedEvent;
            context.NextToken = this.NextToken;
            context.OperationId = this.OperationId;
            context.StackName = this.StackName;
            
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
            var request = new Amazon.CloudFormation.Model.DescribeEventsRequest();
            
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.CloudFormation.Model.EventFilter();
            System.Boolean? requestFilters_filters_FailedEvent = null;
            if (cmdletContext.Filters_FailedEvent != null)
            {
                requestFilters_filters_FailedEvent = cmdletContext.Filters_FailedEvent.Value;
            }
            if (requestFilters_filters_FailedEvent != null)
            {
                request.Filters.FailedEvents = requestFilters_filters_FailedEvent.Value;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
        
        private Amazon.CloudFormation.Model.DescribeEventsResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeEvents");
            try
            {
                return client.DescribeEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChangeSetName { get; set; }
            public System.Boolean? Filters_FailedEvent { get; set; }
            public System.String NextToken { get; set; }
            public System.String OperationId { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DescribeEventsResponse, GetCFNCFNOperationEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationEvents;
        }
        
    }
}
