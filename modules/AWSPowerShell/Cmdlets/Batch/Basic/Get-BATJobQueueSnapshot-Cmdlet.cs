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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Provides a list of the first 100 <c>RUNNABLE</c> jobs associated to a single job queue.
    /// </summary>
    [Cmdlet("Get", "BATJobQueueSnapshot")]
    [OutputType("Amazon.Batch.Model.FrontOfQueueDetail")]
    [AWSCmdlet("Calls the AWS Batch GetJobQueueSnapshot API operation.", Operation = new[] {"GetJobQueueSnapshot"}, SelectReturnType = typeof(Amazon.Batch.Model.GetJobQueueSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.FrontOfQueueDetail or Amazon.Batch.Model.GetJobQueueSnapshotResponse",
        "This cmdlet returns an Amazon.Batch.Model.FrontOfQueueDetail object.",
        "The service call response (type Amazon.Batch.Model.GetJobQueueSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBATJobQueueSnapshotCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The job queue’s name or full queue Amazon Resource Name (ARN).</para>
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
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FrontOfQueue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.GetJobQueueSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.GetJobQueueSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FrontOfQueue";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.GetJobQueueSnapshotResponse, GetBATJobQueueSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobQueue = this.JobQueue;
            #if MODULAR
            if (this.JobQueue == null && ParameterWasBound(nameof(this.JobQueue)))
            {
                WriteWarning("You are passing $null as a value for parameter JobQueue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Batch.Model.GetJobQueueSnapshotRequest();
            
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
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
        
        private Amazon.Batch.Model.GetJobQueueSnapshotResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.GetJobQueueSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "GetJobQueueSnapshot");
            try
            {
                #if DESKTOP
                return client.GetJobQueueSnapshot(request);
                #elif CORECLR
                return client.GetJobQueueSnapshotAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String JobQueue { get; set; }
            public System.Func<Amazon.Batch.Model.GetJobQueueSnapshotResponse, GetBATJobQueueSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FrontOfQueue;
        }
        
    }
}
