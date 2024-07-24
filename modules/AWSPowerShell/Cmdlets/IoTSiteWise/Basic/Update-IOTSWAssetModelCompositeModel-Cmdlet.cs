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
    /// Updates a composite model and all of the assets that were created from the model.
    /// Each asset created from the model inherits the updated asset model's property and
    /// hierarchy definitions. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/update-assets-and-models.html">Updating
    /// assets and models</a> in the <i>IoT SiteWise User Guide</i>.
    /// 
    ///  <important><para>
    /// If you remove a property from a composite asset model, IoT SiteWise deletes all previous
    /// data for that property. You can’t change the type or data type of an existing property.
    /// </para><para>
    /// To replace an existing composite asset model property with a new one with the same
    /// <c>name</c>, do the following:
    /// </para><ol><li><para>
    /// Submit an <c>UpdateAssetModelCompositeModel</c> request with the entire existing property
    /// removed.
    /// </para></li><li><para>
    /// Submit a second <c>UpdateAssetModelCompositeModel</c> request that includes the new
    /// property. The new asset property will have the same <c>name</c> as the previous one
    /// and IoT SiteWise will generate a new unique <c>id</c>.
    /// </para></li></ol></important>
    /// </summary>
    [Cmdlet("Update", "IOTSWAssetModelCompositeModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateAssetModelCompositeModel API operation.", Operation = new[] {"UpdateAssetModelCompositeModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSWAssetModelCompositeModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>An external ID to assign to the asset model. You can only set the external ID of the
        /// asset model if it wasn't set when it was created, or you're setting it to the exact
        /// same thing as when it was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelCompositeModelExternalId { get; set; }
        #endregion
        
        #region Parameter AssetModelCompositeModelId
        /// <summary>
        /// <para>
        /// <para>The ID of a composite model on this asset model.</para>
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
        public Amazon.IoTSiteWise.Model.AssetModelProperty[] AssetModelCompositeModelProperty { get; set; }
        #endregion
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model, in UUID format.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWAssetModelCompositeModel (UpdateAssetModelCompositeModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse, UpdateIOTSWAssetModelCompositeModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetModelCompositeModelDescription = this.AssetModelCompositeModelDescription;
            context.AssetModelCompositeModelExternalId = this.AssetModelCompositeModelExternalId;
            context.AssetModelCompositeModelId = this.AssetModelCompositeModelId;
            #if MODULAR
            if (this.AssetModelCompositeModelId == null && ParameterWasBound(nameof(this.AssetModelCompositeModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelCompositeModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetModelCompositeModelName = this.AssetModelCompositeModelName;
            #if MODULAR
            if (this.AssetModelCompositeModelName == null && ParameterWasBound(nameof(this.AssetModelCompositeModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelCompositeModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssetModelCompositeModelProperty != null)
            {
                context.AssetModelCompositeModelProperty = new List<Amazon.IoTSiteWise.Model.AssetModelProperty>(this.AssetModelCompositeModelProperty);
            }
            context.AssetModelId = this.AssetModelId;
            #if MODULAR
            if (this.AssetModelId == null && ParameterWasBound(nameof(this.AssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelRequest();
            
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
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
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
        
        private Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateAssetModelCompositeModel");
            try
            {
                #if DESKTOP
                return client.UpdateAssetModelCompositeModel(request);
                #elif CORECLR
                return client.UpdateAssetModelCompositeModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetModelCompositeModelDescription { get; set; }
            public System.String AssetModelCompositeModelExternalId { get; set; }
            public System.String AssetModelCompositeModelId { get; set; }
            public System.String AssetModelCompositeModelName { get; set; }
            public List<Amazon.IoTSiteWise.Model.AssetModelProperty> AssetModelCompositeModelProperty { get; set; }
            public System.String AssetModelId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateAssetModelCompositeModelResponse, UpdateIOTSWAssetModelCompositeModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
