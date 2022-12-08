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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Creates a new recommendation preference or updates an existing recommendation preference,
    /// such as enhanced infrastructure metrics.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/enhanced-infrastructure-metrics.html">Activating
    /// enhanced infrastructure metrics</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CORecommendationPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Compute Optimizer PutRecommendationPreferences API operation.", Operation = new[] {"PutRecommendationPreferences"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse))]
    [AWSCmdletOutput("None or Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCORecommendationPreferenceCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        #region Parameter EnhancedInfrastructureMetric
        /// <summary>
        /// <para>
        /// <para>The status of the enhanced infrastructure metrics recommendation preference to create
        /// or update.</para><para>Specify the <code>Active</code> status to activate the preference, or specify <code>Inactive</code>
        /// to deactivate the preference.</para><para>For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/enhanced-infrastructure-metrics.html">Enhanced
        /// infrastructure metrics</a> in the <i>Compute Optimizer User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnhancedInfrastructureMetrics")]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.EnhancedInfrastructureMetrics")]
        public Amazon.ComputeOptimizer.EnhancedInfrastructureMetrics EnhancedInfrastructureMetric { get; set; }
        #endregion
        
        #region Parameter InferredWorkloadType
        /// <summary>
        /// <para>
        /// <para>The status of the inferred workload types recommendation preference to create or update.</para><note><para>The inferred workload type feature is active by default. To deactivate it, create
        /// a recommendation preference.</para></note><para>Specify the <code>Inactive</code> status to deactivate the feature, or specify <code>Active</code>
        /// to activate it.</para><para>For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/inferred-workload-types.html">Inferred
        /// workload types</a> in the <i>Compute Optimizer User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferredWorkloadTypes")]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.InferredWorkloadTypesPreference")]
        public Amazon.ComputeOptimizer.InferredWorkloadTypesPreference InferredWorkloadType { get; set; }
        #endregion
        
        #region Parameter Scope_Name
        /// <summary>
        /// <para>
        /// <para>The name of the scope.</para><para>The following scopes are possible:</para><ul><li><para><code>Organization</code> - Specifies that the recommendation preference applies
        /// at the organization level, for all member accounts of an organization.</para></li><li><para><code>AccountId</code> - Specifies that the recommendation preference applies at
        /// the account level, for all resources of a given resource type in an account.</para></li><li><para><code>ResourceArn</code> - Specifies that the recommendation preference applies at
        /// the individual resource level.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ScopeName")]
        public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The target resource type of the recommendation preference to create.</para><para>The <code>Ec2Instance</code> option encompasses standalone instances and instances
        /// that are part of Auto Scaling groups. The <code>AutoScalingGroup</code> option encompasses
        /// only instances that are part of an Auto Scaling group.</para><note><para>The valid values for this parameter are <code>Ec2Instance</code> and <code>AutoScalingGroup</code>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ResourceType")]
        public Amazon.ComputeOptimizer.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter ExternalMetricsPreference_Source
        /// <summary>
        /// <para>
        /// <para> Contains the source options for external metrics preferences. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ExternalMetricsSource")]
        public Amazon.ComputeOptimizer.ExternalMetricsSource ExternalMetricsPreference_Source { get; set; }
        #endregion
        
        #region Parameter Scope_Value
        /// <summary>
        /// <para>
        /// <para>The value of the scope.</para><para>If you specified the <code>name</code> of the scope as:</para><ul><li><para><code>Organization</code> - The <code>value</code> must be <code>ALL_ACCOUNTS</code>.</para></li><li><para><code>AccountId</code> - The <code>value</code> must be a 12-digit Amazon Web Services
        /// account ID.</para></li><li><para><code>ResourceArn</code> - The <code>value</code> must be the Amazon Resource Name
        /// (ARN) of an EC2 instance or an Auto Scaling group.</para></li></ul><para>Only EC2 instance and Auto Scaling group ARNs are currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Scope_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CORecommendationPreference (PutRecommendationPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse, WriteCORecommendationPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EnhancedInfrastructureMetric = this.EnhancedInfrastructureMetric;
            context.ExternalMetricsPreference_Source = this.ExternalMetricsPreference_Source;
            context.InferredWorkloadType = this.InferredWorkloadType;
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope_Name = this.Scope_Name;
            context.Scope_Value = this.Scope_Value;
            
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
            var request = new Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesRequest();
            
            if (cmdletContext.EnhancedInfrastructureMetric != null)
            {
                request.EnhancedInfrastructureMetrics = cmdletContext.EnhancedInfrastructureMetric;
            }
            
             // populate ExternalMetricsPreference
            var requestExternalMetricsPreferenceIsNull = true;
            request.ExternalMetricsPreference = new Amazon.ComputeOptimizer.Model.ExternalMetricsPreference();
            Amazon.ComputeOptimizer.ExternalMetricsSource requestExternalMetricsPreference_externalMetricsPreference_Source = null;
            if (cmdletContext.ExternalMetricsPreference_Source != null)
            {
                requestExternalMetricsPreference_externalMetricsPreference_Source = cmdletContext.ExternalMetricsPreference_Source;
            }
            if (requestExternalMetricsPreference_externalMetricsPreference_Source != null)
            {
                request.ExternalMetricsPreference.Source = requestExternalMetricsPreference_externalMetricsPreference_Source;
                requestExternalMetricsPreferenceIsNull = false;
            }
             // determine if request.ExternalMetricsPreference should be set to null
            if (requestExternalMetricsPreferenceIsNull)
            {
                request.ExternalMetricsPreference = null;
            }
            if (cmdletContext.InferredWorkloadType != null)
            {
                request.InferredWorkloadTypes = cmdletContext.InferredWorkloadType;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.ComputeOptimizer.Model.Scope();
            Amazon.ComputeOptimizer.ScopeName requestScope_scope_Name = null;
            if (cmdletContext.Scope_Name != null)
            {
                requestScope_scope_Name = cmdletContext.Scope_Name;
            }
            if (requestScope_scope_Name != null)
            {
                request.Scope.Name = requestScope_scope_Name;
                requestScopeIsNull = false;
            }
            System.String requestScope_scope_Value = null;
            if (cmdletContext.Scope_Value != null)
            {
                requestScope_scope_Value = cmdletContext.Scope_Value;
            }
            if (requestScope_scope_Value != null)
            {
                request.Scope.Value = requestScope_scope_Value;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
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
        
        private Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "PutRecommendationPreferences");
            try
            {
                #if DESKTOP
                return client.PutRecommendationPreferences(request);
                #elif CORECLR
                return client.PutRecommendationPreferencesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ComputeOptimizer.EnhancedInfrastructureMetrics EnhancedInfrastructureMetric { get; set; }
            public Amazon.ComputeOptimizer.ExternalMetricsSource ExternalMetricsPreference_Source { get; set; }
            public Amazon.ComputeOptimizer.InferredWorkloadTypesPreference InferredWorkloadType { get; set; }
            public Amazon.ComputeOptimizer.ResourceType ResourceType { get; set; }
            public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
            public System.String Scope_Value { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.PutRecommendationPreferencesResponse, WriteCORecommendationPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
