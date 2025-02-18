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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Description of the cluster policy. This policy is used for task prioritization and
    /// fair-share allocation. This helps prioritize critical workloads and distributes idle
    /// compute across entities.
    /// </summary>
    [Cmdlet("Get", "SMClusterSchedulerConfig")]
    [OutputType("Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribeClusterSchedulerConfig API operation.", Operation = new[] {"DescribeClusterSchedulerConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse object containing multiple properties."
    )]
    public partial class GetSMClusterSchedulerConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterSchedulerConfigId
        /// <summary>
        /// <para>
        /// <para>ID of the cluster policy.</para>
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
        public System.String ClusterSchedulerConfigId { get; set; }
        #endregion
        
        #region Parameter ClusterSchedulerConfigVersion
        /// <summary>
        /// <para>
        /// <para>Version of the cluster policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ClusterSchedulerConfigVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse, GetSMClusterSchedulerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterSchedulerConfigId = this.ClusterSchedulerConfigId;
            #if MODULAR
            if (this.ClusterSchedulerConfigId == null && ParameterWasBound(nameof(this.ClusterSchedulerConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterSchedulerConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterSchedulerConfigVersion = this.ClusterSchedulerConfigVersion;
            
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
            var request = new Amazon.SageMaker.Model.DescribeClusterSchedulerConfigRequest();
            
            if (cmdletContext.ClusterSchedulerConfigId != null)
            {
                request.ClusterSchedulerConfigId = cmdletContext.ClusterSchedulerConfigId;
            }
            if (cmdletContext.ClusterSchedulerConfigVersion != null)
            {
                request.ClusterSchedulerConfigVersion = cmdletContext.ClusterSchedulerConfigVersion.Value;
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
        
        private Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribeClusterSchedulerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribeClusterSchedulerConfig");
            try
            {
                return client.DescribeClusterSchedulerConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterSchedulerConfigId { get; set; }
            public System.Int32? ClusterSchedulerConfigVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribeClusterSchedulerConfigResponse, GetSMClusterSchedulerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
