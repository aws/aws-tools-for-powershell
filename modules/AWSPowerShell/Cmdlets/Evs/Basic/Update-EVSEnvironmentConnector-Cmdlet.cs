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
using Amazon.Evs;
using Amazon.Evs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVS
{
    /// <summary>
    /// Updates a connector for an Amazon EVS environment. You can update the Amazon Web Services
    /// Secrets Manager secret ARN or the appliance FQDN to reconfigure the connector metadata.
    /// 
    ///  <note><para>
    /// You cannot update both the secret and the FQDN in the same request.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "EVSEnvironmentConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Evs.Model.Connector")]
    [AWSCmdlet("Calls the Amazon Elastic VMware Service UpdateEnvironmentConnector API operation.", Operation = new[] {"UpdateEnvironmentConnector"}, SelectReturnType = typeof(Amazon.Evs.Model.UpdateEnvironmentConnectorResponse))]
    [AWSCmdletOutput("Amazon.Evs.Model.Connector or Amazon.Evs.Model.UpdateEnvironmentConnectorResponse",
        "This cmdlet returns an Amazon.Evs.Model.Connector object.",
        "The service call response (type Amazon.Evs.Model.UpdateEnvironmentConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEVSEnvironmentConnectorCmdlet : AmazonEvsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplianceFqdn
        /// <summary>
        /// <para>
        /// <para>The new fully qualified domain name (FQDN) of the VCF appliance that the connector
        /// connects to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplianceFqdn { get; set; }
        #endregion
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the connector to update.</para>
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
        public System.String ConnectorId { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the environment that the connector belongs to.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter SecretIdentifier
        /// <summary>
        /// <para>
        /// <para>The new ARN or name of the Amazon Web Services Secrets Manager secret that stores
        /// the credentials for the VCF appliance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para><note><para>This parameter is not used in Amazon EVS currently. If you supply input for this parameter,
        /// it will have no effect.</para></note><para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the connector update request. If you do not specify a client token, a randomly generated
        /// token is used for the request to ensure idempotency.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Evs.Model.UpdateEnvironmentConnectorResponse).
        /// Specifying the name of a property of type Amazon.Evs.Model.UpdateEnvironmentConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connector";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ConnectorId),
                nameof(this.EnvironmentId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVSEnvironmentConnector (UpdateEnvironmentConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Evs.Model.UpdateEnvironmentConnectorResponse, UpdateEVSEnvironmentConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplianceFqdn = this.ApplianceFqdn;
            context.ClientToken = this.ClientToken;
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretIdentifier = this.SecretIdentifier;
            
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
            var request = new Amazon.Evs.Model.UpdateEnvironmentConnectorRequest();
            
            if (cmdletContext.ApplianceFqdn != null)
            {
                request.ApplianceFqdn = cmdletContext.ApplianceFqdn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.SecretIdentifier != null)
            {
                request.SecretIdentifier = cmdletContext.SecretIdentifier;
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
        
        private Amazon.Evs.Model.UpdateEnvironmentConnectorResponse CallAWSServiceOperation(IAmazonEvs client, Amazon.Evs.Model.UpdateEnvironmentConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic VMware Service", "UpdateEnvironmentConnector");
            try
            {
                return client.UpdateEnvironmentConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplianceFqdn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ConnectorId { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String SecretIdentifier { get; set; }
            public System.Func<Amazon.Evs.Model.UpdateEnvironmentConnectorResponse, UpdateEVSEnvironmentConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connector;
        }
        
    }
}
