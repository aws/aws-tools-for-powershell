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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Returns the count, average, sum, minimum, maximum, sum of squares, variance, and standard
    /// deviation for the specified aggregated field. If the aggregation field is of type
    /// <c>String</c>, only the count statistic is returned.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">GetStatistics</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTStatistic")]
    [OutputType("Amazon.IoT.Model.Statistics")]
    [AWSCmdlet("Calls the AWS IoT GetStatistics API operation.", Operation = new[] {"GetStatistics"}, SelectReturnType = typeof(Amazon.IoT.Model.GetStatisticsResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.Statistics or Amazon.IoT.Model.GetStatisticsResponse",
        "This cmdlet returns an Amazon.IoT.Model.Statistics object.",
        "The service call response (type Amazon.IoT.Model.GetStatisticsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTStatisticCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AggregationField
        /// <summary>
        /// <para>
        /// <para>The aggregation field name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AggregationField { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the index to search. The default value is <c>AWS_Things</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The query used to search. You can specify "*" for the query string to get the count
        /// of all indexed things in your Amazon Web Services account.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter QueryVersion
        /// <summary>
        /// <para>
        /// <para>The version of the query used to search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statistics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.GetStatisticsResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.GetStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statistics";
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
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.GetStatisticsResponse, GetIOTStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregationField = this.AggregationField;
            context.IndexName = this.IndexName;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryVersion = this.QueryVersion;
            
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
            var request = new Amazon.IoT.Model.GetStatisticsRequest();
            
            if (cmdletContext.AggregationField != null)
            {
                request.AggregationField = cmdletContext.AggregationField;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            if (cmdletContext.QueryVersion != null)
            {
                request.QueryVersion = cmdletContext.QueryVersion;
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
        
        private Amazon.IoT.Model.GetStatisticsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.GetStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "GetStatistics");
            try
            {
                return client.GetStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AggregationField { get; set; }
            public System.String IndexName { get; set; }
            public System.String QueryString { get; set; }
            public System.String QueryVersion { get; set; }
            public System.Func<Amazon.IoT.Model.GetStatisticsResponse, GetIOTStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statistics;
        }
        
    }
}
