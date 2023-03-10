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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates the Challenge-Handshake Authentication Protocol (CHAP) credentials for a specified
    /// iSCSI target. By default, a gateway does not have CHAP enabled; however, for added
    /// security, you might use it. This operation is supported in the volume and tape gateway
    /// types.
    /// 
    ///  <important><para>
    /// When you update CHAP credentials, all existing connections on the target are closed
    /// and initiators must reconnect with the new credentials.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SGChapCredential", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.UpdateChapCredentialsResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateChapCredentials API operation.", Operation = new[] {"UpdateChapCredentials"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateChapCredentialsResponse), LegacyAlias="Update-SGChapCredentials")]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.UpdateChapCredentialsResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.UpdateChapCredentialsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSGChapCredentialCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter InitiatorName
        /// <summary>
        /// <para>
        /// <para>The iSCSI initiator that connects to the target.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InitiatorName { get; set; }
        #endregion
        
        #region Parameter SecretToAuthenticateInitiator
        /// <summary>
        /// <para>
        /// <para>The secret key that the initiator (for example, the Windows client) must provide to
        /// participate in mutual CHAP with the target.</para><note><para>The secret key must be between 12 and 16 bytes when encoded in UTF-8.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SecretToAuthenticateInitiator { get; set; }
        #endregion
        
        #region Parameter SecretToAuthenticateTarget
        /// <summary>
        /// <para>
        /// <para>The secret key that the target must provide to participate in mutual CHAP with the
        /// initiator (e.g. Windows client).</para><para>Byte constraints: Minimum bytes of 12. Maximum bytes of 16.</para><note><para>The secret key must be between 12 and 16 bytes when encoded in UTF-8.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String SecretToAuthenticateTarget { get; set; }
        #endregion
        
        #region Parameter TargetARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the iSCSI volume target. Use the <a>DescribeStorediSCSIVolumes</a>
        /// operation to return the TargetARN for specified VolumeARN.</para>
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
        public System.String TargetARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateChapCredentialsResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateChapCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InitiatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGChapCredential (UpdateChapCredentials)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateChapCredentialsResponse, UpdateSGChapCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InitiatorName = this.InitiatorName;
            #if MODULAR
            if (this.InitiatorName == null && ParameterWasBound(nameof(this.InitiatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter InitiatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretToAuthenticateInitiator = this.SecretToAuthenticateInitiator;
            #if MODULAR
            if (this.SecretToAuthenticateInitiator == null && ParameterWasBound(nameof(this.SecretToAuthenticateInitiator)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretToAuthenticateInitiator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretToAuthenticateTarget = this.SecretToAuthenticateTarget;
            context.TargetARN = this.TargetARN;
            #if MODULAR
            if (this.TargetARN == null && ParameterWasBound(nameof(this.TargetARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.UpdateChapCredentialsRequest();
            
            if (cmdletContext.InitiatorName != null)
            {
                request.InitiatorName = cmdletContext.InitiatorName;
            }
            if (cmdletContext.SecretToAuthenticateInitiator != null)
            {
                request.SecretToAuthenticateInitiator = cmdletContext.SecretToAuthenticateInitiator;
            }
            if (cmdletContext.SecretToAuthenticateTarget != null)
            {
                request.SecretToAuthenticateTarget = cmdletContext.SecretToAuthenticateTarget;
            }
            if (cmdletContext.TargetARN != null)
            {
                request.TargetARN = cmdletContext.TargetARN;
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
        
        private Amazon.StorageGateway.Model.UpdateChapCredentialsResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateChapCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateChapCredentials");
            try
            {
                #if DESKTOP
                return client.UpdateChapCredentials(request);
                #elif CORECLR
                return client.UpdateChapCredentialsAsync(request).GetAwaiter().GetResult();
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
            public System.String InitiatorName { get; set; }
            public System.String SecretToAuthenticateInitiator { get; set; }
            public System.String SecretToAuthenticateTarget { get; set; }
            public System.String TargetARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateChapCredentialsResponse, UpdateSGChapCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
