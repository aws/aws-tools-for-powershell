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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Returns metadata about a query, including query run time in milliseconds, number of
    /// events scanned and matched, and query status. If the query results were delivered
    /// to an S3 bucket, the response also provides the S3 URI and the delivery status.
    /// 
    ///  
    /// <para>
    /// You must specify either <c>QueryId</c> or <c>QueryAlias</c>. Specifying the <c>QueryAlias</c>
    /// parameter returns information about the last query run for the alias. You can provide
    /// <c>RefreshId</c> along with <c>QueryAlias</c> to view the query results of a dashboard
    /// query for the specified <c>RefreshId</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CTQuery")]
    [OutputType("Amazon.CloudTrail.Model.DescribeQueryResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail DescribeQuery API operation.", Operation = new[] {"DescribeQuery"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.DescribeQueryResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.DescribeQueryResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.DescribeQueryResponse object containing multiple properties."
    )]
    public partial class GetCTQueryCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventDataStoreOwnerAccountId
        /// <summary>
        /// <para>
        /// <para> The account ID of the event data store owner. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventDataStoreOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter QueryAlias
        /// <summary>
        /// <para>
        /// <para> The alias that identifies a query template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryAlias { get; set; }
        #endregion
        
        #region Parameter QueryId
        /// <summary>
        /// <para>
        /// <para>The query ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueryId { get; set; }
        #endregion
        
        #region Parameter RefreshId
        /// <summary>
        /// <para>
        /// <para> The ID of the dashboard refresh. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshId { get; set; }
        #endregion
        
        #region Parameter EventDataStore
        /// <summary>
        /// <para>
        /// <para>The ARN (or the ID suffix of the ARN) of an event data store on which the specified
        /// query was run.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("EventDataStore is no longer required by DescribeQueryRequest")]
        public System.String EventDataStore { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.DescribeQueryResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.DescribeQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.DescribeQueryResponse, GetCTQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventDataStore = this.EventDataStore;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventDataStoreOwnerAccountId = this.EventDataStoreOwnerAccountId;
            context.QueryAlias = this.QueryAlias;
            context.QueryId = this.QueryId;
            context.RefreshId = this.RefreshId;
            
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
            var request = new Amazon.CloudTrail.Model.DescribeQueryRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EventDataStore != null)
            {
                request.EventDataStore = cmdletContext.EventDataStore;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EventDataStoreOwnerAccountId != null)
            {
                request.EventDataStoreOwnerAccountId = cmdletContext.EventDataStoreOwnerAccountId;
            }
            if (cmdletContext.QueryAlias != null)
            {
                request.QueryAlias = cmdletContext.QueryAlias;
            }
            if (cmdletContext.QueryId != null)
            {
                request.QueryId = cmdletContext.QueryId;
            }
            if (cmdletContext.RefreshId != null)
            {
                request.RefreshId = cmdletContext.RefreshId;
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
        
        private Amazon.CloudTrail.Model.DescribeQueryResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.DescribeQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "DescribeQuery");
            try
            {
                return client.DescribeQueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public System.String EventDataStore { get; set; }
            public System.String EventDataStoreOwnerAccountId { get; set; }
            public System.String QueryAlias { get; set; }
            public System.String QueryId { get; set; }
            public System.String RefreshId { get; set; }
            public System.Func<Amazon.CloudTrail.Model.DescribeQueryResponse, GetCTQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
