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
using Amazon.LambdaWeb;
using Amazon.LambdaWeb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LWEB
{
    /// <summary>
    /// Updates the configuration of a web function endpoint. You can modify the authorization
    /// type, auto-deployment mode, revision weights, scaling, and throttling settings.
    /// 
    ///  <note><para>
    /// This API is experimental and for internal AWS use only. It is not yet available to
    /// external customers.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "LWEBWebFunctionEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse")]
    [AWSCmdlet("Calls the Lambda Web UpdateWebFunctionEndpoint API operation.", Operation = new[] {"UpdateWebFunctionEndpoint"}, SelectReturnType = typeof(Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse))]
    [AWSCmdletOutput("Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse",
        "This cmdlet returns an Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse object containing multiple properties."
    )]
    public partial class UpdateLWEBWebFunctionEndpointCmdlet : AmazonLambdaWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The authorization type for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.AuthType")]
        public Amazon.LambdaWeb.AuthType AuthType { get; set; }
        #endregion
        
        #region Parameter AutoDeploymentMode
        /// <summary>
        /// <para>
        /// <para>The auto-deployment mode for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.AutoDeploymentMode")]
        public Amazon.LambdaWeb.AutoDeploymentMode AutoDeploymentMode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint to update. You can specify the endpoint name or the endpoint
        /// ARN. The length constraint applies only to the full ARN. If you specify only the endpoint
        /// name, it is limited to 64 characters in length.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the web function. You can specify the function name or the function ARN.
        /// The length constraint applies only to the full ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MaxEnvironment
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent execution environments for the endpoint. Minimum
        /// value of 2, maximum value of 10000. There is no default value. If you don't specify
        /// a value, the scaling configuration is absent from the response. On an update, omit
        /// <c>scalingConfig</c> to keep the current value, or specify an empty object to clear
        /// a previously set value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScalingConfig_MaxEnvironments")]
        public System.Int32? ScalingConfig_MaxEnvironment { get; set; }
        #endregion
        
        #region Parameter ThrottleConfig_RateLimit
        /// <summary>
        /// <para>
        /// <para>The maximum request rate per second for the endpoint. The value must be one of the
        /// following supported values: <c>0</c>, <c>100</c>, <c>200</c>, <c>300</c>, <c>400</c>,
        /// <c>500</c>, <c>600</c>, <c>700</c>, <c>800</c>, <c>900</c>, <c>1000</c>, <c>2000</c>,
        /// <c>3000</c>, <c>4000</c>, <c>5000</c>, <c>6000</c>, <c>7000</c>, <c>8000</c>, <c>9000</c>,
        /// or <c>10000</c>. The maximum effective value is also bounded by your account-level
        /// maximum total rate limit. There is no default value. If you don't specify a value,
        /// the throttling configuration is absent from the response. On an update, omit <c>throttleConfig</c>
        /// to keep the current value, or specify an empty object to clear a previously set value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ThrottleConfig_RateLimit { get; set; }
        #endregion
        
        #region Parameter RevisionWeight
        /// <summary>
        /// <para>
        /// <para>A list of revision weights that determine how traffic is distributed across revisions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevisionWeights")]
        public Amazon.LambdaWeb.Model.RevisionWeight[] RevisionWeight { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse).
        /// Specifying the name of a property of type Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.EndpointName),
                nameof(this.FunctionName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LWEBWebFunctionEndpoint (UpdateWebFunctionEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse, UpdateLWEBWebFunctionEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthType = this.AuthType;
            context.AutoDeploymentMode = this.AutoDeploymentMode;
            context.Description = this.Description;
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RevisionWeight != null)
            {
                context.RevisionWeight = new List<Amazon.LambdaWeb.Model.RevisionWeight>(this.RevisionWeight);
            }
            context.ScalingConfig_MaxEnvironment = this.ScalingConfig_MaxEnvironment;
            context.ThrottleConfig_RateLimit = this.ThrottleConfig_RateLimit;
            
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
            var request = new Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointRequest();
            
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.AutoDeploymentMode != null)
            {
                request.AutoDeploymentMode = cmdletContext.AutoDeploymentMode;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.RevisionWeight != null)
            {
                request.RevisionWeights = cmdletContext.RevisionWeight;
            }
            
             // populate ScalingConfig
            var requestScalingConfigIsNull = true;
            request.ScalingConfig = new Amazon.LambdaWeb.Model.ScalingConfig();
            System.Int32? requestScalingConfig_scalingConfig_MaxEnvironment = null;
            if (cmdletContext.ScalingConfig_MaxEnvironment != null)
            {
                requestScalingConfig_scalingConfig_MaxEnvironment = cmdletContext.ScalingConfig_MaxEnvironment.Value;
            }
            if (requestScalingConfig_scalingConfig_MaxEnvironment != null)
            {
                request.ScalingConfig.MaxEnvironments = requestScalingConfig_scalingConfig_MaxEnvironment.Value;
                requestScalingConfigIsNull = false;
            }
             // determine if request.ScalingConfig should be set to null
            if (requestScalingConfigIsNull)
            {
                request.ScalingConfig = null;
            }
            
             // populate ThrottleConfig
            var requestThrottleConfigIsNull = true;
            request.ThrottleConfig = new Amazon.LambdaWeb.Model.ThrottleConfig();
            System.Int32? requestThrottleConfig_throttleConfig_RateLimit = null;
            if (cmdletContext.ThrottleConfig_RateLimit != null)
            {
                requestThrottleConfig_throttleConfig_RateLimit = cmdletContext.ThrottleConfig_RateLimit.Value;
            }
            if (requestThrottleConfig_throttleConfig_RateLimit != null)
            {
                request.ThrottleConfig.RateLimit = requestThrottleConfig_throttleConfig_RateLimit.Value;
                requestThrottleConfigIsNull = false;
            }
             // determine if request.ThrottleConfig should be set to null
            if (requestThrottleConfigIsNull)
            {
                request.ThrottleConfig = null;
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
        
        private Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse CallAWSServiceOperation(IAmazonLambdaWeb client, Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda Web", "UpdateWebFunctionEndpoint");
            try
            {
                return client.UpdateWebFunctionEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LambdaWeb.AuthType AuthType { get; set; }
            public Amazon.LambdaWeb.AutoDeploymentMode AutoDeploymentMode { get; set; }
            public System.String Description { get; set; }
            public System.String EndpointName { get; set; }
            public System.String FunctionName { get; set; }
            public List<Amazon.LambdaWeb.Model.RevisionWeight> RevisionWeight { get; set; }
            public System.Int32? ScalingConfig_MaxEnvironment { get; set; }
            public System.Int32? ThrottleConfig_RateLimit { get; set; }
            public System.Func<Amazon.LambdaWeb.Model.UpdateWebFunctionEndpointResponse, UpdateLWEBWebFunctionEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
