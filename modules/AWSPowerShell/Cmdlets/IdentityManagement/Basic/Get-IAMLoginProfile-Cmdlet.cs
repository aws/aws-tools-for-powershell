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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Retrieves the user name for the specified IAM user. A login profile is created when
    /// you create a password for the user to access the Amazon Web Services Management Console.
    /// If the user does not exist or does not have a password, the operation returns a 404
    /// (<c>NoSuchEntity</c>) error.
    /// 
    ///  
    /// <para>
    /// If you create an IAM user with access to the console, the <c>CreateDate</c> reflects
    /// the date you created the initial password for the user.
    /// </para><para>
    /// If you create an IAM user with programmatic access, and then later add a password
    /// for the user to access the Amazon Web Services Management Console, the <c>CreateDate</c>
    /// reflects the initial password creation date. A user with programmatic access does
    /// not have a login profile unless you create a password for the user to access the Amazon
    /// Web Services Management Console.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMLoginProfile")]
    [OutputType("Amazon.IdentityManagement.Model.LoginProfile")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetLoginProfile API operation.", Operation = new[] {"GetLoginProfile"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GetLoginProfileResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.LoginProfile or Amazon.IdentityManagement.Model.GetLoginProfileResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.LoginProfile object.",
        "The service call response (type Amazon.IdentityManagement.Model.GetLoginProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMLoginProfileCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the user whose login profile you want to retrieve.</para><para>This parameter is optional. If no user name is included, it defaults to the principal
        /// making the request. When you make this request with root user credentials, you must
        /// use an <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRoot.html">AssumeRoot</a>
        /// session to omit the user name.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoginProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GetLoginProfileResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GetLoginProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoginProfile";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GetLoginProfileResponse, GetIAMLoginProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.IdentityManagement.Model.GetLoginProfileRequest();
            
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
        
        private Amazon.IdentityManagement.Model.GetLoginProfileResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetLoginProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetLoginProfile");
            try
            {
                return client.GetLoginProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String UserName { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GetLoginProfileResponse, GetIAMLoginProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoginProfile;
        }
        
    }
}
