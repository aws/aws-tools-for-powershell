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
using Amazon.Odb;
using Amazon.Odb.Model;

namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Lists all Autonomous VM clusters in a specified Cloud Exadata infrastructure.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ODBCloudAutonomousVmClusterList")]
    [OutputType("Amazon.Odb.Model.CloudAutonomousVmClusterSummary")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services ListCloudAutonomousVmClusters API operation.", Operation = new[] {"ListCloudAutonomousVmClusters"}, SelectReturnType = typeof(Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CloudAutonomousVmClusterSummary or Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse",
        "This cmdlet returns a collection of Amazon.Odb.Model.CloudAutonomousVmClusterSummary objects.",
        "The service call response (type Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetODBCloudAutonomousVmClusterListCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudExadataInfrastructureId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cloud Exadata Infrastructure that hosts the Autonomous
        /// VM clusters to be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CloudExadataInfrastructureId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to continue listing from.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CloudAutonomousVmClusters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CloudAutonomousVmClusters";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CloudExadataInfrastructureId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse, GetODBCloudAutonomousVmClusterListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CloudExadataInfrastructureId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudExadataInfrastructureId = this.CloudExadataInfrastructureId;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Odb.Model.ListCloudAutonomousVmClustersRequest();
            
            if (cmdletContext.CloudExadataInfrastructureId != null)
            {
                request.CloudExadataInfrastructureId = cmdletContext.CloudExadataInfrastructureId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.ListCloudAutonomousVmClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "ListCloudAutonomousVmClusters");
            try
            {
                #if DESKTOP
                return client.ListCloudAutonomousVmClusters(request);
                #elif CORECLR
                return client.ListCloudAutonomousVmClustersAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudExadataInfrastructureId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Odb.Model.ListCloudAutonomousVmClustersResponse, GetODBCloudAutonomousVmClusterListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CloudAutonomousVmClusters;
        }
        
    }
}
