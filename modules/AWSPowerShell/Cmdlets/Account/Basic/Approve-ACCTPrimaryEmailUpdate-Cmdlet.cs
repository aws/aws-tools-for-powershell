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
using Amazon.Account;
using Amazon.Account.Model;

namespace Amazon.PowerShell.Cmdlets.ACCT
{
    /// <summary>
    /// Accepts the request that originated from <a>StartPrimaryEmailUpdate</a> to update
    /// the primary email address (also known as the root user email address) for the specified
    /// account.
    /// </summary>
    [Cmdlet("Approve", "ACCTPrimaryEmailUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Account.PrimaryEmailUpdateStatus")]
    [AWSCmdlet("Calls the AWS Account AcceptPrimaryEmailUpdate API operation.", Operation = new[] {"AcceptPrimaryEmailUpdate"}, SelectReturnType = typeof(Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse))]
    [AWSCmdletOutput("Amazon.Account.PrimaryEmailUpdateStatus or Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse",
        "This cmdlet returns an Amazon.Account.PrimaryEmailUpdateStatus object.",
        "The service call response (type Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ApproveACCTPrimaryEmailUpdateCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the 12-digit account ID number of the Amazon Web Services account that you
        /// want to access or modify with this operation. To use this parameter, the caller must
        /// be an identity in the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">organization's
        /// management account</a> or a delegated administrator account. The specified account
        /// ID must be a member account in the same organization. The organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
        /// features enabled</a>, and the organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-trusted-access.html">trusted
        /// access</a> enabled for the Account Management service, and optionally a <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-delegated-admin.html">delegated
        /// admin</a> account assigned.</para><para>This operation can only be called from the management account or the delegated administrator
        /// account of an organization for a member account.</para><note><para>The management account can't specify its own <c>AccountId</c>.</para></note>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Otp
        /// <summary>
        /// <para>
        /// <para>The OTP code sent to the <c>PrimaryEmail</c> specified on the <c>StartPrimaryEmailUpdate</c>
        /// API call.</para>
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
        public System.String Otp { get; set; }
        #endregion
        
        #region Parameter PrimaryEmail
        /// <summary>
        /// <para>
        /// <para>The new primary email address for use with the specified account. This must match
        /// the <c>PrimaryEmail</c> from the <c>StartPrimaryEmailUpdate</c> API call.</para>
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
        public System.String PrimaryEmail { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse).
        /// Specifying the name of a property of type Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-ACCTPrimaryEmailUpdate (AcceptPrimaryEmailUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse, ApproveACCTPrimaryEmailUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Otp = this.Otp;
            #if MODULAR
            if (this.Otp == null && ParameterWasBound(nameof(this.Otp)))
            {
                WriteWarning("You are passing $null as a value for parameter Otp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryEmail = this.PrimaryEmail;
            #if MODULAR
            if (this.PrimaryEmail == null && ParameterWasBound(nameof(this.PrimaryEmail)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryEmail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Account.Model.AcceptPrimaryEmailUpdateRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Otp != null)
            {
                request.Otp = cmdletContext.Otp;
            }
            if (cmdletContext.PrimaryEmail != null)
            {
                request.PrimaryEmail = cmdletContext.PrimaryEmail;
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
        
        private Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.AcceptPrimaryEmailUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "AcceptPrimaryEmailUpdate");
            try
            {
                #if DESKTOP
                return client.AcceptPrimaryEmailUpdate(request);
                #elif CORECLR
                return client.AcceptPrimaryEmailUpdateAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String Otp { get; set; }
            public System.String PrimaryEmail { get; set; }
            public System.Func<Amazon.Account.Model.AcceptPrimaryEmailUpdateResponse, ApproveACCTPrimaryEmailUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
