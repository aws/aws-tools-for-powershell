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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates a custom composite model from specified property and hierarchy definitions.
    /// There are two types of custom composite models, <c>inline</c> and <c>component-model-based</c>.
    /// 
    /// 
    ///  
    /// <para>
    /// Use component-model-based custom composite models to define standard, reusable components.
    /// A component-model-based custom composite model consists of a name, a description,
    /// and the ID of the component model it references. A component-model-based custom composite
    /// model has no properties of its own; its referenced component model provides its associated
    /// properties to any created assets. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/custom-composite-models.html">Custom
    /// composite models (Components)</a> in the <i>IoT SiteWise User Guide</i>.
    /// </para><para>
    /// Use inline custom composite models to organize the properties of an asset model. The
    /// properties of inline custom composite models are local to the asset model where they
    /// are included and can't be used to create multiple assets.
    /// </para><para>
    /// To create a component-model-based model, specify the <c>composedAssetModelId</c> of
    /// an existing asset model with <c>assetModelType</c> of <c>COMPONENT_MODEL</c>.
    /// </para><para>
    /// To create an inline model, specify the <c>assetModelCompositeModelProperties</c> and
    /// don't include an <c>composedAssetModelId</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTSWAssetModelCompositeModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateAssetModelCompositeModel API operation.", Operation = new[] {"CreateAssetModelCompositeModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse object containing multiple properties."
    )]
    public partial class NewIOTSWAssetModelCompositeModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssetModelCompositeModelDescription
        /// <summary>
        /// <para>
        /// <para>A description for the composite model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelCompositeModelDescription { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelExternalId
        /// <summary>
        /// <para>
        /// <para>An external ID to assign to the composite model.</para><para>If the composite model is a derived composite model, or one nested inside a component
        /// model, you can only set the external ID using <c>UpdateAssetModelCompositeModel</c>
        /// and specifying the derived ID of the model or property from the created model it's
        /// a part of.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelCompositeModelExternalId { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the composite model. IoT SiteWise automatically generates a unique ID for
        /// you, so this parameter is never required. However, if you prefer to supply your own
        /// ID instead, you can specify it here in UUID format. If you specify your own ID, it
        /// must be globally unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelCompositeModelId { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelName
        /// <summary>
        /// <para>
        /// <para>A unique name for the composite model.</para>
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
        public System.String AssetModelCompositeModelName { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelProperty
        /// <summary>
        /// <para>
        /// <para>The property definitions of the composite model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/custom-composite-models.html#inline-composite-models">
        /// Inline custom composite models</a> in the <i>IoT SiteWise User Guide</i>.</para><para>You can specify up to 200 properties per composite model. For more information, see
        /// <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/quotas.html">Quotas</a>
        /// in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelCompositeModelProperties")]
        public Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition[] AssetModelCompositeModelProperty { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelType
        /// <summary>
        /// <para>
        /// <para>The composite model type. Valid values are <c>AWS/ALARM</c>, <c>CUSTOM</c>, or <c>
        /// AWS/L4E_ANOMALY</c>.</para>
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
        public System.String AssetModelCompositeModelType { get; set; }
        #endregion
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model this composite model is a part of.</para>
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
        public System.String AssetModelId { get; set; }
        #endregion
        
        #region Parameter ComposedAssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of a component model which is reused to create this composite model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComposedAssetModelId { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The expected current entity tag (ETag) for the asset model’s latest or active version
        /// (specified using <c>matchForVersionType</c>). The create request is rejected if the
        /// tag does not match the latest or active version's current entity tag. See <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/opt-locking-for-model.html">Optimistic
        /// locking for asset model writes</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter IfNoneMatch
        /// <summary>
        /// <para>
        /// <para>Accepts <b>*</b> to reject the create request if an active version (specified using
        /// <c>matchForVersionType</c> as <c>ACTIVE</c>) already exists for the asset model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfNoneMatch { get; set; }
        #endregion
        
        #region Parameter MatchForVersionType
        /// <summary>
        /// <para>
        /// <para>Specifies the asset model version type (<c>LATEST</c> or <c>ACTIVE</c>) used in conjunction
        /// with <c>If-Match</c> or <c>If-None-Match</c> headers to determine the target ETag
        /// for the create operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.AssetModelVersionType")]
        public Amazon.IoTSiteWise.AssetModelVersionType MatchForVersionType { get; set; }
        #endregion
        
        #region Parameter ParentAssetModelCompositeModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent composite model in this asset model relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentAssetModelCompositeModelId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWAssetModelCompositeModel (CreateAssetModelCompositeModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse, NewIOTSWAssetModelCompositeModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetModelCompositeModelDescription = this.AssetModelCompositeModelDescription;
            context.AssetModelCompositeModelExternalId = this.AssetModelCompositeModelExternalId;
            context.AssetModelCompositeModelId = this.AssetModelCompositeModelId;
            context.AssetModelCompositeModelName = this.AssetModelCompositeModelName;
            #if MODULAR
            if (this.AssetModelCompositeModelName == null && ParameterWasBound(nameof(this.AssetModelCompositeModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelCompositeModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssetModelCompositeModelProperty != null)
            {
                context.AssetModelCompositeModelProperty = new List<Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition>(this.AssetModelCompositeModelProperty);
            }
            context.AssetModelCompositeModelType = this.AssetModelCompositeModelType;
            #if MODULAR
            if (this.AssetModelCompositeModelType == null && ParameterWasBound(nameof(this.AssetModelCompositeModelType)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelCompositeModelType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetModelId = this.AssetModelId;
            #if MODULAR
            if (this.AssetModelId == null && ParameterWasBound(nameof(this.AssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ComposedAssetModelId = this.ComposedAssetModelId;
            context.IfMatch = this.IfMatch;
            context.IfNoneMatch = this.IfNoneMatch;
            context.MatchForVersionType = this.MatchForVersionType;
            context.ParentAssetModelCompositeModelId = this.ParentAssetModelCompositeModelId;
            
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
            var request = new Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelRequest();
            
            if (cmdletContext.AssetModelCompositeModelDescription != null)
            {
                request.AssetModelCompositeModelDescription = cmdletContext.AssetModelCompositeModelDescription;
            }
            if (cmdletContext.AssetModelCompositeModelExternalId != null)
            {
                request.AssetModelCompositeModelExternalId = cmdletContext.AssetModelCompositeModelExternalId;
            }
            if (cmdletContext.AssetModelCompositeModelId != null)
            {
                request.AssetModelCompositeModelId = cmdletContext.AssetModelCompositeModelId;
            }
            if (cmdletContext.AssetModelCompositeModelName != null)
            {
                request.AssetModelCompositeModelName = cmdletContext.AssetModelCompositeModelName;
            }
            if (cmdletContext.AssetModelCompositeModelProperty != null)
            {
                request.AssetModelCompositeModelProperties = cmdletContext.AssetModelCompositeModelProperty;
            }
            if (cmdletContext.AssetModelCompositeModelType != null)
            {
                request.AssetModelCompositeModelType = cmdletContext.AssetModelCompositeModelType;
            }
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ComposedAssetModelId != null)
            {
                request.ComposedAssetModelId = cmdletContext.ComposedAssetModelId;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            if (cmdletContext.IfNoneMatch != null)
            {
                request.IfNoneMatch = cmdletContext.IfNoneMatch;
            }
            if (cmdletContext.MatchForVersionType != null)
            {
                request.MatchForVersionType = cmdletContext.MatchForVersionType;
            }
            if (cmdletContext.ParentAssetModelCompositeModelId != null)
            {
                request.ParentAssetModelCompositeModelId = cmdletContext.ParentAssetModelCompositeModelId;
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
        
        private Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateAssetModelCompositeModel");
            try
            {
                return client.CreateAssetModelCompositeModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssetModelCompositeModelDescription { get; set; }
            public System.String AssetModelCompositeModelExternalId { get; set; }
            public System.String AssetModelCompositeModelId { get; set; }
            public System.String AssetModelCompositeModelName { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition> AssetModelCompositeModelProperty { get; set; }
            public System.String AssetModelCompositeModelType { get; set; }
            public System.String AssetModelId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ComposedAssetModelId { get; set; }
            public System.String IfMatch { get; set; }
            public System.String IfNoneMatch { get; set; }
            public Amazon.IoTSiteWise.AssetModelVersionType MatchForVersionType { get; set; }
            public System.String ParentAssetModelCompositeModelId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateAssetModelCompositeModelResponse, NewIOTSWAssetModelCompositeModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
