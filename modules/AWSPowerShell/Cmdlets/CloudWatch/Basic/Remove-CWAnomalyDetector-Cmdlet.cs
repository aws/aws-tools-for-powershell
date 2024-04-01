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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Deletes the specified anomaly detection model from your account. For more information
    /// about how to delete an anomaly detection model, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Create_Anomaly_Detection_Alarm.html#Delete_Anomaly_Detection_Model">Deleting
    /// an anomaly detection model</a> in the <i>CloudWatch User Guide</i>.
    /// </summary>
    [Cmdlet("Remove", "CWAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch DeleteAnomalyDetector API operation.", Operation = new[] {"DeleteAnomalyDetector"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCWAnomalyDetectorCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SingleMetricAnomalyDetector_AccountId
        /// <summary>
        /// <para>
        /// <para>If the CloudWatch metric that provides the time series that the anomaly detector uses
        /// as input is in another account, specify that account ID here. If you omit this parameter,
        /// the current account is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleMetricAnomalyDetector_AccountId { get; set; }
        #endregion
        
        #region Parameter SingleMetricAnomalyDetector_Dimension
        /// <summary>
        /// <para>
        /// <para>The metric dimensions to create the anomaly detection model for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SingleMetricAnomalyDetector_Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] SingleMetricAnomalyDetector_Dimension { get; set; }
        #endregion
        
        #region Parameter MetricMathAnomalyDetector_MetricDataQuery
        /// <summary>
        /// <para>
        /// <para>An array of metric data query structures that enables you to create an anomaly detector
        /// based on the result of a metric math expression. Each item in <c>MetricDataQueries</c>
        /// gets a metric or performs a math expression. One item in <c>MetricDataQueries</c>
        /// is the expression that provides the time series that the anomaly detector uses as
        /// input. Designate the expression by setting <c>ReturnData</c> to <c>true</c> for this
        /// object in the array. For all other expressions and metrics, set <c>ReturnData</c>
        /// to <c>false</c>. The designated expression must return a single time series.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricMathAnomalyDetector_MetricDataQueries")]
        public Amazon.CloudWatch.Model.MetricDataQuery[] MetricMathAnomalyDetector_MetricDataQuery { get; set; }
        #endregion
        
        #region Parameter SingleMetricAnomalyDetector_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to create the anomaly detection model for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleMetricAnomalyDetector_MetricName { get; set; }
        #endregion
        
        #region Parameter SingleMetricAnomalyDetector_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric to create the anomaly detection model for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleMetricAnomalyDetector_Namespace { get; set; }
        #endregion
        
        #region Parameter SingleMetricAnomalyDetector_Stat
        /// <summary>
        /// <para>
        /// <para>The statistic to use for the metric and anomaly detection model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleMetricAnomalyDetector_Stat { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The metric dimensions associated with the anomaly detection model to delete.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use SingleMetricAnomalyDetector.")]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The metric name associated with the anomaly detection model to delete.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [System.ObsoleteAttribute("Use SingleMetricAnomalyDetector.")]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace associated with the anomaly detection model to delete.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use SingleMetricAnomalyDetector.")]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Stat
        /// <summary>
        /// <para>
        /// <para>The statistic associated with the anomaly detection model to delete.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use SingleMetricAnomalyDetector.")]
        public System.String Stat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MetricName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MetricName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MetricName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetricName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWAnomalyDetector (DeleteAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse, RemoveCWAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MetricName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.MetricMathAnomalyDetector_MetricDataQuery != null)
            {
                context.MetricMathAnomalyDetector_MetricDataQuery = new List<Amazon.CloudWatch.Model.MetricDataQuery>(this.MetricMathAnomalyDetector_MetricDataQuery);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MetricName = this.MetricName;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Namespace = this.Namespace;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SingleMetricAnomalyDetector_AccountId = this.SingleMetricAnomalyDetector_AccountId;
            if (this.SingleMetricAnomalyDetector_Dimension != null)
            {
                context.SingleMetricAnomalyDetector_Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.SingleMetricAnomalyDetector_Dimension);
            }
            context.SingleMetricAnomalyDetector_MetricName = this.SingleMetricAnomalyDetector_MetricName;
            context.SingleMetricAnomalyDetector_Namespace = this.SingleMetricAnomalyDetector_Namespace;
            context.SingleMetricAnomalyDetector_Stat = this.SingleMetricAnomalyDetector_Stat;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Stat = this.Stat;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.CloudWatch.Model.DeleteAnomalyDetectorRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
             // populate MetricMathAnomalyDetector
            var requestMetricMathAnomalyDetectorIsNull = true;
            request.MetricMathAnomalyDetector = new Amazon.CloudWatch.Model.MetricMathAnomalyDetector();
            List<Amazon.CloudWatch.Model.MetricDataQuery> requestMetricMathAnomalyDetector_metricMathAnomalyDetector_MetricDataQuery = null;
            if (cmdletContext.MetricMathAnomalyDetector_MetricDataQuery != null)
            {
                requestMetricMathAnomalyDetector_metricMathAnomalyDetector_MetricDataQuery = cmdletContext.MetricMathAnomalyDetector_MetricDataQuery;
            }
            if (requestMetricMathAnomalyDetector_metricMathAnomalyDetector_MetricDataQuery != null)
            {
                request.MetricMathAnomalyDetector.MetricDataQueries = requestMetricMathAnomalyDetector_metricMathAnomalyDetector_MetricDataQuery;
                requestMetricMathAnomalyDetectorIsNull = false;
            }
             // determine if request.MetricMathAnomalyDetector should be set to null
            if (requestMetricMathAnomalyDetectorIsNull)
            {
                request.MetricMathAnomalyDetector = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
             // populate SingleMetricAnomalyDetector
            var requestSingleMetricAnomalyDetectorIsNull = true;
            request.SingleMetricAnomalyDetector = new Amazon.CloudWatch.Model.SingleMetricAnomalyDetector();
            System.String requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_AccountId = null;
            if (cmdletContext.SingleMetricAnomalyDetector_AccountId != null)
            {
                requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_AccountId = cmdletContext.SingleMetricAnomalyDetector_AccountId;
            }
            if (requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_AccountId != null)
            {
                request.SingleMetricAnomalyDetector.AccountId = requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_AccountId;
                requestSingleMetricAnomalyDetectorIsNull = false;
            }
            List<Amazon.CloudWatch.Model.Dimension> requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Dimension = null;
            if (cmdletContext.SingleMetricAnomalyDetector_Dimension != null)
            {
                requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Dimension = cmdletContext.SingleMetricAnomalyDetector_Dimension;
            }
            if (requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Dimension != null)
            {
                request.SingleMetricAnomalyDetector.Dimensions = requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Dimension;
                requestSingleMetricAnomalyDetectorIsNull = false;
            }
            System.String requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_MetricName = null;
            if (cmdletContext.SingleMetricAnomalyDetector_MetricName != null)
            {
                requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_MetricName = cmdletContext.SingleMetricAnomalyDetector_MetricName;
            }
            if (requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_MetricName != null)
            {
                request.SingleMetricAnomalyDetector.MetricName = requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_MetricName;
                requestSingleMetricAnomalyDetectorIsNull = false;
            }
            System.String requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Namespace = null;
            if (cmdletContext.SingleMetricAnomalyDetector_Namespace != null)
            {
                requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Namespace = cmdletContext.SingleMetricAnomalyDetector_Namespace;
            }
            if (requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Namespace != null)
            {
                request.SingleMetricAnomalyDetector.Namespace = requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Namespace;
                requestSingleMetricAnomalyDetectorIsNull = false;
            }
            System.String requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Stat = null;
            if (cmdletContext.SingleMetricAnomalyDetector_Stat != null)
            {
                requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Stat = cmdletContext.SingleMetricAnomalyDetector_Stat;
            }
            if (requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Stat != null)
            {
                request.SingleMetricAnomalyDetector.Stat = requestSingleMetricAnomalyDetector_singleMetricAnomalyDetector_Stat;
                requestSingleMetricAnomalyDetectorIsNull = false;
            }
             // determine if request.SingleMetricAnomalyDetector should be set to null
            if (requestSingleMetricAnomalyDetectorIsNull)
            {
                request.SingleMetricAnomalyDetector = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Stat != null)
            {
                request.Stat = cmdletContext.Stat;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DeleteAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DeleteAnomalyDetector");
            try
            {
                #if DESKTOP
                return client.DeleteAnomalyDetector(request);
                #elif CORECLR
                return client.DeleteAnomalyDetectorAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public List<Amazon.CloudWatch.Model.Dimension> Dimension { get; set; }
            public List<Amazon.CloudWatch.Model.MetricDataQuery> MetricMathAnomalyDetector_MetricDataQuery { get; set; }
            [System.ObsoleteAttribute]
            public System.String MetricName { get; set; }
            [System.ObsoleteAttribute]
            public System.String Namespace { get; set; }
            public System.String SingleMetricAnomalyDetector_AccountId { get; set; }
            public List<Amazon.CloudWatch.Model.Dimension> SingleMetricAnomalyDetector_Dimension { get; set; }
            public System.String SingleMetricAnomalyDetector_MetricName { get; set; }
            public System.String SingleMetricAnomalyDetector_Namespace { get; set; }
            public System.String SingleMetricAnomalyDetector_Stat { get; set; }
            [System.ObsoleteAttribute]
            public System.String Stat { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DeleteAnomalyDetectorResponse, RemoveCWAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
