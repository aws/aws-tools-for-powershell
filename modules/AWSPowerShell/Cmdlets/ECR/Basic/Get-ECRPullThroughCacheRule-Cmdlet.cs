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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Returns the pull through cache rules for a registry.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECRPullThroughCacheRule")]
    [OutputType("Amazon.ECR.Model.PullThroughCacheRule")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry DescribePullThroughCacheRules API operation.", Operation = new[] {"DescribePullThroughCacheRules"}, SelectReturnType = typeof(Amazon.ECR.Model.DescribePullThroughCacheRulesResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.PullThroughCacheRule or Amazon.ECR.Model.DescribePullThroughCacheRulesResponse",
        "This cmdlet returns a collection of Amazon.ECR.Model.PullThroughCacheRule objects.",
        "The service call response (type Amazon.ECR.Model.DescribePullThroughCacheRulesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECRPullThroughCacheRuleCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter EcrRepositoryPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR repository prefixes associated with the pull through cache rules to
        /// return. If no repository prefix value is specified, all pull through cache rules are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EcrRepositoryPrefixes")]
        public System.String[] EcrRepositoryPrefix { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry to return the pull
        /// through cache rules for. If you do not specify a registry, the default registry is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of pull through cache rules returned by <code>DescribePullThroughCacheRulesRequest</code>
        /// in paginated output. When this parameter is used, <code>DescribePullThroughCacheRulesRequest</code>
        /// only returns <code>maxResults</code> results in a single page along with a <code>nextToken</code>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <code>DescribePullThroughCacheRulesRequest</code> request with the returned
        /// <code>nextToken</code> value. This value can be between 1 and 1000. If this parameter
        /// is not used, then <code>DescribePullThroughCacheRulesRequest</code> returns up to
        /// 100 results and a <code>nextToken</code> value, if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> value returned from a previous paginated <code>DescribePullThroughCacheRulesRequest</code>
        /// request where <code>maxResults</code> was used and the results exceeded the value
        /// of that parameter. Pagination continues from the end of the previous results that
        /// returned the <code>nextToken</code> value. This value is null when there are no more
        /// results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PullThroughCacheRules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.DescribePullThroughCacheRulesResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.DescribePullThroughCacheRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PullThroughCacheRules";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.DescribePullThroughCacheRulesResponse, GetECRPullThroughCacheRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EcrRepositoryPrefix != null)
            {
                context.EcrRepositoryPrefix = new List<System.String>(this.EcrRepositoryPrefix);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RegistryId = this.RegistryId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ECR.Model.DescribePullThroughCacheRulesRequest();
            
            if (cmdletContext.EcrRepositoryPrefix != null)
            {
                request.EcrRepositoryPrefixes = cmdletContext.EcrRepositoryPrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ECR.Model.DescribePullThroughCacheRulesResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.DescribePullThroughCacheRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "DescribePullThroughCacheRules");
            try
            {
                #if DESKTOP
                return client.DescribePullThroughCacheRules(request);
                #elif CORECLR
                return client.DescribePullThroughCacheRulesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> EcrRepositoryPrefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RegistryId { get; set; }
            public System.Func<Amazon.ECR.Model.DescribePullThroughCacheRulesResponse, GetECRPullThroughCacheRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PullThroughCacheRules;
        }
        
    }
}
