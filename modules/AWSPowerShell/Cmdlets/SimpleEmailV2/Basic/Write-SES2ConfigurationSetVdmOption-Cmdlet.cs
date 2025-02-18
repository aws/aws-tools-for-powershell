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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Specify VDM preferences for email that you send using the configuration set.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SES2ConfigurationSetVdmOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutConfigurationSetVdmOptions API operation.", Operation = new[] {"PutConfigurationSetVdmOptions"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2ConfigurationSetVdmOptionCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set.</para>
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
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter DashboardOptions_EngagementMetric
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM engagement metrics collection. Can be one of the
        /// following:</para><ul><li><para><c>ENABLED</c> – Amazon SES enables engagement metrics for the configuration set.</para></li><li><para><c>DISABLED</c> – Amazon SES disables engagement metrics for the configuration set.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmOptions_DashboardOptions_EngagementMetrics")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus DashboardOptions_EngagementMetric { get; set; }
        #endregion
        
        #region Parameter GuardianOptions_OptimizedSharedDelivery
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM optimized shared delivery. Can be one of the following:</para><ul><li><para><c>ENABLED</c> – Amazon SES enables optimized shared delivery for the configuration
        /// set.</para></li><li><para><c>DISABLED</c> – Amazon SES disables optimized shared delivery for the configuration
        /// set.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmOptions_GuardianOptions_OptimizedSharedDelivery")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus GuardianOptions_OptimizedSharedDelivery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2ConfigurationSetVdmOption (PutConfigurationSetVdmOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse, WriteSES2ConfigurationSetVdmOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardOptions_EngagementMetric = this.DashboardOptions_EngagementMetric;
            context.GuardianOptions_OptimizedSharedDelivery = this.GuardianOptions_OptimizedSharedDelivery;
            
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
            var request = new Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate VdmOptions
            var requestVdmOptionsIsNull = true;
            request.VdmOptions = new Amazon.SimpleEmailV2.Model.VdmOptions();
            Amazon.SimpleEmailV2.Model.DashboardOptions requestVdmOptions_vdmOptions_DashboardOptions = null;
            
             // populate DashboardOptions
            var requestVdmOptions_vdmOptions_DashboardOptionsIsNull = true;
            requestVdmOptions_vdmOptions_DashboardOptions = new Amazon.SimpleEmailV2.Model.DashboardOptions();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric = null;
            if (cmdletContext.DashboardOptions_EngagementMetric != null)
            {
                requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric = cmdletContext.DashboardOptions_EngagementMetric;
            }
            if (requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric != null)
            {
                requestVdmOptions_vdmOptions_DashboardOptions.EngagementMetrics = requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric;
                requestVdmOptions_vdmOptions_DashboardOptionsIsNull = false;
            }
             // determine if requestVdmOptions_vdmOptions_DashboardOptions should be set to null
            if (requestVdmOptions_vdmOptions_DashboardOptionsIsNull)
            {
                requestVdmOptions_vdmOptions_DashboardOptions = null;
            }
            if (requestVdmOptions_vdmOptions_DashboardOptions != null)
            {
                request.VdmOptions.DashboardOptions = requestVdmOptions_vdmOptions_DashboardOptions;
                requestVdmOptionsIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.GuardianOptions requestVdmOptions_vdmOptions_GuardianOptions = null;
            
             // populate GuardianOptions
            var requestVdmOptions_vdmOptions_GuardianOptionsIsNull = true;
            requestVdmOptions_vdmOptions_GuardianOptions = new Amazon.SimpleEmailV2.Model.GuardianOptions();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery = null;
            if (cmdletContext.GuardianOptions_OptimizedSharedDelivery != null)
            {
                requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery = cmdletContext.GuardianOptions_OptimizedSharedDelivery;
            }
            if (requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery != null)
            {
                requestVdmOptions_vdmOptions_GuardianOptions.OptimizedSharedDelivery = requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery;
                requestVdmOptions_vdmOptions_GuardianOptionsIsNull = false;
            }
             // determine if requestVdmOptions_vdmOptions_GuardianOptions should be set to null
            if (requestVdmOptions_vdmOptions_GuardianOptionsIsNull)
            {
                requestVdmOptions_vdmOptions_GuardianOptions = null;
            }
            if (requestVdmOptions_vdmOptions_GuardianOptions != null)
            {
                request.VdmOptions.GuardianOptions = requestVdmOptions_vdmOptions_GuardianOptions;
                requestVdmOptionsIsNull = false;
            }
             // determine if request.VdmOptions should be set to null
            if (requestVdmOptionsIsNull)
            {
                request.VdmOptions = null;
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
        
        private Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutConfigurationSetVdmOptions");
            try
            {
                return client.PutConfigurationSetVdmOptionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus DashboardOptions_EngagementMetric { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus GuardianOptions_OptimizedSharedDelivery { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutConfigurationSetVdmOptionsResponse, WriteSES2ConfigurationSetVdmOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
