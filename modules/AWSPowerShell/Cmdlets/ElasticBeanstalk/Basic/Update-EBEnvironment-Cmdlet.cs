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
    /// Updates the environment description, deploys a new application version, updates the
    /// configuration settings to an entirely new configuration template, or updates select
    /// configuration option values in the running environment.
    /// 
    ///  
    /// <para>
    ///  Attempting to update both the release and configuration is not allowed and AWS Elastic
    /// Beanstalk returns an <c>InvalidParameterCombination</c> error. 
    /// </para><para>
    ///  When updating the configuration settings to a new template or individual settings,
    /// a draft configuration is created and <a>DescribeConfigurationSettings</a> for this
    /// environment returns two setting descriptions with different <c>DeploymentStatus</c>
    /// values. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse object containing multiple properties."
    )]
    public partial class UpdateEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application with which the environment is associated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>If this parameter is specified, AWS Elastic Beanstalk updates the description of this
        /// environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to update.</para><para>If no environment with this ID exists, AWS Elastic Beanstalk returns an <c>InvalidParameterValue</c>
        /// error.</para><para>Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the environment to update. If no environment with this name exists, AWS
        /// Elastic Beanstalk returns an <c>InvalidParameterValue</c> error. </para><para>Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c> error.
        /// </para>
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
        /// the environment name or environment ID parameters. See <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/environment-cfg-manifest.html">Environment
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
        
        #region Parameter OptionSetting
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk updates the configuration set associated with
        /// the running environment and sets the specified configuration options to the requested
        /// value.</para>
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
        /// set for this environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] OptionsToRemove { get; set; }
        #endregion
        
        #region Parameter PlatformArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the platform, if used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformArn { get; set; }
        #endregion
        
        #region Parameter SolutionStackName
        /// <summary>
        /// <para>
        /// <para>This specifies the platform version that the environment will run after the environment
        /// is updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SolutionStackName { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>If this parameter is specified, AWS Elastic Beanstalk deploys this configuration template
        /// to the environment. If no such configuration template is found, AWS Elastic Beanstalk
        /// returns an <c>InvalidParameterValue</c> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
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
        /// <para>If this parameter is specified, AWS Elastic Beanstalk deploys the named application
        /// version to the environment. If no such application version is found, returns an <c>InvalidParameterValue</c>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EBEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse, UpdateEBEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
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
            var request = new Amazon.ElasticBeanstalk.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
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
        
        private Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String GroupName { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting> OptionSetting { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.OptionSpecification> OptionsToRemove { get; set; }
            public System.String PlatformArn { get; set; }
            public System.String SolutionStackName { get; set; }
            public System.String TemplateName { get; set; }
            public System.String Tier_Name { get; set; }
            public System.String Tier_Type { get; set; }
            public System.String Tier_Version { get; set; }
            public System.String VersionLabel { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResponse, UpdateEBEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
