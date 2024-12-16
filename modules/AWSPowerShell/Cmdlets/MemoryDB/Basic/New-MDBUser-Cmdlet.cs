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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Creates a MemoryDB user. For more information, see <a href="https://docs.aws.amazon.com/MemoryDB/latest/devguide/clusters.acls.html">Authenticating
    /// users with Access Contol Lists (ACLs)</a>.
    /// </summary>
    [Cmdlet("New", "MDBUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.User")]
    [AWSCmdlet("Calls the Amazon MemoryDB CreateUser API operation.", Operation = new[] {"CreateUser"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.CreateUserResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.User or Amazon.MemoryDB.Model.CreateUserResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.User object.",
        "The service call response (type Amazon.MemoryDB.Model.CreateUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMDBUserCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessString
        /// <summary>
        /// <para>
        /// <para>Access permissions string used for this user.</para>
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
        public System.String AccessString { get; set; }
        #endregion
        
        #region Parameter AuthenticationMode_Password
        /// <summary>
        /// <para>
        /// <para>The password(s) used for authentication</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationMode_Passwords")]
        public System.String[] AuthenticationMode_Password { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MemoryDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AuthenticationMode_Type
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user requires a password to authenticate. All newly-created
        /// users require a password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MemoryDB.InputAuthenticationType")]
        public Amazon.MemoryDB.InputAuthenticationType AuthenticationMode_Type { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the user. This value must be unique as it also serves as the user identifier.</para>
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
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'User'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.CreateUserResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.CreateUserResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MDBUser (CreateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.CreateUserResponse, NewMDBUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessString = this.AccessString;
            #if MODULAR
            if (this.AccessString == null && ParameterWasBound(nameof(this.AccessString)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthenticationMode_Password != null)
            {
                context.AuthenticationMode_Password = new List<System.String>(this.AuthenticationMode_Password);
            }
            context.AuthenticationMode_Type = this.AuthenticationMode_Type;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MemoryDB.Model.Tag>(this.Tag);
            }
            context.UserName = this.UserName;
            #if MODULAR
            if (this.UserName == null && ParameterWasBound(nameof(this.UserName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MemoryDB.Model.CreateUserRequest();
            
            if (cmdletContext.AccessString != null)
            {
                request.AccessString = cmdletContext.AccessString;
            }
            
             // populate AuthenticationMode
            var requestAuthenticationModeIsNull = true;
            request.AuthenticationMode = new Amazon.MemoryDB.Model.AuthenticationMode();
            List<System.String> requestAuthenticationMode_authenticationMode_Password = null;
            if (cmdletContext.AuthenticationMode_Password != null)
            {
                requestAuthenticationMode_authenticationMode_Password = cmdletContext.AuthenticationMode_Password;
            }
            if (requestAuthenticationMode_authenticationMode_Password != null)
            {
                request.AuthenticationMode.Passwords = requestAuthenticationMode_authenticationMode_Password;
                requestAuthenticationModeIsNull = false;
            }
            Amazon.MemoryDB.InputAuthenticationType requestAuthenticationMode_authenticationMode_Type = null;
            if (cmdletContext.AuthenticationMode_Type != null)
            {
                requestAuthenticationMode_authenticationMode_Type = cmdletContext.AuthenticationMode_Type;
            }
            if (requestAuthenticationMode_authenticationMode_Type != null)
            {
                request.AuthenticationMode.Type = requestAuthenticationMode_authenticationMode_Type;
                requestAuthenticationModeIsNull = false;
            }
             // determine if request.AuthenticationMode should be set to null
            if (requestAuthenticationModeIsNull)
            {
                request.AuthenticationMode = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
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
        
        private Amazon.MemoryDB.Model.CreateUserResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "CreateUser");
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
            public System.String AccessString { get; set; }
            public List<System.String> AuthenticationMode_Password { get; set; }
            public Amazon.MemoryDB.InputAuthenticationType AuthenticationMode_Type { get; set; }
            public List<Amazon.MemoryDB.Model.Tag> Tag { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.MemoryDB.Model.CreateUserResponse, NewMDBUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.User;
        }
        
    }
}
