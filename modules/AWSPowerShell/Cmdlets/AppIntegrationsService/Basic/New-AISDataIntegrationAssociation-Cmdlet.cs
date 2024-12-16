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
using Amazon.AppIntegrationsService;
using Amazon.AppIntegrationsService.Model;

namespace Amazon.PowerShell.Cmdlets.AIS
{
    /// <summary>
    /// Creates and persists a DataIntegrationAssociation resource.
    /// </summary>
    [Cmdlet("New", "AISDataIntegrationAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service CreateDataIntegrationAssociation API operation.", Operation = new[] {"CreateDataIntegrationAssociation"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse))]
    [AWSCmdletOutput("Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse",
        "This cmdlet returns an Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse object containing multiple properties."
    )]
    public partial class NewAISDataIntegrationAssociationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientAssociationMetadata
        /// <summary>
        /// <para>
        /// <para>The mapping of metadata to be extracted from the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientAssociationMetadata { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The identifier for the client that is associated with the DataIntegration association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
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
        
        #region Parameter DestinationURI
        /// <summary>
        /// <para>
        /// <para>The URI of the data destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationURI { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter ObjectConfiguration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ObjectConfiguration { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse).
        /// Specifying the name of a property of type Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataIntegrationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AISDataIntegrationAssociation (CreateDataIntegrationAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse, NewAISDataIntegrationAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ClientAssociationMetadata != null)
            {
                context.ClientAssociationMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientAssociationMetadata.Keys)
                {
                    context.ClientAssociationMetadata.Add((String)hashKey, (System.String)(this.ClientAssociationMetadata[hashKey]));
                }
            }
            context.ClientId = this.ClientId;
            context.ClientToken = this.ClientToken;
            context.DataIntegrationIdentifier = this.DataIntegrationIdentifier;
            #if MODULAR
            if (this.DataIntegrationIdentifier == null && ParameterWasBound(nameof(this.DataIntegrationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataIntegrationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationURI = this.DestinationURI;
            context.ExecutionConfiguration_ExecutionMode = this.ExecutionConfiguration_ExecutionMode;
            context.OnDemandConfiguration_EndTime = this.OnDemandConfiguration_EndTime;
            context.OnDemandConfiguration_StartTime = this.OnDemandConfiguration_StartTime;
            context.ScheduleConfiguration_FirstExecutionFrom = this.ScheduleConfiguration_FirstExecutionFrom;
            context.ScheduleConfiguration_Object = this.ScheduleConfiguration_Object;
            context.ScheduleConfiguration_ScheduleExpression = this.ScheduleConfiguration_ScheduleExpression;
            if (this.ObjectConfiguration != null)
            {
                context.ObjectConfiguration = new Dictionary<System.String, Dictionary<System.String, List<System.String>>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ObjectConfiguration.Keys)
                {
                    context.ObjectConfiguration.Add((String)hashKey, (Dictionary<System.String,List<System.String>>)(this.ObjectConfiguration[hashKey]));
                }
            }
            
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
            var request = new Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationRequest();
            
            if (cmdletContext.ClientAssociationMetadata != null)
            {
                request.ClientAssociationMetadata = cmdletContext.ClientAssociationMetadata;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataIntegrationIdentifier != null)
            {
                request.DataIntegrationIdentifier = cmdletContext.DataIntegrationIdentifier;
            }
            if (cmdletContext.DestinationURI != null)
            {
                request.DestinationURI = cmdletContext.DestinationURI;
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
            if (cmdletContext.ObjectConfiguration != null)
            {
                request.ObjectConfiguration = cmdletContext.ObjectConfiguration;
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
        
        private Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "CreateDataIntegrationAssociation");
            try
            {
                #if DESKTOP
                return client.CreateDataIntegrationAssociation(request);
                #elif CORECLR
                return client.CreateDataIntegrationAssociationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> ClientAssociationMetadata { get; set; }
            public System.String ClientId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DataIntegrationIdentifier { get; set; }
            public System.String DestinationURI { get; set; }
            public Amazon.AppIntegrationsService.ExecutionMode ExecutionConfiguration_ExecutionMode { get; set; }
            public System.String OnDemandConfiguration_EndTime { get; set; }
            public System.String OnDemandConfiguration_StartTime { get; set; }
            public System.String ScheduleConfiguration_FirstExecutionFrom { get; set; }
            public System.String ScheduleConfiguration_Object { get; set; }
            public System.String ScheduleConfiguration_ScheduleExpression { get; set; }
            public Dictionary<System.String, Dictionary<System.String, List<System.String>>> ObjectConfiguration { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.CreateDataIntegrationAssociationResponse, NewAISDataIntegrationAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
