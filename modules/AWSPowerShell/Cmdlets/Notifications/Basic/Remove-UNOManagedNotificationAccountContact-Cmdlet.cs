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

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Disassociates an Account Contact with a particular <c>ManagedNotificationConfiguration</c>.
    /// </summary>
    [Cmdlet("Remove", "UNOManagedNotificationAccountContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS User Notifications DisassociateManagedNotificationAccountContact API operation.", Operation = new[] {"DisassociateManagedNotificationAccountContact"}, SelectReturnType = typeof(Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse))]
    [AWSCmdletOutput("None or Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveUNOManagedNotificationAccountContactCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique value of an Account Contact Type to associate with the <c>ManagedNotificationConfiguration</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Notifications.AccountContactType")]
        public Amazon.Notifications.AccountContactType ContactIdentifier { get; set; }
        #endregion
        
        #region Parameter ManagedNotificationConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <c>ManagedNotificationConfiguration</c> to associate
        /// with the Account Contact.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-UNOManagedNotificationAccountContact (DisassociateManagedNotificationAccountContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse, RemoveUNOManagedNotificationAccountContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactIdentifier = this.ContactIdentifier;
            #if MODULAR
            if (this.ContactIdentifier == null && ParameterWasBound(nameof(this.ContactIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactRequest();
            
            if (cmdletContext.ContactIdentifier != null)
            {
                request.ContactIdentifier = cmdletContext.ContactIdentifier;
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
        
        private Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "DisassociateManagedNotificationAccountContact");
            try
            {
                return client.DisassociateManagedNotificationAccountContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Notifications.AccountContactType ContactIdentifier { get; set; }
            public System.String ManagedNotificationConfigurationArn { get; set; }
            public System.Func<Amazon.Notifications.Model.DisassociateManagedNotificationAccountContactResponse, RemoveUNOManagedNotificationAccountContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
