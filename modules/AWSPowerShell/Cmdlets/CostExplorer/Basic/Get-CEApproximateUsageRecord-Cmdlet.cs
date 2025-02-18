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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves estimated usage records for hourly granularity or resource-level data at
    /// daily granularity.
    /// </summary>
    [Cmdlet("Get", "CEApproximateUsageRecord")]
    [OutputType("Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetApproximateUsageRecords API operation.", Operation = new[] {"GetApproximateUsageRecords"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse object containing multiple properties."
    )]
    public partial class GetCEApproximateUsageRecordCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApproximationDimension
        /// <summary>
        /// <para>
        /// <para>The service to evaluate for the usage records. You can choose resource-level data
        /// at daily granularity, or hourly granularity with or without resource-level data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.ApproximationDimension")]
        public Amazon.CostExplorer.ApproximationDimension ApproximationDimension { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>How granular you want the data to be. You can enable data at hourly or daily granularity.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The service metadata for the service or services you want to query. If not specified,
        /// all elements are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Services")]
        public System.String[] Service { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse, GetCEApproximateUsageRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApproximationDimension = this.ApproximationDimension;
            #if MODULAR
            if (this.ApproximationDimension == null && ParameterWasBound(nameof(this.ApproximationDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter ApproximationDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Granularity = this.Granularity;
            #if MODULAR
            if (this.Granularity == null && ParameterWasBound(nameof(this.Granularity)))
            {
                WriteWarning("You are passing $null as a value for parameter Granularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Service != null)
            {
                context.Service = new List<System.String>(this.Service);
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
            // create request
            var request = new Amazon.CostExplorer.Model.GetApproximateUsageRecordsRequest();
            
            if (cmdletContext.ApproximationDimension != null)
            {
                request.ApproximationDimension = cmdletContext.ApproximationDimension;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.Service != null)
            {
                request.Services = cmdletContext.Service;
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
        
        private Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetApproximateUsageRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetApproximateUsageRecords");
            try
            {
                return client.GetApproximateUsageRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.ApproximationDimension ApproximationDimension { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public List<System.String> Service { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetApproximateUsageRecordsResponse, GetCEApproximateUsageRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
