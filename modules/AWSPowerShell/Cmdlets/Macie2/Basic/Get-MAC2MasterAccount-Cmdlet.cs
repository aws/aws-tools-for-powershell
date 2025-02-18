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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// (Deprecated) Retrieves information about the Amazon Macie administrator account for
    /// an account. This operation has been replaced by the <link linkend="GetAdministratorAccount">GetAdministratorAccount</link>
    /// operation.
    /// </summary>
    [Cmdlet("Get", "MAC2MasterAccount")]
    [OutputType("Amazon.Macie2.Model.Invitation")]
    [AWSCmdlet("Calls the Amazon Macie 2 GetMasterAccount API operation.", Operation = new[] {"GetMasterAccount"}, SelectReturnType = typeof(Amazon.Macie2.Model.GetMasterAccountResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.Invitation or Amazon.Macie2.Model.GetMasterAccountResponse",
        "This cmdlet returns an Amazon.Macie2.Model.Invitation object.",
        "The service call response (type Amazon.Macie2.Model.GetMasterAccountResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMAC2MasterAccountCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Master'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.GetMasterAccountResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.GetMasterAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Master";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.GetMasterAccountResponse, GetMAC2MasterAccountCmdlet>(Select) ??
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
            var request = new Amazon.Macie2.Model.GetMasterAccountRequest();
            
            
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
        
        private Amazon.Macie2.Model.GetMasterAccountResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.GetMasterAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "GetMasterAccount");
            try
            {
                return client.GetMasterAccountAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Macie2.Model.GetMasterAccountResponse, GetMAC2MasterAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Master;
        }
        
    }
}
