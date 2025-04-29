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
using Amazon.AppIntegrationsService;
using Amazon.AppIntegrationsService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AIS
{
    /// <summary>
    /// Updates and persists a DataIntegrationAssociation resource.
    /// 
    ///  <note><para>
    ///  Updating a DataIntegrationAssociation with ExecutionConfiguration will rerun the
    /// on-demand job. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "AISDataIntegrationAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service UpdateDataIntegrationAssociation API operation.", Operation = new[] {"UpdateDataIntegrationAssociation"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse))]
    [AWSCmdletOutput("None or Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateAISDataIntegrationAssociationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataIntegrationAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier. of the DataIntegrationAssociation resource</para>
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
        public System.String DataIntegrationAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter DataIntegrationIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the DataIntegration.</para>
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
        public System.String DataIntegrationIdentifier { get; set; }
        #endregion
        
        #region Parameter OnDemandConfiguration_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for data pull from the source as an Unix/epoch string in milliseconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_OnDemandConfiguration_EndTime")]
        public System.String OnDemandConfiguration_EndTime { get; set; }
        #endregion
        
        #region Parameter ExecutionConfiguration_ExecutionMode
        /// <summary>
        /// <para>
        /// <para>The mode for data import/export execution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppIntegrationsService.ExecutionMode")]
        public Amazon.AppIntegrationsService.ExecutionMode ExecutionConfiguration_ExecutionMode { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_FirstExecutionFrom
        /// <summary>
        /// <para>
        /// <para>The start date for objects to import in the first flow run as an Unix/epoch timestamp
        /// in milliseconds or in ISO-8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_ScheduleConfiguration_FirstExecutionFrom")]
        public System.String ScheduleConfiguration_FirstExecutionFrom { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_Object
        /// <summary>
        /// <para>
        /// <para>The name of the object to pull from the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_ScheduleConfiguration_Object")]
        public System.String ScheduleConfiguration_Object { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>How often the data should be pulled from data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_ScheduleConfiguration_ScheduleExpression")]
        public System.String ScheduleConfiguration_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter OnDemandConfiguration_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for data pull from the source as an Unix/epoch string in milliseconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_OnDemandConfiguration_StartTime")]
        public System.String OnDemandConfiguration_StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataIntegrationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AISDataIntegrationAssociation (UpdateDataIntegrationAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse, UpdateAISDataIntegrationAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataIntegrationAssociationIdentifier = this.DataIntegrationAssociationIdentifier;
            #if MODULAR
            if (this.DataIntegrationAssociationIdentifier == null && ParameterWasBound(nameof(this.DataIntegrationAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataIntegrationAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataIntegrationIdentifier = this.DataIntegrationIdentifier;
            #if MODULAR
            if (this.DataIntegrationIdentifier == null && ParameterWasBound(nameof(this.DataIntegrationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataIntegrationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionConfiguration_ExecutionMode = this.ExecutionConfiguration_ExecutionMode;
            #if MODULAR
            if (this.ExecutionConfiguration_ExecutionMode == null && ParameterWasBound(nameof(this.ExecutionConfiguration_ExecutionMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionConfiguration_ExecutionMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnDemandConfiguration_EndTime = this.OnDemandConfiguration_EndTime;
            context.OnDemandConfiguration_StartTime = this.OnDemandConfiguration_StartTime;
            context.ScheduleConfiguration_FirstExecutionFrom = this.ScheduleConfiguration_FirstExecutionFrom;
            context.ScheduleConfiguration_Object = this.ScheduleConfiguration_Object;
            context.ScheduleConfiguration_ScheduleExpression = this.ScheduleConfiguration_ScheduleExpression;
            
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
            var request = new Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationRequest();
            
            if (cmdletContext.DataIntegrationAssociationIdentifier != null)
            {
                request.DataIntegrationAssociationIdentifier = cmdletContext.DataIntegrationAssociationIdentifier;
            }
            if (cmdletContext.DataIntegrationIdentifier != null)
            {
                request.DataIntegrationIdentifier = cmdletContext.DataIntegrationIdentifier;
            }
            
             // populate ExecutionConfiguration
            var requestExecutionConfigurationIsNull = true;
            request.ExecutionConfiguration = new Amazon.AppIntegrationsService.Model.ExecutionConfiguration();
            Amazon.AppIntegrationsService.ExecutionMode requestExecutionConfiguration_executionConfiguration_ExecutionMode = null;
            if (cmdletContext.ExecutionConfiguration_ExecutionMode != null)
            {
                requestExecutionConfiguration_executionConfiguration_ExecutionMode = cmdletContext.ExecutionConfiguration_ExecutionMode;
            }
            if (requestExecutionConfiguration_executionConfiguration_ExecutionMode != null)
            {
                request.ExecutionConfiguration.ExecutionMode = requestExecutionConfiguration_executionConfiguration_ExecutionMode;
                requestExecutionConfigurationIsNull = false;
            }
            Amazon.AppIntegrationsService.Model.OnDemandConfiguration requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration = null;
            
             // populate OnDemandConfiguration
            var requestExecutionConfiguration_executionConfiguration_OnDemandConfigurationIsNull = true;
            requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration = new Amazon.AppIntegrationsService.Model.OnDemandConfiguration();
            System.String requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_EndTime = null;
            if (cmdletContext.OnDemandConfiguration_EndTime != null)
            {
                requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_EndTime = cmdletContext.OnDemandConfiguration_EndTime;
            }
            if (requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_EndTime != null)
            {
                requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration.EndTime = requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_EndTime;
                requestExecutionConfiguration_executionConfiguration_OnDemandConfigurationIsNull = false;
            }
            System.String requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_StartTime = null;
            if (cmdletContext.OnDemandConfiguration_StartTime != null)
            {
                requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_StartTime = cmdletContext.OnDemandConfiguration_StartTime;
            }
            if (requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_StartTime != null)
            {
                requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration.StartTime = requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration_onDemandConfiguration_StartTime;
                requestExecutionConfiguration_executionConfiguration_OnDemandConfigurationIsNull = false;
            }
             // determine if requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration should be set to null
            if (requestExecutionConfiguration_executionConfiguration_OnDemandConfigurationIsNull)
            {
                requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration = null;
            }
            if (requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration != null)
            {
                request.ExecutionConfiguration.OnDemandConfiguration = requestExecutionConfiguration_executionConfiguration_OnDemandConfiguration;
                requestExecutionConfigurationIsNull = false;
            }
            Amazon.AppIntegrationsService.Model.ScheduleConfiguration requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration = null;
            
             // populate ScheduleConfiguration
            var requestExecutionConfiguration_executionConfiguration_ScheduleConfigurationIsNull = true;
            requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration = new Amazon.AppIntegrationsService.Model.ScheduleConfiguration();
            System.String requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_FirstExecutionFrom = null;
            if (cmdletContext.ScheduleConfiguration_FirstExecutionFrom != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_FirstExecutionFrom = cmdletContext.ScheduleConfiguration_FirstExecutionFrom;
            }
            if (requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_FirstExecutionFrom != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration.FirstExecutionFrom = requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_FirstExecutionFrom;
                requestExecutionConfiguration_executionConfiguration_ScheduleConfigurationIsNull = false;
            }
            System.String requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_Object = null;
            if (cmdletContext.ScheduleConfiguration_Object != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_Object = cmdletContext.ScheduleConfiguration_Object;
            }
            if (requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_Object != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration.Object = requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_Object;
                requestExecutionConfiguration_executionConfiguration_ScheduleConfigurationIsNull = false;
            }
            System.String requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_ScheduleExpression = null;
            if (cmdletContext.ScheduleConfiguration_ScheduleExpression != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_ScheduleExpression = cmdletContext.ScheduleConfiguration_ScheduleExpression;
            }
            if (requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_ScheduleExpression != null)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration.ScheduleExpression = requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration_scheduleConfiguration_ScheduleExpression;
                requestExecutionConfiguration_executionConfiguration_ScheduleConfigurationIsNull = false;
            }
             // determine if requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration should be set to null
            if (requestExecutionConfiguration_executionConfiguration_ScheduleConfigurationIsNull)
            {
                requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration = null;
            }
            if (requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration != null)
            {
                request.ExecutionConfiguration.ScheduleConfiguration = requestExecutionConfiguration_executionConfiguration_ScheduleConfiguration;
                requestExecutionConfigurationIsNull = false;
            }
             // determine if request.ExecutionConfiguration should be set to null
            if (requestExecutionConfigurationIsNull)
            {
                request.ExecutionConfiguration = null;
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
        
        private Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "UpdateDataIntegrationAssociation");
            try
            {
                return client.UpdateDataIntegrationAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataIntegrationAssociationIdentifier { get; set; }
            public System.String DataIntegrationIdentifier { get; set; }
            public Amazon.AppIntegrationsService.ExecutionMode ExecutionConfiguration_ExecutionMode { get; set; }
            public System.String OnDemandConfiguration_EndTime { get; set; }
            public System.String OnDemandConfiguration_StartTime { get; set; }
            public System.String ScheduleConfiguration_FirstExecutionFrom { get; set; }
            public System.String ScheduleConfiguration_Object { get; set; }
            public System.String ScheduleConfiguration_ScheduleExpression { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.UpdateDataIntegrationAssociationResponse, UpdateAISDataIntegrationAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
