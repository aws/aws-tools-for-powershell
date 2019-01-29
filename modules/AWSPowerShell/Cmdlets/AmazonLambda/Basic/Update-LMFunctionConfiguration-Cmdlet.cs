/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modify the version-specifc settings of a Lambda function.
    /// 
    ///  
    /// <para>
    /// These settings can vary between versions of a function and are locked when you publish
    /// a version. You cannot modify the configuration of a published version, only the unpublished
    /// version.
    /// </para><para>
    /// To configure function concurrency, use <a>PutFunctionConcurrency</a>. To grant invoke
    /// permissions to an account or AWS service, use <a>AddPermission</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateFunctionConfiguration API operation.", Operation = new[] {"UpdateFunctionConfiguration"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateFunctionConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMFunctionConfigurationCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short user-defined function description. AWS Lambda does not use this value. Assign
        /// a meaningful description as you see fit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.UpdateFunctionConfigurationRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Handler
        /// <summary>
        /// <para>
        /// <para>The function that Lambda calls to begin executing your function. For Node.js, it is
        /// the <code>module-name.export</code> value in your function. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Handler { get; set; }
        #endregion
        
        #region Parameter KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt your function's environment
        /// variables. If you elect to use the AWS Lambda default service key, pass in an empty
        /// string ("") for this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter Layer
        /// <summary>
        /// <para>
        /// <para>A list of <a href="http://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">function
        /// layers</a> to add to the function's execution environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Layers")]
        public System.String[] Layer { get; set; }
        #endregion
        
        #region Parameter MemorySize
        /// <summary>
        /// <para>
        /// <para>The amount of memory, in MB, your Lambda function is given. AWS Lambda uses this memory
        /// size to infer the amount of CPU allocated to your function. Your function use-case
        /// determines your CPU and memory requirements. For example, a database operation might
        /// need less memory compared to an image processing function. The default value is 128
        /// MB. The value must be a multiple of 64 MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MemorySize { get; set; }
        #endregion
        
        #region Parameter TracingConfig_Mode
        /// <summary>
        /// <para>
        /// <para>The tracing mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lambda.TracingMode")]
        public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only update the function if the revision ID matches the ID specified. Use this option
        /// to avoid modifying a function that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Lambda will assume when it executes
        /// your function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Runtime
        /// <summary>
        /// <para>
        /// <para>The runtime version for the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lambda.Runtime")]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter DeadLetterConfig_TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon SQS queue or Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeadLetterConfig_TargetArn { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time that Lambda allows a function to run before terminating it. The
        /// default is 3 seconds. The maximum allowed value is 900 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Timeout { get; set; }
        #endregion
        
        #region Parameter Environment_Variable
        /// <summary>
        /// <para>
        /// <para>Environment variable key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Environment_Variables")]
        public System.Collections.Hashtable Environment_Variable { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionConfiguration (UpdateFunctionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DeadLetterConfig_TargetArn = this.DeadLetterConfig_TargetArn;
            context.Description = this.Description;
            if (this.Environment_Variable != null)
            {
                context.Environment_Variables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment_Variable.Keys)
                {
                    context.Environment_Variables.Add((String)hashKey, (String)(this.Environment_Variable[hashKey]));
                }
            }
            context.FunctionName = this.FunctionName;
            context.Handler = this.Handler;
            context.KMSKeyArn = this.KMSKeyArn;
            if (this.Layer != null)
            {
                context.Layers = new List<System.String>(this.Layer);
            }
            if (ParameterWasBound("MemorySize"))
                context.MemorySize = this.MemorySize;
            context.RevisionId = this.RevisionId;
            context.Role = this.Role;
            context.Runtime = this.Runtime;
            if (ParameterWasBound("Timeout"))
                context.Timeout = this.Timeout;
            context.TracingConfig_Mode = this.TracingConfig_Mode;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupIds = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetIds = new List<System.String>(this.VpcConfig_SubnetId);
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
            bool requestDeadLetterConfigIsNull = true;
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
            bool requestEnvironmentIsNull = true;
            request.Environment = new Amazon.Lambda.Model.Environment();
            Dictionary<System.String, System.String> requestEnvironment_environment_Variable = null;
            if (cmdletContext.Environment_Variables != null)
            {
                requestEnvironment_environment_Variable = cmdletContext.Environment_Variables;
            }
            if (requestEnvironment_environment_Variable != null)
            {
                request.Environment.Variables = requestEnvironment_environment_Variable;
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
            if (cmdletContext.Layers != null)
            {
                request.Layers = cmdletContext.Layers;
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
            bool requestTracingConfigIsNull = true;
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
            bool requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Lambda.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupIds != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupIds;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetIds != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetIds;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateFunctionConfigurationAsync(request);
                return task.Result;
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
            public Dictionary<System.String, System.String> Environment_Variables { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Handler { get; set; }
            public System.String KMSKeyArn { get; set; }
            public List<System.String> Layers { get; set; }
            public System.Int32? MemorySize { get; set; }
            public System.String RevisionId { get; set; }
            public System.String Role { get; set; }
            public Amazon.Lambda.Runtime Runtime { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Lambda.TracingMode TracingConfig_Mode { get; set; }
            public List<System.String> VpcConfig_SecurityGroupIds { get; set; }
            public List<System.String> VpcConfig_SubnetIds { get; set; }
        }
        
    }
}
