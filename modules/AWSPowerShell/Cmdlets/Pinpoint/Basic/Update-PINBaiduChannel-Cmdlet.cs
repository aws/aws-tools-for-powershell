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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the Baidu channel for an application or updates the status and settings of
    /// the Baidu channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINBaiduChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.BaiduChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateBaiduChannel API operation.", Operation = new[] {"UpdateBaiduChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateBaiduChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.BaiduChannelResponse or Amazon.Pinpoint.Model.UpdateBaiduChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.BaiduChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateBaiduChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINBaiduChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaiduChannelRequest_ApiKey
        /// <summary>
        /// <para>
        /// <para>The API key that you received from the Baidu Cloud Push service to communicate with
        /// the service.</para>
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
        public System.String BaiduChannelRequest_ApiKey { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter BaiduChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the Baidu channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BaiduChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter BaiduChannelRequest_SecretKey
        /// <summary>
        /// <para>
        /// <para>The secret key that you received from the Baidu Cloud Push service to communicate
        /// with the service.</para>
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
        public System.String BaiduChannelRequest_SecretKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BaiduChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateBaiduChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateBaiduChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BaiduChannelResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINBaiduChannel (UpdateBaiduChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateBaiduChannelResponse, UpdatePINBaiduChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaiduChannelRequest_ApiKey = this.BaiduChannelRequest_ApiKey;
            #if MODULAR
            if (this.BaiduChannelRequest_ApiKey == null && ParameterWasBound(nameof(this.BaiduChannelRequest_ApiKey)))
            {
                WriteWarning("You are passing $null as a value for parameter BaiduChannelRequest_ApiKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaiduChannelRequest_Enabled = this.BaiduChannelRequest_Enabled;
            context.BaiduChannelRequest_SecretKey = this.BaiduChannelRequest_SecretKey;
            #if MODULAR
            if (this.BaiduChannelRequest_SecretKey == null && ParameterWasBound(nameof(this.BaiduChannelRequest_SecretKey)))
            {
                WriteWarning("You are passing $null as a value for parameter BaiduChannelRequest_SecretKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.UpdateBaiduChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate BaiduChannelRequest
            var requestBaiduChannelRequestIsNull = true;
            request.BaiduChannelRequest = new Amazon.Pinpoint.Model.BaiduChannelRequest();
            System.String requestBaiduChannelRequest_baiduChannelRequest_ApiKey = null;
            if (cmdletContext.BaiduChannelRequest_ApiKey != null)
            {
                requestBaiduChannelRequest_baiduChannelRequest_ApiKey = cmdletContext.BaiduChannelRequest_ApiKey;
            }
            if (requestBaiduChannelRequest_baiduChannelRequest_ApiKey != null)
            {
                request.BaiduChannelRequest.ApiKey = requestBaiduChannelRequest_baiduChannelRequest_ApiKey;
                requestBaiduChannelRequestIsNull = false;
            }
            System.Boolean? requestBaiduChannelRequest_baiduChannelRequest_Enabled = null;
            if (cmdletContext.BaiduChannelRequest_Enabled != null)
            {
                requestBaiduChannelRequest_baiduChannelRequest_Enabled = cmdletContext.BaiduChannelRequest_Enabled.Value;
            }
            if (requestBaiduChannelRequest_baiduChannelRequest_Enabled != null)
            {
                request.BaiduChannelRequest.Enabled = requestBaiduChannelRequest_baiduChannelRequest_Enabled.Value;
                requestBaiduChannelRequestIsNull = false;
            }
            System.String requestBaiduChannelRequest_baiduChannelRequest_SecretKey = null;
            if (cmdletContext.BaiduChannelRequest_SecretKey != null)
            {
                requestBaiduChannelRequest_baiduChannelRequest_SecretKey = cmdletContext.BaiduChannelRequest_SecretKey;
            }
            if (requestBaiduChannelRequest_baiduChannelRequest_SecretKey != null)
            {
                request.BaiduChannelRequest.SecretKey = requestBaiduChannelRequest_baiduChannelRequest_SecretKey;
                requestBaiduChannelRequestIsNull = false;
            }
             // determine if request.BaiduChannelRequest should be set to null
            if (requestBaiduChannelRequestIsNull)
            {
                request.BaiduChannelRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateBaiduChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateBaiduChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateBaiduChannel");
            try
            {
                #if DESKTOP
                return client.UpdateBaiduChannel(request);
                #elif CORECLR
                return client.UpdateBaiduChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String BaiduChannelRequest_ApiKey { get; set; }
            public System.Boolean? BaiduChannelRequest_Enabled { get; set; }
            public System.String BaiduChannelRequest_SecretKey { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateBaiduChannelResponse, UpdatePINBaiduChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BaiduChannelResponse;
        }
        
    }
}
