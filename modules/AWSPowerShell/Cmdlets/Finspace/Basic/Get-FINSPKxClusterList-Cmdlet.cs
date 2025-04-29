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
using Amazon.Finspace;
using Amazon.Finspace.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Returns a list of clusters.
    /// </summary>
    [Cmdlet("Get", "FINSPKxClusterList")]
    [OutputType("Amazon.Finspace.Model.KxCluster")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service ListKxClusters API operation.", Operation = new[] {"ListKxClusters"}, SelectReturnType = typeof(Amazon.Finspace.Model.ListKxClustersResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.KxCluster or Amazon.Finspace.Model.ListKxClustersResponse",
        "This cmdlet returns a collection of Amazon.Finspace.Model.KxCluster objects.",
        "The service call response (type Amazon.Finspace.Model.ListKxClustersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetFINSPKxClusterListCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of KDB database that is being created. The following types are
        /// available: </para><ul><li><para>HDB – A Historical Database. The data is only accessible with read-only permissions
        /// from one of the FinSpace managed kdb databases mounted to the cluster.</para></li><li><para>RDB – A Realtime Database. This type of database captures all the data from a ticker
        /// plant and stores it in memory until the end of day, after which it writes all of its
        /// data to a disk and reloads the HDB. This cluster type requires local storage for temporary
        /// storage of data during the savedown process. If you specify this field in your request,
        /// you must provide the <c>savedownStorageConfiguration</c> parameter.</para></li><li><para>GATEWAY – A gateway cluster allows you to access data across processes in kdb systems.
        /// It allows you to create your own routing logic using the initialization scripts and
        /// custom code. This type of cluster does not require a writable local storage.</para></li><li><para>GP – A general purpose cluster allows you to quickly iterate on code during development
        /// by granting greater access to system commands and enabling a fast reload of custom
        /// code. This cluster type can optionally mount databases including cache and savedown
        /// storage. For this cluster type, the node count is fixed at 1. It does not support
        /// autoscaling and supports only <c>SINGLE</c> AZ mode.</para></li><li><para>Tickerplant – A tickerplant cluster allows you to subscribe to feed handlers based
        /// on IAM permissions. It can publish to RDBs, other Tickerplants, and real-time subscribers
        /// (RTS). Tickerplants can persist messages to log, which is readable by any RDB environment.
        /// It supports only single-node that is only one kdb process.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.KxClusterType")]
        public Amazon.Finspace.KxClusterType ClusterType { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates where a results page should begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KxClusterSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.ListKxClustersResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.ListKxClustersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KxClusterSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.ListKxClustersResponse, GetFINSPKxClusterListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterType = this.ClusterType;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Finspace.Model.ListKxClustersRequest();
            
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
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
        
        private Amazon.Finspace.Model.ListKxClustersResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.ListKxClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "ListKxClusters");
            try
            {
                return client.ListKxClustersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Finspace.KxClusterType ClusterType { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Finspace.Model.ListKxClustersResponse, GetFINSPKxClusterListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KxClusterSummaries;
        }
        
    }
}
