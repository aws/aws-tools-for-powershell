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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Specifies which devices and operating systems users can use to access their WorkSpaces.
    /// For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/update-directory-details.html#control-device-access">
    /// Control Device Access</a>.
    /// </summary>
    [Cmdlet("Edit", "WKSWorkspaceAccessProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyWorkspaceAccessProperties API operation.", Operation = new[] {"ModifyWorkspaceAccessProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSWorkspaceAccessPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessEndpointConfig_AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>Indicates a list of access endpoints associated with this directory.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceAccessProperties_AccessEndpointConfig_AccessEndpoints")]
        public Amazon.WorkSpaces.Model.AccessEndpoint[] AccessEndpointConfig_AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeAndroid
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use Android and Android-compatible Chrome OS devices to
        /// access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeAndroid { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeChromeOs
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use Chromebooks to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeChromeOs { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeIo
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use iOS devices to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceAccessProperties_DeviceTypeIos")]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeIo { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeLinux
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use Linux clients to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeLinux { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeOsx
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use macOS clients to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeOsx { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeWeb
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can access their WorkSpaces through a web browser.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWeb { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeWindow
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use Windows clients to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceAccessProperties_DeviceTypeWindows")]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWindow { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can access their WorkSpaces through a WorkSpaces Thin Client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient { get; set; }
        #endregion
        
        #region Parameter WorkspaceAccessProperties_DeviceTypeZeroClient
        /// <summary>
        /// <para>
        /// <para>Indicates whether users can use zero client devices to access their WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.AccessPropertyValue")]
        public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeZeroClient { get; set; }
        #endregion
        
        #region Parameter AccessEndpointConfig_InternetFallbackProtocol
        /// <summary>
        /// <para>
        /// <para>Indicates a list of protocols that fallback to using the public Internet when streaming
        /// over a VPC endpoint is not available.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceAccessProperties_AccessEndpointConfig_InternetFallbackProtocols")]
        public System.String[] AccessEndpointConfig_InternetFallbackProtocol { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSWorkspaceAccessProperty (ModifyWorkspaceAccessProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse, EditWKSWorkspaceAccessPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AccessEndpointConfig_AccessEndpoint != null)
            {
                context.AccessEndpointConfig_AccessEndpoint = new List<Amazon.WorkSpaces.Model.AccessEndpoint>(this.AccessEndpointConfig_AccessEndpoint);
            }
            if (this.AccessEndpointConfig_InternetFallbackProtocol != null)
            {
                context.AccessEndpointConfig_InternetFallbackProtocol = new List<System.String>(this.AccessEndpointConfig_InternetFallbackProtocol);
            }
            context.WorkspaceAccessProperties_DeviceTypeAndroid = this.WorkspaceAccessProperties_DeviceTypeAndroid;
            context.WorkspaceAccessProperties_DeviceTypeChromeOs = this.WorkspaceAccessProperties_DeviceTypeChromeOs;
            context.WorkspaceAccessProperties_DeviceTypeIo = this.WorkspaceAccessProperties_DeviceTypeIo;
            context.WorkspaceAccessProperties_DeviceTypeLinux = this.WorkspaceAccessProperties_DeviceTypeLinux;
            context.WorkspaceAccessProperties_DeviceTypeOsx = this.WorkspaceAccessProperties_DeviceTypeOsx;
            context.WorkspaceAccessProperties_DeviceTypeWeb = this.WorkspaceAccessProperties_DeviceTypeWeb;
            context.WorkspaceAccessProperties_DeviceTypeWindow = this.WorkspaceAccessProperties_DeviceTypeWindow;
            context.WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient = this.WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient;
            context.WorkspaceAccessProperties_DeviceTypeZeroClient = this.WorkspaceAccessProperties_DeviceTypeZeroClient;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
             // populate WorkspaceAccessProperties
            var requestWorkspaceAccessPropertiesIsNull = true;
            request.WorkspaceAccessProperties = new Amazon.WorkSpaces.Model.WorkspaceAccessProperties();
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeAndroid = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeAndroid != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeAndroid = cmdletContext.WorkspaceAccessProperties_DeviceTypeAndroid;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeAndroid != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeAndroid = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeAndroid;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeChromeOs = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeChromeOs != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeChromeOs = cmdletContext.WorkspaceAccessProperties_DeviceTypeChromeOs;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeChromeOs != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeChromeOs = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeChromeOs;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeIo = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeIo != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeIo = cmdletContext.WorkspaceAccessProperties_DeviceTypeIo;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeIo != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeIos = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeIo;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeLinux = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeLinux != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeLinux = cmdletContext.WorkspaceAccessProperties_DeviceTypeLinux;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeLinux != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeLinux = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeLinux;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeOsx = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeOsx != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeOsx = cmdletContext.WorkspaceAccessProperties_DeviceTypeOsx;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeOsx != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeOsx = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeOsx;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWeb = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeWeb != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWeb = cmdletContext.WorkspaceAccessProperties_DeviceTypeWeb;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWeb != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeWeb = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWeb;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWindow = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeWindow != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWindow = cmdletContext.WorkspaceAccessProperties_DeviceTypeWindow;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWindow != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeWindows = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWindow;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWorkSpacesThinClient = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWorkSpacesThinClient = cmdletContext.WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWorkSpacesThinClient != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeWorkSpacesThinClient = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeWorkSpacesThinClient;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.AccessPropertyValue requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeZeroClient = null;
            if (cmdletContext.WorkspaceAccessProperties_DeviceTypeZeroClient != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeZeroClient = cmdletContext.WorkspaceAccessProperties_DeviceTypeZeroClient;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeZeroClient != null)
            {
                request.WorkspaceAccessProperties.DeviceTypeZeroClient = requestWorkspaceAccessProperties_workspaceAccessProperties_DeviceTypeZeroClient;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.Model.AccessEndpointConfig requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig = null;
            
             // populate AccessEndpointConfig
            var requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfigIsNull = true;
            requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig = new Amazon.WorkSpaces.Model.AccessEndpointConfig();
            List<Amazon.WorkSpaces.Model.AccessEndpoint> requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_AccessEndpoint = null;
            if (cmdletContext.AccessEndpointConfig_AccessEndpoint != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_AccessEndpoint = cmdletContext.AccessEndpointConfig_AccessEndpoint;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_AccessEndpoint != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig.AccessEndpoints = requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_AccessEndpoint;
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfigIsNull = false;
            }
            List<System.String> requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_InternetFallbackProtocol = null;
            if (cmdletContext.AccessEndpointConfig_InternetFallbackProtocol != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_InternetFallbackProtocol = cmdletContext.AccessEndpointConfig_InternetFallbackProtocol;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_InternetFallbackProtocol != null)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig.InternetFallbackProtocols = requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig_accessEndpointConfig_InternetFallbackProtocol;
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfigIsNull = false;
            }
             // determine if requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig should be set to null
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfigIsNull)
            {
                requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig = null;
            }
            if (requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig != null)
            {
                request.WorkspaceAccessProperties.AccessEndpointConfig = requestWorkspaceAccessProperties_workspaceAccessProperties_AccessEndpointConfig;
                requestWorkspaceAccessPropertiesIsNull = false;
            }
             // determine if request.WorkspaceAccessProperties should be set to null
            if (requestWorkspaceAccessPropertiesIsNull)
            {
                request.WorkspaceAccessProperties = null;
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
        
        private Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyWorkspaceAccessProperties");
            try
            {
                return client.ModifyWorkspaceAccessPropertiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public List<Amazon.WorkSpaces.Model.AccessEndpoint> AccessEndpointConfig_AccessEndpoint { get; set; }
            public List<System.String> AccessEndpointConfig_InternetFallbackProtocol { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeAndroid { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeChromeOs { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeIo { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeLinux { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeOsx { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWeb { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWindow { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient { get; set; }
            public Amazon.WorkSpaces.AccessPropertyValue WorkspaceAccessProperties_DeviceTypeZeroClient { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyWorkspaceAccessPropertiesResponse, EditWKSWorkspaceAccessPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
