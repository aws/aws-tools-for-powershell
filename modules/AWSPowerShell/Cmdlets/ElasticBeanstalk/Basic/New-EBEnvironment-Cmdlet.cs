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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Launches an AWS Elastic Beanstalk environment for the specified application using
    /// the specified configuration.
    /// </summary>
    [Cmdlet("New", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse object containing multiple properties."
    )]
    public partial class NewEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application that is associated with this environment.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CNAMEPrefix
        /// <summary>
        /// <para>
        /// <para>If specified, the environment attempts to use this value as the prefix for the CNAME
        /// in your Elastic Beanstalk environment URL. If not specified, the CNAME is generated
        /// automatically by appending a random alphanumeric string to the environment name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CNAMEPrefix { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Your description for this environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>A unique name for the environment.</para><para>Constraint: Must be from 4 to 40 characters in length. The name can contain only letters,
        /// numbers, and hyphens. It can't start or end with a hyphen. This name must be unique
        /// within a region in your account. If the specified name already exists in the region,
        /// Elastic Beanstalk returns an <c>InvalidParameterValue</c> error. </para><para>If you don't specify the <c>CNAMEPrefix</c> parameter, the environment name becomes
        /// part of the CNAME, and therefore part of the visible URL for your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the group to which the target environment belongs. Specify a group name
        /// only if the environment's name is specified in an environment manifest and not with
        /// the environment name parameter. See <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/environment-cfg-manifest.html">Environment
        /// Manifest (env.yaml)</a> for details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter Tier_Name
        /// <summary>
        /// <para>
        /// <para>The name of this environment tier.</para><para>Valid values:</para><ul><li><para>For <i>Web server tier</i> – <c>WebServer</c></para></li><li><para>For <i>Worker tier</i> – <c>Worker</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tier_Name { get; set; }
        #endregion
        
        #region Parameter OperationsRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an existing IAM role to be used as the environment's
        /// operations role. If specified, Elastic Beanstalk uses the operations role for permissions
        /// to downstream services during this call and during subsequent calls acting on this
        /// environment. To specify an operations role, you must have the <c>iam:PassRole</c>
        /// permission for the role. For more information, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/iam-operationsrole.html">Operations
        /// roles</a> in the <i>AWS Elastic Beanstalk Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationsRole { get; set; }
        #endregion
        
        #region Parameter OptionSetting
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk sets the specified configuration options to the
        /// requested value in the configuration set for the new environment. These override the
        /// values obtained from the solution stack or the configuration template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        #endregion
        
        #region Parameter OptionsToRemove
        /// <summary>
        /// <para>
        /// <para>A list of custom user-defined configuration options to remove from the configuration
        /// set for this new environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] OptionsToRemove { get; set; }
        #endregion
        
        #region Parameter PlatformArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the custom platform to use with the environment.
        /// For more information, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/custom-platforms.html">Custom
        /// Platforms</a> in the <i>AWS Elastic Beanstalk Developer Guide</i>.</para><note><para>If you specify <c>PlatformArn</c>, don't specify <c>SolutionStackName</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformArn { get; set; }
        #endregion
        
        #region Parameter SolutionStackName
        /// <summary>
        /// <para>
        /// <para>The name of an Elastic Beanstalk solution stack (platform version) to use with the
        /// environment. If specified, Elastic Beanstalk sets the configuration values to the
        /// default values associated with the specified solution stack. For a list of current
        /// solution stacks, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/platforms/platforms-supported.html">Elastic
        /// Beanstalk Supported Platforms</a> in the <i>AWS Elastic Beanstalk Platforms</i> guide.</para><note><para>If you specify <c>SolutionStackName</c>, don't specify <c>PlatformArn</c> or <c>TemplateName</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SolutionStackName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the tags applied to resources in the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticBeanstalk.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the Elastic Beanstalk configuration template to use with the environment.</para><note><para>If you specify <c>TemplateName</c>, then don't specify <c>SolutionStackName</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Tier_Type
        /// <summary>
        /// <para>
        /// <para>The type of this environment tier.</para><para>Valid values:</para><ul><li><para>For <i>Web server tier</i> – <c>Standard</c></para></li><li><para>For <i>Worker tier</i> – <c>SQS/HTTP</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tier_Type { get; set; }
        #endregion
        
        #region Parameter Tier_Version
        /// <summary>
        /// <para>
        /// <para>The version of this environment tier. When you don't set a value to it, Elastic Beanstalk
        /// uses the latest compatible worker tier version.</para><note><para>This member is deprecated. Any specific version that you set may become out of date.
        /// We recommend leaving it unspecified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tier_Version { get; set; }
        #endregion
        
        #region Parameter VersionLabel
        /// <summary>
        /// <para>
        /// <para>The name of the application version to deploy.</para><para>Default: If not specified, Elastic Beanstalk attempts to deploy the sample application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse, NewEBEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CNAMEPrefix = this.CNAMEPrefix;
            context.Description = this.Description;
            context.EnvironmentName = this.EnvironmentName;
            context.GroupName = this.GroupName;
            context.OperationsRole = this.OperationsRole;
            if (this.OptionSetting != null)
            {
                context.OptionSetting = new List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting>(this.OptionSetting);
            }
            if (this.OptionsToRemove != null)
            {
                context.OptionsToRemove = new List<Amazon.ElasticBeanstalk.Model.OptionSpecification>(this.OptionsToRemove);
            }
            context.PlatformArn = this.PlatformArn;
            context.SolutionStackName = this.SolutionStackName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticBeanstalk.Model.Tag>(this.Tag);
            }
            context.TemplateName = this.TemplateName;
            context.Tier_Name = this.Tier_Name;
            context.Tier_Type = this.Tier_Type;
            context.Tier_Version = this.Tier_Version;
            context.VersionLabel = this.VersionLabel;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.CreateEnvironmentRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CNAMEPrefix != null)
            {
                request.CNAMEPrefix = cmdletContext.CNAMEPrefix;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.OperationsRole != null)
            {
                request.OperationsRole = cmdletContext.OperationsRole;
            }
            if (cmdletContext.OptionSetting != null)
            {
                request.OptionSettings = cmdletContext.OptionSetting;
            }
            if (cmdletContext.OptionsToRemove != null)
            {
                request.OptionsToRemove = cmdletContext.OptionsToRemove;
            }
            if (cmdletContext.PlatformArn != null)
            {
                request.PlatformArn = cmdletContext.PlatformArn;
            }
            if (cmdletContext.SolutionStackName != null)
            {
                request.SolutionStackName = cmdletContext.SolutionStackName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            
             // populate Tier
            var requestTierIsNull = true;
            request.Tier = new Amazon.ElasticBeanstalk.Model.EnvironmentTier();
            System.String requestTier_tier_Name = null;
            if (cmdletContext.Tier_Name != null)
            {
                requestTier_tier_Name = cmdletContext.Tier_Name;
            }
            if (requestTier_tier_Name != null)
            {
                request.Tier.Name = requestTier_tier_Name;
                requestTierIsNull = false;
            }
            System.String requestTier_tier_Type = null;
            if (cmdletContext.Tier_Type != null)
            {
                requestTier_tier_Type = cmdletContext.Tier_Type;
            }
            if (requestTier_tier_Type != null)
            {
                request.Tier.Type = requestTier_tier_Type;
                requestTierIsNull = false;
            }
            System.String requestTier_tier_Version = null;
            if (cmdletContext.Tier_Version != null)
            {
                requestTier_tier_Version = cmdletContext.Tier_Version;
            }
            if (requestTier_tier_Version != null)
            {
                request.Tier.Version = requestTier_tier_Version;
                requestTierIsNull = false;
            }
             // determine if request.Tier should be set to null
            if (requestTierIsNull)
            {
                request.Tier = null;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
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
        
        private Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "CreateEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateEnvironment(request);
                #elif CORECLR
                return client.CreateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.String CNAMEPrefix { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String GroupName { get; set; }
            public System.String OperationsRole { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting> OptionSetting { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.OptionSpecification> OptionsToRemove { get; set; }
            public System.String PlatformArn { get; set; }
            public System.String SolutionStackName { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.Tag> Tag { get; set; }
            public System.String TemplateName { get; set; }
            public System.String Tier_Name { get; set; }
            public System.String Tier_Type { get; set; }
            public System.String Tier_Version { get; set; }
            public System.String VersionLabel { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse, NewEBEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
