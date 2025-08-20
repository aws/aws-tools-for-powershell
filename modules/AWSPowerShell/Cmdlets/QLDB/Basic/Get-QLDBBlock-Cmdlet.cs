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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Returns a block object at a specified address in a journal. Also returns a proof of
    /// the specified block for verification if <c>DigestTipAddress</c> is provided.
    /// 
    ///  
    /// <para>
    /// For information about the data contents in a block, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/journal-contents.html">Journal
    /// contents</a> in the <i>Amazon QLDB Developer Guide</i>.
    /// </para><para>
    /// If the specified ledger doesn't exist or is in <c>DELETING</c> status, then throws
    /// <c>ResourceNotFoundException</c>.
    /// </para><para>
    /// If the specified ledger is in <c>CREATING</c> status, then throws <c>ResourcePreconditionNotMetException</c>.
    /// </para><para>
    /// If no block exists with the specified address, then throws <c>InvalidParameterException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "QLDBBlock")]
    [OutputType("Amazon.QLDB.Model.GetBlockResponse")]
    [AWSCmdlet("Calls the Amazon QLDB GetBlock API operation.", Operation = new[] {"GetBlock"}, SelectReturnType = typeof(Amazon.QLDB.Model.GetBlockResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.GetBlockResponse",
        "This cmdlet returns an Amazon.QLDB.Model.GetBlockResponse object containing multiple properties."
    )]
    public partial class GetQLDBBlockCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.GetBlockResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.GetBlockResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.GetBlockResponse, GetQLDBBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BlockAddress_IonText = this.BlockAddress_IonText;
            context.DigestTipAddress_IonText = this.DigestTipAddress_IonText;
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
            var request = new Amazon.QLDB.Model.GetBlockRequest();
            
            
             // populate BlockAddress
            request.BlockAddress = new Amazon.QLDB.Model.ValueHolder();
            System.String requestBlockAddress_blockAddress_IonText = null;
            if (cmdletContext.BlockAddress_IonText != null)
            {
                requestBlockAddress_blockAddress_IonText = cmdletContext.BlockAddress_IonText;
            }
            if (requestBlockAddress_blockAddress_IonText != null)
            {
                request.BlockAddress.IonText = requestBlockAddress_blockAddress_IonText;
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
        
        private Amazon.QLDB.Model.GetBlockResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.GetBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "GetBlock");
            try
            {
                #if DESKTOP
                return client.GetBlock(request);
                #elif CORECLR
                return client.GetBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String BlockAddress_IonText { get; set; }
            public System.String DigestTipAddress_IonText { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QLDB.Model.GetBlockResponse, GetQLDBBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
