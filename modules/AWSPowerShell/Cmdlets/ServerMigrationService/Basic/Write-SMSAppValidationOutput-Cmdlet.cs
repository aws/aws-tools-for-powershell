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
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.SMS
{
    /// <summary>
    /// Provides information to Server Migration Service about whether application validation
    /// is successful.
    /// </summary>
    [Cmdlet("Write", "SMSAppValidationOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Server Migration Service NotifyAppValidationOutput API operation.", Operation = new[] {"NotifyAppValidationOutput"}, SelectReturnType = typeof(Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse))]
    [AWSCmdletOutput("None or Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSMSAppValidationOutputCmdlet : AmazonServerMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The ID of the application.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter NotificationContext_Status
        /// <summary>
        /// <para>
        /// <para>The status of the validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServerMigrationService.ValidationStatus")]
        public Amazon.ServerMigrationService.ValidationStatus NotificationContext_Status { get; set; }
        #endregion
        
        #region Parameter NotificationContext_StatusMessage
        /// <summary>
        /// <para>
        /// <para>The status message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationContext_StatusMessage { get; set; }
        #endregion
        
        #region Parameter NotificationContext_ValidationId
        /// <summary>
        /// <para>
        /// <para>The ID of the validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationContext_ValidationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMSAppValidationOutput (NotifyAppValidationOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse, WriteSMSAppValidationOutputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationContext_Status = this.NotificationContext_Status;
            context.NotificationContext_StatusMessage = this.NotificationContext_StatusMessage;
            context.NotificationContext_ValidationId = this.NotificationContext_ValidationId;
            
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
            var request = new Amazon.ServerMigrationService.Model.NotifyAppValidationOutputRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            
             // populate NotificationContext
            var requestNotificationContextIsNull = true;
            request.NotificationContext = new Amazon.ServerMigrationService.Model.NotificationContext();
            Amazon.ServerMigrationService.ValidationStatus requestNotificationContext_notificationContext_Status = null;
            if (cmdletContext.NotificationContext_Status != null)
            {
                requestNotificationContext_notificationContext_Status = cmdletContext.NotificationContext_Status;
            }
            if (requestNotificationContext_notificationContext_Status != null)
            {
                request.NotificationContext.Status = requestNotificationContext_notificationContext_Status;
                requestNotificationContextIsNull = false;
            }
            System.String requestNotificationContext_notificationContext_StatusMessage = null;
            if (cmdletContext.NotificationContext_StatusMessage != null)
            {
                requestNotificationContext_notificationContext_StatusMessage = cmdletContext.NotificationContext_StatusMessage;
            }
            if (requestNotificationContext_notificationContext_StatusMessage != null)
            {
                request.NotificationContext.StatusMessage = requestNotificationContext_notificationContext_StatusMessage;
                requestNotificationContextIsNull = false;
            }
            System.String requestNotificationContext_notificationContext_ValidationId = null;
            if (cmdletContext.NotificationContext_ValidationId != null)
            {
                requestNotificationContext_notificationContext_ValidationId = cmdletContext.NotificationContext_ValidationId;
            }
            if (requestNotificationContext_notificationContext_ValidationId != null)
            {
                request.NotificationContext.ValidationId = requestNotificationContext_notificationContext_ValidationId;
                requestNotificationContextIsNull = false;
            }
             // determine if request.NotificationContext should be set to null
            if (requestNotificationContextIsNull)
            {
                request.NotificationContext = null;
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
        
        private Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse CallAWSServiceOperation(IAmazonServerMigrationService client, Amazon.ServerMigrationService.Model.NotifyAppValidationOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Server Migration Service", "NotifyAppValidationOutput");
            try
            {
                return client.NotifyAppValidationOutputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public Amazon.ServerMigrationService.ValidationStatus NotificationContext_Status { get; set; }
            public System.String NotificationContext_StatusMessage { get; set; }
            public System.String NotificationContext_ValidationId { get; set; }
            public System.Func<Amazon.ServerMigrationService.Model.NotifyAppValidationOutputResponse, WriteSMSAppValidationOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
