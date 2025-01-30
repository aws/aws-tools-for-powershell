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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Add an event destination to log event data from WhatsApp for a WhatsApp Business Account
    /// (WABA). A WABA can only have one event destination at a time. All resources associated
    /// with the WABA use the same event destination.
    /// </summary>
    [Cmdlet("Write", "SOCIALWhatsAppBusinessAccountEventDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS End User Messaging Social PutWhatsAppBusinessAccountEventDestinations API operation.", Operation = new[] {"PutWhatsAppBusinessAccountEventDestinations"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse))]
    [AWSCmdletOutput("None or Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSOCIALWhatsAppBusinessAccountEventDestinationCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventDestination
        /// <summary>
        /// <para>
        /// <para>An array of <c>WhatsAppBusinessAccountEventDestination</c> event destinations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EventDestinations")]
        public Amazon.SocialMessaging.Model.WhatsAppBusinessAccountEventDestination[] EventDestination { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of your WhatsApp Business Account. WABA identifiers are formatted
        /// as <c>waba-01234567890123456789012345678901</c>. Use <a href="https://docs.aws.amazon.com/social-messaging/latest/APIReference/API_ListLinkedWhatsAppBusinessAccounts.html">ListLinkedWhatsAppBusinessAccounts</a>
        /// to list all WABAs and their details.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SOCIALWhatsAppBusinessAccountEventDestination (PutWhatsAppBusinessAccountEventDestinations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse, WriteSOCIALWhatsAppBusinessAccountEventDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EventDestination != null)
            {
                context.EventDestination = new List<Amazon.SocialMessaging.Model.WhatsAppBusinessAccountEventDestination>(this.EventDestination);
            }
            #if MODULAR
            if (this.EventDestination == null && ParameterWasBound(nameof(this.EventDestination)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDestination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsRequest();
            
            if (cmdletContext.EventDestination != null)
            {
                request.EventDestinations = cmdletContext.EventDestination;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "PutWhatsAppBusinessAccountEventDestinations");
            try
            {
                #if DESKTOP
                return client.PutWhatsAppBusinessAccountEventDestinations(request);
                #elif CORECLR
                return client.PutWhatsAppBusinessAccountEventDestinationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SocialMessaging.Model.WhatsAppBusinessAccountEventDestination> EventDestination { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.PutWhatsAppBusinessAccountEventDestinationsResponse, WriteSOCIALWhatsAppBusinessAccountEventDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
