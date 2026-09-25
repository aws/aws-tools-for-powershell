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
    /// upgrading to the Maps API V2 unless you require <c>Grab</c> data.
    /// </para><ul><li><para><c>DescribeMap</c> is part of a previous Amazon Location Service Maps API (version
    /// 1) which has been superseded by a more intuitive, powerful, and complete API (version
    /// 2).
    /// </para></li><li><para>
    /// The Maps API version 2 has a simplified interface that can be used without creating
    /// or managing map resources.
    /// </para></li><li><para>
    /// If you are using an AWS SDK or the AWS CLI, note that the Maps API version 2 is found
    /// under <c>geo-maps</c> or <c>geo_maps</c>, not under <c>location</c>.
    /// </para></li><li><para>
    /// Since <c>Grab</c> is not yet fully supported in Maps API version 2, we recommend you
    /// continue using API version 1 when using <c>Grab</c>.
    /// </para></li><li><para>
    /// Start your version 2 API journey with the <a href="https://docs.aws.amazon.com/location/latest/APIReference/API_Operations_Amazon_Location_Service_Maps_V2.html">Maps
    /// V2 API Reference</a> or the <a href="https://docs.aws.amazon.com/location/latest/developerguide/maps.html">Developer
    /// Guide</a>.
    /// </para></li></ul></important><para>
    /// Retrieves the map resource details.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LOCMap")]
    [OutputType("Amazon.LocationService.Model.DescribeMapResponse")]
    [AWSCmdlet("Calls the Amazon Location Service DescribeMap API operation.", Operation = new[] {"DescribeMap"}, SelectReturnType = typeof(Amazon.LocationService.Model.DescribeMapResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.DescribeMapResponse",
        "This cmdlet returns an Amazon.LocationService.Model.DescribeMapResponse object containing multiple properties."
    )]
    public partial class GetLOCMapCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MapName
        /// <summary>
        /// <para>
        /// <para>The name of the map resource.</para>
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
        public System.String MapName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.DescribeMapResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.DescribeMapResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.DescribeMapResponse, GetLOCMapCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MapName = this.MapName;
            #if MODULAR
            if (this.MapName == null && ParameterWasBound(nameof(this.MapName)))
            {
                WriteWarning("You are passing $null as a value for parameter MapName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.DescribeMapRequest();
            
            if (cmdletContext.MapName != null)
            {
                request.MapName = cmdletContext.MapName;
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
        
        private Amazon.LocationService.Model.DescribeMapResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.DescribeMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "DescribeMap");
            try
            {
                return client.DescribeMapAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MapName { get; set; }
            public System.Func<Amazon.LocationService.Model.DescribeMapResponse, GetLOCMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
