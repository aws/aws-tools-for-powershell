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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a new user account in your Amazon Connect instance.
    /// </summary>
    [Cmdlet("New", "CONNUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateUserResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateUser API operation.", Operation = new[] {"CreateUser"})]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateUserResponse",
        "This cmdlet returns a Amazon.Connect.Model.CreateUserResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCONNUserCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryUserId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the user account in the directory service directory used
        /// for identity management. If Amazon Connect is unable to access the existing directory,
        /// you can use the <code>DirectoryUserId</code> to authenticate users. If you include
        /// the parameter, it is assumed that Amazon Connect cannot access the directory. If the
        /// parameter is not included, the <code>UserIdentityInfo</code> is used to authenticate
        /// users from your existing directory.</para><para>This parameter is required if you are using an existing directory for identity management
        /// in Amazon Connect when Amazon Connect cannot access your directory to authenticate
        /// users. If you are using SAML for identity management and include this parameter, an
        /// <code>InvalidRequestException</code> is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectoryUserId { get; set; }
        #endregion
        
        #region Parameter HierarchyGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the hierarchy group to assign to the user created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HierarchyGroupId { get; set; }
        #endregion
        
        #region Parameter IdentityInfo
        /// <summary>
        /// <para>
        /// <para>Information about the user, including email address, first name, and last name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Connect.Model.UserIdentityInfo IdentityInfo { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier for your Amazon Connect instance. To find the ID of your instance,
        /// open the AWS console and select Amazon Connect. Select the alias of the instance in
        /// the Instance alias column. The instance ID is displayed in the Overview section of
        /// your instance settings. For example, the instance ID is the set of characters at the
        /// end of the instance ARN, after instance/, such as 10a4c4eb-f57e-4d4c-b602-bf39176ced07.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for the user account to create. This is required if you are using Amazon
        /// Connect for identity management. If you are using SAML for identity management and
        /// include this parameter, an <code>InvalidRequestException</code> is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter PhoneConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the phone settings for the user, including <code>AfterContactWorkTimeLimit</code>,
        /// <code>AutoAccept</code>, <code>DeskPhoneNumber</code>, and <code>PhoneType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Connect.Model.UserPhoneConfig PhoneConfig { get; set; }
        #endregion
        
        #region Parameter RoutingProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the routing profile to assign to the user created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoutingProfileId { get; set; }
        #endregion
        
        #region Parameter SecurityProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the security profile to assign to the user created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityProfileIds")]
        public System.String[] SecurityProfileId { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name in Amazon Connect for the account to create. If you are using SAML for
        /// identity management in your Amazon Connect, the value for <code>Username</code> can
        /// include up to 64 characters from [a-zA-Z0-9_-.\@]+.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Username { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNUser (CreateUser)"))
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
            
            context.DirectoryUserId = this.DirectoryUserId;
            context.HierarchyGroupId = this.HierarchyGroupId;
            context.IdentityInfo = this.IdentityInfo;
            context.InstanceId = this.InstanceId;
            context.Password = this.Password;
            context.PhoneConfig = this.PhoneConfig;
            context.RoutingProfileId = this.RoutingProfileId;
            if (this.SecurityProfileId != null)
            {
                context.SecurityProfileIds = new List<System.String>(this.SecurityProfileId);
            }
            context.Username = this.Username;
            
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
            var request = new Amazon.Connect.Model.CreateUserRequest();
            
            if (cmdletContext.DirectoryUserId != null)
            {
                request.DirectoryUserId = cmdletContext.DirectoryUserId;
            }
            if (cmdletContext.HierarchyGroupId != null)
            {
                request.HierarchyGroupId = cmdletContext.HierarchyGroupId;
            }
            if (cmdletContext.IdentityInfo != null)
            {
                request.IdentityInfo = cmdletContext.IdentityInfo;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.PhoneConfig != null)
            {
                request.PhoneConfig = cmdletContext.PhoneConfig;
            }
            if (cmdletContext.RoutingProfileId != null)
            {
                request.RoutingProfileId = cmdletContext.RoutingProfileId;
            }
            if (cmdletContext.SecurityProfileIds != null)
            {
                request.SecurityProfileIds = cmdletContext.SecurityProfileIds;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Connect.Model.CreateUserResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateUser");
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
            public System.String DirectoryUserId { get; set; }
            public System.String HierarchyGroupId { get; set; }
            public Amazon.Connect.Model.UserIdentityInfo IdentityInfo { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Password { get; set; }
            public Amazon.Connect.Model.UserPhoneConfig PhoneConfig { get; set; }
            public System.String RoutingProfileId { get; set; }
            public List<System.String> SecurityProfileIds { get; set; }
            public System.String Username { get; set; }
        }
        
    }
}
