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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// This method is deprecated. Instead, use <c>GetAdministratorAccount</c>.
    /// 
    ///  
    /// <para>
    /// The Security Hub console continues to use <c>GetMasterAccount</c>. It will eventually
    /// change to use <c>GetAdministratorAccount</c>. Any IAM policies that specifically control
    /// access to this function must continue to use <c>GetMasterAccount</c>. You should also
    /// add <c>GetAdministratorAccount</c> to your policies to ensure that the correct permissions
    /// are in place after the console begins to use <c>GetAdministratorAccount</c>.
    /// </para><para>
    /// Provides the details for the Security Hub administrator account for the current member
    /// account.
    /// </para><para>
    /// Can be used by both member accounts that are managed using Organizations and accounts
    /// that were invited manually.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "SHUBMasterAccount")]
    [OutputType("Amazon.SecurityHub.Model.Invitation")]
    [AWSCmdlet("Calls the AWS Security Hub GetMasterAccount API operation.", Operation = new[] {"GetMasterAccount"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetMasterAccountResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.Invitation or Amazon.SecurityHub.Model.GetMasterAccountResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.Invitation object.",
        "The service call response (type Amazon.SecurityHub.Model.GetMasterAccountResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This API has been deprecated, use GetAdministratorAccount API instead.")]
    public partial class GetSHUBMasterAccountCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Master'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetMasterAccountResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetMasterAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Master";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetMasterAccountResponse, GetSHUBMasterAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.SecurityHub.Model.GetMasterAccountRequest();
            
            
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
        
        private Amazon.SecurityHub.Model.GetMasterAccountResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetMasterAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetMasterAccount");
            try
            {
                #if DESKTOP
                return client.GetMasterAccount(request);
                #elif CORECLR
                return client.GetMasterAccountAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SecurityHub.Model.GetMasterAccountResponse, GetSHUBMasterAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Master;
        }
        
    }
}
