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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// <note><para>
    ///  The newer <c>BatchGetDeploymentTargets</c> should be used instead because it works
    /// with all compute types. <c>ListDeploymentInstances</c> throws an exception if it is
    /// used with a compute platform other than EC2/On-premises or Lambda. 
    /// </para></note><para>
    ///  Lists the instance for a deployment associated with the user or Amazon Web Services
    /// account. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentInstanceList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy ListDeploymentInstances API operation.", Operation = new[] {"ListDeploymentInstances"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This operation is deprecated, use ListDeploymentTargets instead.")]
    public partial class GetCDDeploymentInstanceListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para> The unique ID of a deployment. </para>
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
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter InstanceStatusFilter
        /// <summary>
        /// <para>
        /// <para>A subset of instances to list by status:</para><ul><li><para><c>Pending</c>: Include those instances with pending deployments.</para></li><li><para><c>InProgress</c>: Include those instances where deployments are still in progress.</para></li><li><para><c>Succeeded</c>: Include those instances with successful deployments.</para></li><li><para><c>Failed</c>: Include those instances with failed deployments.</para></li><li><para><c>Skipped</c>: Include those instances with skipped deployments.</para></li><li><para><c>Unknown</c>: Include those instances with deployments in an unknown state.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InstanceStatusFilter { get; set; }
        #endregion
        
        #region Parameter InstanceTypeFilter
        /// <summary>
        /// <para>
        /// <para>The set of instances in a blue/green deployment, either those in the original environment
        /// ("BLUE") or those in the replacement environment ("GREEN"), for which you want to
        /// view instance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InstanceTypeFilter { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous list deployment instances call. It can be
        /// used to return the next set of deployment instances in the list.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstancesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstancesList";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse, GetCDDeploymentInstanceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentId = this.DeploymentId;
            #if MODULAR
            if (this.DeploymentId == null && ParameterWasBound(nameof(this.DeploymentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceStatusFilter != null)
            {
                context.InstanceStatusFilter = new List<System.String>(this.InstanceStatusFilter);
            }
            if (this.InstanceTypeFilter != null)
            {
                context.InstanceTypeFilter = new List<System.String>(this.InstanceTypeFilter);
            }
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
            var request = new Amazon.CodeDeploy.Model.ListDeploymentInstancesRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.InstanceStatusFilter != null)
            {
                request.InstanceStatusFilter = cmdletContext.InstanceStatusFilter;
            }
            if (cmdletContext.InstanceTypeFilter != null)
            {
                request.InstanceTypeFilter = cmdletContext.InstanceTypeFilter;
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
        
        private Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.ListDeploymentInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "ListDeploymentInstances");
            try
            {
                return client.ListDeploymentInstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeploymentId { get; set; }
            public List<System.String> InstanceStatusFilter { get; set; }
            public List<System.String> InstanceTypeFilter { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.ListDeploymentInstancesResponse, GetCDDeploymentInstanceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstancesList;
        }
        
    }
}
