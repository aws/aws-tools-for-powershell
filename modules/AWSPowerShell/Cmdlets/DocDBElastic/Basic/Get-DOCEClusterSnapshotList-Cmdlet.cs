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
using Amazon.DocDBElastic;
using Amazon.DocDBElastic.Model;

namespace Amazon.PowerShell.Cmdlets.DOCE
{
    /// <summary>
    /// Returns information about snapshots for a specified elastic cluster.
    /// </summary>
    [Cmdlet("Get", "DOCEClusterSnapshotList")]
    [OutputType("Amazon.DocDBElastic.Model.ClusterSnapshotInList")]
    [AWSCmdlet("Calls the Amazon DocumentDB Elastic Clusters ListClusterSnapshots API operation.", Operation = new[] {"ListClusterSnapshots"}, SelectReturnType = typeof(Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.DocDBElastic.Model.ClusterSnapshotInList or Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.DocDBElastic.Model.ClusterSnapshotInList objects.",
        "The service call response (type Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDOCEClusterSnapshotListCmdlet : AmazonDocDBElasticClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The ARN identifier of the elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter SnapshotType
        /// <summary>
        /// <para>
        /// <para>The type of cluster snapshots to be returned. You can specify one of the following
        /// values:</para><ul><li><para><c>automated</c> - Return all cluster snapshots that Amazon DocumentDB has automatically
        /// created for your Amazon Web Services account.</para></li><li><para><c>manual</c> - Return all cluster snapshots that you have manually created for your
        /// Amazon Web Services account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of elastic cluster snapshot results to receive in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token provided by a previous request. If this parameter is specified,
        /// the response includes only records beyond this token, up to the value specified by
        /// <c>max-results</c>.</para><para>If there is no more data in the responce, the <c>nextToken</c> will not be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshots";
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
                context.Select = CreateSelectDelegate<Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse, GetDOCEClusterSnapshotListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterArn = this.ClusterArn;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SnapshotType = this.SnapshotType;
            
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
            var request = new Amazon.DocDBElastic.Model.ListClusterSnapshotsRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SnapshotType != null)
            {
                request.SnapshotType = cmdletContext.SnapshotType;
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
        
        private Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse CallAWSServiceOperation(IAmazonDocDBElastic client, Amazon.DocDBElastic.Model.ListClusterSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB Elastic Clusters", "ListClusterSnapshots");
            try
            {
                #if DESKTOP
                return client.ListClusterSnapshots(request);
                #elif CORECLR
                return client.ListClusterSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SnapshotType { get; set; }
            public System.Func<Amazon.DocDBElastic.Model.ListClusterSnapshotsResponse, GetDOCEClusterSnapshotListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
