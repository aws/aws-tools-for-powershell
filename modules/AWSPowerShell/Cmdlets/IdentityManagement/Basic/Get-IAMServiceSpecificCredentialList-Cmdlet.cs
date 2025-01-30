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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Returns information about the service-specific credentials associated with the specified
    /// IAM user. If none exists, the operation returns an empty list. The service-specific
    /// credentials returned by this operation are used only for authenticating the IAM user
    /// to a specific service. For more information about using service-specific credentials
    /// to authenticate to an Amazon Web Services service, see <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/setting-up-gc.html">Set
    /// up service-specific credentials</a> in the CodeCommit User Guide.
    /// </summary>
    [Cmdlet("Get", "IAMServiceSpecificCredentialList")]
    [OutputType("Amazon.IdentityManagement.Model.ServiceSpecificCredentialMetadata")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ListServiceSpecificCredentials API operation.", Operation = new[] {"ListServiceSpecificCredentials"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ServiceSpecificCredentialMetadata or Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse",
        "This cmdlet returns a collection of Amazon.IdentityManagement.Model.ServiceSpecificCredentialMetadata objects.",
        "The service call response (type Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMServiceSpecificCredentialListCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>Filters the returned results to only those for the specified Amazon Web Services service.
        /// If not specified, then Amazon Web Services returns service-specific credentials for
        /// all services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the user whose service-specific credentials you want information about.
        /// If this value is not specified, then the operation assumes the user whose credentials
        /// are used to call the operation.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceSpecificCredentials'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceSpecificCredentials";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse, GetIAMServiceSpecificCredentialListCmdlet>(Select) ??
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
            context.UserName = this.UserName;
            
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
            var request = new Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsRequest();
            
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
        
        private Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "ListServiceSpecificCredentials");
            try
            {
                #if DESKTOP
                return client.ListServiceSpecificCredentials(request);
                #elif CORECLR
                return client.ListServiceSpecificCredentialsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IdentityManagement.Model.ListServiceSpecificCredentialsResponse, GetIAMServiceSpecificCredentialListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceSpecificCredentials;
        }
        
    }
}
