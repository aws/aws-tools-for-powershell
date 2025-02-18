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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Lists managed endpoints based on a set of parameters. A managed endpoint is a gateway
    /// that connects Amazon EMR Studio to Amazon EMR on EKS so that Amazon EMR Studio can
    /// communicate with your virtual cluster.
    /// </summary>
    [Cmdlet("Get", "EMRCManagedEndpointList")]
    [OutputType("Amazon.EMRContainers.Model.Endpoint")]
    [AWSCmdlet("Calls the Amazon EMR Containers ListManagedEndpoints API operation.", Operation = new[] {"ListManagedEndpoints"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.ListManagedEndpointsResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.Endpoint or Amazon.EMRContainers.Model.ListManagedEndpointsResponse",
        "This cmdlet returns a collection of Amazon.EMRContainers.Model.Endpoint objects.",
        "The service call response (type Amazon.EMRContainers.Model.ListManagedEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMRCManagedEndpointListCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para> The date and time after which the endpoints are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The date and time before which the endpoints are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The states of the managed endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The types of the managed endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Types")]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter VirtualClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual cluster.</para>
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
        public System.String VirtualClusterId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of managed endpoints that can be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token for the next set of managed endpoints to return. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Endpoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.ListManagedEndpointsResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.ListManagedEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Endpoints";
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
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.ListManagedEndpointsResponse, GetEMRCManagedEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
            }
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            context.VirtualClusterId = this.VirtualClusterId;
            #if MODULAR
            if (this.VirtualClusterId == null && ParameterWasBound(nameof(this.VirtualClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EMRContainers.Model.ListManagedEndpointsRequest();
            
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
            }
            if (cmdletContext.Type != null)
            {
                request.Types = cmdletContext.Type;
            }
            if (cmdletContext.VirtualClusterId != null)
            {
                request.VirtualClusterId = cmdletContext.VirtualClusterId;
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
        
        private Amazon.EMRContainers.Model.ListManagedEndpointsResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.ListManagedEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "ListManagedEndpoints");
            try
            {
                return client.ListManagedEndpointsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> State { get; set; }
            public List<System.String> Type { get; set; }
            public System.String VirtualClusterId { get; set; }
            public System.Func<Amazon.EMRContainers.Model.ListManagedEndpointsResponse, GetEMRCManagedEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Endpoints;
        }
        
    }
}
