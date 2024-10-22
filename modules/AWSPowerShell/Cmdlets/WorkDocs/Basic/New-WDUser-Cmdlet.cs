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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Creates a user in a Simple AD or Microsoft AD directory. The status of a newly created
    /// user is "ACTIVE". New users can access Amazon WorkDocs.
    /// </summary>
    [Cmdlet("New", "WDUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.User")]
    [AWSCmdlet("Calls the Amazon WorkDocs CreateUser API operation.", Operation = new[] {"CreateUser"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.CreateUserResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.User or Amazon.WorkDocs.Model.CreateUserResponse",
        "This cmdlet returns an Amazon.WorkDocs.Model.User object.",
        "The service call response (type Amazon.WorkDocs.Model.CreateUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWDUserCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter GivenName
        /// <summary>
        /// <para>
        /// <para>The given name of the user.</para>
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
        public System.String GivenName { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The ID of the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password of the user.</para>
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
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter StorageRule_StorageAllocatedInByte
        /// <summary>
        /// <para>
        /// <para>The amount of storage allocated, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageRule_StorageAllocatedInBytes")]
        public System.Int64? StorageRule_StorageAllocatedInByte { get; set; }
        #endregion
        
        #region Parameter StorageRule_StorageType
        /// <summary>
        /// <para>
        /// <para>The type of storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkDocs.StorageType")]
        public Amazon.WorkDocs.StorageType StorageRule_StorageType { get; set; }
        #endregion
        
        #region Parameter Surname
        /// <summary>
        /// <para>
        /// <para>The surname of the user.</para>
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
        public System.String Surname { get; set; }
        #endregion
        
        #region Parameter TimeZoneId
        /// <summary>
        /// <para>
        /// <para>The time zone ID of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeZoneId { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The login name of the user.</para>
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
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'User'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.CreateUserResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.CreateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "User";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GivenName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WDUser (CreateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.CreateUserResponse, NewWDUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthenticationToken = this.AuthenticationToken;
            context.EmailAddress = this.EmailAddress;
            context.GivenName = this.GivenName;
            #if MODULAR
            if (this.GivenName == null && ParameterWasBound(nameof(this.GivenName)))
            {
                WriteWarning("You are passing $null as a value for parameter GivenName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationId = this.OrganizationId;
            context.Password = this.Password;
            #if MODULAR
            if (this.Password == null && ParameterWasBound(nameof(this.Password)))
            {
                WriteWarning("You are passing $null as a value for parameter Password which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageRule_StorageAllocatedInByte = this.StorageRule_StorageAllocatedInByte;
            context.StorageRule_StorageType = this.StorageRule_StorageType;
            context.Surname = this.Surname;
            #if MODULAR
            if (this.Surname == null && ParameterWasBound(nameof(this.Surname)))
            {
                WriteWarning("You are passing $null as a value for parameter Surname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeZoneId = this.TimeZoneId;
            context.Username = this.Username;
            #if MODULAR
            if (this.Username == null && ParameterWasBound(nameof(this.Username)))
            {
                WriteWarning("You are passing $null as a value for parameter Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkDocs.Model.CreateUserRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.GivenName != null)
            {
                request.GivenName = cmdletContext.GivenName;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            
             // populate StorageRule
            var requestStorageRuleIsNull = true;
            request.StorageRule = new Amazon.WorkDocs.Model.StorageRuleType();
            System.Int64? requestStorageRule_storageRule_StorageAllocatedInByte = null;
            if (cmdletContext.StorageRule_StorageAllocatedInByte != null)
            {
                requestStorageRule_storageRule_StorageAllocatedInByte = cmdletContext.StorageRule_StorageAllocatedInByte.Value;
            }
            if (requestStorageRule_storageRule_StorageAllocatedInByte != null)
            {
                request.StorageRule.StorageAllocatedInBytes = requestStorageRule_storageRule_StorageAllocatedInByte.Value;
                requestStorageRuleIsNull = false;
            }
            Amazon.WorkDocs.StorageType requestStorageRule_storageRule_StorageType = null;
            if (cmdletContext.StorageRule_StorageType != null)
            {
                requestStorageRule_storageRule_StorageType = cmdletContext.StorageRule_StorageType;
            }
            if (requestStorageRule_storageRule_StorageType != null)
            {
                request.StorageRule.StorageType = requestStorageRule_storageRule_StorageType;
                requestStorageRuleIsNull = false;
            }
             // determine if request.StorageRule should be set to null
            if (requestStorageRuleIsNull)
            {
                request.StorageRule = null;
            }
            if (cmdletContext.Surname != null)
            {
                request.Surname = cmdletContext.Surname;
            }
            if (cmdletContext.TimeZoneId != null)
            {
                request.TimeZoneId = cmdletContext.TimeZoneId;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.WorkDocs.Model.CreateUserResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "CreateUser");
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
            public System.String AuthenticationToken { get; set; }
            public System.String EmailAddress { get; set; }
            public System.String GivenName { get; set; }
            public System.String OrganizationId { get; set; }
            public System.String Password { get; set; }
            public System.Int64? StorageRule_StorageAllocatedInByte { get; set; }
            public Amazon.WorkDocs.StorageType StorageRule_StorageType { get; set; }
            public System.String Surname { get; set; }
            public System.String TimeZoneId { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.WorkDocs.Model.CreateUserResponse, NewWDUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.User;
        }
        
    }
}
