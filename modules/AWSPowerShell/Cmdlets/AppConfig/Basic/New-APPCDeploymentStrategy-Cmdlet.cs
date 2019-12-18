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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// A deployment strategy defines important criteria for rolling out your configuration
    /// to the designated targets. A deployment strategy includes: the overall duration required,
    /// a percentage of targets to receive the deployment during each interval, an algorithm
    /// that defines how percentage grows, and bake time.
    /// </summary>
    [Cmdlet("New", "APPCDeploymentStrategy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.CreateDeploymentStrategyResponse")]
    [AWSCmdlet("Calls the AWS AppConfig CreateDeploymentStrategy API operation.", Operation = new[] {"CreateDeploymentStrategy"}, SelectReturnType = typeof(Amazon.AppConfig.Model.CreateDeploymentStrategyResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.CreateDeploymentStrategyResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.CreateDeploymentStrategyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPPCDeploymentStrategyCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentDurationInMinute
        /// <summary>
        /// <para>
        /// <para>Total amount of time for a deployment to last.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DeploymentDurationInMinutes")]
        public System.Int32? DeploymentDurationInMinute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the deployment strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FinalBakeTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time AppConfig monitors for alarms before considering the deployment
        /// to be complete and no longer eligible for automatic roll back.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FinalBakeTimeInMinutes")]
        public System.Int32? FinalBakeTimeInMinute { get; set; }
        #endregion
        
        #region Parameter GrowthFactor
        /// <summary>
        /// <para>
        /// <para>The percentage of targets to receive a deployed configuration during each interval.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Single? GrowthFactor { get; set; }
        #endregion
        
        #region Parameter GrowthType
        /// <summary>
        /// <para>
        /// <para>The algorithm used to define how percentage grows over time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppConfig.GrowthType")]
        public Amazon.AppConfig.GrowthType GrowthType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the deployment strategy.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReplicateTo
        /// <summary>
        /// <para>
        /// <para>Save the deployment strategy to a Systems Manager (SSM) document.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppConfig.ReplicateTo")]
        public Amazon.AppConfig.ReplicateTo ReplicateTo { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata to assign to the deployment strategy. Tags help organize and categorize your
        /// AppConfig resources. Each tag consists of a key and an optional value, both of which
        /// you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.CreateDeploymentStrategyResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.CreateDeploymentStrategyResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APPCDeploymentStrategy (CreateDeploymentStrategy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.CreateDeploymentStrategyResponse, NewAPPCDeploymentStrategyCmdlet>(Select) ??
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
            context.DeploymentDurationInMinute = this.DeploymentDurationInMinute;
            #if MODULAR
            if (this.DeploymentDurationInMinute == null && ParameterWasBound(nameof(this.DeploymentDurationInMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentDurationInMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.FinalBakeTimeInMinute = this.FinalBakeTimeInMinute;
            context.GrowthFactor = this.GrowthFactor;
            #if MODULAR
            if (this.GrowthFactor == null && ParameterWasBound(nameof(this.GrowthFactor)))
            {
                WriteWarning("You are passing $null as a value for parameter GrowthFactor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrowthType = this.GrowthType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicateTo = this.ReplicateTo;
            #if MODULAR
            if (this.ReplicateTo == null && ParameterWasBound(nameof(this.ReplicateTo)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicateTo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.CreateDeploymentStrategyRequest();
            
            if (cmdletContext.DeploymentDurationInMinute != null)
            {
                request.DeploymentDurationInMinutes = cmdletContext.DeploymentDurationInMinute.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FinalBakeTimeInMinute != null)
            {
                request.FinalBakeTimeInMinutes = cmdletContext.FinalBakeTimeInMinute.Value;
            }
            if (cmdletContext.GrowthFactor != null)
            {
                request.GrowthFactor = cmdletContext.GrowthFactor.Value;
            }
            if (cmdletContext.GrowthType != null)
            {
                request.GrowthType = cmdletContext.GrowthType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ReplicateTo != null)
            {
                request.ReplicateTo = cmdletContext.ReplicateTo;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.AppConfig.Model.CreateDeploymentStrategyResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.CreateDeploymentStrategyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "CreateDeploymentStrategy");
            try
            {
                #if DESKTOP
                return client.CreateDeploymentStrategy(request);
                #elif CORECLR
                return client.CreateDeploymentStrategyAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DeploymentDurationInMinute { get; set; }
            public System.String Description { get; set; }
            public System.Int32? FinalBakeTimeInMinute { get; set; }
            public System.Single? GrowthFactor { get; set; }
            public Amazon.AppConfig.GrowthType GrowthType { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppConfig.ReplicateTo ReplicateTo { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppConfig.Model.CreateDeploymentStrategyResponse, NewAPPCDeploymentStrategyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
