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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Generates a shared secret and its encapsulated (ciphertext) form using the public
    /// key of an ML-KEM KMS key pair. Module-Lattice-Based Key-Encapsulation Mechanism (ML-KEM),
    /// specified in <a href="https://csrc.nist.gov/pubs/fips/203/final">FIPS 203</a> on the
    /// NIST website, is a post-quantum algorithm for establishing a shared secret between
    /// two parties.
    /// 
    ///  
    /// <para>
    /// For an example of how two parties establish a shared secret over an insecure channel
    /// using ML-KEM, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/pqkeys.html#mlkem">ML-KEM
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The Encapsulate operation is not available in China Regions.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:Encapsulate</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decapsulate</a></para></li><li><para><a>DeriveSharedSecret</a></para></li><li><para><a>CreateKey</a></para></li><li><para><a>GetPublicKey</a></para></li><li><para><a>DescribeKey</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSEncapsulate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.EncapsulateResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service Encapsulate API operation.", Operation = new[] {"Encapsulate"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.EncapsulateResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.EncapsulateResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.EncapsulateResponse object containing multiple properties."
    )]
    public partial class InvokeKMSEncapsulateCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks if your request will succeed. <c>DryRun</c> is an optional parameter. </para><para>To learn more about how to use this parameter, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/testing-permissions.html">Testing
        /// your permissions</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EncapsulationAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the key encapsulation algorithm used to generate the shared secret and its
        /// encapsulated form. The only valid value is <c>ML_KEM</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncapsulationAlgorithmSpec")]
        public Amazon.KeyManagementService.EncapsulationAlgorithmSpec EncapsulationAlgorithm { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/using-grant-token.html">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies an asymmetric ML-KEM KMS key. KMS uses the public key in the specified
        /// key pair to encapsulate the shared secret. ML-KEM KMS keys have a <c>KeySpec</c> value
        /// of <c>ML_KEM_512</c>, <c>ML_KEM_768</c>, or <c>ML_KEM_1024</c> and a <c>KeyUsage</c>
        /// value of <c>ENCAPSULATE_DECAPSULATE</c>. To find the <c>KeySpec</c> and <c>KeyUsage</c>
        /// of a KMS key, use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.EncapsulateResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.EncapsulateResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSEncapsulate (Encapsulate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.EncapsulateResponse, InvokeKMSEncapsulateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.EncapsulationAlgorithm = this.EncapsulationAlgorithm;
            #if MODULAR
            if (this.EncapsulationAlgorithm == null && ParameterWasBound(nameof(this.EncapsulationAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter EncapsulationAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.EncapsulateRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EncapsulationAlgorithm != null)
            {
                request.EncapsulationAlgorithm = cmdletContext.EncapsulationAlgorithm;
            }
            if (cmdletContext.GrantToken != null)
            {
                request.GrantTokens = cmdletContext.GrantToken;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
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
        
        private Amazon.KeyManagementService.Model.EncapsulateResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.EncapsulateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "Encapsulate");
            try
            {
                return client.EncapsulateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Amazon.KeyManagementService.EncapsulationAlgorithmSpec EncapsulationAlgorithm { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.EncapsulateResponse, InvokeKMSEncapsulateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
