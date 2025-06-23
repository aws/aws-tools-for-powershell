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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Updates a specified layer.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSLayer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks UpdateLayer API operation.", Operation = new[] {"UpdateLayer"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.UpdateLayerResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.UpdateLayerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.OpsWorks.Model.UpdateLayerResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateOPSLayerCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key/value pairs to be added to the stack attributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter AutoAssignElasticIp
        /// <summary>
        /// <para>
        /// <para>Whether to automatically assign an <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
        /// IP address</a> to the layer's instances. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoAssignElasticIps")]
        public System.Boolean? AutoAssignElasticIp { get; set; }
        #endregion
        
        #region Parameter AutoAssignPublicIp
        /// <summary>
        /// <para>
        /// <para>For stacks that are running in a VPC, whether to automatically assign a public IP
        /// address to the layer's instances. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoAssignPublicIps")]
        public System.Boolean? AutoAssignPublicIp { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Configure
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <c>configure</c> event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomRecipes_Configure { get; set; }
        #endregion
        
        #region Parameter CustomInstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM profile to be used for all of the layer's EC2 instances. For more
        /// information about IAM ARNs, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomInstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A JSON-formatted string containing custom stack configuration and deployment attributes
        /// to be installed on the layer's instances. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingcookbook-json-override.html">
        /// Using Custom JSON</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomJson { get; set; }
        #endregion
        
        #region Parameter CustomSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array containing the layer's custom security group IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomSecurityGroupIds")]
        public System.String[] CustomSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Shutdown_DelayUntilElbConnectionsDrained
        /// <summary>
        /// <para>
        /// <para>Whether to enable Elastic Load Balancing connection draining. For more information,
        /// see <a href="https://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/TerminologyandKeyConcepts.html#conn-drain">Connection
        /// Draining</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained")]
        public System.Boolean? Shutdown_DelayUntilElbConnectionsDrained { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Deploy
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <c>deploy</c> event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomRecipes_Deploy { get; set; }
        #endregion
        
        #region Parameter EnableAutoHealing
        /// <summary>
        /// <para>
        /// <para>Whether to disable auto healing for the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableAutoHealing { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether CloudWatch Logs is enabled for a layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CloudWatchLogsConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter Shutdown_ExecutionTimeout
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that OpsWorks Stacks waits after triggering a Shutdown event
        /// before shutting down an instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LifecycleEventConfiguration_Shutdown_ExecutionTimeout")]
        public System.Int32? Shutdown_ExecutionTimeout { get; set; }
        #endregion
        
        #region Parameter InstallUpdatesOnBoot
        /// <summary>
        /// <para>
        /// <para>Whether to install operating system and package updates when the instance boots. The
        /// default value is <c>true</c>. To control when updates are installed, set this value
        /// to <c>false</c>. You must then update your instances manually by using <a>CreateDeployment</a>
        /// to run the <c>update_dependencies</c> stack command or manually running <c>yum</c>
        /// (Amazon Linux) or <c>apt-get</c> (Ubuntu) on the instances. </para><note><para>We strongly recommend using the default value of <c>true</c>, to ensure that your
        /// instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstallUpdatesOnBoot { get; set; }
        #endregion
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>The layer ID.</para>
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
        public System.String LayerId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsConfiguration_LogStream
        /// <summary>
        /// <para>
        /// <para>A list of configuration options for CloudWatch Logs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudWatchLogsConfiguration_LogStreams")]
        public Amazon.OpsWorks.Model.CloudWatchLogsLogStream[] CloudWatchLogsConfiguration_LogStream { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The layer name, which is used by the console. Layer names can be a maximum of 32 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Package
        /// <summary>
        /// <para>
        /// <para>An array of <c>Package</c> objects that describe the layer's packages.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Packages")]
        public System.String[] Package { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Setup
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <c>setup</c> event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomRecipes_Setup { get; set; }
        #endregion
        
        #region Parameter Shortname
        /// <summary>
        /// <para>
        /// <para>For custom layers only, use this parameter to specify the layer's short name, which
        /// is used internally by OpsWorks Stacks and by Chef. The short name is also used as
        /// the name for the directory where your app files are installed. It can have a maximum
        /// of 32 characters and must be in the following format: /\A[a-z0-9\-\_\.]+\Z/.</para><para>Built-in layer short names are defined by OpsWorks Stacks. For more information, see
        /// the <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/layers.html">Layer
        /// reference</a> in the OpsWorks User Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Shortname { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Shutdown
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <c>shutdown</c> event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomRecipes_Shutdown { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Undeploy
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <c>undeploy</c> event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomRecipes_Undeploy { get; set; }
        #endregion
        
        #region Parameter UseEbsOptimizedInstance
        /// <summary>
        /// <para>
        /// <para>Whether to use Amazon EBS-optimized instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseEbsOptimizedInstances")]
        public System.Boolean? UseEbsOptimizedInstance { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration
        /// <summary>
        /// <para>
        /// <para>A <c>VolumeConfigurations</c> object that describes the layer's Amazon EBS volumes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VolumeConfigurations")]
        public Amazon.OpsWorks.Model.VolumeConfiguration[] VolumeConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.UpdateLayerResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LayerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSLayer (UpdateLayer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.UpdateLayerResponse, UpdateOPSLayerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.AutoAssignElasticIp = this.AutoAssignElasticIp;
            context.AutoAssignPublicIp = this.AutoAssignPublicIp;
            context.CloudWatchLogsConfiguration_Enabled = this.CloudWatchLogsConfiguration_Enabled;
            if (this.CloudWatchLogsConfiguration_LogStream != null)
            {
                context.CloudWatchLogsConfiguration_LogStream = new List<Amazon.OpsWorks.Model.CloudWatchLogsLogStream>(this.CloudWatchLogsConfiguration_LogStream);
            }
            context.CustomInstanceProfileArn = this.CustomInstanceProfileArn;
            context.CustomJson = this.CustomJson;
            if (this.CustomRecipes_Configure != null)
            {
                context.CustomRecipes_Configure = new List<System.String>(this.CustomRecipes_Configure);
            }
            if (this.CustomRecipes_Deploy != null)
            {
                context.CustomRecipes_Deploy = new List<System.String>(this.CustomRecipes_Deploy);
            }
            if (this.CustomRecipes_Setup != null)
            {
                context.CustomRecipes_Setup = new List<System.String>(this.CustomRecipes_Setup);
            }
            if (this.CustomRecipes_Shutdown != null)
            {
                context.CustomRecipes_Shutdown = new List<System.String>(this.CustomRecipes_Shutdown);
            }
            if (this.CustomRecipes_Undeploy != null)
            {
                context.CustomRecipes_Undeploy = new List<System.String>(this.CustomRecipes_Undeploy);
            }
            if (this.CustomSecurityGroupId != null)
            {
                context.CustomSecurityGroupId = new List<System.String>(this.CustomSecurityGroupId);
            }
            context.EnableAutoHealing = this.EnableAutoHealing;
            context.InstallUpdatesOnBoot = this.InstallUpdatesOnBoot;
            context.LayerId = this.LayerId;
            #if MODULAR
            if (this.LayerId == null && ParameterWasBound(nameof(this.LayerId)))
            {
                WriteWarning("You are passing $null as a value for parameter LayerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Shutdown_DelayUntilElbConnectionsDrained = this.Shutdown_DelayUntilElbConnectionsDrained;
            context.Shutdown_ExecutionTimeout = this.Shutdown_ExecutionTimeout;
            context.Name = this.Name;
            if (this.Package != null)
            {
                context.Package = new List<System.String>(this.Package);
            }
            context.Shortname = this.Shortname;
            context.UseEbsOptimizedInstance = this.UseEbsOptimizedInstance;
            if (this.VolumeConfiguration != null)
            {
                context.VolumeConfiguration = new List<Amazon.OpsWorks.Model.VolumeConfiguration>(this.VolumeConfiguration);
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
            var request = new Amazon.OpsWorks.Model.UpdateLayerRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.AutoAssignElasticIp != null)
            {
                request.AutoAssignElasticIps = cmdletContext.AutoAssignElasticIp.Value;
            }
            if (cmdletContext.AutoAssignPublicIp != null)
            {
                request.AutoAssignPublicIps = cmdletContext.AutoAssignPublicIp.Value;
            }
            
             // populate CloudWatchLogsConfiguration
            var requestCloudWatchLogsConfigurationIsNull = true;
            request.CloudWatchLogsConfiguration = new Amazon.OpsWorks.Model.CloudWatchLogsConfiguration();
            System.Boolean? requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_Enabled = null;
            if (cmdletContext.CloudWatchLogsConfiguration_Enabled != null)
            {
                requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_Enabled = cmdletContext.CloudWatchLogsConfiguration_Enabled.Value;
            }
            if (requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_Enabled != null)
            {
                request.CloudWatchLogsConfiguration.Enabled = requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_Enabled.Value;
                requestCloudWatchLogsConfigurationIsNull = false;
            }
            List<Amazon.OpsWorks.Model.CloudWatchLogsLogStream> requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogStream = null;
            if (cmdletContext.CloudWatchLogsConfiguration_LogStream != null)
            {
                requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogStream = cmdletContext.CloudWatchLogsConfiguration_LogStream;
            }
            if (requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogStream != null)
            {
                request.CloudWatchLogsConfiguration.LogStreams = requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogStream;
                requestCloudWatchLogsConfigurationIsNull = false;
            }
             // determine if request.CloudWatchLogsConfiguration should be set to null
            if (requestCloudWatchLogsConfigurationIsNull)
            {
                request.CloudWatchLogsConfiguration = null;
            }
            if (cmdletContext.CustomInstanceProfileArn != null)
            {
                request.CustomInstanceProfileArn = cmdletContext.CustomInstanceProfileArn;
            }
            if (cmdletContext.CustomJson != null)
            {
                request.CustomJson = cmdletContext.CustomJson;
            }
            
             // populate CustomRecipes
            var requestCustomRecipesIsNull = true;
            request.CustomRecipes = new Amazon.OpsWorks.Model.Recipes();
            List<System.String> requestCustomRecipes_customRecipes_Configure = null;
            if (cmdletContext.CustomRecipes_Configure != null)
            {
                requestCustomRecipes_customRecipes_Configure = cmdletContext.CustomRecipes_Configure;
            }
            if (requestCustomRecipes_customRecipes_Configure != null)
            {
                request.CustomRecipes.Configure = requestCustomRecipes_customRecipes_Configure;
                requestCustomRecipesIsNull = false;
            }
            List<System.String> requestCustomRecipes_customRecipes_Deploy = null;
            if (cmdletContext.CustomRecipes_Deploy != null)
            {
                requestCustomRecipes_customRecipes_Deploy = cmdletContext.CustomRecipes_Deploy;
            }
            if (requestCustomRecipes_customRecipes_Deploy != null)
            {
                request.CustomRecipes.Deploy = requestCustomRecipes_customRecipes_Deploy;
                requestCustomRecipesIsNull = false;
            }
            List<System.String> requestCustomRecipes_customRecipes_Setup = null;
            if (cmdletContext.CustomRecipes_Setup != null)
            {
                requestCustomRecipes_customRecipes_Setup = cmdletContext.CustomRecipes_Setup;
            }
            if (requestCustomRecipes_customRecipes_Setup != null)
            {
                request.CustomRecipes.Setup = requestCustomRecipes_customRecipes_Setup;
                requestCustomRecipesIsNull = false;
            }
            List<System.String> requestCustomRecipes_customRecipes_Shutdown = null;
            if (cmdletContext.CustomRecipes_Shutdown != null)
            {
                requestCustomRecipes_customRecipes_Shutdown = cmdletContext.CustomRecipes_Shutdown;
            }
            if (requestCustomRecipes_customRecipes_Shutdown != null)
            {
                request.CustomRecipes.Shutdown = requestCustomRecipes_customRecipes_Shutdown;
                requestCustomRecipesIsNull = false;
            }
            List<System.String> requestCustomRecipes_customRecipes_Undeploy = null;
            if (cmdletContext.CustomRecipes_Undeploy != null)
            {
                requestCustomRecipes_customRecipes_Undeploy = cmdletContext.CustomRecipes_Undeploy;
            }
            if (requestCustomRecipes_customRecipes_Undeploy != null)
            {
                request.CustomRecipes.Undeploy = requestCustomRecipes_customRecipes_Undeploy;
                requestCustomRecipesIsNull = false;
            }
             // determine if request.CustomRecipes should be set to null
            if (requestCustomRecipesIsNull)
            {
                request.CustomRecipes = null;
            }
            if (cmdletContext.CustomSecurityGroupId != null)
            {
                request.CustomSecurityGroupIds = cmdletContext.CustomSecurityGroupId;
            }
            if (cmdletContext.EnableAutoHealing != null)
            {
                request.EnableAutoHealing = cmdletContext.EnableAutoHealing.Value;
            }
            if (cmdletContext.InstallUpdatesOnBoot != null)
            {
                request.InstallUpdatesOnBoot = cmdletContext.InstallUpdatesOnBoot.Value;
            }
            if (cmdletContext.LayerId != null)
            {
                request.LayerId = cmdletContext.LayerId;
            }
            
             // populate LifecycleEventConfiguration
            var requestLifecycleEventConfigurationIsNull = true;
            request.LifecycleEventConfiguration = new Amazon.OpsWorks.Model.LifecycleEventConfiguration();
            Amazon.OpsWorks.Model.ShutdownEventConfiguration requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = null;
            
             // populate Shutdown
            var requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = true;
            requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = new Amazon.OpsWorks.Model.ShutdownEventConfiguration();
            System.Boolean? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = null;
            if (cmdletContext.Shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = cmdletContext.Shutdown_DelayUntilElbConnectionsDrained.Value;
            }
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown.DelayUntilElbConnectionsDrained = requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained.Value;
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = false;
            }
            System.Int32? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout = null;
            if (cmdletContext.Shutdown_ExecutionTimeout != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout = cmdletContext.Shutdown_ExecutionTimeout.Value;
            }
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown.ExecutionTimeout = requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout.Value;
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = false;
            }
             // determine if requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown should be set to null
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = null;
            }
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown != null)
            {
                request.LifecycleEventConfiguration.Shutdown = requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown;
                requestLifecycleEventConfigurationIsNull = false;
            }
             // determine if request.LifecycleEventConfiguration should be set to null
            if (requestLifecycleEventConfigurationIsNull)
            {
                request.LifecycleEventConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Package != null)
            {
                request.Packages = cmdletContext.Package;
            }
            if (cmdletContext.Shortname != null)
            {
                request.Shortname = cmdletContext.Shortname;
            }
            if (cmdletContext.UseEbsOptimizedInstance != null)
            {
                request.UseEbsOptimizedInstances = cmdletContext.UseEbsOptimizedInstance.Value;
            }
            if (cmdletContext.VolumeConfiguration != null)
            {
                request.VolumeConfigurations = cmdletContext.VolumeConfiguration;
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
        
        private Amazon.OpsWorks.Model.UpdateLayerResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateLayerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "UpdateLayer");
            try
            {
                return client.UpdateLayerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.Boolean? AutoAssignElasticIp { get; set; }
            public System.Boolean? AutoAssignPublicIp { get; set; }
            public System.Boolean? CloudWatchLogsConfiguration_Enabled { get; set; }
            public List<Amazon.OpsWorks.Model.CloudWatchLogsLogStream> CloudWatchLogsConfiguration_LogStream { get; set; }
            public System.String CustomInstanceProfileArn { get; set; }
            public System.String CustomJson { get; set; }
            public List<System.String> CustomRecipes_Configure { get; set; }
            public List<System.String> CustomRecipes_Deploy { get; set; }
            public List<System.String> CustomRecipes_Setup { get; set; }
            public List<System.String> CustomRecipes_Shutdown { get; set; }
            public List<System.String> CustomRecipes_Undeploy { get; set; }
            public List<System.String> CustomSecurityGroupId { get; set; }
            public System.Boolean? EnableAutoHealing { get; set; }
            public System.Boolean? InstallUpdatesOnBoot { get; set; }
            public System.String LayerId { get; set; }
            public System.Boolean? Shutdown_DelayUntilElbConnectionsDrained { get; set; }
            public System.Int32? Shutdown_ExecutionTimeout { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Package { get; set; }
            public System.String Shortname { get; set; }
            public System.Boolean? UseEbsOptimizedInstance { get; set; }
            public List<Amazon.OpsWorks.Model.VolumeConfiguration> VolumeConfiguration { get; set; }
            public System.Func<Amazon.OpsWorks.Model.UpdateLayerResponse, UpdateOPSLayerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
