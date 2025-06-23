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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a usage plan with the throttle and quota limits, as well as the associated
    /// API stages, specified in the payload.
    /// </summary>
    [Cmdlet("New", "AGUsagePlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateUsagePlanResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateUsagePlan API operation.", Operation = new[] {"CreateUsagePlan"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateUsagePlanResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateUsagePlanResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateUsagePlanResponse object containing multiple properties."
    )]
    public partial class NewAGUsagePlanCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiStage
        /// <summary>
        /// <para>
        /// <para>The associated API stages of the usage plan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiStages")]
        public Amazon.APIGateway.Model.ApiStage[] ApiStage { get; set; }
        #endregion
        
        #region Parameter Throttle_BurstLimit
        /// <summary>
        /// <para>
        /// <para>The API target request burst rate limit. This allows more requests through for a period
        /// of time than the target rate limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Throttle_BurstLimit { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the usage plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Quota_Limit
        /// <summary>
        /// <para>
        /// <para>The target maximum number of requests that can be made in a given time period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Quota_Limit { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the usage plan.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Quota_Offset
        /// <summary>
        /// <para>
        /// <para>The number of requests subtracted from the given limit in the initial time period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Quota_Offset { get; set; }
        #endregion
        
        #region Parameter Quota_Period
        /// <summary>
        /// <para>
        /// <para>The time period in which the limit applies. Valid values are "DAY", "WEEK" or "MONTH".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIGateway.QuotaPeriodType")]
        public Amazon.APIGateway.QuotaPeriodType Quota_Period { get; set; }
        #endregion
        
        #region Parameter Throttle_RateLimit
        /// <summary>
        /// <para>
        /// <para>The API target request rate limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Throttle_RateLimit { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value map of strings. The valid character set is [a-zA-Z+-=._:/]. The tag
        /// key can be up to 128 characters and must not start with <c>aws:</c>. The tag value
        /// can be up to 256 characters.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateUsagePlanResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateUsagePlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGUsagePlan (CreateUsagePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateUsagePlanResponse, NewAGUsagePlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ApiStage != null)
            {
                context.ApiStage = new List<Amazon.APIGateway.Model.ApiStage>(this.ApiStage);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Quota_Limit = this.Quota_Limit;
            context.Quota_Offset = this.Quota_Offset;
            context.Quota_Period = this.Quota_Period;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Throttle_BurstLimit = this.Throttle_BurstLimit;
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
            
            if (cmdletContext.ApiStage != null)
            {
                request.ApiStages = cmdletContext.ApiStage;
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
            var requestQuotaIsNull = true;
            request.Quota = new Amazon.APIGateway.Model.QuotaSettings();
            System.Int32? requestQuota_quota_Limit = null;
            if (cmdletContext.Quota_Limit != null)
            {
                requestQuota_quota_Limit = cmdletContext.Quota_Limit.Value;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Throttle
            var requestThrottleIsNull = true;
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
        
        private Amazon.APIGateway.Model.CreateUsagePlanResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateUsagePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateUsagePlan");
            try
            {
                return client.CreateUsagePlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.APIGateway.Model.ApiStage> ApiStage { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Quota_Limit { get; set; }
            public System.Int32? Quota_Offset { get; set; }
            public Amazon.APIGateway.QuotaPeriodType Quota_Period { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Throttle_BurstLimit { get; set; }
            public System.Double? Throttle_RateLimit { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateUsagePlanResponse, NewAGUsagePlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
