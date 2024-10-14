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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Generates a set of credentials consisting of a user name and password that can be
    /// used to access the service specified in the request. These credentials are generated
    /// by IAM, and can be used only for the specified service. 
    /// 
    ///  
    /// <para>
    /// You can have a maximum of two sets of service-specific credentials for each supported
    /// service per user.
    /// </para><para>
    /// You can create service-specific credentials for CodeCommit and Amazon Keyspaces (for
    /// Apache Cassandra).
    /// </para><para>
    /// You can reset the password to a new service-generated value by calling <a>ResetServiceSpecificCredential</a>.
    /// </para><para>
    /// For more information about service-specific credentials, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_ssh-keys.html">Using
    /// IAM with CodeCommit: Git credentials, SSH keys, and Amazon Web Services access keys</a>
    /// in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMServiceSpecificCredential", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.ServiceSpecificCredential")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateServiceSpecificCredential API operation.", Operation = new[] {"CreateServiceSpecificCredential"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ServiceSpecificCredential or Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.ServiceSpecificCredential object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMServiceSpecificCredentialCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services service that is to be associated with the credentials.
        /// The service you specify here is the only service that can be accessed using these
        /// credentials.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user that is to be associated with the credentials. The new service-specific
        /// credentials have the same permissions as the associated user except that they can
        /// be used only to access the specified service.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceSpecificCredential'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceSpecificCredential";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMServiceSpecificCredential (CreateServiceSpecificCredential)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse, NewIAMServiceSpecificCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialRequest();
            
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
        
        private Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateServiceSpecificCredential");
            try
            {
                #if DESKTOP
                return client.CreateServiceSpecificCredential(request);
                #elif CORECLR
                return client.CreateServiceSpecificCredentialAsync(request).GetAwaiter().GetResult();
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
            public System.String ServiceName { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateServiceSpecificCredentialResponse, NewIAMServiceSpecificCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceSpecificCredential;
        }
        
    }
}
