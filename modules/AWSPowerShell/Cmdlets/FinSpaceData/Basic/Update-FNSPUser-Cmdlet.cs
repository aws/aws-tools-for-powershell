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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Modifies the details of the specified user. You cannot update the <c>userId</c> for
    /// a user.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "FNSPUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the FinSpace Public API UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.UpdateUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.FinSpaceData.Model.UpdateUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FinSpaceData.Model.UpdateUserResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class UpdateFNSPUserCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiAccess
        /// <summary>
        /// <para>
        /// <para>The option to indicate whether the user can use the <c>GetProgrammaticAccessCredentials</c>
        /// API to obtain credentials that can then be used to access other FinSpace Data API
        /// operations.</para><ul><li><para><c>ENABLED</c> – The user has permissions to use the APIs.</para></li><li><para><c>DISABLED</c> – The user does not have permissions to use any APIs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FinSpaceData.ApiAccess")]
        public Amazon.FinSpaceData.ApiAccess ApiAccess { get; set; }
        #endregion
        
        #region Parameter ApiAccessPrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN identifier of an AWS user or role that is allowed to call the <c>GetProgrammaticAccessCredentials</c>
        /// API to obtain a credentials token for a specific FinSpace user. This must be an IAM
        /// role within your FinSpace account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiAccessPrincipalArn { get; set; }
        #endregion
        
        #region Parameter FirstName
        /// <summary>
        /// <para>
        /// <para>The first name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirstName { get; set; }
        #endregion
        
        #region Parameter LastName
        /// <summary>
        /// <para>
        /// <para>The last name of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastName { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The option to indicate the type of user.</para><ul><li><para><c>SUPER_USER</c>– A user with permission to all the functionality and data in FinSpace.</para></li><li><para><c>APP_USER</c> – A user with specific permissions in FinSpace. The users are assigned
        /// permissions by adding them to a permission group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FinSpaceData.UserType")]
        public Amazon.FinSpaceData.UserType Type { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the user that you want to update.</para>
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.UpdateUserResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.UpdateUserResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FNSPUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.UpdateUserResponse, UpdateFNSPUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiAccess = this.ApiAccess;
            context.ApiAccessPrincipalArn = this.ApiAccessPrincipalArn;
            context.ClientToken = this.ClientToken;
            context.FirstName = this.FirstName;
            context.LastName = this.LastName;
            context.Type = this.Type;
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
            var request = new Amazon.FinSpaceData.Model.UpdateUserRequest();
            
            if (cmdletContext.ApiAccess != null)
            {
                request.ApiAccess = cmdletContext.ApiAccess;
            }
            if (cmdletContext.ApiAccessPrincipalArn != null)
            {
                request.ApiAccessPrincipalArn = cmdletContext.ApiAccessPrincipalArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FirstName != null)
            {
                request.FirstName = cmdletContext.FirstName;
            }
            if (cmdletContext.LastName != null)
            {
                request.LastName = cmdletContext.LastName;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.FinSpaceData.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "UpdateUser");
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
            public Amazon.FinSpaceData.ApiAccess ApiAccess { get; set; }
            public System.String ApiAccessPrincipalArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String FirstName { get; set; }
            public System.String LastName { get; set; }
            public Amazon.FinSpaceData.UserType Type { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.UpdateUserResponse, UpdateFNSPUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserId;
        }
        
    }
}
