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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Sets the attributes of the platform application object for the supported push notification
    /// services, such as APNS and GCM (Firebase Cloud Messaging). For more information, see
    /// <a href="https://docs.aws.amazon.com/sns/latest/dg/SNSMobilePush.html">Using Amazon
    /// SNS Mobile Push Notifications</a>. For information on configuring attributes for message
    /// delivery status, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-msg-status.html">Using
    /// Amazon SNS Application Attributes for Message Delivery Status</a>.
    /// </summary>
    [Cmdlet("Set", "SNSPlatformApplicationAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) SetPlatformApplicationAttributes API operation.", Operation = new[] {"SetPlatformApplicationAttributes"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse), LegacyAlias="Set-SNSPlatformApplicationAttributes")]
    [AWSCmdletOutput("None or Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSNSPlatformApplicationAttributeCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of the platform application attributes. Attributes in this map include the following:</para><ul><li><para><c>PlatformCredential</c> – The credential received from the notification service.</para><ul><li><para>For ADM, <c>PlatformCredential</c>is client secret.</para></li><li><para>For Apple Services using certificate credentials, <c>PlatformCredential</c> is private
        /// key.</para></li><li><para>For Apple Services using token credentials, <c>PlatformCredential</c> is signing key.</para></li><li><para>For GCM (Firebase Cloud Messaging) using key credentials, there is no <c>PlatformPrincipal</c>.
        /// The <c>PlatformCredential</c> is <c>API key</c>.</para></li><li><para>For GCM (Firebase Cloud Messaging) using token credentials, there is no <c>PlatformPrincipal</c>.
        /// The <c>PlatformCredential</c> is a JSON formatted private key file. When using the
        /// Amazon Web Services CLI, the file must be in string format and special characters
        /// must be ignored. To format the file correctly, Amazon SNS recommends using the following
        /// command: <c>SERVICE_JSON=`jq @json &lt;&lt;&lt; cat service.json`</c>.</para></li></ul></li></ul><ul><li><para><c>PlatformPrincipal</c> – The principal received from the notification service.</para><ul><li><para>For ADM, <c>PlatformPrincipal</c>is client id.</para></li><li><para>For Apple Services using certificate credentials, <c>PlatformPrincipal</c> is SSL
        /// certificate.</para></li><li><para>For Apple Services using token credentials, <c>PlatformPrincipal</c> is signing key
        /// ID.</para></li><li><para>For GCM (Firebase Cloud Messaging), there is no <c>PlatformPrincipal</c>. </para></li></ul></li></ul><ul><li><para><c>EventEndpointCreated</c> – Topic ARN to which <c>EndpointCreated</c> event notifications
        /// are sent.</para></li><li><para><c>EventEndpointDeleted</c> – Topic ARN to which <c>EndpointDeleted</c> event notifications
        /// are sent.</para></li><li><para><c>EventEndpointUpdated</c> – Topic ARN to which <c>EndpointUpdate</c> event notifications
        /// are sent.</para></li><li><para><c>EventDeliveryFailure</c> – Topic ARN to which <c>DeliveryFailure</c> event notifications
        /// are sent upon Direct Publish delivery failure (permanent) to one of the application's
        /// endpoints.</para></li><li><para><c>SuccessFeedbackRoleArn</c> – IAM role ARN used to give Amazon SNS write access
        /// to use CloudWatch Logs on your behalf.</para></li><li><para><c>FailureFeedbackRoleArn</c> – IAM role ARN used to give Amazon SNS write access
        /// to use CloudWatch Logs on your behalf.</para></li><li><para><c>SuccessFeedbackSampleRate</c> – Sample rate percentage (0-100) of successfully
        /// delivered messages.</para></li></ul><para>The following attributes only apply to <c>APNs</c> token-based authentication:</para><ul><li><para><c>ApplePlatformTeamID</c> – The identifier that's assigned to your Apple developer
        /// account team.</para></li><li><para><c>ApplePlatformBundleID</c> – The bundle identifier that's assigned to your iOS
        /// app.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter PlatformApplicationArn
        /// <summary>
        /// <para>
        /// <para><c>PlatformApplicationArn</c> for <c>SetPlatformApplicationAttributes</c> action.</para>
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
        public System.String PlatformApplicationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PlatformApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SNSPlatformApplicationAttribute (SetPlatformApplicationAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse, SetSNSPlatformApplicationAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlatformApplicationArn = this.PlatformApplicationArn;
            #if MODULAR
            if (this.PlatformApplicationArn == null && ParameterWasBound(nameof(this.PlatformApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PlatformApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.PlatformApplicationArn != null)
            {
                request.PlatformApplicationArn = cmdletContext.PlatformApplicationArn;
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
        
        private Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "SetPlatformApplicationAttributes");
            try
            {
                return client.SetPlatformApplicationAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String PlatformApplicationArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse, SetSNSPlatformApplicationAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
