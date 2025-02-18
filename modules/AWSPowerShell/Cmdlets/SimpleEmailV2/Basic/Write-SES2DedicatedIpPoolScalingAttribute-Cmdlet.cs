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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Used to convert a dedicated IP pool to a different scaling mode.
    /// 
    ///  <note><para><c>MANAGED</c> pools cannot be converted to <c>STANDARD</c> scaling mode.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "SES2DedicatedIpPoolScalingAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutDedicatedIpPoolScalingAttributes API operation.", Operation = new[] {"PutDedicatedIpPoolScalingAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2DedicatedIpPoolScalingAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PoolName
        /// <summary>
        /// <para>
        /// <para>The name of the dedicated IP pool.</para>
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
        public System.String PoolName { get; set; }
        #endregion
        
        #region Parameter ScalingMode
        /// <summary>
        /// <para>
        /// <para>The scaling mode to apply to the dedicated IP pool.</para><note><para>Changing the scaling mode from <c>MANAGED</c> to <c>STANDARD</c> is not supported.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ScalingMode")]
        public Amazon.SimpleEmailV2.ScalingMode ScalingMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2DedicatedIpPoolScalingAttribute (PutDedicatedIpPoolScalingAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse, WriteSES2DedicatedIpPoolScalingAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PoolName = this.PoolName;
            #if MODULAR
            if (this.PoolName == null && ParameterWasBound(nameof(this.PoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingMode = this.ScalingMode;
            #if MODULAR
            if (this.ScalingMode == null && ParameterWasBound(nameof(this.ScalingMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesRequest();
            
            if (cmdletContext.PoolName != null)
            {
                request.PoolName = cmdletContext.PoolName;
            }
            if (cmdletContext.ScalingMode != null)
            {
                request.ScalingMode = cmdletContext.ScalingMode;
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
        
        private Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutDedicatedIpPoolScalingAttributes");
            try
            {
                return client.PutDedicatedIpPoolScalingAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PoolName { get; set; }
            public Amazon.SimpleEmailV2.ScalingMode ScalingMode { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutDedicatedIpPoolScalingAttributesResponse, WriteSES2DedicatedIpPoolScalingAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
