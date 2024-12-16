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
using Amazon.AutoScalingPlans;
using Amazon.AutoScalingPlans.Model;

namespace Amazon.PowerShell.Cmdlets.ASP
{
    /// <summary>
    /// Retrieves the forecast data for a scalable resource.
    /// 
    ///  
    /// <para>
    /// Capacity forecasts are represented as predicted values, or data points, that are calculated
    /// using historical data points from a specified CloudWatch load metric. Data points
    /// are available for up to 56 days. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ASPScalingPlanResourceForecastData")]
    [OutputType("Amazon.AutoScalingPlans.Model.Datapoint")]
    [AWSCmdlet("Calls the AWS Auto Scaling Plans GetScalingPlanResourceForecastData API operation.", Operation = new[] {"GetScalingPlanResourceForecastData"}, SelectReturnType = typeof(Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse))]
    [AWSCmdletOutput("Amazon.AutoScalingPlans.Model.Datapoint or Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse",
        "This cmdlet returns a collection of Amazon.AutoScalingPlans.Model.Datapoint objects.",
        "The service call response (type Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetASPScalingPlanResourceForecastDataCmdlet : AmazonAutoScalingPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The exclusive end time of the time range for the forecast data to get. The maximum
        /// time duration between the start and end time is seven days. </para><para>Although this parameter can accept a date and time that is more than two days in the
        /// future, the availability of forecast data has limits. AWS Auto Scaling only issues
        /// forecasts for periods of two days in advance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter ForecastDataType
        /// <summary>
        /// <para>
        /// <para>The type of forecast data to get.</para><ul><li><para><c>LoadForecast</c>: The load metric forecast. </para></li><li><para><c>CapacityForecast</c>: The capacity forecast. </para></li><li><para><c>ScheduledActionMinCapacity</c>: The minimum capacity for each scheduled scaling
        /// action. This data is calculated as the larger of two values: the capacity forecast
        /// or the minimum capacity in the scaling instruction.</para></li><li><para><c>ScheduledActionMaxCapacity</c>: The maximum capacity for each scheduled scaling
        /// action. The calculation used is determined by the predictive scaling maximum capacity
        /// behavior setting in the scaling instruction.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AutoScalingPlans.ForecastDataType")]
        public Amazon.AutoScalingPlans.ForecastDataType ForecastDataType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource. This string consists of a prefix (<c>autoScalingGroup</c>)
        /// followed by the name of a specified Auto Scaling group (<c>my-asg</c>). Example: <c>autoScalingGroup/my-asg</c>.
        /// </para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension for the resource. The only valid value is <c>autoscaling:autoScalingGroup:DesiredCapacity</c>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AutoScalingPlans.ScalableDimension")]
        public Amazon.AutoScalingPlans.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter ScalingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling plan.</para>
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
        public System.String ScalingPlanName { get; set; }
        #endregion
        
        #region Parameter ScalingPlanVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the scaling plan. Currently, the only valid value is <c>1</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? ScalingPlanVersion { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the AWS service. The only valid value is <c>autoscaling</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AutoScalingPlans.ServiceNamespace")]
        public Amazon.AutoScalingPlans.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The inclusive start time of the time range for the forecast data to get. The date
        /// and time can be at most 56 days before the current date and time. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Datapoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse).
        /// Specifying the name of a property of type Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Datapoints";
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
                context.Select = CreateSelectDelegate<Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse, GetASPScalingPlanResourceForecastDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForecastDataType = this.ForecastDataType;
            #if MODULAR
            if (this.ForecastDataType == null && ParameterWasBound(nameof(this.ForecastDataType)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastDataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalableDimension = this.ScalableDimension;
            #if MODULAR
            if (this.ScalableDimension == null && ParameterWasBound(nameof(this.ScalableDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalableDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingPlanName = this.ScalingPlanName;
            #if MODULAR
            if (this.ScalingPlanName == null && ParameterWasBound(nameof(this.ScalingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingPlanVersion = this.ScalingPlanVersion;
            #if MODULAR
            if (this.ScalingPlanVersion == null && ParameterWasBound(nameof(this.ScalingPlanVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingPlanVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNamespace = this.ServiceNamespace;
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.ForecastDataType != null)
            {
                request.ForecastDataType = cmdletContext.ForecastDataType;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ScalingPlanName != null)
            {
                request.ScalingPlanName = cmdletContext.ScalingPlanName;
            }
            if (cmdletContext.ScalingPlanVersion != null)
            {
                request.ScalingPlanVersion = cmdletContext.ScalingPlanVersion.Value;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse CallAWSServiceOperation(IAmazonAutoScalingPlans client, Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling Plans", "GetScalingPlanResourceForecastData");
            try
            {
                #if DESKTOP
                return client.GetScalingPlanResourceForecastData(request);
                #elif CORECLR
                return client.GetScalingPlanResourceForecastDataAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public Amazon.AutoScalingPlans.ForecastDataType ForecastDataType { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.AutoScalingPlans.ScalableDimension ScalableDimension { get; set; }
            public System.String ScalingPlanName { get; set; }
            public System.Int64? ScalingPlanVersion { get; set; }
            public Amazon.AutoScalingPlans.ServiceNamespace ServiceNamespace { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse, GetASPScalingPlanResourceForecastDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Datapoints;
        }
        
    }
}
