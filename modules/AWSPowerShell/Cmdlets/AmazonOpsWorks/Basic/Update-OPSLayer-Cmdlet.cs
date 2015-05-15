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
        "The service response (type UpdateLayerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateOPSLayerCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key/value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to automatically assign an <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
        /// IP address</a> to the layer's instances. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoAssignElasticIps { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For stacks that are running in a VPC, whether to automatically assign a public IP
        /// address to the layer's instances. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinglayers-basics-edit.html">How
        /// to Edit a Layer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoAssignPublicIps { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>configure</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Configure { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM profile to be used for all of the layer's EC2 instances. For more
        /// information about IAM ARNs, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomInstanceProfileArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array containing the layer's custom security group IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomSecurityGroupIds")]
        public System.String[] CustomSecurityGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to enable Elastic Load Balancing connection draining. For more information,
        /// see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/TerminologyandKeyConcepts.html#conn-drain">Connection
        /// Draining</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained")]
        public Boolean Shutdown_DelayUntilElbConnectionsDrained { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>deploy</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Deploy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to disable auto healing for the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean EnableAutoHealing { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that AWS OpsWorks will wait after triggering a Shutdown event
        /// before shutting down an instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LifecycleEventConfiguration_Shutdown_ExecutionTimeout")]
        public Int32 Shutdown_ExecutionTimeout { get; set; }
        
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
        public Boolean InstallUpdatesOnBoot { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The layer ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LayerId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The layer name, which is used by the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of <code>Package</code> objects that describe the layer's packages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Packages")]
        public System.String[] Package { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>setup</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Setup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For custom layers only, use this parameter to specify the layer's short name, which
        /// is used internally by AWS OpsWorksand by Chef. The short name is also used as the
        /// name for the directory where your app files are installed. It can have a maximum of
        /// 200 characters and must be in the following format: /\A[a-z0-9\-\_\.]+\Z/.</para><para>The built-in layers' short names are defined by AWS OpsWorks. For more information,
        /// see the <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/layers.html">Layer
        /// Reference</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Shortname { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>shutdown</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Shutdown { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of custom recipe names to be run following a <code>undeploy</code> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CustomRecipes_Undeploy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to use Amazon EBS-optimized instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean UseEbsOptimizedInstances { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A <code>VolumeConfigurations</code> object that describes the layer's Amazon EBS volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VolumeConfigurations")]
        public Amazon.OpsWorks.Model.VolumeConfiguration[] VolumeConfiguration { get; set; }
        
        /// <summary>
        /// Returns the value passed to the LayerId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            if (ParameterWasBound("AutoAssignElasticIps"))
                context.AutoAssignElasticIps = this.AutoAssignElasticIps;
            if (ParameterWasBound("AutoAssignPublicIps"))
                context.AutoAssignPublicIps = this.AutoAssignPublicIps;
            context.CustomInstanceProfileArn = this.CustomInstanceProfileArn;
            if (this.CustomRecipes_Configure != null)
            {
                context.CustomRecipes_Configure = new List<String>(this.CustomRecipes_Configure);
            }
            if (this.CustomRecipes_Deploy != null)
            {
                context.CustomRecipes_Deploy = new List<String>(this.CustomRecipes_Deploy);
            }
            if (this.CustomRecipes_Setup != null)
            {
                context.CustomRecipes_Setup = new List<String>(this.CustomRecipes_Setup);
            }
            if (this.CustomRecipes_Shutdown != null)
            {
                context.CustomRecipes_Shutdown = new List<String>(this.CustomRecipes_Shutdown);
            }
            if (this.CustomRecipes_Undeploy != null)
            {
                context.CustomRecipes_Undeploy = new List<String>(this.CustomRecipes_Undeploy);
            }
            if (this.CustomSecurityGroupId != null)
            {
                context.CustomSecurityGroupIds = new List<String>(this.CustomSecurityGroupId);
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
                context.Packages = new List<String>(this.Package);
            }
            context.Shortname = this.Shortname;
            if (ParameterWasBound("UseEbsOptimizedInstances"))
                context.UseEbsOptimizedInstances = this.UseEbsOptimizedInstances;
            if (this.VolumeConfiguration != null)
            {
                context.VolumeConfigurations = new List<VolumeConfiguration>(this.VolumeConfiguration);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateLayerRequest();
            
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
            if (cmdletContext.CustomInstanceProfileArn != null)
            {
                request.CustomInstanceProfileArn = cmdletContext.CustomInstanceProfileArn;
            }
            
             // populate CustomRecipes
            bool requestCustomRecipesIsNull = true;
            request.CustomRecipes = new Recipes();
            List<String> requestCustomRecipes_customRecipes_Configure = null;
            if (cmdletContext.CustomRecipes_Configure != null)
            {
                requestCustomRecipes_customRecipes_Configure = cmdletContext.CustomRecipes_Configure;
            }
            if (requestCustomRecipes_customRecipes_Configure != null)
            {
                request.CustomRecipes.Configure = requestCustomRecipes_customRecipes_Configure;
                requestCustomRecipesIsNull = false;
            }
            List<String> requestCustomRecipes_customRecipes_Deploy = null;
            if (cmdletContext.CustomRecipes_Deploy != null)
            {
                requestCustomRecipes_customRecipes_Deploy = cmdletContext.CustomRecipes_Deploy;
            }
            if (requestCustomRecipes_customRecipes_Deploy != null)
            {
                request.CustomRecipes.Deploy = requestCustomRecipes_customRecipes_Deploy;
                requestCustomRecipesIsNull = false;
            }
            List<String> requestCustomRecipes_customRecipes_Setup = null;
            if (cmdletContext.CustomRecipes_Setup != null)
            {
                requestCustomRecipes_customRecipes_Setup = cmdletContext.CustomRecipes_Setup;
            }
            if (requestCustomRecipes_customRecipes_Setup != null)
            {
                request.CustomRecipes.Setup = requestCustomRecipes_customRecipes_Setup;
                requestCustomRecipesIsNull = false;
            }
            List<String> requestCustomRecipes_customRecipes_Shutdown = null;
            if (cmdletContext.CustomRecipes_Shutdown != null)
            {
                requestCustomRecipes_customRecipes_Shutdown = cmdletContext.CustomRecipes_Shutdown;
            }
            if (requestCustomRecipes_customRecipes_Shutdown != null)
            {
                request.CustomRecipes.Shutdown = requestCustomRecipes_customRecipes_Shutdown;
                requestCustomRecipesIsNull = false;
            }
            List<String> requestCustomRecipes_customRecipes_Undeploy = null;
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
            request.LifecycleEventConfiguration = new LifecycleEventConfiguration();
            ShutdownEventConfiguration requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = null;
            
             // populate Shutdown
            bool requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = true;
            requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown = new ShutdownEventConfiguration();
            Boolean? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = null;
            if (cmdletContext.LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained = cmdletContext.LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained.Value;
            }
            if (requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained != null)
            {
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown.DelayUntilElbConnectionsDrained = requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_DelayUntilElbConnectionsDrained.Value;
                requestLifecycleEventConfiguration_lifecycleEventConfiguration_ShutdownIsNull = false;
            }
            Int32? requestLifecycleEventConfiguration_lifecycleEventConfiguration_Shutdown_shutdown_ExecutionTimeout = null;
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
                var response = client.UpdateLayer(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<String, String> Attributes { get; set; }
            public Boolean? AutoAssignElasticIps { get; set; }
            public Boolean? AutoAssignPublicIps { get; set; }
            public String CustomInstanceProfileArn { get; set; }
            public List<String> CustomRecipes_Configure { get; set; }
            public List<String> CustomRecipes_Deploy { get; set; }
            public List<String> CustomRecipes_Setup { get; set; }
            public List<String> CustomRecipes_Shutdown { get; set; }
            public List<String> CustomRecipes_Undeploy { get; set; }
            public List<String> CustomSecurityGroupIds { get; set; }
            public Boolean? EnableAutoHealing { get; set; }
            public Boolean? InstallUpdatesOnBoot { get; set; }
            public String LayerId { get; set; }
            public Boolean? LifecycleEventConfiguration_Shutdown_DelayUntilElbConnectionsDrained { get; set; }
            public Int32? LifecycleEventConfiguration_Shutdown_ExecutionTimeout { get; set; }
            public String Name { get; set; }
            public List<String> Packages { get; set; }
            public String Shortname { get; set; }
            public Boolean? UseEbsOptimizedInstances { get; set; }
            public List<VolumeConfiguration> VolumeConfigurations { get; set; }
        }
        
    }
}
