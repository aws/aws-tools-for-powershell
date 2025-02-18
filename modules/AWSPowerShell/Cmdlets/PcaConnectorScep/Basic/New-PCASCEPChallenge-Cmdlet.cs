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
using Amazon.PcaConnectorScep;
using Amazon.PcaConnectorScep.Model;

namespace Amazon.PowerShell.Cmdlets.PCASCEP
{
    /// <summary>
    /// For general-purpose connectors. Creates a <i>challenge password</i> for the specified
    /// connector. The SCEP protocol uses a challenge password to authenticate a request before
    /// issuing a certificate from a certificate authority (CA). Your SCEP clients include
    /// the challenge password as part of their certificate request to Connector for SCEP.
    /// To retrieve the connector Amazon Resource Names (ARNs) for the connectors in your
    /// account, call <a href="https://docs.aws.amazon.com/C4SCEP_API/pca-connector-scep/latest/APIReference/API_ListConnectors.html">ListConnectors</a>.
    /// 
    ///  
    /// <para>
    /// To create additional challenge passwords for the connector, call <c>CreateChallenge</c>
    /// again. We recommend frequently rotating your challenge passwords.
    /// </para>
    /// </summary>
    [Cmdlet("New", "PCASCEPChallenge", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PcaConnectorScep.Model.Challenge")]
    [AWSCmdlet("Calls the Private CA Connector for SCEP CreateChallenge API operation.", Operation = new[] {"CreateChallenge"}, SelectReturnType = typeof(Amazon.PcaConnectorScep.Model.CreateChallengeResponse))]
    [AWSCmdletOutput("Amazon.PcaConnectorScep.Model.Challenge or Amazon.PcaConnectorScep.Model.CreateChallengeResponse",
        "This cmdlet returns an Amazon.PcaConnectorScep.Model.Challenge object.",
        "The service call response (type Amazon.PcaConnectorScep.Model.CreateChallengeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCASCEPChallengeCmdlet : AmazonPcaConnectorScepClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the connector that you want to create a challenge
        /// for.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Custom string that can be used to distinguish between calls to the <a href="https://docs.aws.amazon.com/C4SCEP_API/pca-connector-scep/latest/APIReference/API_CreateChallenge.html">CreateChallenge</a>
        /// action. Client tokens for <c>CreateChallenge</c> time out after five minutes. Therefore,
        /// if you call <c>CreateChallenge</c> multiple times with the same client token within
        /// five minutes, Connector for SCEP recognizes that you are requesting only one challenge
        /// and will only respond with one. If you change the client token for each call, Connector
        /// for SCEP recognizes that you are requesting multiple challenge passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Challenge'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorScep.Model.CreateChallengeResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorScep.Model.CreateChallengeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Challenge";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCASCEPChallenge (CreateChallenge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorScep.Model.CreateChallengeResponse, NewPCASCEPChallengeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PcaConnectorScep.Model.CreateChallengeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
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
        
        private Amazon.PcaConnectorScep.Model.CreateChallengeResponse CallAWSServiceOperation(IAmazonPcaConnectorScep client, Amazon.PcaConnectorScep.Model.CreateChallengeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Private CA Connector for SCEP", "CreateChallenge");
            try
            {
                return client.CreateChallengeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectorArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PcaConnectorScep.Model.CreateChallengeResponse, NewPCASCEPChallengeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Challenge;
        }
        
    }
}
