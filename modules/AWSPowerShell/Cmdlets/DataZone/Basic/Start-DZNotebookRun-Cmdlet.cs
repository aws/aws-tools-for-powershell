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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Starts a notebook run in an Amazon DataZone domain. A notebook run represents the
    /// execution of a Amazon DataZone notebook within a project. You can configure compute,
    /// network, timeout, and environment settings for the run.
    /// </summary>
    [Cmdlet("Start", "DZNotebookRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.StartNotebookRunResponse")]
    [AWSCmdlet("Calls the Amazon DataZone StartNotebookRun API operation.", Operation = new[] {"StartNotebookRun"}, SelectReturnType = typeof(Amazon.DataZone.Model.StartNotebookRunResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.StartNotebookRunResponse",
        "This cmdlet returns an Amazon.DataZone.Model.StartNotebookRunResponse object containing multiple properties."
    )]
    public partial class StartDZNotebookRunCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain in which the notebook run is started.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_EnvironmentVersion
        /// <summary>
        /// <para>
        /// <para>The environment version for the notebook run compute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_EnvironmentVersion { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for the notebook run compute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_InstanceType { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The metadata for the notebook run, specified as key-value pairs. You can specify up
        /// to 50 entries, with keys up to 128 characters and values up to 1024 characters.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter TriggerSource_Name
        /// <summary>
        /// <para>
        /// <para>The name of the trigger source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TriggerSource_Name { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_NetworkAccessType
        /// <summary>
        /// <para>
        /// <para>The network access type for the notebook run. Valid values are <c>PUBLIC_INTERNET_ONLY</c>
        /// and <c>VPC_ONLY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.NetworkAccessType")]
        public Amazon.DataZone.NetworkAccessType NetworkConfiguration_NetworkAccessType { get; set; }
        #endregion
        
        #region Parameter NotebookIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the notebook to run.</para>
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
        public System.String NotebookIdentifier { get; set; }
        #endregion
        
        #region Parameter OwningProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the project that owns the notebook run.</para>
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
        public System.String OwningProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The sensitive parameters for the notebook run, specified as key-value pairs. You can
        /// specify up to 50 entries, with keys up to 128 characters and values up to 1024 characters.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter TimeoutConfiguration_RunTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The timeout for the notebook run, in minutes. The minimum value is 60 minutes (1 hour),
        /// the maximum value is 1440 minutes (24 hours), and the default value is 720 minutes
        /// (12 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutConfiguration_RunTimeoutInMinutes")]
        public System.Int32? TimeoutConfiguration_RunTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter ScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the schedule associated with the notebook run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the security groups for the notebook run. You can specify up to
        /// 5 security groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroupIds")]
        public System.String[] NetworkConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the notebook run. You can specify up to 10 subnets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SubnetIds")]
        public System.String[] NetworkConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter TriggerSource_Type
        /// <summary>
        /// <para>
        /// <para>The type of the trigger source. Valid values are <c>MANUAL</c>, <c>SCHEDULED</c>,
        /// and <c>WORKFLOW</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.TriggerSourceType")]
        public Amazon.DataZone.TriggerSourceType TriggerSource_Type { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC for the notebook run. This is required when the network
        /// access type is <c>VPC_ONLY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This field
        /// is automatically populated if not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.StartNotebookRunResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.StartNotebookRunResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainIdentifier),
                nameof(this.NotebookIdentifier),
                nameof(this.OwningProjectIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DZNotebookRun (StartNotebookRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.StartNotebookRunResponse, StartDZNotebookRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ComputeConfiguration_EnvironmentVersion = this.ComputeConfiguration_EnvironmentVersion;
            context.ComputeConfiguration_InstanceType = this.ComputeConfiguration_InstanceType;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.NetworkConfiguration_NetworkAccessType = this.NetworkConfiguration_NetworkAccessType;
            if (this.NetworkConfiguration_SecurityGroupId != null)
            {
                context.NetworkConfiguration_SecurityGroupId = new List<System.String>(this.NetworkConfiguration_SecurityGroupId);
            }
            if (this.NetworkConfiguration_SubnetId != null)
            {
                context.NetworkConfiguration_SubnetId = new List<System.String>(this.NetworkConfiguration_SubnetId);
            }
            context.NetworkConfiguration_VpcId = this.NetworkConfiguration_VpcId;
            context.NotebookIdentifier = this.NotebookIdentifier;
            #if MODULAR
            if (this.NotebookIdentifier == null && ParameterWasBound(nameof(this.NotebookIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter NotebookIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwningProjectIdentifier = this.OwningProjectIdentifier;
            #if MODULAR
            if (this.OwningProjectIdentifier == null && ParameterWasBound(nameof(this.OwningProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OwningProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            context.ScheduleIdentifier = this.ScheduleIdentifier;
            context.TimeoutConfiguration_RunTimeoutInMinute = this.TimeoutConfiguration_RunTimeoutInMinute;
            context.TriggerSource_Name = this.TriggerSource_Name;
            context.TriggerSource_Type = this.TriggerSource_Type;
            
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
            var request = new Amazon.DataZone.Model.StartNotebookRunRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ComputeConfiguration
            var requestComputeConfigurationIsNull = true;
            request.ComputeConfiguration = new Amazon.DataZone.Model.ComputeConfig();
            System.String requestComputeConfiguration_computeConfiguration_EnvironmentVersion = null;
            if (cmdletContext.ComputeConfiguration_EnvironmentVersion != null)
            {
                requestComputeConfiguration_computeConfiguration_EnvironmentVersion = cmdletContext.ComputeConfiguration_EnvironmentVersion;
            }
            if (requestComputeConfiguration_computeConfiguration_EnvironmentVersion != null)
            {
                request.ComputeConfiguration.EnvironmentVersion = requestComputeConfiguration_computeConfiguration_EnvironmentVersion;
                requestComputeConfigurationIsNull = false;
            }
            System.String requestComputeConfiguration_computeConfiguration_InstanceType = null;
            if (cmdletContext.ComputeConfiguration_InstanceType != null)
            {
                requestComputeConfiguration_computeConfiguration_InstanceType = cmdletContext.ComputeConfiguration_InstanceType;
            }
            if (requestComputeConfiguration_computeConfiguration_InstanceType != null)
            {
                request.ComputeConfiguration.InstanceType = requestComputeConfiguration_computeConfiguration_InstanceType;
                requestComputeConfigurationIsNull = false;
            }
             // determine if request.ComputeConfiguration should be set to null
            if (requestComputeConfigurationIsNull)
            {
                request.ComputeConfiguration = null;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.DataZone.Model.NetworkConfig();
            Amazon.DataZone.NetworkAccessType requestNetworkConfiguration_networkConfiguration_NetworkAccessType = null;
            if (cmdletContext.NetworkConfiguration_NetworkAccessType != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkAccessType = cmdletContext.NetworkConfiguration_NetworkAccessType;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkAccessType != null)
            {
                request.NetworkConfiguration.NetworkAccessType = requestNetworkConfiguration_networkConfiguration_NetworkAccessType;
                requestNetworkConfigurationIsNull = false;
            }
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
            System.String requestNetworkConfiguration_networkConfiguration_VpcId = null;
            if (cmdletContext.NetworkConfiguration_VpcId != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpcId = cmdletContext.NetworkConfiguration_VpcId;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpcId != null)
            {
                request.NetworkConfiguration.VpcId = requestNetworkConfiguration_networkConfiguration_VpcId;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.NotebookIdentifier != null)
            {
                request.NotebookIdentifier = cmdletContext.NotebookIdentifier;
            }
            if (cmdletContext.OwningProjectIdentifier != null)
            {
                request.OwningProjectIdentifier = cmdletContext.OwningProjectIdentifier;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ScheduleIdentifier != null)
            {
                request.ScheduleIdentifier = cmdletContext.ScheduleIdentifier;
            }
            
             // populate TimeoutConfiguration
            var requestTimeoutConfigurationIsNull = true;
            request.TimeoutConfiguration = new Amazon.DataZone.Model.TimeoutConfig();
            System.Int32? requestTimeoutConfiguration_timeoutConfiguration_RunTimeoutInMinute = null;
            if (cmdletContext.TimeoutConfiguration_RunTimeoutInMinute != null)
            {
                requestTimeoutConfiguration_timeoutConfiguration_RunTimeoutInMinute = cmdletContext.TimeoutConfiguration_RunTimeoutInMinute.Value;
            }
            if (requestTimeoutConfiguration_timeoutConfiguration_RunTimeoutInMinute != null)
            {
                request.TimeoutConfiguration.RunTimeoutInMinutes = requestTimeoutConfiguration_timeoutConfiguration_RunTimeoutInMinute.Value;
                requestTimeoutConfigurationIsNull = false;
            }
             // determine if request.TimeoutConfiguration should be set to null
            if (requestTimeoutConfigurationIsNull)
            {
                request.TimeoutConfiguration = null;
            }
            
             // populate TriggerSource
            var requestTriggerSourceIsNull = true;
            request.TriggerSource = new Amazon.DataZone.Model.TriggerSource();
            System.String requestTriggerSource_triggerSource_Name = null;
            if (cmdletContext.TriggerSource_Name != null)
            {
                requestTriggerSource_triggerSource_Name = cmdletContext.TriggerSource_Name;
            }
            if (requestTriggerSource_triggerSource_Name != null)
            {
                request.TriggerSource.Name = requestTriggerSource_triggerSource_Name;
                requestTriggerSourceIsNull = false;
            }
            Amazon.DataZone.TriggerSourceType requestTriggerSource_triggerSource_Type = null;
            if (cmdletContext.TriggerSource_Type != null)
            {
                requestTriggerSource_triggerSource_Type = cmdletContext.TriggerSource_Type;
            }
            if (requestTriggerSource_triggerSource_Type != null)
            {
                request.TriggerSource.Type = requestTriggerSource_triggerSource_Type;
                requestTriggerSourceIsNull = false;
            }
             // determine if request.TriggerSource should be set to null
            if (requestTriggerSourceIsNull)
            {
                request.TriggerSource = null;
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
        
        private Amazon.DataZone.Model.StartNotebookRunResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.StartNotebookRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "StartNotebookRun");
            try
            {
                return client.StartNotebookRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ComputeConfiguration_EnvironmentVersion { get; set; }
            public System.String ComputeConfiguration_InstanceType { get; set; }
            public System.String DomainIdentifier { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public Amazon.DataZone.NetworkAccessType NetworkConfiguration_NetworkAccessType { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfiguration_SubnetId { get; set; }
            public System.String NetworkConfiguration_VpcId { get; set; }
            public System.String NotebookIdentifier { get; set; }
            public System.String OwningProjectIdentifier { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.String ScheduleIdentifier { get; set; }
            public System.Int32? TimeoutConfiguration_RunTimeoutInMinute { get; set; }
            public System.String TriggerSource_Name { get; set; }
            public Amazon.DataZone.TriggerSourceType TriggerSource_Type { get; set; }
            public System.Func<Amazon.DataZone.Model.StartNotebookRunResponse, StartDZNotebookRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
