/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS Auto Scaling Plans GetScalingPlanResourceForecastData API operation.", Operation = new[] {"GetScalingPlanResourceForecastData"})]
    [AWSCmdletOutput("Amazon.AutoScalingPlans.Model.Datapoint",
        "This cmdlet returns a collection of Datapoint objects.",
        "The service call response (type Amazon.AutoScalingPlans.Model.GetScalingPlanResourceForecastDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetASPScalingPlanResourceForecastDataCmdlet : AmazonAutoScalingPlansClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The exclusive end time of the time range for the forecast data to get. The maximum
        /// time duration between the start and end time is seven days. </para><para>Although this parameter can accept a date and time that is more than two days in the
        /// future, the availability of forecast data has limits. AWS Auto Scaling only issues
        /// forecasts for periods of two days in advance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter ForecastDataType
        /// <summary>
        /// <para>
        /// <para>The type of forecast data to get.</para><ul><li><para><code>LoadForecast</code>: The load metric forecast. </para></li><li><para><code>CapacityForecast</code>: The capacity forecast. </para></li><li><para><code>ScheduledActionMinCapacity</code>: The minimum capacity for each scheduled
        /// scaling action. This data is calculated as the larger of two values: the capacity
        /// forecast or the minimum capacity in the scaling instruction.</para></li><li><para><code>ScheduledActionMaxCapacity</code>: The maximum capacity for each scheduled
        /// scaling action. The calculation used is determined by the predictive scaling maximum
        /// capacity behavior setting in the scaling instruction.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AutoScalingPlans.ForecastDataType")]
        public Amazon.AutoScalingPlans.ForecastDataType ForecastDataType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource. This string consists of the resource type and unique identifier.
        /// </para><ul><li><para>Auto Scaling group - The resource type is <code>autoScalingGroup</code> and the unique
        /// identifier is the name of the Auto Scaling group. Example: <code>autoScalingGroup/my-asg</code>.</para></li><li><para>ECS service - The resource type is <code>service</code> and the unique identifier
        /// is the cluster name and service name. Example: <code>service/default/sample-webapp</code>.</para></li><li><para>Spot Fleet request - The resource type is <code>spot-fleet-request</code> and the
        /// unique identifier is the Spot Fleet request ID. Example: <code>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</code>.</para></li><li><para>DynamoDB table - The resource type is <code>table</code> and the unique identifier
        /// is the resource ID. Example: <code>table/my-table</code>.</para></li><li><para>DynamoDB global secondary index - The resource type is <code>index</code> and the
        /// unique identifier is the resource ID. Example: <code>table/my-table/index/my-table-index</code>.</para></li><li><para>Aurora DB cluster - The resource type is <code>cluster</code> and the unique identifier
        /// is the cluster name. Example: <code>cluster:my-db-cluster</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension for the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AutoScalingPlans.ScalableDimension")]
        public Amazon.AutoScalingPlans.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter ScalingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ScalingPlanName { get; set; }
        #endregion
        
        #region Parameter ScalingPlanVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the scaling plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ScalingPlanVersion { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the AWS service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.ForecastDataType = this.ForecastDataType;
            context.ResourceId = this.ResourceId;
            context.ScalableDimension = this.ScalableDimension;
            context.ScalingPlanName = this.ScalingPlanName;
            if (ParameterWasBound("ScalingPlanVersion"))
                context.ScalingPlanVersion = this.ScalingPlanVersion;
            context.ServiceNamespace = this.ServiceNamespace;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Datapoints;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        }
        
    }
}
