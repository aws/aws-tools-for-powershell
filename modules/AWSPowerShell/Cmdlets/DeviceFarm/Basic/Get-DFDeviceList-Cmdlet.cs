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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about unique device types.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DFDeviceList")]
    [OutputType("Amazon.DeviceFarm.Model.Device")]
    [AWSCmdlet("Calls the AWS Device Farm ListDevices API operation.", Operation = new[] {"ListDevices"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.ListDevicesResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Device or Amazon.DeviceFarm.Model.ListDevicesResponse",
        "This cmdlet returns a collection of Amazon.DeviceFarm.Model.Device objects.",
        "The service call response (type Amazon.DeviceFarm.Model.ListDevicesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDFDeviceListCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Used to select a set of devices. A filter is made up of an attribute, an operator,
        /// and one or more values.</para><ul><li><para>Attribute: The aspect of a device such as platform or model used as the selection
        /// criteria in a device filter.</para><para>Allowed values include:</para><ul><li><para>ARN: The Amazon Resource Name (ARN) of the device (for example, <c>arn:aws:devicefarm:us-west-2::device:12345Example</c>).</para></li><li><para>PLATFORM: The device platform. Valid values are ANDROID or IOS.</para></li><li><para>OS_VERSION: The operating system version (for example, 10.3.2).</para></li><li><para>MODEL: The device model (for example, iPad 5th Gen).</para></li><li><para>AVAILABILITY: The current availability of the device. Valid values are AVAILABLE,
        /// HIGHLY_AVAILABLE, BUSY, or TEMPORARY_NOT_AVAILABLE.</para></li><li><para>FORM_FACTOR: The device form factor. Valid values are PHONE or TABLET.</para></li><li><para>MANUFACTURER: The device manufacturer (for example, Apple).</para></li><li><para>REMOTE_ACCESS_ENABLED: Whether the device is enabled for remote access. Valid values
        /// are TRUE or FALSE.</para></li><li><para>REMOTE_DEBUG_ENABLED: Whether the device is enabled for remote debugging. Valid values
        /// are TRUE or FALSE. Because remote debugging is <a href="https://docs.aws.amazon.com/devicefarm/latest/developerguide/history.html">no
        /// longer supported</a>, this attribute is ignored.</para></li><li><para>INSTANCE_ARN: The Amazon Resource Name (ARN) of the device instance.</para></li><li><para>INSTANCE_LABELS: The label of the device instance.</para></li><li><para>FLEET_TYPE: The fleet type. Valid values are PUBLIC or PRIVATE.</para></li></ul></li><li><para>Operator: The filter operator.</para><ul><li><para>The EQUALS operator is available for every attribute except INSTANCE_LABELS.</para></li><li><para>The CONTAINS operator is available for the INSTANCE_LABELS and MODEL attributes.</para></li><li><para>The IN and NOT_IN operators are available for the ARN, OS_VERSION, MODEL, MANUFACTURER,
        /// and INSTANCE_ARN attributes.</para></li><li><para>The LESS_THAN, GREATER_THAN, LESS_THAN_OR_EQUALS, and GREATER_THAN_OR_EQUALS operators
        /// are also available for the OS_VERSION attribute.</para></li></ul></li><li><para>Values: An array of one or more filter values.</para><ul><li><para>The IN and NOT_IN operators take a values array that has one or more elements.</para></li><li><para>The other operators require an array with a single element.</para></li><li><para>In a request, the AVAILABILITY attribute takes the following values: AVAILABLE, HIGHLY_AVAILABLE,
        /// BUSY, or TEMPORARY_NOT_AVAILABLE.</para></li></ul></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.DeviceFarm.Model.DeviceFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous call to this operation, which can
        /// be used to return the next set of items in the list.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Devices'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.ListDevicesResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.ListDevicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Devices";
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
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.ListDevicesResponse, GetDFDeviceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.DeviceFarm.Model.DeviceFilter>(this.Filter);
            }
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DeviceFarm.Model.ListDevicesRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
        
        private Amazon.DeviceFarm.Model.ListDevicesResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.ListDevicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "ListDevices");
            try
            {
                return client.ListDevicesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<Amazon.DeviceFarm.Model.DeviceFilter> Filter { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.ListDevicesResponse, GetDFDeviceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Devices;
        }
        
    }
}
