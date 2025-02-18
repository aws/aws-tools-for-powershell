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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Retrieves a paginated list of deployments.
    /// </summary>
    [Cmdlet("Get", "GGV2DeploymentList")]
    [OutputType("Amazon.GreengrassV2.Model.Deployment")]
    [AWSCmdlet("Calls the AWS GreengrassV2 ListDeployments API operation.", Operation = new[] {"ListDeployments"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.ListDeploymentsResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.Deployment or Amazon.GreengrassV2.Model.ListDeploymentsResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.Deployment objects.",
        "The service call response (type Amazon.GreengrassV2.Model.ListDeploymentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGGV2DeploymentListCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HistoryFilter
        /// <summary>
        /// <para>
        /// <para>The filter for the list of deployments. Choose one of the following options:</para><ul><li><para><c>ALL</c> – The list includes all deployments.</para></li><li><para><c>LATEST_ONLY</c> – The list includes only the latest revision of each deployment.</para></li></ul><para>Default: <c>LATEST_ONLY</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.DeploymentHistoryFilter")]
        public Amazon.GreengrassV2.DeploymentHistoryFilter HistoryFilter { get; set; }
        #endregion
        
        #region Parameter ParentTargetArn
        /// <summary>
        /// <para>
        /// <para>The parent deployment's target <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// within a subdeployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentTargetArn { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the target IoT thing or thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned per paginated request.</para><para>Default: <c>50</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Deployments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.ListDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.ListDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Deployments";
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
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.ListDeploymentsResponse, GetGGV2DeploymentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HistoryFilter = this.HistoryFilter;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ParentTargetArn = this.ParentTargetArn;
            context.TargetArn = this.TargetArn;
            
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
            var request = new Amazon.GreengrassV2.Model.ListDeploymentsRequest();
            
            if (cmdletContext.HistoryFilter != null)
            {
                request.HistoryFilter = cmdletContext.HistoryFilter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ParentTargetArn != null)
            {
                request.ParentTargetArn = cmdletContext.ParentTargetArn;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.GreengrassV2.Model.ListDeploymentsResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.ListDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "ListDeployments");
            try
            {
                return client.ListDeploymentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GreengrassV2.DeploymentHistoryFilter HistoryFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParentTargetArn { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.ListDeploymentsResponse, GetGGV2DeploymentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Deployments;
        }
        
    }
}
