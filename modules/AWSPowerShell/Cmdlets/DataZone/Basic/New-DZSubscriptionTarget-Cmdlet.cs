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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Creates a subscription target in Amazon DataZone.
    /// </summary>
    [Cmdlet("New", "DZSubscriptionTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateSubscriptionTargetResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateSubscriptionTarget API operation.", Operation = new[] {"CreateSubscriptionTarget"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateSubscriptionTargetResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateSubscriptionTargetResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateSubscriptionTargetResponse object containing multiple properties."
    )]
    public partial class NewDZSubscriptionTargetCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicableAssetType
        /// <summary>
        /// <para>
        /// <para>The asset types that can be included in the subscription target.</para>
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
        [Alias("ApplicableAssetTypes")]
        public System.String[] ApplicableAssetType { get; set; }
        #endregion
        
        #region Parameter AuthorizedPrincipal
        /// <summary>
        /// <para>
        /// <para>The authorized principals of the subscription target.</para>
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
        [Alias("AuthorizedPrincipals")]
        public System.String[] AuthorizedPrincipal { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain in which subscription target is created.</para>
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
        /// <para>The ID of the environment in which subscription target is created.</para>
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
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter ManageAccessRole
        /// <summary>
        /// <para>
        /// <para>The manage access role that is used to create the subscription target.</para>
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
        public System.String ManageAccessRole { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the subscription target.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the subscription target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider { get; set; }
        #endregion
        
        #region Parameter SubscriptionTargetConfig
        /// <summary>
        /// <para>
        /// <para>The configuration of the subscription target.</para>
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
        public Amazon.DataZone.Model.SubscriptionTargetForm[] SubscriptionTargetConfig { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the subscription target.</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateSubscriptionTargetResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateSubscriptionTargetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZSubscriptionTarget (CreateSubscriptionTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateSubscriptionTargetResponse, NewDZSubscriptionTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ApplicableAssetType != null)
            {
                context.ApplicableAssetType = new List<System.String>(this.ApplicableAssetType);
            }
            #if MODULAR
            if (this.ApplicableAssetType == null && ParameterWasBound(nameof(this.ApplicableAssetType)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicableAssetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthorizedPrincipal != null)
            {
                context.AuthorizedPrincipal = new List<System.String>(this.AuthorizedPrincipal);
            }
            #if MODULAR
            if (this.AuthorizedPrincipal == null && ParameterWasBound(nameof(this.AuthorizedPrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizedPrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
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
            context.ManageAccessRole = this.ManageAccessRole;
            #if MODULAR
            if (this.ManageAccessRole == null && ParameterWasBound(nameof(this.ManageAccessRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ManageAccessRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Provider = this.Provider;
            if (this.SubscriptionTargetConfig != null)
            {
                context.SubscriptionTargetConfig = new List<Amazon.DataZone.Model.SubscriptionTargetForm>(this.SubscriptionTargetConfig);
            }
            #if MODULAR
            if (this.SubscriptionTargetConfig == null && ParameterWasBound(nameof(this.SubscriptionTargetConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionTargetConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataZone.Model.CreateSubscriptionTargetRequest();
            
            if (cmdletContext.ApplicableAssetType != null)
            {
                request.ApplicableAssetTypes = cmdletContext.ApplicableAssetType;
            }
            if (cmdletContext.AuthorizedPrincipal != null)
            {
                request.AuthorizedPrincipals = cmdletContext.AuthorizedPrincipal;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
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
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DataZone.Model.CreateSubscriptionTargetResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateSubscriptionTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateSubscriptionTarget");
            try
            {
                return client.CreateSubscriptionTargetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String ManageAccessRole { get; set; }
            public System.String Name { get; set; }
            public System.String Provider { get; set; }
            public List<Amazon.DataZone.Model.SubscriptionTargetForm> SubscriptionTargetConfig { get; set; }
            public System.String Type { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateSubscriptionTargetResponse, NewDZSubscriptionTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
