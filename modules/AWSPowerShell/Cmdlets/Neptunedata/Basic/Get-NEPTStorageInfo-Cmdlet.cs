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
    /// Retrieves storage information for the Neptune database instance, including approximate
    /// total storage used and per-category size and entry counts. Storage categories include:
    /// 
    ///  <ul><li><para><i>Quad indexes</i> - the indexes that store graph data, for both RDF (SPARQL) and
    /// Property Graph (Gremlin/openCypher) models.
    /// </para></li><li><para><i>Dictionaries</i> - the term dictionaries, including total dictionary storage and
    /// the portion used by blob (large value) entries.
    /// </para></li><li><para><i>Undo logs</i> - the undo logs, reported as a total size and the number of entries
    /// in the undo log list.
    /// </para></li><li><para><i>Streams</i> - the change-log streams.
    /// </para></li><li><para><i>Schema</i> - the schema.
    /// </para></li><li><para><i>DFE statistics</i> - the DFE engine statistics.
    /// </para></li><li><para><i>System metadata</i> - internal system metadata.
    /// </para></li></ul><para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#getstorageinfo">neptune-db:GetStorageInfo</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTStorageInfo")]
    [OutputType("Amazon.Neptunedata.Model.GetStorageInfoResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData GetStorageInfo API operation.", Operation = new[] {"GetStorageInfo"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.GetStorageInfoResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.GetStorageInfoResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.GetStorageInfoResponse object containing multiple properties."
    )]
    public partial class GetNEPTStorageInfoCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.GetStorageInfoResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.GetStorageInfoResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.GetStorageInfoResponse, GetNEPTStorageInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.Neptunedata.Model.GetStorageInfoRequest();
            
            
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
        
        private Amazon.Neptunedata.Model.GetStorageInfoResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.GetStorageInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "GetStorageInfo");
            try
            {
                return client.GetStorageInfoAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Neptunedata.Model.GetStorageInfoResponse, GetNEPTStorageInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
