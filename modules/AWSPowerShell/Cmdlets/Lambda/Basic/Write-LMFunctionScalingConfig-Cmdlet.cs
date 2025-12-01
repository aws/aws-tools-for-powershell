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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Sets the scaling configuration for a Lambda Managed Instances function. The scaling
    /// configuration defines the minimum and maximum number of execution environments that
    /// can be provisioned for the function, allowing you to control scaling behavior and
    /// resource allocation.
    /// </summary>
    [Cmdlet("Write", "LMFunctionScalingConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.State")]
    [AWSCmdlet("Calls the AWS Lambda PutFunctionScalingConfig API operation.", Operation = new[] {"PutFunctionScalingConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.PutFunctionScalingConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.State or Amazon.Lambda.Model.PutFunctionScalingConfigResponse",
        "This cmdlet returns an Amazon.Lambda.State object.",
        "The service call response (type Amazon.Lambda.Model.PutFunctionScalingConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteLMFunctionScalingConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function.</para>
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionScalingConfig_MaxExecutionEnvironment
        /// <summary>
        /// <para>
        /// <para>The maximum number of execution environments that can be provisioned for the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionScalingConfig_MaxExecutionEnvironments")]
        public System.Int32? FunctionScalingConfig_MaxExecutionEnvironment { get; set; }
        #endregion
        
        #region Parameter FunctionScalingConfig_MinExecutionEnvironment
        /// <summary>
        /// <para>
        /// <para>The minimum number of execution environments to maintain for the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionScalingConfig_MinExecutionEnvironments")]
        public System.Int32? FunctionScalingConfig_MinExecutionEnvironment { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Specify a version or alias to set the scaling configuration for a published version
        /// of the function.</para>
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
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FunctionState'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PutFunctionScalingConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.PutFunctionScalingConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FunctionState";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMFunctionScalingConfig (PutFunctionScalingConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PutFunctionScalingConfigResponse, WriteLMFunctionScalingConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionScalingConfig_MaxExecutionEnvironment = this.FunctionScalingConfig_MaxExecutionEnvironment;
            context.FunctionScalingConfig_MinExecutionEnvironment = this.FunctionScalingConfig_MinExecutionEnvironment;
            context.Qualifier = this.Qualifier;
            #if MODULAR
            if (this.Qualifier == null && ParameterWasBound(nameof(this.Qualifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Qualifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.PutFunctionScalingConfigRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            
             // populate FunctionScalingConfig
            var requestFunctionScalingConfigIsNull = true;
            request.FunctionScalingConfig = new Amazon.Lambda.Model.FunctionScalingConfig();
            System.Int32? requestFunctionScalingConfig_functionScalingConfig_MaxExecutionEnvironment = null;
            if (cmdletContext.FunctionScalingConfig_MaxExecutionEnvironment != null)
            {
                requestFunctionScalingConfig_functionScalingConfig_MaxExecutionEnvironment = cmdletContext.FunctionScalingConfig_MaxExecutionEnvironment.Value;
            }
            if (requestFunctionScalingConfig_functionScalingConfig_MaxExecutionEnvironment != null)
            {
                request.FunctionScalingConfig.MaxExecutionEnvironments = requestFunctionScalingConfig_functionScalingConfig_MaxExecutionEnvironment.Value;
                requestFunctionScalingConfigIsNull = false;
            }
            System.Int32? requestFunctionScalingConfig_functionScalingConfig_MinExecutionEnvironment = null;
            if (cmdletContext.FunctionScalingConfig_MinExecutionEnvironment != null)
            {
                requestFunctionScalingConfig_functionScalingConfig_MinExecutionEnvironment = cmdletContext.FunctionScalingConfig_MinExecutionEnvironment.Value;
            }
            if (requestFunctionScalingConfig_functionScalingConfig_MinExecutionEnvironment != null)
            {
                request.FunctionScalingConfig.MinExecutionEnvironments = requestFunctionScalingConfig_functionScalingConfig_MinExecutionEnvironment.Value;
                requestFunctionScalingConfigIsNull = false;
            }
             // determine if request.FunctionScalingConfig should be set to null
            if (requestFunctionScalingConfigIsNull)
            {
                request.FunctionScalingConfig = null;
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
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
        
        private Amazon.Lambda.Model.PutFunctionScalingConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PutFunctionScalingConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PutFunctionScalingConfig");
            try
            {
                #if DESKTOP
                return client.PutFunctionScalingConfig(request);
                #elif CORECLR
                return client.PutFunctionScalingConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String FunctionName { get; set; }
            public System.Int32? FunctionScalingConfig_MaxExecutionEnvironment { get; set; }
            public System.Int32? FunctionScalingConfig_MinExecutionEnvironment { get; set; }
            public System.String Qualifier { get; set; }
            public System.Func<Amazon.Lambda.Model.PutFunctionScalingConfigResponse, WriteLMFunctionScalingConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FunctionState;
        }
        
    }
}
