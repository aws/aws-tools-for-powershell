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
using Amazon.Scheduler;
using Amazon.Scheduler.Model;

namespace Amazon.PowerShell.Cmdlets.SCH
{
    /// <summary>
    /// Returns a paginated list of your schedule groups.
    /// </summary>
    [Cmdlet("Get", "SCHScheduleGroupList")]
    [OutputType("Amazon.Scheduler.Model.ScheduleGroupSummary")]
    [AWSCmdlet("Calls the Amazon EventBridge Scheduler ListScheduleGroups API operation.", Operation = new[] {"ListScheduleGroups"}, SelectReturnType = typeof(Amazon.Scheduler.Model.ListScheduleGroupsResponse))]
    [AWSCmdletOutput("Amazon.Scheduler.Model.ScheduleGroupSummary or Amazon.Scheduler.Model.ListScheduleGroupsResponse",
        "This cmdlet returns a collection of Amazon.Scheduler.Model.ScheduleGroupSummary objects.",
        "The service call response (type Amazon.Scheduler.Model.ListScheduleGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSCHScheduleGroupListCmdlet : AmazonSchedulerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NamePrefix
        /// <summary>
        /// <para>
        /// <para>The name prefix that you can use to return a filtered list of your schedule groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>If specified, limits the number of results returned by this operation. The operation
        /// also returns a <c>NextToken</c> which you can use in a subsequent operation to retrieve
        /// the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned by a previous call to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduleGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Scheduler.Model.ListScheduleGroupsResponse).
        /// Specifying the name of a property of type Amazon.Scheduler.Model.ListScheduleGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduleGroups";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Scheduler.Model.ListScheduleGroupsResponse, GetSCHScheduleGroupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NamePrefix = this.NamePrefix;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Scheduler.Model.ListScheduleGroupsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamePrefix != null)
            {
                request.NamePrefix = cmdletContext.NamePrefix;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Scheduler.Model.ListScheduleGroupsResponse CallAWSServiceOperation(IAmazonScheduler client, Amazon.Scheduler.Model.ListScheduleGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Scheduler", "ListScheduleGroups");
            try
            {
                return client.ListScheduleGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NamePrefix { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Scheduler.Model.ListScheduleGroupsResponse, GetSCHScheduleGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduleGroups;
        }
        
    }
}
