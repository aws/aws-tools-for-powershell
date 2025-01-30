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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Schedules delivery of a configuration snapshot to the Amazon S3 bucket in the specified
    /// delivery channel. After the delivery has started, Config sends the following notifications
    /// using an Amazon SNS topic that you have specified.
    /// 
    ///  <ul><li><para>
    /// Notification of the start of the delivery.
    /// </para></li><li><para>
    /// Notification of the completion of the delivery, if the delivery was successfully completed.
    /// </para></li><li><para>
    /// Notification of delivery failure, if the delivery failed.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Submit", "CFGConfigSnapshotDelivery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config DeliverConfigSnapshot API operation.", Operation = new[] {"DeliverConfigSnapshot"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DeliverConfigSnapshotResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.DeliverConfigSnapshotResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.DeliverConfigSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SubmitCFGConfigSnapshotDeliveryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliveryChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery channel through which the snapshot is delivered.</para>
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
        public System.String DeliveryChannelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigSnapshotId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DeliverConfigSnapshotResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DeliverConfigSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigSnapshotId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeliveryChannelName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeliveryChannelName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeliveryChannelName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryChannelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-CFGConfigSnapshotDelivery (DeliverConfigSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DeliverConfigSnapshotResponse, SubmitCFGConfigSnapshotDeliveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeliveryChannelName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeliveryChannelName = this.DeliveryChannelName;
            #if MODULAR
            if (this.DeliveryChannelName == null && ParameterWasBound(nameof(this.DeliveryChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.DeliverConfigSnapshotRequest();
            
            if (cmdletContext.DeliveryChannelName != null)
            {
                request.DeliveryChannelName = cmdletContext.DeliveryChannelName;
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
        
        private Amazon.ConfigService.Model.DeliverConfigSnapshotResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DeliverConfigSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DeliverConfigSnapshot");
            try
            {
                #if DESKTOP
                return client.DeliverConfigSnapshot(request);
                #elif CORECLR
                return client.DeliverConfigSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryChannelName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DeliverConfigSnapshotResponse, SubmitCFGConfigSnapshotDeliveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigSnapshotId;
        }
        
    }
}
