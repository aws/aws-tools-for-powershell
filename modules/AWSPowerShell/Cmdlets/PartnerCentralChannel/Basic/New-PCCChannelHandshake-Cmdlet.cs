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
using Amazon.PartnerCentralChannel;
using Amazon.PartnerCentralChannel.Model;

namespace Amazon.PowerShell.Cmdlets.PCC
{
    /// <summary>
    /// Creates a new channel handshake request to establish a partnership with another AWS
    /// account.
    /// </summary>
    [Cmdlet("New", "PCCChannelHandshake", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeDetail")]
    [AWSCmdlet("Calls the Partner Central Channel API CreateChannelHandshake API operation.", Operation = new[] {"CreateChannelHandshake"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeDetail or Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse",
        "This cmdlet returns an Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeDetail object.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCCChannelHandshakeCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociatedResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with this handshake.</para>
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
        public System.String AssociatedResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier for the handshake request.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodPayload_EndDate
        /// <summary>
        /// <para>
        /// <para>The end date of the service period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_StartServicePeriodPayload_EndDate")]
        public System.DateTime? StartServicePeriodPayload_EndDate { get; set; }
        #endregion
        
        #region Parameter HandshakeType
        /// <summary>
        /// <para>
        /// <para>The type of handshake to create (e.g., start service period, revoke service period).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.HandshakeType")]
        public Amazon.PartnerCentralChannel.HandshakeType HandshakeType { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodPayload_MinimumNoticeDay
        /// <summary>
        /// <para>
        /// <para>The minimum number of days notice required for changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_StartServicePeriodPayload_MinimumNoticeDays")]
        public System.String StartServicePeriodPayload_MinimumNoticeDay { get; set; }
        #endregion
        
        #region Parameter RevokeServicePeriodPayload_Note
        /// <summary>
        /// <para>
        /// <para>A note explaining the reason for revoking the service period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_RevokeServicePeriodPayload_Note")]
        public System.String RevokeServicePeriodPayload_Note { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodPayload_Note
        /// <summary>
        /// <para>
        /// <para>A note providing additional information about the service period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_StartServicePeriodPayload_Note")]
        public System.String StartServicePeriodPayload_Note { get; set; }
        #endregion
        
        #region Parameter RevokeServicePeriodPayload_ProgramManagementAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the program management account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_RevokeServicePeriodPayload_ProgramManagementAccountIdentifier")]
        public System.String RevokeServicePeriodPayload_ProgramManagementAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodPayload_ProgramManagementAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the program management account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_StartServicePeriodPayload_ProgramManagementAccountIdentifier")]
        public System.String StartServicePeriodPayload_ProgramManagementAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter StartServicePeriodPayload_ServicePeriodType
        /// <summary>
        /// <para>
        /// <para>The type of service period being started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_StartServicePeriodPayload_ServicePeriodType")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ServicePeriodType")]
        public Amazon.PartnerCentralChannel.ServicePeriodType StartServicePeriodPayload_ServicePeriodType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with the channel handshake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralChannel.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelHandshakeDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelHandshakeDetail";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociatedResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCCChannelHandshake (CreateChannelHandshake)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse, NewPCCChannelHandshakeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatedResourceIdentifier = this.AssociatedResourceIdentifier;
            #if MODULAR
            if (this.AssociatedResourceIdentifier == null && ParameterWasBound(nameof(this.AssociatedResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.HandshakeType = this.HandshakeType;
            #if MODULAR
            if (this.HandshakeType == null && ParameterWasBound(nameof(this.HandshakeType)))
            {
                WriteWarning("You are passing $null as a value for parameter HandshakeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevokeServicePeriodPayload_Note = this.RevokeServicePeriodPayload_Note;
            context.RevokeServicePeriodPayload_ProgramManagementAccountIdentifier = this.RevokeServicePeriodPayload_ProgramManagementAccountIdentifier;
            context.StartServicePeriodPayload_EndDate = this.StartServicePeriodPayload_EndDate;
            context.StartServicePeriodPayload_MinimumNoticeDay = this.StartServicePeriodPayload_MinimumNoticeDay;
            context.StartServicePeriodPayload_Note = this.StartServicePeriodPayload_Note;
            context.StartServicePeriodPayload_ProgramManagementAccountIdentifier = this.StartServicePeriodPayload_ProgramManagementAccountIdentifier;
            context.StartServicePeriodPayload_ServicePeriodType = this.StartServicePeriodPayload_ServicePeriodType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralChannel.Model.Tag>(this.Tag);
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
            var request = new Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeRequest();
            
            if (cmdletContext.AssociatedResourceIdentifier != null)
            {
                request.AssociatedResourceIdentifier = cmdletContext.AssociatedResourceIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.HandshakeType != null)
            {
                request.HandshakeType = cmdletContext.HandshakeType;
            }
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.PartnerCentralChannel.Model.ChannelHandshakePayload();
            Amazon.PartnerCentralChannel.Model.RevokeServicePeriodPayload requestPayload_payload_RevokeServicePeriodPayload = null;
            
             // populate RevokeServicePeriodPayload
            var requestPayload_payload_RevokeServicePeriodPayloadIsNull = true;
            requestPayload_payload_RevokeServicePeriodPayload = new Amazon.PartnerCentralChannel.Model.RevokeServicePeriodPayload();
            System.String requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_Note = null;
            if (cmdletContext.RevokeServicePeriodPayload_Note != null)
            {
                requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_Note = cmdletContext.RevokeServicePeriodPayload_Note;
            }
            if (requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_Note != null)
            {
                requestPayload_payload_RevokeServicePeriodPayload.Note = requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_Note;
                requestPayload_payload_RevokeServicePeriodPayloadIsNull = false;
            }
            System.String requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_ProgramManagementAccountIdentifier = null;
            if (cmdletContext.RevokeServicePeriodPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_ProgramManagementAccountIdentifier = cmdletContext.RevokeServicePeriodPayload_ProgramManagementAccountIdentifier;
            }
            if (requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_RevokeServicePeriodPayload.ProgramManagementAccountIdentifier = requestPayload_payload_RevokeServicePeriodPayload_revokeServicePeriodPayload_ProgramManagementAccountIdentifier;
                requestPayload_payload_RevokeServicePeriodPayloadIsNull = false;
            }
             // determine if requestPayload_payload_RevokeServicePeriodPayload should be set to null
            if (requestPayload_payload_RevokeServicePeriodPayloadIsNull)
            {
                requestPayload_payload_RevokeServicePeriodPayload = null;
            }
            if (requestPayload_payload_RevokeServicePeriodPayload != null)
            {
                request.Payload.RevokeServicePeriodPayload = requestPayload_payload_RevokeServicePeriodPayload;
                requestPayloadIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.StartServicePeriodPayload requestPayload_payload_StartServicePeriodPayload = null;
            
             // populate StartServicePeriodPayload
            var requestPayload_payload_StartServicePeriodPayloadIsNull = true;
            requestPayload_payload_StartServicePeriodPayload = new Amazon.PartnerCentralChannel.Model.StartServicePeriodPayload();
            System.DateTime? requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_EndDate = null;
            if (cmdletContext.StartServicePeriodPayload_EndDate != null)
            {
                requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_EndDate = cmdletContext.StartServicePeriodPayload_EndDate.Value;
            }
            if (requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_EndDate != null)
            {
                requestPayload_payload_StartServicePeriodPayload.EndDate = requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_EndDate.Value;
                requestPayload_payload_StartServicePeriodPayloadIsNull = false;
            }
            System.String requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_MinimumNoticeDay = null;
            if (cmdletContext.StartServicePeriodPayload_MinimumNoticeDay != null)
            {
                requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_MinimumNoticeDay = cmdletContext.StartServicePeriodPayload_MinimumNoticeDay;
            }
            if (requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_MinimumNoticeDay != null)
            {
                requestPayload_payload_StartServicePeriodPayload.MinimumNoticeDays = requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_MinimumNoticeDay;
                requestPayload_payload_StartServicePeriodPayloadIsNull = false;
            }
            System.String requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_Note = null;
            if (cmdletContext.StartServicePeriodPayload_Note != null)
            {
                requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_Note = cmdletContext.StartServicePeriodPayload_Note;
            }
            if (requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_Note != null)
            {
                requestPayload_payload_StartServicePeriodPayload.Note = requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_Note;
                requestPayload_payload_StartServicePeriodPayloadIsNull = false;
            }
            System.String requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ProgramManagementAccountIdentifier = null;
            if (cmdletContext.StartServicePeriodPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ProgramManagementAccountIdentifier = cmdletContext.StartServicePeriodPayload_ProgramManagementAccountIdentifier;
            }
            if (requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_StartServicePeriodPayload.ProgramManagementAccountIdentifier = requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ProgramManagementAccountIdentifier;
                requestPayload_payload_StartServicePeriodPayloadIsNull = false;
            }
            Amazon.PartnerCentralChannel.ServicePeriodType requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ServicePeriodType = null;
            if (cmdletContext.StartServicePeriodPayload_ServicePeriodType != null)
            {
                requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ServicePeriodType = cmdletContext.StartServicePeriodPayload_ServicePeriodType;
            }
            if (requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ServicePeriodType != null)
            {
                requestPayload_payload_StartServicePeriodPayload.ServicePeriodType = requestPayload_payload_StartServicePeriodPayload_startServicePeriodPayload_ServicePeriodType;
                requestPayload_payload_StartServicePeriodPayloadIsNull = false;
            }
             // determine if requestPayload_payload_StartServicePeriodPayload should be set to null
            if (requestPayload_payload_StartServicePeriodPayloadIsNull)
            {
                requestPayload_payload_StartServicePeriodPayload = null;
            }
            if (requestPayload_payload_StartServicePeriodPayload != null)
            {
                request.Payload.StartServicePeriodPayload = requestPayload_payload_StartServicePeriodPayload;
                requestPayloadIsNull = false;
            }
             // determine if request.Payload should be set to null
            if (requestPayloadIsNull)
            {
                request.Payload = null;
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
        
        private Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "CreateChannelHandshake");
            try
            {
                #if DESKTOP
                return client.CreateChannelHandshake(request);
                #elif CORECLR
                return client.CreateChannelHandshakeAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociatedResourceIdentifier { get; set; }
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.PartnerCentralChannel.HandshakeType HandshakeType { get; set; }
            public System.String RevokeServicePeriodPayload_Note { get; set; }
            public System.String RevokeServicePeriodPayload_ProgramManagementAccountIdentifier { get; set; }
            public System.DateTime? StartServicePeriodPayload_EndDate { get; set; }
            public System.String StartServicePeriodPayload_MinimumNoticeDay { get; set; }
            public System.String StartServicePeriodPayload_Note { get; set; }
            public System.String StartServicePeriodPayload_ProgramManagementAccountIdentifier { get; set; }
            public Amazon.PartnerCentralChannel.ServicePeriodType StartServicePeriodPayload_ServicePeriodType { get; set; }
            public List<Amazon.PartnerCentralChannel.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.CreateChannelHandshakeResponse, NewPCCChannelHandshakeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelHandshakeDetail;
        }
        
    }
}
