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
    /// Creates an asset model from specified property and hierarchy definitions. You create
    /// assets from asset models. With asset models, you can easily create assets of the same
    /// type that have standardized definitions. Each asset created from a model inherits
    /// the asset model's property and hierarchy definitions. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/define-models.html">Defining
    /// asset models</a> in the <i>IoT SiteWise User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can create two types of asset models, <c>ASSET_MODEL</c> or <c>COMPONENT_MODEL</c>.
    /// </para><ul><li><para><b>ASSET_MODEL</b> – (default) An asset model that you can use to create assets.
    /// Can't be included as a component in another asset model.
    /// </para></li><li><para><b>COMPONENT_MODEL</b> – A reusable component that you can include in the composite
    /// models of other asset models. You can't create assets directly from this type of asset
    /// model. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "IOTSWAssetModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateAssetModelResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateAssetModel API operation.", Operation = new[] {"CreateAssetModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateAssetModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateAssetModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateAssetModelResponse object containing multiple properties."
    )]
    public partial class NewIOTSWAssetModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssetModelCompositeModel
        /// <summary>
        /// <para>
        /// <para>The composite models that are part of this asset model. It groups properties (such
        /// as attributes, measurements, transforms, and metrics) and child composite models that
        /// model parts of your industrial equipment. Each composite model has a type that defines
        /// the properties that the composite model supports. Use composite models to define alarms
        /// on this asset model.</para><note><para>When creating custom composite models, you need to use <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_CreateAssetModelCompositeModel.html">CreateAssetModelCompositeModel</a>.
        /// For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/create-custom-composite-models.html">Creating
        /// custom composite models (Components)</a> in the <i>IoT SiteWise User Guide</i>.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelCompositeModels")]
        public Amazon.IoTSiteWise.Model.AssetModelCompositeModelDefinition[] AssetModelCompositeModel { get; set; }
        #endregion
        
        #region Parameter AssetModelDescription
        /// <summary>
        /// <para>
        /// <para>A description for the asset model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelDescription { get; set; }
        #endregion
        
        #region Parameter AssetModelExternalId
        /// <summary>
        /// <para>
        /// <para>An external ID to assign to the asset model. The external ID must be unique within
        /// your Amazon Web Services account. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-ids">Using
        /// external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelExternalId { get; set; }
        #endregion
        
        #region Parameter AssetModelHierarchy
        /// <summary>
        /// <para>
        /// <para>The hierarchy definitions of the asset model. Each hierarchy specifies an asset model
        /// whose assets can be children of any other assets created from this asset model. For
        /// more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/asset-hierarchies.html">Asset
        /// hierarchies</a> in the <i>IoT SiteWise User Guide</i>.</para><para>You can specify up to 10 hierarchies per asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/quotas.html">Quotas</a>
        /// in the <i>IoT SiteWise User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelHierarchies")]
        public Amazon.IoTSiteWise.Model.AssetModelHierarchyDefinition[] AssetModelHierarchy { get; set; }
        #endregion
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID to assign to the asset model, if desired. IoT SiteWise automatically generates
        /// a unique ID for you, so this parameter is never required. However, if you prefer to
        /// supply your own ID instead, you can specify it here in UUID format. If you specify
        /// your own ID, it must be globally unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelId { get; set; }
        #endregion
        
        #region Parameter AssetModelName
        /// <summary>
        /// <para>
        /// <para>A unique name for the asset model.</para>
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
        public System.String AssetModelName { get; set; }
        #endregion
        
        #region Parameter AssetModelProperty
        /// <summary>
        /// <para>
        /// <para>The property definitions of the asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/asset-properties.html">Asset
        /// properties</a> in the <i>IoT SiteWise User Guide</i>.</para><para>You can specify up to 200 properties per asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/quotas.html">Quotas</a>
        /// in the <i>IoT SiteWise User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelProperties")]
        public Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition[] AssetModelProperty { get; set; }
        #endregion
        
        #region Parameter AssetModelType
        /// <summary>
        /// <para>
        /// <para>The type of asset model.</para><ul><li><para><b>ASSET_MODEL</b> – (default) An asset model that you can use to create assets.
        /// Can't be included as a component in another asset model.</para></li><li><para><b>COMPONENT_MODEL</b> – A reusable component that you can include in the composite
        /// models of other asset models. You can't create assets directly from this type of asset
        /// model. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.AssetModelType")]
        public Amazon.IoTSiteWise.AssetModelType AssetModelType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the asset model. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/tag-resources.html">Tagging
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para><para />
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateAssetModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateAssetModelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWAssetModel (CreateAssetModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateAssetModelResponse, NewIOTSWAssetModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssetModelCompositeModel != null)
            {
                context.AssetModelCompositeModel = new List<Amazon.IoTSiteWise.Model.AssetModelCompositeModelDefinition>(this.AssetModelCompositeModel);
            }
            context.AssetModelDescription = this.AssetModelDescription;
            context.AssetModelExternalId = this.AssetModelExternalId;
            if (this.AssetModelHierarchy != null)
            {
                context.AssetModelHierarchy = new List<Amazon.IoTSiteWise.Model.AssetModelHierarchyDefinition>(this.AssetModelHierarchy);
            }
            context.AssetModelId = this.AssetModelId;
            context.AssetModelName = this.AssetModelName;
            #if MODULAR
            if (this.AssetModelName == null && ParameterWasBound(nameof(this.AssetModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssetModelProperty != null)
            {
                context.AssetModelProperty = new List<Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition>(this.AssetModelProperty);
            }
            context.AssetModelType = this.AssetModelType;
            context.ClientToken = this.ClientToken;
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
            var request = new Amazon.IoTSiteWise.Model.CreateAssetModelRequest();
            
            if (cmdletContext.AssetModelCompositeModel != null)
            {
                request.AssetModelCompositeModels = cmdletContext.AssetModelCompositeModel;
            }
            if (cmdletContext.AssetModelDescription != null)
            {
                request.AssetModelDescription = cmdletContext.AssetModelDescription;
            }
            if (cmdletContext.AssetModelExternalId != null)
            {
                request.AssetModelExternalId = cmdletContext.AssetModelExternalId;
            }
            if (cmdletContext.AssetModelHierarchy != null)
            {
                request.AssetModelHierarchies = cmdletContext.AssetModelHierarchy;
            }
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
            }
            if (cmdletContext.AssetModelName != null)
            {
                request.AssetModelName = cmdletContext.AssetModelName;
            }
            if (cmdletContext.AssetModelProperty != null)
            {
                request.AssetModelProperties = cmdletContext.AssetModelProperty;
            }
            if (cmdletContext.AssetModelType != null)
            {
                request.AssetModelType = cmdletContext.AssetModelType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.IoTSiteWise.Model.CreateAssetModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateAssetModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateAssetModel");
            try
            {
                return client.CreateAssetModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.IoTSiteWise.Model.AssetModelCompositeModelDefinition> AssetModelCompositeModel { get; set; }
            public System.String AssetModelDescription { get; set; }
            public System.String AssetModelExternalId { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelHierarchyDefinition> AssetModelHierarchy { get; set; }
            public System.String AssetModelId { get; set; }
            public System.String AssetModelName { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelPropertyDefinition> AssetModelProperty { get; set; }
            public Amazon.IoTSiteWise.AssetModelType AssetModelType { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateAssetModelResponse, NewIOTSWAssetModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
