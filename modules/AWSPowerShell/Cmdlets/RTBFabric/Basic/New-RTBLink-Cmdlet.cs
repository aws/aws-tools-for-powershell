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
using Amazon.RTBFabric;
using Amazon.RTBFabric.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RTB
{
    /// <summary>
    /// Creates a new link between gateways.
    /// 
    ///  
    /// <para>
    /// Establishes a connection that allows gateways to communicate and exchange bid requests
    /// and responses.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RTBLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RTBFabric.Model.CreateLinkResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric CreateLink API operation.", Operation = new[] {"CreateLink"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.CreateLinkResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.CreateLinkResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.CreateLinkResponse object containing multiple properties."
    )]
    public partial class NewRTBLinkCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attributes_CustomerProvidedId
        /// <summary>
        /// <para>
        /// <para>The customer-provided unique identifier of the link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attributes_CustomerProvidedId { get; set; }
        #endregion
        
        #region Parameter Sampling_ErrorLog
        /// <summary>
        /// <para>
        /// <para>An error log entry.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LogSettings_ApplicationLogs_Sampling_ErrorLog")]
        public System.Double? Sampling_ErrorLog { get; set; }
        #endregion
        
        #region Parameter Sampling_FilterLog
        /// <summary>
        /// <para>
        /// <para>A filter log entry.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LogSettings_ApplicationLogs_Sampling_FilterLog")]
        public System.Double? Sampling_FilterLog { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway.</para>
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter HttpResponderAllowed
        /// <summary>
        /// <para>
        /// <para>Boolean to specify if an HTTP responder is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HttpResponderAllowed { get; set; }
        #endregion
        
        #region Parameter PeerGatewayId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the peer gateway.</para>
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
        public System.String PeerGatewayId { get; set; }
        #endregion
        
        #region Parameter Attributes_ResponderErrorMasking
        /// <summary>
        /// <para>
        /// <para>Describes the masking for HTTP error codes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode[] Attributes_ResponderErrorMasking { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the resource.</para><para />
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.CreateLinkResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.CreateLinkResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.GatewayId),
                nameof(this.PeerGatewayId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RTBLink (CreateLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.CreateLinkResponse, NewRTBLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Attributes_CustomerProvidedId = this.Attributes_CustomerProvidedId;
            if (this.Attributes_ResponderErrorMasking != null)
            {
                context.Attributes_ResponderErrorMasking = new List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode>(this.Attributes_ResponderErrorMasking);
            }
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HttpResponderAllowed = this.HttpResponderAllowed;
            context.Sampling_ErrorLog = this.Sampling_ErrorLog;
            #if MODULAR
            if (this.Sampling_ErrorLog == null && ParameterWasBound(nameof(this.Sampling_ErrorLog)))
            {
                WriteWarning("You are passing $null as a value for parameter Sampling_ErrorLog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sampling_FilterLog = this.Sampling_FilterLog;
            #if MODULAR
            if (this.Sampling_FilterLog == null && ParameterWasBound(nameof(this.Sampling_FilterLog)))
            {
                WriteWarning("You are passing $null as a value for parameter Sampling_FilterLog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerGatewayId = this.PeerGatewayId;
            #if MODULAR
            if (this.PeerGatewayId == null && ParameterWasBound(nameof(this.PeerGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.RTBFabric.Model.CreateLinkRequest();
            
            
             // populate Attributes
            var requestAttributesIsNull = true;
            request.Attributes = new Amazon.RTBFabric.Model.LinkAttributes();
            System.String requestAttributes_attributes_CustomerProvidedId = null;
            if (cmdletContext.Attributes_CustomerProvidedId != null)
            {
                requestAttributes_attributes_CustomerProvidedId = cmdletContext.Attributes_CustomerProvidedId;
            }
            if (requestAttributes_attributes_CustomerProvidedId != null)
            {
                request.Attributes.CustomerProvidedId = requestAttributes_attributes_CustomerProvidedId;
                requestAttributesIsNull = false;
            }
            List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode> requestAttributes_attributes_ResponderErrorMasking = null;
            if (cmdletContext.Attributes_ResponderErrorMasking != null)
            {
                requestAttributes_attributes_ResponderErrorMasking = cmdletContext.Attributes_ResponderErrorMasking;
            }
            if (requestAttributes_attributes_ResponderErrorMasking != null)
            {
                request.Attributes.ResponderErrorMasking = requestAttributes_attributes_ResponderErrorMasking;
                requestAttributesIsNull = false;
            }
             // determine if request.Attributes should be set to null
            if (requestAttributesIsNull)
            {
                request.Attributes = null;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.HttpResponderAllowed != null)
            {
                request.HttpResponderAllowed = cmdletContext.HttpResponderAllowed.Value;
            }
            
             // populate LogSettings
            var requestLogSettingsIsNull = true;
            request.LogSettings = new Amazon.RTBFabric.Model.LinkLogSettings();
            Amazon.RTBFabric.Model.LinkApplicationLogConfiguration requestLogSettings_logSettings_ApplicationLogs = null;
            
             // populate ApplicationLogs
            var requestLogSettings_logSettings_ApplicationLogsIsNull = true;
            requestLogSettings_logSettings_ApplicationLogs = new Amazon.RTBFabric.Model.LinkApplicationLogConfiguration();
            Amazon.RTBFabric.Model.LinkApplicationLogSampling requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = null;
            
             // populate Sampling
            var requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = true;
            requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = new Amazon.RTBFabric.Model.LinkApplicationLogSampling();
            System.Double? requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog = null;
            if (cmdletContext.Sampling_ErrorLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog = cmdletContext.Sampling_ErrorLog.Value;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling.ErrorLog = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog.Value;
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = false;
            }
            System.Double? requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog = null;
            if (cmdletContext.Sampling_FilterLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog = cmdletContext.Sampling_FilterLog.Value;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling.FilterLog = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog.Value;
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = false;
            }
             // determine if requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling should be set to null
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = null;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling != null)
            {
                requestLogSettings_logSettings_ApplicationLogs.Sampling = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling;
                requestLogSettings_logSettings_ApplicationLogsIsNull = false;
            }
             // determine if requestLogSettings_logSettings_ApplicationLogs should be set to null
            if (requestLogSettings_logSettings_ApplicationLogsIsNull)
            {
                requestLogSettings_logSettings_ApplicationLogs = null;
            }
            if (requestLogSettings_logSettings_ApplicationLogs != null)
            {
                request.LogSettings.ApplicationLogs = requestLogSettings_logSettings_ApplicationLogs;
                requestLogSettingsIsNull = false;
            }
             // determine if request.LogSettings should be set to null
            if (requestLogSettingsIsNull)
            {
                request.LogSettings = null;
            }
            if (cmdletContext.PeerGatewayId != null)
            {
                request.PeerGatewayId = cmdletContext.PeerGatewayId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RTBFabric.Model.CreateLinkResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.CreateLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "CreateLink");
            try
            {
                return client.CreateLinkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Attributes_CustomerProvidedId { get; set; }
            public List<Amazon.RTBFabric.Model.ResponderErrorMaskingForHttpCode> Attributes_ResponderErrorMasking { get; set; }
            public System.String GatewayId { get; set; }
            public System.Boolean? HttpResponderAllowed { get; set; }
            public System.Double? Sampling_ErrorLog { get; set; }
            public System.Double? Sampling_FilterLog { get; set; }
            public System.String PeerGatewayId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.RTBFabric.Model.CreateLinkResponse, NewRTBLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
