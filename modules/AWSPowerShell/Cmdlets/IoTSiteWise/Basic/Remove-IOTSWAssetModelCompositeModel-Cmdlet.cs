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

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Deletes a composite model. This action can't be undone. You must delete all assets
    /// created from a composite model before you can delete the model. Also, you can't delete
    /// a composite model if a parent asset model exists that contains a property formula
    /// expression that depends on the asset model that you want to delete. For more information,
    /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/delete-assets-and-models.html">Deleting
    /// assets and models</a> in the <i>IoT SiteWise User Guide</i>.
    /// </summary>
    [Cmdlet("Remove", "IOTSWAssetModelCompositeModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.IoTSiteWise.Model.AssetModelStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DeleteAssetModelCompositeModel API operation.", Operation = new[] {"DeleteAssetModelCompositeModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AssetModelStatus or Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.AssetModelStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveIOTSWAssetModelCompositeModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssetModelStatus";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTSWAssetModelCompositeModel (DeleteAssetModelCompositeModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse, RemoveIOTSWAssetModelCompositeModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetModelCompositeModelId = this.AssetModelCompositeModelId;
            #if MODULAR
            if (this.AssetModelCompositeModelId == null && ParameterWasBound(nameof(this.AssetModelCompositeModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelCompositeModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelRequest();
            
            if (cmdletContext.AssetModelCompositeModelId != null)
            {
                request.AssetModelCompositeModelId = cmdletContext.AssetModelCompositeModelId;
            }
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
        
        private Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DeleteAssetModelCompositeModel");
            try
            {
                return client.DeleteAssetModelCompositeModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssetModelCompositeModelId { get; set; }
            public System.String AssetModelId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String IfMatch { get; set; }
            public System.String IfNoneMatch { get; set; }
            public Amazon.IoTSiteWise.AssetModelVersionType MatchForVersionType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DeleteAssetModelCompositeModelResponse, RemoveIOTSWAssetModelCompositeModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssetModelStatus;
        }
        
    }
}
