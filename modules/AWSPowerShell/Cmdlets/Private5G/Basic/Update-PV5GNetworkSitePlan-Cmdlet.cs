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
using Amazon.Private5G;
using Amazon.Private5G.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Updates the specified network site plan.
    /// </summary>
    [Cmdlet("Update", "PV5GNetworkSitePlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Private5G.Model.NetworkSite")]
    [AWSCmdlet("Calls the AWS Private 5G UpdateNetworkSitePlan API operation.", Operation = new[] {"UpdateNetworkSitePlan"}, SelectReturnType = typeof(Amazon.Private5G.Model.UpdateNetworkSitePlanResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkSite or Amazon.Private5G.Model.UpdateNetworkSitePlanResponse",
        "This cmdlet returns an Amazon.Private5G.Model.NetworkSite object.",
        "The service call response (type Amazon.Private5G.Model.UpdateNetworkSitePlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePV5GNetworkSitePlanCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NetworkSiteArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network site.</para>
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
        public System.String NetworkSiteArn { get; set; }
        #endregion
        
        #region Parameter PendingPlan_Option
        /// <summary>
        /// <para>
        /// <para>The options of the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PendingPlan_Options")]
        public Amazon.Private5G.Model.NameValuePair[] PendingPlan_Option { get; set; }
        #endregion
        
        #region Parameter PendingPlan_ResourceDefinition
        /// <summary>
        /// <para>
        /// <para>The resource definitions of the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PendingPlan_ResourceDefinitions")]
        public Amazon.Private5G.Model.NetworkResourceDefinition[] PendingPlan_ResourceDefinition { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkSite'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.UpdateNetworkSitePlanResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.UpdateNetworkSitePlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkSite";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkSiteArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PV5GNetworkSitePlan (UpdateNetworkSitePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.UpdateNetworkSitePlanResponse, UpdatePV5GNetworkSitePlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.NetworkSiteArn = this.NetworkSiteArn;
            #if MODULAR
            if (this.NetworkSiteArn == null && ParameterWasBound(nameof(this.NetworkSiteArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkSiteArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PendingPlan_Option != null)
            {
                context.PendingPlan_Option = new List<Amazon.Private5G.Model.NameValuePair>(this.PendingPlan_Option);
            }
            if (this.PendingPlan_ResourceDefinition != null)
            {
                context.PendingPlan_ResourceDefinition = new List<Amazon.Private5G.Model.NetworkResourceDefinition>(this.PendingPlan_ResourceDefinition);
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
            var request = new Amazon.Private5G.Model.UpdateNetworkSitePlanRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.NetworkSiteArn != null)
            {
                request.NetworkSiteArn = cmdletContext.NetworkSiteArn;
            }
            
             // populate PendingPlan
            var requestPendingPlanIsNull = true;
            request.PendingPlan = new Amazon.Private5G.Model.SitePlan();
            List<Amazon.Private5G.Model.NameValuePair> requestPendingPlan_pendingPlan_Option = null;
            if (cmdletContext.PendingPlan_Option != null)
            {
                requestPendingPlan_pendingPlan_Option = cmdletContext.PendingPlan_Option;
            }
            if (requestPendingPlan_pendingPlan_Option != null)
            {
                request.PendingPlan.Options = requestPendingPlan_pendingPlan_Option;
                requestPendingPlanIsNull = false;
            }
            List<Amazon.Private5G.Model.NetworkResourceDefinition> requestPendingPlan_pendingPlan_ResourceDefinition = null;
            if (cmdletContext.PendingPlan_ResourceDefinition != null)
            {
                requestPendingPlan_pendingPlan_ResourceDefinition = cmdletContext.PendingPlan_ResourceDefinition;
            }
            if (requestPendingPlan_pendingPlan_ResourceDefinition != null)
            {
                request.PendingPlan.ResourceDefinitions = requestPendingPlan_pendingPlan_ResourceDefinition;
                requestPendingPlanIsNull = false;
            }
             // determine if request.PendingPlan should be set to null
            if (requestPendingPlanIsNull)
            {
                request.PendingPlan = null;
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
        
        private Amazon.Private5G.Model.UpdateNetworkSitePlanResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.UpdateNetworkSitePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "UpdateNetworkSitePlan");
            try
            {
                return client.UpdateNetworkSitePlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NetworkSiteArn { get; set; }
            public List<Amazon.Private5G.Model.NameValuePair> PendingPlan_Option { get; set; }
            public List<Amazon.Private5G.Model.NetworkResourceDefinition> PendingPlan_ResourceDefinition { get; set; }
            public System.Func<Amazon.Private5G.Model.UpdateNetworkSitePlanResponse, UpdatePV5GNetworkSitePlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkSite;
        }
        
    }
}
