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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Creates a new scaling group.
    /// </summary>
    [Cmdlet("New", "FINSPKxScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.CreateKxScalingGroupResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service CreateKxScalingGroup API operation.", Operation = new[] {"CreateKxScalingGroup"}, SelectReturnType = typeof(Amazon.Finspace.Model.CreateKxScalingGroupResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.CreateKxScalingGroupResponse",
        "This cmdlet returns an Amazon.Finspace.Model.CreateKxScalingGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFINSPKxScalingGroupCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The identifier of the availability zones.</para>
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
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment, where you want to create the scaling
        /// group. </para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter HostType
        /// <summary>
        /// <para>
        /// <para> The memory and CPU capabilities of the scaling group host on which FinSpace Managed
        /// kdb clusters will be placed.</para><para>You can add one of the following values:</para><ul><li><para><c>kx.sg.4xlarge</c> – The host type with a configuration of 108 GiB memory and 16
        /// vCPUs.</para></li><li><para><c>kx.sg.8xlarge</c> – The host type with a configuration of 216 GiB memory and 32
        /// vCPUs.</para></li><li><para><c>kx.sg.16xlarge</c> – The host type with a configuration of 432 GiB memory and
        /// 64 vCPUs.</para></li><li><para><c>kx.sg.32xlarge</c> – The host type with a configuration of 864 GiB memory and
        /// 128 vCPUs.</para></li><li><para><c>kx.sg1.16xlarge</c> – The host type with a configuration of 1949 GiB memory and
        /// 64 vCPUs.</para></li><li><para><c>kx.sg1.24xlarge</c> – The host type with a configuration of 2948 GiB memory and
        /// 96 vCPUs.</para></li></ul>
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
        public System.String HostType { get; set; }
        #endregion
        
        #region Parameter ScalingGroupName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb scaling group. </para>
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
        public System.String ScalingGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A list of key-value pairs to label the scaling group. You can add up to 50 tags to
        /// a scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.CreateKxScalingGroupResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.CreateKxScalingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FINSPKxScalingGroup (CreateKxScalingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.CreateKxScalingGroupResponse, NewFINSPKxScalingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            #if MODULAR
            if (this.AvailabilityZoneId == null && ParameterWasBound(nameof(this.AvailabilityZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostType = this.HostType;
            #if MODULAR
            if (this.HostType == null && ParameterWasBound(nameof(this.HostType)))
            {
                WriteWarning("You are passing $null as a value for parameter HostType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingGroupName = this.ScalingGroupName;
            #if MODULAR
            if (this.ScalingGroupName == null && ParameterWasBound(nameof(this.ScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Finspace.Model.CreateKxScalingGroupRequest();
            
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.HostType != null)
            {
                request.HostType = cmdletContext.HostType;
            }
            if (cmdletContext.ScalingGroupName != null)
            {
                request.ScalingGroupName = cmdletContext.ScalingGroupName;
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
        
        private Amazon.Finspace.Model.CreateKxScalingGroupResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.CreateKxScalingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "CreateKxScalingGroup");
            try
            {
                #if DESKTOP
                return client.CreateKxScalingGroup(request);
                #elif CORECLR
                return client.CreateKxScalingGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String HostType { get; set; }
            public System.String ScalingGroupName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Finspace.Model.CreateKxScalingGroupResponse, NewFINSPKxScalingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
