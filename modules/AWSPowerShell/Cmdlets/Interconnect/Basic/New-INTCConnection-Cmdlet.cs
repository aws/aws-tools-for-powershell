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
using Amazon.Interconnect;
using Amazon.Interconnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INTC
{
    /// <summary>
    /// Initiates the process to create a Connection across the specified Environment. 
    /// 
    ///  
    /// <para>
    /// The Environment dictates the specified partner and location to which the other end
    /// of the connection should attach. You can see a list of the available Environments
    /// by calling <a>ListEnvironments</a></para><para>
    /// The Attach Point specifies where within the AWS Network your connection will logically
    /// connect.
    /// </para><para>
    /// After a successful call to this method, the resulting <a>Connection</a> will return
    /// an Activation Key which will need to be brought to the specific partner's portal to
    /// confirm the <a>Connection</a> on both sides. (See <a>Environment$activationPageUrl</a>
    /// for a direct link to the partner portal). 
    /// </para>
    /// </summary>
    [Cmdlet("New", "INTCConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Interconnect.Model.Connection")]
    [AWSCmdlet("Calls the Interconnect CreateConnection API operation.", Operation = new[] {"CreateConnection"}, SelectReturnType = typeof(Amazon.Interconnect.Model.CreateConnectionResponse))]
    [AWSCmdletOutput("Amazon.Interconnect.Model.Connection or Amazon.Interconnect.Model.CreateConnectionResponse",
        "This cmdlet returns an Amazon.Interconnect.Model.Connection object.",
        "The service call response (type Amazon.Interconnect.Model.CreateConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINTCConnectionCmdlet : AmazonInterconnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachPoint_Arn
        /// <summary>
        /// <para>
        /// <para>Identifies an attach point by full ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttachPoint_Arn { get; set; }
        #endregion
        
        #region Parameter Bandwidth
        /// <summary>
        /// <para>
        /// <para>The desired bandwidth of the requested <a>Connection</a></para>
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
        public System.String Bandwidth { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description to distinguish this <a>Connection</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AttachPoint_DirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>Identifies an DirectConnect Gateway attach point by DirectConnectGatewayID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttachPoint_DirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the <a>Environment</a> across which this <a>Connection</a> should
        /// be created.</para><para>The available <a>Environment</a> objects can be determined using <a>ListEnvironments</a>.</para>
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
        
        #region Parameter RemoteAccount_Identifier
        /// <summary>
        /// <para>
        /// <para>A generic bit of identifying information. Can be used in place of any of the more
        /// specific types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteAccount_Identifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag to associate with the resulting <a>Connection</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token used for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Interconnect.Model.CreateConnectionResponse).
        /// Specifying the name of a property of type Amazon.Interconnect.Model.CreateConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INTCConnection (CreateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Interconnect.Model.CreateConnectionResponse, NewINTCConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachPoint_Arn = this.AttachPoint_Arn;
            context.AttachPoint_DirectConnectGateway = this.AttachPoint_DirectConnectGateway;
            context.Bandwidth = this.Bandwidth;
            #if MODULAR
            if (this.Bandwidth == null && ParameterWasBound(nameof(this.Bandwidth)))
            {
                WriteWarning("You are passing $null as a value for parameter Bandwidth which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RemoteAccount_Identifier = this.RemoteAccount_Identifier;
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
            var request = new Amazon.Interconnect.Model.CreateConnectionRequest();
            
            
             // populate AttachPoint
            var requestAttachPointIsNull = true;
            request.AttachPoint = new Amazon.Interconnect.Model.AttachPoint();
            System.String requestAttachPoint_attachPoint_Arn = null;
            if (cmdletContext.AttachPoint_Arn != null)
            {
                requestAttachPoint_attachPoint_Arn = cmdletContext.AttachPoint_Arn;
            }
            if (requestAttachPoint_attachPoint_Arn != null)
            {
                request.AttachPoint.Arn = requestAttachPoint_attachPoint_Arn;
                requestAttachPointIsNull = false;
            }
            System.String requestAttachPoint_attachPoint_DirectConnectGateway = null;
            if (cmdletContext.AttachPoint_DirectConnectGateway != null)
            {
                requestAttachPoint_attachPoint_DirectConnectGateway = cmdletContext.AttachPoint_DirectConnectGateway;
            }
            if (requestAttachPoint_attachPoint_DirectConnectGateway != null)
            {
                request.AttachPoint.DirectConnectGateway = requestAttachPoint_attachPoint_DirectConnectGateway;
                requestAttachPointIsNull = false;
            }
             // determine if request.AttachPoint should be set to null
            if (requestAttachPointIsNull)
            {
                request.AttachPoint = null;
            }
            if (cmdletContext.Bandwidth != null)
            {
                request.Bandwidth = cmdletContext.Bandwidth;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            
             // populate RemoteAccount
            var requestRemoteAccountIsNull = true;
            request.RemoteAccount = new Amazon.Interconnect.Model.RemoteAccountIdentifier();
            System.String requestRemoteAccount_remoteAccount_Identifier = null;
            if (cmdletContext.RemoteAccount_Identifier != null)
            {
                requestRemoteAccount_remoteAccount_Identifier = cmdletContext.RemoteAccount_Identifier;
            }
            if (requestRemoteAccount_remoteAccount_Identifier != null)
            {
                request.RemoteAccount.Identifier = requestRemoteAccount_remoteAccount_Identifier;
                requestRemoteAccountIsNull = false;
            }
             // determine if request.RemoteAccount should be set to null
            if (requestRemoteAccountIsNull)
            {
                request.RemoteAccount = null;
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
        
        private Amazon.Interconnect.Model.CreateConnectionResponse CallAWSServiceOperation(IAmazonInterconnect client, Amazon.Interconnect.Model.CreateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Interconnect", "CreateConnection");
            try
            {
                return client.CreateConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttachPoint_Arn { get; set; }
            public System.String AttachPoint_DirectConnectGateway { get; set; }
            public System.String Bandwidth { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String RemoteAccount_Identifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Interconnect.Model.CreateConnectionResponse, NewINTCConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connection;
        }
        
    }
}
