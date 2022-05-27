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
using Amazon.EMRServerless;
using Amazon.EMRServerless.Model;

namespace Amazon.PowerShell.Cmdlets.EMRServerless
{
    /// <summary>
    /// Creates an application.
    /// </summary>
    [Cmdlet("New", "EMRServerlessApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRServerless.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the EMR Serverless CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.EMRServerless.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.EMRServerless.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.EMRServerless.Model.CreateApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMRServerlessApplicationCmdlet : AmazonEMRServerlessClientCmdlet, IExecutor
    {
        
        #region Parameter MaximumCapacity_Cpu
        /// <summary>
        /// <para>
        /// <para>The maximum allowed CPU for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Cpu { get; set; }
        #endregion
        
        #region Parameter MaximumCapacity_Disk
        /// <summary>
        /// <para>
        /// <para>The maximum allowed disk for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Disk { get; set; }
        #endregion
        
        #region Parameter AutoStartConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables the application to automatically start on job submission. Defaults to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoStartConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoStopConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables the application to automatically stop after a certain amount of time being
        /// idle. Defaults to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoStopConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoStopConfiguration_IdleTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The amount of idle time in minutes after which your application will automatically
        /// stop. Defaults to 15 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoStopConfiguration_IdleTimeoutMinutes")]
        public System.Int32? AutoStopConfiguration_IdleTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter InitialCapacity
        /// <summary>
        /// <para>
        /// <para>The capacity to initialize when the application is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable InitialCapacity { get; set; }
        #endregion
        
        #region Parameter MaximumCapacity_Memory
        /// <summary>
        /// <para>
        /// <para>The maximum allowed resources for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Memory { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The EMR release version associated with the application.</para>
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
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The array of security group Ids for customer VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroupIds")]
        public System.String[] NetworkConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The array of subnet Ids for customer VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SubnetIds")]
        public System.String[] NetworkConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of application you want to start, such as Spark or Hive.</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token of the application to create. Its value must be unique
        /// for each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRServerless.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.EMRServerless.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRServerlessApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRServerless.Model.CreateApplicationResponse, NewEMRServerlessApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoStartConfiguration_Enabled = this.AutoStartConfiguration_Enabled;
            context.AutoStopConfiguration_Enabled = this.AutoStopConfiguration_Enabled;
            context.AutoStopConfiguration_IdleTimeoutMinute = this.AutoStopConfiguration_IdleTimeoutMinute;
            context.ClientToken = this.ClientToken;
            if (this.InitialCapacity != null)
            {
                context.InitialCapacity = new Dictionary<System.String, Amazon.EMRServerless.Model.InitialCapacityConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.InitialCapacity.Keys)
                {
                    context.InitialCapacity.Add((String)hashKey, (InitialCapacityConfig)(this.InitialCapacity[hashKey]));
                }
            }
            context.MaximumCapacity_Cpu = this.MaximumCapacity_Cpu;
            context.MaximumCapacity_Disk = this.MaximumCapacity_Disk;
            context.MaximumCapacity_Memory = this.MaximumCapacity_Memory;
            context.Name = this.Name;
            if (this.NetworkConfiguration_SecurityGroupId != null)
            {
                context.NetworkConfiguration_SecurityGroupId = new List<System.String>(this.NetworkConfiguration_SecurityGroupId);
            }
            if (this.NetworkConfiguration_SubnetId != null)
            {
                context.NetworkConfiguration_SubnetId = new List<System.String>(this.NetworkConfiguration_SubnetId);
            }
            context.ReleaseLabel = this.ReleaseLabel;
            #if MODULAR
            if (this.ReleaseLabel == null && ParameterWasBound(nameof(this.ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EMRServerless.Model.CreateApplicationRequest();
            
            
             // populate AutoStartConfiguration
            var requestAutoStartConfigurationIsNull = true;
            request.AutoStartConfiguration = new Amazon.EMRServerless.Model.AutoStartConfig();
            System.Boolean? requestAutoStartConfiguration_autoStartConfiguration_Enabled = null;
            if (cmdletContext.AutoStartConfiguration_Enabled != null)
            {
                requestAutoStartConfiguration_autoStartConfiguration_Enabled = cmdletContext.AutoStartConfiguration_Enabled.Value;
            }
            if (requestAutoStartConfiguration_autoStartConfiguration_Enabled != null)
            {
                request.AutoStartConfiguration.Enabled = requestAutoStartConfiguration_autoStartConfiguration_Enabled.Value;
                requestAutoStartConfigurationIsNull = false;
            }
             // determine if request.AutoStartConfiguration should be set to null
            if (requestAutoStartConfigurationIsNull)
            {
                request.AutoStartConfiguration = null;
            }
            
             // populate AutoStopConfiguration
            var requestAutoStopConfigurationIsNull = true;
            request.AutoStopConfiguration = new Amazon.EMRServerless.Model.AutoStopConfig();
            System.Boolean? requestAutoStopConfiguration_autoStopConfiguration_Enabled = null;
            if (cmdletContext.AutoStopConfiguration_Enabled != null)
            {
                requestAutoStopConfiguration_autoStopConfiguration_Enabled = cmdletContext.AutoStopConfiguration_Enabled.Value;
            }
            if (requestAutoStopConfiguration_autoStopConfiguration_Enabled != null)
            {
                request.AutoStopConfiguration.Enabled = requestAutoStopConfiguration_autoStopConfiguration_Enabled.Value;
                requestAutoStopConfigurationIsNull = false;
            }
            System.Int32? requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute = null;
            if (cmdletContext.AutoStopConfiguration_IdleTimeoutMinute != null)
            {
                requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute = cmdletContext.AutoStopConfiguration_IdleTimeoutMinute.Value;
            }
            if (requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute != null)
            {
                request.AutoStopConfiguration.IdleTimeoutMinutes = requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute.Value;
                requestAutoStopConfigurationIsNull = false;
            }
             // determine if request.AutoStopConfiguration should be set to null
            if (requestAutoStopConfigurationIsNull)
            {
                request.AutoStopConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InitialCapacity != null)
            {
                request.InitialCapacity = cmdletContext.InitialCapacity;
            }
            
             // populate MaximumCapacity
            var requestMaximumCapacityIsNull = true;
            request.MaximumCapacity = new Amazon.EMRServerless.Model.MaximumAllowedResources();
            System.String requestMaximumCapacity_maximumCapacity_Cpu = null;
            if (cmdletContext.MaximumCapacity_Cpu != null)
            {
                requestMaximumCapacity_maximumCapacity_Cpu = cmdletContext.MaximumCapacity_Cpu;
            }
            if (requestMaximumCapacity_maximumCapacity_Cpu != null)
            {
                request.MaximumCapacity.Cpu = requestMaximumCapacity_maximumCapacity_Cpu;
                requestMaximumCapacityIsNull = false;
            }
            System.String requestMaximumCapacity_maximumCapacity_Disk = null;
            if (cmdletContext.MaximumCapacity_Disk != null)
            {
                requestMaximumCapacity_maximumCapacity_Disk = cmdletContext.MaximumCapacity_Disk;
            }
            if (requestMaximumCapacity_maximumCapacity_Disk != null)
            {
                request.MaximumCapacity.Disk = requestMaximumCapacity_maximumCapacity_Disk;
                requestMaximumCapacityIsNull = false;
            }
            System.String requestMaximumCapacity_maximumCapacity_Memory = null;
            if (cmdletContext.MaximumCapacity_Memory != null)
            {
                requestMaximumCapacity_maximumCapacity_Memory = cmdletContext.MaximumCapacity_Memory;
            }
            if (requestMaximumCapacity_maximumCapacity_Memory != null)
            {
                request.MaximumCapacity.Memory = requestMaximumCapacity_maximumCapacity_Memory;
                requestMaximumCapacityIsNull = false;
            }
             // determine if request.MaximumCapacity should be set to null
            if (requestMaximumCapacityIsNull)
            {
                request.MaximumCapacity = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.EMRServerless.Model.NetworkConfiguration();
            List<System.String> requestNetworkConfiguration_networkConfiguration_SecurityGroupId = null;
            if (cmdletContext.NetworkConfiguration_SecurityGroupId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SecurityGroupId = cmdletContext.NetworkConfiguration_SecurityGroupId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SecurityGroupId != null)
            {
                request.NetworkConfiguration.SecurityGroupIds = requestNetworkConfiguration_networkConfiguration_SecurityGroupId;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_SubnetId = null;
            if (cmdletContext.NetworkConfiguration_SubnetId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SubnetId = cmdletContext.NetworkConfiguration_SubnetId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SubnetId != null)
            {
                request.NetworkConfiguration.SubnetIds = requestNetworkConfiguration_networkConfiguration_SubnetId;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.EMRServerless.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonEMRServerless client, Amazon.EMRServerless.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EMR Serverless", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoStartConfiguration_Enabled { get; set; }
            public System.Boolean? AutoStopConfiguration_Enabled { get; set; }
            public System.Int32? AutoStopConfiguration_IdleTimeoutMinute { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, Amazon.EMRServerless.Model.InitialCapacityConfig> InitialCapacity { get; set; }
            public System.String MaximumCapacity_Cpu { get; set; }
            public System.String MaximumCapacity_Disk { get; set; }
            public System.String MaximumCapacity_Memory { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfiguration_SubnetId { get; set; }
            public System.String ReleaseLabel { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Type { get; set; }
            public System.Func<Amazon.EMRServerless.Model.CreateApplicationResponse, NewEMRServerlessApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
