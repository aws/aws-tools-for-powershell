/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

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
    /// When the status of any component on the core device becomes <code>BROKEN</code></para></li><li><para>
    /// At a <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/greengrass-nucleus-component.html#greengrass-nucleus-component-configuration-fss">regular
    /// interval that you can configure</a>, which defaults to 24 hours
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "GGV2CoreDeviceList")]
    [OutputType("Amazon.GreengrassV2.Model.CoreDevice")]
    [AWSCmdlet("Calls the AWS GreengrassV2 ListCoreDevices API operation.", Operation = new[] {"ListCoreDevices"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.ListCoreDevicesResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.CoreDevice or Amazon.GreengrassV2.Model.ListCoreDevicesResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.CoreDevice objects.",
        "The service call response (type Amazon.GreengrassV2.Model.ListCoreDevicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGV2CoreDeviceListCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The core device status by which to filter. If you specify this parameter, the list
        /// includes only core devices that have this status. Choose one of the following options:</para><ul><li><para><code>HEALTHY</code> – The IoT Greengrass Core software and all components run on
        /// the core device without issue.</para></li><li><para><code>UNHEALTHY</code> – The IoT Greengrass Core software or a component is in a
        /// failed state on the core device.</para></li></ul>
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
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
            context.NextToken = this.NextToken;
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
            // create request
            var request = new Amazon.GreengrassV2.Model.ListCoreDevicesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.ThingGroupArn != null)
            {
                request.ThingGroupArn = cmdletContext.ThingGroupArn;
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
        
        private Amazon.GreengrassV2.Model.ListCoreDevicesResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.ListCoreDevicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "ListCoreDevices");
            try
            {
                #if DESKTOP
                return client.ListCoreDevices(request);
                #elif CORECLR
                return client.ListCoreDevicesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.GreengrassV2.CoreDeviceStatus Status { get; set; }
            public System.String ThingGroupArn { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.ListCoreDevicesResponse, GetGGV2CoreDeviceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CoreDevices;
        }
        
    }
}
