/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Retrieves the results of a running or completed experiment. No results are available
    /// until there have been 100 events for each variation and at least 10 minutes have passed
    /// since the start of the experiment.
    /// 
    ///  
    /// <para>
    /// Experiment results are available up to 63 days after the start of the experiment.
    /// They are not available after that because of CloudWatch data retention policies.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWEVDExperimentResult")]
    [OutputType("Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently GetExperimentResults API operation.", Operation = new[] {"GetExperimentResults"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWEVDExperimentResultCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        #region Parameter BaseStat
        /// <summary>
        /// <para>
        /// <para>The statistic used to calculate experiment results. Currently the only valid value
        /// is <code>mean</code>, which uses the mean of the collected values as the statistic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchEvidently.ExperimentBaseStat")]
        public Amazon.CloudWatchEvidently.ExperimentBaseStat BaseStat { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time that the experiment ended, if it is completed. This must be no longer
        /// than 30 days after the experiment start time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Experiment
        /// <summary>
        /// <para>
        /// <para>The name of the experiment to retrieve the results of.</para>
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
        public System.String Experiment { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The names of the experiment metrics that you want to see the results of.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MetricNames")]
        public System.String[] MetricName { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>In seconds, the amount of time to aggregate results together. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Period { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains the experiment that you want to see the
        /// results of.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter ReportName
        /// <summary>
        /// <para>
        /// <para>The names of the report types that you want to see. Currently, <code>BayesianInference</code>
        /// is the only valid value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportNames")]
        public System.String[] ReportName { get; set; }
        #endregion
        
        #region Parameter ResultStat
        /// <summary>
        /// <para>
        /// <para>The statistics that you want to see in the returned results.</para><ul><li><para><code>PValue</code> specifies to use p-values for the results. A p-value is used
        /// in hypothesis testing to measure how often you are willing to make a mistake in rejecting
        /// the null hypothesis. A general practice is to reject the null hypothesis and declare
        /// that the results are statistically significant when the p-value is less than 0.05.</para></li><li><para><code>ConfidenceInterval</code> specifies a confidence interval for the results.
        /// The confidence interval represents the range of values for the chosen metric that
        /// is likely to contain the true difference between the <code>baseStat</code> of a variation
        /// and the baseline. Evidently returns the 95% confidence interval. </para></li><li><para><code>TreatmentEffect</code> is the difference in the statistic specified by the
        /// <code>baseStat</code> parameter between each variation and the default variation.
        /// </para></li><li><para><code>BaseStat</code> returns the statistical values collected for the metric for
        /// each variation. The statistic uses the same statistic specified in the <code>baseStat</code>
        /// parameter. Therefore, if <code>baseStat</code> is <code>mean</code>, this returns
        /// the mean of the values collected for each variation.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultStats")]
        public System.String[] ResultStat { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time that the experiment started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter TreatmentName
        /// <summary>
        /// <para>
        /// <para>The names of the experiment treatments that you want to see the results for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TreatmentNames")]
        public System.String[] TreatmentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse, GetCWEVDExperimentResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseStat = this.BaseStat;
            context.EndTime = this.EndTime;
            context.Experiment = this.Experiment;
            #if MODULAR
            if (this.Experiment == null && ParameterWasBound(nameof(this.Experiment)))
            {
                WriteWarning("You are passing $null as a value for parameter Experiment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricName != null)
            {
                context.MetricName = new List<System.String>(this.MetricName);
            }
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Period = this.Period;
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReportName != null)
            {
                context.ReportName = new List<System.String>(this.ReportName);
            }
            if (this.ResultStat != null)
            {
                context.ResultStat = new List<System.String>(this.ResultStat);
            }
            context.StartTime = this.StartTime;
            if (this.TreatmentName != null)
            {
                context.TreatmentName = new List<System.String>(this.TreatmentName);
            }
            #if MODULAR
            if (this.TreatmentName == null && ParameterWasBound(nameof(this.TreatmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter TreatmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvidently.Model.GetExperimentResultsRequest();
            
            if (cmdletContext.BaseStat != null)
            {
                request.BaseStat = cmdletContext.BaseStat;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Experiment != null)
            {
                request.Experiment = cmdletContext.Experiment;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricNames = cmdletContext.MetricName;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.ReportName != null)
            {
                request.ReportNames = cmdletContext.ReportName;
            }
            if (cmdletContext.ResultStat != null)
            {
                request.ResultStats = cmdletContext.ResultStat;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TreatmentName != null)
            {
                request.TreatmentNames = cmdletContext.TreatmentName;
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
        
        private Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.GetExperimentResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "GetExperimentResults");
            try
            {
                #if DESKTOP
                return client.GetExperimentResults(request);
                #elif CORECLR
                return client.GetExperimentResultsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudWatchEvidently.ExperimentBaseStat BaseStat { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String Experiment { get; set; }
            public List<System.String> MetricName { get; set; }
            public System.Int64? Period { get; set; }
            public System.String Project { get; set; }
            public List<System.String> ReportName { get; set; }
            public List<System.String> ResultStat { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<System.String> TreatmentName { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.GetExperimentResultsResponse, GetCWEVDExperimentResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
