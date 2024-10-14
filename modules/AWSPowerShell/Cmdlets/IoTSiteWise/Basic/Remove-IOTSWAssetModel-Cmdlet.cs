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
    /// Deletes an asset model. This action can't be undone. You must delete all assets created
    /// from an asset model before you can delete the model. Also, you can't delete an asset
    /// model if a parent asset model exists that contains a property formula expression that
    /// depends on the asset model that you want to delete. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/delete-assets-and-models.html">Deleting
    /// assets and models</a> in the <i>IoT SiteWise User Guide</i>.
    /// </summary>
    [Cmdlet("Remove", "IOTSWAssetModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.IoTSiteWise.Model.AssetModelStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DeleteAssetModel API operation.", Operation = new[] {"DeleteAssetModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DeleteAssetModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AssetModelStatus or Amazon.IoTSiteWise.Model.DeleteAssetModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.AssetModelStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.DeleteAssetModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveIOTSWAssetModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model to delete. This can be either the actual ID in UUID format,
        /// or else <c>externalId:</c> followed by the external ID, if it has one. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-id-references">Referencing
        /// objects with external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The expected current entity tag (ETag) for the asset model’s latest or active version
        /// (specified using <c>matchForVersionType</c>). The delete request is rejected if the
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
        /// <para>Accepts <b>*</b> to reject the delete request if an active version (specified using
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
        /// for the delete operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.AssetModelVersionType")]
        public Amazon.IoTSiteWise.AssetModelVersionType MatchForVersionType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DeleteAssetModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DeleteAssetModelResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTSWAssetModel (DeleteAssetModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DeleteAssetModelResponse, RemoveIOTSWAssetModelCmdlet>(Select) ??
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
            context.AssetModelId = this.AssetModelId;
            #if MODULAR
            if (this.AssetModelId == null && ParameterWasBound(nameof(this.AssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.IfMatch = this.IfMatch;
            context.IfNoneMatch = this.IfNoneMatch;
            context.MatchForVersionType = this.MatchForVersionType;
            
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
            var request = new Amazon.IoTSiteWise.Model.DeleteAssetModelRequest();
            
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.IoTSiteWise.Model.DeleteAssetModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DeleteAssetModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DeleteAssetModel");
            try
            {
                #if DESKTOP
                return client.DeleteAssetModel(request);
                #elif CORECLR
                return client.DeleteAssetModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetModelId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String IfMatch { get; set; }
            public System.String IfNoneMatch { get; set; }
            public Amazon.IoTSiteWise.AssetModelVersionType MatchForVersionType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DeleteAssetModelResponse, RemoveIOTSWAssetModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssetModelStatus;
        }
        
    }
}
