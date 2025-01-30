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
using Amazon.LicenseManagerLinuxSubscriptions;
using Amazon.LicenseManagerLinuxSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LLMS
{
    /// <summary>
    /// List Bring Your Own License (BYOL) subscription registration resources for your account.
    /// </summary>
    [Cmdlet("Get", "LLMSRegisteredSubscriptionProviderList")]
    [OutputType("Amazon.LicenseManagerLinuxSubscriptions.Model.RegisteredSubscriptionProvider")]
    [AWSCmdlet("Calls the AWS License Manager - Linux Subscriptions ListRegisteredSubscriptionProviders API operation.", Operation = new[] {"ListRegisteredSubscriptionProviders"}, SelectReturnType = typeof(Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerLinuxSubscriptions.Model.RegisteredSubscriptionProvider or Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse",
        "This cmdlet returns a collection of Amazon.LicenseManagerLinuxSubscriptions.Model.RegisteredSubscriptionProvider objects.",
        "The service call response (type Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLLMSRegisteredSubscriptionProviderListCmdlet : AmazonLicenseManagerLinuxSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SubscriptionProviderSource
        /// <summary>
        /// <para>
        /// <para>To filter your results, specify which subscription providers to return in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubscriptionProviderSources")]
        public System.String[] SubscriptionProviderSource { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum items to return in a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to specify where to start paginating. This is the nextToken from a previously
        /// truncated response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegisteredSubscriptionProviders'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegisteredSubscriptionProviders";
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
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse, GetLLMSRegisteredSubscriptionProviderListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SubscriptionProviderSource != null)
            {
                context.SubscriptionProviderSource = new List<System.String>(this.SubscriptionProviderSource);
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
            var request = new Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SubscriptionProviderSource != null)
            {
                request.SubscriptionProviderSources = cmdletContext.SubscriptionProviderSource;
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
        
        private Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse CallAWSServiceOperation(IAmazonLicenseManagerLinuxSubscriptions client, Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager - Linux Subscriptions", "ListRegisteredSubscriptionProviders");
            try
            {
                #if DESKTOP
                return client.ListRegisteredSubscriptionProviders(request);
                #elif CORECLR
                return client.ListRegisteredSubscriptionProvidersAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SubscriptionProviderSource { get; set; }
            public System.Func<Amazon.LicenseManagerLinuxSubscriptions.Model.ListRegisteredSubscriptionProvidersResponse, GetLLMSRegisteredSubscriptionProviderListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegisteredSubscriptionProviders;
        }
        
    }
}
