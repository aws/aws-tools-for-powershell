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
using Amazon.PCS;
using Amazon.PCS.Model;

namespace Amazon.PowerShell.Cmdlets.PCS
{
    /// <summary>
    /// Creates a cluster in your account. Amazon Web Services PCS creates the cluster controller
    /// in a service-owned account. The cluster controller communicates with the cluster resources
    /// in your account. The subnets and security groups for the cluster must already exist
    /// before you use this API action.
    /// 
    ///  <note><para>
    /// It takes time for Amazon Web Services PCS to create the cluster. The cluster is in
    /// a <c>Creating</c> state until it is ready to use. There can only be 1 cluster in a
    /// <c>Creating</c> state per Amazon Web Services Region per Amazon Web Services account.
    /// <c>CreateCluster</c> fails with a <c>ServiceQuotaExceededException</c> if there is
    /// already a cluster in a <c>Creating</c> state.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PCSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PCS.Model.Cluster")]
    [AWSCmdlet("Calls the AWS Parallel Computing Service CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.PCS.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.PCS.Model.Cluster or Amazon.PCS.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.PCS.Model.Cluster object.",
        "The service call response (type Amazon.PCS.Model.CreateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCSClusterCmdlet : AmazonPCSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>A name to identify the cluster. Example: <c>MyCluster</c></para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_ScaleDownIdleTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The time before an idle node is scaled down.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_ScaleDownIdleTimeInSeconds")]
        public System.Int32? SlurmConfiguration_ScaleDownIdleTimeInSecond { get; set; }
        #endregion
        
        #region Parameter Networking_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group IDs associated with the Elastic Network Interface (ENI) created
        /// in subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Networking_SecurityGroupIds")]
        public System.String[] Networking_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>A value that determines the maximum number of compute nodes in the cluster and the
        /// maximum number of jobs (active and queued).</para><ul><li><para><c>SMALL</c>: 32 compute nodes and 256 jobs</para></li><li><para><c>MEDIUM</c>: 512 compute nodes and 8192 jobs</para></li><li><para><c>LARGE</c>: 2048 compute nodes and 16,384 jobs</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PCS.Size")]
        public Amazon.PCS.Size Size { get; set; }
        #endregion
        
        #region Parameter SlurmConfiguration_SlurmCustomSetting
        /// <summary>
        /// <para>
        /// <para>Additional Slurm-specific configuration that directly maps to Slurm settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlurmConfiguration_SlurmCustomSettings")]
        public Amazon.PCS.Model.SlurmCustomSetting[] SlurmConfiguration_SlurmCustomSetting { get; set; }
        #endregion
        
        #region Parameter Networking_SubnetId
        /// <summary>
        /// <para>
        /// <para>The list of subnet IDs where Amazon Web Services PCS creates an Elastic Network Interface
        /// (ENI) to enable communication between managed controllers and Amazon Web Services
        /// PCS resources. Subnet IDs have the form <c>subnet-0123456789abcdef0</c>.</para><para>Subnets can't be in Outposts, Wavelength or an Amazon Web Services Local Zone.</para><note><para>Amazon Web Services PCS currently supports only 1 subnet in this list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Networking_SubnetIds")]
        public System.String[] Networking_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>1 or more tags added to the resource. Each tag consists of a tag key and tag value.
        /// The tag value is optional and can be an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Scheduler_Type
        /// <summary>
        /// <para>
        /// <para>The software Amazon Web Services PCS uses to manage cluster scaling and job scheduling.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PCS.SchedulerType")]
        public Amazon.PCS.SchedulerType Scheduler_Type { get; set; }
        #endregion
        
