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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Modify the version-specific settings of a Lambda function.
    /// 
    ///  
    /// <para>
    /// When you update a function, Lambda provisions an instance of the function and its
    /// supporting resources. If your function connects to a VPC, this process can take a
    /// minute. During this time, you can't modify the function, but you can still invoke
    /// it. The <code>LastUpdateStatus</code>, <code>LastUpdateStatusReason</code>, and <code>LastUpdateStatusReasonCode</code>
    /// fields in the response from <a>GetFunctionConfiguration</a> indicate when the update
    /// is complete and the function is processing events with the new configuration. For
    /// more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/functions-states.html">Function
    /// States</a>.
    /// </para><para>
    /// These settings can vary between versions of a function and are locked when you publish
    /// a version. You can't modify the configuration of a published version, only the unpublished
    /// version.
    /// </para><para>
    /// To configure function concurrency, use <a>PutFunctionConcurrency</a>. To grant invoke
    /// permissions to an account or AWS service, use <a>AddPermission</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateFunctionConfiguration API operation.", Operation = new[] {"UpdateFunctionConfiguration"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateFunctionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateFunctionConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMFunctionConfigurationCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.UpdateFunctionConfigurationRequest.FunctionName
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
        
        #region Parameter Handler
        /// <summary>
        /// <para>
        /// <para>The name of the method within your code that Lambda calls to execute your function.
        /// The format includes the file name. It can also include namespaces and other qualifiers,
        /// depending on the runtime. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/programming-model-v2.html">Programming
        /// Model</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Handler { get; set; }
        #endregion
        
        #region Parameter IsLayersSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.UpdateFunctionConfigurationRequest.Layers" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLayersSet { get; set; }
        #endregion
        
        #region Parameter Environment_IsVariablesSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.Lambda.Model.Environment.Variables" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Environment_IsVariablesSet { get; set; }
        #endregion
        
        #region Parameter KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Key Management Service (AWS KMS) key that's used to encrypt your
        /// function's environment variables. If it's not provided, AWS Lambda uses a default
        /// service key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter Layer
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">function
        /// layers</a> to add to the function's execution environment. Specify each layer by its
        /// ARN, including the version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layers")]
        public System.String[] Layer { get; set; }
        #endregion
        
        #region Parameter MemorySize
        /// <summary>
        /// <para>
        /// <para>The amount of memory that your function has access to. Increasing the function's memory
        /// also increases its CPU allocation. The default value is 128 MB. The value must be
        /// a multiple of 64 MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MemorySize { get; set; }
        #endregion
        
        #region Parameter TracingConfig_Mode
        /// <summary>
        /// <para>
        /// <para>The tracing mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.TracingMode")]
        public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only update the function if the revision ID matches the ID that's specified. Use this
        /// option to avoid modifying a function that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function's execution role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Runtime
        /// <summary>
        /// <para>
        /// <para>The identifier of the function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html">runtime</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.Runtime")]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter DeadLetterConfig_TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon SQS queue or Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeadLetterConfig_TargetArn { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time that Lambda allows a function to run before stopping it. The default
        /// is 3 seconds. The maximum allowed value is 900 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Environment_Variable
        /// <summary>
        /// <para>
        /// <para>Environment variable key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_Variables")]
        public System.Collections.Hashtable Environment_Variable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateFunctionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateFunctionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionConfiguration (UpdateFunctionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateFunctionConfigurationResponse, UpdateLMFunctionConfigurationCmdlet>(Select) ??
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
            context.DeadLetterConfig_TargetArn = this.DeadLetterConfig_TargetArn;
            context.Description = this.Description;
            if (this.Environment_Variable != null)
            {
                context.Environment_Variable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment_Variable.Keys)
                {
                    context.Environment_Variable.Add((String)hashKey, (String)(this.Environment_Variable[hashKey]));
                }
            }
            context.Environment_IsVariablesSet = this.Environment_IsVariablesSet;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Handler = this.Handler;
            context.KMSKeyArn = this.KMSKeyArn;
            if (this.Layer != null)
            {
                context.Layer = new List<System.String>(this.Layer);
            }
            context.IsLayersSet = this.IsLayersSet;
            context.MemorySize = this.MemorySize;
            context.RevisionId = this.RevisionId;
            context.Role = this.Role;
            context.Runtime = this.Runtime;
            context.Timeout = this.Timeout;
            context.TracingConfig_Mode = this.TracingConfig_Mode;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.Lambda.Model.UpdateFunctionConfigurationRequest();
            
            
             // populate DeadLetterConfig
            var requestDeadLetterConfigIsNull = true;
            request.DeadLetterConfig = new Amazon.Lambda.Model.DeadLetterConfig();
            System.String requestDeadLetterConfig_deadLetterConfig_TargetArn = null;
            if (cmdletContext.DeadLetterConfig_TargetArn != null)
            {
                requestDeadLetterConfig_deadLetterConfig_TargetArn = cmdletContext.DeadLetterConfig_TargetArn;
            }
            if (requestDeadLetterConfig_deadLetterConfig_TargetArn != null)
            {
                request.DeadLetterConfig.TargetArn = requestDeadLetterConfig_deadLetterConfig_TargetArn;
                requestDeadLetterConfigIsNull = false;
            }
             // determine if request.DeadLetterConfig should be set to null
            if (requestDeadLetterConfigIsNull)
            {
                request.DeadLetterConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Environment
            var requestEnvironmentIsNull = true;
            request.Environment = new Amazon.Lambda.Model.Environment();
            Dictionary<System.String, System.String> requestEnvironment_environment_Variable = null;
            if (cmdletContext.Environment_Variable != null)
            {
                requestEnvironment_environment_Variable = cmdletContext.Environment_Variable;
            }
            if (requestEnvironment_environment_Variable != null)
            {
                request.Environment.Variables = requestEnvironment_environment_Variable;
                requestEnvironmentIsNull = false;
            }
            System.Boolean? requestEnvironment_environment_IsVariablesSet = null;
            if (cmdletContext.Environment_IsVariablesSet != null)
            {
                requestEnvironment_environment_IsVariablesSet = cmdletContext.Environment_IsVariablesSet.Value;
            }
            if (requestEnvironment_environment_IsVariablesSet != null)
            {
                request.Environment.IsVariablesSet = requestEnvironment_environment_IsVariablesSet.Value;
                requestEnvironmentIsNull = false;
            }
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.Handler != null)
            {
                request.Handler = cmdletContext.Handler;
            }
            if (cmdletContext.KMSKeyArn != null)
            {
                request.KMSKeyArn = cmdletContext.KMSKeyArn;
            }
            if (cmdletContext.Layer != null)
            {
                request.Layers = cmdletContext.Layer;
            }
            if (cmdletContext.IsLayersSet != null)
            {
                request.IsLayersSet = cmdletContext.IsLayersSet.Value;
            }
            if (cmdletContext.MemorySize != null)
            {
                request.MemorySize = cmdletContext.MemorySize.Value;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Runtime != null)
            {
                request.Runtime = cmdletContext.Runtime;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            
             // populate TracingConfig
            var requestTracingConfigIsNull = true;
            request.TracingConfig = new Amazon.Lambda.Model.TracingConfig();
            Amazon.Lambda.TracingMode requestTracingConfig_tracingConfig_Mode = null;
            if (cmdletContext.TracingConfig_Mode != null)
            {
                requestTracingConfig_tracingConfig_Mode = cmdletContext.TracingConfig_Mode;
            }
            if (requestTracingConfig_tracingConfig_Mode != null)
            {
                request.TracingConfig.Mode = requestTracingConfig_tracingConfig_Mode;
                requestTracingConfigIsNull = false;
            }
             // determine if request.TracingConfig should be set to null
            if (requestTracingConfigIsNull)
            {
                request.TracingConfig = null;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Lambda.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.Lambda.Model.UpdateFunctionConfigurationResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateFunctionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateFunctionConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateFunctionConfiguration(request);
                #elif CORECLR
                return client.UpdateFunctionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DeadLetterConfig_TargetArn { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Environment_Variable { get; set; }
            public System.Boolean? Environment_IsVariablesSet { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Handler { get; set; }
            public System.String KMSKeyArn { get; set; }
            public List<System.String> Layer { get; set; }
            public System.Boolean? IsLayersSet { get; set; }
            public System.Int32? MemorySize { get; set; }
            public System.String RevisionId { get; set; }
            public System.String Role { get; set; }
            public Amazon.Lambda.Runtime Runtime { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateFunctionConfigurationResponse, UpdateLMFunctionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
