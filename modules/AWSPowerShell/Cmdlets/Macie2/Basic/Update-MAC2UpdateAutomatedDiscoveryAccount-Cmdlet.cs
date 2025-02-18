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
    /// Changes the status of automated sensitive data discovery for one or more accounts.
    /// </summary>
    [Cmdlet("Update", "MAC2UpdateAutomatedDiscoveryAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdateError")]
    [AWSCmdlet("Calls the Amazon Macie 2 BatchUpdateAutomatedDiscoveryAccounts API operation.", Operation = new[] {"BatchUpdateAutomatedDiscoveryAccounts"}, SelectReturnType = typeof(Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdateError or Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdateError objects.",
        "The service call response (type Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMAC2UpdateAutomatedDiscoveryAccountCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each account to change the status of automated sensitive
        /// data discovery for. Each object specifies the Amazon Web Services account ID for an
        /// account and a new status for that account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdate[] Account { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Account), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2UpdateAutomatedDiscoveryAccount (BatchUpdateAutomatedDiscoveryAccounts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse, UpdateMAC2UpdateAutomatedDiscoveryAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Account != null)
            {
                context.Account = new List<Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdate>(this.Account);
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
            var request = new Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Accounts = cmdletContext.Account;
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
        
        private Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "BatchUpdateAutomatedDiscoveryAccounts");
            try
            {
                return client.BatchUpdateAutomatedDiscoveryAccountsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Macie2.Model.AutomatedDiscoveryAccountUpdate> Account { get; set; }
            public System.Func<Amazon.Macie2.Model.BatchUpdateAutomatedDiscoveryAccountsResponse, UpdateMAC2UpdateAutomatedDiscoveryAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
