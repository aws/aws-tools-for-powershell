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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// <important><para>
    ///  End of support notice: On May 20, 2026, Amazon Web Services will end support for
    /// Amazon Web Services DMS Fleet Advisor;. After May 20, 2026, you will no longer be
    /// able to access the Amazon Web Services DMS Fleet Advisor; console or Amazon Web Services
    /// DMS Fleet Advisor; resources. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/dms_fleet.advisor-end-of-support.html">Amazon
    /// Web Services DMS Fleet Advisor end of support</a>. 
    /// </para></important><para>
    /// Starts the analysis of your source database to provide recommendations of target engines.
    /// </para><para>
    /// You can create recommendations for multiple source databases using <a href="https://docs.aws.amazon.com/dms/latest/APIReference/API_BatchStartRecommendations.html">BatchStartRecommendations</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DMSRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartRecommendations API operation.", Operation = new[] {"StartRecommendations"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse))]
    [AWSCmdletOutput("None or Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartDMSRecommendationCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatabaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the source database to analyze and provide recommendations for.</para>
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
        public System.String DatabaseId { get; set; }
        #endregion
        
        #region Parameter Settings_InstanceSizingType
        /// <summary>
        /// <para>
        /// <para>The size of your target instance. Fleet Advisor calculates this value based on your
        /// data collection type, such as total capacity and resource utilization. Valid values
        /// include <c>"total-capacity"</c> and <c>"utilization"</c>.</para>
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
        public System.String Settings_InstanceSizingType { get; set; }
        #endregion
        
        #region Parameter Settings_WorkloadType
        /// <summary>
        /// <para>
        /// <para>The deployment option for your target engine. For production databases, Fleet Advisor
        /// chooses Multi-AZ deployment. For development or test databases, Fleet Advisor chooses
        /// Single-AZ deployment. Valid values include <c>"development"</c> and <c>"production"</c>.</para>
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
        public System.String Settings_WorkloadType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSRecommendation (StartRecommendations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse, StartDMSRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseId = this.DatabaseId;
            #if MODULAR
            if (this.DatabaseId == null && ParameterWasBound(nameof(this.DatabaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_InstanceSizingType = this.Settings_InstanceSizingType;
            #if MODULAR
            if (this.Settings_InstanceSizingType == null && ParameterWasBound(nameof(this.Settings_InstanceSizingType)))
            {
                WriteWarning("You are passing $null as a value for parameter Settings_InstanceSizingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_WorkloadType = this.Settings_WorkloadType;
            #if MODULAR
            if (this.Settings_WorkloadType == null && ParameterWasBound(nameof(this.Settings_WorkloadType)))
            {
                WriteWarning("You are passing $null as a value for parameter Settings_WorkloadType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.StartRecommendationsRequest();
            
            if (cmdletContext.DatabaseId != null)
            {
                request.DatabaseId = cmdletContext.DatabaseId;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.DatabaseMigrationService.Model.RecommendationSettings();
            System.String requestSettings_settings_InstanceSizingType = null;
            if (cmdletContext.Settings_InstanceSizingType != null)
            {
                requestSettings_settings_InstanceSizingType = cmdletContext.Settings_InstanceSizingType;
            }
            if (requestSettings_settings_InstanceSizingType != null)
            {
                request.Settings.InstanceSizingType = requestSettings_settings_InstanceSizingType;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_WorkloadType = null;
            if (cmdletContext.Settings_WorkloadType != null)
            {
                requestSettings_settings_WorkloadType = cmdletContext.Settings_WorkloadType;
            }
            if (requestSettings_settings_WorkloadType != null)
            {
                request.Settings.WorkloadType = requestSettings_settings_WorkloadType;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartRecommendations");
            try
            {
                return client.StartRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatabaseId { get; set; }
            public System.String Settings_InstanceSizingType { get; set; }
            public System.String Settings_WorkloadType { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartRecommendationsResponse, StartDMSRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
