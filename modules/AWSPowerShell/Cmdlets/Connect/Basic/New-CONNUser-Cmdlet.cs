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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a user account for the specified Amazon Connect instance.
    /// 
    ///  <important><para>
    /// Certain <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_UserIdentityInfo.html">UserIdentityInfo</a>
    /// parameters are required in some situations. For example, <c>Email</c> is required
    /// if you are using SAML for identity management. <c>FirstName</c> and <c>LastName</c>
    /// are required if you are using Amazon Connect or SAML for identity management.
    /// </para></important><para>
    /// For information about how to create users using the Amazon Connect admin website,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/user-management.html">Add
    /// Users</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CONNUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateUserResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateUser API operation.", Operation = new[] {"CreateUser"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateUserResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateUserResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateUserResponse object containing multiple properties."
    )]
    public partial class NewCONNUserCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectoryUserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user account in the directory used for identity management.
        /// If Amazon Connect cannot access the directory, you can specify this identifier to
        /// authenticate users. If you include the identifier, we assume that Amazon Connect cannot
        /// access the directory. Otherwise, the identity information is used to authenticate
        /// users from your directory.</para><para>This parameter is required if you are using an existing directory for identity management
        /// in Amazon Connect when Amazon Connect cannot access your directory to authenticate
        /// users. If you are using SAML for identity management and include this parameter, an
        /// error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DirectoryUserId { get; set; }
        #endregion
        
        #region Parameter HierarchyGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the hierarchy group for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HierarchyGroupId { get; set; }
        #endregion
        
        #region Parameter IdentityInfo
        /// <summary>
        /// <para>
        /// <para>The information about the identity of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Connect.Model.UserIdentityInfo IdentityInfo { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for the user account. A password is required if you are using Amazon
        /// Connect for identity management. Otherwise, it is an error to include a password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter PhoneConfig
        /// <summary>
        /// <para>
        /// <para>The phone settings for the user.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Connect.Model.UserPhoneConfig PhoneConfig { get; set; }
        #endregion
        
        #region Parameter RoutingProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the routing profile for the user.</para>
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
        public System.String RoutingProfileId { get; set; }
        #endregion
        
        #region Parameter SecurityProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the security profile for the user.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("SecurityProfileIds")]
        public System.String[] SecurityProfileId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// { "Tags": {"key1":"value1", "key2":"value2"} }.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name for the account. For instances not using SAML for identity management,
        /// the user name can include up to 20 characters. If you are using SAML for identity
        /// management, the user name can include up to 64 characters from [a-zA-Z0-9_-.\@]+.</para><para>Username can include @ only if used in an email format. For example:</para><ul><li><para>Correct: testuser</para></li><li><para>Correct: testuser@example.com</para></li><li><para>Incorrect: testuser@example</para></li></ul>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateUserResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateUserResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNUser (CreateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateUserResponse, NewCONNUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryUserId = this.DirectoryUserId;
            context.HierarchyGroupId = this.HierarchyGroupId;
            context.IdentityInfo = this.IdentityInfo;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Password = this.Password;
            context.PhoneConfig = this.PhoneConfig;
            #if MODULAR
            if (this.PhoneConfig == null && ParameterWasBound(nameof(this.PhoneConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoutingProfileId = this.RoutingProfileId;
            #if MODULAR
            if (this.RoutingProfileId == null && ParameterWasBound(nameof(this.RoutingProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SecurityProfileId != null)
            {
                context.SecurityProfileId = new List<System.String>(this.SecurityProfileId);
            }
            #if MODULAR
            if (this.SecurityProfileId == null && ParameterWasBound(nameof(this.SecurityProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            if (cmdletContext.SecurityProfileId != null)
            {
                request.SecurityProfileIds = cmdletContext.SecurityProfileId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Connect.Model.CreateUserResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateUser");
            try
            {
                return client.CreateUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> SecurityProfileId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.Connect.Model.CreateUserResponse, NewCONNUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
