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
    /// Updates an asset property's alias and notification state.
    /// 
    ///  <important><para>
    /// This operation overwrites the property's existing alias and notification state. To
    /// keep your existing property's alias or notification state, you must include the existing
    /// values in the UpdateAssetProperty request. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_DescribeAssetProperty.html">DescribeAssetProperty</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "IOTSWAssetProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateAssetProperty API operation.", Operation = new[] {"UpdateAssetProperty"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse))]
    [AWSCmdletOutput("None or Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSWAssetPropertyCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset to be updated.</para>
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
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter PropertyAlias
        /// <summary>
        /// <para>
        /// <para>The property alias that identifies the property, such as an OPC-UA server data stream
        /// path (for example, <code>/company/windfarm/3/turbine/7/temperature</code>). For more
        /// information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/connect-data-streams.html">Mapping
        /// Industrial Data Streams to Asset Properties</a> in the <i>AWS IoT SiteWise User Guide</i>.</para><para>If you omit this parameter, the alias is removed from the property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyAlias { get; set; }
        #endregion
        
        #region Parameter PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset property to be updated.</para>
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
        public System.String PropertyId { get; set; }
        #endregion
        
        #region Parameter PropertyNotificationState
        /// <summary>
        /// <para>
        /// <para>The MQTT notification state (enabled or disabled) for this asset property. When the
        /// notification state is enabled, AWS IoT SiteWise publishes property value updates to
        /// a unique MQTT topic. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/interact-with-other-services.html">Interacting
        /// with Other Services</a> in the <i>AWS IoT SiteWise User Guide</i>.</para><para>If you omit this parameter, the notification state is set to <code>DISABLED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.PropertyNotificationState")]
        public Amazon.IoTSiteWise.PropertyNotificationState PropertyNotificationState { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWAssetProperty (UpdateAssetProperty)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse, UpdateIOTSWAssetPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssetId = this.AssetId;
            #if MODULAR
            if (this.AssetId == null && ParameterWasBound(nameof(this.AssetId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.PropertyAlias = this.PropertyAlias;
            context.PropertyId = this.PropertyId;
            #if MODULAR
            if (this.PropertyId == null && ParameterWasBound(nameof(this.PropertyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PropertyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PropertyNotificationState = this.PropertyNotificationState;
            
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
            var request = new Amazon.IoTSiteWise.Model.UpdateAssetPropertyRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PropertyAlias != null)
            {
                request.PropertyAlias = cmdletContext.PropertyAlias;
            }
            if (cmdletContext.PropertyId != null)
            {
                request.PropertyId = cmdletContext.PropertyId;
            }
            if (cmdletContext.PropertyNotificationState != null)
            {
                request.PropertyNotificationState = cmdletContext.PropertyNotificationState;
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
        
        private Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateAssetPropertyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateAssetProperty");
            try
            {
                #if DESKTOP
                return client.UpdateAssetProperty(request);
                #elif CORECLR
                return client.UpdateAssetPropertyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String PropertyAlias { get; set; }
            public System.String PropertyId { get; set; }
            public Amazon.IoTSiteWise.PropertyNotificationState PropertyNotificationState { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateAssetPropertyResponse, UpdateIOTSWAssetPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
