/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Organizations sends email on your behalf to the email address that is associated with
    /// the other account's owner. The invitation is implemented as a <a>Handshake</a> whose
    /// details are in the response.
    /// 
    ///  <important><para>
    /// You can invite AWS accounts only from the same reseller as the master account. For
    /// example, if your organization's master account was created by Amazon Internet Services
    /// Pvt. Ltd (AISPL), an AWS reseller in India, then you can only invite other AISPL accounts
    /// to your organization. You can't combine accounts from AISPL and AWS. For more information,
    /// see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/useconsolidatedbilliing-India.html">Consolidated
    /// Billing in India</a>.
    /// </para></important><para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ORGAccountInvitation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Invokes the InviteAccountToOrganization operation against AWS Organizations.", Operation = new[] {"InviteAccountToOrganization"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake",
        "This cmdlet returns a Handshake object.",
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
        [System.Management.Automation.Parameter]
        public System.String Target_Id { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>Additional information that you want to include in the generated email to the recipient
        /// account owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter Target_Type
        /// <summary>
        /// <para>
        /// <para>The type of party.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Organizations.HandshakePartyType")]
        public Amazon.Organizations.HandshakePartyType Target_Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Target_Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGAccountInvitation (InviteAccountToOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Notes = this.Note;
            context.Target_Id = this.Target_Id;
            context.Target_Type = this.Target_Type;
            
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
            
            if (cmdletContext.Notes != null)
            {
                request.Notes = cmdletContext.Notes;
            }
            
             // populate Target
            bool requestTargetIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Handshake;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            #if DESKTOP
            return client.InviteAccountToOrganization(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.InviteAccountToOrganizationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Notes { get; set; }
            public System.String Target_Id { get; set; }
            public Amazon.Organizations.HandshakePartyType Target_Type { get; set; }
        }
        
    }
}
