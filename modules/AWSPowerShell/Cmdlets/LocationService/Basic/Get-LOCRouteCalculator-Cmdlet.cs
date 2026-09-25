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
using Amazon.LocationService;
using Amazon.LocationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// <important><para>
    /// This operation is no longer current and may be deprecated in the future. We recommend
    /// you upgrade to the Routes API V2 unless you require Grab data.
    /// </para><ul><li><para><c>DescribeRouteCalculator</c> is part of a previous Amazon Location Service Routes
    /// API (version 1) which has been superseded by a more intuitive, powerful, and complete
    /// API (version 2).
    /// </para></li><li><para>
    /// The Routes API version 2 has a simplified interface that can be used without creating
    /// or managing route calculator resources.
    /// </para></li><li><para>
    /// If you are using an Amazon Web Services SDK or the Amazon Web Services CLI, note that
    /// the Routes API version 2 is found under <c>geo-routes</c> or <c>geo_routes</c>, not
    /// under <c>location</c>.
    /// </para></li><li><para>
    /// Since Grab is not yet fully supported in Routes API version 2, we recommend you continue
    /// using API version 1 when using Grab.
    /// </para></li><li><para>
    /// Start your version 2 API journey with the Routes V2 <a href="/location/latest/APIReference/API_Operations_Amazon_Location_Service_Routes_V2.html">API
    /// Reference</a> or the <a href="/location/latest/developerguide/routes.html">Developer
    /// Guide</a>.
    /// </para></li></ul></important><para>
    /// Retrieves the route calculator resource details.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LOCRouteCalculator")]
    [OutputType("Amazon.LocationService.Model.DescribeRouteCalculatorResponse")]
    [AWSCmdlet("Calls the Amazon Location Service DescribeRouteCalculator API operation.", Operation = new[] {"DescribeRouteCalculator"}, SelectReturnType = typeof(Amazon.LocationService.Model.DescribeRouteCalculatorResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.DescribeRouteCalculatorResponse",
        "This cmdlet returns an Amazon.LocationService.Model.DescribeRouteCalculatorResponse object containing multiple properties."
    )]
    public partial class GetLOCRouteCalculatorCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CalculatorName
        /// <summary>
        /// <para>
        /// <para>The name of the route calculator resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CalculatorName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.DescribeRouteCalculatorResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.DescribeRouteCalculatorResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.DescribeRouteCalculatorResponse, GetLOCRouteCalculatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CalculatorName = this.CalculatorName;
            #if MODULAR
            if (this.CalculatorName == null && ParameterWasBound(nameof(this.CalculatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.LocationService.Model.DescribeRouteCalculatorRequest();
            
            if (cmdletContext.CalculatorName != null)
            {
                request.CalculatorName = cmdletContext.CalculatorName;
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
        
        private Amazon.LocationService.Model.DescribeRouteCalculatorResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.DescribeRouteCalculatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "DescribeRouteCalculator");
            try
            {
                return client.DescribeRouteCalculatorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CalculatorName { get; set; }
            public System.Func<Amazon.LocationService.Model.DescribeRouteCalculatorResponse, GetLOCRouteCalculatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
