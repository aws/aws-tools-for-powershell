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
using Amazon.MarketplaceAgreement;
using Amazon.MarketplaceAgreement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAS
{
    /// <summary>
    /// Obtains details about the acceptor's contact information for an active agreement that
    /// you participate in as the proposer, acceptor, or manufacturer.
    /// 
    ///  <note><para>
    /// If the acceptor's contact information isn't available, the operation succeeds but
    /// doesn't return <c>acceptorContact</c>. This happens when the acceptor didn't provide
    /// it, the information was removed, or the agreement isn't active.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MASAgreementContact")]
    [OutputType("Amazon.MarketplaceAgreement.Model.AcceptorContact")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service GetAgreementContacts API operation.", Operation = new[] {"GetAgreementContacts"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.AcceptorContact or Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.AcceptorContact object.",
        "The service call response (type Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMASAgreementContactCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgreementId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement.</para>
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
        public System.String AgreementId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcceptorContact'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcceptorContact";
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
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse, GetMASAgreementContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgreementId = this.AgreementId;
            #if MODULAR
            if (this.AgreementId == null && ParameterWasBound(nameof(this.AgreementId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgreementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceAgreement.Model.GetAgreementContactsRequest();
            
            if (cmdletContext.AgreementId != null)
            {
                request.AgreementId = cmdletContext.AgreementId;
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
        
        private Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.GetAgreementContactsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "GetAgreementContacts");
            try
            {
                return client.GetAgreementContactsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgreementId { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.GetAgreementContactsResponse, GetMASAgreementContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => Amazon.PowerShell.Common.SensitiveOutput.TagForHost(response.AcceptorContact, cmdlet, "AcceptorContact");
        }
        
    }
}
