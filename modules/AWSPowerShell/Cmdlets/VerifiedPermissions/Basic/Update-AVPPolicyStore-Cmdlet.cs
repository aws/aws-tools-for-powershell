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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Modifies the validation setting for a policy store.
    /// 
    ///  <note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "AVPPolicyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions UpdatePolicyStore API operation.", Operation = new[] {"UpdatePolicyStore"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse object containing multiple properties."
    )]
    public partial class UpdateAVPPolicyStoreCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Descriptive text that you can provide to help with identification of the current policy
        /// store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ValidationSettings_Mode
        /// <summary>
        /// <para>
        /// <para>The validation mode currently configured for this policy store. The valid values are:</para><ul><li><para><b>OFF</b> – Neither Verified Permissions nor Cedar perform any validation on policies.
        /// No validation errors are reported by either service.</para></li><li><para><b>STRICT</b> – Requires a schema to be present in the policy store. Cedar performs
        /// validation on all submitted new or updated static policies and policy templates. Any
        /// that fail validation are rejected and Cedar doesn't store them in the policy store.</para></li></ul><important><para>If <c>Mode=STRICT</c> and the policy store doesn't contain a schema, Verified Permissions
        /// rejects all static policies and policy templates because there is no schema to validate
        /// against. </para><para>To submit a static policy or policy template without a schema, you must turn off validation.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.VerifiedPermissions.ValidationMode")]
        public Amazon.VerifiedPermissions.ValidationMode ValidationSettings_Mode { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store that you want to update</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AVPPolicyStore (UpdatePolicyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse, UpdateAVPPolicyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationSettings_Mode = this.ValidationSettings_Mode;
            #if MODULAR
            if (this.ValidationSettings_Mode == null && ParameterWasBound(nameof(this.ValidationSettings_Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter ValidationSettings_Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.UpdatePolicyStoreRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            
             // populate ValidationSettings
            var requestValidationSettingsIsNull = true;
            request.ValidationSettings = new Amazon.VerifiedPermissions.Model.ValidationSettings();
            Amazon.VerifiedPermissions.ValidationMode requestValidationSettings_validationSettings_Mode = null;
            if (cmdletContext.ValidationSettings_Mode != null)
            {
                requestValidationSettings_validationSettings_Mode = cmdletContext.ValidationSettings_Mode;
            }
            if (requestValidationSettings_validationSettings_Mode != null)
            {
                request.ValidationSettings.Mode = requestValidationSettings_validationSettings_Mode;
                requestValidationSettingsIsNull = false;
            }
             // determine if request.ValidationSettings should be set to null
            if (requestValidationSettingsIsNull)
            {
                request.ValidationSettings = null;
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
        
        private Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.UpdatePolicyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "UpdatePolicyStore");
            try
            {
                #if DESKTOP
                return client.UpdatePolicyStore(request);
                #elif CORECLR
                return client.UpdatePolicyStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String PolicyStoreId { get; set; }
            public Amazon.VerifiedPermissions.ValidationMode ValidationSettings_Mode { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.UpdatePolicyStoreResponse, UpdateAVPPolicyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
