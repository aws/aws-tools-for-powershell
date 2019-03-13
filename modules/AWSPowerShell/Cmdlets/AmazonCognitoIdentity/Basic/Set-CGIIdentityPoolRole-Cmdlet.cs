/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity SetIdentityPoolRoles API operation.", Operation = new[] {"SetIdentityPoolRoles"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the IdentityPoolId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CognitoIdentity.Model.SetIdentityPoolRolesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCGIIdentityPoolRoleCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>An identity pool ID in the format REGION:GUID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter RoleMapping
        /// <summary>
        /// <para>
        /// <para>How users for a specific identity provider are to mapped to roles. This is a string
        /// to <a>RoleMapping</a> object map. The string identifies the identity provider, for
        /// example, "graph.facebook.com" or "cognito-idp-east-1.amazonaws.com/us-east-1_abcdefghi:app_client_id".</para><para>Up to 25 rules can be specified per identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("Roles")]
        public System.Collections.Hashtable Role { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the IdentityPoolId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IdentityPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIIdentityPoolRole (SetIdentityPoolRoles)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.IdentityPoolId = this.IdentityPoolId;
            if (this.RoleMapping != null)
            {
                context.RoleMappings = new Dictionary<System.String, Amazon.CognitoIdentity.Model.RoleMapping>(StringComparer.Ordinal);
                foreach (var hashKey in this.RoleMapping.Keys)
                {
                    context.RoleMappings.Add((String)hashKey, (RoleMapping)(this.RoleMapping[hashKey]));
                }
            }
            if (this.Role != null)
            {
                context.Roles = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Role.Keys)
                {
                    context.Roles.Add((String)hashKey, (String)(this.Role[hashKey]));
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
            var request = new Amazon.CognitoIdentity.Model.SetIdentityPoolRolesRequest();
            
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.RoleMappings != null)
            {
                request.RoleMappings = cmdletContext.RoleMappings;
            }
            if (cmdletContext.Roles != null)
            {
                request.Roles = cmdletContext.Roles;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.IdentityPoolId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public Dictionary<System.String, Amazon.CognitoIdentity.Model.RoleMapping> RoleMappings { get; set; }
            public Dictionary<System.String, System.String> Roles { get; set; }
        }
        
    }
}
