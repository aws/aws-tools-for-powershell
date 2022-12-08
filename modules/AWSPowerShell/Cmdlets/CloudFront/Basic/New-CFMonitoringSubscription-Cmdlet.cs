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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Enables additional CloudWatch metrics for the specified CloudFront distribution. The
    /// additional metrics incur an additional cost.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/viewing-cloudfront-metrics.html#monitoring-console.distributions-additional">Viewing
    /// additional CloudFront distribution metrics</a> in the <i>Amazon CloudFront Developer
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFMonitoringSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.MonitoringSubscription")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateMonitoringSubscription API operation.", Operation = new[] {"CreateMonitoringSubscription"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.MonitoringSubscription or Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.MonitoringSubscription object.",
        "The service call response (type Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFMonitoringSubscriptionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter DistributionId
        /// <summary>
        /// <para>
        /// <para>The ID of the distribution that you are enabling metrics for.</para>
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
        public System.String DistributionId { get; set; }
        #endregion
        
        #region Parameter RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus
        /// <summary>
        /// <para>
        /// <para>A flag that indicates whether additional CloudWatch metrics are enabled for a given
        /// CloudFront distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringSubscription_RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus")]
        [AWSConstantClassSource("Amazon.CloudFront.RealtimeMetricsSubscriptionStatus")]
        public Amazon.CloudFront.RealtimeMetricsSubscriptionStatus RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MonitoringSubscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MonitoringSubscription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DistributionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DistributionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DistributionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFMonitoringSubscription (CreateMonitoringSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse, NewCFMonitoringSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DistributionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DistributionId = this.DistributionId;
            #if MODULAR
            if (this.DistributionId == null && ParameterWasBound(nameof(this.DistributionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus = this.RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus;
            
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
            var request = new Amazon.CloudFront.Model.CreateMonitoringSubscriptionRequest();
            
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            
             // populate MonitoringSubscription
            var requestMonitoringSubscriptionIsNull = true;
            request.MonitoringSubscription = new Amazon.CloudFront.Model.MonitoringSubscription();
            Amazon.CloudFront.Model.RealtimeMetricsSubscriptionConfig requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig = null;
            
             // populate RealtimeMetricsSubscriptionConfig
            var requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfigIsNull = true;
            requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig = new Amazon.CloudFront.Model.RealtimeMetricsSubscriptionConfig();
            Amazon.CloudFront.RealtimeMetricsSubscriptionStatus requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig_realtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus = null;
            if (cmdletContext.RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus != null)
            {
                requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig_realtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus = cmdletContext.RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus;
            }
            if (requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig_realtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus != null)
            {
                requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig.RealtimeMetricsSubscriptionStatus = requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig_realtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus;
                requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfigIsNull = false;
            }
             // determine if requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig should be set to null
            if (requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfigIsNull)
            {
                requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig = null;
            }
            if (requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig != null)
            {
                request.MonitoringSubscription.RealtimeMetricsSubscriptionConfig = requestMonitoringSubscription_monitoringSubscription_RealtimeMetricsSubscriptionConfig;
                requestMonitoringSubscriptionIsNull = false;
            }
             // determine if request.MonitoringSubscription should be set to null
            if (requestMonitoringSubscriptionIsNull)
            {
                request.MonitoringSubscription = null;
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
        
        private Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateMonitoringSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateMonitoringSubscription");
            try
            {
                #if DESKTOP
                return client.CreateMonitoringSubscription(request);
                #elif CORECLR
                return client.CreateMonitoringSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionId { get; set; }
            public Amazon.CloudFront.RealtimeMetricsSubscriptionStatus RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateMonitoringSubscriptionResponse, NewCFMonitoringSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MonitoringSubscription;
        }
        
    }
}
