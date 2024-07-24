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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Updates the configuration of an existing origination phone number. You can update
    /// the opt-out list, enable or disable two-way messaging, change the TwoWayChannelArn,
    /// enable or disable self-managed opt-outs, and enable or disable deletion protection.
    /// 
    ///  
    /// <para>
    /// If the origination phone number is associated with a pool, an error is returned.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMSVPhoneNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 UpdatePhoneNumber API operation.", Operation = new[] {"UpdatePhoneNumber"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMSVPhoneNumberCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true the phone number can't be deleted.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter OptOutListName
        /// <summary>
        /// <para>
        /// <para>The OptOutList to add the phone number to. Valid values for this field can be either
        /// the OutOutListName or OutOutListArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptOutListName { get; set; }
        #endregion
        
        #region Parameter PhoneNumberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the phone number. Valid values for this field can be either
        /// the PhoneNumberId or PhoneNumberArn.</para>
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
        public System.String PhoneNumberId { get; set; }
        #endregion
        
        #region Parameter SelfManagedOptOutsEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When an end recipient sends a message that begins
        /// with HELP or STOP to one of your dedicated numbers, AWS End User Messaging SMS and
        /// Voice automatically replies with a customizable message and adds the end recipient
        /// to the OptOutList. When set to true you're responsible for responding to HELP and
        /// STOP requests. You're also responsible for tracking and honoring opt-out requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SelfManagedOptOutsEnabled { get; set; }
        #endregion
        
        #region Parameter TwoWayChannelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the two way channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayChannelArn { get; set; }
        #endregion
        
        #region Parameter TwoWayChannelRole
        /// <summary>
        /// <para>
        /// <para>An optional IAM Role Arn for a service to assume, to be able to post inbound SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayChannelRole { get; set; }
        #endregion
        
        #region Parameter TwoWayEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true you can receive incoming text messages
        /// from your end recipients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TwoWayEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PhoneNumberId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PhoneNumberId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PhoneNumberId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PhoneNumberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSVPhoneNumber (UpdatePhoneNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse, UpdateSMSVPhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PhoneNumberId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.OptOutListName = this.OptOutListName;
            context.PhoneNumberId = this.PhoneNumberId;
            #if MODULAR
            if (this.PhoneNumberId == null && ParameterWasBound(nameof(this.PhoneNumberId)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelfManagedOptOutsEnabled = this.SelfManagedOptOutsEnabled;
            context.TwoWayChannelArn = this.TwoWayChannelArn;
            context.TwoWayChannelRole = this.TwoWayChannelRole;
            context.TwoWayEnabled = this.TwoWayEnabled;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberRequest();
            
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.OptOutListName != null)
            {
                request.OptOutListName = cmdletContext.OptOutListName;
            }
            if (cmdletContext.PhoneNumberId != null)
            {
                request.PhoneNumberId = cmdletContext.PhoneNumberId;
            }
            if (cmdletContext.SelfManagedOptOutsEnabled != null)
            {
                request.SelfManagedOptOutsEnabled = cmdletContext.SelfManagedOptOutsEnabled.Value;
            }
            if (cmdletContext.TwoWayChannelArn != null)
            {
                request.TwoWayChannelArn = cmdletContext.TwoWayChannelArn;
            }
            if (cmdletContext.TwoWayChannelRole != null)
            {
                request.TwoWayChannelRole = cmdletContext.TwoWayChannelRole;
            }
            if (cmdletContext.TwoWayEnabled != null)
            {
                request.TwoWayEnabled = cmdletContext.TwoWayEnabled.Value;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "UpdatePhoneNumber");
            try
            {
                #if DESKTOP
                return client.UpdatePhoneNumber(request);
                #elif CORECLR
                return client.UpdatePhoneNumberAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.String OptOutListName { get; set; }
            public System.String PhoneNumberId { get; set; }
            public System.Boolean? SelfManagedOptOutsEnabled { get; set; }
            public System.String TwoWayChannelArn { get; set; }
            public System.String TwoWayChannelRole { get; set; }
            public System.Boolean? TwoWayEnabled { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.UpdatePhoneNumberResponse, UpdateSMSVPhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
