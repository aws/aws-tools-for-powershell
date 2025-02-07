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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Updates data for the user. To have the latest information, it must be preceded by
    /// a <a>DescribeUser</a> call. The dataset in the request should be the one expected
    /// when performing another <c>DescribeUser</c> call.
    /// </summary>
    [Cmdlet("Update", "WMUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.WorkMail.Model.UpdateUserResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.UpdateUserResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.UpdateUserResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateWMUserCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter City
        /// <summary>
        /// <para>
        /// <para>Updates the user's city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String City { get; set; }
        #endregion
        
        #region Parameter Company
        /// <summary>
        /// <para>
        /// <para>Updates the user's company.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Company { get; set; }
        #endregion
        
        #region Parameter Country
        /// <summary>
        /// <para>
        /// <para>Updates the user's country.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Country { get; set; }
        #endregion
        
        #region Parameter Department
        /// <summary>
        /// <para>
        /// <para>Updates the user's department.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Department { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>Updates the display name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter FirstName
        /// <summary>
        /// <para>
        /// <para>Updates the user's first name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirstName { get; set; }
        #endregion
        
        #region Parameter HiddenFromGlobalAddressList
        /// <summary>
        /// <para>
        /// <para>If enabled, the user is hidden from the global address list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HiddenFromGlobalAddressList { get; set; }
        #endregion
        
        #region Parameter IdentityProviderUserId
        /// <summary>
        /// <para>
        /// <para>User ID from the IAM Identity Center. If this parameter is empty it will be updated
        /// automatically when the user logs in for the first time to the mailbox associated with
        /// WorkMail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderUserId { get; set; }
        #endregion
        
        #region Parameter Initial
        /// <summary>
        /// <para>
        /// <para>Updates the user's initials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Initials")]
        public System.String Initial { get; set; }
        #endregion
        
        #region Parameter JobTitle
        /// <summary>
        /// <para>
        /// <para>Updates the user's job title.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTitle { get; set; }
        #endregion
        
        #region Parameter LastName
        /// <summary>
        /// <para>
        /// <para>Updates the user's last name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastName { get; set; }
        #endregion
        
        #region Parameter Office
        /// <summary>
        /// <para>
        /// <para>Updates the user's office.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Office { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the organization under which the user exists.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>Updates the user role.</para><para>You cannot pass <i>SYSTEM_USER</i> or <i>RESOURCE</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkMail.UserRole")]
        public Amazon.WorkMail.UserRole Role { get; set; }
        #endregion
        
        #region Parameter Street
        /// <summary>
        /// <para>
        /// <para>Updates the user's street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Street { get; set; }
        #endregion
        
        #region Parameter Telephone
        /// <summary>
        /// <para>
        /// <para>Updates the user's contact details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Telephone { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier for the user to be updated.</para><para>The identifier can be the <i>UserId</i>, <i>Username</i>, or <i>email</i>. The following
        /// identity formats are available:</para><ul><li><para>User ID: 12345678-1234-1234-1234-123456789012 or S-1-1-12-1234567890-123456789-123456789-1234</para></li><li><para>Email address: user@domain.tld</para></li><li><para>User name: user</para></li></ul>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter ZipCode
        /// <summary>
        /// <para>
        /// <para>Updates the user's zip code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ZipCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.UpdateUserResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WMUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.UpdateUserResponse, UpdateWMUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.City = this.City;
            context.Company = this.Company;
            context.Country = this.Country;
            context.Department = this.Department;
            context.DisplayName = this.DisplayName;
            context.FirstName = this.FirstName;
            context.HiddenFromGlobalAddressList = this.HiddenFromGlobalAddressList;
            context.IdentityProviderUserId = this.IdentityProviderUserId;
            context.Initial = this.Initial;
            context.JobTitle = this.JobTitle;
            context.LastName = this.LastName;
            context.Office = this.Office;
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Role = this.Role;
            context.Street = this.Street;
            context.Telephone = this.Telephone;
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ZipCode = this.ZipCode;
            
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
            var request = new Amazon.WorkMail.Model.UpdateUserRequest();
            
            if (cmdletContext.City != null)
            {
                request.City = cmdletContext.City;
            }
            if (cmdletContext.Company != null)
            {
                request.Company = cmdletContext.Company;
            }
            if (cmdletContext.Country != null)
            {
                request.Country = cmdletContext.Country;
            }
            if (cmdletContext.Department != null)
            {
                request.Department = cmdletContext.Department;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FirstName != null)
            {
                request.FirstName = cmdletContext.FirstName;
            }
            if (cmdletContext.HiddenFromGlobalAddressList != null)
            {
                request.HiddenFromGlobalAddressList = cmdletContext.HiddenFromGlobalAddressList.Value;
            }
            if (cmdletContext.IdentityProviderUserId != null)
            {
                request.IdentityProviderUserId = cmdletContext.IdentityProviderUserId;
            }
            if (cmdletContext.Initial != null)
            {
                request.Initials = cmdletContext.Initial;
            }
            if (cmdletContext.JobTitle != null)
            {
                request.JobTitle = cmdletContext.JobTitle;
            }
            if (cmdletContext.LastName != null)
            {
                request.LastName = cmdletContext.LastName;
            }
            if (cmdletContext.Office != null)
            {
                request.Office = cmdletContext.Office;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Street != null)
            {
                request.Street = cmdletContext.Street;
            }
            if (cmdletContext.Telephone != null)
            {
                request.Telephone = cmdletContext.Telephone;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.ZipCode != null)
            {
                request.ZipCode = cmdletContext.ZipCode;
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
        
        private Amazon.WorkMail.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "UpdateUser");
            try
            {
                #if DESKTOP
                return client.UpdateUser(request);
                #elif CORECLR
                return client.UpdateUserAsync(request).GetAwaiter().GetResult();
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
            public System.String City { get; set; }
            public System.String Company { get; set; }
            public System.String Country { get; set; }
            public System.String Department { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FirstName { get; set; }
            public System.Boolean? HiddenFromGlobalAddressList { get; set; }
            public System.String IdentityProviderUserId { get; set; }
            public System.String Initial { get; set; }
            public System.String JobTitle { get; set; }
            public System.String LastName { get; set; }
            public System.String Office { get; set; }
            public System.String OrganizationId { get; set; }
            public Amazon.WorkMail.UserRole Role { get; set; }
            public System.String Street { get; set; }
            public System.String Telephone { get; set; }
            public System.String UserId { get; set; }
            public System.String ZipCode { get; set; }
            public System.Func<Amazon.WorkMail.Model.UpdateUserResponse, UpdateWMUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
