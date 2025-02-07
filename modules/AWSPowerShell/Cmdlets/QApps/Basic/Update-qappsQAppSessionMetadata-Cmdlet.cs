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
using Amazon.QApps;
using Amazon.QApps.Model;

namespace Amazon.PowerShell.Cmdlets.qapps
{
    /// <summary>
    /// Updates the configuration metadata of a session for a given Q App <c>sessionId</c>.
    /// </summary>
    [Cmdlet("Update", "qappsQAppSessionMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QApps.Model.UpdateQAppSessionMetadataResponse")]
    [AWSCmdlet("Calls the Amazon Q Apps UpdateQAppSessionMetadata API operation.", Operation = new[] {"UpdateQAppSessionMetadata"}, SelectReturnType = typeof(Amazon.QApps.Model.UpdateQAppSessionMetadataResponse))]
    [AWSCmdletOutput("Amazon.QApps.Model.UpdateQAppSessionMetadataResponse",
        "This cmdlet returns an Amazon.QApps.Model.UpdateQAppSessionMetadataResponse object containing multiple properties."
    )]
    public partial class UpdateqappsQAppSessionMetadataCmdlet : AmazonQAppsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SharingConfiguration_AcceptResponse
        /// <summary>
        /// <para>
        /// <para>Indicates whether an Q App session can accept responses from users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SharingConfiguration_AcceptResponses")]
        public System.Boolean? SharingConfiguration_AcceptResponse { get; set; }
        #endregion
        
        #region Parameter SharingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether an Q App session is shareable with other users.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? SharingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Q Business application environment instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter SharingConfiguration_RevealCard
        /// <summary>
        /// <para>
        /// <para>Indicates whether collected responses for an Q App session are revealed for all users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SharingConfiguration_RevealCards")]
        public System.Boolean? SharingConfiguration_RevealCard { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Q App session to update configuration for.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter SessionName
        /// <summary>
        /// <para>
        /// <para>The new name for the Q App session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QApps.Model.UpdateQAppSessionMetadataResponse).
        /// Specifying the name of a property of type Amazon.QApps.Model.UpdateQAppSessionMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-qappsQAppSessionMetadata (UpdateQAppSessionMetadata)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QApps.Model.UpdateQAppSessionMetadataResponse, UpdateqappsQAppSessionMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionName = this.SessionName;
            context.SharingConfiguration_AcceptResponse = this.SharingConfiguration_AcceptResponse;
            context.SharingConfiguration_Enabled = this.SharingConfiguration_Enabled;
            #if MODULAR
            if (this.SharingConfiguration_Enabled == null && ParameterWasBound(nameof(this.SharingConfiguration_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter SharingConfiguration_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SharingConfiguration_RevealCard = this.SharingConfiguration_RevealCard;
            
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
            var request = new Amazon.QApps.Model.UpdateQAppSessionMetadataRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.SessionName != null)
            {
                request.SessionName = cmdletContext.SessionName;
            }
            
             // populate SharingConfiguration
            var requestSharingConfigurationIsNull = true;
            request.SharingConfiguration = new Amazon.QApps.Model.SessionSharingConfiguration();
            System.Boolean? requestSharingConfiguration_sharingConfiguration_AcceptResponse = null;
            if (cmdletContext.SharingConfiguration_AcceptResponse != null)
            {
                requestSharingConfiguration_sharingConfiguration_AcceptResponse = cmdletContext.SharingConfiguration_AcceptResponse.Value;
            }
            if (requestSharingConfiguration_sharingConfiguration_AcceptResponse != null)
            {
                request.SharingConfiguration.AcceptResponses = requestSharingConfiguration_sharingConfiguration_AcceptResponse.Value;
                requestSharingConfigurationIsNull = false;
            }
            System.Boolean? requestSharingConfiguration_sharingConfiguration_Enabled = null;
            if (cmdletContext.SharingConfiguration_Enabled != null)
            {
                requestSharingConfiguration_sharingConfiguration_Enabled = cmdletContext.SharingConfiguration_Enabled.Value;
            }
            if (requestSharingConfiguration_sharingConfiguration_Enabled != null)
            {
                request.SharingConfiguration.Enabled = requestSharingConfiguration_sharingConfiguration_Enabled.Value;
                requestSharingConfigurationIsNull = false;
            }
            System.Boolean? requestSharingConfiguration_sharingConfiguration_RevealCard = null;
            if (cmdletContext.SharingConfiguration_RevealCard != null)
            {
                requestSharingConfiguration_sharingConfiguration_RevealCard = cmdletContext.SharingConfiguration_RevealCard.Value;
            }
            if (requestSharingConfiguration_sharingConfiguration_RevealCard != null)
            {
                request.SharingConfiguration.RevealCards = requestSharingConfiguration_sharingConfiguration_RevealCard.Value;
                requestSharingConfigurationIsNull = false;
            }
             // determine if request.SharingConfiguration should be set to null
            if (requestSharingConfigurationIsNull)
            {
                request.SharingConfiguration = null;
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
        
        private Amazon.QApps.Model.UpdateQAppSessionMetadataResponse CallAWSServiceOperation(IAmazonQApps client, Amazon.QApps.Model.UpdateQAppSessionMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Apps", "UpdateQAppSessionMetadata");
            try
            {
                #if DESKTOP
                return client.UpdateQAppSessionMetadata(request);
                #elif CORECLR
                return client.UpdateQAppSessionMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String SessionId { get; set; }
            public System.String SessionName { get; set; }
            public System.Boolean? SharingConfiguration_AcceptResponse { get; set; }
            public System.Boolean? SharingConfiguration_Enabled { get; set; }
            public System.Boolean? SharingConfiguration_RevealCard { get; set; }
            public System.Func<Amazon.QApps.Model.UpdateQAppSessionMetadataResponse, UpdateqappsQAppSessionMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
