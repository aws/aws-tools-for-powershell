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
using Amazon.PricingPlanManager;
using Amazon.PricingPlanManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PPM
{
    /// <summary>
    /// Creates a flat-rate pricing subscription for the specified resources.
    /// 
    ///  <note><para>
    /// When <c>approvalMode</c> is set to <c>MANUAL</c>, paid-tier subscriptions are created
    /// in <c>PENDING_APPROVAL</c> status and require a separate <c>ApprovePaidSubscription</c>
    /// call before billing starts. Free-tier subscriptions are always activated immediately
    /// regardless of approval mode.
    /// </para><para>
    /// When <c>approvalMode</c> is set to <c>IMMEDIATE</c> or is not specified, the subscription
    /// is activated immediately.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PPMSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PricingPlanManager.Model.Subscription")]
    [AWSCmdlet("Calls the PricingPlanManager CreateSubscription API operation.", Operation = new[] {"CreateSubscription"}, SelectReturnType = typeof(Amazon.PricingPlanManager.Model.CreateSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.PricingPlanManager.Model.Subscription or Amazon.PricingPlanManager.Model.CreateSubscriptionResponse",
        "This cmdlet returns an Amazon.PricingPlanManager.Model.Subscription object.",
        "The service call response (type Amazon.PricingPlanManager.Model.CreateSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPPMSubscriptionCmdlet : AmazonPricingPlanManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApprovalMode
        /// <summary>
        /// <para>
        /// <para>Determines whether the subscription requires explicit approval before billing starts.
        /// Set to <c>MANUAL</c> to require a separate <c>ApprovePaidSubscription</c> call, or
        /// <c>IMMEDIATE</c> to activate the subscription right away. Defaults to <c>IMMEDIATE</c>
        /// if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PricingPlanManager.ApprovalMode")]
        public Amazon.PricingPlanManager.ApprovalMode ApprovalMode { get; set; }
        #endregion
        
        #region Parameter PlanFamily
        /// <summary>
        /// <para>
        /// <para>The pricing plan family to subscribe to, such as <c>CloudFront</c>.</para>
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
        public System.String PlanFamily { get; set; }
        #endregion
        
        #region Parameter PlanTier
        /// <summary>
        /// <para>
        /// <para>The tier level for the subscription, such as <c>FREE</c>, <c>PRO</c>, <c>BUSINESS</c>,
        /// or <c>PREMIUM</c>.</para>
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
        public System.String PlanTier { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the AWS resources to include in the subscription. Specify one or more
        /// supported resources.</para><note><para>For subscriptions in the CloudFront plan family, the resources must include exactly
        /// one Amazon CloudFront distribution and exactly one AWS WAF web ACL. You can also include
        /// other supported resources, such as Amazon Route 53 hosted zones and CloudFront KeyValueStores.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter UsageLevel
        /// <summary>
        /// <para>
        /// <para>The usage level within the plan tier. Specify <c>DEFAULT</c> for the base configuration,
        /// or a higher level if your plan tier supports it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UsageLevel { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the request is
        /// handled only once. If you send the same request with the same client token, the API
        /// returns the original response without creating a duplicate subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PricingPlanManager.Model.CreateSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.PricingPlanManager.Model.CreateSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subscription";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PPMSubscription (CreateSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PricingPlanManager.Model.CreateSubscriptionResponse, NewPPMSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalMode = this.ApprovalMode;
            context.ClientToken = this.ClientToken;
            context.PlanFamily = this.PlanFamily;
            #if MODULAR
            if (this.PlanFamily == null && ParameterWasBound(nameof(this.PlanFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlanTier = this.PlanTier;
            #if MODULAR
            if (this.PlanTier == null && ParameterWasBound(nameof(this.PlanTier)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanTier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UsageLevel = this.UsageLevel;
            
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
            var request = new Amazon.PricingPlanManager.Model.CreateSubscriptionRequest();
            
            if (cmdletContext.ApprovalMode != null)
            {
                request.ApprovalMode = cmdletContext.ApprovalMode;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PlanFamily != null)
            {
                request.PlanFamily = cmdletContext.PlanFamily;
            }
            if (cmdletContext.PlanTier != null)
            {
                request.PlanTier = cmdletContext.PlanTier;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.UsageLevel != null)
            {
                request.UsageLevel = cmdletContext.UsageLevel;
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
        
        private Amazon.PricingPlanManager.Model.CreateSubscriptionResponse CallAWSServiceOperation(IAmazonPricingPlanManager client, Amazon.PricingPlanManager.Model.CreateSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "PricingPlanManager", "CreateSubscription");
            try
            {
                return client.CreateSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PricingPlanManager.ApprovalMode ApprovalMode { get; set; }
            public System.String ClientToken { get; set; }
            public System.String PlanFamily { get; set; }
            public System.String PlanTier { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.String UsageLevel { get; set; }
            public System.Func<Amazon.PricingPlanManager.Model.CreateSubscriptionResponse, NewPPMSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subscription;
        }
        
    }
}
