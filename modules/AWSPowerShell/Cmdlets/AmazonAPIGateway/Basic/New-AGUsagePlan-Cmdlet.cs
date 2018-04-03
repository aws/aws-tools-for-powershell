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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a usage plan with the throttle and quota limits, as well as the associated
    /// API stages, specified in the payload.
    /// </summary>
    [Cmdlet("New", "AGUsagePlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateUsagePlanResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateUsagePlan API operation.", Operation = new[] {"CreateUsagePlan"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateUsagePlanResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateUsagePlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGUsagePlanCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ApiStage
        /// <summary>
        /// <para>
        /// <para>The associated API stages of the usage plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApiStages")]
        public Amazon.APIGateway.Model.ApiStage[] ApiStage { get; set; }
        #endregion
        
        #region Parameter Throttle_BurstLimit
        /// <summary>
        /// <para>
        /// <para>The API request burst limit, the maximum rate limit over a time ranging from one to
        /// a few seconds, depending upon whether the underlying token bucket is at its full capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Throttle_BurstLimit { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the usage plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>[Required] The name of the usage plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Quota_Offset
        /// <summary>
        /// <para>
        /// <para>The number of requests subtracted from the given limit in the initial time period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Quota_Offset { get; set; }
        #endregion
        
        #region Parameter Quota_Period
        /// <summary>
        /// <para>
        /// <para>The time period in which the limit applies. Valid values are "DAY", "WEEK" or "MONTH".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.QuotaPeriodType")]
        public Amazon.APIGateway.QuotaPeriodType Quota_Period { get; set; }
        #endregion
        
        #region Parameter Throttle_RateLimit
        /// <summary>
        /// <para>
        /// <para>The API request steady-state rate limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Throttle_RateLimit { get; set; }
        #endregion
        
        #region Parameter Quota_Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests that can be made in a given time period.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public int Quota_Limit { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGUsagePlan (CreateUsagePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.ApiStage != null)
            {
                context.ApiStages = new List<Amazon.APIGateway.Model.ApiStage>(this.ApiStage);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            if (ParameterWasBound("Quota_Limit"))
                context.Quota_Limit = this.Quota_Limit;
            if (ParameterWasBound("Quota_Offset"))
                context.Quota_Offset = this.Quota_Offset;
            context.Quota_Period = this.Quota_Period;
            if (ParameterWasBound("Throttle_BurstLimit"))
                context.Throttle_BurstLimit = this.Throttle_BurstLimit;
            if (ParameterWasBound("Throttle_RateLimit"))
                context.Throttle_RateLimit = this.Throttle_RateLimit;
            
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
            var request = new Amazon.APIGateway.Model.CreateUsagePlanRequest();
            
            if (cmdletContext.ApiStages != null)
            {
                request.ApiStages = cmdletContext.ApiStages;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Quota
            bool requestQuotaIsNull = true;
            request.Quota = new Amazon.APIGateway.Model.QuotaSettings();
            System.Int32? requestQuota_quota_Limit = null;
            if (cmdletContext.Quota_Limit != null)
            {
                requestQuota_quota_Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Quota_Limit.Value);
            }
            if (requestQuota_quota_Limit != null)
            {
                request.Quota.Limit = requestQuota_quota_Limit.Value;
                requestQuotaIsNull = false;
            }
            System.Int32? requestQuota_quota_Offset = null;
            if (cmdletContext.Quota_Offset != null)
            {
                requestQuota_quota_Offset = cmdletContext.Quota_Offset.Value;
            }
            if (requestQuota_quota_Offset != null)
            {
                request.Quota.Offset = requestQuota_quota_Offset.Value;
                requestQuotaIsNull = false;
            }
            Amazon.APIGateway.QuotaPeriodType requestQuota_quota_Period = null;
            if (cmdletContext.Quota_Period != null)
            {
                requestQuota_quota_Period = cmdletContext.Quota_Period;
            }
            if (requestQuota_quota_Period != null)
            {
                request.Quota.Period = requestQuota_quota_Period;
                requestQuotaIsNull = false;
            }
             // determine if request.Quota should be set to null
            if (requestQuotaIsNull)
            {
                request.Quota = null;
            }
            
             // populate Throttle
            bool requestThrottleIsNull = true;
            request.Throttle = new Amazon.APIGateway.Model.ThrottleSettings();
            System.Int32? requestThrottle_throttle_BurstLimit = null;
            if (cmdletContext.Throttle_BurstLimit != null)
            {
                requestThrottle_throttle_BurstLimit = cmdletContext.Throttle_BurstLimit.Value;
            }
            if (requestThrottle_throttle_BurstLimit != null)
            {
                request.Throttle.BurstLimit = requestThrottle_throttle_BurstLimit.Value;
                requestThrottleIsNull = false;
            }
            System.Double? requestThrottle_throttle_RateLimit = null;
            if (cmdletContext.Throttle_RateLimit != null)
            {
                requestThrottle_throttle_RateLimit = cmdletContext.Throttle_RateLimit.Value;
            }
            if (requestThrottle_throttle_RateLimit != null)
            {
                request.Throttle.RateLimit = requestThrottle_throttle_RateLimit.Value;
                requestThrottleIsNull = false;
            }
             // determine if request.Throttle should be set to null
            if (requestThrottleIsNull)
            {
                request.Throttle = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.APIGateway.Model.CreateUsagePlanResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateUsagePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateUsagePlan");
            try
            {
                #if DESKTOP
                return client.CreateUsagePlan(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateUsagePlanAsync(request);
                return task.Result;
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
            public List<Amazon.APIGateway.Model.ApiStage> ApiStages { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public int? Quota_Limit { get; set; }
            public System.Int32? Quota_Offset { get; set; }
            public Amazon.APIGateway.QuotaPeriodType Quota_Period { get; set; }
            public System.Int32? Throttle_BurstLimit { get; set; }
            public System.Double? Throttle_RateLimit { get; set; }
        }
        
    }
}
