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
    /// Creates a billing group that resembles a consolidated billing family that Amazon
    /// Web Services charges, based off of the predefined pricing plan computation.
    /// </summary>
    [Cmdlet("New", "ABCBillingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSBillingConductor CreateBillingGroup API operation.", Operation = new[] {"CreateBillingGroup"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.CreateBillingGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.BillingConductor.Model.CreateBillingGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BillingConductor.Model.CreateBillingGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewABCBillingGroupCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the billing group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AccountGrouping_LinkedAccountId
        /// <summary>
        /// <para>
        /// <para> The account IDs that make up the billing group. Account IDs must be a part of the
        /// consolidated billing family, and not associated with another billing group. </para>
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
        [Alias("AccountGrouping_LinkedAccountIds")]
        public System.String[] AccountGrouping_LinkedAccountId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The billing group name. The names must be unique. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ComputationPreference_PricingPlanArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the pricing plan that's used to compute the Amazon
        /// Web Services charges for a billing group. </para>
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
        public System.String ComputationPreference_PricingPlanArn { get; set; }
        #endregion
        
        #region Parameter PrimaryAccountId
        /// <summary>
        /// <para>
        /// <para> The account ID that serves as the main account in a billing group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryAccountId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A map that contains tag keys and tag values that are attached to a billing group.
        /// This feature isn't available during the beta. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> The token that is needed to support idempotency. Idempotency isn't currently supported,
        /// but will be implemented in a future update. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.CreateBillingGroupResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.CreateBillingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ABCBillingGroup (CreateBillingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.CreateBillingGroupResponse, NewABCBillingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountGrouping_LinkedAccountId != null)
            {
                context.AccountGrouping_LinkedAccountId = new List<System.String>(this.AccountGrouping_LinkedAccountId);
            }
            #if MODULAR
            if (this.AccountGrouping_LinkedAccountId == null && ParameterWasBound(nameof(this.AccountGrouping_LinkedAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountGrouping_LinkedAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ComputationPreference_PricingPlanArn = this.ComputationPreference_PricingPlanArn;
            #if MODULAR
            if (this.ComputationPreference_PricingPlanArn == null && ParameterWasBound(nameof(this.ComputationPreference_PricingPlanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputationPreference_PricingPlanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryAccountId = this.PrimaryAccountId;
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
            var request = new Amazon.BillingConductor.Model.CreateBillingGroupRequest();
            
            
             // populate AccountGrouping
            var requestAccountGroupingIsNull = true;
            request.AccountGrouping = new Amazon.BillingConductor.Model.AccountGrouping();
            List<System.String> requestAccountGrouping_accountGrouping_LinkedAccountId = null;
            if (cmdletContext.AccountGrouping_LinkedAccountId != null)
            {
                requestAccountGrouping_accountGrouping_LinkedAccountId = cmdletContext.AccountGrouping_LinkedAccountId;
            }
            if (requestAccountGrouping_accountGrouping_LinkedAccountId != null)
            {
                request.AccountGrouping.LinkedAccountIds = requestAccountGrouping_accountGrouping_LinkedAccountId;
                requestAccountGroupingIsNull = false;
            }
             // determine if request.AccountGrouping should be set to null
            if (requestAccountGroupingIsNull)
            {
                request.AccountGrouping = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.PrimaryAccountId != null)
            {
                request.PrimaryAccountId = cmdletContext.PrimaryAccountId;
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
        
        private Amazon.BillingConductor.Model.CreateBillingGroupResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.CreateBillingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "CreateBillingGroup");
            try
            {
                #if DESKTOP
                return client.CreateBillingGroup(request);
                #elif CORECLR
                return client.CreateBillingGroupAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountGrouping_LinkedAccountId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ComputationPreference_PricingPlanArn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PrimaryAccountId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BillingConductor.Model.CreateBillingGroupResponse, NewABCBillingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
