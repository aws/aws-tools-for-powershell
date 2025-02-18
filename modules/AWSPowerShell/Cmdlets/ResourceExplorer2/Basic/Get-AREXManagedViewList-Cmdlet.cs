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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Lists the Amazon resource names (ARNs) of the <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/aws-managed-views.html">Amazon
    /// Web Services-managed views</a> available in the Amazon Web Services Region in which
    /// you call this operation.
    /// </summary>
    [Cmdlet("Get", "AREXManagedViewList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Explorer ListManagedViews API operation.", Operation = new[] {"ListManagedViews"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.ListManagedViewsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ResourceExplorer2.Model.ListManagedViewsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ResourceExplorer2.Model.ListManagedViewsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAREXManagedViewListCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>Specifies a service principal name. If specified, then the operation only returns
        /// the managed views that are managed by the input service. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that you want included on each page of the response.
        /// If you do not include this parameter, it defaults to a value appropriate to the operation.
        /// If additional items exist beyond those included in the current response, the <c>NextToken</c>
        /// response element is present and has a value (is not null). Include that value as the
        /// <c>NextToken</c> request parameter in the next call to the operation to get the next
        /// part of the results.</para><note><para>An API operation can return fewer results than the maximum even when there are more
        /// results available. You should check <c>NextToken</c> after every operation to ensure
        /// that you receive all of the results.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The parameter for receiving additional results if you receive a <c>NextToken</c> response
        /// in a previous request. A <c>NextToken</c> response indicates that more output is available.
        /// Set this parameter to the value of the previous call's <c>NextToken</c> response to
        /// indicate where the output should continue from. The pagination tokens expire after
        /// 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedViews'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.ListManagedViewsResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.ListManagedViewsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedViews";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.ListManagedViewsResponse, GetAREXManagedViewListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ServicePrincipal = this.ServicePrincipal;
            
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
            var request = new Amazon.ResourceExplorer2.Model.ListManagedViewsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
        
        private Amazon.ResourceExplorer2.Model.ListManagedViewsResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.ListManagedViewsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "ListManagedViews");
            try
            {
                return client.ListManagedViewsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ServicePrincipal { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.ListManagedViewsResponse, GetAREXManagedViewListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedViews;
        }
        
    }
}
