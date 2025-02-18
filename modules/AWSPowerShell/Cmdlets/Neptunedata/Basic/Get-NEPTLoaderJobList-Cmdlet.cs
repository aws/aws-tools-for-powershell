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

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Retrieves a list of the <c>loadIds</c> for all active loader jobs.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#listloaderjobs">neptune-db:ListLoaderJobs</a>
    /// IAM action in that cluster..
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTLoaderJobList")]
    [OutputType("Amazon.Neptunedata.Model.ListLoaderJobsResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData ListLoaderJobs API operation.", Operation = new[] {"ListLoaderJobs"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.ListLoaderJobsResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.ListLoaderJobsResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.ListLoaderJobsResponse object containing multiple properties."
    )]
    public partial class GetNEPTLoaderJobListCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeQueuedLoad
        /// <summary>
        /// <para>
        /// <para>An optional parameter that can be used to exclude the load IDs of queued load requests
        /// when requesting a list of load IDs by setting the parameter to <c>FALSE</c>. The default
        /// value is <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeQueuedLoads")]
        public System.Boolean? IncludeQueuedLoad { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The number of load IDs to list. Must be a positive integer greater than zero and not
        /// more than <c>100</c> (which is the default).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.ListLoaderJobsResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.ListLoaderJobsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.ListLoaderJobsResponse, GetNEPTLoaderJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeQueuedLoad = this.IncludeQueuedLoad;
            context.Limit = this.Limit;
            
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
            var request = new Amazon.Neptunedata.Model.ListLoaderJobsRequest();
            
            if (cmdletContext.IncludeQueuedLoad != null)
            {
                request.IncludeQueuedLoads = cmdletContext.IncludeQueuedLoad.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
        
        private Amazon.Neptunedata.Model.ListLoaderJobsResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.ListLoaderJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "ListLoaderJobs");
            try
            {
                return client.ListLoaderJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeQueuedLoad { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Func<Amazon.Neptunedata.Model.ListLoaderJobsResponse, GetNEPTLoaderJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
