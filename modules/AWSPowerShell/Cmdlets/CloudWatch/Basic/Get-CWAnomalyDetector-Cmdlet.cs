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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Lists the anomaly detection models that you have created in your account. For single
    /// metric anomaly detectors, you can list all of the models in your account or filter
    /// the results to only the models that are related to a certain namespace, metric name,
    /// or metric dimension. For metric math anomaly detectors, you can list them by adding
    /// <c>METRIC_MATH</c> to the <c>AnomalyDetectorTypes</c> array. This will return all
    /// metric math anomaly detectors in your account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWAnomalyDetector")]
    [OutputType("Amazon.CloudWatch.Model.AnomalyDetector")]
    [AWSCmdlet("Calls the Amazon CloudWatch DescribeAnomalyDetectors API operation.", Operation = new[] {"DescribeAnomalyDetectors"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.AnomalyDetector or Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.AnomalyDetector objects.",
        "The service call response (type Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWAnomalyDetectorCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorType
        /// <summary>
        /// <para>
        /// <para>The anomaly detector types to request when using <c>DescribeAnomalyDetectorsInput</c>.
        /// If empty, defaults to <c>SINGLE_METRIC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnomalyDetectorTypes")]
        public System.String[] AnomalyDetectorType { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>Limits the results to only the anomaly detection models that are associated with the
        /// specified metric dimensions. If there are multiple metrics that have these dimensions
        /// and have anomaly detection models associated, they're all returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>Limits the results to only the anomaly detection models that are associated with the
        /// specified metric name. If there are multiple metrics with this name in different namespaces
        /// that have anomaly detection models, they're all returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>Limits the results to only the anomaly detection models that are associated with the
        /// specified namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one operation. The maximum value that you
        /// can specify is 100.</para><para>To retrieve the remaining results, make another call with the returned <c>NextToken</c>
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use the token returned by the previous operation to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyDetectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyDetectors";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse, GetCWAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AnomalyDetectorType != null)
            {
                context.AnomalyDetectorType = new List<System.String>(this.AnomalyDetectorType);
            }
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            context.MaxResult = this.MaxResult;
            context.MetricName = this.MetricName;
            context.Namespace = this.Namespace;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatch.Model.DescribeAnomalyDetectorsRequest();
            
            if (cmdletContext.AnomalyDetectorType != null)
            {
                request.AnomalyDetectorTypes = cmdletContext.AnomalyDetectorType;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DescribeAnomalyDetectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DescribeAnomalyDetectors");
            try
            {
                return client.DescribeAnomalyDetectorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AnomalyDetectorType { get; set; }
            public List<Amazon.CloudWatch.Model.Dimension> Dimension { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DescribeAnomalyDetectorsResponse, GetCWAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyDetectors;
        }
        
    }
}
