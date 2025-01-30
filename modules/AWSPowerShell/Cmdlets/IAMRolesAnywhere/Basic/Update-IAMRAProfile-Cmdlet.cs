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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

namespace Amazon.PowerShell.Cmdlets.IAMRA
{
    /// <summary>
    /// Updates a <i>profile</i>, a list of the roles that IAM Roles Anywhere service is trusted
    /// to assume. You use profiles to intersect permissions with IAM managed policies.
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:UpdateProfile</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMRAProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.ProfileDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere UpdateProfile API operation.", Operation = new[] {"UpdateProfile"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.ProfileDetail or Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.ProfileDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIAMRAProfileCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptRoleSessionName
        /// <summary>
        /// <para>
        /// <para>Used to determine if a custom role session name will be accepted in a temporary credential
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AcceptRoleSessionName { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para> Used to determine how long sessions vended using this profile are valid for. See
        /// the <c>Expiration</c> section of the <a href="https://docs.aws.amazon.com/rolesanywhere/latest/userguide/authentication-create-session.html#credentials-object">CreateSession
        /// API documentation</a> page for more details. In requests, if this value is not provided,
        /// the default value will be 3600. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter ManagedPolicyArn
        /// <summary>
        /// <para>
        /// <para>A list of managed policy ARNs that apply to the vended session credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedPolicyArns")]
        public System.String[] ManagedPolicyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the profile.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>A list of IAM roles that this profile can assume in a temporary credential request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoleArns")]
        public System.String[] RoleArn { get; set; }
        #endregion
        
        #region Parameter SessionPolicy
        /// <summary>
        /// <para>
        /// <para>A session policy that applies to the trust boundary of the vended session credentials.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Profile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Profile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProfileId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMRAProfile (UpdateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse, UpdateIAMRAProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptRoleSessionName = this.AcceptRoleSessionName;
            context.DurationSecond = this.DurationSecond;
            if (this.ManagedPolicyArn != null)
            {
                context.ManagedPolicyArn = new List<System.String>(this.ManagedPolicyArn);
            }
            context.Name = this.Name;
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RoleArn != null)
            {
                context.RoleArn = new List<System.String>(this.RoleArn);
            }
            context.SessionPolicy = this.SessionPolicy;
            
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
            var request = new Amazon.IAMRolesAnywhere.Model.UpdateProfileRequest();
            
            if (cmdletContext.AcceptRoleSessionName != null)
            {
                request.AcceptRoleSessionName = cmdletContext.AcceptRoleSessionName.Value;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.ManagedPolicyArn != null)
            {
                request.ManagedPolicyArns = cmdletContext.ManagedPolicyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArns = cmdletContext.RoleArn;
            }
            if (cmdletContext.SessionPolicy != null)
            {
                request.SessionPolicy = cmdletContext.SessionPolicy;
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
        
        private Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.UpdateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "UpdateProfile");
            try
            {
                #if DESKTOP
                return client.UpdateProfile(request);
                #elif CORECLR
                return client.UpdateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptRoleSessionName { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public List<System.String> ManagedPolicyArn { get; set; }
            public System.String Name { get; set; }
            public System.String ProfileId { get; set; }
            public List<System.String> RoleArn { get; set; }
            public System.String SessionPolicy { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse, UpdateIAMRAProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Profile;
        }
        
    }
}
