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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Returns information about an ingestion stream, including its configuration, status,
    /// and processing state.
    /// </summary>
    [Cmdlet("Get", "OSSIngestionStream")]
    [OutputType("Amazon.OpenSearchServerless.Model.IngestionStreamDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless GetIngestionStream API operation.", Operation = new[] {"GetIngestionStream"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.IngestionStreamDetail or Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.IngestionStreamDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSSIngestionStreamCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the collection that the ingestion stream belongs to.</para>
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
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter IngestionStreamId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ingestion stream to retrieve.</para>
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
        public System.String IngestionStreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngestionStreamDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngestionStreamDetail";
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
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse, GetOSSIngestionStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionStreamId = this.IngestionStreamId;
            #if MODULAR
            if (this.IngestionStreamId == null && ParameterWasBound(nameof(this.IngestionStreamId)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionStreamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchServerless.Model.GetIngestionStreamRequest();
            
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            if (cmdletContext.IngestionStreamId != null)
            {
                request.IngestionStreamId = cmdletContext.IngestionStreamId;
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
        
        private Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.GetIngestionStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "GetIngestionStream");
            try
            {
                return client.GetIngestionStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollectionId { get; set; }
            public System.String IngestionStreamId { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.GetIngestionStreamResponse, GetOSSIngestionStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngestionStreamDetail;
        }
        
    }
}
