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
using Amazon.Account;
using Amazon.Account.Model;

namespace Amazon.PowerShell.Cmdlets.ACCT
{
    /// <summary>
    /// Retrieves the specified alternate contact attached to an Amazon Web Services account.
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
    [Cmdlet("Get", "ACCTAlternateContact")]
    [OutputType("Amazon.Account.Model.AlternateContact")]
    [AWSCmdlet("Calls the AWS Account GetAlternateContact API operation.", Operation = new[] {"GetAlternateContact"}, SelectReturnType = typeof(Amazon.Account.Model.GetAlternateContactResponse))]
    [AWSCmdletOutput("Amazon.Account.Model.AlternateContact or Amazon.Account.Model.GetAlternateContactResponse",
        "This cmdlet returns an Amazon.Account.Model.AlternateContact object.",
        "The service call response (type Amazon.Account.Model.GetAlternateContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACCTAlternateContactCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>Specifies which alternate contact you want to retrieve.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AlternateContact'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.GetAlternateContactResponse).
        /// Specifying the name of a property of type Amazon.Account.Model.GetAlternateContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AlternateContact";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AlternateContactType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AlternateContactType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AlternateContactType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Account.Model.GetAlternateContactResponse, GetACCTAlternateContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AlternateContactType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.Account.Model.GetAlternateContactRequest();
            
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
        
        private Amazon.Account.Model.GetAlternateContactResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.GetAlternateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "GetAlternateContact");
            try
            {
                #if DESKTOP
                return client.GetAlternateContact(request);
                #elif CORECLR
                return client.GetAlternateContactAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Account.AlternateContactType AlternateContactType { get; set; }
            public System.Func<Amazon.Account.Model.GetAlternateContactResponse, GetACCTAlternateContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AlternateContact;
        }
        
    }
}
