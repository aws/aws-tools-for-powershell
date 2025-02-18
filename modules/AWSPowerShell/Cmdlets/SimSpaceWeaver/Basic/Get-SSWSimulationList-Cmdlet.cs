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
using Amazon.SimSpaceWeaver;
using Amazon.SimSpaceWeaver.Model;

namespace Amazon.PowerShell.Cmdlets.SSW
{
    /// <summary>
    /// Lists the SimSpace Weaver simulations in the Amazon Web Services account used to make
    /// the API call.
    /// </summary>
    [Cmdlet("Get", "SSWSimulationList")]
    [OutputType("Amazon.SimSpaceWeaver.Model.SimulationMetadata")]
    [AWSCmdlet("Calls the AWS SimSpace Weaver ListSimulations API operation.", Operation = new[] {"ListSimulations"}, SelectReturnType = typeof(Amazon.SimSpaceWeaver.Model.ListSimulationsResponse))]
    [AWSCmdletOutput("Amazon.SimSpaceWeaver.Model.SimulationMetadata or Amazon.SimSpaceWeaver.Model.ListSimulationsResponse",
        "This cmdlet returns a collection of Amazon.SimSpaceWeaver.Model.SimulationMetadata objects.",
        "The service call response (type Amazon.SimSpaceWeaver.Model.ListSimulationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSWSimulationListCmdlet : AmazonSimSpaceWeaverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of simulations to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If SimSpace Weaver returns <c>nextToken</c>, then there are more results available.
        /// The value of <c>nextToken</c> is a unique pagination token for each page. To retrieve
        /// the next page, call the operation again using the returned token. Keep all other arguments
        /// unchanged. If no results remain, then <c>nextToken</c> is set to <c>null</c>. Each
        /// pagination token expires after 24 hours. If you provide a token that isn't valid,
        /// then you receive an <i>HTTP 400 ValidationException</i> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Simulations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimSpaceWeaver.Model.ListSimulationsResponse).
        /// Specifying the name of a property of type Amazon.SimSpaceWeaver.Model.ListSimulationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Simulations";
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
                context.Select = CreateSelectDelegate<Amazon.SimSpaceWeaver.Model.ListSimulationsResponse, GetSSWSimulationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.SimSpaceWeaver.Model.ListSimulationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.SimSpaceWeaver.Model.ListSimulationsResponse CallAWSServiceOperation(IAmazonSimSpaceWeaver client, Amazon.SimSpaceWeaver.Model.ListSimulationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS SimSpace Weaver", "ListSimulations");
            try
            {
                return client.ListSimulationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SimSpaceWeaver.Model.ListSimulationsResponse, GetSSWSimulationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Simulations;
        }
        
    }
}
