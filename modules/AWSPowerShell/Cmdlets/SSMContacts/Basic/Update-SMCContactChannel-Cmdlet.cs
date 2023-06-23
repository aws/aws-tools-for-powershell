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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Updates a contact's contact channel.
    /// </summary>
    [Cmdlet("Update", "SMCContactChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts UpdateContactChannel API operation.", Operation = new[] {"UpdateContactChannel"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.UpdateContactChannelResponse))]
    [AWSCmdletOutput("None or Amazon.SSMContacts.Model.UpdateContactChannelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMContacts.Model.UpdateContactChannelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMCContactChannelCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        #region Parameter ContactChannelId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the contact channel you want to update.</para>
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
        public System.String ContactChannelId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the contact channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DeliveryAddress_SimpleAddress
        /// <summary>
        /// <para>
        /// <para>The format is dependent on the type of the contact channel. The following are the
        /// expected formats:</para><ul><li><para>SMS - '+' followed by the country code and phone number</para></li><li><para>VOICE - '+' followed by the country code and phone number</para></li><li><para>EMAIL - any standard email format</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryAddress_SimpleAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.UpdateContactChannelResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactChannelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactChannelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactChannelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMCContactChannel (UpdateContactChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.UpdateContactChannelResponse, UpdateSMCContactChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactChannelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactChannelId = this.ContactChannelId;
            #if MODULAR
            if (this.ContactChannelId == null && ParameterWasBound(nameof(this.ContactChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryAddress_SimpleAddress = this.DeliveryAddress_SimpleAddress;
            context.Name = this.Name;
            
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
            var request = new Amazon.SSMContacts.Model.UpdateContactChannelRequest();
            
            if (cmdletContext.ContactChannelId != null)
            {
                request.ContactChannelId = cmdletContext.ContactChannelId;
            }
            
             // populate DeliveryAddress
            var requestDeliveryAddressIsNull = true;
            request.DeliveryAddress = new Amazon.SSMContacts.Model.ContactChannelAddress();
            System.String requestDeliveryAddress_deliveryAddress_SimpleAddress = null;
            if (cmdletContext.DeliveryAddress_SimpleAddress != null)
            {
                requestDeliveryAddress_deliveryAddress_SimpleAddress = cmdletContext.DeliveryAddress_SimpleAddress;
            }
            if (requestDeliveryAddress_deliveryAddress_SimpleAddress != null)
            {
                request.DeliveryAddress.SimpleAddress = requestDeliveryAddress_deliveryAddress_SimpleAddress;
                requestDeliveryAddressIsNull = false;
            }
             // determine if request.DeliveryAddress should be set to null
            if (requestDeliveryAddressIsNull)
            {
                request.DeliveryAddress = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SSMContacts.Model.UpdateContactChannelResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.UpdateContactChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "UpdateContactChannel");
            try
            {
                #if DESKTOP
                return client.UpdateContactChannel(request);
                #elif CORECLR
                return client.UpdateContactChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ContactChannelId { get; set; }
            public System.String DeliveryAddress_SimpleAddress { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.SSMContacts.Model.UpdateContactChannelResponse, UpdateSMCContactChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
