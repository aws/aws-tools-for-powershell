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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Describes the hours of operation override.
    /// </summary>
    [Cmdlet("Get", "CONNHoursOfOperationOverride")]
    [OutputType("Amazon.Connect.Model.HoursOfOperationOverride")]
    [AWSCmdlet("Calls the Amazon Connect Service DescribeHoursOfOperationOverride API operation.", Operation = new[] {"DescribeHoursOfOperationOverride"}, SelectReturnType = typeof(Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.HoursOfOperationOverride or Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse",
        "This cmdlet returns an Amazon.Connect.Model.HoursOfOperationOverride object.",
        "The service call response (type Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNHoursOfOperationOverrideCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HoursOfOperationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation.</para>
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
        public System.String HoursOfOperationId { get; set; }
        #endregion
        
        #region Parameter HoursOfOperationOverrideId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation override.</para>
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
        public System.String HoursOfOperationOverrideId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HoursOfOperationOverride'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HoursOfOperationOverride";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse, GetCONNHoursOfOperationOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HoursOfOperationId = this.HoursOfOperationId;
            #if MODULAR
            if (this.HoursOfOperationId == null && ParameterWasBound(nameof(this.HoursOfOperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HoursOfOperationOverrideId = this.HoursOfOperationOverrideId;
            #if MODULAR
            if (this.HoursOfOperationOverrideId == null && ParameterWasBound(nameof(this.HoursOfOperationOverrideId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationOverrideId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DescribeHoursOfOperationOverrideRequest();
            
            if (cmdletContext.HoursOfOperationId != null)
            {
                request.HoursOfOperationId = cmdletContext.HoursOfOperationId;
            }
            if (cmdletContext.HoursOfOperationOverrideId != null)
            {
                request.HoursOfOperationOverrideId = cmdletContext.HoursOfOperationOverrideId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DescribeHoursOfOperationOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DescribeHoursOfOperationOverride");
            try
            {
                return client.DescribeHoursOfOperationOverrideAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HoursOfOperationId { get; set; }
            public System.String HoursOfOperationOverrideId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.DescribeHoursOfOperationOverrideResponse, GetCONNHoursOfOperationOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HoursOfOperationOverride;
        }
        
    }
}
