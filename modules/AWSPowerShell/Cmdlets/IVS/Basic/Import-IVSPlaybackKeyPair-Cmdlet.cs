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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Imports the public portion of a new key pair and returns its <c>arn</c> and <c>fingerprint</c>.
    /// The <c>privateKey</c> can then be used to generate viewer authorization tokens, to
    /// grant viewers access to private channels. For more information, see <a href="https://docs.aws.amazon.com/ivs/latest/userguide/private-channels.html">Setting
    /// Up Private Channels</a> in the <i>Amazon IVS User Guide</i>.
    /// </summary>
    [Cmdlet("Import", "IVSPlaybackKeyPair", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.PlaybackKeyPair")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service ImportPlaybackKeyPair API operation.", Operation = new[] {"ImportPlaybackKeyPair"}, SelectReturnType = typeof(Amazon.IVS.Model.ImportPlaybackKeyPairResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.PlaybackKeyPair or Amazon.IVS.Model.ImportPlaybackKeyPairResponse",
        "This cmdlet returns an Amazon.IVS.Model.PlaybackKeyPair object.",
        "The service call response (type Amazon.IVS.Model.ImportPlaybackKeyPairResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportIVSPlaybackKeyPairCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Playback-key-pair name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PublicKeyMaterial
        /// <summary>
        /// <para>
        /// <para>The public portion of a customer-generated key pair.</para>
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
        public System.String PublicKeyMaterial { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags provided with the request are added to the playback key pair tags. See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging Amazon Web Services Resources and Tag Editor</i>
        /// for details, including restrictions that apply to tags and "Tag naming limits and
        /// requirements"; Amazon IVS has no service-specific constraints beyond what is documented
        /// there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyPair'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.ImportPlaybackKeyPairResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.ImportPlaybackKeyPairResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyPair";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PublicKeyMaterial parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PublicKeyMaterial' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PublicKeyMaterial' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-IVSPlaybackKeyPair (ImportPlaybackKeyPair)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.ImportPlaybackKeyPairResponse, ImportIVSPlaybackKeyPairCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PublicKeyMaterial;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.PublicKeyMaterial = this.PublicKeyMaterial;
            #if MODULAR
            if (this.PublicKeyMaterial == null && ParameterWasBound(nameof(this.PublicKeyMaterial)))
            {
                WriteWarning("You are passing $null as a value for parameter PublicKeyMaterial which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.IVS.Model.ImportPlaybackKeyPairRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PublicKeyMaterial != null)
            {
                request.PublicKeyMaterial = cmdletContext.PublicKeyMaterial;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IVS.Model.ImportPlaybackKeyPairResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.ImportPlaybackKeyPairRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "ImportPlaybackKeyPair");
            try
            {
                #if DESKTOP
                return client.ImportPlaybackKeyPair(request);
                #elif CORECLR
                return client.ImportPlaybackKeyPairAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String PublicKeyMaterial { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IVS.Model.ImportPlaybackKeyPairResponse, ImportIVSPlaybackKeyPairCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyPair;
        }
        
    }
}
