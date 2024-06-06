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
    /// Retrieves the opt-in status of a particular Region.
    /// </summary>
    [Cmdlet("Get", "ACCTRegionOptStatus")]
    [OutputType("Amazon.Account.RegionOptStatus")]
    [AWSCmdlet("Calls the AWS Account GetRegionOptStatus API operation.", Operation = new[] {"GetRegionOptStatus"}, SelectReturnType = typeof(Amazon.Account.Model.GetRegionOptStatusResponse))]
    [AWSCmdletOutput("Amazon.Account.RegionOptStatus or Amazon.Account.Model.GetRegionOptStatusResponse",
        "This cmdlet returns an Amazon.Account.RegionOptStatus object.",
        "The service call response (type Amazon.Account.Model.GetRegionOptStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetACCTRegionOptStatusCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the 12-digit account ID number of the Amazon Web Services account that you
        /// want to access or modify with this operation. If you don't specify this parameter,
        /// it defaults to the Amazon Web Services account of the identity used to call the operation.
        /// To use this parameter, the caller must be an identity in the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">organization's
        /// management account</a> or a delegated administrator account. The specified account
        /// ID must be a member account in the same organization. The organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
        /// features enabled</a>, and the organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-trusted-access.html">trusted
        /// access</a> enabled for the Account Management service, and optionally a <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-delegated-admin.html">delegated
        /// admin</a> account assigned.</para><note><para>The management account can't specify its own <c>AccountId</c>. It must call the operation
        /// in standalone context by not including the <c>AccountId</c> parameter.</para></note><para>To call this operation on an account that is not a member of an organization, don't
        /// specify this parameter. Instead, call the operation using an identity belonging to
        /// the account whose contacts you wish to retrieve or modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>Specifies the Region-code for a given Region name (for example, <c>af-south-1</c>).
        /// This function will return the status of whatever Region you pass into this parameter.
        /// </para>
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
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegionOptStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.GetRegionOptStatusResponse).
        /// Specifying the name of a property of type Amazon.Account.Model.GetRegionOptStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegionOptStatus";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Account.Model.GetRegionOptStatusResponse, GetACCTRegionOptStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.RegionName = this.RegionName;
            #if MODULAR
            if (this.RegionName == null && ParameterWasBound(nameof(this.RegionName)))
            {
                WriteWarning("You are passing $null as a value for parameter RegionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Account.Model.GetRegionOptStatusRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionName = cmdletContext.RegionName;
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
        
        private Amazon.Account.Model.GetRegionOptStatusResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.GetRegionOptStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "GetRegionOptStatus");
            try
            {
                #if DESKTOP
                return client.GetRegionOptStatus(request);
                #elif CORECLR
                return client.GetRegionOptStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String RegionName { get; set; }
            public System.Func<Amazon.Account.Model.GetRegionOptStatusResponse, GetACCTRegionOptStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegionOptStatus;
        }
        
    }
}
