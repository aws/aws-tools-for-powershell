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
using Amazon.DSQL;
using Amazon.DSQL.Model;

namespace Amazon.PowerShell.Cmdlets.DSQL
{
    /// <summary>
    /// Creates multi-Region clusters in Amazon Aurora DSQL. Multi-Region clusters require
    /// a linked Region list, which is an array of the Regions in which you want to create
    /// linked clusters. Multi-Region clusters require a witness Region, which participates
    /// in quorum in failure scenarios.
    /// </summary>
    [Cmdlet("New", "DSQLMultiRegionCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Aurora DSQL CreateMultiRegionClusters API operation.", Operation = new[] {"CreateMultiRegionClusters"}, SelectReturnType = typeof(Amazon.DSQL.Model.CreateMultiRegionClustersResponse))]
    [AWSCmdletOutput("System.String or Amazon.DSQL.Model.CreateMultiRegionClustersResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.DSQL.Model.CreateMultiRegionClustersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSQLMultiRegionClusterCmdlet : AmazonDSQLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterProperty
        /// <summary>
        /// <para>
        /// <para>A mapping of properties to use when creating linked clusters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClusterProperties")]
        public System.Collections.Hashtable ClusterProperty { get; set; }
        #endregion
        
        #region Parameter LinkedRegionList
        /// <summary>
        /// <para>
        /// <para>An array of the Regions in which you want to create additional clusters.</para>
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
        public System.String[] LinkedRegionList { get; set; }
        #endregion
        
        #region Parameter WitnessRegion
        /// <summary>
        /// <para>
        /// <para>The witness Region of multi-Region clusters.</para>
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
        public System.String WitnessRegion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully. The subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you don't specify a client token, the Amazon Web Services SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LinkedClusterArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DSQL.Model.CreateMultiRegionClustersResponse).
        /// Specifying the name of a property of type Amazon.DSQL.Model.CreateMultiRegionClustersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LinkedClusterArns";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WitnessRegion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSQLMultiRegionCluster (CreateMultiRegionClusters)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DSQL.Model.CreateMultiRegionClustersResponse, NewDSQLMultiRegionClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ClusterProperty != null)
            {
                context.ClusterProperty = new Dictionary<System.String, Amazon.DSQL.Model.LinkedClusterProperties>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClusterProperty.Keys)
                {
                    context.ClusterProperty.Add((String)hashKey, (Amazon.DSQL.Model.LinkedClusterProperties)(this.ClusterProperty[hashKey]));
                }
            }
            if (this.LinkedRegionList != null)
            {
                context.LinkedRegionList = new List<System.String>(this.LinkedRegionList);
            }
            #if MODULAR
            if (this.LinkedRegionList == null && ParameterWasBound(nameof(this.LinkedRegionList)))
            {
                WriteWarning("You are passing $null as a value for parameter LinkedRegionList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WitnessRegion = this.WitnessRegion;
            #if MODULAR
            if (this.WitnessRegion == null && ParameterWasBound(nameof(this.WitnessRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter WitnessRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.DSQL.Model.CreateMultiRegionClustersRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterProperty != null)
            {
                request.ClusterProperties = cmdletContext.ClusterProperty;
            }
            if (cmdletContext.LinkedRegionList != null)
            {
                request.LinkedRegionList = cmdletContext.LinkedRegionList;
            }
            if (cmdletContext.WitnessRegion != null)
            {
                request.WitnessRegion = cmdletContext.WitnessRegion;
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
        
        private Amazon.DSQL.Model.CreateMultiRegionClustersResponse CallAWSServiceOperation(IAmazonDSQL client, Amazon.DSQL.Model.CreateMultiRegionClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Aurora DSQL", "CreateMultiRegionClusters");
            try
            {
                return client.CreateMultiRegionClustersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, Amazon.DSQL.Model.LinkedClusterProperties> ClusterProperty { get; set; }
            public List<System.String> LinkedRegionList { get; set; }
            public System.String WitnessRegion { get; set; }
            public System.Func<Amazon.DSQL.Model.CreateMultiRegionClustersResponse, NewDSQLMultiRegionClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LinkedClusterArns;
        }
        
    }
}
