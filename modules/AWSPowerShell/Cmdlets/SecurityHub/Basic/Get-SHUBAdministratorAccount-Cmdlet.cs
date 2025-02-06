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
    /// Provides the details for the Security Hub administrator account for the current member
    /// account.
    /// 
    ///  
    /// <para>
    /// Can be used by both member accounts that are managed using Organizations and accounts
    /// that were invited manually.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SHUBAdministratorAccount")]
    [OutputType("Amazon.SecurityHub.Model.Invitation")]
    [AWSCmdlet("Calls the AWS Security Hub GetAdministratorAccount API operation.", Operation = new[] {"GetAdministratorAccount"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetAdministratorAccountResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.Invitation or Amazon.SecurityHub.Model.GetAdministratorAccountResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.Invitation object.",
        "The service call response (type Amazon.SecurityHub.Model.GetAdministratorAccountResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBAdministratorAccountCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Administrator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetAdministratorAccountResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetAdministratorAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Administrator";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetAdministratorAccountResponse, GetSHUBAdministratorAccountCmdlet>(Select) ??
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
            var request = new Amazon.SecurityHub.Model.GetAdministratorAccountRequest();
            
            
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
        
        private Amazon.SecurityHub.Model.GetAdministratorAccountResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetAdministratorAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetAdministratorAccount");
            try
            {
                #if DESKTOP
                return client.GetAdministratorAccount(request);
                #elif CORECLR
                return client.GetAdministratorAccountAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SecurityHub.Model.GetAdministratorAccountResponse, GetSHUBAdministratorAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Administrator;
        }
        
    }
}
