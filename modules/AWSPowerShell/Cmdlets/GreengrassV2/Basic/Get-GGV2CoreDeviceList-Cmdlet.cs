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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Retrieves a paginated list of Greengrass core devices.
    /// 
    ///  <note><para>
    /// IoT Greengrass relies on individual devices to send status updates to the Amazon Web
    /// Services Cloud. If the IoT Greengrass Core software isn't running on the device, or
    /// if device isn't connected to the Amazon Web Services Cloud, then the reported status
    /// of that device might not reflect its current status. The status timestamp indicates
    /// when the device status was last updated.
    /// </para><para>
    /// Core devices send status updates at the following times:
    /// </para><ul><li><para>
    /// When the IoT Greengrass Core software starts
    /// </para></li><li><para>
    /// When the core device receives a deployment from the Amazon Web Services Cloud
    /// </para></li><li><para>
    /// For Greengrass nucleus 2.12.2 and earlier, the core device sends status updates when
    /// the status of any component on the core device becomes <c>ERRORED</c> or <c>BROKEN</c>.
    /// </para></li><li><para>
    /// For Greengrass nucleus 2.12.3 and later, the core device sends status updates when
    /// the status of any component on the core device becomes <c>ERRORED</c>, <c>BROKEN</c>,
    /// <c>RUNNING</c>, or <c>FINISHED</c>.
    /// </para></li><li><para>
    /// At a <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/greengrass-nucleus-component.html#greengrass-nucleus-component-configuration-fss">regular
    /// interval that you can configure</a>, which defaults to 24 hours
    /// </para></li><li><para>
    /// For IoT Greengrass Core v2.7.0, the core device sends status updates upon local deployment
    /// and cloud deployment
    /// </para></li></ul></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "GGV2CoreDeviceList")]
    [OutputType("Amazon.GreengrassV2.Model.CoreDevice")]
    [AWSCmdlet("Calls the AWS GreengrassV2 ListCoreDevices API operation.", Operation = new[] {"ListCoreDevices"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.ListCoreDevicesResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.CoreDevice or Amazon.GreengrassV2.Model.ListCoreDevicesResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.CoreDevice objects.",
        "The service call response (type Amazon.GreengrassV2.Model.ListCoreDevicesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGGV2CoreDeviceListCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Runtime
        /// <summary>
        /// <para>
        /// <para>The runtime to be used by the core device. The runtime can be:</para><ul><li><para><c>aws_nucleus_classic</c></para></li><li><para><c>aws_nucleus_lite</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Runtime { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The core device status by which to filter. If you specify this parameter, the list
        /// includes only core devices that have this status. Choose one of the following options:</para><ul><li><para><c>HEALTHY</c> – The IoT Greengrass Core software and all components run on the core
        /// device without issue.</para></li><li><para><c>UNHEALTHY</c> – The IoT Greengrass Core software or a component is in a failed
        /// state on the core device.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.CoreDeviceStatus")]
        public Amazon.GreengrassV2.CoreDeviceStatus Status { get; set; }
        #endregion
        
        #region Parameter ThingGroupArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the IoT thing group by which to filter. If you specify this parameter, the list
        /// includes only core devices that have successfully deployed a deployment that targets
        /// the thing group. When you remove a core device from a thing group, the list continues
        /// to include that core device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThingGroupArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned per paginated request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CoreDevices'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.ListCoreDevicesResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.ListCoreDevicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CoreDevices";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.ListCoreDevicesResponse, GetGGV2CoreDeviceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Runtime = this.Runtime;
            context.Status = this.Status;
            context.ThingGroupArn = this.ThingGroupArn;
            
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
            var request = new Amazon.GreengrassV2.Model.ListCoreDevicesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Runtime != null)
            {
                request.Runtime = cmdletContext.Runtime;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.ThingGroupArn != null)
            {
                request.ThingGroupArn = cmdletContext.ThingGroupArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.GreengrassV2.Model.ListCoreDevicesResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.ListCoreDevicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "ListCoreDevices");
            try
            {
                return client.ListCoreDevicesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Runtime { get; set; }
            public Amazon.GreengrassV2.CoreDeviceStatus Status { get; set; }
            public System.String ThingGroupArn { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.ListCoreDevicesResponse, GetGGV2CoreDeviceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CoreDevices;
        }
        
    }
}
