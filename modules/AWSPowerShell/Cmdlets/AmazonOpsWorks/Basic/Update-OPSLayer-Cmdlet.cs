/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Updates a specified layer.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSLayer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateLayer operation against AWS OpsWorks.", Operation = new[] {"UpdateLayer"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LayerId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.OpsWorks.Model.UpdateLayerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateOPSLayerCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key/value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter AutoAssignElasticIp
        /// <summary>
        /// <para>
        /// <para>Whether to automatically assign an <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
        /// IP address</a> to the layer's instances. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoAssignElasticIps")]
        public System.Boolean AutoAssignElasticIp { get; set; }
        #endregion
        
        #region Parameter AutoAssignPublicIp
        /// <summary>
        /// <para>
        /// <para>For stacks that are running in a VPC, whether to automatically assign a public IP
        /// address to the layer's instances. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoAssignPublicIps")]
        public System.Boolean AutoAssignPublicIp { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Configure
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>configure</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Configure { get; set; }
        #endregion
        
        #region Parameter CustomInstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM profile to be used for all of the layer's EC2 instances. For more
        /// information about IAM ARNs, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomInstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A JSON-formatted string containing custom stack configuration and deployment attributes
        /// to be installed on the layer's instances. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingcookbook-json-override.html">
        /// Using Custom JSON</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomJson { get; set; }
        #endregion
        
        #region Parameter CustomSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array containing the layer's custom security group IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomSecurityGroupIds")]
        public System.String[] CustomSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Shutdown_DelayUntilElbConnectionsDrained
        /// <summary>
        /// <para>
        /// <para>Whether to enable Elastic Load Balancing connection draining. For more information,
        /// see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/TerminologyandKeyConcepts.html#conn-drain">Connection
        /// Draining</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained")]
        public System.Boolean Shutdown_DelayUntilElbConnectionsDrained { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Deploy
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>deploy</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Deploy { get; set; }
        #endregion
        
        #region Parameter EnableAutoHealing
        /// <summary>
        /// <para>
        /// <para>Whether to disable auto healing for the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableAutoHealing { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether CloudWatch Logs is enabled for a layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CloudWatchLogsConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter Shutdown_ExecutionTimeout
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that AWS OpsWorks Stacks will wait after triggering a Shutdown
        /// event before shutting down an instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LifecycleEventConfiguration_Shutdown_ExecutionTimeout")]
        public System.Int32 Shutdown_ExecutionTimeout { get; set; }
        #endregion
        
        #region Parameter InstallUpdatesOnBoot
        /// <summary>
        /// <para>
        /// <para>Whether to install operating system and package updates when the instance boots. The
        /// default value is <code>true</code>. To control when updates are installed, set this
        /// value to <code>false</code>. You must then update your instances manually by using
        /// <a>CreateDeployment</a> to run the <code>update_dependencies</code> stack command
        /// or manually running <code>yum</code> (Amazon Linux) or <code>apt-get</code> (Ubuntu)
        /// on the instances. </para><note><para>We strongly recommend using the default value of <code>true</code>, to ensure that
        /// your instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean InstallUpdatesOnBoot { get; set; }
        #endregion
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>The layer ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LayerId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsConfiguration_LogStream
        /// <summary>
        /// <para>
        /// <para>A list of configuration options for CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudWatchLogsConfiguration_LogStreams")]
        public Amazon.OpsWorks.Model.CloudWatchLogsLogStream[] CloudWatchLogsConfiguration_LogStream { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The layer name, which is used by the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Package
        /// <summary>
        /// <para>
        /// <para>An array of <code>Package</code> objects that describe the layer's packages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Packages")]
        public System.String[] Package { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Setup
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>setup</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Setup { get; set; }
        #endregion
        
        #region Parameter Shortname
        /// <summary>
        /// <para>
        /// <para>For custom layers only, use this parameter to specify the layer's short name, which
        /// is used internally by AWS OpsWorks Stacks and by Chef. The short name is also used
        /// as the name for the directory where your app files are installed. It can have a maximum
        /// of 200 characters and must be in the following format: /\A[a-z0-9\-\_\.]+\Z/.</para><para>The built-in layers' short names are defined by AWS OpsWorks Stacks. For more information,
        /// see the <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/layers.html">Layer
        /// Reference</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Shortname { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Shutdown
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>shutdown</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Shutdown { get; set; }
        #endregion
        
        #region Parameter CustomRecipes_Undeploy
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>undeploy</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Undeploy { get; set; }
        #endregion
        
        #region Parameter UseEbsOptimizedInstance
        /// <summary>
        /// <para>
        /// <para>Whether to use Amazon EBS-optimized instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseEbsOptimizedInstances")]
        public System.Boolean UseEbsOptimizedInstance { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration
        /// <summary>
        /// <para>
        /// <para>A <code>VolumeConfigurations</code> object that describes the layer's Amazon EBS volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VolumeConfigurations")]
        public Amazon.OpsWorks.Model.VolumeConfiguration[] VolumeConfiguration { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the LayerId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LayerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSLayer (UpdateLayer)"))
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            if (ParameterWasBound("AutoAssignElasticIp"))
                context.AutoAssignElasticIps = this.AutoAssignElasticIp;
            if (ParameterWasBound("AutoAssignPublicIp"))
                context.AutoAssignPublicIps = this.AutoAssignPublicIp;
            if (ParameterWasBound("CloudWatchLogsConfiguration_Enabled"))
                context.CloudWatchLogsConfiguration_Enabled = this.CloudWatchLogsConfiguration_Enabled;
            if (this.CloudWatchLogsConfiguration_LogStream != null)
            {
                context.CloudWatchLogsConfiguration_LogStreams = new List<Amazon.OpsWorks.Model.CloudWatchLogsLogStream>(this.CloudWatchLogsConfiguration_LogStream);
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
                context.CustomSecurityGroupIds = new List<System.String>(this.CustomSecurityGroupId);
            }
            if (ParameterWasBound("EnableAutoHealing"))
                context.EnableAutoHealing = this.EnableAutoHealing;
            if (ParameterWasBound("InstallUpdatesOnBoot"))
                context.InstallUpdatesOnBoot = this.InstallUpdatesOnBoot;
            context.LayerId = this.LayerId;
            if (ParameterWasBound("Shutdown_DelayUntilElbConnectionsDrained"))
                context.LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained = this.Shutdown_DelayUntilElbConnectionsDrained;
            if (ParameterWasBound("Shutdown_ExecutionTimeout"))
                context.LifecycleEventConfiguration_Shutdown_ExecutionTimeout = this.Shutdown_ExecutionTimeout;
            context.Name = this.Name;
            if (this.Package != null)
            {
                context.Packages = new List<System.String>(this.Package);
            }
            context.Shortname = this.Shortname;
            if (ParameterWasBound("UseEbsOptimizedInstance"))
                context.UseEbsOptimizedInstances = this.UseEbsOptimizedInstance;
            if (this.VolumeConfiguration != null)
            {
                context.VolumeConfigurations = new List<Amazon.OpsWorks.Model.VolumeConfiguration>(this.VolumeConfiguration);
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
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.AutoAssignElasticIps != null)
            {
                request.AutoAssignElasticIps = cmdletContext.AutoAssignElasticIps.Value;
            }
            if (cmdletContext.AutoAssignPublicIps != null)
            {
                request.AutoAssignPublicIps = cmdletContext.AutoAssignPublicIps.Value;
            }
            
             // populate CloudWatchLogsConfiguration
            bool requestCloudWatchLogsConfigurationIsNull = true;
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
            if (cmdletContext.CloudWatchLogsConfiguration_LogStreams != null)
            {
                requestCloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogStream = cmdletContext.CloudWatchLogsConfiguration_LogStreams;
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
            bool requestCustomRecipesIsNull = true;
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
            if (cmdletContext.CustomSecurityGroupIds != null)
            {
                request.CustomSecurityGroupIds = cmdletContext.CustomSecurityGroupIds;
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
            bool requestLifecycleEventConfigurationIsNull = true;
            request.LifecycleEventConfiguration = new Amazon.OpsWorks.Model.LifecycleEventConfiguration();
            Amazon.OpsWorks.Model.ShutdownEventConfiguration requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = null;
            
             // populate Shutdown
            bool requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = true;
            requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = new Amazon.OpsWorks.Model.ShutdownEventConfiguration();
            System.Boolean? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = null;
            if (cmdletContext.LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = cmdletContext.LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained.Value;
            }
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown.DelayUntilElbConnectionsDrained = requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained.Value;
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = false;
            }
            System.Int32? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout = null;
            if (cmdletContext.LifecycleEventConfiguration_Shutdown_ExecutionTimeout != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout = cmdletContext.LifecycleEventConfiguration_Shutdown_ExecutionTimeout.Value;
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
            if (cmdletContext.Packages != null)
            {
                request.Packages = cmdletContext.Packages;
            }
            if (cmdletContext.Shortname != null)
            {
                request.Shortname = cmdletContext.Shortname;
            }
            if (cmdletContext.UseEbsOptimizedInstances != null)
            {
                request.UseEbsOptimizedInstances = cmdletContext.UseEbsOptimizedInstances.Value;
            }
            if (cmdletContext.VolumeConfigurations != null)
            {
                request.VolumeConfigurations = cmdletContext.VolumeConfigurations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LayerId;
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
        
        private static Amazon.OpsWorks.Model.UpdateLayerResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateLayerRequest request)
        {
            #if DESKTOP
            return client.UpdateLayer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateLayerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.Boolean? AutoAssignElasticIps { get; set; }
            public System.Boolean? AutoAssignPublicIps { get; set; }
            public System.Boolean? CloudWatchLogsConfiguration_Enabled { get; set; }
            public List<Amazon.OpsWorks.Model.CloudWatchLogsLogStream> CloudWatchLogsConfiguration_LogStreams { get; set; }
            public System.String CustomInstanceProfileArn { get; set; }
            public System.String CustomJson { get; set; }
            public List<System.String> CustomRecipes_Configure { get; set; }
            public List<System.String> CustomRecipes_Deploy { get; set; }
            public List<System.String> CustomRecipes_Setup { get; set; }
            public List<System.String> CustomRecipes_Shutdown { get; set; }
            public List<System.String> CustomRecipes_Undeploy { get; set; }
            public List<System.String> CustomSecurityGroupIds { get; set; }
            public System.Boolean? EnableAutoHealing { get; set; }
            public System.Boolean? InstallUpdatesOnBoot { get; set; }
            public System.String LayerId { get; set; }
            public System.Boolean? LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained { get; set; }
            public System.Int32? LifecycleEventConfiguration_Shutdown_ExecutionTimeout { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Packages { get; set; }
            public System.String Shortname { get; set; }
            public System.Boolean? UseEbsOptimizedInstances { get; set; }
            public List<Amazon.OpsWorks.Model.VolumeConfiguration> VolumeConfigurations { get; set; }
        }
        
    }
}
