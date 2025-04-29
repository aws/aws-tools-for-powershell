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
using Amazon.IoTDeviceAdvisor;
using Amazon.IoTDeviceAdvisor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTDA
{
    /// <summary>
    /// Gets information about an Device Advisor endpoint.
    /// </summary>
    [Cmdlet("Get", "IOTDAEndpoint")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Core Device Advisor GetEndpoint API operation.", Operation = new[] {"GetEndpoint"}, SelectReturnType = typeof(Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTDAEndpointCmdlet : AmazonIoTDeviceAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The authentication method used during the device connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTDeviceAdvisor.AuthenticationMethod")]
        public Amazon.IoTDeviceAdvisor.AuthenticationMethod AuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The certificate ARN of the device. This is an optional parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter DeviceRoleArn
        /// <summary>
        /// <para>
        /// <para>The device role ARN of the device. This is an optional parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceRoleArn { get; set; }
        #endregion
        
        #region Parameter ThingArn
        /// <summary>
        /// <para>
        /// <para>The thing ARN of the device. This is an optional parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThingArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Endpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse).
        /// Specifying the name of a property of type Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Endpoint";
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
                context.Select = CreateSelectDelegate<Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse, GetIOTDAEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthenticationMethod = this.AuthenticationMethod;
            context.CertificateArn = this.CertificateArn;
            context.DeviceRoleArn = this.DeviceRoleArn;
            context.ThingArn = this.ThingArn;
            
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
            var request = new Amazon.IoTDeviceAdvisor.Model.GetEndpointRequest();
            
            if (cmdletContext.AuthenticationMethod != null)
            {
                request.AuthenticationMethod = cmdletContext.AuthenticationMethod;
            }
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.DeviceRoleArn != null)
            {
                request.DeviceRoleArn = cmdletContext.DeviceRoleArn;
            }
            if (cmdletContext.ThingArn != null)
            {
                request.ThingArn = cmdletContext.ThingArn;
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
        
        private Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse CallAWSServiceOperation(IAmazonIoTDeviceAdvisor client, Amazon.IoTDeviceAdvisor.Model.GetEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Core Device Advisor", "GetEndpoint");
            try
            {
                return client.GetEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.IoTDeviceAdvisor.AuthenticationMethod AuthenticationMethod { get; set; }
            public System.String CertificateArn { get; set; }
            public System.String DeviceRoleArn { get; set; }
            public System.String ThingArn { get; set; }
            public System.Func<Amazon.IoTDeviceAdvisor.Model.GetEndpointResponse, GetIOTDAEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Endpoint;
        }
        
    }
}
