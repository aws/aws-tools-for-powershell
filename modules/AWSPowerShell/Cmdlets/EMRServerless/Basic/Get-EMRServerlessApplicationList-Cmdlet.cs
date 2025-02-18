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
using Amazon.EMRServerless;
using Amazon.EMRServerless.Model;

namespace Amazon.PowerShell.Cmdlets.EMRServerless
{
    /// <summary>
    /// Lists applications based on a set of parameters.
    /// </summary>
    [Cmdlet("Get", "EMRServerlessApplicationList")]
    [OutputType("Amazon.EMRServerless.Model.ApplicationSummary")]
    [AWSCmdlet("Calls the EMR Serverless ListApplications API operation.", Operation = new[] {"ListApplications"}, SelectReturnType = typeof(Amazon.EMRServerless.Model.ListApplicationsResponse))]
    [AWSCmdletOutput("Amazon.EMRServerless.Model.ApplicationSummary or Amazon.EMRServerless.Model.ListApplicationsResponse",
        "This cmdlet returns a collection of Amazon.EMRServerless.Model.ApplicationSummary objects.",
        "The service call response (type Amazon.EMRServerless.Model.ListApplicationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMRServerlessApplicationListCmdlet : AmazonEMRServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>An optional filter for application states. Note that if this filter contains multiple
        /// states, the resulting list will be grouped by the state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of applications that can be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of application results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Applications'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRServerless.Model.ListApplicationsResponse).
        /// Specifying the name of a property of type Amazon.EMRServerless.Model.ListApplicationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Applications";
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
                context.Select = CreateSelectDelegate<Amazon.EMRServerless.Model.ListApplicationsResponse, GetEMRServerlessApplicationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
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
            var request = new Amazon.EMRServerless.Model.ListApplicationsRequest();
            
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
        
        private Amazon.EMRServerless.Model.ListApplicationsResponse CallAWSServiceOperation(IAmazonEMRServerless client, Amazon.EMRServerless.Model.ListApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EMR Serverless", "ListApplications");
            try
            {
                return client.ListApplicationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> State { get; set; }
            public System.Func<Amazon.EMRServerless.Model.ListApplicationsResponse, GetEMRServerlessApplicationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Applications;
        }
        
    }
}
