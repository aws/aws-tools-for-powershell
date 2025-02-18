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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Describes one or more blue/green deployments.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/blue-green-deployments.html">Using
    /// Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon RDS User
    /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/blue-green-deployments.html">
    /// Using Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon
    /// Aurora User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSBlueGreenDeployment")]
    [OutputType("Amazon.RDS.Model.BlueGreenDeployment")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeBlueGreenDeployments API operation.", Operation = new[] {"DescribeBlueGreenDeployments"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.BlueGreenDeployment or Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.BlueGreenDeployment objects.",
        "The service call response (type Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSBlueGreenDeploymentCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BlueGreenDeploymentIdentifier
        /// <summary>
        /// <para>
        /// <para>The blue/green deployment identifier. If you specify this parameter, the response
        /// only includes information about the specific blue/green deployment. This parameter
        /// isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match an existing blue/green deployment identifier.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BlueGreenDeploymentIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies one or more blue/green deployments to describe.</para><para>Valid Values:</para><ul><li><para><c>blue-green-deployment-identifier</c> - Accepts system-generated identifiers for
        /// blue/green deployments. The results list only includes information about the blue/green
        /// deployments with the specified identifiers.</para></li><li><para><c>blue-green-deployment-name</c> - Accepts user-supplied names for blue/green deployments.
        /// The results list only includes information about the blue/green deployments with the
        /// specified names.</para></li><li><para><c>source</c> - Accepts source databases for a blue/green deployment. The results
        /// list only includes information about the blue/green deployments with the specified
        /// source databases.</para></li><li><para><c>target</c> - Accepts target databases for a blue/green deployment. The results
        /// list only includes information about the blue/green deployments with the specified
        /// target databases.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <c>DescribeBlueGreenDeployments</c>
        /// request. If you specify this parameter, the response only includes records beyond
        /// the marker, up to the value specified by <c>MaxRecords</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token called a marker is included
        /// in the response so you can retrieve the remaining results.</para><para>Default: 100</para><para>Constraints:</para><ul><li><para>Must be a minimum of 20.</para></li><li><para>Can't exceed 100.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BlueGreenDeployments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BlueGreenDeployments";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse, GetRDSBlueGreenDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueGreenDeploymentIdentifier = this.BlueGreenDeploymentIdentifier;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
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
            var request = new Amazon.RDS.Model.DescribeBlueGreenDeploymentsRequest();
            
            if (cmdletContext.BlueGreenDeploymentIdentifier != null)
            {
                request.BlueGreenDeploymentIdentifier = cmdletContext.BlueGreenDeploymentIdentifier;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeBlueGreenDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeBlueGreenDeployments");
            try
            {
                return client.DescribeBlueGreenDeploymentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BlueGreenDeploymentIdentifier { get; set; }
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeBlueGreenDeploymentsResponse, GetRDSBlueGreenDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BlueGreenDeployments;
        }
        
    }
}
