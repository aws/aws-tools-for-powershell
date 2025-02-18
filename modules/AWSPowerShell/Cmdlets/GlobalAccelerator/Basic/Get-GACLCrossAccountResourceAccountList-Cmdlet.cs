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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// List the accounts that have cross-account resources.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/cross-account-resources.html">
    /// Working with cross-account attachments and resources in Global Accelerator</a> in
    /// the <i> Global Accelerator Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GACLCrossAccountResourceAccountList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Global Accelerator ListCrossAccountResourceAccounts API operation.", Operation = new[] {"ListCrossAccountResourceAccounts"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse))]
    [AWSCmdletOutput("System.String or Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGACLCrossAccountResourceAccountListCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceOwnerAwsAccountIds'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceOwnerAwsAccountIds";
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
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse, GetGACLCrossAccountResourceAccountListCmdlet>(Select) ??
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
            var request = new Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsRequest();
            
            
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
        
        private Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "ListCrossAccountResourceAccounts");
            try
            {
                return client.ListCrossAccountResourceAccountsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.GlobalAccelerator.Model.ListCrossAccountResourceAccountsResponse, GetGACLCrossAccountResourceAccountListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceOwnerAwsAccountIds;
        }
        
    }
}
