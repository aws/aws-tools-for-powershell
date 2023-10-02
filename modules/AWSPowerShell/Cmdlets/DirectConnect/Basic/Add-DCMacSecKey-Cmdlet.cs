/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Associates a MAC Security (MACsec) Connection Key Name (CKN)/ Connectivity Association
    /// Key (CAK) pair with an Direct Connect dedicated connection.
    /// 
    ///  
    /// <para>
    /// You must supply either the <code>secretARN,</code> or the CKN/CAK (<code>ckn</code>
    /// and <code>cak</code>) pair in the request.
    /// </para><para>
    /// For information about MAC Security (MACsec) key considerations, see <a href="https://docs.aws.amazon.com/directconnect/latest/UserGuide/direct-connect-mac-sec-getting-started.html#mac-sec-key-consideration">MACsec
    /// pre-shared CKN/CAK key considerations </a> in the <i>Direct Connect User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DCMacSecKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AssociateMacSecKeyResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AssociateMacSecKey API operation.", Operation = new[] {"AssociateMacSecKey"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AssociateMacSecKeyResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AssociateMacSecKeyResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.AssociateMacSecKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddDCMacSecKeyCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cak
        /// <summary>
        /// <para>
        /// <para>The MAC Security (MACsec) CAK to associate with the dedicated connection.</para><para>You can create the CKN/CAK pair using an industry standard tool.</para><para> The valid values are 64 hexadecimal characters (0-9, A-E).</para><para>If you use this request parameter, you must use the <code>ckn</code> request parameter
        /// and not use the <code>secretARN</code> request parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cak { get; set; }
        #endregion
        
        #region Parameter Ckn
        /// <summary>
        /// <para>
        /// <para>The MAC Security (MACsec) CKN to associate with the dedicated connection.</para><para>You can create the CKN/CAK pair using an industry standard tool.</para><para> The valid values are 64 hexadecimal characters (0-9, A-E).</para><para>If you use this request parameter, you must use the <code>cak</code> request parameter
        /// and not use the <code>secretARN</code> request parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ckn { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the dedicated connection (dxcon-xxxx), or the ID of the LAG (dxlag-xxxx).</para><para>You can use <a>DescribeConnections</a> or <a>DescribeLags</a> to retrieve connection
        /// ID.</para>
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
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter SecretARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the MAC Security (MACsec) secret key to associate
        /// with the dedicated connection.</para><para>You can use <a>DescribeConnections</a> or <a>DescribeLags</a> to retrieve the MAC
        /// Security (MACsec) secret key.</para><para>If you use this request parameter, you do not use the <code>ckn</code> and <code>cak</code>
        /// request parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AssociateMacSecKeyResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AssociateMacSecKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DCMacSecKey (AssociateMacSecKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AssociateMacSecKeyResponse, AddDCMacSecKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cak = this.Cak;
            context.Ckn = this.Ckn;
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretARN = this.SecretARN;
            
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
            var request = new Amazon.DirectConnect.Model.AssociateMacSecKeyRequest();
            
            if (cmdletContext.Cak != null)
            {
                request.Cak = cmdletContext.Cak;
            }
            if (cmdletContext.Ckn != null)
            {
                request.Ckn = cmdletContext.Ckn;
            }
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.SecretARN != null)
            {
                request.SecretARN = cmdletContext.SecretARN;
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
        
        private Amazon.DirectConnect.Model.AssociateMacSecKeyResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AssociateMacSecKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AssociateMacSecKey");
            try
            {
                #if DESKTOP
                return client.AssociateMacSecKey(request);
                #elif CORECLR
                return client.AssociateMacSecKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String Cak { get; set; }
            public System.String Ckn { get; set; }
            public System.String ConnectionId { get; set; }
            public System.String SecretARN { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AssociateMacSecKeyResponse, AddDCMacSecKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
