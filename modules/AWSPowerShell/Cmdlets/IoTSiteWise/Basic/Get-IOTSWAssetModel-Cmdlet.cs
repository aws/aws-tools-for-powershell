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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Retrieves information about an asset model. This includes details about the asset
    /// model's properties, hierarchies, composite models, and any interface relationships
    /// if the asset model implements interfaces.
    /// </summary>
    [Cmdlet("Get", "IOTSWAssetModel")]
    [OutputType("Amazon.IoTSiteWise.Model.DescribeAssetModelResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DescribeAssetModel API operation.", Operation = new[] {"DescribeAssetModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DescribeAssetModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.DescribeAssetModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.DescribeAssetModelResponse object containing multiple properties."
    )]
    public partial class GetIOTSWAssetModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model. This can be either the actual ID in UUID format, or else
        /// <c>externalId:</c> followed by the external ID, if it has one. For more information,
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
        
        #region Parameter AssetModelVersion
        /// <summary>
        /// <para>
        /// <para>The version alias that specifies the latest or active version of the asset model.
        /// The details are returned in the response. The default value is <c>LATEST</c>. See
        /// <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/model-active-version.html">
        /// Asset model versions</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetModelVersion { get; set; }
        #endregion
        
        #region Parameter ExcludeProperty
        /// <summary>
        /// <para>
        /// <para> Whether or not to exclude asset model properties from the response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeProperties")]
        public System.Boolean? ExcludeProperty { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DescribeAssetModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DescribeAssetModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DescribeAssetModelResponse, GetIOTSWAssetModelCmdlet>(Select) ??
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
            context.AssetModelVersion = this.AssetModelVersion;
            context.ExcludeProperty = this.ExcludeProperty;
            
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
            var request = new Amazon.IoTSiteWise.Model.DescribeAssetModelRequest();
            
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
            }
            if (cmdletContext.AssetModelVersion != null)
            {
                request.AssetModelVersion = cmdletContext.AssetModelVersion;
            }
            if (cmdletContext.ExcludeProperty != null)
            {
                request.ExcludeProperties = cmdletContext.ExcludeProperty.Value;
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
        
        private Amazon.IoTSiteWise.Model.DescribeAssetModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DescribeAssetModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DescribeAssetModel");
            try
            {
                #if DESKTOP
                return client.DescribeAssetModel(request);
                #elif CORECLR
                return client.DescribeAssetModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetModelVersion { get; set; }
            public System.Boolean? ExcludeProperty { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DescribeAssetModelResponse, GetIOTSWAssetModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
