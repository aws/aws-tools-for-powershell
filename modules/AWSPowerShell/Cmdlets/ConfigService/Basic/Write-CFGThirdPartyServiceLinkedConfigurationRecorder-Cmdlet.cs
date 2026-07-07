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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates or updates a service-linked configuration recorder that is linked to a third-party
    /// cloud service provider based on the <c>ConnectorArn</c> you specify.
    /// 
    ///  
    /// <para>
    /// The configuration recorder's <c>name</c>, <c>recordingGroup</c>, <c>recordingMode</c>,
    /// and <c>recordingScope</c> is set by the service that is linked to the configuration
    /// recorder.
    /// </para><para>
    /// If a service-linked configuration recorder already exists for the specified service
    /// principal and connector, calling this operation again updates the <c>ScopeConfiguration</c>.
    /// </para><note><para><b>This operation can only be called by the Amazon Web Services service linked to
    /// the configuration recorder</b></para><para>
    /// Customers cannot call this operation directly. Only the linked Amazon Web Services
    /// service can create or update the service-linked configuration recorder.
    /// </para></note><note><para><b>Tags are added at creation and cannot be updated with this operation</b></para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGThirdPartyServiceLinkedConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse")]
    [AWSCmdlet("Calls the AWS Config PutThirdPartyServiceLinkedConfigurationRecorder API operation.", Operation = new[] {"PutThirdPartyServiceLinkedConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse object containing multiple properties."
    )]
    public partial class WriteCFGThirdPartyServiceLinkedConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScopeConfiguration_AllRegion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to record resources from all supported regions for the third-party
        /// cloud service provider.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ScopeConfiguration_AllRegions")]
        public System.Boolean? ScopeConfiguration_AllRegion { get; set; }
        #endregion
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the connector that specifies the connection between
        /// the third-party cloud service provider and Config. The specified connector must exist.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_IncludedRegion
        /// <summary>
        /// <para>
        /// <para>The list of regions from the third-party cloud service provider to include when recording
        /// resources. Used when <c>allRegions</c> is set to <c>false</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_IncludedRegions")]
        public System.String[] ScopeConfiguration_IncludedRegion { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_ScopeType
        /// <summary>
        /// <para>
        /// <para>The type of scope for the third-party cloud resources. Valid values include <c>tenant</c>
        /// and <c>subscription</c>.</para>
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
        public System.String ScopeConfiguration_ScopeType { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_ScopeValue
        /// <summary>
        /// <para>
        /// <para>The list of specific scope values for the third-party cloud resources. For example,
        /// a list of Azure subscriptions or management groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_ScopeValues")]
        public System.String[] ScopeConfiguration_ScopeValue { get; set; }
        #endregion
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>The service principal of the Amazon Web Services service for the service-linked configuration
        /// recorder that you want to create.</para>
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
        public System.String ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for a service-linked configuration recorder. Each tag consists of a key and
        /// an optional value, both of which you define.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGThirdPartyServiceLinkedConfigurationRecorder (PutThirdPartyServiceLinkedConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse, WriteCFGThirdPartyServiceLinkedConfigurationRecorderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeConfiguration_AllRegion = this.ScopeConfiguration_AllRegion;
            #if MODULAR
            if (this.ScopeConfiguration_AllRegion == null && ParameterWasBound(nameof(this.ScopeConfiguration_AllRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeConfiguration_AllRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScopeConfiguration_IncludedRegion != null)
            {
                context.ScopeConfiguration_IncludedRegion = new List<System.String>(this.ScopeConfiguration_IncludedRegion);
            }
            context.ScopeConfiguration_ScopeType = this.ScopeConfiguration_ScopeType;
            #if MODULAR
            if (this.ScopeConfiguration_ScopeType == null && ParameterWasBound(nameof(this.ScopeConfiguration_ScopeType)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeConfiguration_ScopeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScopeConfiguration_ScopeValue != null)
            {
                context.ScopeConfiguration_ScopeValue = new List<System.String>(this.ScopeConfiguration_ScopeValue);
            }
            context.ServicePrincipal = this.ServicePrincipal;
            #if MODULAR
            if (this.ServicePrincipal == null && ParameterWasBound(nameof(this.ServicePrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter ServicePrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderRequest();
            
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
            }
            
             // populate ScopeConfiguration
            var requestScopeConfigurationIsNull = true;
            request.ScopeConfiguration = new Amazon.ConfigService.Model.ScopeConfiguration();
            System.Boolean? requestScopeConfiguration_scopeConfiguration_AllRegion = null;
            if (cmdletContext.ScopeConfiguration_AllRegion != null)
            {
                requestScopeConfiguration_scopeConfiguration_AllRegion = cmdletContext.ScopeConfiguration_AllRegion.Value;
            }
            if (requestScopeConfiguration_scopeConfiguration_AllRegion != null)
            {
                request.ScopeConfiguration.AllRegions = requestScopeConfiguration_scopeConfiguration_AllRegion.Value;
                requestScopeConfigurationIsNull = false;
            }
            List<System.String> requestScopeConfiguration_scopeConfiguration_IncludedRegion = null;
            if (cmdletContext.ScopeConfiguration_IncludedRegion != null)
            {
                requestScopeConfiguration_scopeConfiguration_IncludedRegion = cmdletContext.ScopeConfiguration_IncludedRegion;
            }
            if (requestScopeConfiguration_scopeConfiguration_IncludedRegion != null)
            {
                request.ScopeConfiguration.IncludedRegions = requestScopeConfiguration_scopeConfiguration_IncludedRegion;
                requestScopeConfigurationIsNull = false;
            }
            System.String requestScopeConfiguration_scopeConfiguration_ScopeType = null;
            if (cmdletContext.ScopeConfiguration_ScopeType != null)
            {
                requestScopeConfiguration_scopeConfiguration_ScopeType = cmdletContext.ScopeConfiguration_ScopeType;
            }
            if (requestScopeConfiguration_scopeConfiguration_ScopeType != null)
            {
                request.ScopeConfiguration.ScopeType = requestScopeConfiguration_scopeConfiguration_ScopeType;
                requestScopeConfigurationIsNull = false;
            }
            List<System.String> requestScopeConfiguration_scopeConfiguration_ScopeValue = null;
            if (cmdletContext.ScopeConfiguration_ScopeValue != null)
            {
                requestScopeConfiguration_scopeConfiguration_ScopeValue = cmdletContext.ScopeConfiguration_ScopeValue;
            }
            if (requestScopeConfiguration_scopeConfiguration_ScopeValue != null)
            {
                request.ScopeConfiguration.ScopeValues = requestScopeConfiguration_scopeConfiguration_ScopeValue;
                requestScopeConfigurationIsNull = false;
            }
             // determine if request.ScopeConfiguration should be set to null
            if (requestScopeConfigurationIsNull)
            {
                request.ScopeConfiguration = null;
            }
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
        
        private Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutThirdPartyServiceLinkedConfigurationRecorder");
            try
            {
                return client.PutThirdPartyServiceLinkedConfigurationRecorderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorArn { get; set; }
            public System.Boolean? ScopeConfiguration_AllRegion { get; set; }
            public List<System.String> ScopeConfiguration_IncludedRegion { get; set; }
            public System.String ScopeConfiguration_ScopeType { get; set; }
            public List<System.String> ScopeConfiguration_ScopeValue { get; set; }
            public System.String ServicePrincipal { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutThirdPartyServiceLinkedConfigurationRecorderResponse, WriteCFGThirdPartyServiceLinkedConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
