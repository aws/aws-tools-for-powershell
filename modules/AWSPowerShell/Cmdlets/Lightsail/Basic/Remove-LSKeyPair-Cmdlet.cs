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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Deletes the specified key pair by removing the public key from Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// You can delete key pairs that were created using the <a href="https://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_ImportKeyPair.html">ImportKeyPair</a>
    /// and <a href="https://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_CreateKeyPair.html">CreateKeyPair</a>
    /// actions, as well as the Lightsail default key pair. A new default key pair will not
    /// be created unless you launch an instance without specifying a custom key pair, or
    /// you call the <a href="https://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_DownloadDefaultKeyPair.html">DownloadDefaultKeyPair</a>
    /// API. 
    /// </para><para>
    /// The <c>delete key pair</c> operation supports tag-based access control via resource
    /// tags applied to the resource identified by <c>key pair name</c>. For more information,
    /// see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "LSKeyPair", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail DeleteKeyPair API operation.", Operation = new[] {"DeleteKeyPair"}, SelectReturnType = typeof(Amazon.Lightsail.Model.DeleteKeyPairResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.DeleteKeyPairResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.DeleteKeyPairResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveLSKeyPairCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpectedFingerprint
        /// <summary>
        /// <para>
        /// <para>The RSA fingerprint of the Lightsail default key pair to delete.</para><note><para>The <c>expectedFingerprint</c> parameter is required only when specifying to delete
        /// a Lightsail default key pair.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedFingerprint { get; set; }
        #endregion
        
        #region Parameter KeyPairName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair to delete.</para>
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
        public System.String KeyPairName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.DeleteKeyPairResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.DeleteKeyPairResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyPairName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyPairName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyPairName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyPairName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LSKeyPair (DeleteKeyPair)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.DeleteKeyPairResponse, RemoveLSKeyPairCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyPairName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExpectedFingerprint = this.ExpectedFingerprint;
            context.KeyPairName = this.KeyPairName;
            #if MODULAR
            if (this.KeyPairName == null && ParameterWasBound(nameof(this.KeyPairName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyPairName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.DeleteKeyPairRequest();
            
            if (cmdletContext.ExpectedFingerprint != null)
            {
                request.ExpectedFingerprint = cmdletContext.ExpectedFingerprint;
            }
            if (cmdletContext.KeyPairName != null)
            {
                request.KeyPairName = cmdletContext.KeyPairName;
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
        
        private Amazon.Lightsail.Model.DeleteKeyPairResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.DeleteKeyPairRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "DeleteKeyPair");
            try
            {
                #if DESKTOP
                return client.DeleteKeyPair(request);
                #elif CORECLR
                return client.DeleteKeyPairAsync(request).GetAwaiter().GetResult();
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
            public System.String ExpectedFingerprint { get; set; }
            public System.String KeyPairName { get; set; }
            public System.Func<Amazon.Lightsail.Model.DeleteKeyPairResponse, RemoveLSKeyPairCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
