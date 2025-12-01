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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a capacity provider that manages compute resources for Lambda functions
    /// </summary>
    [Cmdlet("New", "LMCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CapacityProvider")]
    [AWSCmdlet("Calls the AWS Lambda CreateCapacityProvider API operation.", Operation = new[] {"CreateCapacityProvider"}, SelectReturnType = typeof(Amazon.Lambda.Model.CreateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CapacityProvider or Amazon.Lambda.Model.CreateCapacityProviderResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CapacityProvider object.",
        "The service call response (type Amazon.Lambda.Model.CreateCapacityProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLMCapacityProviderCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of EC2 instance types that the capacity provider is allowed to use. If not
        /// specified, all compatible instance types are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_Architecture
        /// <summary>
        /// <para>
        /// <para>A list of supported CPU architectures for compute instances. Valid values include
        /// <c>x86_64</c> and <c>arm64</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_Architectures")]
        public System.String[] InstanceRequirements_Architecture { get; set; }
        #endregion
        
        #region Parameter CapacityProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the capacity provider. </para>
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
        public System.String CapacityProviderName { get; set; }
        #endregion
        
        #region Parameter PermissionsConfig_CapacityProviderOperatorRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the capacity provider uses to manage compute instances
        /// and other Amazon Web Services resources.</para>
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
        public System.String PermissionsConfig_CapacityProviderOperatorRoleArn { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of EC2 instance types that the capacity provider should not use, even if they
        /// meet other requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_ExcludedInstanceTypes")]
        public System.String[] InstanceRequirements_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt data associated with the capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_MaxVCpuCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs that the capacity provider can provision across all compute
        /// instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityProviderScalingConfig_MaxVCpuCount { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_ScalingMode
        /// <summary>
        /// <para>
        /// <para>The scaling mode that determines how the capacity provider responds to changes in
        /// demand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.CapacityProviderScalingMode")]
        public Amazon.Lambda.CapacityProviderScalingMode CapacityProviderScalingConfig_ScalingMode { get; set; }
        #endregion
        
        #region Parameter CapacityProviderScalingConfig_ScalingPolicy
        /// <summary>
        /// <para>
        /// <para>A list of scaling policies that define how the capacity provider scales compute instances
        /// based on metrics and thresholds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityProviderScalingConfig_ScalingPolicies")]
        public Amazon.Lambda.Model.TargetTrackingScalingPolicy[] CapacityProviderScalingConfig_ScalingPolicy { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group IDs that control network access for compute instances managed
        /// by the capacity provider.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs where the capacity provider launches compute instances.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CreateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CreateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CapacityProviderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CapacityProviderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CapacityProviderName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMCapacityProvider (CreateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CreateCapacityProviderResponse, NewLMCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CapacityProviderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CapacityProviderName = this.CapacityProviderName;
            #if MODULAR
            if (this.CapacityProviderName == null && ParameterWasBound(nameof(this.CapacityProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityProviderScalingConfig_MaxVCpuCount = this.CapacityProviderScalingConfig_MaxVCpuCount;
            context.CapacityProviderScalingConfig_ScalingMode = this.CapacityProviderScalingConfig_ScalingMode;
            if (this.CapacityProviderScalingConfig_ScalingPolicy != null)
            {
                context.CapacityProviderScalingConfig_ScalingPolicy = new List<Amazon.Lambda.Model.TargetTrackingScalingPolicy>(this.CapacityProviderScalingConfig_ScalingPolicy);
            }
            if (this.InstanceRequirements_AllowedInstanceType != null)
            {
                context.InstanceRequirements_AllowedInstanceType = new List<System.String>(this.InstanceRequirements_AllowedInstanceType);
            }
            if (this.InstanceRequirements_Architecture != null)
            {
                context.InstanceRequirements_Architecture = new List<System.String>(this.InstanceRequirements_Architecture);
            }
            if (this.InstanceRequirements_ExcludedInstanceType != null)
            {
                context.InstanceRequirements_ExcludedInstanceType = new List<System.String>(this.InstanceRequirements_ExcludedInstanceType);
            }
            context.KmsKeyArn = this.KmsKeyArn;
            context.PermissionsConfig_CapacityProviderOperatorRoleArn = this.PermissionsConfig_CapacityProviderOperatorRoleArn;
            #if MODULAR
            if (this.PermissionsConfig_CapacityProviderOperatorRoleArn == null && ParameterWasBound(nameof(this.PermissionsConfig_CapacityProviderOperatorRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionsConfig_CapacityProviderOperatorRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            #if MODULAR
            if (this.VpcConfig_SecurityGroupId == null && ParameterWasBound(nameof(this.VpcConfig_SecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcConfig_SecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
            }
            #if MODULAR
            if (this.VpcConfig_SubnetId == null && ParameterWasBound(nameof(this.VpcConfig_SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcConfig_SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.CreateCapacityProviderRequest();
            
            if (cmdletContext.CapacityProviderName != null)
            {
                request.CapacityProviderName = cmdletContext.CapacityProviderName;
            }
            
             // populate CapacityProviderScalingConfig
            var requestCapacityProviderScalingConfigIsNull = true;
            request.CapacityProviderScalingConfig = new Amazon.Lambda.Model.CapacityProviderScalingConfig();
            System.Int32? requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount = null;
            if (cmdletContext.CapacityProviderScalingConfig_MaxVCpuCount != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount = cmdletContext.CapacityProviderScalingConfig_MaxVCpuCount.Value;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount != null)
            {
                request.CapacityProviderScalingConfig.MaxVCpuCount = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_MaxVCpuCount.Value;
                requestCapacityProviderScalingConfigIsNull = false;
            }
            Amazon.Lambda.CapacityProviderScalingMode requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode = null;
            if (cmdletContext.CapacityProviderScalingConfig_ScalingMode != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode = cmdletContext.CapacityProviderScalingConfig_ScalingMode;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode != null)
            {
                request.CapacityProviderScalingConfig.ScalingMode = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingMode;
                requestCapacityProviderScalingConfigIsNull = false;
            }
            List<Amazon.Lambda.Model.TargetTrackingScalingPolicy> requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy = null;
            if (cmdletContext.CapacityProviderScalingConfig_ScalingPolicy != null)
            {
                requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy = cmdletContext.CapacityProviderScalingConfig_ScalingPolicy;
            }
            if (requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy != null)
            {
                request.CapacityProviderScalingConfig.ScalingPolicies = requestCapacityProviderScalingConfig_capacityProviderScalingConfig_ScalingPolicy;
                requestCapacityProviderScalingConfigIsNull = false;
            }
             // determine if request.CapacityProviderScalingConfig should be set to null
            if (requestCapacityProviderScalingConfigIsNull)
            {
                request.CapacityProviderScalingConfig = null;
            }
            
             // populate InstanceRequirements
            var requestInstanceRequirementsIsNull = true;
            request.InstanceRequirements = new Amazon.Lambda.Model.InstanceRequirements();
            List<System.String> requestInstanceRequirements_instanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.InstanceRequirements_AllowedInstanceType != null)
            {
                requestInstanceRequirements_instanceRequirements_AllowedInstanceType = cmdletContext.InstanceRequirements_AllowedInstanceType;
            }
            if (requestInstanceRequirements_instanceRequirements_AllowedInstanceType != null)
            {
                request.InstanceRequirements.AllowedInstanceTypes = requestInstanceRequirements_instanceRequirements_AllowedInstanceType;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_Architecture = null;
            if (cmdletContext.InstanceRequirements_Architecture != null)
            {
                requestInstanceRequirements_instanceRequirements_Architecture = cmdletContext.InstanceRequirements_Architecture;
            }
            if (requestInstanceRequirements_instanceRequirements_Architecture != null)
            {
                request.InstanceRequirements.Architectures = requestInstanceRequirements_instanceRequirements_Architecture;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_ExcludedInstanceType = null;
            if (cmdletContext.InstanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirements_instanceRequirements_ExcludedInstanceType = cmdletContext.InstanceRequirements_ExcludedInstanceType;
            }
            if (requestInstanceRequirements_instanceRequirements_ExcludedInstanceType != null)
            {
                request.InstanceRequirements.ExcludedInstanceTypes = requestInstanceRequirements_instanceRequirements_ExcludedInstanceType;
                requestInstanceRequirementsIsNull = false;
            }
             // determine if request.InstanceRequirements should be set to null
            if (requestInstanceRequirementsIsNull)
            {
                request.InstanceRequirements = null;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            
             // populate PermissionsConfig
            var requestPermissionsConfigIsNull = true;
            request.PermissionsConfig = new Amazon.Lambda.Model.CapacityProviderPermissionsConfig();
            System.String requestPermissionsConfig_permissionsConfig_CapacityProviderOperatorRoleArn = null;
            if (cmdletContext.PermissionsConfig_CapacityProviderOperatorRoleArn != null)
            {
                requestPermissionsConfig_permissionsConfig_CapacityProviderOperatorRoleArn = cmdletContext.PermissionsConfig_CapacityProviderOperatorRoleArn;
            }
            if (requestPermissionsConfig_permissionsConfig_CapacityProviderOperatorRoleArn != null)
            {
                request.PermissionsConfig.CapacityProviderOperatorRoleArn = requestPermissionsConfig_permissionsConfig_CapacityProviderOperatorRoleArn;
                requestPermissionsConfigIsNull = false;
            }
             // determine if request.PermissionsConfig should be set to null
            if (requestPermissionsConfigIsNull)
            {
                request.PermissionsConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Lambda.Model.CapacityProviderVpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.Lambda.Model.CreateCapacityProviderResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateCapacityProvider");
            try
            {
                #if DESKTOP
                return client.CreateCapacityProvider(request);
                #elif CORECLR
                return client.CreateCapacityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityProviderName { get; set; }
            public System.Int32? CapacityProviderScalingConfig_MaxVCpuCount { get; set; }
            public Amazon.Lambda.CapacityProviderScalingMode CapacityProviderScalingConfig_ScalingMode { get; set; }
            public List<Amazon.Lambda.Model.TargetTrackingScalingPolicy> CapacityProviderScalingConfig_ScalingPolicy { get; set; }
            public List<System.String> InstanceRequirements_AllowedInstanceType { get; set; }
            public List<System.String> InstanceRequirements_Architecture { get; set; }
            public List<System.String> InstanceRequirements_ExcludedInstanceType { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String PermissionsConfig_CapacityProviderOperatorRoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Lambda.Model.CreateCapacityProviderResponse, NewLMCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
