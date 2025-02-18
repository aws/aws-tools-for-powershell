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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Returns a list of Timestream for InfluxDB DB parameter groups.
    /// </summary>
    [Cmdlet("Get", "TIDBDbParameterGroupList")]
    [OutputType("Amazon.TimestreamInfluxDB.Model.DbParameterGroupSummary")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB ListDbParameterGroups API operation.", Operation = new[] {"ListDbParameterGroups"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.Model.DbParameterGroupSummary or Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse",
        "This cmdlet returns a collection of Amazon.TimestreamInfluxDB.Model.DbParameterGroupSummary objects.",
        "The service call response (type Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTIDBDbParameterGroupListCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the output. If the total number of items
        /// available is more than the value specified, a NextToken is provided in the output.
        /// To resume pagination, provide the NextToken value as argument of a subsequent API
        /// invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token. To resume pagination, provide the NextToken value as argument
        /// of a subsequent API invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse, GetTIDBDbParameterGroupListCmdlet>(Select) ??
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
            var request = new Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsRequest();
            
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
        
        private Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "ListDbParameterGroups");
            try
            {
                return client.ListDbParameterGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.TimestreamInfluxDB.Model.ListDbParameterGroupsResponse, GetTIDBDbParameterGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
