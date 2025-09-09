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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Update Source Server.
    /// </summary>
    [Cmdlet("Update", "MGNSourceServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateSourceServerResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateSourceServer API operation.", Operation = new[] {"UpdateSourceServer"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateSourceServerResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateSourceServerResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateSourceServerResponse object containing multiple properties."
    )]
    public partial class UpdateMGNSourceServerCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Update Source Server request account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter ConnectorAction_ConnectorArn
        /// <summary>
        /// <para>
        /// <para>Source Server connector action connector arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAction_ConnectorArn { get; set; }
        #endregion
        
        #region Parameter ConnectorAction_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>Source Server connector action credentials secret arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorAction_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>Update Source Server request source server ID.</para>
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
        public System.String SourceServerID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateSourceServerResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateSourceServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceServerID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNSourceServer (UpdateSourceServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateSourceServerResponse, UpdateMGNSourceServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceServerID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountID = this.AccountID;
            context.ConnectorAction_ConnectorArn = this.ConnectorAction_ConnectorArn;
            context.ConnectorAction_CredentialsSecretArn = this.ConnectorAction_CredentialsSecretArn;
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Mgn.Model.UpdateSourceServerRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate ConnectorAction
            var requestConnectorActionIsNull = true;
            request.ConnectorAction = new Amazon.Mgn.Model.SourceServerConnectorAction();
            System.String requestConnectorAction_connectorAction_ConnectorArn = null;
            if (cmdletContext.ConnectorAction_ConnectorArn != null)
            {
                requestConnectorAction_connectorAction_ConnectorArn = cmdletContext.ConnectorAction_ConnectorArn;
            }
            if (requestConnectorAction_connectorAction_ConnectorArn != null)
            {
                request.ConnectorAction.ConnectorArn = requestConnectorAction_connectorAction_ConnectorArn;
                requestConnectorActionIsNull = false;
            }
            System.String requestConnectorAction_connectorAction_CredentialsSecretArn = null;
            if (cmdletContext.ConnectorAction_CredentialsSecretArn != null)
            {
                requestConnectorAction_connectorAction_CredentialsSecretArn = cmdletContext.ConnectorAction_CredentialsSecretArn;
            }
            if (requestConnectorAction_connectorAction_CredentialsSecretArn != null)
            {
                request.ConnectorAction.CredentialsSecretArn = requestConnectorAction_connectorAction_CredentialsSecretArn;
                requestConnectorActionIsNull = false;
            }
             // determine if request.ConnectorAction should be set to null
            if (requestConnectorActionIsNull)
            {
                request.ConnectorAction = null;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
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
        
        private Amazon.Mgn.Model.UpdateSourceServerResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateSourceServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateSourceServer");
            try
            {
                #if DESKTOP
                return client.UpdateSourceServer(request);
                #elif CORECLR
                return client.UpdateSourceServerAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public System.String ConnectorAction_ConnectorArn { get; set; }
            public System.String ConnectorAction_CredentialsSecretArn { get; set; }
            public System.String SourceServerID { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateSourceServerResponse, UpdateMGNSourceServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
