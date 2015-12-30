/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// <para> Returns a list of valid metrics stored for the AWS account owner. Returned metrics can be used with GetMetricStatistics to obtain
    /// statistical data for a given metric. </para><para><b>NOTE:</b> Up to 500 results are returned for any one call. To retrieve further
    /// results, use returned NextToken values with subsequent ListMetrics operations. </para><para><b>NOTE:</b> If you create a metric with the
    /// PutMetricData action, allow up to fifteen minutes for the metric to appear in calls to the ListMetrics action. Statistics about the metric,
    /// however, are available sooner using GetMetricStatistics. </para>
    /// </summary>
    [Cmdlet("Get", "CWMetrics")]
    [OutputType("Amazon.CloudWatch.Model.Metric")]
    [AWSCmdlet("Invokes the ListMetrics operation against Amazon CloudWatch.", Operation = new [] {"ListMetrics"})]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.Metric",
        "This cmdlet returns 0 or more Metric instances.",
        "The service response (type Amazon.CloudWatch.Model.ListMetricsResponse) is added to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as notes to the service response type instance in the history stack: NextToken (type String)"
    )]
    public class GetCWMetricsCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// The namespace to filter against.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>1 - 255</description></item><item><term>Pattern</term><description>[^:].*</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Namespace { get; set; }
        #endregion

        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// The name of the metric to filter against.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>1 - 255</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion

        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// A list of dimensions to filter against.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>0 - 10</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 2)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.DimensionFilter[] Dimension { get; set; }
        #endregion

        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The token returned by a previous call to indicate that there is more data available.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String NextToken { get; set; }
        #endregion

        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all metrics to the pipeline. If set,
        /// the cmdlet will retrieve only the next 'page' of results (max 500 entries) using the 
        /// value of NextToken as the start point.
        /// </summary>
        [Parameter]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  Namespace = this.Namespace,
                                  MetricName = this.MetricName
                              };

            if (this.Dimension != null)
            {
                context.Dimensions = new List<DimensionFilter>(this.Dimension);
            }
            context.NextToken = this.NextToken;
            context.NoAutoIteration = this.NoAutoIteration.IsPresent;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            // create request and set iteration invariants
            var request = new ListMetricsRequest();
            
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Dimensions != null)
            {
                request.Dimensions = cmdletContext.Dimensions;
            }

            // Initialize loop variant and commence piping
            String _nextMarker = null;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            
            do
            {
                request.NextToken = _nextMarker;

                var client = Client ?? CreateClient(context.Credentials, context.Region);
                CmdletOutput output;

                try
                {            
                    var response = client.ListMetrics(request);
                    Dictionary<string, object> notes = null;
                    notes = new Dictionary<string, object>();
                    notes["NextToken"] = response.NextToken;
                    output = new CmdletOutput
                    {
                        PipelineOutput = response.Metrics,
                        ServiceResponse = response,
                        Notes = notes
                    };
                    
                    _nextMarker = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }

                ProcessOutput(output);
            } while (!cmdletContext.NoAutoIteration && AutoIterationHelpers.HasValue(_nextMarker));

            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Namespace { get; set; }
            public String MetricName { get; set; }
            public List<DimensionFilter> Dimensions { get; set; }
            public String NextToken { get; set; }
            public bool NoAutoIteration { get; set; }
        }
        
    }
}
