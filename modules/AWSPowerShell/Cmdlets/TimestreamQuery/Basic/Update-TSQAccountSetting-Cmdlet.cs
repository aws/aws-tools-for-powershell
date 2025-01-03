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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// Transitions your account to use TCUs for query pricing and modifies the maximum query
    /// compute units that you've configured. If you reduce the value of <c>MaxQueryTCU</c>
    /// to a desired configuration, the new value can take up to 24 hours to be effective.
    /// 
    ///  <note><para>
    /// After you've transitioned your account to use TCUs for query pricing, you can't transition
    /// to using bytes scanned for query pricing.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "TSQAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Timestream Query UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse object containing multiple properties."
    )]
    public partial class UpdateTSQAccountSettingCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueryCompute_ComputeMode
        /// <summary>
        /// <para>
        /// <para>The mode in which Timestream Compute Units (TCUs) are allocated and utilized within
        /// an account. Note that in the Asia Pacific (Mumbai) region, the API operation only
        /// recognizes the value <c>PROVISIONED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamQuery.ComputeMode")]
        public Amazon.TimestreamQuery.ComputeMode QueryCompute_ComputeMode { get; set; }
        #endregion
        
        #region Parameter MaxQueryTCU
        /// <summary>
        /// <para>
        /// <para>The maximum number of compute units the service will use at any point in time to serve
        /// your queries. To run queries, you must set a minimum capacity of 4 TCU. You can set
        /// the maximum number of TCU in multiples of 4, for example, 4, 8, 16, 32, and so on.
        /// The maximum value supported for <c>MaxQueryTCU</c> is 1000. To request an increase
        /// to this soft limit, contact Amazon Web Services Support. For information about the
        /// default quota for maxQueryTCU, see Default quotas. This configuration is applicable
        /// only for on-demand usage of Timestream Compute Units (TCUs).</para><para>The maximum value supported for <c>MaxQueryTCU</c> is 1000. To request an increase
        /// to this soft limit, contact Amazon Web Services Support. For information about the
        /// default quota for <c>maxQueryTCU</c>, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html#limits.default">Default
        /// quotas</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Int32? MaxQueryTCU { get; set; }
        #endregion
        
        #region Parameter QueryPricingModel
        /// <summary>
        /// <para>
        /// <para>The pricing model for queries in an account.</para><note><para>The <c>QueryPricingModel</c> parameter is used by several Timestream operations; however,
        /// the <c>UpdateAccountSettings</c> API operation doesn't recognize any values other
        /// than <c>COMPUTE_UNITS</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamQuery.QueryPricingModel")]
        public Amazon.TimestreamQuery.QueryPricingModel QueryPricingModel { get; set; }
        #endregion
        
        #region Parameter NotificationConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that grants Timestream permission to publish notifications.
        /// This field is only visible if SNS Topic is provided when updating the account settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryCompute_ProvisionedCapacity_NotificationConfiguration_RoleArn")]
        public System.String NotificationConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter ProvisionedCapacity_TargetQueryTCU
        /// <summary>
        /// <para>
        /// <para>The target compute capacity for querying data, specified in Timestream Compute Units
        /// (TCUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryCompute_ProvisionedCapacity_TargetQueryTCU")]
        public System.Int32? ProvisionedCapacity_TargetQueryTCU { get; set; }
        #endregion
        
        #region Parameter SnsConfiguration_TopicArn
        /// <summary>
        /// <para>
        /// <para>SNS topic ARN that the scheduled query status notifications will be sent to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration_TopicArn")]
        public System.String SnsConfiguration_TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MaxQueryTCU), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TSQAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse, UpdateTSQAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxQueryTCU = this.MaxQueryTCU;
            context.QueryCompute_ComputeMode = this.QueryCompute_ComputeMode;
            context.NotificationConfiguration_RoleArn = this.NotificationConfiguration_RoleArn;
            context.SnsConfiguration_TopicArn = this.SnsConfiguration_TopicArn;
            context.ProvisionedCapacity_TargetQueryTCU = this.ProvisionedCapacity_TargetQueryTCU;
            context.QueryPricingModel = this.QueryPricingModel;
            
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
            var request = new Amazon.TimestreamQuery.Model.UpdateAccountSettingsRequest();
            
            if (cmdletContext.MaxQueryTCU != null)
            {
                request.MaxQueryTCU = cmdletContext.MaxQueryTCU.Value;
            }
            
             // populate QueryCompute
            var requestQueryComputeIsNull = true;
            request.QueryCompute = new Amazon.TimestreamQuery.Model.QueryComputeRequest();
            Amazon.TimestreamQuery.ComputeMode requestQueryCompute_queryCompute_ComputeMode = null;
            if (cmdletContext.QueryCompute_ComputeMode != null)
            {
                requestQueryCompute_queryCompute_ComputeMode = cmdletContext.QueryCompute_ComputeMode;
            }
            if (requestQueryCompute_queryCompute_ComputeMode != null)
            {
                request.QueryCompute.ComputeMode = requestQueryCompute_queryCompute_ComputeMode;
                requestQueryComputeIsNull = false;
            }
            Amazon.TimestreamQuery.Model.ProvisionedCapacityRequest requestQueryCompute_queryCompute_ProvisionedCapacity = null;
            
             // populate ProvisionedCapacity
            var requestQueryCompute_queryCompute_ProvisionedCapacityIsNull = true;
            requestQueryCompute_queryCompute_ProvisionedCapacity = new Amazon.TimestreamQuery.Model.ProvisionedCapacityRequest();
            System.Int32? requestQueryCompute_queryCompute_ProvisionedCapacity_provisionedCapacity_TargetQueryTCU = null;
            if (cmdletContext.ProvisionedCapacity_TargetQueryTCU != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_provisionedCapacity_TargetQueryTCU = cmdletContext.ProvisionedCapacity_TargetQueryTCU.Value;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_provisionedCapacity_TargetQueryTCU != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity.TargetQueryTCU = requestQueryCompute_queryCompute_ProvisionedCapacity_provisionedCapacity_TargetQueryTCU.Value;
                requestQueryCompute_queryCompute_ProvisionedCapacityIsNull = false;
            }
            Amazon.TimestreamQuery.Model.AccountSettingsNotificationConfiguration requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration = null;
            
             // populate NotificationConfiguration
            var requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfigurationIsNull = true;
            requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration = new Amazon.TimestreamQuery.Model.AccountSettingsNotificationConfiguration();
            System.String requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_notificationConfiguration_RoleArn = null;
            if (cmdletContext.NotificationConfiguration_RoleArn != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_notificationConfiguration_RoleArn = cmdletContext.NotificationConfiguration_RoleArn;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_notificationConfiguration_RoleArn != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration.RoleArn = requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_notificationConfiguration_RoleArn;
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfigurationIsNull = false;
            }
            Amazon.TimestreamQuery.Model.SnsConfiguration requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration = null;
            
             // populate SnsConfiguration
            var requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfigurationIsNull = true;
            requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration = new Amazon.TimestreamQuery.Model.SnsConfiguration();
            System.String requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn = null;
            if (cmdletContext.SnsConfiguration_TopicArn != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn = cmdletContext.SnsConfiguration_TopicArn;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration.TopicArn = requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn;
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfigurationIsNull = false;
            }
             // determine if requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration should be set to null
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfigurationIsNull)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration = null;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration.SnsConfiguration = requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration_queryCompute_ProvisionedCapacity_NotificationConfiguration_SnsConfiguration;
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfigurationIsNull = false;
            }
             // determine if requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration should be set to null
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfigurationIsNull)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration = null;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration != null)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity.NotificationConfiguration = requestQueryCompute_queryCompute_ProvisionedCapacity_queryCompute_ProvisionedCapacity_NotificationConfiguration;
                requestQueryCompute_queryCompute_ProvisionedCapacityIsNull = false;
            }
             // determine if requestQueryCompute_queryCompute_ProvisionedCapacity should be set to null
            if (requestQueryCompute_queryCompute_ProvisionedCapacityIsNull)
            {
                requestQueryCompute_queryCompute_ProvisionedCapacity = null;
            }
            if (requestQueryCompute_queryCompute_ProvisionedCapacity != null)
            {
                request.QueryCompute.ProvisionedCapacity = requestQueryCompute_queryCompute_ProvisionedCapacity;
                requestQueryComputeIsNull = false;
            }
             // determine if request.QueryCompute should be set to null
            if (requestQueryComputeIsNull)
            {
                request.QueryCompute = null;
            }
            if (cmdletContext.QueryPricingModel != null)
            {
                request.QueryPricingModel = cmdletContext.QueryPricingModel;
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
        
        private Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "UpdateAccountSettings");
            try
            {
                #if DESKTOP
                return client.UpdateAccountSettings(request);
                #elif CORECLR
                return client.UpdateAccountSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxQueryTCU { get; set; }
            public Amazon.TimestreamQuery.ComputeMode QueryCompute_ComputeMode { get; set; }
            public System.String NotificationConfiguration_RoleArn { get; set; }
            public System.String SnsConfiguration_TopicArn { get; set; }
            public System.Int32? ProvisionedCapacity_TargetQueryTCU { get; set; }
            public Amazon.TimestreamQuery.QueryPricingModel QueryPricingModel { get; set; }
            public System.Func<Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse, UpdateTSQAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
