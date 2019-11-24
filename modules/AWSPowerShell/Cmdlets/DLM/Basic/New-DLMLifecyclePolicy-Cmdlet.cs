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
using Amazon.DLM;
using Amazon.DLM.Model;

namespace Amazon.PowerShell.Cmdlets.DLM
{
    /// <summary>
    /// Creates a policy to manage the lifecycle of the specified AWS resources. You can create
    /// up to 100 lifecycle policies.
    /// </summary>
    [Cmdlet("New", "DLMLifecyclePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Data Lifecycle Manager CreateLifecyclePolicy API operation.", Operation = new[] {"CreateLifecyclePolicy"}, SelectReturnType = typeof(Amazon.DLM.Model.CreateLifecyclePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.DLM.Model.CreateLifecyclePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DLM.Model.CreateLifecyclePolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDLMLifecyclePolicyCmdlet : AmazonDLMClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the lifecycle policy. The characters ^[0-9A-Za-z _-]+$ are supported.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Parameters_ExcludeBootVolume
        /// <summary>
        /// <para>
        /// <para>When executing an EBS Snapshot Management – Instance policy, execute all CreateSnapshots
        /// calls with the <code>excludeBootVolume</code> set to the supplied field. Defaults
        /// to false. Only valid for EBS Snapshot Management – Instance policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Parameters_ExcludeBootVolume")]
        public System.Boolean? Parameters_ExcludeBootVolume { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used to run the operations specified
        /// by the lifecycle policy.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_PolicyType
        /// <summary>
        /// <para>
        /// <para>This field determines the valid target resource types and actions a policy can manage.
        /// This field defaults to EBS_SNAPSHOT_MANAGEMENT if not present.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.PolicyTypeValues")]
        public Amazon.DLM.PolicyTypeValues PolicyDetails_PolicyType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_ResourceTypes")]
        public System.String[] PolicyDetails_ResourceType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule of policy-defined actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Schedules")]
        public Amazon.DLM.Model.Schedule[] PolicyDetails_Schedule { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The desired activation state of the lifecycle policy after creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DLM.SettablePolicyStateValues")]
        public Amazon.DLM.SettablePolicyStateValues State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the lifecycle policy during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_TargetTag
        /// <summary>
        /// <para>
        /// <para>The single tag that identifies targeted resources for this policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_TargetTags")]
        public Amazon.DLM.Model.Tag[] PolicyDetails_TargetTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DLM.Model.CreateLifecyclePolicyResponse).
        /// Specifying the name of a property of type Amazon.DLM.Model.CreateLifecyclePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExecutionRoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExecutionRoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExecutionRoleArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExecutionRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DLMLifecyclePolicy (CreateLifecyclePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DLM.Model.CreateLifecyclePolicyResponse, NewDLMLifecyclePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExecutionRoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Parameters_ExcludeBootVolume = this.Parameters_ExcludeBootVolume;
            context.PolicyDetails_PolicyType = this.PolicyDetails_PolicyType;
            if (this.PolicyDetails_ResourceType != null)
            {
                context.PolicyDetails_ResourceType = new List<System.String>(this.PolicyDetails_ResourceType);
            }
            if (this.PolicyDetails_Schedule != null)
            {
                context.PolicyDetails_Schedule = new List<Amazon.DLM.Model.Schedule>(this.PolicyDetails_Schedule);
            }
            if (this.PolicyDetails_TargetTag != null)
            {
                context.PolicyDetails_TargetTag = new List<Amazon.DLM.Model.Tag>(this.PolicyDetails_TargetTag);
            }
            context.State = this.State;
            #if MODULAR
            if (this.State == null && ParameterWasBound(nameof(this.State)))
            {
                WriteWarning("You are passing $null as a value for parameter State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DLM.Model.CreateLifecyclePolicyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate PolicyDetails
            var requestPolicyDetailsIsNull = true;
            request.PolicyDetails = new Amazon.DLM.Model.PolicyDetails();
            Amazon.DLM.PolicyTypeValues requestPolicyDetails_policyDetails_PolicyType = null;
            if (cmdletContext.PolicyDetails_PolicyType != null)
            {
                requestPolicyDetails_policyDetails_PolicyType = cmdletContext.PolicyDetails_PolicyType;
            }
            if (requestPolicyDetails_policyDetails_PolicyType != null)
            {
                request.PolicyDetails.PolicyType = requestPolicyDetails_policyDetails_PolicyType;
                requestPolicyDetailsIsNull = false;
            }
            List<System.String> requestPolicyDetails_policyDetails_ResourceType = null;
            if (cmdletContext.PolicyDetails_ResourceType != null)
            {
                requestPolicyDetails_policyDetails_ResourceType = cmdletContext.PolicyDetails_ResourceType;
            }
            if (requestPolicyDetails_policyDetails_ResourceType != null)
            {
                request.PolicyDetails.ResourceTypes = requestPolicyDetails_policyDetails_ResourceType;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Schedule> requestPolicyDetails_policyDetails_Schedule = null;
            if (cmdletContext.PolicyDetails_Schedule != null)
            {
                requestPolicyDetails_policyDetails_Schedule = cmdletContext.PolicyDetails_Schedule;
            }
            if (requestPolicyDetails_policyDetails_Schedule != null)
            {
                request.PolicyDetails.Schedules = requestPolicyDetails_policyDetails_Schedule;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestPolicyDetails_policyDetails_TargetTag = null;
            if (cmdletContext.PolicyDetails_TargetTag != null)
            {
                requestPolicyDetails_policyDetails_TargetTag = cmdletContext.PolicyDetails_TargetTag;
            }
            if (requestPolicyDetails_policyDetails_TargetTag != null)
            {
                request.PolicyDetails.TargetTags = requestPolicyDetails_policyDetails_TargetTag;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.Model.Parameters requestPolicyDetails_policyDetails_Parameters = null;
            
             // populate Parameters
            var requestPolicyDetails_policyDetails_ParametersIsNull = true;
            requestPolicyDetails_policyDetails_Parameters = new Amazon.DLM.Model.Parameters();
            System.Boolean? requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume = null;
            if (cmdletContext.Parameters_ExcludeBootVolume != null)
            {
                requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume = cmdletContext.Parameters_ExcludeBootVolume.Value;
            }
            if (requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume != null)
            {
                requestPolicyDetails_policyDetails_Parameters.ExcludeBootVolume = requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume.Value;
                requestPolicyDetails_policyDetails_ParametersIsNull = false;
            }
             // determine if requestPolicyDetails_policyDetails_Parameters should be set to null
            if (requestPolicyDetails_policyDetails_ParametersIsNull)
            {
                requestPolicyDetails_policyDetails_Parameters = null;
            }
            if (requestPolicyDetails_policyDetails_Parameters != null)
            {
                request.PolicyDetails.Parameters = requestPolicyDetails_policyDetails_Parameters;
                requestPolicyDetailsIsNull = false;
            }
             // determine if request.PolicyDetails should be set to null
            if (requestPolicyDetailsIsNull)
            {
                request.PolicyDetails = null;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.DLM.Model.CreateLifecyclePolicyResponse CallAWSServiceOperation(IAmazonDLM client, Amazon.DLM.Model.CreateLifecyclePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Data Lifecycle Manager", "CreateLifecyclePolicy");
            try
            {
                #if DESKTOP
                return client.CreateLifecyclePolicy(request);
                #elif CORECLR
                return client.CreateLifecyclePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? Parameters_ExcludeBootVolume { get; set; }
            public Amazon.DLM.PolicyTypeValues PolicyDetails_PolicyType { get; set; }
            public List<System.String> PolicyDetails_ResourceType { get; set; }
            public List<Amazon.DLM.Model.Schedule> PolicyDetails_Schedule { get; set; }
            public List<Amazon.DLM.Model.Tag> PolicyDetails_TargetTag { get; set; }
            public Amazon.DLM.SettablePolicyStateValues State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.DLM.Model.CreateLifecyclePolicyResponse, NewDLMLifecyclePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyId;
        }
        
    }
}
