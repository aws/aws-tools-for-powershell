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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Creates a system instance. 
    /// 
    ///  
    /// <para>
    /// This action validates the system instance, prepares the deployment-related resources.
    /// For Greengrass deployments, it updates the Greengrass group that is specified by the
    /// <c>greengrassGroupName</c> parameter. It also adds a file to the S3 bucket specified
    /// by the <c>s3BucketName</c> parameter. You need to call <c>DeploySystemInstance</c>
    /// after running this action.
    /// </para><para>
    /// For Greengrass deployments, since this action modifies and adds resources to a Greengrass
    /// group and an S3 bucket on the caller's behalf, the calling identity must have write
    /// permissions to both the specified Greengrass group and S3 bucket. Otherwise, the call
    /// will fail with an authorization error.
    /// </para><para>
    /// For cloud deployments, this action requires a <c>flowActionsRoleArn</c> value. This
    /// is an IAM role that has permissions to access AWS services, such as AWS Lambda and
    /// AWS IoT, that the flow uses when it executes.
    /// </para><para>
    /// If the definition document doesn't specify a version of the user's namespace, the
    /// latest version will be used by default.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "IOTTGSystemInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.SystemInstanceSummary")]
    [AWSCmdlet("Calls the AWS IoT Things Graph CreateSystemInstance API operation.", Operation = new[] {"CreateSystemInstance"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.SystemInstanceSummary or Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse",
        "This cmdlet returns an Amazon.IoTThingsGraph.Model.SystemInstanceSummary object.",
        "The service call response (type Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class NewIOTTGSystemInstanceCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MetricsConfiguration_CloudMetricEnabled
        /// <summary>
        /// <para>
        /// <para>A Boolean that specifies whether cloud metrics are collected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MetricsConfiguration_CloudMetricEnabled { get; set; }
        #endregion
        
        #region Parameter FlowActionsRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that AWS IoT Things Graph will assume when it executes the
        /// flow. This role must have read and write access to AWS Lambda and AWS IoT and any
        /// other AWS services that the flow uses when it executes. This value is required if
        /// the value of the <c>target</c> parameter is <c>CLOUD</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowActionsRoleArn { get; set; }
        #endregion
        
        #region Parameter GreengrassGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Greengrass group where the system instance will be deployed. This
        /// value is required if the value of the <c>target</c> parameter is <c>GREENGRASS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GreengrassGroupName { get; set; }
        #endregion
        
        #region Parameter Definition_Language
        /// <summary>
        /// <para>
        /// <para>The language used to define the entity. <c>GRAPHQL</c> is the only valid value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTThingsGraph.DefinitionLanguage")]
        public Amazon.IoTThingsGraph.DefinitionLanguage Definition_Language { get; set; }
        #endregion
        
        #region Parameter MetricsConfiguration_MetricRuleRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that is used to collect cloud metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsConfiguration_MetricRuleRoleArn { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Simple Storage Service bucket that will be used to store and
        /// deploy the system instance's resource file. This value is required if the value of
        /// the <c>target</c> parameter is <c>GREENGRASS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata, consisting of key-value pairs, that can be used to categorize your system
        /// instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTThingsGraph.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The target type of the deployment. Valid values are <c>GREENGRASS</c> and <c>CLOUD</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTThingsGraph.DeploymentTarget")]
        public Amazon.IoTThingsGraph.DeploymentTarget Target { get; set; }
        #endregion
        
        #region Parameter Definition_Text
        /// <summary>
        /// <para>
        /// <para>The GraphQL text that defines the entity.</para>
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
        public System.String Definition_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summary";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTGSystemInstance (CreateSystemInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse, NewIOTTGSystemInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Definition_Language = this.Definition_Language;
            #if MODULAR
            if (this.Definition_Language == null && ParameterWasBound(nameof(this.Definition_Language)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition_Language which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Definition_Text = this.Definition_Text;
            #if MODULAR
            if (this.Definition_Text == null && ParameterWasBound(nameof(this.Definition_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowActionsRoleArn = this.FlowActionsRoleArn;
            context.GreengrassGroupName = this.GreengrassGroupName;
            context.MetricsConfiguration_CloudMetricEnabled = this.MetricsConfiguration_CloudMetricEnabled;
            context.MetricsConfiguration_MetricRuleRoleArn = this.MetricsConfiguration_MetricRuleRoleArn;
            context.S3BucketName = this.S3BucketName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTThingsGraph.Model.Tag>(this.Tag);
            }
            context.Target = this.Target;
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTThingsGraph.Model.CreateSystemInstanceRequest();
            
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.IoTThingsGraph.Model.DefinitionDocument();
            Amazon.IoTThingsGraph.DefinitionLanguage requestDefinition_definition_Language = null;
            if (cmdletContext.Definition_Language != null)
            {
                requestDefinition_definition_Language = cmdletContext.Definition_Language;
            }
            if (requestDefinition_definition_Language != null)
            {
                request.Definition.Language = requestDefinition_definition_Language;
                requestDefinitionIsNull = false;
            }
            System.String requestDefinition_definition_Text = null;
            if (cmdletContext.Definition_Text != null)
            {
                requestDefinition_definition_Text = cmdletContext.Definition_Text;
            }
            if (requestDefinition_definition_Text != null)
            {
                request.Definition.Text = requestDefinition_definition_Text;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.FlowActionsRoleArn != null)
            {
                request.FlowActionsRoleArn = cmdletContext.FlowActionsRoleArn;
            }
            if (cmdletContext.GreengrassGroupName != null)
            {
                request.GreengrassGroupName = cmdletContext.GreengrassGroupName;
            }
            
             // populate MetricsConfiguration
            var requestMetricsConfigurationIsNull = true;
            request.MetricsConfiguration = new Amazon.IoTThingsGraph.Model.MetricsConfiguration();
            System.Boolean? requestMetricsConfiguration_metricsConfiguration_CloudMetricEnabled = null;
            if (cmdletContext.MetricsConfiguration_CloudMetricEnabled != null)
            {
                requestMetricsConfiguration_metricsConfiguration_CloudMetricEnabled = cmdletContext.MetricsConfiguration_CloudMetricEnabled.Value;
            }
            if (requestMetricsConfiguration_metricsConfiguration_CloudMetricEnabled != null)
            {
                request.MetricsConfiguration.CloudMetricEnabled = requestMetricsConfiguration_metricsConfiguration_CloudMetricEnabled.Value;
                requestMetricsConfigurationIsNull = false;
            }
            System.String requestMetricsConfiguration_metricsConfiguration_MetricRuleRoleArn = null;
            if (cmdletContext.MetricsConfiguration_MetricRuleRoleArn != null)
            {
                requestMetricsConfiguration_metricsConfiguration_MetricRuleRoleArn = cmdletContext.MetricsConfiguration_MetricRuleRoleArn;
            }
            if (requestMetricsConfiguration_metricsConfiguration_MetricRuleRoleArn != null)
            {
                request.MetricsConfiguration.MetricRuleRoleArn = requestMetricsConfiguration_metricsConfiguration_MetricRuleRoleArn;
                requestMetricsConfigurationIsNull = false;
            }
             // determine if request.MetricsConfiguration should be set to null
            if (requestMetricsConfigurationIsNull)
            {
                request.MetricsConfiguration = null;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
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
        
        private Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.CreateSystemInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "CreateSystemInstance");
            try
            {
                #if DESKTOP
                return client.CreateSystemInstance(request);
                #elif CORECLR
                return client.CreateSystemInstanceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTThingsGraph.DefinitionLanguage Definition_Language { get; set; }
            public System.String Definition_Text { get; set; }
            public System.String FlowActionsRoleArn { get; set; }
            public System.String GreengrassGroupName { get; set; }
            public System.Boolean? MetricsConfiguration_CloudMetricEnabled { get; set; }
            public System.String MetricsConfiguration_MetricRuleRoleArn { get; set; }
            public System.String S3BucketName { get; set; }
            public List<Amazon.IoTThingsGraph.Model.Tag> Tag { get; set; }
            public Amazon.IoTThingsGraph.DeploymentTarget Target { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.CreateSystemInstanceResponse, NewIOTTGSystemInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summary;
        }
        
    }
}
