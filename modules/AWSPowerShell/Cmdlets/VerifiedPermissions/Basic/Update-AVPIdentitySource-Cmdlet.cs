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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Updates the specified identity source to use a new identity provider (IdP) source,
    /// or to change the mapping of identities from the IdP to a different principal entity
    /// type.
    /// </summary>
    [Cmdlet("Update", "AVPIdentitySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions UpdateIdentitySource API operation.", Operation = new[] {"UpdateIdentitySource"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAVPIdentitySourceCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter CognitoUserPoolConfiguration_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of an app client that is configured for the specified Amazon Cognito
        /// user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_CognitoUserPoolConfiguration_ClientIds")]
        public System.String[] CognitoUserPoolConfiguration_ClientId { get; set; }
        #endregion
        
        #region Parameter IdentitySourceId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the identity source that you want to update.</para>
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
        public System.String IdentitySourceId { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store that contains the identity source that you want
        /// to update.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter PrincipalEntityType
        /// <summary>
        /// <para>
        /// <para>Specifies the data type of principals generated for identities authenticated by the
        /// identity source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalEntityType { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_UserPoolArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the Amazon Cognito user pool associated with this identity
        /// source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_CognitoUserPoolConfiguration_UserPoolArn")]
        public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentitySourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AVPIdentitySource (UpdateIdentitySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse, UpdateAVPIdentitySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentitySourceId = this.IdentitySourceId;
            #if MODULAR
            if (this.IdentitySourceId == null && ParameterWasBound(nameof(this.IdentitySourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentitySourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalEntityType = this.PrincipalEntityType;
            if (this.CognitoUserPoolConfiguration_ClientId != null)
            {
                context.CognitoUserPoolConfiguration_ClientId = new List<System.String>(this.CognitoUserPoolConfiguration_ClientId);
            }
            context.CognitoUserPoolConfiguration_UserPoolArn = this.CognitoUserPoolConfiguration_UserPoolArn;
            
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
            var request = new Amazon.VerifiedPermissions.Model.UpdateIdentitySourceRequest();
            
            if (cmdletContext.IdentitySourceId != null)
            {
                request.IdentitySourceId = cmdletContext.IdentitySourceId;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.PrincipalEntityType != null)
            {
                request.PrincipalEntityType = cmdletContext.PrincipalEntityType;
            }
            
             // populate UpdateConfiguration
            var requestUpdateConfigurationIsNull = true;
            request.UpdateConfiguration = new Amazon.VerifiedPermissions.Model.UpdateConfiguration();
            Amazon.VerifiedPermissions.Model.UpdateCognitoUserPoolConfiguration requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = null;
            
             // populate CognitoUserPoolConfiguration
            var requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = true;
            requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = new Amazon.VerifiedPermissions.Model.UpdateCognitoUserPoolConfiguration();
            List<System.String> requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = null;
            if (cmdletContext.CognitoUserPoolConfiguration_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = cmdletContext.CognitoUserPoolConfiguration_ClientId;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration.ClientIds = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = null;
            if (cmdletContext.CognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = cmdletContext.CognitoUserPoolConfiguration_UserPoolArn;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration.UserPoolArn = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration should be set to null
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration != null)
            {
                request.UpdateConfiguration.CognitoUserPoolConfiguration = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration;
                requestUpdateConfigurationIsNull = false;
            }
             // determine if request.UpdateConfiguration should be set to null
            if (requestUpdateConfigurationIsNull)
            {
                request.UpdateConfiguration = null;
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
        
        private Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.UpdateIdentitySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "UpdateIdentitySource");
            try
            {
                #if DESKTOP
                return client.UpdateIdentitySource(request);
                #elif CORECLR
                return client.UpdateIdentitySourceAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentitySourceId { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.String PrincipalEntityType { get; set; }
            public List<System.String> CognitoUserPoolConfiguration_ClientId { get; set; }
            public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse, UpdateAVPIdentitySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
