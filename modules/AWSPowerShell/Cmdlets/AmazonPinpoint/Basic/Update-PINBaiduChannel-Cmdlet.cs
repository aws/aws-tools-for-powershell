/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Update a BAIDU GCM channel
    /// </summary>
    [Cmdlet("Update", "PINBaiduChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.BaiduChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateBaiduChannel API operation.", Operation = new[] {"UpdateBaiduChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.BaiduChannelResponse",
        "This cmdlet returns a BaiduChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateBaiduChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINBaiduChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter BaiduChannelRequest_ApiKey
        /// <summary>
        /// <para>
        /// Platform credential API key from Baidu.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BaiduChannelRequest_ApiKey { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter BaiduChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean BaiduChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter BaiduChannelRequest_SecretKey
        /// <summary>
        /// <para>
        /// Platform credential Secret key from Baidu.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BaiduChannelRequest_SecretKey { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINBaiduChannel (UpdateBaiduChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationId = this.ApplicationId;
            context.BaiduChannelRequest_ApiKey = this.BaiduChannelRequest_ApiKey;
            if (ParameterWasBound("BaiduChannelRequest_Enabled"))
                context.BaiduChannelRequest_Enabled = this.BaiduChannelRequest_Enabled;
            context.BaiduChannelRequest_SecretKey = this.BaiduChannelRequest_SecretKey;
            
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
            bool requestBaiduChannelRequestIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BaiduChannelResponse;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateBaiduChannelAsync(request);
                return task.Result;
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
        }
        
    }
}
