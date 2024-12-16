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
    /// Removes a member account from its parent organization. This version of the operation
    /// is performed by the account that wants to leave. To remove a member account as a user
    /// in the management account, use <a>RemoveAccountFromOrganization</a> instead.
    /// 
    ///  
    /// <para>
    /// This operation can be called only from a member account in the organization.
    /// </para><important><ul><li><para>
    /// The management account in an organization with all features enabled can set service
    /// control policies (SCPs) that can restrict what administrators of member accounts can
    /// do. This includes preventing them from successfully calling <c>LeaveOrganization</c>
    /// and leaving the organization.
    /// </para></li><li><para>
    /// You can leave an organization as a member account only if the account is configured
    /// with the information required to operate as a standalone account. When you create
    /// an account in an organization using the Organizations console, API, or CLI commands,
    /// the information required of standalone accounts is <i>not</i> automatically collected.
    /// For each account that you want to make standalone, you must perform the following
    /// steps. If any of the steps are already completed for this account, that step doesn't
    /// appear.
    /// </para><ul><li><para>
    /// Choose a support plan
    /// </para></li><li><para>
    /// Provide and verify the required contact information
    /// </para></li><li><para>
    /// Provide a current payment method
    /// </para></li></ul><para>
    /// Amazon Web Services uses the payment method to charge for any billable (not free tier)
    /// Amazon Web Services activity that occurs while the account isn't attached to an organization.
    /// For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_account-before-remove.html">Considerations
    /// before removing an account from an organization</a> in the <i>Organizations User Guide</i>.
    /// </para></li><li><para>
    /// The account that you want to leave must not be a delegated administrator account for
    /// any Amazon Web Services service enabled for your organization. If the account is a
    /// delegated administrator, you must first change the delegated administrator account
    /// to another account that is remaining in the organization.
    /// </para></li><li><para>
    /// You can leave an organization only after you enable IAM user access to billing in
    /// your account. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/grantaccess.html#ControllingAccessWebsite-Activate">About
    /// IAM access to the Billing and Cost Management console</a> in the <i>Amazon Web Services
    /// Billing and Cost Management User Guide</i>.
    /// </para></li><li><para>
    /// After the account leaves the organization, all tags that were attached to the account
    /// object in the organization are deleted. Amazon Web Services accounts outside of an
    /// organization do not support tags.
    /// </para></li><li><para>
    /// A newly created account has a waiting period before it can be removed from its organization.
    /// You must wait until at least seven days after the account was created. Invited accounts
    /// aren't subject to this waiting period.
    /// </para></li><li><para>
    /// If you are using an organization principal to call <c>LeaveOrganization</c> across
    /// multiple accounts, you can only do this up to 5 accounts per second in a single organization.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Remove", "ORGOrganizationAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Organizations LeaveOrganization API operation.", Operation = new[] {"LeaveOrganization"}, SelectReturnType = typeof(Amazon.Organizations.Model.LeaveOrganizationResponse))]
    [AWSCmdletOutput("None or Amazon.Organizations.Model.LeaveOrganizationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Organizations.Model.LeaveOrganizationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveORGOrganizationAssociationCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.LeaveOrganizationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ORGOrganizationAssociation (LeaveOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.LeaveOrganizationResponse, RemoveORGOrganizationAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Organizations.Model.LeaveOrganizationRequest();
            
            
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
        
        private Amazon.Organizations.Model.LeaveOrganizationResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.LeaveOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "LeaveOrganization");
            try
            {
                #if DESKTOP
                return client.LeaveOrganization(request);
                #elif CORECLR
                return client.LeaveOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Organizations.Model.LeaveOrganizationResponse, RemoveORGOrganizationAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
