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
    /// Gets an asset property's current value. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/query-industrial-data.html#current-values">Querying
    /// current values</a> in the <i>IoT SiteWise User Guide</i>.
    /// 
    ///  
    /// <para>
    /// To identify an asset property, you must specify one of the following:
    /// </para><ul><li><para>
    /// The <code>assetId</code> and <code>propertyId</code> of an asset property.
    /// </para></li><li><para>
    /// A <code>propertyAlias</code>, which is a data stream alias (for example, <code>/company/windfarm/3/turbine/7/temperature</code>).
    /// To define an asset property's alias, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_UpdateAssetProperty.html">UpdateAssetProperty</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "IOTSWAssetPropertyValue")]
    [OutputType("Amazon.IoTSiteWise.Model.AssetPropertyValue")]
    [AWSCmdlet("Calls the AWS IoT SiteWise GetAssetPropertyValue API operation.", Operation = new[] {"GetAssetPropertyValue"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AssetPropertyValue or Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.AssetPropertyValue object.",
        "The service call response (type Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTSWAssetPropertyValueCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter PropertyAlias
        /// <summary>
        /// <para>
        /// <para>The alias that identifies the property, such as an OPC-UA server data stream path
        /// (for example, <code>/company/windfarm/3/turbine/7/temperature</code>). For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/connect-data-streams.html">Mapping
        /// industrial data streams to asset properties</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyAlias { get; set; }
        #endregion
        
        #region Parameter PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset property, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PropertyValue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PropertyValue";
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
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse, GetIOTSWAssetPropertyValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetId = this.AssetId;
            context.PropertyAlias = this.PropertyAlias;
            context.PropertyId = this.PropertyId;
            
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
            var request = new Amazon.IoTSiteWise.Model.GetAssetPropertyValueRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.PropertyAlias != null)
            {
                request.PropertyAlias = cmdletContext.PropertyAlias;
            }
            if (cmdletContext.PropertyId != null)
            {
                request.PropertyId = cmdletContext.PropertyId;
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
        
        private Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.GetAssetPropertyValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "GetAssetPropertyValue");
            try
            {
                #if DESKTOP
                return client.GetAssetPropertyValue(request);
                #elif CORECLR
                return client.GetAssetPropertyValueAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetId { get; set; }
            public System.String PropertyAlias { get; set; }
            public System.String PropertyId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.GetAssetPropertyValueResponse, GetIOTSWAssetPropertyValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PropertyValue;
        }
        
    }
}
