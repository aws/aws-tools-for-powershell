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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Lists the platform branches available for your account in an AWS Region. Provides
    /// summary information about each platform branch.
    /// 
    ///  
    /// <para>
    /// For definitions of platform branch and other platform-related terms, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/platforms-glossary.html">AWS
    /// Elastic Beanstalk Platforms Glossary</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EBPlatformBranch")]
    [OutputType("Amazon.ElasticBeanstalk.Model.PlatformBranchSummary")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk ListPlatformBranches API operation.", Operation = new[] {"ListPlatformBranches"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.PlatformBranchSummary or Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse",
        "This cmdlet returns a collection of Amazon.ElasticBeanstalk.Model.PlatformBranchSummary objects.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEBPlatformBranchCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Criteria for restricting the resulting list of platform branches. The filter is evaluated
        /// as a logical conjunction (AND) of the separate <code>SearchFilter</code> terms.</para><para>The following list shows valid attribute values for each of the <code>SearchFilter</code>
        /// terms. Most operators take a single value. The <code>in</code> and <code>not_in</code>
        /// operators can take multiple values.</para><ul><li><para><code>Attribute = BranchName</code>:</para><ul><li><para><code>Operator</code>: <code>=</code> | <code>!=</code> | <code>begins_with</code>
        /// | <code>ends_with</code> | <code>contains</code> | <code>in</code> | <code>not_in</code></para></li></ul></li><li><para><code>Attribute = LifecycleState</code>:</para><ul><li><para><code>Operator</code>: <code>=</code> | <code>!=</code> | <code>in</code> | <code>not_in</code></para></li><li><para><code>Values</code>: <code>beta</code> | <code>supported</code> | <code>deprecated</code>
        /// | <code>retired</code></para></li></ul></li><li><para><code>Attribute = PlatformName</code>:</para><ul><li><para><code>Operator</code>: <code>=</code> | <code>!=</code> | <code>begins_with</code>
        /// | <code>ends_with</code> | <code>contains</code> | <code>in</code> | <code>not_in</code></para></li></ul></li><li><para><code>Attribute = TierType</code>:</para><ul><li><para><code>Operator</code>: <code>=</code> | <code>!=</code></para></li><li><para><code>Values</code>: <code>WebServer/Standard</code> | <code>Worker/SQS/HTTP</code></para></li></ul></li></ul><para>Array size: limited to 10 <code>SearchFilter</code> objects.</para><para>Within each <code>SearchFilter</code> item, the <code>Values</code> array is limited
        /// to 10 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ElasticBeanstalk.Model.SearchFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of platform branch values returned in one call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>For a paginated request. Specify a token from a previous response page to retrieve
        /// the next response page. All other parameter values must be identical to the ones specified
        /// in the initial request.</para><para>If no <code>NextToken</code> is specified, the first page is retrieved.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlatformBranchSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlatformBranchSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse, GetEBPlatformBranchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ElasticBeanstalk.Model.SearchFilter>(this.Filter);
            }
            context.MaxRecord = this.MaxRecord;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticBeanstalk.Model.ListPlatformBranchesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
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
        
        private Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.ListPlatformBranchesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "ListPlatformBranches");
            try
            {
                #if DESKTOP
                return client.ListPlatformBranches(request);
                #elif CORECLR
                return client.ListPlatformBranchesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticBeanstalk.Model.SearchFilter> Filter { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.ListPlatformBranchesResponse, GetEBPlatformBranchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlatformBranchSummaryList;
        }
        
    }
}
