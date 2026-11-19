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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

#pragma warning disable CS0618, CS0612
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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>The alias for the profile.</para><para>You can use this parameter in the following ways:</para><ul><li><para>To set or change the alias, specify the new alias name. After the change, the previous
        /// alias ARN no longer identifies the resource. You can then assign the previous alias
        /// to another resource of the same type. A change can take a short time to take effect
        /// for requests that use an alias ARN.</para></li><li><para>To remove the alias, specify an empty string.</para></li><li><para>To keep the current alias, omit this parameter.</para></li></ul><para>An alias name contains 1 to 256 characters. It must begin with a letter (A-Z or a-z).
        /// It can contain only letters (A-Z and a-z), numbers (0-9), underscores (_), hyphens
        /// (-), and forward slashes (/). A forward slash can appear only between two other characters,
        /// so an alias name can't end with a forward slash or contain two in a row. Alias names
        /// that begin with <c>aws/</c>, in any combination of uppercase and lowercase letters,
        /// are reserved. Alias names are case sensitive.</para><para>The alias name must be unique among resources of the same type in your account and
        /// Region. If another resource of the same type already has the alias, the request fails
        /// with a <c>ValidationException</c>. An invalid or reserved alias name also causes a
        /// <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasName { get; set; }
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
        /// <para>A list of managed policy ARNs that apply to the vended session credentials. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The profile to act on. You can specify one of the following:</para><ul><li><para>The profile ID.</para></li><li><para>The profile ARN.</para></li><li><para>The alias ARN of the profile.</para></li></ul><para>An ARN must be for a profile in your account and Region.</para>
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
        /// <para>A list of IAM roles that this profile can assume in a temporary credential request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter TipConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>Specifies whether you use trusted identity propagation (TIP) for the profile. This
        /// field supports the following values:</para><ul><li><para><c>ENABLED</c> – Sessions from the profile include the <c>aws:OriginIdentity</c>
        /// condition keys.</para></li><li><para><c>DISABLED</c> – Sessions from the profile don't include these keys.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IAMRolesAnywhere.TipStatus")]
        public Amazon.IAMRolesAnywhere.TipStatus TipConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter TipConfiguration_SubjectSource
        /// <summary>
        /// <para>
        /// <para>The certificate field whose value becomes the subject, <c>aws:OriginIdentity/Subject</c>.
        /// This field supports the following values:</para><ul><li><para><c>x509Subject/CN</c> (default) – The common name (CN) in the certificate's Subject.</para></li><li><para><c>x509SAN/URI</c> – The first URI in the certificate's Subject Alternative Name
        /// (SAN) extension.</para></li></ul><para>The profile's attribute mappings must include a rule for this field, and the default
        /// attribute mappings include one for each value. If the certificate has no value for
        /// the field, <c>CreateSession</c> denies the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IAMRolesAnywhere.TipSubjectSource")]
        public Amazon.IAMRolesAnywhere.TipSubjectSource TipConfiguration_SubjectSource { get; set; }
        #endregion
        
        #region Parameter TipConfiguration_SubjectType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the certificates for the profile identify workloads or people. This
        /// field supports the following values:</para><ul><li><para><c>workload</c> – The certificates identify workloads.</para></li><li><para><c>user</c> – The certificates identify people.</para></li></ul><para>Sessions include the value in <c>aws:OriginIdentity/SubjectType</c>. If you omit this
        /// field, sessions don't include that key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IAMRolesAnywhere.TipSubjectType")]
        public Amazon.IAMRolesAnywhere.TipSubjectType TipConfiguration_SubjectType { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMRAProfile (UpdateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse, UpdateIAMRAProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptRoleSessionName = this.AcceptRoleSessionName;
            context.AliasName = this.AliasName;
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
            context.TipConfiguration_Status = this.TipConfiguration_Status;
            context.TipConfiguration_SubjectSource = this.TipConfiguration_SubjectSource;
            context.TipConfiguration_SubjectType = this.TipConfiguration_SubjectType;
            
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
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
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
            
             // populate TipConfiguration
            var requestTipConfigurationIsNull = true;
            request.TipConfiguration = new Amazon.IAMRolesAnywhere.Model.TipConfiguration();
            Amazon.IAMRolesAnywhere.TipStatus requestTipConfiguration_tipConfiguration_Status = null;
            if (cmdletContext.TipConfiguration_Status != null)
            {
                requestTipConfiguration_tipConfiguration_Status = cmdletContext.TipConfiguration_Status;
            }
            if (requestTipConfiguration_tipConfiguration_Status != null)
            {
                request.TipConfiguration.Status = requestTipConfiguration_tipConfiguration_Status;
                requestTipConfigurationIsNull = false;
            }
            Amazon.IAMRolesAnywhere.TipSubjectSource requestTipConfiguration_tipConfiguration_SubjectSource = null;
            if (cmdletContext.TipConfiguration_SubjectSource != null)
            {
                requestTipConfiguration_tipConfiguration_SubjectSource = cmdletContext.TipConfiguration_SubjectSource;
            }
            if (requestTipConfiguration_tipConfiguration_SubjectSource != null)
            {
                request.TipConfiguration.SubjectSource = requestTipConfiguration_tipConfiguration_SubjectSource;
                requestTipConfigurationIsNull = false;
            }
            Amazon.IAMRolesAnywhere.TipSubjectType requestTipConfiguration_tipConfiguration_SubjectType = null;
            if (cmdletContext.TipConfiguration_SubjectType != null)
            {
                requestTipConfiguration_tipConfiguration_SubjectType = cmdletContext.TipConfiguration_SubjectType;
            }
            if (requestTipConfiguration_tipConfiguration_SubjectType != null)
            {
                request.TipConfiguration.SubjectType = requestTipConfiguration_tipConfiguration_SubjectType;
                requestTipConfigurationIsNull = false;
            }
             // determine if request.TipConfiguration should be set to null
            if (requestTipConfigurationIsNull)
            {
                request.TipConfiguration = null;
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
                return client.UpdateProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasName { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public List<System.String> ManagedPolicyArn { get; set; }
            public System.String Name { get; set; }
            public System.String ProfileId { get; set; }
            public List<System.String> RoleArn { get; set; }
            public System.String SessionPolicy { get; set; }
            public Amazon.IAMRolesAnywhere.TipStatus TipConfiguration_Status { get; set; }
            public Amazon.IAMRolesAnywhere.TipSubjectSource TipConfiguration_SubjectSource { get; set; }
            public Amazon.IAMRolesAnywhere.TipSubjectType TipConfiguration_SubjectType { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.UpdateProfileResponse, UpdateIAMRAProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Profile;
        }
        
    }
}
