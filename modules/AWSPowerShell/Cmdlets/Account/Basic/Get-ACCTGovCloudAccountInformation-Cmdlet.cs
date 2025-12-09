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
    /// Retrieves information about the GovCloud account linked to the specified standard
    /// account (if it exists) including the GovCloud account ID and state. To use this API,
    /// an IAM user or role must have the <c>account:GetGovCloudAccountInformation</c> IAM
    /// permission.
    /// </summary>
    [Cmdlet("Get", "ACCTGovCloudAccountInformation")]
    [OutputType("Amazon.Account.Model.GetGovCloudAccountInformationResponse")]
    [AWSCmdlet("Calls the AWS Account GetGovCloudAccountInformation API operation.", Operation = new[] {"GetGovCloudAccountInformation"}, SelectReturnType = typeof(Amazon.Account.Model.GetGovCloudAccountInformationResponse))]
    [AWSCmdletOutput("Amazon.Account.Model.GetGovCloudAccountInformationResponse",
        "This cmdlet returns an Amazon.Account.Model.GetGovCloudAccountInformationResponse object containing multiple properties."
    )]
    public partial class GetACCTGovCloudAccountInformationCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StandardAccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the 12 digit account ID number of the Amazon Web Services account that you
        /// want to access or modify with this operation.</para><para>If you do not specify this parameter, it defaults to the Amazon Web Services account
        /// of the identity used to call the operation.</para><para>To use this parameter, the caller must be an identity in the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">organization's
        /// management account</a> or a delegated administrator account, and the specified account
        /// ID must be a member account in the same organization. The organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
        /// features enabled</a>, and the organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/services-that-can-integrate-account.html">trusted
        /// access</a> enabled for the Account Management service, and optionally a <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#delegated-admin">delegated
        /// administrator</a> account assigned.</para><note><para>The management account can't specify its own <c>AccountId</c>; it must call the operation
        /// in standalone context by not including the <c>AccountId</c> parameter.</para></note><para>To call this operation on an account that is not a member of an organization, then
        /// don't specify this parameter, and call the operation using an identity belonging to
        /// the account whose contacts you wish to retrieve or modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StandardAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.GetGovCloudAccountInformationResponse).
        /// Specifying the name of a property of type Amazon.Account.Model.GetGovCloudAccountInformationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StandardAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StandardAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StandardAccountId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Account.Model.GetGovCloudAccountInformationResponse, GetACCTGovCloudAccountInformationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StandardAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StandardAccountId = this.StandardAccountId;
            
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
            var request = new Amazon.Account.Model.GetGovCloudAccountInformationRequest();
            
            if (cmdletContext.StandardAccountId != null)
            {
                request.StandardAccountId = cmdletContext.StandardAccountId;
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
        
        private Amazon.Account.Model.GetGovCloudAccountInformationResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.GetGovCloudAccountInformationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "GetGovCloudAccountInformation");
            try
            {
                #if DESKTOP
                return client.GetGovCloudAccountInformation(request);
                #elif CORECLR
                return client.GetGovCloudAccountInformationAsync(request).GetAwaiter().GetResult();
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
            public System.String StandardAccountId { get; set; }
            public System.Func<Amazon.Account.Model.GetGovCloudAccountInformationResponse, GetACCTGovCloudAccountInformationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
