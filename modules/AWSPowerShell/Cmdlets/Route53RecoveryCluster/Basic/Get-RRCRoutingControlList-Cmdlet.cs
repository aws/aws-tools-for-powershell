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
using Amazon.Route53RecoveryCluster;
using Amazon.Route53RecoveryCluster.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RRC
{
    /// <summary>
    /// List routing control names and Amazon Resource Names (ARNs), as well as the routing
    /// control state for each routing control, along with the control panel name and control
    /// panel ARN for the routing controls. If you specify a control panel ARN, this call
    /// lists the routing controls in the control panel. Otherwise, it lists all the routing
    /// controls in the cluster.
    /// 
    ///  
    /// <para>
    /// A routing control is a simple on/off switch in Route 53 ARC that you can use to route
    /// traffic to cells. When a routing control state is set to ON, traffic flows to a cell.
    /// When the state is set to OFF, traffic does not flow.
    /// </para><para>
    /// Before you can create a routing control, you must first create a cluster, and then
    /// host the control in a control panel on the cluster. For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.create.html">
    /// Create routing control structures</a> in the Amazon Route 53 Application Recovery
    /// Controller Developer Guide. You access one of the endpoints for the cluster to get
    /// or update the routing control state to redirect traffic for your application. 
    /// </para><para><i>You must specify Regional endpoints when you work with API cluster operations
    /// to use this API operation to list routing controls in Route 53 ARC.</i></para><para>
    /// Learn more about working with routing controls in the following topics in the Amazon
    /// Route 53 Application Recovery Controller Developer Guide:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.update.html">
    /// Viewing and updating routing control states</a></para></li><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.html">Working
    /// with routing controls in Route 53 ARC</a></para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "RRCRoutingControlList")]
    [OutputType("Amazon.Route53RecoveryCluster.Model.RoutingControl")]
    [AWSCmdlet("Calls the Route53 Recovery Cluster ListRoutingControls API operation.", Operation = new[] {"ListRoutingControls"}, SelectReturnType = typeof(Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryCluster.Model.RoutingControl or Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse",
        "This cmdlet returns a collection of Amazon.Route53RecoveryCluster.Model.RoutingControl objects.",
        "The service call response (type Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRRCRoutingControlListCmdlet : AmazonRoute53RecoveryClusterClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ControlPanelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the control panel of the routing controls to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ControlPanelArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of routing controls objects that you want to return with this call. The
        /// default value is 500.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. You receive this token from a previous call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RoutingControls'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RoutingControls";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse, GetRRCRoutingControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ControlPanelArn = this.ControlPanelArn;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
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
            var request = new Amazon.Route53RecoveryCluster.Model.ListRoutingControlsRequest();
            
            if (cmdletContext.ControlPanelArn != null)
            {
                request.ControlPanelArn = cmdletContext.ControlPanelArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse CallAWSServiceOperation(IAmazonRoute53RecoveryCluster client, Amazon.Route53RecoveryCluster.Model.ListRoutingControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Route53 Recovery Cluster", "ListRoutingControls");
            try
            {
                return client.ListRoutingControlsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ControlPanelArn { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Route53RecoveryCluster.Model.ListRoutingControlsResponse, GetRRCRoutingControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RoutingControls;
        }
        
    }
}
