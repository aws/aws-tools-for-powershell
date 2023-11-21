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
    /// Retrieves information about an asset model composite model (also known as an asset
    /// model component). For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/custom-composite-models.html">Custom
    /// composite models (Components)</a> in the <i>IoT SiteWise User Guide</i>.
    /// </summary>
    [Cmdlet("Get", "IOTSWAssetModelCompositeModel")]
    [OutputType("Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DescribeAssetModelCompositeModel API operation.", Operation = new[] {"DescribeAssetModelCompositeModel"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTSWAssetModelCompositeModelCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetModelCompositeModelId
        /// <summary>
        /// <para>
        /// <para>The ID of a composite model on this asset model. This can be either the actual ID
        /// in UUID format, or else <code>externalId:</code> followed by the external ID, if it
        /// has one. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-id-references">Referencing
        /// objects with external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        /// <para>The ID of the asset model. This can be either the actual ID in UUID format, or else
        /// <code>externalId:</code> followed by the external ID, if it has one. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-id-references">Referencing
        /// objects with external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse, GetIOTSWAssetModelCompositeModelCmdlet>(Select) ??
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
            var request = new Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelRequest();
            
            if (cmdletContext.AssetModelCompositeModelId != null)
            {
                request.AssetModelCompositeModelId = cmdletContext.AssetModelCompositeModelId;
            }
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
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
        
        private Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DescribeAssetModelCompositeModel");
            try
            {
                #if DESKTOP
                return client.DescribeAssetModelCompositeModel(request);
                #elif CORECLR
                return client.DescribeAssetModelCompositeModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetModelCompositeModelId { get; set; }
            public System.String AssetModelId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DescribeAssetModelCompositeModelResponse, GetIOTSWAssetModelCompositeModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
