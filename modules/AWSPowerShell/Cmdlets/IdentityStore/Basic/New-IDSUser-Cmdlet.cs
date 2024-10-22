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
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// Creates a user within the specified identity store.
    /// </summary>
    [Cmdlet("New", "IDSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity Store CreateUser API operation.", Operation = new[] {"CreateUser"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.CreateUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityStore.Model.CreateUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityStore.Model.CreateUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIDSUserCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>A list of <c>Address</c> objects containing addresses associated with the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Addresses")]
        public Amazon.IdentityStore.Model.Address[] Address { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A string containing the name of the user. This value is typically formatted for display
        /// when the user is referenced. For example, "John Doe." </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>A list of <c>Email</c> objects containing email addresses associated with the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Emails")]
        public Amazon.IdentityStore.Model.Email[] Email { get; set; }
        #endregion
        
        #region Parameter Name_FamilyName
        /// <summary>
        /// <para>
        /// <para>The family name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_FamilyName { get; set; }
        #endregion
        
        #region Parameter Name_Formatted
        /// <summary>
        /// <para>
        /// <para>A string containing a formatted version of the name for display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_Formatted { get; set; }
        #endregion
        
        #region Parameter Name_GivenName
        /// <summary>
        /// <para>
        /// <para>The given name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_GivenName { get; set; }
        #endregion
        
        #region Parameter Name_HonorificPrefix
        /// <summary>
        /// <para>
        /// <para>The honorific prefix of the user. For example, "Dr."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_HonorificPrefix { get; set; }
        #endregion
        
        #region Parameter Name_HonorificSuffix
        /// <summary>
        /// <para>
        /// <para>The honorific suffix of the user. For example, "M.D."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_HonorificSuffix { get; set; }
        #endregion
        
        #region Parameter IdentityStoreId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier for the identity store.</para>
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
        public System.String IdentityStoreId { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>A string containing the geographical region or location of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Name_MiddleName
        /// <summary>
        /// <para>
        /// <para>The middle name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name_MiddleName { get; set; }
        #endregion
        
        #region Parameter NickName
        /// <summary>
        /// <para>
        /// <para>A string containing an alternate name for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NickName { get; set; }
        #endregion
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>A list of <c>PhoneNumber</c> objects containing phone numbers associated with the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PhoneNumbers")]
        public Amazon.IdentityStore.Model.PhoneNumber[] PhoneNumber { get; set; }
        #endregion
        
        #region Parameter PreferredLanguage
        /// <summary>
        /// <para>
        /// <para>A string containing the preferred language of the user. For example, "American English"
        /// or "en-us."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredLanguage { get; set; }
        #endregion
        
        #region Parameter ProfileUrl
        /// <summary>
        /// <para>
        /// <para>A string containing a URL that might be associated with the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileUrl { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>A string containing the time zone of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A string containing the title of the user. Possible values are left unspecified. The
        /// value can vary based on your specific use case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>A unique string used to identify the user. The length limit is 128 characters. This
        /// value can consist of letters, accented characters, symbols, numbers, and punctuation.
        /// This value is specified at the time the user is created and stored as an attribute
        /// of the user object in the identity store. <c>Administrator</c> and <c>AWSAdministrators</c>
        /// are reserved names and can't be used for users or groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserType
        /// <summary>
        /// <para>
        /// <para>A string indicating the type of user. Possible values are left unspecified. The value
        /// can vary based on your specific use case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.CreateUserResponse).
        /// Specifying the name of a property of type Amazon.IdentityStore.Model.CreateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IDSUser (CreateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.CreateUserResponse, NewIDSUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Address != null)
            {
                context.Address = new List<Amazon.IdentityStore.Model.Address>(this.Address);
            }
            context.DisplayName = this.DisplayName;
            if (this.Email != null)
            {
                context.Email = new List<Amazon.IdentityStore.Model.Email>(this.Email);
            }
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            context.Name_FamilyName = this.Name_FamilyName;
            context.Name_Formatted = this.Name_Formatted;
            context.Name_GivenName = this.Name_GivenName;
            context.Name_HonorificPrefix = this.Name_HonorificPrefix;
            context.Name_HonorificSuffix = this.Name_HonorificSuffix;
            context.Name_MiddleName = this.Name_MiddleName;
            context.NickName = this.NickName;
            if (this.PhoneNumber != null)
            {
                context.PhoneNumber = new List<Amazon.IdentityStore.Model.PhoneNumber>(this.PhoneNumber);
            }
            context.PreferredLanguage = this.PreferredLanguage;
            context.ProfileUrl = this.ProfileUrl;
            context.Timezone = this.Timezone;
            context.Title = this.Title;
            context.UserName = this.UserName;
            context.UserType = this.UserType;
            
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
            var request = new Amazon.IdentityStore.Model.CreateUserRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Addresses = cmdletContext.Address;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Email != null)
            {
                request.Emails = cmdletContext.Email;
            }
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            
             // populate Name
            var requestNameIsNull = true;
            request.Name = new Amazon.IdentityStore.Model.Name();
            System.String requestName_name_FamilyName = null;
            if (cmdletContext.Name_FamilyName != null)
            {
                requestName_name_FamilyName = cmdletContext.Name_FamilyName;
            }
            if (requestName_name_FamilyName != null)
            {
                request.Name.FamilyName = requestName_name_FamilyName;
                requestNameIsNull = false;
            }
            System.String requestName_name_Formatted = null;
            if (cmdletContext.Name_Formatted != null)
            {
                requestName_name_Formatted = cmdletContext.Name_Formatted;
            }
            if (requestName_name_Formatted != null)
            {
                request.Name.Formatted = requestName_name_Formatted;
                requestNameIsNull = false;
            }
            System.String requestName_name_GivenName = null;
            if (cmdletContext.Name_GivenName != null)
            {
                requestName_name_GivenName = cmdletContext.Name_GivenName;
            }
            if (requestName_name_GivenName != null)
            {
                request.Name.GivenName = requestName_name_GivenName;
                requestNameIsNull = false;
            }
            System.String requestName_name_HonorificPrefix = null;
            if (cmdletContext.Name_HonorificPrefix != null)
            {
                requestName_name_HonorificPrefix = cmdletContext.Name_HonorificPrefix;
            }
            if (requestName_name_HonorificPrefix != null)
            {
                request.Name.HonorificPrefix = requestName_name_HonorificPrefix;
                requestNameIsNull = false;
            }
            System.String requestName_name_HonorificSuffix = null;
            if (cmdletContext.Name_HonorificSuffix != null)
            {
                requestName_name_HonorificSuffix = cmdletContext.Name_HonorificSuffix;
            }
            if (requestName_name_HonorificSuffix != null)
            {
                request.Name.HonorificSuffix = requestName_name_HonorificSuffix;
                requestNameIsNull = false;
            }
            System.String requestName_name_MiddleName = null;
            if (cmdletContext.Name_MiddleName != null)
            {
                requestName_name_MiddleName = cmdletContext.Name_MiddleName;
            }
            if (requestName_name_MiddleName != null)
            {
                request.Name.MiddleName = requestName_name_MiddleName;
                requestNameIsNull = false;
            }
             // determine if request.Name should be set to null
            if (requestNameIsNull)
            {
                request.Name = null;
            }
            if (cmdletContext.NickName != null)
            {
                request.NickName = cmdletContext.NickName;
            }
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumbers = cmdletContext.PhoneNumber;
            }
            if (cmdletContext.PreferredLanguage != null)
            {
                request.PreferredLanguage = cmdletContext.PreferredLanguage;
            }
            if (cmdletContext.ProfileUrl != null)
            {
                request.ProfileUrl = cmdletContext.ProfileUrl;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserType != null)
            {
                request.UserType = cmdletContext.UserType;
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
        
        private Amazon.IdentityStore.Model.CreateUserResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "CreateUser");
            try
            {
                #if DESKTOP
                return client.CreateUser(request);
                #elif CORECLR
                return client.CreateUserAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IdentityStore.Model.Address> Address { get; set; }
            public System.String DisplayName { get; set; }
            public List<Amazon.IdentityStore.Model.Email> Email { get; set; }
            public System.String IdentityStoreId { get; set; }
            public System.String Locale { get; set; }
            public System.String Name_FamilyName { get; set; }
            public System.String Name_Formatted { get; set; }
            public System.String Name_GivenName { get; set; }
            public System.String Name_HonorificPrefix { get; set; }
            public System.String Name_HonorificSuffix { get; set; }
            public System.String Name_MiddleName { get; set; }
            public System.String NickName { get; set; }
            public List<Amazon.IdentityStore.Model.PhoneNumber> PhoneNumber { get; set; }
            public System.String PreferredLanguage { get; set; }
            public System.String ProfileUrl { get; set; }
            public System.String Timezone { get; set; }
            public System.String Title { get; set; }
            public System.String UserName { get; set; }
            public System.String UserType { get; set; }
            public System.Func<Amazon.IdentityStore.Model.CreateUserResponse, NewIDSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserId;
        }
        
    }
}
