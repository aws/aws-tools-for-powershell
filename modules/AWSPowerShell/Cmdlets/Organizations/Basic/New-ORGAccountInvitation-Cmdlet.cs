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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Sends an invitation to another account to join your organization as a member account.
    /// AWS Organizations sends email on your behalf to the email address that is associated
    /// with the other account's owner. The invitation is implemented as a <a>Handshake</a>
    /// whose details are in the response.
    /// 
    ///  <important><ul><li><para>
    /// You can invite AWS accounts only from the same seller as the master account. For example,
    /// assume that your organization's master account was created by Amazon Internet Services
    /// Pvt. Ltd (AISPL), an AWS seller in India. You can invite only other AISPL accounts
    /// to your organization. You can't combine accounts from AISPL and AWS or from any other
    /// AWS seller. For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/useconsolidatedbilliing-India.html">Consolidated
    /// Billing in India</a>.
    /// </para></li><li><para>
    /// You might receive an exception that indicates that you exceeded your account limits
    /// for the organization or that the operation failed because your organization is still
    /// initializing. If so, wait one hour and then try again. If the error persists after
    /// an hour, contact <a href="https://console.aws.amazon.com/support/home#/">AWS Support</a>.
    /// </para></li></ul></important><para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ORGAccountInvitation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations InviteAccountToOrganization API operation.", Operation = new[] {"InviteAccountToOrganization"}, SelectReturnType = typeof(Amazon.Organizations.Model.InviteAccountToOrganizationResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake or Amazon.Organizations.Model.InviteAccountToOrganizationResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Handshake object.",
        "The service call response (type Amazon.Organizations.Model.InviteAccountToOrganizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewORGAccountInvitationCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter Target_Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) for the party.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for handshake ID string
        /// requires "h-" followed by from 8 to 32 lower-case letters or digits.</para>
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
        public System.String Target_Id { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>Additional information that you want to include in the generated email to the recipient
        /// account owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter Target_Type
        /// <summary>
        /// <para>
        /// <para>The type of party.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Handshake'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.InviteAccountToOrganizationResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.InviteAccountToOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Handshake";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Target_Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Target_Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Target_Id' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Target_Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGAccountInvitation (InviteAccountToOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.InviteAccountToOrganizationResponse, NewORGAccountInvitationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Target_Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Note = this.Note;
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
            var request = new Amazon.Organizations.Model.InviteAccountToOrganizationRequest();
            
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
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
        
        private Amazon.Organizations.Model.InviteAccountToOrganizationResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.InviteAccountToOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "InviteAccountToOrganization");
            try
            {
                #if DESKTOP
                return client.InviteAccountToOrganization(request);
                #elif CORECLR
                return client.InviteAccountToOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.String Target_Id { get; set; }
            public Amazon.Organizations.HandshakePartyType Target_Type { get; set; }
            public System.Func<Amazon.Organizations.Model.InviteAccountToOrganizationResponse, NewORGAccountInvitationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Handshake;
        }
        
    }
}
