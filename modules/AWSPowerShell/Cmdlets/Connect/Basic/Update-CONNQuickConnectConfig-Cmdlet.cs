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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the configuration settings for the specified quick connect.
    /// </summary>
    [Cmdlet("Update", "CONNQuickConnectConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateQuickConnectConfig API operation.", Operation = new[] {"UpdateQuickConnectConfig"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateQuickConnectConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateQuickConnectConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateQuickConnectConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNQuickConnectConfigCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueueConfig_ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectConfig_QueueConfig_ContactFlowId")]
        public System.String QueueConfig_ContactFlowId { get; set; }
        #endregion
        
        #region Parameter UserConfig_ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectConfig_UserConfig_ContactFlowId")]
        public System.String UserConfig_ContactFlowId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PhoneConfig_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number in E.164 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectConfig_PhoneConfig_PhoneNumber")]
        public System.String PhoneConfig_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter QueueConfig_QueueId
        /// <summary>
        /// <para>
        /// <para>The identifier for the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectConfig_QueueConfig_QueueId")]
        public System.String QueueConfig_QueueId { get; set; }
        #endregion
        
        #region Parameter QuickConnectId
        /// <summary>
        /// <para>
        /// <para>The identifier for the quick connect.</para>
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
        public System.String QuickConnectId { get; set; }
        #endregion
        
        #region Parameter QuickConnectConfig_QuickConnectType
        /// <summary>
        /// <para>
        /// <para>The type of quick connect. In the Amazon Connect admin website, when you create a
        /// quick connect, you are prompted to assign one of the following types: Agent (USER),
        /// External (PHONE_NUMBER), or Queue (QUEUE). </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.QuickConnectType")]
        public Amazon.Connect.QuickConnectType QuickConnectConfig_QuickConnectType { get; set; }
        #endregion
        
        #region Parameter UserConfig_UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QuickConnectConfig_UserConfig_UserId")]
        public System.String UserConfig_UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateQuickConnectConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNQuickConnectConfig (UpdateQuickConnectConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateQuickConnectConfigResponse, UpdateCONNQuickConnectConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PhoneConfig_PhoneNumber = this.PhoneConfig_PhoneNumber;
            context.QueueConfig_ContactFlowId = this.QueueConfig_ContactFlowId;
            context.QueueConfig_QueueId = this.QueueConfig_QueueId;
            context.QuickConnectConfig_QuickConnectType = this.QuickConnectConfig_QuickConnectType;
            #if MODULAR
            if (this.QuickConnectConfig_QuickConnectType == null && ParameterWasBound(nameof(this.QuickConnectConfig_QuickConnectType)))
            {
                WriteWarning("You are passing $null as a value for parameter QuickConnectConfig_QuickConnectType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserConfig_ContactFlowId = this.UserConfig_ContactFlowId;
            context.UserConfig_UserId = this.UserConfig_UserId;
            context.QuickConnectId = this.QuickConnectId;
            #if MODULAR
            if (this.QuickConnectId == null && ParameterWasBound(nameof(this.QuickConnectId)))
            {
                WriteWarning("You are passing $null as a value for parameter QuickConnectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateQuickConnectConfigRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate QuickConnectConfig
            var requestQuickConnectConfigIsNull = true;
            request.QuickConnectConfig = new Amazon.Connect.Model.QuickConnectConfig();
            Amazon.Connect.QuickConnectType requestQuickConnectConfig_quickConnectConfig_QuickConnectType = null;
            if (cmdletContext.QuickConnectConfig_QuickConnectType != null)
            {
                requestQuickConnectConfig_quickConnectConfig_QuickConnectType = cmdletContext.QuickConnectConfig_QuickConnectType;
            }
            if (requestQuickConnectConfig_quickConnectConfig_QuickConnectType != null)
            {
                request.QuickConnectConfig.QuickConnectType = requestQuickConnectConfig_quickConnectConfig_QuickConnectType;
                requestQuickConnectConfigIsNull = false;
            }
            Amazon.Connect.Model.PhoneNumberQuickConnectConfig requestQuickConnectConfig_quickConnectConfig_PhoneConfig = null;
            
             // populate PhoneConfig
            var requestQuickConnectConfig_quickConnectConfig_PhoneConfigIsNull = true;
            requestQuickConnectConfig_quickConnectConfig_PhoneConfig = new Amazon.Connect.Model.PhoneNumberQuickConnectConfig();
            System.String requestQuickConnectConfig_quickConnectConfig_PhoneConfig_phoneConfig_PhoneNumber = null;
            if (cmdletContext.PhoneConfig_PhoneNumber != null)
            {
                requestQuickConnectConfig_quickConnectConfig_PhoneConfig_phoneConfig_PhoneNumber = cmdletContext.PhoneConfig_PhoneNumber;
            }
            if (requestQuickConnectConfig_quickConnectConfig_PhoneConfig_phoneConfig_PhoneNumber != null)
            {
                requestQuickConnectConfig_quickConnectConfig_PhoneConfig.PhoneNumber = requestQuickConnectConfig_quickConnectConfig_PhoneConfig_phoneConfig_PhoneNumber;
                requestQuickConnectConfig_quickConnectConfig_PhoneConfigIsNull = false;
            }
             // determine if requestQuickConnectConfig_quickConnectConfig_PhoneConfig should be set to null
            if (requestQuickConnectConfig_quickConnectConfig_PhoneConfigIsNull)
            {
                requestQuickConnectConfig_quickConnectConfig_PhoneConfig = null;
            }
            if (requestQuickConnectConfig_quickConnectConfig_PhoneConfig != null)
            {
                request.QuickConnectConfig.PhoneConfig = requestQuickConnectConfig_quickConnectConfig_PhoneConfig;
                requestQuickConnectConfigIsNull = false;
            }
            Amazon.Connect.Model.QueueQuickConnectConfig requestQuickConnectConfig_quickConnectConfig_QueueConfig = null;
            
             // populate QueueConfig
            var requestQuickConnectConfig_quickConnectConfig_QueueConfigIsNull = true;
            requestQuickConnectConfig_quickConnectConfig_QueueConfig = new Amazon.Connect.Model.QueueQuickConnectConfig();
            System.String requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_ContactFlowId = null;
            if (cmdletContext.QueueConfig_ContactFlowId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_ContactFlowId = cmdletContext.QueueConfig_ContactFlowId;
            }
            if (requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_ContactFlowId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_QueueConfig.ContactFlowId = requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_ContactFlowId;
                requestQuickConnectConfig_quickConnectConfig_QueueConfigIsNull = false;
            }
            System.String requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_QueueId = null;
            if (cmdletContext.QueueConfig_QueueId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_QueueId = cmdletContext.QueueConfig_QueueId;
            }
            if (requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_QueueId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_QueueConfig.QueueId = requestQuickConnectConfig_quickConnectConfig_QueueConfig_queueConfig_QueueId;
                requestQuickConnectConfig_quickConnectConfig_QueueConfigIsNull = false;
            }
             // determine if requestQuickConnectConfig_quickConnectConfig_QueueConfig should be set to null
            if (requestQuickConnectConfig_quickConnectConfig_QueueConfigIsNull)
            {
                requestQuickConnectConfig_quickConnectConfig_QueueConfig = null;
            }
            if (requestQuickConnectConfig_quickConnectConfig_QueueConfig != null)
            {
                request.QuickConnectConfig.QueueConfig = requestQuickConnectConfig_quickConnectConfig_QueueConfig;
                requestQuickConnectConfigIsNull = false;
            }
            Amazon.Connect.Model.UserQuickConnectConfig requestQuickConnectConfig_quickConnectConfig_UserConfig = null;
            
             // populate UserConfig
            var requestQuickConnectConfig_quickConnectConfig_UserConfigIsNull = true;
            requestQuickConnectConfig_quickConnectConfig_UserConfig = new Amazon.Connect.Model.UserQuickConnectConfig();
            System.String requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_ContactFlowId = null;
            if (cmdletContext.UserConfig_ContactFlowId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_ContactFlowId = cmdletContext.UserConfig_ContactFlowId;
            }
            if (requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_ContactFlowId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_UserConfig.ContactFlowId = requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_ContactFlowId;
                requestQuickConnectConfig_quickConnectConfig_UserConfigIsNull = false;
            }
            System.String requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_UserId = null;
            if (cmdletContext.UserConfig_UserId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_UserId = cmdletContext.UserConfig_UserId;
            }
            if (requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_UserId != null)
            {
                requestQuickConnectConfig_quickConnectConfig_UserConfig.UserId = requestQuickConnectConfig_quickConnectConfig_UserConfig_userConfig_UserId;
                requestQuickConnectConfig_quickConnectConfig_UserConfigIsNull = false;
            }
             // determine if requestQuickConnectConfig_quickConnectConfig_UserConfig should be set to null
            if (requestQuickConnectConfig_quickConnectConfig_UserConfigIsNull)
            {
                requestQuickConnectConfig_quickConnectConfig_UserConfig = null;
            }
            if (requestQuickConnectConfig_quickConnectConfig_UserConfig != null)
            {
                request.QuickConnectConfig.UserConfig = requestQuickConnectConfig_quickConnectConfig_UserConfig;
                requestQuickConnectConfigIsNull = false;
            }
             // determine if request.QuickConnectConfig should be set to null
            if (requestQuickConnectConfigIsNull)
            {
                request.QuickConnectConfig = null;
            }
            if (cmdletContext.QuickConnectId != null)
            {
                request.QuickConnectId = cmdletContext.QuickConnectId;
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
        
        private Amazon.Connect.Model.UpdateQuickConnectConfigResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateQuickConnectConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateQuickConnectConfig");
            try
            {
                #if DESKTOP
                return client.UpdateQuickConnectConfig(request);
                #elif CORECLR
                return client.UpdateQuickConnectConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String PhoneConfig_PhoneNumber { get; set; }
            public System.String QueueConfig_ContactFlowId { get; set; }
            public System.String QueueConfig_QueueId { get; set; }
            public Amazon.Connect.QuickConnectType QuickConnectConfig_QuickConnectType { get; set; }
            public System.String UserConfig_ContactFlowId { get; set; }
            public System.String UserConfig_UserId { get; set; }
            public System.String QuickConnectId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateQuickConnectConfigResponse, UpdateCONNQuickConnectConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
