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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Retrieve the configuration properties of a flywheel iteration. For more information
    /// about flywheels, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/flywheels-about.html">
    /// Flywheel overview</a> in the <i>Amazon Comprehend Developer Guide</i>.
    /// </summary>
    [Cmdlet("Get", "COMPFlywheelIteration")]
    [OutputType("Amazon.Comprehend.Model.FlywheelIterationProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend DescribeFlywheelIteration API operation.", Operation = new[] {"DescribeFlywheelIteration"}, SelectReturnType = typeof(Amazon.Comprehend.Model.DescribeFlywheelIterationResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.FlywheelIterationProperties or Amazon.Comprehend.Model.DescribeFlywheelIterationResponse",
        "This cmdlet returns an Amazon.Comprehend.Model.FlywheelIterationProperties object.",
        "The service call response (type Amazon.Comprehend.Model.DescribeFlywheelIterationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOMPFlywheelIterationCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FlywheelArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FlywheelArn { get; set; }
        #endregion
        
        #region Parameter FlywheelIterationId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FlywheelIterationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlywheelIterationProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.DescribeFlywheelIterationResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.DescribeFlywheelIterationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlywheelIterationProperties";
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
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.DescribeFlywheelIterationResponse, GetCOMPFlywheelIterationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FlywheelArn = this.FlywheelArn;
            #if MODULAR
            if (this.FlywheelArn == null && ParameterWasBound(nameof(this.FlywheelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlywheelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlywheelIterationId = this.FlywheelIterationId;
            #if MODULAR
            if (this.FlywheelIterationId == null && ParameterWasBound(nameof(this.FlywheelIterationId)))
            {
                WriteWarning("You are passing $null as a value for parameter FlywheelIterationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Comprehend.Model.DescribeFlywheelIterationRequest();
            
            if (cmdletContext.FlywheelArn != null)
            {
                request.FlywheelArn = cmdletContext.FlywheelArn;
            }
            if (cmdletContext.FlywheelIterationId != null)
            {
                request.FlywheelIterationId = cmdletContext.FlywheelIterationId;
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
        
        private Amazon.Comprehend.Model.DescribeFlywheelIterationResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.DescribeFlywheelIterationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "DescribeFlywheelIteration");
            try
            {
                return client.DescribeFlywheelIterationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FlywheelArn { get; set; }
            public System.String FlywheelIterationId { get; set; }
            public System.Func<Amazon.Comprehend.Model.DescribeFlywheelIterationResponse, GetCOMPFlywheelIterationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlywheelIterationProperties;
        }
        
    }
}
