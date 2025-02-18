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
using Amazon.SnowDeviceManagement;
using Amazon.SnowDeviceManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SDMS
{
    /// <summary>
    /// Checks the current state of the Amazon EC2 instances. The output is similar to <c>describeDevice</c>,
    /// but the results are sourced from the device cache in the Amazon Web Services Cloud
    /// and include a subset of the available fields.
    /// </summary>
    [Cmdlet("Get", "SDMSDeviceEc2Instance")]
    [OutputType("Amazon.SnowDeviceManagement.Model.InstanceSummary")]
    [AWSCmdlet("Calls the AWS Snow Device Management DescribeDeviceEc2Instances API operation.", Operation = new[] {"DescribeDeviceEc2Instances"}, SelectReturnType = typeof(Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse))]
    [AWSCmdletOutput("Amazon.SnowDeviceManagement.Model.InstanceSummary or Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse",
        "This cmdlet returns a collection of Amazon.SnowDeviceManagement.Model.InstanceSummary objects.",
        "The service call response (type Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSDMSDeviceEc2InstanceCmdlet : AmazonSnowDeviceManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>A list of instance IDs associated with the managed device.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter ManagedDeviceId
        /// <summary>
        /// <para>
        /// <para>The ID of the managed device.</para>
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
        public System.String ManagedDeviceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse).
        /// Specifying the name of a property of type Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
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
                context.Select = CreateSelectDelegate<Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse, GetSDMSDeviceEc2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.InstanceId != null)
            {
                context.InstanceId = new List<System.String>(this.InstanceId);
            }
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManagedDeviceId = this.ManagedDeviceId;
            #if MODULAR
            if (this.ManagedDeviceId == null && ParameterWasBound(nameof(this.ManagedDeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedDeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.ManagedDeviceId != null)
            {
                request.ManagedDeviceId = cmdletContext.ManagedDeviceId;
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
        
        private Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse CallAWSServiceOperation(IAmazonSnowDeviceManagement client, Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Snow Device Management", "DescribeDeviceEc2Instances");
            try
            {
                return client.DescribeDeviceEc2InstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> InstanceId { get; set; }
            public System.String ManagedDeviceId { get; set; }
            public System.Func<Amazon.SnowDeviceManagement.Model.DescribeDeviceEc2InstancesResponse, GetSDMSDeviceEc2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
