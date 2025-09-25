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
using Amazon.QLDB;
using Amazon.QLDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Returns a revision data object for a specified document ID and block address. Also
    /// returns a proof of the specified revision for verification if <c>DigestTipAddress</c>
    /// is provided.
    /// </summary>
    [Cmdlet("Get", "QLDBRevision")]
    [OutputType("Amazon.QLDB.Model.GetRevisionResponse")]
    [AWSCmdlet("Calls the Amazon QLDB GetRevision API operation.", Operation = new[] {"GetRevision"}, SelectReturnType = typeof(Amazon.QLDB.Model.GetRevisionResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.GetRevisionResponse",
        "This cmdlet returns an Amazon.QLDB.Model.GetRevisionResponse object containing multiple properties."
    )]
    public partial class GetQLDBRevisionCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DocumentId
        /// <summary>
        /// <para>
        /// <para>The UUID (represented in Base62-encoded text) of the document to be verified.</para>
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
        public System.String DocumentId { get; set; }
        #endregion
        
        #region Parameter BlockAddress_IonText
        /// <summary>
        /// <para>
        /// <para>An Amazon Ion plaintext value contained in a <c>ValueHolder</c> structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlockAddress_IonText { get; set; }
        #endregion
        
        #region Parameter DigestTipAddress_IonText
        /// <summary>
        /// <para>
        /// <para>An Amazon Ion plaintext value contained in a <c>ValueHolder</c> structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DigestTipAddress_IonText { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.GetRevisionResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.GetRevisionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.GetRevisionResponse, GetQLDBRevisionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlockAddress_IonText = this.BlockAddress_IonText;
            context.DigestTipAddress_IonText = this.DigestTipAddress_IonText;
            context.DocumentId = this.DocumentId;
            #if MODULAR
            if (this.DocumentId == null && ParameterWasBound(nameof(this.DocumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.GetRevisionRequest();
            
            
             // populate BlockAddress
            var requestBlockAddressIsNull = true;
            request.BlockAddress = new Amazon.QLDB.Model.ValueHolder();
            System.String requestBlockAddress_blockAddress_IonText = null;
            if (cmdletContext.BlockAddress_IonText != null)
            {
                requestBlockAddress_blockAddress_IonText = cmdletContext.BlockAddress_IonText;
            }
            if (requestBlockAddress_blockAddress_IonText != null)
            {
                request.BlockAddress.IonText = requestBlockAddress_blockAddress_IonText;
                requestBlockAddressIsNull = false;
            }
             // determine if request.BlockAddress should be set to null
            if (requestBlockAddressIsNull)
            {
                request.BlockAddress = null;
            }
            
             // populate DigestTipAddress
            var requestDigestTipAddressIsNull = true;
            request.DigestTipAddress = new Amazon.QLDB.Model.ValueHolder();
            System.String requestDigestTipAddress_digestTipAddress_IonText = null;
            if (cmdletContext.DigestTipAddress_IonText != null)
            {
                requestDigestTipAddress_digestTipAddress_IonText = cmdletContext.DigestTipAddress_IonText;
            }
            if (requestDigestTipAddress_digestTipAddress_IonText != null)
            {
                request.DigestTipAddress.IonText = requestDigestTipAddress_digestTipAddress_IonText;
                requestDigestTipAddressIsNull = false;
            }
             // determine if request.DigestTipAddress should be set to null
            if (requestDigestTipAddressIsNull)
            {
                request.DigestTipAddress = null;
            }
            if (cmdletContext.DocumentId != null)
            {
                request.DocumentId = cmdletContext.DocumentId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QLDB.Model.GetRevisionResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.GetRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "GetRevision");
            try
            {
                return client.GetRevisionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BlockAddress_IonText { get; set; }
            public System.String DigestTipAddress_IonText { get; set; }
            public System.String DocumentId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QLDB.Model.GetRevisionResponse, GetQLDBRevisionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
