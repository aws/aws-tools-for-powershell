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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Provides a list of operations in progress or queued. For usage examples, see <a href="https://docs.aws.amazon.com/controltower/latest/controlreference/control-api-examples-short.html#list-control-operations-api-examples">ListControlOperation
    /// examples</a>.
    /// </summary>
    [Cmdlet("Get", "ACTControlOperationList")]
    [OutputType("Amazon.ControlTower.Model.ControlOperationSummary")]
    [AWSCmdlet("Calls the AWS Control Tower ListControlOperations API operation.", Operation = new[] {"ListControlOperations"}, SelectReturnType = typeof(Amazon.ControlTower.Model.ListControlOperationsResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.ControlOperationSummary or Amazon.ControlTower.Model.ListControlOperationsResponse",
        "This cmdlet returns a collection of Amazon.ControlTower.Model.ControlOperationSummary objects.",
        "The service call response (type Amazon.ControlTower.Model.ListControlOperationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTControlOperationListCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_ControlIdentifier
        /// <summary>
        /// <para>
        /// <para>The set of <c>controlIdentifier</c> returned by the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ControlIdentifiers")]
        public System.String[] Filter_ControlIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter_ControlOperationType
        /// <summary>
        /// <para>
        /// <para>The set of <c>ControlOperation</c> objects returned by the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ControlOperationTypes")]
        public System.String[] Filter_ControlOperationType { get; set; }
        #endregion
        
        #region Parameter Filter_EnabledControlIdentifier
        /// <summary>
        /// <para>
        /// <para>The set <c>controlIdentifier</c> of enabled controls selected by the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EnabledControlIdentifiers")]
        public System.String[] Filter_EnabledControlIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Lists the status of control operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Statuses")]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_TargetIdentifier
        /// <summary>
        /// <para>
        /// <para>The set of <c>targetIdentifier</c> objects returned by the filter.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlOperations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.ListControlOperationsResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.ListControlOperationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlOperations";
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.ListControlOperationsResponse, GetACTControlOperationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_ControlIdentifier != null)
            {
                context.Filter_ControlIdentifier = new List<System.String>(this.Filter_ControlIdentifier);
            }
            if (this.Filter_ControlOperationType != null)
            {
                context.Filter_ControlOperationType = new List<System.String>(this.Filter_ControlOperationType);
            }
            if (this.Filter_EnabledControlIdentifier != null)
            {
                context.Filter_EnabledControlIdentifier = new List<System.String>(this.Filter_EnabledControlIdentifier);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            if (this.Filter_TargetIdentifier != null)
            {
                context.Filter_TargetIdentifier = new List<System.String>(this.Filter_TargetIdentifier);
            }
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
            var request = new Amazon.ControlTower.Model.ListControlOperationsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlTower.Model.ControlOperationFilter();
            List<System.String> requestFilter_filter_ControlIdentifier = null;
            if (cmdletContext.Filter_ControlIdentifier != null)
            {
                requestFilter_filter_ControlIdentifier = cmdletContext.Filter_ControlIdentifier;
            }
            if (requestFilter_filter_ControlIdentifier != null)
            {
                request.Filter.ControlIdentifiers = requestFilter_filter_ControlIdentifier;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ControlOperationType = null;
            if (cmdletContext.Filter_ControlOperationType != null)
            {
                requestFilter_filter_ControlOperationType = cmdletContext.Filter_ControlOperationType;
            }
            if (requestFilter_filter_ControlOperationType != null)
            {
                request.Filter.ControlOperationTypes = requestFilter_filter_ControlOperationType;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EnabledControlIdentifier = null;
            if (cmdletContext.Filter_EnabledControlIdentifier != null)
            {
                requestFilter_filter_EnabledControlIdentifier = cmdletContext.Filter_EnabledControlIdentifier;
            }
            if (requestFilter_filter_EnabledControlIdentifier != null)
            {
                request.Filter.EnabledControlIdentifiers = requestFilter_filter_EnabledControlIdentifier;
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
        
        private Amazon.ControlTower.Model.ListControlOperationsResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.ListControlOperationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "ListControlOperations");
            try
            {
                #if DESKTOP
                return client.ListControlOperations(request);
                #elif CORECLR
                return client.ListControlOperationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_ControlIdentifier { get; set; }
            public List<System.String> Filter_ControlOperationType { get; set; }
            public List<System.String> Filter_EnabledControlIdentifier { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public List<System.String> Filter_TargetIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlTower.Model.ListControlOperationsResponse, GetACTControlOperationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlOperations;
        }
        
    }
}
