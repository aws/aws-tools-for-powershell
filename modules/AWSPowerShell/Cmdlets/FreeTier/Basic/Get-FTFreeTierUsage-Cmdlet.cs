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
using Amazon.FreeTier;
using Amazon.FreeTier.Model;

namespace Amazon.PowerShell.Cmdlets.FT
{
    /// <summary>
    /// Returns a list of all Free Tier usage objects that match your filters.
    /// </summary>
    [Cmdlet("Get", "FTFreeTierUsage")]
    [OutputType("Amazon.FreeTier.Model.FreeTierUsage")]
    [AWSCmdlet("Calls the AWS Free Tier GetFreeTierUsage API operation.", Operation = new[] {"GetFreeTierUsage"}, SelectReturnType = typeof(Amazon.FreeTier.Model.GetFreeTierUsageResponse))]
    [AWSCmdletOutput("Amazon.FreeTier.Model.FreeTierUsage or Amazon.FreeTier.Model.GetFreeTierUsageResponse",
        "This cmdlet returns a collection of Amazon.FreeTier.Model.FreeTierUsage objects.",
        "The service call response (type Amazon.FreeTier.Model.GetFreeTierUsageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetFTFreeTierUsageCmdlet : AmazonFreeTierClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An expression that specifies the conditions that you want each <c>FreeTierUsage</c>
        /// object to meet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.FreeTier.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response. <c>MaxResults</c> means that
        /// there can be up to the specified number of values, but there might be fewer results
        /// based on your filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FreeTierUsages'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FreeTier.Model.GetFreeTierUsageResponse).
        /// Specifying the name of a property of type Amazon.FreeTier.Model.GetFreeTierUsageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FreeTierUsages";
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
                context.Select = CreateSelectDelegate<Amazon.FreeTier.Model.GetFreeTierUsageResponse, GetFTFreeTierUsageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
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
            var request = new Amazon.FreeTier.Model.GetFreeTierUsageRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
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
        
        private Amazon.FreeTier.Model.GetFreeTierUsageResponse CallAWSServiceOperation(IAmazonFreeTier client, Amazon.FreeTier.Model.GetFreeTierUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Free Tier", "GetFreeTierUsage");
            try
            {
                #if DESKTOP
                return client.GetFreeTierUsage(request);
                #elif CORECLR
                return client.GetFreeTierUsageAsync(request).GetAwaiter().GetResult();
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
            public Amazon.FreeTier.Model.Expression Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.FreeTier.Model.GetFreeTierUsageResponse, GetFTFreeTierUsageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FreeTierUsages;
        }
        
    }
}
