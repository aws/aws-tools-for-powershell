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
using Amazon.Wickr;
using Amazon.Wickr.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Updates the properties of an existing user in a Wickr network. This operation allows
    /// you to modify the user's name, password, security group membership, and invite code
    /// settings.
    /// 
    ///  <note><para><c>codeValidation</c>, <c>inviteCode</c>, and <c>inviteCodeTtl</c> are restricted
    /// to networks under preview only.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "WICUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.UpdateUserResponse")]
    [AWSCmdlet("Calls the AWS Wickr Admin API UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.Wickr.Model.UpdateUserResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.UpdateUserResponse",
        "This cmdlet returns an Amazon.Wickr.Model.UpdateUserResponse object containing multiple properties."
    )]
    public partial class UpdateWICUserCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UserDetails_CodeValidation
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can be verified through a custom invite code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UserDetails_CodeValidation { get; set; }
        #endregion
        
        #region Parameter UserDetails_FirstName
        /// <summary>
        /// <para>
        /// <para>The new first name for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_FirstName { get; set; }
        #endregion
        
        #region Parameter UserDetails_InviteCode
        /// <summary>
        /// <para>
        /// <para>A new custom invite code for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_InviteCode { get; set; }
        #endregion
        
        #region Parameter UserDetails_InviteCodeTtl
        /// <summary>
        /// <para>
        /// <para>The new time-to-live for the invite code in days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UserDetails_InviteCodeTtl { get; set; }
        #endregion
        
        #region Parameter UserDetails_LastName
        /// <summary>
        /// <para>
        /// <para>The new last name for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_LastName { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network containing the user to update.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter UserDetails_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The updated list of security group IDs to which the user should belong.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserDetails_SecurityGroupIds")]
        public System.String[] UserDetails_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the user to update.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserDetails_Username
        /// <summary>
        /// <para>
        /// <para>The new username or email address for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.UpdateUserResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.UpdateUserResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WICUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.UpdateUserResponse, UpdateWICUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserDetails_CodeValidation = this.UserDetails_CodeValidation;
            context.UserDetails_FirstName = this.UserDetails_FirstName;
            context.UserDetails_InviteCode = this.UserDetails_InviteCode;
            context.UserDetails_InviteCodeTtl = this.UserDetails_InviteCodeTtl;
            context.UserDetails_LastName = this.UserDetails_LastName;
            if (this.UserDetails_SecurityGroupId != null)
            {
                context.UserDetails_SecurityGroupId = new List<System.String>(this.UserDetails_SecurityGroupId);
            }
            context.UserDetails_Username = this.UserDetails_Username;
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Wickr.Model.UpdateUserRequest();
            
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            
             // populate UserDetails
            var requestUserDetailsIsNull = true;
            request.UserDetails = new Amazon.Wickr.Model.UpdateUserDetails();
            System.Boolean? requestUserDetails_userDetails_CodeValidation = null;
            if (cmdletContext.UserDetails_CodeValidation != null)
            {
                requestUserDetails_userDetails_CodeValidation = cmdletContext.UserDetails_CodeValidation.Value;
            }
            if (requestUserDetails_userDetails_CodeValidation != null)
            {
                request.UserDetails.CodeValidation = requestUserDetails_userDetails_CodeValidation.Value;
                requestUserDetailsIsNull = false;
            }
            System.String requestUserDetails_userDetails_FirstName = null;
            if (cmdletContext.UserDetails_FirstName != null)
            {
                requestUserDetails_userDetails_FirstName = cmdletContext.UserDetails_FirstName;
            }
            if (requestUserDetails_userDetails_FirstName != null)
            {
                request.UserDetails.FirstName = requestUserDetails_userDetails_FirstName;
                requestUserDetailsIsNull = false;
            }
            System.String requestUserDetails_userDetails_InviteCode = null;
            if (cmdletContext.UserDetails_InviteCode != null)
            {
                requestUserDetails_userDetails_InviteCode = cmdletContext.UserDetails_InviteCode;
            }
            if (requestUserDetails_userDetails_InviteCode != null)
            {
                request.UserDetails.InviteCode = requestUserDetails_userDetails_InviteCode;
                requestUserDetailsIsNull = false;
            }
            System.Int32? requestUserDetails_userDetails_InviteCodeTtl = null;
            if (cmdletContext.UserDetails_InviteCodeTtl != null)
            {
                requestUserDetails_userDetails_InviteCodeTtl = cmdletContext.UserDetails_InviteCodeTtl.Value;
            }
            if (requestUserDetails_userDetails_InviteCodeTtl != null)
            {
                request.UserDetails.InviteCodeTtl = requestUserDetails_userDetails_InviteCodeTtl.Value;
                requestUserDetailsIsNull = false;
            }
            System.String requestUserDetails_userDetails_LastName = null;
            if (cmdletContext.UserDetails_LastName != null)
            {
                requestUserDetails_userDetails_LastName = cmdletContext.UserDetails_LastName;
            }
            if (requestUserDetails_userDetails_LastName != null)
            {
                request.UserDetails.LastName = requestUserDetails_userDetails_LastName;
                requestUserDetailsIsNull = false;
            }
            List<System.String> requestUserDetails_userDetails_SecurityGroupId = null;
            if (cmdletContext.UserDetails_SecurityGroupId != null)
            {
                requestUserDetails_userDetails_SecurityGroupId = cmdletContext.UserDetails_SecurityGroupId;
            }
            if (requestUserDetails_userDetails_SecurityGroupId != null)
            {
                request.UserDetails.SecurityGroupIds = requestUserDetails_userDetails_SecurityGroupId;
                requestUserDetailsIsNull = false;
            }
            System.String requestUserDetails_userDetails_Username = null;
            if (cmdletContext.UserDetails_Username != null)
            {
                requestUserDetails_userDetails_Username = cmdletContext.UserDetails_Username;
            }
            if (requestUserDetails_userDetails_Username != null)
            {
                request.UserDetails.Username = requestUserDetails_userDetails_Username;
                requestUserDetailsIsNull = false;
            }
             // determine if request.UserDetails should be set to null
            if (requestUserDetailsIsNull)
            {
                request.UserDetails = null;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.Wickr.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "UpdateUser");
            try
            {
                return client.UpdateUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NetworkId { get; set; }
            public System.Boolean? UserDetails_CodeValidation { get; set; }
            public System.String UserDetails_FirstName { get; set; }
            public System.String UserDetails_InviteCode { get; set; }
            public System.Int32? UserDetails_InviteCodeTtl { get; set; }
            public System.String UserDetails_LastName { get; set; }
            public List<System.String> UserDetails_SecurityGroupId { get; set; }
            public System.String UserDetails_Username { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.Wickr.Model.UpdateUserResponse, UpdateWICUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
