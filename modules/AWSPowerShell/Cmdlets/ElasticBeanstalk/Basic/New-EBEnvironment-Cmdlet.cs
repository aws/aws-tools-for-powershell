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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Launches an environment for the specified application using the specified configuration.
    /// </summary>
    [Cmdlet("New", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application that contains the version to be deployed.</para><para> If no application is found with this name, <code>CreateEnvironment</code> returns
        /// an <code>InvalidParameterValue</code> error. </para>
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
        /// <para>If specified, the environment attempts to use this value as the prefix for the CNAME.
        /// If not specified, the CNAME is generated automatically by appending a random alphanumeric
        /// string to the environment name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CNAMEPrefix { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes this environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>A unique name for the deployment environment. Used in the application URL.</para><para>Constraint: Must be from 4 to 40 characters in length. The name can contain only letters,
        /// numbers, and hyphens. It cannot start or end with a hyphen. This name must be unique
        /// within a region in your account. If the specified name already exists in the region,
        /// AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code> error. </para><para>Default: If the CNAME parameter is not specified, the environment name becomes part
        /// of the CNAME, and therefore part of the visible URL for your application.</para>
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
        /// <para>The name of this environment tier.</para><para>Valid values:</para><ul><li><para>For <i>Web server tier</i> – <code>WebServer</code></para></li><li><para>For <i>Worker tier</i> – <code>Worker</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tier_Name { get; set; }
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
        /// <para>The ARN of the platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformArn { get; set; }
        #endregion
        
        #region Parameter SolutionStackName
        /// <summary>
        /// <para>
        /// <para>This is an alternative to specifying a template name. If specified, AWS Elastic Beanstalk
        /// sets the configuration values to the default values associated with the specified
        /// solution stack.</para><para>For a list of current solution stacks, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/concepts.platforms.html">Elastic
        /// Beanstalk Supported Platforms</a>.</para>
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
        /// <para> The name of the configuration template to use in deployment. If no configuration
        /// template is found with this name, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Tier_Type
        /// <summary>
        /// <para>
        /// <para>The type of this environment tier.</para><para>Valid values:</para><ul><li><para>For <i>Web server tier</i> – <code>Standard</code></para></li><li><para>For <i>Worker tier</i> – <code>SQS/HTTP</code></para></li></ul>
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
        /// <para>The name of the application version to deploy.</para><para> If the specified application has no associated application versions, AWS Elastic
        /// Beanstalk <code>UpdateEnvironment</code> returns an <code>InvalidParameterValue</code>
        /// error. </para><para>Default: If not specified, AWS Elastic Beanstalk attempts to launch the sample application
        /// in the container.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse, NewEBEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
