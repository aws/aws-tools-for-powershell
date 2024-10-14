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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// This updates an existing billing group.
    /// </summary>
    [Cmdlet("Update", "ABCBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BillingConductor.Model.UpdateBillingGroupResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor UpdateBillingGroup API operation.", Operation = new[] {"UpdateBillingGroup"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.UpdateBillingGroupResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.UpdateBillingGroupResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.UpdateBillingGroupResponse object containing multiple properties."
    )]
    public partial class UpdateABCBillingGroupCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the billing group being updated. </para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter AccountGrouping_AutoAssociate
        /// <summary>
        /// <para>
        /// <para>Specifies if this billing group will automatically associate newly added Amazon Web
        /// Services accounts that join your consolidated billing family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccountGrouping_AutoAssociate { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the billing group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the billing group. The names must be unique to each billing group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ComputationPreference_PricingPlanArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the pricing plan that's used to compute the Amazon
        /// Web Services charges for a billing group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputationPreference_PricingPlanArn { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the billing group. Only one of the valid values can be used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BillingConductor.BillingGroupStatus")]
        public Amazon.BillingConductor.BillingGroupStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.UpdateBillingGroupResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.UpdateBillingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ABCBillingGroup (UpdateBillingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.UpdateBillingGroupResponse, UpdateABCBillingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountGrouping_AutoAssociate = this.AccountGrouping_AutoAssociate;
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputationPreference_PricingPlanArn = this.ComputationPreference_PricingPlanArn;
            context.Description = this.Description;
            context.Name = this.Name;
            context.Status = this.Status;
            
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
            var request = new Amazon.BillingConductor.Model.UpdateBillingGroupRequest();
            
            
             // populate AccountGrouping
            var requestAccountGroupingIsNull = true;
            request.AccountGrouping = new Amazon.BillingConductor.Model.UpdateBillingGroupAccountGrouping();
            System.Boolean? requestAccountGrouping_accountGrouping_AutoAssociate = null;
            if (cmdletContext.AccountGrouping_AutoAssociate != null)
            {
                requestAccountGrouping_accountGrouping_AutoAssociate = cmdletContext.AccountGrouping_AutoAssociate.Value;
            }
            if (requestAccountGrouping_accountGrouping_AutoAssociate != null)
            {
                request.AccountGrouping.AutoAssociate = requestAccountGrouping_accountGrouping_AutoAssociate.Value;
                requestAccountGroupingIsNull = false;
            }
             // determine if request.AccountGrouping should be set to null
            if (requestAccountGroupingIsNull)
            {
                request.AccountGrouping = null;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate ComputationPreference
            var requestComputationPreferenceIsNull = true;
            request.ComputationPreference = new Amazon.BillingConductor.Model.ComputationPreference();
            System.String requestComputationPreference_computationPreference_PricingPlanArn = null;
            if (cmdletContext.ComputationPreference_PricingPlanArn != null)
            {
                requestComputationPreference_computationPreference_PricingPlanArn = cmdletContext.ComputationPreference_PricingPlanArn;
            }
            if (requestComputationPreference_computationPreference_PricingPlanArn != null)
            {
                request.ComputationPreference.PricingPlanArn = requestComputationPreference_computationPreference_PricingPlanArn;
                requestComputationPreferenceIsNull = false;
            }
             // determine if request.ComputationPreference should be set to null
            if (requestComputationPreferenceIsNull)
            {
                request.ComputationPreference = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.BillingConductor.Model.UpdateBillingGroupResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.UpdateBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "UpdateBillingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateBillingGroup(request);
                #elif CORECLR
                return client.UpdateBillingGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AccountGrouping_AutoAssociate { get; set; }
            public System.String Arn { get; set; }
            public System.String ComputationPreference_PricingPlanArn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.BillingConductor.BillingGroupStatus Status { get; set; }
            public System.Func<Amazon.BillingConductor.Model.UpdateBillingGroupResponse, UpdateABCBillingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
