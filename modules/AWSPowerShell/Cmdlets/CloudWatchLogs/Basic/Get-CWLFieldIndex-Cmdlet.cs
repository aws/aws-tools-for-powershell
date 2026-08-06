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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns a list of field indexes discovered in log data. By default, the response includes
    /// the <c>DEFAULT</c>, <c>CUSTOM</c>, and <c>INACTIVE</c> index categories. To return
    /// indexes from other categories, use the <c>indexCategories</c> parameter.
    /// 
    ///  
    /// <para>
    /// For more information about field index policies, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutIndexPolicy.html">PutIndexPolicy</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWLFieldIndex")]
    [OutputType("Amazon.CloudWatchLogs.Model.FieldIndex")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs DescribeFieldIndexes API operation.", Operation = new[] {"DescribeFieldIndexes"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.FieldIndex or Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.FieldIndex objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLFieldIndexCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IndexCategory
        /// <summary>
        /// <para>
        /// <para>The index categories to return. The following values are supported:</para><ul><li><para><c>DEFAULT</c>: Fields that CloudWatch Logs indexes by default. Examples include
        /// <c>@logStream</c> and <c>@data_format</c>.</para></li><li><para><c>CUSTOM</c>: Fields that you added manually to the field index policy. CloudWatch
        /// Logs always indexes these fields. These fields count toward the quota of 20 fields
        /// for each log group.</para></li><li><para><c>AUTO</c>: Fields that CloudWatch Logs indexes automatically based on your query
        /// patterns and usage. These fields do not count toward the field index quota. CloudWatch
        /// Logs might update these fields based on changes in your query patterns. To keep a
        /// field indexed permanently, add it to an account-level or log-group level field index
        /// policy.</para></li><li><para><c>INACTIVE</c>: Fields that CloudWatch Logs indexed before but does not index now.
        /// This happens if you remove a field from the field index policy or if CloudWatch Logs
        /// automatically selects a different field based on your queries.</para></li></ul><para>If you omit this parameter, the response includes the <c>DEFAULT</c>, <c>CUSTOM</c>,
        /// and <c>INACTIVE</c> categories.</para><para>For more information about automatically indexed fields and using the <c>AUTO</c>
        /// category, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatchLogs-Field-Indexing-Automatic.html">Automatically
        /// indexed fields</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IndexCategories")]
        public System.String[] IndexCategory { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>An array containing the names or ARNs of the log groups that you want to retrieve
        /// field indexes for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LogGroupIdentifiers")]
        public System.String[] LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FieldIndexes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FieldIndexes";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse, GetCWLFieldIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.IndexCategory != null)
            {
                context.IndexCategory = new List<System.String>(this.IndexCategory);
            }
            if (this.LogGroupIdentifier != null)
            {
                context.LogGroupIdentifier = new List<System.String>(this.LogGroupIdentifier);
            }
            #if MODULAR
            if (this.LogGroupIdentifier == null && ParameterWasBound(nameof(this.LogGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudWatchLogs.Model.DescribeFieldIndexesRequest();
            
            if (cmdletContext.IndexCategory != null)
            {
                request.IndexCategories = cmdletContext.IndexCategory;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifiers = cmdletContext.LogGroupIdentifier;
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
        
        private Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeFieldIndexesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "DescribeFieldIndexes");
            try
            {
                return client.DescribeFieldIndexesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> IndexCategory { get; set; }
            public List<System.String> LogGroupIdentifier { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.DescribeFieldIndexesResponse, GetCWLFieldIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FieldIndexes;
        }
        
    }
}
