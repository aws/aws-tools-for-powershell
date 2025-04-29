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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Returns or creates a unique endpoint specific to the Amazon Web Services account making
    /// the call.
    /// 
    ///  <note><para>
    /// The first time <c>DescribeEndpoint</c> is called, an endpoint is created. All subsequent
    /// calls to <c>DescribeEndpoint</c> return the same endpoint.
    /// </para></note><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">DescribeEndpoint</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTEndpoint")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT DescribeEndpoint API operation.", Operation = new[] {"DescribeEndpoint"}, SelectReturnType = typeof(Amazon.IoT.Model.DescribeEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.DescribeEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.DescribeEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTEndpointCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The endpoint type. Valid endpoint types include:</para><ul><li><para><c>iot:Data</c> - Returns a VeriSign signed data endpoint.</para></li></ul><ul><li><para><c>iot:Data-ATS</c> - Returns an ATS signed data endpoint.</para></li></ul><ul><li><para><c>iot:CredentialProvider</c> - Returns an IoT credentials provider API endpoint.</para></li></ul><ul><li><para><c>iot:Jobs</c> - Returns an IoT device management Jobs API endpoint.</para></li></ul><para>We strongly recommend that customers use the newer <c>iot:Data-ATS</c> endpoint type
        /// to avoid issues related to the widespread distrust of Symantec certificate authorities.
        /// ATS Signed Certificates are more secure and are trusted by most popular browsers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EndpointType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointAddress'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.DescribeEndpointResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.DescribeEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointAddress";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.DescribeEndpointResponse, GetIOTEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndpointType = this.EndpointType;
            
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
            var request = new Amazon.IoT.Model.DescribeEndpointRequest();
            
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
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
        
        private Amazon.IoT.Model.DescribeEndpointResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.DescribeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "DescribeEndpoint");
            try
            {
                return client.DescribeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EndpointType { get; set; }
            public System.Func<Amazon.IoT.Model.DescribeEndpointResponse, GetIOTEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointAddress;
        }
        
    }
}
