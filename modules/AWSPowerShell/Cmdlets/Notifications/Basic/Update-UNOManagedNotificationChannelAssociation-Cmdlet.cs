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
using Amazon.Notifications;
using Amazon.Notifications.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Updates the <c>isSensitiveEventsSubscribed</c> property of a particular ManagedNotification
    /// channel association.
    /// </summary>
    [Cmdlet("Update", "UNOManagedNotificationChannelAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS User Notifications UpdateManagedNotificationChannelAssociation API operation.", Operation = new[] {"UpdateManagedNotificationChannelAssociation"}, SelectReturnType = typeof(Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse))]
    [AWSCmdletOutput("None or Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateUNOManagedNotificationChannelAssociationCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the channel association to update. You can specify one of the following:</para><ul><li><para>An Account contact identifier.</para></li><li><para>A Channel ARN.</para></li></ul>
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
        public System.String ChannelIdentifier { get; set; }
        #endregion
        
        #region Parameter IsSensitiveEventsSubscribed
        /// <summary>
        /// <para>
        /// <para>Specifies whether the association is subscribed to sensitive events. The <c>notifications:SubscribeSensitiveEvents</c>
        /// permission controls access to sensitive events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsSensitiveEventsSubscribed { get; set; }
        #endregion
        
        #region Parameter ManagedNotificationConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <c>ManagedNotificationConfiguration</c> whose
        /// Channel association property you want to update.</para>
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
        public System.String ManagedNotificationConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ManagedNotificationConfigurationArn),
                nameof(this.ChannelIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-UNOManagedNotificationChannelAssociation (UpdateManagedNotificationChannelAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse, UpdateUNOManagedNotificationChannelAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelIdentifier = this.ChannelIdentifier;
            #if MODULAR
            if (this.ChannelIdentifier == null && ParameterWasBound(nameof(this.ChannelIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsSensitiveEventsSubscribed = this.IsSensitiveEventsSubscribed;
            context.ManagedNotificationConfigurationArn = this.ManagedNotificationConfigurationArn;
            #if MODULAR
            if (this.ManagedNotificationConfigurationArn == null && ParameterWasBound(nameof(this.ManagedNotificationConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedNotificationConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationRequest();
            
            if (cmdletContext.ChannelIdentifier != null)
            {
                request.ChannelIdentifier = cmdletContext.ChannelIdentifier;
            }
            if (cmdletContext.IsSensitiveEventsSubscribed != null)
            {
                request.IsSensitiveEventsSubscribed = cmdletContext.IsSensitiveEventsSubscribed.Value;
            }
            if (cmdletContext.ManagedNotificationConfigurationArn != null)
            {
                request.ManagedNotificationConfigurationArn = cmdletContext.ManagedNotificationConfigurationArn;
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
        
        private Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "UpdateManagedNotificationChannelAssociation");
            try
            {
                return client.UpdateManagedNotificationChannelAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelIdentifier { get; set; }
            public System.Boolean? IsSensitiveEventsSubscribed { get; set; }
            public System.String ManagedNotificationConfigurationArn { get; set; }
            public System.Func<Amazon.Notifications.Model.UpdateManagedNotificationChannelAssociationResponse, UpdateUNOManagedNotificationChannelAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
