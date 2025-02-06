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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Lists all of the Amazon Managed Service for Prometheus workspaces in your account.
    /// This includes workspaces being created or deleted.
    /// </summary>
    [Cmdlet("Get", "PROMWorkspaceList")]
    [OutputType("Amazon.PrometheusService.Model.WorkspaceSummary")]
    [AWSCmdlet("Calls the Amazon Prometheus Service ListWorkspaces API operation.", Operation = new[] {"ListWorkspaces"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.ListWorkspacesResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.WorkspaceSummary or Amazon.PrometheusService.Model.ListWorkspacesResponse",
        "This cmdlet returns a collection of Amazon.PrometheusService.Model.WorkspaceSummary objects.",
        "The service call response (type Amazon.PrometheusService.Model.ListWorkspacesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPROMWorkspaceListCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>If this is included, it filters the results to only the workspaces with names that
        /// start with the value that you specify here.</para><para>Amazon Managed Service for Prometheus will automatically strip any blank spaces from
        /// the beginning and end of the alias that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of workspaces to return per request. The default is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of items to return. You receive this token from a previous
        /// call, and use it to get the next page of results. The other parameters must be the
        /// same as the initial call.</para><para>For example, if your initial request has <c>maxResults</c> of 10, and there are 12
        /// workspaces to return, then your initial request will return 10 and a <c>nextToken</c>.
        /// Using the next token in a subsequent call will return the remaining 2 workspaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workspaces'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.ListWorkspacesResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.ListWorkspacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workspaces";
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
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.ListWorkspacesResponse, GetPROMWorkspaceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
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
            var request = new Amazon.PrometheusService.Model.ListWorkspacesRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
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
        
        private Amazon.PrometheusService.Model.ListWorkspacesResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.ListWorkspacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "ListWorkspaces");
            try
            {
                #if DESKTOP
                return client.ListWorkspaces(request);
                #elif CORECLR
                return client.ListWorkspacesAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.PrometheusService.Model.ListWorkspacesResponse, GetPROMWorkspaceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workspaces;
        }
        
    }
}
