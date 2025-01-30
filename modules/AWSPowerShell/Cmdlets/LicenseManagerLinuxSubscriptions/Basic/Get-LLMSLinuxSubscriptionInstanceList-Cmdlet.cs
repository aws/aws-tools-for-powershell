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
    /// Lists the running Amazon EC2 instances that were discovered with commercial Linux
    /// subscriptions.
    /// </summary>
    [Cmdlet("Get", "LLMSLinuxSubscriptionInstanceList")]
    [OutputType("Amazon.LicenseManagerLinuxSubscriptions.Model.Instance")]
    [AWSCmdlet("Calls the AWS License Manager - Linux Subscriptions ListLinuxSubscriptionInstances API operation.", Operation = new[] {"ListLinuxSubscriptionInstances"}, SelectReturnType = typeof(Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerLinuxSubscriptions.Model.Instance or Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse",
        "This cmdlet returns a collection of Amazon.LicenseManagerLinuxSubscriptions.Model.Instance objects.",
        "The service call response (type Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLLMSLinuxSubscriptionInstanceListCmdlet : AmazonLicenseManagerLinuxSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of structures that you can use to filter the results by your specified criteria.
        /// For example, you can specify <c>Region</c> in the <c>Name</c>, with the <c>contains</c>
        /// operator to list all subscriptions that match a partial string in the <c>Value</c>,
        /// such as <c>us-west</c>.</para><para>For each filter, you can specify one of the following values for the <c>Name</c> key
        /// to streamline results:</para><ul><li><para><c>AccountID</c></para></li><li><para><c>AmiID</c></para></li><li><para><c>DualSubscription</c></para></li><li><para><c>InstanceID</c></para></li><li><para><c>InstanceType</c></para></li><li><para><c>ProductCode</c></para></li><li><para><c>Region</c></para></li><li><para><c>Status</c></para></li><li><para><c>UsageOperation</c></para></li></ul><para>For each filter, you can use one of the following <c>Operator</c> values to define
        /// the behavior of the filter:</para><ul><li><para><c>contains</c></para></li><li><para><c>equals</c></para></li><li><para><c>Notequal</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LicenseManagerLinuxSubscriptions.Model.Filter[] Filter { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
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
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse, GetLLMSLinuxSubscriptionInstanceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LicenseManagerLinuxSubscriptions.Model.Filter>(this.Filter);
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
            var request = new Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
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
        
        private Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse CallAWSServiceOperation(IAmazonLicenseManagerLinuxSubscriptions client, Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager - Linux Subscriptions", "ListLinuxSubscriptionInstances");
            try
            {
                #if DESKTOP
                return client.ListLinuxSubscriptionInstances(request);
                #elif CORECLR
                return client.ListLinuxSubscriptionInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LicenseManagerLinuxSubscriptions.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LicenseManagerLinuxSubscriptions.Model.ListLinuxSubscriptionInstancesResponse, GetLLMSLinuxSubscriptionInstanceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
