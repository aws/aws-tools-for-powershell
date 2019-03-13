/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about unique device types.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "DFDeviceList")]
    [OutputType("Amazon.DeviceFarm.Model.Device")]
    [AWSCmdlet("Calls the AWS Device Farm ListDevices API operation.", Operation = new[] {"ListDevices"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Device",
        "This cmdlet returns a collection of Device objects.",
        "The service call response (type Amazon.DeviceFarm.Model.ListDevicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetDFDeviceListCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Used to select a set of devices. A filter is made up of an attribute, an operator,
        /// and one or more values.</para><ul><li><para>Attribute: The aspect of a device such as platform or model used as the selction criteria
        /// in a device filter.</para><para>Allowed values include:</para><ul><li><para>ARN: The Amazon Resource Name (ARN) of the device. For example, "arn:aws:devicefarm:us-west-2::device:12345Example".</para></li><li><para>PLATFORM: The device platform. Valid values are "ANDROID" or "IOS".</para></li><li><para>OS_VERSION: The operating system version. For example, "10.3.2".</para></li><li><para>MODEL: The device model. For example, "iPad 5th Gen".</para></li><li><para>AVAILABILITY: The current availability of the device. Valid values are "AVAILABLE",
        /// "HIGHLY_AVAILABLE", "BUSY", or "TEMPORARY_NOT_AVAILABLE".</para></li><li><para>FORM_FACTOR: The device form factor. Valid values are "PHONE" or "TABLET".</para></li><li><para>MANUFACTURER: The device manufacturer. For example, "Apple".</para></li><li><para>REMOTE_ACCESS_ENABLED: Whether the device is enabled for remote access. Valid values
        /// are "TRUE" or "FALSE".</para></li><li><para>REMOTE_DEBUG_ENABLED: Whether the device is enabled for remote debugging. Valid values
        /// are "TRUE" or "FALSE".</para></li><li><para>INSTANCE_ARN: The Amazon Resource Name (ARN) of the device instance.</para></li><li><para>INSTANCE_LABELS: The label of the device instance.</para></li><li><para>FLEET_TYPE: The fleet type. Valid values are "PUBLIC" or "PRIVATE".</para></li></ul></li><li><para>Operator: The filter operator.</para><ul><li><para>The EQUALS operator is available for every attribute except INSTANCE_LABELS.</para></li><li><para>The CONTAINS operator is available for the INSTANCE_LABELS and MODEL attributes.</para></li><li><para>The IN and NOT_IN operators are available for the ARN, OS_VERSION, MODEL, MANUFACTURER,
        /// and INSTANCE_ARN attributes.</para></li><li><para>The LESS_THAN, GREATER_THAN, LESS_THAN_OR_EQUALS, and GREATER_THAN_OR_EQUALS operators
        /// are also available for the OS_VERSION attribute.</para></li></ul></li><li><para>Values: An array of one or more filter values.</para><ul><li><para>The IN and NOT_IN operators take a values array that has one or more elements.</para></li><li><para>The other operators require an array with a single element.</para></li><li><para>In a request, the AVAILABILITY attribute takes "AVAILABLE", "HIGHLY_AVAILABLE", "BUSY",
        /// or "TEMPORARY_NOT_AVAILABLE" as values.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Arn = this.Arn;
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.DeviceFarm.Model.DeviceFilter>(this.Filter);
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
            
            // create request and set iteration invariants
            var request = new Amazon.DeviceFarm.Model.ListDevicesRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (ParameterWasBound("NextToken"))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Devices;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Devices.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
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
                #if DESKTOP
                return client.ListDevices(request);
                #elif CORECLR
                return client.ListDevicesAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<Amazon.DeviceFarm.Model.DeviceFilter> Filters { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
