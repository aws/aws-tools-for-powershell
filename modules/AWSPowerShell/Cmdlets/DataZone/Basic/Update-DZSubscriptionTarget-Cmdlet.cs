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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates the specified subscription target in Amazon DataZone.
    /// </summary>
    [Cmdlet("Update", "DZSubscriptionTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateSubscriptionTargetResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateSubscriptionTarget API operation.", Operation = new[] {"UpdateSubscriptionTarget"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateSubscriptionTargetResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateSubscriptionTargetResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateSubscriptionTargetResponse object containing multiple properties."
    )]
    public partial class UpdateDZSubscriptionTargetCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicableAssetType
        /// <summary>
        /// <para>
        /// <para>The applicable asset types to be updated as part of the <c>UpdateSubscriptionTarget</c>
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicableAssetTypes")]
        public System.String[] ApplicableAssetType { get; set; }
        #endregion
        
        #region Parameter AuthorizedPrincipal
        /// <summary>
        /// <para>
        /// <para>The authorized principals to be updated as part of the <c>UpdateSubscriptionTarget</c>
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizedPrincipals")]
        public System.String[] AuthorizedPrincipal { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain in which a subscription target is to
        /// be updated.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the environment in which a subscription target is to be updated.</para>
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
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Identifier of the subscription target that is to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter ManageAccessRole
        /// <summary>
        /// <para>
        /// <para>The manage access role to be updated as part of the <c>UpdateSubscriptionTarget</c>
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManageAccessRole { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to be updated as part of the <c>UpdateSubscriptionTarget</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The provider to be updated as part of the <c>UpdateSubscriptionTarget</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider { get; set; }
        #endregion
        
        #region Parameter SubscriptionTargetConfig
        /// <summary>
        /// <para>
        /// <para>The configuration to be updated as part of the <c>UpdateSubscriptionTarget</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.SubscriptionTargetForm[] SubscriptionTargetConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateSubscriptionTargetResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateSubscriptionTargetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZSubscriptionTarget (UpdateSubscriptionTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateSubscriptionTargetResponse, UpdateDZSubscriptionTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ApplicableAssetType != null)
            {
                context.ApplicableAssetType = new List<System.String>(this.ApplicableAssetType);
            }
            if (this.AuthorizedPrincipal != null)
            {
                context.AuthorizedPrincipal = new List<System.String>(this.AuthorizedPrincipal);
            }
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManageAccessRole = this.ManageAccessRole;
            context.Name = this.Name;
            context.Provider = this.Provider;
            if (this.SubscriptionTargetConfig != null)
            {
                context.SubscriptionTargetConfig = new List<Amazon.DataZone.Model.SubscriptionTargetForm>(this.SubscriptionTargetConfig);
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
            var request = new Amazon.DataZone.Model.UpdateSubscriptionTargetRequest();
            
            if (cmdletContext.ApplicableAssetType != null)
            {
                request.ApplicableAssetTypes = cmdletContext.ApplicableAssetType;
            }
            if (cmdletContext.AuthorizedPrincipal != null)
            {
                request.AuthorizedPrincipals = cmdletContext.AuthorizedPrincipal;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.ManageAccessRole != null)
            {
                request.ManageAccessRole = cmdletContext.ManageAccessRole;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            if (cmdletContext.SubscriptionTargetConfig != null)
            {
                request.SubscriptionTargetConfig = cmdletContext.SubscriptionTargetConfig;
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
        
        private Amazon.DataZone.Model.UpdateSubscriptionTargetResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateSubscriptionTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateSubscriptionTarget");
            try
            {
                #if DESKTOP
                return client.UpdateSubscriptionTarget(request);
                #elif CORECLR
                return client.UpdateSubscriptionTargetAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ApplicableAssetType { get; set; }
            public List<System.String> AuthorizedPrincipal { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public System.String ManageAccessRole { get; set; }
            public System.String Name { get; set; }
            public System.String Provider { get; set; }
            public List<Amazon.DataZone.Model.SubscriptionTargetForm> SubscriptionTargetConfig { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateSubscriptionTargetResponse, UpdateDZSubscriptionTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
