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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Creates an <i>alias</i>, or a friendly name, for an Amazon Web Services Payment Cryptography
    /// key. You can use an alias to identify a key in the console and when you call cryptographic
    /// operations such as <a href="https://docs.aws.amazon.com/payment-cryptography/latest/DataAPIReference/API_EncryptData.html">EncryptData</a>
    /// or <a href="https://docs.aws.amazon.com/payment-cryptography/latest/DataAPIReference/API_DecryptData.html">DecryptData</a>.
    /// 
    ///  
    /// <para>
    /// You can associate the alias with any key in the same Amazon Web Services Region. Each
    /// alias is associated with only one key at a time, but a key can have multiple aliases.
    /// You can't create an alias without a key. The alias must be unique in the account and
    /// Amazon Web Services Region, but you can create another alias with the same name in
    /// a different Amazon Web Services Region.
    /// </para><para>
    /// To change the key that's associated with the alias, call <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_UpdateAlias.html">UpdateAlias</a>.
    /// To delete the alias, call <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_DeleteAlias.html">DeleteAlias</a>.
    /// These operations don't affect the underlying key. To get the alias that you created,
    /// call <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ListAliases.html">ListAliases</a>.
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_DeleteAlias.html">DeleteAlias</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetAlias.html">GetAlias</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ListAliases.html">ListAliases</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_UpdateAlias.html">UpdateAlias</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCCAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptography.Model.Alias")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane CreateAlias API operation.", Operation = new[] {"CreateAlias"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.CreateAliasResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.Alias or Amazon.PaymentCryptography.Model.CreateAliasResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.Alias object.",
        "The service call response (type Amazon.PaymentCryptography.Model.CreateAliasResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPAYCCAliasCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>A friendly name that you can use to refer to a key. An alias must begin with <c>alias/</c>
        /// followed by a name, for example <c>alias/ExampleAlias</c>. It can contain only alphanumeric
        /// characters, forward slashes (/), underscores (_), and dashes (-).</para><important><para>Don't include personal, confidential or sensitive information in this field. This
        /// field may be displayed in plaintext in CloudTrail logs and other output.</para></important>
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
        public System.String AliasName { get; set; }
        #endregion
        
        #region Parameter KeyArn
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the key to associate with the alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Alias'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.CreateAliasResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.CreateAliasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Alias";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AliasName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCCAlias (CreateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.CreateAliasResponse, NewPAYCCAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AliasName = this.AliasName;
            #if MODULAR
            if (this.AliasName == null && ParameterWasBound(nameof(this.AliasName)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyArn = this.KeyArn;
            
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
            var request = new Amazon.PaymentCryptography.Model.CreateAliasRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
            }
            if (cmdletContext.KeyArn != null)
            {
                request.KeyArn = cmdletContext.KeyArn;
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
        
        private Amazon.PaymentCryptography.Model.CreateAliasResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.CreateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "CreateAlias");
            try
            {
                return client.CreateAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasName { get; set; }
            public System.String KeyArn { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.CreateAliasResponse, NewPAYCCAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Alias;
        }
        
    }
}
