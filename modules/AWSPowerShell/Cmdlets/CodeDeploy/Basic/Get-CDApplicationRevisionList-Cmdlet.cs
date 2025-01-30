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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Lists information about revisions for an application.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CDApplicationRevisionList")]
    [OutputType("Amazon.CodeDeploy.Model.RevisionLocation")]
    [AWSCmdlet("Calls the AWS CodeDeploy ListApplicationRevisions API operation.", Operation = new[] {"ListApplicationRevisions"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse))]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.RevisionLocation or Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse",
        "This cmdlet returns a collection of Amazon.CodeDeploy.Model.RevisionLocation objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCDApplicationRevisionListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para> The name of an CodeDeploy application associated with the user or Amazon Web Services
        /// account. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter Deployed
        /// <summary>
        /// <para>
        /// <para> Whether to list revisions based on whether the revision is the target revision of
        /// a deployment group: </para><ul><li><para><c>include</c>: List revisions that are target revisions of a deployment group.</para></li><li><para><c>exclude</c>: Do not list revisions that are target revisions of a deployment group.</para></li><li><para><c>ignore</c>: List all revisions.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.ListStateFilterAction")]
        public Amazon.CodeDeploy.ListStateFilterAction Deployed { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para> An Amazon S3 bucket name to limit the search for revisions. </para><para> If set to null, all of the user's buckets are searched. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para> A key prefix for the set of Amazon S3 objects to limit the search for revisions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The column name to use to sort the list results:</para><ul><li><para><c>registerTime</c>: Sort by the time the revisions were registered with CodeDeploy.</para></li><li><para><c>firstUsedTime</c>: Sort by the time the revisions were first used in a deployment.</para></li><li><para><c>lastUsedTime</c>: Sort by the time the revisions were last used in a deployment.</para></li></ul><para> If not specified or set to null, the results are returned in an arbitrary order.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.ApplicationRevisionSortBy")]
        public Amazon.CodeDeploy.ApplicationRevisionSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para> The order in which to sort the list results: </para><ul><li><para><c>ascending</c>: ascending order.</para></li><li><para><c>descending</c>: descending order.</para></li></ul><para>If not specified, the results are sorted in ascending order.</para><para>If set to null, the results are sorted in an arbitrary order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.SortOrder")]
        public Amazon.CodeDeploy.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous <c>ListApplicationRevisions</c> call. It
        /// can be used to return the next set of applications in the list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Revisions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Revisions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse, GetCDApplicationRevisionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Deployed = this.Deployed;
            context.NextToken = this.NextToken;
            context.S3Bucket = this.S3Bucket;
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CodeDeploy.Model.ListApplicationRevisionsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Deployed != null)
            {
                request.Deployed = cmdletContext.Deployed;
            }
            if (cmdletContext.S3Bucket != null)
            {
                request.S3Bucket = cmdletContext.S3Bucket;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.ListApplicationRevisionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "ListApplicationRevisions");
            try
            {
                #if DESKTOP
                return client.ListApplicationRevisions(request);
                #elif CORECLR
                return client.ListApplicationRevisionsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public Amazon.CodeDeploy.ListStateFilterAction Deployed { get; set; }
            public System.String NextToken { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public Amazon.CodeDeploy.ApplicationRevisionSortBy SortBy { get; set; }
            public Amazon.CodeDeploy.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse, GetCDApplicationRevisionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Revisions;
        }
        
    }
}
