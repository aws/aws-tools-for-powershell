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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Returns a list of summaries describing <c>EnabledBaseline</c> resources. You can filter
    /// the list by the corresponding <c>Baseline</c> or <c>Target</c> of the <c>EnabledBaseline</c>
    /// resources. For usage examples, see <a href="https://docs.aws.amazon.com/controltower/latest/userguide/baseline-api-examples.html"><i>the Amazon Web Services Control Tower User Guide</i></a>.
    /// </summary>
    [Cmdlet("Get", "ACTEnabledBaselineList")]
    [OutputType("Amazon.ControlTower.Model.EnabledBaselineSummary")]
    [AWSCmdlet("Calls the AWS Control Tower ListEnabledBaselines API operation.", Operation = new[] {"ListEnabledBaselines"}, SelectReturnType = typeof(Amazon.ControlTower.Model.ListEnabledBaselinesResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.EnabledBaselineSummary or Amazon.ControlTower.Model.ListEnabledBaselinesResponse",
        "This cmdlet returns a collection of Amazon.ControlTower.Model.EnabledBaselineSummary objects.",
        "The service call response (type Amazon.ControlTower.Model.ListEnabledBaselinesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTEnabledBaselineListCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_BaselineIdentifier
        /// <summary>
        /// <para>
        /// <para>Identifiers for the <c>Baseline</c> objects returned as part of the filter operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_BaselineIdentifiers")]
        public System.String[] Filter_BaselineIdentifier { get; set; }
        #endregion
        
        #region Parameter IncludeChild
        /// <summary>
        /// <para>
        /// <para>A value that can be set to include the child enabled baselines in responses. The default
        /// value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeChildren")]
        public System.Boolean? IncludeChild { get; set; }
        #endregion
        
        #region Parameter Filter_InheritanceDriftStatus
        /// <summary>
        /// <para>
        /// <para>A list of <c>EnabledBaselineDriftStatus</c> items for enabled baselines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_InheritanceDriftStatuses")]
        public System.String[] Filter_InheritanceDriftStatus { get; set; }
        #endregion
        
        #region Parameter Filter_ParentIdentifier
        /// <summary>
        /// <para>
        /// <para>An optional filter that sets up a list of <c>parentIdentifiers</c> to filter the results
        /// of the <c>ListEnabledBaseline</c> output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ParentIdentifiers")]
        public System.String[] Filter_ParentIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>A list of <c>EnablementStatus</c> items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Statuses")]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_TargetIdentifier
        /// <summary>
        /// <para>
        /// <para>Identifiers for the targets of the <c>Baseline</c> filter operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TargetIdentifiers")]
        public System.String[] Filter_TargetIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be shown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnabledBaselines'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.ListEnabledBaselinesResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.ListEnabledBaselinesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnabledBaselines";
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.ListEnabledBaselinesResponse, GetACTEnabledBaselineListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_BaselineIdentifier != null)
            {
                context.Filter_BaselineIdentifier = new List<System.String>(this.Filter_BaselineIdentifier);
            }
            if (this.Filter_InheritanceDriftStatus != null)
            {
                context.Filter_InheritanceDriftStatus = new List<System.String>(this.Filter_InheritanceDriftStatus);
            }
            if (this.Filter_ParentIdentifier != null)
            {
                context.Filter_ParentIdentifier = new List<System.String>(this.Filter_ParentIdentifier);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            if (this.Filter_TargetIdentifier != null)
            {
                context.Filter_TargetIdentifier = new List<System.String>(this.Filter_TargetIdentifier);
            }
            context.IncludeChild = this.IncludeChild;
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.ControlTower.Model.ListEnabledBaselinesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlTower.Model.EnabledBaselineFilter();
            List<System.String> requestFilter_filter_BaselineIdentifier = null;
            if (cmdletContext.Filter_BaselineIdentifier != null)
            {
                requestFilter_filter_BaselineIdentifier = cmdletContext.Filter_BaselineIdentifier;
            }
            if (requestFilter_filter_BaselineIdentifier != null)
            {
                request.Filter.BaselineIdentifiers = requestFilter_filter_BaselineIdentifier;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_InheritanceDriftStatus = null;
            if (cmdletContext.Filter_InheritanceDriftStatus != null)
            {
                requestFilter_filter_InheritanceDriftStatus = cmdletContext.Filter_InheritanceDriftStatus;
            }
            if (requestFilter_filter_InheritanceDriftStatus != null)
            {
                request.Filter.InheritanceDriftStatuses = requestFilter_filter_InheritanceDriftStatus;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ParentIdentifier = null;
            if (cmdletContext.Filter_ParentIdentifier != null)
            {
                requestFilter_filter_ParentIdentifier = cmdletContext.Filter_ParentIdentifier;
            }
            if (requestFilter_filter_ParentIdentifier != null)
            {
                request.Filter.ParentIdentifiers = requestFilter_filter_ParentIdentifier;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Statuses = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_TargetIdentifier = null;
            if (cmdletContext.Filter_TargetIdentifier != null)
            {
                requestFilter_filter_TargetIdentifier = cmdletContext.Filter_TargetIdentifier;
            }
            if (requestFilter_filter_TargetIdentifier != null)
            {
                request.Filter.TargetIdentifiers = requestFilter_filter_TargetIdentifier;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.IncludeChild != null)
            {
                request.IncludeChildren = cmdletContext.IncludeChild.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ControlTower.Model.ListEnabledBaselinesResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.ListEnabledBaselinesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "ListEnabledBaselines");
            try
            {
                return client.ListEnabledBaselinesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filter_BaselineIdentifier { get; set; }
            public List<System.String> Filter_InheritanceDriftStatus { get; set; }
            public List<System.String> Filter_ParentIdentifier { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public List<System.String> Filter_TargetIdentifier { get; set; }
            public System.Boolean? IncludeChild { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlTower.Model.ListEnabledBaselinesResponse, GetACTEnabledBaselineListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnabledBaselines;
        }
        
    }
}
