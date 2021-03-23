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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Changes the association of a <a>FirewallRuleGroup</a> with a VPC. The association
    /// enables DNS filtering for the VPC.
    /// </summary>
    [Cmdlet("Edit", "R53RFirewallRuleGroupAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.FirewallRuleGroupAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver UpdateFirewallRuleGroupAssociation API operation.", Operation = new[] {"UpdateFirewallRuleGroupAssociation"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.FirewallRuleGroupAssociation or Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.FirewallRuleGroupAssociation object.",
        "The service call response (type Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditR53RFirewallRuleGroupAssociationCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter FirewallRuleGroupAssociationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the <a>FirewallRuleGroupAssociation</a>. </para>
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
        public System.String FirewallRuleGroupAssociationId { get; set; }
        #endregion
        
        #region Parameter MutationProtection
        /// <summary>
        /// <para>
        /// <para>If enabled, this setting disallows modification or removal of the association, to
        /// help prevent against accidentally altering DNS firewall protections. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.MutationProtectionStatus")]
        public Amazon.Route53Resolver.MutationProtectionStatus MutationProtection { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the rule group association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The setting that determines the processing order of the rule group among the rule
        /// groups that you associate with the specified VPC. DNS Firewall filters VPC traffic
        /// starting from rule group with the lowest numeric priority setting. </para><para>You must specify a unique priority for each rule group that you associate with a single
        /// VPC. To make it easier to insert rule groups later, leave space between the numbers,
        /// for example, use 100, 200, and so on. You can change the priority setting for a rule
        /// group association after you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FirewallRuleGroupAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FirewallRuleGroupAssociation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallRuleGroupAssociationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallRuleGroupAssociationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallRuleGroupAssociationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallRuleGroupAssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-R53RFirewallRuleGroupAssociation (UpdateFirewallRuleGroupAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse, EditR53RFirewallRuleGroupAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallRuleGroupAssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirewallRuleGroupAssociationId = this.FirewallRuleGroupAssociationId;
            #if MODULAR
            if (this.FirewallRuleGroupAssociationId == null && ParameterWasBound(nameof(this.FirewallRuleGroupAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallRuleGroupAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MutationProtection = this.MutationProtection;
            context.Name = this.Name;
            context.Priority = this.Priority;
            
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
            var request = new Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationRequest();
            
            if (cmdletContext.FirewallRuleGroupAssociationId != null)
            {
                request.FirewallRuleGroupAssociationId = cmdletContext.FirewallRuleGroupAssociationId;
            }
            if (cmdletContext.MutationProtection != null)
            {
                request.MutationProtection = cmdletContext.MutationProtection;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
        
        private Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "UpdateFirewallRuleGroupAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateFirewallRuleGroupAssociation(request);
                #elif CORECLR
                return client.UpdateFirewallRuleGroupAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String FirewallRuleGroupAssociationId { get; set; }
            public Amazon.Route53Resolver.MutationProtectionStatus MutationProtection { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.UpdateFirewallRuleGroupAssociationResponse, EditR53RFirewallRuleGroupAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FirewallRuleGroupAssociation;
        }
        
    }
}
