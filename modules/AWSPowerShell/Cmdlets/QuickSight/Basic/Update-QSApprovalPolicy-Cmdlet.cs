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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates an approval policy in Quick Sight.
    /// </summary>
    [Cmdlet("Update", "QSApprovalPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.ApprovalPolicy")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateApprovalPolicy API operation.", Operation = new[] {"UpdateApprovalPolicy"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateApprovalPolicyResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.ApprovalPolicy or Amazon.QuickSight.Model.UpdateApprovalPolicyResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.ApprovalPolicy object.",
        "The service call response (type Amazon.QuickSight.Model.UpdateApprovalPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQSApprovalPolicyCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The list of governed actions that trigger the approval workflow.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public System.String[] Action { get; set; }
        #endregion
        
        #region Parameter ApprovalGroup
        /// <summary>
        /// <para>
        /// <para>The list of group ARNs whose members can approve requests.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovalGroups")]
        public System.String[] ApprovalGroup { get; set; }
        #endregion
        
        #region Parameter AssetType
        /// <summary>
        /// <para>
        /// <para>The list of asset types that the approval policy applies to.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetTypes")]
        public System.String[] AssetType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the approval policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ApplicableTo_GroupArn
        /// <summary>
        /// <para>
        /// <para>The list of group ARNs that the policy applies to. Required when type is GROUP.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicableTo_GroupArns")]
        public System.String[] ApplicableTo_GroupArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the approval policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the approval policy to update.</para>
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
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter ApplicableTo_Type
        /// <summary>
        /// <para>
        /// <para>The type of scoping that determines which principals the approval policy applies to.
        /// Valid values are defined as follows:</para><ul><li><para><c>GROUP</c>: The policy applies only to principals in the groups specified by <c>GroupArns</c>.
        /// When you use <c>GROUP</c>, you must also provide a value for <c>GroupArns</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.ApplicableToType")]
        public Amazon.QuickSight.ApplicableToType ApplicableTo_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateApprovalPolicyResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateApprovalPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSApprovalPolicy (UpdateApprovalPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateApprovalPolicyResponse, UpdateQSApprovalPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<System.String>(this.Action);
            }
            if (this.ApplicableTo_GroupArn != null)
            {
                context.ApplicableTo_GroupArn = new List<System.String>(this.ApplicableTo_GroupArn);
            }
            context.ApplicableTo_Type = this.ApplicableTo_Type;
            if (this.ApprovalGroup != null)
            {
                context.ApprovalGroup = new List<System.String>(this.ApprovalGroup);
            }
            if (this.AssetType != null)
            {
                context.AssetType = new List<System.String>(this.AssetType);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            context.PolicyId = this.PolicyId;
            #if MODULAR
            if (this.PolicyId == null && ParameterWasBound(nameof(this.PolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateApprovalPolicyRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            
             // populate ApplicableTo
            var requestApplicableToIsNull = true;
            request.ApplicableTo = new Amazon.QuickSight.Model.ApplicableTo();
            List<System.String> requestApplicableTo_applicableTo_GroupArn = null;
            if (cmdletContext.ApplicableTo_GroupArn != null)
            {
                requestApplicableTo_applicableTo_GroupArn = cmdletContext.ApplicableTo_GroupArn;
            }
            if (requestApplicableTo_applicableTo_GroupArn != null)
            {
                request.ApplicableTo.GroupArns = requestApplicableTo_applicableTo_GroupArn;
                requestApplicableToIsNull = false;
            }
            Amazon.QuickSight.ApplicableToType requestApplicableTo_applicableTo_Type = null;
            if (cmdletContext.ApplicableTo_Type != null)
            {
                requestApplicableTo_applicableTo_Type = cmdletContext.ApplicableTo_Type;
            }
            if (requestApplicableTo_applicableTo_Type != null)
            {
                request.ApplicableTo.Type = requestApplicableTo_applicableTo_Type;
                requestApplicableToIsNull = false;
            }
             // determine if request.ApplicableTo should be set to null
            if (requestApplicableToIsNull)
            {
                request.ApplicableTo = null;
            }
            if (cmdletContext.ApprovalGroup != null)
            {
                request.ApprovalGroups = cmdletContext.ApprovalGroup;
            }
            if (cmdletContext.AssetType != null)
            {
                request.AssetTypes = cmdletContext.AssetType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
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
        
        private Amazon.QuickSight.Model.UpdateApprovalPolicyResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateApprovalPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateApprovalPolicy");
            try
            {
                return client.UpdateApprovalPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Action { get; set; }
            public List<System.String> ApplicableTo_GroupArn { get; set; }
            public Amazon.QuickSight.ApplicableToType ApplicableTo_Type { get; set; }
            public List<System.String> ApprovalGroup { get; set; }
            public List<System.String> AssetType { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PolicyId { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateApprovalPolicyResponse, UpdateQSApprovalPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
