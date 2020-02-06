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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Registers a type with the CloudFormation service. Registering a type makes it available
    /// for use in CloudFormation templates in your AWS account, and includes:
    /// 
    ///  <ul><li><para>
    /// Validating the resource schema
    /// </para></li><li><para>
    /// Determining which handlers have been specified for the resource
    /// </para></li><li><para>
    /// Making the resource type available for use in your account
    /// </para></li></ul><para>
    /// For more information on how to develop types and ready them for registeration, see
    /// <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-types.html">Creating
    /// Resource Providers</a> in the <i>CloudFormation CLI User Guide</i>.
    /// </para><para>
    /// Once you have initiated a registration request using <code><a>RegisterType</a></code>,
    /// you can use <code><a>DescribeTypeRegistration</a></code> to monitor the progress
    /// of the registration request.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "CFNType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation RegisterType API operation.", Operation = new[] {"RegisterType"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.RegisterTypeResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.RegisterTypeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.RegisterTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterCFNTypeCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that acts as an idempotency key for this registration request.
        /// Specifying a client request token prevents CloudFormation from generating more than
        /// one version of a type from the same registeration request, even if the request is
        /// submitted multiple times. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM execution role to use to register the type.
        /// If your resource type calls AWS APIs in any of its handlers, you must create an <i><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles.html">IAM execution
        /// role</a></i> that includes the necessary permissions to call those AWS APIs, and
        /// provision that execution role in your account. CloudFormation then assumes that execution
        /// role to provide your resource type with the appropriate credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The Amazon CloudWatch log group to which CloudFormation sends error logging information
        /// when invoking the type's handlers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_LogGroupName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that CloudFormation should assume when sending log entries to
        /// CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_LogRoleArn { get; set; }
        #endregion
        
        #region Parameter SchemaHandlerPackage
        /// <summary>
        /// <para>
        /// <para>A url to the S3 bucket containing the schema handler package that contains the schema,
        /// event handlers, and associated files for the type you want to register.</para><para>For information on generating a schema handler package for the type you want to register,
        /// see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-cli-submit.html">submit</a>
        /// in the <i>CloudFormation CLI User Guide</i>.</para><note><para>As part of registering a resource provider type, CloudFormation must be able to access
        /// the S3 bucket which contains the schema handler package for that resource provider.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry.html#registry-register-permissions">IAM
        /// Permissions for Registering a Resource Provider</a> in the <i>AWS CloudFormation User
        /// Guide</i>.</para></note>
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
        public System.String SchemaHandlerPackage { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The kind of type.</para><para>Currently, the only valid value is <code>RESOURCE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.RegistryType")]
        public Amazon.CloudFormation.RegistryType Type { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the type being registered.</para><para>We recommend that type names adhere to the following pattern: <i>company_or_organization</i>::<i>service</i>::<i>type</i>.</para><note><para>The following organization namespaces are reserved and cannot be used in your resource
        /// type names:</para><ul><li><para><code>Alexa</code></para></li><li><para><code>AMZN</code></para></li><li><para><code>Amazon</code></para></li><li><para><code>AWS</code></para></li><li><para><code>Custom</code></para></li><li><para><code>Dev</code></para></li></ul></note>
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
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistrationToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.RegisterTypeResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.RegisterTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistrationToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TypeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TypeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TypeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TypeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CFNType (RegisterType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.RegisterTypeResponse, RegisterCFNTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TypeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.LoggingConfig_LogGroupName = this.LoggingConfig_LogGroupName;
            context.LoggingConfig_LogRoleArn = this.LoggingConfig_LogRoleArn;
            context.SchemaHandlerPackage = this.SchemaHandlerPackage;
            #if MODULAR
            if (this.SchemaHandlerPackage == null && ParameterWasBound(nameof(this.SchemaHandlerPackage)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaHandlerPackage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            context.TypeName = this.TypeName;
            #if MODULAR
            if (this.TypeName == null && ParameterWasBound(nameof(this.TypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFormation.Model.RegisterTypeRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate LoggingConfig
            var requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.CloudFormation.Model.LoggingConfig();
            System.String requestLoggingConfig_loggingConfig_LogGroupName = null;
            if (cmdletContext.LoggingConfig_LogGroupName != null)
            {
                requestLoggingConfig_loggingConfig_LogGroupName = cmdletContext.LoggingConfig_LogGroupName;
            }
            if (requestLoggingConfig_loggingConfig_LogGroupName != null)
            {
                request.LoggingConfig.LogGroupName = requestLoggingConfig_loggingConfig_LogGroupName;
                requestLoggingConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_LogRoleArn = null;
            if (cmdletContext.LoggingConfig_LogRoleArn != null)
            {
                requestLoggingConfig_loggingConfig_LogRoleArn = cmdletContext.LoggingConfig_LogRoleArn;
            }
            if (requestLoggingConfig_loggingConfig_LogRoleArn != null)
            {
                request.LoggingConfig.LogRoleArn = requestLoggingConfig_loggingConfig_LogRoleArn;
                requestLoggingConfigIsNull = false;
            }
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
            }
            if (cmdletContext.SchemaHandlerPackage != null)
            {
                request.SchemaHandlerPackage = cmdletContext.SchemaHandlerPackage;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
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
        
        private Amazon.CloudFormation.Model.RegisterTypeResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.RegisterTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "RegisterType");
            try
            {
                #if DESKTOP
                return client.RegisterType(request);
                #elif CORECLR
                return client.RegisterTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String LoggingConfig_LogGroupName { get; set; }
            public System.String LoggingConfig_LogRoleArn { get; set; }
            public System.String SchemaHandlerPackage { get; set; }
            public Amazon.CloudFormation.RegistryType Type { get; set; }
            public System.String TypeName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.RegisterTypeResponse, RegisterCFNTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistrationToken;
        }
        
    }
}
