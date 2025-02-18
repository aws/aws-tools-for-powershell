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
using Amazon.Account;
using Amazon.Account.Model;

namespace Amazon.PowerShell.Cmdlets.ACCT
{
    /// <summary>
    /// Deletes the specified alternate contact from an Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// For complete details about how to use the alternate contact operations, see <a href="https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-update-contact.html">Access
    /// or updating the alternate contacts</a>.
    /// </para><note><para>
    /// Before you can update the alternate contact information for an Amazon Web Services
    /// account that is managed by Organizations, you must first enable integration between
    /// Amazon Web Services Account Management and Organizations. For more information, see
    /// <a href="https://docs.aws.amazon.com/accounts/latest/reference/using-orgs-trusted-access.html">Enabling
    /// trusted access for Amazon Web Services Account Management</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "ACCTAlternateContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Account DeleteAlternateContact API operation.", Operation = new[] {"DeleteAlternateContact"}, SelectReturnType = typeof(Amazon.Account.Model.DeleteAlternateContactResponse))]
    [AWSCmdletOutput("None or Amazon.Account.Model.DeleteAlternateContactResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Account.Model.DeleteAlternateContactResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveACCTAlternateContactCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the 12 digit account ID number of the Amazon Web Services account that you
        /// want to access or modify with this operation.</para><para>If you do not specify this parameter, it defaults to the Amazon Web Services account
        /// of the identity used to call the operation.</para><para>To use this parameter, the caller must be an identity in the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">organization's
        /// management account</a> or a delegated administrator account, and the specified account
        /// ID must be a member account in the same organization. The organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
        /// features enabled</a>, and the organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-trusted-access.html">trusted
        /// access</a> enabled for the Account Management service, and optionally a <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-delegated-admin.html">delegated
        /// admin</a> account assigned.</para><note><para>The management account can't specify its own <c>AccountId</c>; it must call the operation
        /// in standalone context by not including the <c>AccountId</c> parameter.</para></note><para>To call this operation on an account that is not a member of an organization, then
        /// don't specify this parameter, and call the operation using an identity belonging to
        /// the account whose contacts you wish to retrieve or modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AlternateContactType
        /// <summary>
        /// <para>
        /// <para>Specifies which of the alternate contacts to delete. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Account.AlternateContactType")]
        public Amazon.Account.AlternateContactType AlternateContactType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.DeleteAlternateContactResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ACCTAlternateContact (DeleteAlternateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Account.Model.DeleteAlternateContactResponse, RemoveACCTAlternateContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.AlternateContactType = this.AlternateContactType;
            #if MODULAR
            if (this.AlternateContactType == null && ParameterWasBound(nameof(this.AlternateContactType)))
            {
                WriteWarning("You are passing $null as a value for parameter AlternateContactType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Account.Model.DeleteAlternateContactRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AlternateContactType != null)
            {
                request.AlternateContactType = cmdletContext.AlternateContactType;
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
        
        private Amazon.Account.Model.DeleteAlternateContactResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.DeleteAlternateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "DeleteAlternateContact");
            try
            {
                return client.DeleteAlternateContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.Account.AlternateContactType AlternateContactType { get; set; }
            public System.Func<Amazon.Account.Model.DeleteAlternateContactResponse, RemoveACCTAlternateContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
