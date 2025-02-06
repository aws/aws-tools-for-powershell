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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Sets the roles for an identity pool. These roles are used when making calls to <a>GetCredentialsForIdentity</a>
    /// action.
    /// 
    ///  
    /// <para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "CGIIdentityPoolRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity SetIdentityPoolRoles API operation.", Operation = new[] {"SetIdentityPoolRoles"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetCGIIdentityPoolRoleCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>An identity pool ID in the format REGION:GUID.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter RoleMapping
        /// <summary>
        /// <para>
        /// <para>How users for a specific identity provider are to mapped to roles. This is a string
        /// to <a>RoleMapping</a> object map. The string identifies the identity provider, for
        /// example, "graph.facebook.com" or "cognito-idp.us-east-1.amazonaws.com/us-east-1_abcdefghi:app_client_id".</para><para>Up to 25 rules can be specified per identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoleMappings")]
        public System.Collections.Hashtable RoleMapping { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The map of roles associated with this pool. For a given role, the key will be either
        /// "authenticated" or "unauthenticated" and the value will be the Role ARN.</para>
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
        [Alias("Roles")]
        public System.Collections.Hashtable Role { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIIdentityPoolRole (SetIdentityPoolRoles)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse, SetCGIIdentityPoolRoleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RoleMapping != null)
            {
                context.RoleMapping = new Dictionary<System.String, Amazon.CognitoIdentity.Model.RoleMapping>(StringComparer.Ordinal);
                foreach (var hashKey in this.RoleMapping.Keys)
                {
                    context.RoleMapping.Add((String)hashKey, (Amazon.CognitoIdentity.Model.RoleMapping)(this.RoleMapping[hashKey]));
                }
            }
            if (this.Role != null)
            {
                context.Role = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Role.Keys)
                {
                    context.Role.Add((String)hashKey, (System.String)(this.Role[hashKey]));
                }
            }
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentity.Model.SetIdentityPoolRolesRequest();
            
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.RoleMapping != null)
            {
                request.RoleMappings = cmdletContext.RoleMapping;
            }
            if (cmdletContext.Role != null)
            {
                request.Roles = cmdletContext.Role;
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
        
        private Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.SetIdentityPoolRolesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "SetIdentityPoolRoles");
            try
            {
                #if DESKTOP
                return client.SetIdentityPoolRoles(request);
                #elif CORECLR
                return client.SetIdentityPoolRolesAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityPoolId { get; set; }
            public Dictionary<System.String, Amazon.CognitoIdentity.Model.RoleMapping> RoleMapping { get; set; }
            public Dictionary<System.String, System.String> Role { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse, SetCGIIdentityPoolRoleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
