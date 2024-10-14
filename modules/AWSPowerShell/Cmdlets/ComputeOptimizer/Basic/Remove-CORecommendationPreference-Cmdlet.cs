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
    /// Deletes a recommendation preference, such as enhanced infrastructure metrics.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/enhanced-infrastructure-metrics.html">Activating
    /// enhanced infrastructure metrics</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CORecommendationPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Compute Optimizer DeleteRecommendationPreferences API operation.", Operation = new[] {"DeleteRecommendationPreferences"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse))]
    [AWSCmdletOutput("None or Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCORecommendationPreferenceCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Scope_Name
        /// <summary>
        /// <para>
        /// <para>The name of the scope.</para><para>The following scopes are possible:</para><ul><li><para><c>Organization</c> - Specifies that the recommendation preference applies at the
        /// organization level, for all member accounts of an organization.</para></li><li><para><c>AccountId</c> - Specifies that the recommendation preference applies at the account
        /// level, for all resources of a given resource type in an account.</para></li><li><para><c>ResourceArn</c> - Specifies that the recommendation preference applies at the
        /// individual resource level.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ScopeName")]
        public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
        #endregion
        
        #region Parameter RecommendationPreferenceName
        /// <summary>
        /// <para>
        /// <para>The name of the recommendation preference to delete.</para>
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
        [Alias("RecommendationPreferenceNames")]
        public System.String[] RecommendationPreferenceName { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The target resource type of the recommendation preference to delete.</para><para>The <c>Ec2Instance</c> option encompasses standalone instances and instances that
        /// are part of Auto Scaling groups. The <c>AutoScalingGroup</c> option encompasses only
        /// instances that are part of an Auto Scaling group.</para>
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
        
        #region Parameter Scope_Value
        /// <summary>
        /// <para>
        /// <para>The value of the scope.</para><para>If you specified the <c>name</c> of the scope as:</para><ul><li><para><c>Organization</c> - The <c>value</c> must be <c>ALL_ACCOUNTS</c>.</para></li><li><para><c>AccountId</c> - The <c>value</c> must be a 12-digit Amazon Web Services account
        /// ID.</para></li><li><para><c>ResourceArn</c> - The <c>value</c> must be the Amazon Resource Name (ARN) of an
        /// EC2 instance or an Auto Scaling group.</para></li></ul><para>Only EC2 instance and Auto Scaling group ARNs are currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CORecommendationPreference (DeleteRecommendationPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse, RemoveCORecommendationPreferenceCmdlet>(Select) ??
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
            if (this.RecommendationPreferenceName != null)
            {
                context.RecommendationPreferenceName = new List<System.String>(this.RecommendationPreferenceName);
            }
            #if MODULAR
            if (this.RecommendationPreferenceName == null && ParameterWasBound(nameof(this.RecommendationPreferenceName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationPreferenceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesRequest();
            
            if (cmdletContext.RecommendationPreferenceName != null)
            {
                request.RecommendationPreferenceNames = cmdletContext.RecommendationPreferenceName;
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
        
        private Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "DeleteRecommendationPreferences");
            try
            {
                #if DESKTOP
                return client.DeleteRecommendationPreferences(request);
                #elif CORECLR
                return client.DeleteRecommendationPreferencesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> RecommendationPreferenceName { get; set; }
            public Amazon.ComputeOptimizer.ResourceType ResourceType { get; set; }
            public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
            public System.String Scope_Value { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.DeleteRecommendationPreferencesResponse, RemoveCORecommendationPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
