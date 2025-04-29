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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Lists all engagements that have happened in an incident.
    /// </summary>
    [Cmdlet("Get", "SMCEngagementList")]
    [OutputType("Amazon.SSMContacts.Model.Engagement")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts ListEngagements API operation.", Operation = new[] {"ListEngagements"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.ListEngagementsResponse))]
    [AWSCmdletOutput("Amazon.SSMContacts.Model.Engagement or Amazon.SSMContacts.Model.ListEngagementsResponse",
        "This cmdlet returns a collection of Amazon.SSMContacts.Model.Engagement objects.",
        "The service call response (type Amazon.SSMContacts.Model.ListEngagementsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMCEngagementListCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TimeRangeValue_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRangeValue_EndTime { get; set; }
        #endregion
        
        #region Parameter IncidentId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident you're listing engagements for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String IncidentId { get; set; }
        #endregion
        
        #region Parameter TimeRangeValue_StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRangeValue_StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of engagements per page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to continue to the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Engagements'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.ListEngagementsResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.ListEngagementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Engagements";
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
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.ListEngagementsResponse, GetSMCEngagementListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncidentId = this.IncidentId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TimeRangeValue_EndTime = this.TimeRangeValue_EndTime;
            context.TimeRangeValue_StartTime = this.TimeRangeValue_StartTime;
            
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
            var request = new Amazon.SSMContacts.Model.ListEngagementsRequest();
            
            if (cmdletContext.IncidentId != null)
            {
                request.IncidentId = cmdletContext.IncidentId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate TimeRangeValue
            var requestTimeRangeValueIsNull = true;
            request.TimeRangeValue = new Amazon.SSMContacts.Model.TimeRange();
            System.DateTime? requestTimeRangeValue_timeRangeValue_EndTime = null;
            if (cmdletContext.TimeRangeValue_EndTime != null)
            {
                requestTimeRangeValue_timeRangeValue_EndTime = cmdletContext.TimeRangeValue_EndTime.Value;
            }
            if (requestTimeRangeValue_timeRangeValue_EndTime != null)
            {
                request.TimeRangeValue.EndTime = requestTimeRangeValue_timeRangeValue_EndTime.Value;
                requestTimeRangeValueIsNull = false;
            }
            System.DateTime? requestTimeRangeValue_timeRangeValue_StartTime = null;
            if (cmdletContext.TimeRangeValue_StartTime != null)
            {
                requestTimeRangeValue_timeRangeValue_StartTime = cmdletContext.TimeRangeValue_StartTime.Value;
            }
            if (requestTimeRangeValue_timeRangeValue_StartTime != null)
            {
                request.TimeRangeValue.StartTime = requestTimeRangeValue_timeRangeValue_StartTime.Value;
                requestTimeRangeValueIsNull = false;
            }
             // determine if request.TimeRangeValue should be set to null
            if (requestTimeRangeValueIsNull)
            {
                request.TimeRangeValue = null;
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
        
        private Amazon.SSMContacts.Model.ListEngagementsResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.ListEngagementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "ListEngagements");
            try
            {
                return client.ListEngagementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IncidentId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? TimeRangeValue_EndTime { get; set; }
            public System.DateTime? TimeRangeValue_StartTime { get; set; }
            public System.Func<Amazon.SSMContacts.Model.ListEngagementsResponse, GetSMCEngagementListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Engagements;
        }
        
    }
}
