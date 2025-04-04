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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Updates the specified archive.
    /// </summary>
    [Cmdlet("Update", "EVBArchive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.UpdateArchiveResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge UpdateArchive API operation.", Operation = new[] {"UpdateArchive"}, SelectReturnType = typeof(Amazon.EventBridge.Model.UpdateArchiveResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.UpdateArchiveResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.UpdateArchiveResponse object containing multiple properties."
    )]
    public partial class UpdateEVBArchiveCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArchiveName
        /// <summary>
        /// <para>
        /// <para>The name of the archive to update.</para>
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
        public System.String ArchiveName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventPattern
        /// <summary>
        /// <para>
        /// <para>The event pattern to use to filter events sent to the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventPattern { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS customer managed key for EventBridge to use, if you choose
        /// to use a customer managed key to encrypt this archive. The identifier can be the key
        /// Amazon Resource Name (ARN), KeyId, key alias, or key alias ARN.</para><para>If you do not specify a customer managed key identifier, EventBridge uses an Amazon
        /// Web Services owned key to encrypt the archive.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/viewing-keys.html">Identify
        /// and view keys</a> in the <i>Key Management Service Developer Guide</i>. </para><important><para>If you have specified that EventBridge use a customer managed key for encrypting the
        /// source event bus, we strongly recommend you also specify a customer managed key for
        /// any archives for the event bus as well. </para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/encryption-archives.html">Encrypting
        /// archives</a> in the <i>Amazon EventBridge User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter RetentionDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain events in the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionDays")]
        public System.Int32? RetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.UpdateArchiveResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.UpdateArchiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ArchiveName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ArchiveName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ArchiveName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBArchive (UpdateArchive)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.UpdateArchiveResponse, UpdateEVBArchiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ArchiveName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ArchiveName = this.ArchiveName;
            #if MODULAR
            if (this.ArchiveName == null && ParameterWasBound(nameof(this.ArchiveName)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EventPattern = this.EventPattern;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.RetentionDay = this.RetentionDay;
            
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
            var request = new Amazon.EventBridge.Model.UpdateArchiveRequest();
            
            if (cmdletContext.ArchiveName != null)
            {
                request.ArchiveName = cmdletContext.ArchiveName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventPattern != null)
            {
                request.EventPattern = cmdletContext.EventPattern;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.RetentionDay != null)
            {
                request.RetentionDays = cmdletContext.RetentionDay.Value;
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
        
        private Amazon.EventBridge.Model.UpdateArchiveResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.UpdateArchiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "UpdateArchive");
            try
            {
                #if DESKTOP
                return client.UpdateArchive(request);
                #elif CORECLR
                return client.UpdateArchiveAsync(request).GetAwaiter().GetResult();
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
            public System.String ArchiveName { get; set; }
            public System.String Description { get; set; }
            public System.String EventPattern { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.Int32? RetentionDay { get; set; }
            public System.Func<Amazon.EventBridge.Model.UpdateArchiveResponse, UpdateEVBArchiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
