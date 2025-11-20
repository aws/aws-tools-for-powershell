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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Sends an invitation to another organization's management account to designate your
    /// account with the specified responsibilities for their organization. The invitation
    /// is implemented as a <a>Handshake</a> whose details are in the response.
    /// 
    ///  
    /// <para>
    /// You can only call this operation from the management account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ORGOrganizationToTransferResponsibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations InviteOrganizationToTransferResponsibility API operation.", Operation = new[] {"InviteOrganizationToTransferResponsibility"}, SelectReturnType = typeof(Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake or Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Handshake object.",
        "The service call response (type Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewORGOrganizationToTransferResponsibilityCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Target_Id
        /// <summary>
        /// <para>
        /// <para>ID for the participant: Acccount ID, organization ID, or email address.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for handshake ID string
        /// requires "h-" followed by from 8 to 32 lowercase letters or digits.</para>
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
        public System.String Target_Id { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>Additional information that you want to include in the invitation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter SourceName
        /// <summary>
        /// <para>
        /// <para>Name you want to assign to the transfer.</para>
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
        public System.String SourceName { get; set; }
        #endregion
        
        #region Parameter StartTimestamp
        /// <summary>
        /// <para>
        /// <para>Timestamp when the recipient will begin managing the specified responsibilities.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTimestamp { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the transfer. For each tag in the list,
        /// you must specify both a tag key and a value. You can set the value to an empty string,
        /// but you can't set it to <c>null</c>. For more information about tagging, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_tagging.html">Tagging
        /// Organizations resources</a> in the Organizations User Guide.</para><important><para>Any tags in the request are checked for compliance with any applicable tag policies
        /// when the request is made. The request is rejected if the tags in the request don't
        /// match the requirements of the policy at that time. Tag policy compliance is <i><b>not</b></i> checked again when the invitation is accepted and the tags are actually attached
        /// to the transfer. That means that if the tag policy changes between the invitation
        /// and the acceptance, then that tags could potentially be non-compliant.</para></important><note><para>If any one of the tags is not valid or if you exceed the allowed number of tags for
        /// a transfer, then the entire request fails and invitations are not sent.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Organizations.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Target_Type
        /// <summary>
        /// <para>
        /// <para>The type of ID for the participant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Organizations.HandshakePartyType")]
        public Amazon.Organizations.HandshakePartyType Target_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of responsibility you want to designate to your organization. Currently,
        /// only <c>BILLING</c> is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Organizations.ResponsibilityTransferType")]
        public Amazon.Organizations.ResponsibilityTransferType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Handshake'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Handshake";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGOrganizationToTransferResponsibility (InviteOrganizationToTransferResponsibility)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse, NewORGOrganizationToTransferResponsibilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Note = this.Note;
            context.SourceName = this.SourceName;
            #if MODULAR
            if (this.SourceName == null && ParameterWasBound(nameof(this.SourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTimestamp = this.StartTimestamp;
            #if MODULAR
            if (this.StartTimestamp == null && ParameterWasBound(nameof(this.StartTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Organizations.Model.Tag>(this.Tag);
            }
            context.Target_Id = this.Target_Id;
            #if MODULAR
            if (this.Target_Id == null && ParameterWasBound(nameof(this.Target_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_Type = this.Target_Type;
            #if MODULAR
            if (this.Target_Type == null && ParameterWasBound(nameof(this.Target_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityRequest();
            
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            if (cmdletContext.SourceName != null)
            {
                request.SourceName = cmdletContext.SourceName;
            }
            if (cmdletContext.StartTimestamp != null)
            {
                request.StartTimestamp = cmdletContext.StartTimestamp.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.Organizations.Model.HandshakeParty();
            System.String requestTarget_target_Id = null;
            if (cmdletContext.Target_Id != null)
            {
                requestTarget_target_Id = cmdletContext.Target_Id;
            }
            if (requestTarget_target_Id != null)
            {
                request.Target.Id = requestTarget_target_Id;
                requestTargetIsNull = false;
            }
            Amazon.Organizations.HandshakePartyType requestTarget_target_Type = null;
            if (cmdletContext.Target_Type != null)
            {
                requestTarget_target_Type = cmdletContext.Target_Type;
            }
            if (requestTarget_target_Type != null)
            {
                request.Target.Type = requestTarget_target_Type;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "InviteOrganizationToTransferResponsibility");
            try
            {
                #if DESKTOP
                return client.InviteOrganizationToTransferResponsibility(request);
                #elif CORECLR
                return client.InviteOrganizationToTransferResponsibilityAsync(request).GetAwaiter().GetResult();
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
            public System.String Note { get; set; }
            public System.String SourceName { get; set; }
            public System.DateTime? StartTimestamp { get; set; }
            public List<Amazon.Organizations.Model.Tag> Tag { get; set; }
            public System.String Target_Id { get; set; }
            public Amazon.Organizations.HandshakePartyType Target_Type { get; set; }
            public Amazon.Organizations.ResponsibilityTransferType Type { get; set; }
            public System.Func<Amazon.Organizations.Model.InviteOrganizationToTransferResponsibilityResponse, NewORGOrganizationToTransferResponsibilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Handshake;
        }
        
    }
}
