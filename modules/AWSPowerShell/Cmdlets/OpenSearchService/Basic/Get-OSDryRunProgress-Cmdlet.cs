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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Describes the progress of a pre-update dry run analysis on an Amazon OpenSearch Service
    /// domain. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/managedomains-configuration-changes#dryrun">Determining
    /// whether a change will cause a blue/green deployment</a>.
    /// </summary>
    [Cmdlet("Get", "OSDryRunProgress")]
    [OutputType("Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service DescribeDryRunProgress API operation.", Operation = new[] {"DescribeDryRunProgress"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse object containing multiple properties."
    )]
    public partial class GetOSDryRunProgressCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DryRunId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the dry run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DryRunId { get; set; }
        #endregion
        
        #region Parameter LoadDryRunConfig
        /// <summary>
        /// <para>
        /// <para>Whether to include the configuration of the dry run in the response. The configuration
        /// specifies the updates that you're planning to make on the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoadDryRunConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse, GetOSDryRunProgressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRunId = this.DryRunId;
            context.LoadDryRunConfig = this.LoadDryRunConfig;
            
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
            var request = new Amazon.OpenSearchService.Model.DescribeDryRunProgressRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DryRunId != null)
            {
                request.DryRunId = cmdletContext.DryRunId;
            }
            if (cmdletContext.LoadDryRunConfig != null)
            {
                request.LoadDryRunConfig = cmdletContext.LoadDryRunConfig.Value;
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
        
        private Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.DescribeDryRunProgressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "DescribeDryRunProgress");
            try
            {
                return client.DescribeDryRunProgressAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String DryRunId { get; set; }
            public System.Boolean? LoadDryRunConfig { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.DescribeDryRunProgressResponse, GetOSDryRunProgressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
