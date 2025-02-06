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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// List all WhatsApp Business Accounts linked to your Amazon Web Services account.
    /// </summary>
    [Cmdlet("Get", "SOCIALLinkedWhatsAppBusinessAccountList")]
    [OutputType("Amazon.SocialMessaging.Model.LinkedWhatsAppBusinessAccountSummary")]
    [AWSCmdlet("Calls the AWS End User Messaging Social ListLinkedWhatsAppBusinessAccounts API operation.", Operation = new[] {"ListLinkedWhatsAppBusinessAccounts"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse))]
    [AWSCmdletOutput("Amazon.SocialMessaging.Model.LinkedWhatsAppBusinessAccountSummary or Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse",
        "This cmdlet returns a collection of Amazon.SocialMessaging.Model.LinkedWhatsAppBusinessAccountSummary objects.",
        "The service call response (type Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSOCIALLinkedWhatsAppBusinessAccountListCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The next token for pagination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LinkedAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LinkedAccounts";
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
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse, GetSOCIALLinkedWhatsAppBusinessAccountListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "ListLinkedWhatsAppBusinessAccounts");
            try
            {
                #if DESKTOP
                return client.ListLinkedWhatsAppBusinessAccounts(request);
                #elif CORECLR
                return client.ListLinkedWhatsAppBusinessAccountsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.ListLinkedWhatsAppBusinessAccountsResponse, GetSOCIALLinkedWhatsAppBusinessAccountListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LinkedAccounts;
        }
        
    }
}
