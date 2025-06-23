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
using Amazon.Evs;
using Amazon.Evs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVS
{
    /// <summary>
    /// Creates an ESXi host and adds it to an Amazon EVS environment. Amazon EVS supports
    /// 4-16 hosts per environment.
    /// 
    ///  
    /// <para>
    /// This action can only be used after the Amazon EVS environment is deployed. All Amazon
    /// EVS hosts are created with the latest AMI release version for the respective VCF version
    /// of the environment.
    /// </para><para>
    /// You can use the <c>dedicatedHostId</c> parameter to specify an Amazon EC2 Dedicated
    /// Host for ESXi host creation.
    /// </para><para>
    ///  You can use the <c>placementGroupId</c> parameter to specify a cluster or partition
    /// placement group to launch EC2 instances into.
    /// </para><note><para>
    /// You cannot use the <c>dedicatedHostId</c> and <c>placementGroupId</c> parameters together
    /// in the same <c>CreateEnvironmentHost</c> action. This results in a <c>ValidationException</c>
    /// response.
    /// </para></note><note><para>
    /// EC2 instances created through Amazon EVS do not support associating an IAM instance
    /// profile.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EVSEnvironmentHost", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Evs.Model.CreateEnvironmentHostResponse")]
    [AWSCmdlet("Calls the Amazon Elastic VMware Service CreateEnvironmentHost API operation.", Operation = new[] {"CreateEnvironmentHost"}, SelectReturnType = typeof(Amazon.Evs.Model.CreateEnvironmentHostResponse))]
    [AWSCmdletOutput("Amazon.Evs.Model.CreateEnvironmentHostResponse",
        "This cmdlet returns an Amazon.Evs.Model.CreateEnvironmentHostResponse object containing multiple properties."
    )]
    public partial class NewEVSEnvironmentHostCmdlet : AmazonEvsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Host_DedicatedHostId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the Amazon EC2 Dedicated Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Host_DedicatedHostId { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the environment that the host is added to.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter Host_HostName
        /// <summary>
        /// <para>
        /// <para>The DNS hostname of the host. DNS hostnames for hosts must be unique across Amazon
        /// EVS environments and within VCF.</para>
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
        public System.String Host_HostName { get; set; }
        #endregion
        
        #region Parameter Host_InstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type that represents the host.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Evs.InstanceType")]
        public Amazon.Evs.InstanceType Host_InstanceType { get; set; }
        #endregion
        
        #region Parameter Host_KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the SSH key that is used to access the host.</para>
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
        public System.String Host_KeyName { get; set; }
        #endregion
        
        #region Parameter Host_PlacementGroupId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the placement group where the host is placed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Host_PlacementGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para><note><para>This parameter is not used in Amazon EVS currently. If you supply input for this parameter,
        /// it will have no effect.</para></note><para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the host creation request. If you do not specify a client token, a randomly generated
        /// token is used for the request to ensure idempotency.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Evs.Model.CreateEnvironmentHostResponse).
        /// Specifying the name of a property of type Amazon.Evs.Model.CreateEnvironmentHostResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVSEnvironmentHost (CreateEnvironmentHost)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Evs.Model.CreateEnvironmentHostResponse, NewEVSEnvironmentHostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Host_DedicatedHostId = this.Host_DedicatedHostId;
            context.Host_HostName = this.Host_HostName;
            #if MODULAR
            if (this.Host_HostName == null && ParameterWasBound(nameof(this.Host_HostName)))
            {
                WriteWarning("You are passing $null as a value for parameter Host_HostName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Host_InstanceType = this.Host_InstanceType;
            #if MODULAR
            if (this.Host_InstanceType == null && ParameterWasBound(nameof(this.Host_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter Host_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Host_KeyName = this.Host_KeyName;
            #if MODULAR
            if (this.Host_KeyName == null && ParameterWasBound(nameof(this.Host_KeyName)))
            {
                WriteWarning("You are passing $null as a value for parameter Host_KeyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Host_PlacementGroupId = this.Host_PlacementGroupId;
            
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
            var request = new Amazon.Evs.Model.CreateEnvironmentHostRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            
             // populate Host
            var requestHostIsNull = true;
            request.Host = new Amazon.Evs.Model.HostInfoForCreate();
            System.String requestHost_host_DedicatedHostId = null;
            if (cmdletContext.Host_DedicatedHostId != null)
            {
                requestHost_host_DedicatedHostId = cmdletContext.Host_DedicatedHostId;
            }
            if (requestHost_host_DedicatedHostId != null)
            {
                request.Host.DedicatedHostId = requestHost_host_DedicatedHostId;
                requestHostIsNull = false;
            }
            System.String requestHost_host_HostName = null;
            if (cmdletContext.Host_HostName != null)
            {
                requestHost_host_HostName = cmdletContext.Host_HostName;
            }
            if (requestHost_host_HostName != null)
            {
                request.Host.HostName = requestHost_host_HostName;
                requestHostIsNull = false;
            }
            Amazon.Evs.InstanceType requestHost_host_InstanceType = null;
            if (cmdletContext.Host_InstanceType != null)
            {
                requestHost_host_InstanceType = cmdletContext.Host_InstanceType;
            }
            if (requestHost_host_InstanceType != null)
            {
                request.Host.InstanceType = requestHost_host_InstanceType;
                requestHostIsNull = false;
            }
            System.String requestHost_host_KeyName = null;
            if (cmdletContext.Host_KeyName != null)
            {
                requestHost_host_KeyName = cmdletContext.Host_KeyName;
            }
            if (requestHost_host_KeyName != null)
            {
                request.Host.KeyName = requestHost_host_KeyName;
                requestHostIsNull = false;
            }
            System.String requestHost_host_PlacementGroupId = null;
            if (cmdletContext.Host_PlacementGroupId != null)
            {
                requestHost_host_PlacementGroupId = cmdletContext.Host_PlacementGroupId;
            }
            if (requestHost_host_PlacementGroupId != null)
            {
                request.Host.PlacementGroupId = requestHost_host_PlacementGroupId;
                requestHostIsNull = false;
            }
             // determine if request.Host should be set to null
            if (requestHostIsNull)
            {
                request.Host = null;
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
        
        private Amazon.Evs.Model.CreateEnvironmentHostResponse CallAWSServiceOperation(IAmazonEvs client, Amazon.Evs.Model.CreateEnvironmentHostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic VMware Service", "CreateEnvironmentHost");
            try
            {
                return client.CreateEnvironmentHostAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EnvironmentId { get; set; }
            public System.String Host_DedicatedHostId { get; set; }
            public System.String Host_HostName { get; set; }
            public Amazon.Evs.InstanceType Host_InstanceType { get; set; }
            public System.String Host_KeyName { get; set; }
            public System.String Host_PlacementGroupId { get; set; }
            public System.Func<Amazon.Evs.Model.CreateEnvironmentHostResponse, NewEVSEnvironmentHostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
