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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Updates an asset model and all of the assets that were created from the model. Each
    /// asset created from the model inherits the updated asset model's property and hierarchy
    /// definitions. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/update-assets-and-models.html">Updating
    /// assets and models</a> in the <i>AWS IoT SiteWise User Guide</i>.
    /// 
    ///  <important><para>
    /// This operation overwrites the existing model with the provided model. To avoid deleting
    /// your asset model's properties or hierarchies, you must include their IDs and definitions
    /// in the updated asset model payload. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_DescribeAssetModel.html">DescribeAssetModel</a>.
    /// </para><para>
    /// If you remove a property from an asset model, AWS IoT SiteWise deletes all previous
    /// data for that property. If you remove a hierarchy definition from an asset model,
    /// AWS IoT SiteWise disassociates every asset associated with that hierarchy. You can't
    /// change the type or data type of an existing property.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "IOTSWAssetModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.AssetModelStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateAssetModel API operation.", Operation = new[] {"UpdateAssetModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateAssetModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AssetModelStatus or Amazon.IoTSiteWise.Model.UpdateAssetModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.AssetModelStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.UpdateAssetModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSWAssetModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        #region Parameter AssetModelCompositeModel
        /// <summary>
        /// <para>
        /// <para>The composite asset models that are part of this asset model. Composite asset models
        /// are asset models that contain specific properties. Each composite model has a type
        /// that defines the properties that the composite model supports. Use composite asset
        /// models to define alarms on this asset model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelCompositeModels")]
        public Amazon.IoTSiteWise.Model.AssetModelCompositeModel[] AssetModelCompositeModel { get; set; }
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
        
        #region Parameter AssetModelHierarchy
        /// <summary>
        /// <para>
        /// <para>The updated hierarchy definitions of the asset model. Each hierarchy specifies an
        /// asset model whose assets can be children of any other assets created from this asset
        /// model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/asset-hierarchies.html">Asset
        /// hierarchies</a> in the <i>AWS IoT SiteWise User Guide</i>.</para><para>You can specify up to 10 hierarchies per asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/quotas.html">Quotas</a>
        /// in the <i>AWS IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelHierarchies")]
        public Amazon.IoTSiteWise.Model.AssetModelHierarchy[] AssetModelHierarchy { get; set; }
        #endregion
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model to update.</para>
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
        public System.String AssetModelId { get; set; }
        #endregion
        
        #region Parameter AssetModelName
        /// <summary>
        /// <para>
        /// <para>A unique, friendly name for the asset model.</para>
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
        /// <para>The updated property definitions of the asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/asset-properties.html">Asset
        /// properties</a> in the <i>AWS IoT SiteWise User Guide</i>.</para><para>You can specify up to 200 properties per asset model. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/quotas.html">Quotas</a>
        /// in the <i>AWS IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetModelProperties")]
        public Amazon.IoTSiteWise.Model.AssetModelProperty[] AssetModelProperty { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssetModelStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateAssetModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateAssetModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssetModelStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssetModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssetModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssetModelId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWAssetModel (UpdateAssetModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateAssetModelResponse, UpdateIOTSWAssetModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssetModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssetModelCompositeModel != null)
            {
                context.AssetModelCompositeModel = new List<Amazon.IoTSiteWise.Model.AssetModelCompositeModel>(this.AssetModelCompositeModel);
            }
            context.AssetModelDescription = this.AssetModelDescription;
            if (this.AssetModelHierarchy != null)
            {
                context.AssetModelHierarchy = new List<Amazon.IoTSiteWise.Model.AssetModelHierarchy>(this.AssetModelHierarchy);
            }
            context.AssetModelId = this.AssetModelId;
            #if MODULAR
            if (this.AssetModelId == null && ParameterWasBound(nameof(this.AssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetModelName = this.AssetModelName;
            #if MODULAR
            if (this.AssetModelName == null && ParameterWasBound(nameof(this.AssetModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssetModelProperty != null)
            {
                context.AssetModelProperty = new List<Amazon.IoTSiteWise.Model.AssetModelProperty>(this.AssetModelProperty);
            }
            context.ClientToken = this.ClientToken;
            
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
            var request = new Amazon.IoTSiteWise.Model.UpdateAssetModelRequest();
            
            if (cmdletContext.AssetModelCompositeModel != null)
            {
                request.AssetModelCompositeModels = cmdletContext.AssetModelCompositeModel;
            }
            if (cmdletContext.AssetModelDescription != null)
            {
                request.AssetModelDescription = cmdletContext.AssetModelDescription;
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.IoTSiteWise.Model.UpdateAssetModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateAssetModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateAssetModel");
            try
            {
                #if DESKTOP
                return client.UpdateAssetModel(request);
                #elif CORECLR
                return client.UpdateAssetModelAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoTSiteWise.Model.AssetModelCompositeModel> AssetModelCompositeModel { get; set; }
            public System.String AssetModelDescription { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelHierarchy> AssetModelHierarchy { get; set; }
            public System.String AssetModelId { get; set; }
            public System.String AssetModelName { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelProperty> AssetModelProperty { get; set; }
            public System.String ClientToken { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateAssetModelResponse, UpdateIOTSWAssetModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssetModelStatus;
        }
        
    }
}
