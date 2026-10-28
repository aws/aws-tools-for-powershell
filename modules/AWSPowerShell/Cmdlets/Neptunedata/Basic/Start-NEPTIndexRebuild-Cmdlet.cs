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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Initiates an index rebuild operation to optimize storage and improve query performance.
    /// The rebuild operation reorganizes index to reclaim space and improve efficiency.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#startindexrebuild">neptune-db:StartIndexRebuild</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NEPTIndexRebuild", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptunedata.Model.StartIndexRebuildResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData StartIndexRebuild API operation.", Operation = new[] {"StartIndexRebuild"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.StartIndexRebuildResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.StartIndexRebuildResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.StartIndexRebuildResponse object containing multiple properties."
    )]
    public partial class StartNEPTIndexRebuildCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Concurrency
        /// <summary>
        /// <para>
        /// <para>The number of concurrent indexes to rebuild in parallel. If not specified, defaults
        /// to <c>1</c>.</para><para>Valid values are between <c>1</c> and the number of vCPUs available on the writer
        /// instance. If the value exceeds the available vCPUs, it is capped at the maximum instead
        /// of returning an <c>InvalidParameterException</c>. The effective (capped) value is
        /// returned in the response.</para><para>Higher concurrency can shorten the overall rebuild, but also increases CPU and I/O
        /// load during the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Concurrency { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies the scope of the rebuild operation. Possible values are:</para><ul><li><para><c>ALL</c> - Rebuild all (quads and dictionaries). This is the default if not specified.</para></li><li><para><c>QUADS</c> - Rebuild only the quad indexes. </para></li><li><para><c>DICTIONARIES</c> - Rebuild only the dictionaries.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Scope")]
        public Amazon.Neptunedata.Scope Scope { get; set; }
        #endregion
        
        #region Parameter WriteBufferSize
        /// <summary>
        /// <para>
        /// <para>Controls the buffer size used for tracking concurrent write operations during the
        /// index rebuild. If your database has high write traffic during the rebuild, a larger
        /// buffer prevents the operation from failing due to buffer overflow. Possible values
        /// are:</para><ul><li><para><c>LOW</c> - Suitable for databases with light to moderate write activity. This is
        /// the default.</para></li><li><para><c>MEDIUM</c> - Recommended for databases with sustained write traffic or bulk loading.</para></li><li><para><c>HIGH</c> - Use when rebuilding indexes during heavy write workloads or continuous
        /// bulk data ingestion.</para></li></ul><para>If your rebuild fails and you are actively writing data to the database, retry with
        /// a higher <c>writeBufferSize</c> value. For bulk load operations, consider using <c>HIGH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.WriteBufferSize")]
        public Amazon.Neptunedata.WriteBufferSize WriteBufferSize { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.StartIndexRebuildResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.StartIndexRebuildResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NEPTIndexRebuild (StartIndexRebuild)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.StartIndexRebuildResponse, StartNEPTIndexRebuildCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Concurrency = this.Concurrency;
            context.Scope = this.Scope;
            context.WriteBufferSize = this.WriteBufferSize;
            
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
            var request = new Amazon.Neptunedata.Model.StartIndexRebuildRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Concurrency != null)
            {
                request.Concurrency = cmdletContext.Concurrency.Value;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.WriteBufferSize != null)
            {
                request.WriteBufferSize = cmdletContext.WriteBufferSize;
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
        
        private Amazon.Neptunedata.Model.StartIndexRebuildResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.StartIndexRebuildRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "StartIndexRebuild");
            try
            {
                return client.StartIndexRebuildAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Concurrency { get; set; }
            public Amazon.Neptunedata.Scope Scope { get; set; }
            public Amazon.Neptunedata.WriteBufferSize WriteBufferSize { get; set; }
            public System.Func<Amazon.Neptunedata.Model.StartIndexRebuildResponse, StartNEPTIndexRebuildCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
