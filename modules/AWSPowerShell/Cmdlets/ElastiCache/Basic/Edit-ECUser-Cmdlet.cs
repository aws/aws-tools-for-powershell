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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Changes user password(s) and/or access string.
    /// </summary>
    [Cmdlet("Edit", "ECUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ModifyUserResponse")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyUser API operation.", Operation = new[] {"ModifyUser"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ModifyUserResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ModifyUserResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ModifyUserResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditECUserCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter AccessString
        /// <summary>
        /// <para>
        /// <para>Access permissions string used for this user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessString { get; set; }
        #endregion
        
        #region Parameter AppendAccessString
        /// <summary>
        /// <para>
        /// <para>Adds additional user permissions to the access string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppendAccessString { get; set; }
        #endregion
        
        #region Parameter NoPasswordRequired
        /// <summary>
        /// <para>
        /// <para>Indicates no password is required for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NoPasswordRequired { get; set; }
        #endregion
        
        #region Parameter AuthenticationMode_Password
        /// <summary>
        /// <para>
        /// <para>Specifies the passwords to use for authentication if <code>Type</code> is set to <code>password</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationMode_Passwords")]
        public System.String[] AuthenticationMode_Password { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The passwords belonging to the user. You are allowed up to two.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Passwords")]
        public System.String[] Password { get; set; }
        #endregion
        
        #region Parameter AuthenticationMode_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the authentication type. Possible options are IAM authentication, password
        /// and no password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.InputAuthenticationType")]
        public Amazon.ElastiCache.InputAuthenticationType AuthenticationMode_Type { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the user.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ModifyUserResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ModifyUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECUser (ModifyUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ModifyUserResponse, EditECUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessString = this.AccessString;
            context.AppendAccessString = this.AppendAccessString;
            if (this.AuthenticationMode_Password != null)
            {
                context.AuthenticationMode_Password = new List<System.String>(this.AuthenticationMode_Password);
            }
            context.AuthenticationMode_Type = this.AuthenticationMode_Type;
            context.NoPasswordRequired = this.NoPasswordRequired;
            if (this.Password != null)
            {
                context.Password = new List<System.String>(this.Password);
            }
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
            var request = new Amazon.ElastiCache.Model.ModifyUserRequest();
            
            if (cmdletContext.AccessString != null)
            {
                request.AccessString = cmdletContext.AccessString;
            }
            if (cmdletContext.AppendAccessString != null)
            {
                request.AppendAccessString = cmdletContext.AppendAccessString;
            }
            
             // populate AuthenticationMode
            var requestAuthenticationModeIsNull = true;
            request.AuthenticationMode = new Amazon.ElastiCache.Model.AuthenticationMode();
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
            Amazon.ElastiCache.InputAuthenticationType requestAuthenticationMode_authenticationMode_Type = null;
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
            if (cmdletContext.NoPasswordRequired != null)
            {
                request.NoPasswordRequired = cmdletContext.NoPasswordRequired.Value;
            }
            if (cmdletContext.Password != null)
            {
                request.Passwords = cmdletContext.Password;
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
        
        private Amazon.ElastiCache.Model.ModifyUserResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyUser");
            try
            {
                #if DESKTOP
                return client.ModifyUser(request);
                #elif CORECLR
                return client.ModifyUserAsync(request).GetAwaiter().GetResult();
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
            public System.String AppendAccessString { get; set; }
            public List<System.String> AuthenticationMode_Password { get; set; }
            public Amazon.ElastiCache.InputAuthenticationType AuthenticationMode_Type { get; set; }
            public System.Boolean? NoPasswordRequired { get; set; }
            public List<System.String> Password { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ModifyUserResponse, EditECUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
