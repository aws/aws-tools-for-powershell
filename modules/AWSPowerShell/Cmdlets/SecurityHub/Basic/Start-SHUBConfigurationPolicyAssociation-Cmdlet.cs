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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Associates a target account, organizational unit, or the root with a specified configuration.
    /// The target can be associated with a configuration policy or self-managed behavior.
    /// Only the Security Hub delegated administrator can invoke this operation from the home
    /// Region.
    /// </summary>
    [Cmdlet("Start", "SHUBConfigurationPolicyAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse")]
    [AWSCmdlet("Calls the AWS Security Hub StartConfigurationPolicyAssociation API operation.", Operation = new[] {"StartConfigurationPolicyAssociation"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse object containing multiple properties."
    )]
    public partial class StartSHUBConfigurationPolicyAssociationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Target_AccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID of the target account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationPolicyIdentifier
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of a configuration policy, the universally unique
        /// identifier (UUID) of a configuration policy, or a value of <c>SELF_MANAGED_SECURITY_HUB</c>
        /// for a self-managed configuration. </para>
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
        public System.String ConfigurationPolicyIdentifier { get; set; }
        #endregion
        
        #region Parameter Target_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para> The organizational unit ID of the target organizational unit. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Target_RootId
        /// <summary>
        /// <para>
        /// <para> The ID of the organization root. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_RootId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationPolicyIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationPolicyIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationPolicyIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationPolicyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SHUBConfigurationPolicyAssociation (StartConfigurationPolicyAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse, StartSHUBConfigurationPolicyAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationPolicyIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationPolicyIdentifier = this.ConfigurationPolicyIdentifier;
            #if MODULAR
            if (this.ConfigurationPolicyIdentifier == null && ParameterWasBound(nameof(this.ConfigurationPolicyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationPolicyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_AccountId = this.Target_AccountId;
            context.Target_OrganizationalUnitId = this.Target_OrganizationalUnitId;
            context.Target_RootId = this.Target_RootId;
            
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
            var request = new Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationRequest();
            
            if (cmdletContext.ConfigurationPolicyIdentifier != null)
            {
                request.ConfigurationPolicyIdentifier = cmdletContext.ConfigurationPolicyIdentifier;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.SecurityHub.Model.Target();
            System.String requestTarget_target_AccountId = null;
            if (cmdletContext.Target_AccountId != null)
            {
                requestTarget_target_AccountId = cmdletContext.Target_AccountId;
            }
            if (requestTarget_target_AccountId != null)
            {
                request.Target.AccountId = requestTarget_target_AccountId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_OrganizationalUnitId = null;
            if (cmdletContext.Target_OrganizationalUnitId != null)
            {
                requestTarget_target_OrganizationalUnitId = cmdletContext.Target_OrganizationalUnitId;
            }
            if (requestTarget_target_OrganizationalUnitId != null)
            {
                request.Target.OrganizationalUnitId = requestTarget_target_OrganizationalUnitId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_RootId = null;
            if (cmdletContext.Target_RootId != null)
            {
                requestTarget_target_RootId = cmdletContext.Target_RootId;
            }
            if (requestTarget_target_RootId != null)
            {
                request.Target.RootId = requestTarget_target_RootId;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "StartConfigurationPolicyAssociation");
            try
            {
                #if DESKTOP
                return client.StartConfigurationPolicyAssociation(request);
                #elif CORECLR
                return client.StartConfigurationPolicyAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationPolicyIdentifier { get; set; }
            public System.String Target_AccountId { get; set; }
            public System.String Target_OrganizationalUnitId { get; set; }
            public System.String Target_RootId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.StartConfigurationPolicyAssociationResponse, StartSHUBConfigurationPolicyAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