        #region Parameter Scheduler_Version
        /// <summary>
        /// <para>
        /// <para>The version of the specified scheduling software that Amazon Web Services PCS uses
        /// to manage cluster scaling and job scheduling.</para>
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
        public System.String Scheduler_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect. If you don't specify a client token, the
        /// CLI and SDK automatically generate 1 for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PCS.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.PCS.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PCS.Model.CreateClusterResponse, NewPCSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Networking_SecurityGroupId != null)
            {
                context.Networking_SecurityGroupId = new List<System.String>(this.Networking_SecurityGroupId);
            }
            if (this.Networking_SubnetId != null)
            {
                context.Networking_SubnetId = new List<System.String>(this.Networking_SubnetId);
            }
            context.Scheduler_Type = this.Scheduler_Type;
            #if MODULAR
            if (this.Scheduler_Type == null && ParameterWasBound(nameof(this.Scheduler_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Scheduler_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scheduler_Version = this.Scheduler_Version;
            #if MODULAR
            if (this.Scheduler_Version == null && ParameterWasBound(nameof(this.Scheduler_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter Scheduler_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Size = this.Size;
            #if MODULAR
            if (this.Size == null && ParameterWasBound(nameof(this.Size)))
            {
                WriteWarning("You are passing $null as a value for parameter Size which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlurmConfiguration_ScaleDownIdleTimeInSecond = this.SlurmConfiguration_ScaleDownIdleTimeInSecond;
            if (this.SlurmConfiguration_SlurmCustomSetting != null)
            {
                context.SlurmConfiguration_SlurmCustomSetting = new List<Amazon.PCS.Model.SlurmCustomSetting>(this.SlurmConfiguration_SlurmCustomSetting);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.PCS.Model.CreateClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Networking
            var requestNetworkingIsNull = true;
            request.Networking = new Amazon.PCS.Model.NetworkingRequest();
            List<System.String> requestNetworking_networking_SecurityGroupId = null;
            if (cmdletContext.Networking_SecurityGroupId != null)
            {
                requestNetworking_networking_SecurityGroupId = cmdletContext.Networking_SecurityGroupId;
            }
            if (requestNetworking_networking_SecurityGroupId != null)
            {
                request.Networking.SecurityGroupIds = requestNetworking_networking_SecurityGroupId;
                requestNetworkingIsNull = false;
            }
            List<System.String> requestNetworking_networking_SubnetId = null;
            if (cmdletContext.Networking_SubnetId != null)
            {
                requestNetworking_networking_SubnetId = cmdletContext.Networking_SubnetId;
            }
            if (requestNetworking_networking_SubnetId != null)
            {
                request.Networking.SubnetIds = requestNetworking_networking_SubnetId;
                requestNetworkingIsNull = false;
            }
             // determine if request.Networking should be set to null
            if (requestNetworkingIsNull)
            {
                request.Networking = null;
            }
            
             // populate Scheduler
            var requestSchedulerIsNull = true;
            request.Scheduler = new Amazon.PCS.Model.SchedulerRequest();
            Amazon.PCS.SchedulerType requestScheduler_scheduler_Type = null;
            if (cmdletContext.Scheduler_Type != null)
            {
                requestScheduler_scheduler_Type = cmdletContext.Scheduler_Type;
            }
            if (requestScheduler_scheduler_Type != null)
            {
                request.Scheduler.Type = requestScheduler_scheduler_Type;
                requestSchedulerIsNull = false;
            }
            System.String requestScheduler_scheduler_Version = null;
            if (cmdletContext.Scheduler_Version != null)
            {
                requestScheduler_scheduler_Version = cmdletContext.Scheduler_Version;
            }
            if (requestScheduler_scheduler_Version != null)
            {
                request.Scheduler.Version = requestScheduler_scheduler_Version;
                requestSchedulerIsNull = false;
            }
             // determine if request.Scheduler should be set to null
            if (requestSchedulerIsNull)
            {
                request.Scheduler = null;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size;
            }
            
             // populate SlurmConfiguration
            var requestSlurmConfigurationIsNull = true;
            request.SlurmConfiguration = new Amazon.PCS.Model.ClusterSlurmConfigurationRequest();
            System.Int32? requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond = null;
            if (cmdletContext.SlurmConfiguration_ScaleDownIdleTimeInSecond != null)
            {
                requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond = cmdletContext.SlurmConfiguration_ScaleDownIdleTimeInSecond.Value;
            }
            if (requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond != null)
            {
                request.SlurmConfiguration.ScaleDownIdleTimeInSeconds = requestSlurmConfiguration_slurmConfiguration_ScaleDownIdleTimeInSecond.Value;
                requestSlurmConfigurationIsNull = false;
            }
            List<Amazon.PCS.Model.SlurmCustomSetting> requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = null;
            if (cmdletContext.SlurmConfiguration_SlurmCustomSetting != null)
            {
                requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting = cmdletContext.SlurmConfiguration_SlurmCustomSetting;
            }
            if (requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting != null)
            {
                request.SlurmConfiguration.SlurmCustomSettings = requestSlurmConfiguration_slurmConfiguration_SlurmCustomSetting;
                requestSlurmConfigurationIsNull = false;
            }
             // determine if request.SlurmConfiguration should be set to null
            if (requestSlurmConfigurationIsNull)
            {
                request.SlurmConfiguration = null;
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
        
        private Amazon.PCS.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonPCS client, Amazon.PCS.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Parallel Computing Service", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterName { get; set; }
            public List<System.String> Networking_SecurityGroupId { get; set; }
            public List<System.String> Networking_SubnetId { get; set; }
            public Amazon.PCS.SchedulerType Scheduler_Type { get; set; }
            public System.String Scheduler_Version { get; set; }
            public Amazon.PCS.Size Size { get; set; }
            public System.Int32? SlurmConfiguration_ScaleDownIdleTimeInSecond { get; set; }
            public List<Amazon.PCS.Model.SlurmCustomSetting> SlurmConfiguration_SlurmCustomSetting { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PCS.Model.CreateClusterResponse, NewPCSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
