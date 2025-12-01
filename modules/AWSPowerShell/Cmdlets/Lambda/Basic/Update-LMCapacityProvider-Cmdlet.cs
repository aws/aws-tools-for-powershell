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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Updates the configuration of an existing capacity provider.
    /// </summary>
    [Cmdlet("Update", "LMCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CapacityProvider")]
    [AWSCmdlet("Calls the AWS Lambda UpdateCapacityProvider API operation.", Operation = new[] {"UpdateCapacityProvider"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CapacityProvider or Amazon.Lambda.Model.UpdateCapacityProviderResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CapacityProvider object.",
        "The service call response (type Amazon.Lambda.Model.UpdateCapacityProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLMCapacityProviderCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapacityProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the capacity provider to update.</para>
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
        public System.String CapacityProviderName { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_MaxVCpuCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs that the capacity provider can provision across all compute
        /// instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityProviderScalingConfig_MaxVCpuCount { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_ScalingMode
        /// <summary>
        /// <para>
        /// <para>The scaling mode that determines how the capacity provider responds to changes in
        /// demand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.CapacityProviderScalingMode")]
        public Amazon.Lambda.CapacityProviderScalingMode CapacityProviderScalingConfig_ScalingMode { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_ScalingPolicy
        /// <summary>
        /// <para>
        /// <para>A list of scaling policies that define how the capacity provider scales compute instances
        /// based on metrics and thresholds.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityProviderScalingConfig_ScalingPolicies")]
        public Amazon.Lambda.Model.TargetTrackingScalingPolicy[] CapacityProviderScalingConfig_ScalingPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMCapacityProvider (UpdateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateCapacityProviderResponse, UpdateLMCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityProviderName = this.CapacityProviderName;
            #if MODULAR
            if (this.CapacityProviderName == null && ParameterWasBound(nameof(this.CapacityProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityProviderScalingConfig_MaxVCpuCount = this.CapacityProviderScalingConfig_MaxVCpuCount;
            context.CapacityProviderScalingConfig_ScalingMode = this.CapacityProviderScalingConfig_ScalingMode;
            if (this.CapacityProviderScalingConfig_ScalingPolicy != null)
            {
                context.CapacityProviderScalingConfig_ScalingPolicy = new List<Amazon.Lambda.Model.TargetTrackingScalingPolicy>(this.CapacityProviderScalingConfig_ScalingPolicy);
            }
            
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
            var request = new Amazon.Lambda.Model.UpdateCapacityProviderRequest();
            
            if (cmdletContext.CapacityProviderName != null)
            {
                request.CapacityProviderName = cmdletContext.CapacityProviderName;
            }
            
             // populate CapacityProviderScalingConfig
            var requestCapacityProviderScalingConfigIsNull = true;
            request.CapacityProviderScalingConfig = new Amazon.Lambda.Model.CapacityProviderScalingConfig();
            System.Int32? requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount = null;
            if (cmdletContext.CapacityProviderScalingConfig_MaxVCpuCount != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount = cmdletContext.CapacityProviderScalingConfig_MaxVCpuCount.Value;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount != null)
            {
                request.CapacityProviderScalingConfig.MaxVCpuCount = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount.Value;
                requestCapacityProviderScalingConfigIsNull = false;
            }
            Amazon.Lambda.CapacityProviderScalingMode requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode = null;
            if (cmdletContext.CapacityProviderScalingConfig_ScalingMode != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode = cmdletContext.CapacityProviderScalingConfig_ScalingMode;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode != null)
            {
                request.CapacityProviderScalingConfig.ScalingMode = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode;
                requestCapacityProviderScalingConfigIsNull = false;
            }
            List<Amazon.Lambda.Model.TargetTrackingScalingPolicy> requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy = null;
            if (cmdletContext.CapacityProviderScalingConfig_ScalingPolicy != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy = cmdletContext.CapacityProviderScalingConfig_ScalingPolicy;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy != null)
            {
                request.CapacityProviderScalingConfig.ScalingPolicies = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy;
                requestCapacityProviderScalingConfigIsNull = false;
            }
             // determine if request.CapacityProviderScalingConfig should be set to null
            if (requestCapacityProviderScalingConfigIsNull)
            {
                request.CapacityProviderScalingConfig = null;
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
        
        private Amazon.Lambda.Model.UpdateCapacityProviderResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateCapacityProvider");
            try
            {
                return client.UpdateCapacityProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CapacityProviderName { get; set; }
            public System.Int32? CapacityProviderScalingConfig_MaxVCpuCount { get; set; }
            public Amazon.Lambda.CapacityProviderScalingMode CapacityProviderScalingConfig_ScalingMode { get; set; }
            public List<Amazon.Lambda.Model.TargetTrackingScalingPolicy> CapacityProviderScalingConfig_ScalingPolicy { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateCapacityProviderResponse, UpdateLMCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
