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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Lists the IAM principals that are excluded from having their image pull times recorded.
    /// </summary>
    [Cmdlet("Get", "ECRPullTimeUpdateExclusionList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry ListPullTimeUpdateExclusions API operation.", Operation = new[] {"ListPullTimeUpdateExclusions"}, SelectReturnType = typeof(Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECRPullTimeUpdateExclusionListCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of pull time update exclusion results returned by <c>ListPullTimeUpdateExclusions</c>
        /// in paginated output. When this parameter is used, <c>ListPullTimeUpdateExclusions</c>
        /// only returns <c>maxResults</c> results in a single page along with a <c>nextToken</c>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <c>ListPullTimeUpdateExclusions</c> request with the returned <c>nextToken</c>
        /// value. This value can be between 1 and 1000. If this parameter is not used, then <c>ListPullTimeUpdateExclusions</c>
        /// returns up to 100 results and a <c>nextToken</c> value, if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListPullTimeUpdateExclusions</c>
        /// request where <c>maxResults</c> was used and the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous results that returned
        /// the <c>nextToken</c> value. This value is <c>null</c> when there are no more results
        /// to return.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PullTimeUpdateExclusions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PullTimeUpdateExclusions";
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
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse, GetECRPullTimeUpdateExclusionListCmdlet>(Select) ??
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
            var request = new Amazon.ECR.Model.ListPullTimeUpdateExclusionsRequest();
            
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
        
        private Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.ListPullTimeUpdateExclusionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "ListPullTimeUpdateExclusions");
            try
            {
                #if DESKTOP
                return client.ListPullTimeUpdateExclusions(request);
                #elif CORECLR
                return client.ListPullTimeUpdateExclusionsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ECR.Model.ListPullTimeUpdateExclusionsResponse, GetECRPullTimeUpdateExclusionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PullTimeUpdateExclusions;
        }
        
    }
}
