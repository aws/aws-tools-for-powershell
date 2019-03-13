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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Disassociates the specified phone number from the specified Amazon Chime Voice Connector.
    /// </summary>
    [Cmdlet("Remove", "CHMPhoneNumbersFromVoiceConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Chime.Model.PhoneNumberError")]
    [AWSCmdlet("Calls the Amazon Chime DisassociatePhoneNumbersFromVoiceConnector API operation.", Operation = new[] {"DisassociatePhoneNumbersFromVoiceConnector"})]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberError",
        "This cmdlet returns a collection of PhoneNumberError objects.",
        "The service call response (type Amazon.Chime.Model.DisassociatePhoneNumbersFromVoiceConnectorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCHMPhoneNumbersFromVoiceConnectorCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter E164PhoneNumber
        /// <summary>
        /// <para>
        /// <para>List of phone numbers, in E.164 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("E164PhoneNumbers")]
        public System.String[] E164PhoneNumber { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime Voice Connector ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String VoiceConnectorId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VoiceConnectorId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CHMPhoneNumbersFromVoiceConnector (DisassociatePhoneNumbersFromVoiceConnector)"))
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
            
            if (this.E164PhoneNumber != null)
            {
                context.E164PhoneNumbers = new List<System.String>(this.E164PhoneNumber);
            }
            context.VoiceConnectorId = this.VoiceConnectorId;
            
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
            var request = new Amazon.Chime.Model.DisassociatePhoneNumbersFromVoiceConnectorRequest();
            
            if (cmdletContext.E164PhoneNumbers != null)
            {
                request.E164PhoneNumbers = cmdletContext.E164PhoneNumbers;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PhoneNumberErrors;
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
        
        private Amazon.Chime.Model.DisassociatePhoneNumbersFromVoiceConnectorResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.DisassociatePhoneNumbersFromVoiceConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "DisassociatePhoneNumbersFromVoiceConnector");
            try
            {
                #if DESKTOP
                return client.DisassociatePhoneNumbersFromVoiceConnector(request);
                #elif CORECLR
                return client.DisassociatePhoneNumbersFromVoiceConnectorAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> E164PhoneNumbers { get; set; }
            public System.String VoiceConnectorId { get; set; }
        }
        
    }
}
