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
    /// Adds termination settings for the specified Amazon Chime Voice Connector.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorTermination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.Termination")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorTermination API operation.", Operation = new[] {"PutVoiceConnectorTermination"})]
    [AWSCmdletOutput("Amazon.Chime.Model.Termination",
        "This cmdlet returns a Termination object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorTerminationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCHMVoiceConnectorTerminationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter Termination_CallingRegion
        /// <summary>
        /// <para>
        /// <para>The countries to which calls are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Termination_CallingRegions")]
        public System.String[] Termination_CallingRegion { get; set; }
        #endregion
        
        #region Parameter Termination_CidrAllowedList
        /// <summary>
        /// <para>
        /// <para>The IP addresses allowed to make calls, in CIDR format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Termination_CidrAllowedList { get; set; }
        #endregion
        
        #region Parameter Termination_CpsLimit
        /// <summary>
        /// <para>
        /// <para>The limit on calls per second. Max value based on account service limit. Default value
        /// of 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Termination_CpsLimit { get; set; }
        #endregion
        
        #region Parameter Termination_DefaultPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The default caller ID phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Termination_DefaultPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Termination_Disabled
        /// <summary>
        /// <para>
        /// <para>When termination settings are disabled, outbound calls can not be made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Termination_Disabled { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorTermination (PutVoiceConnectorTermination)"))
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
            
            if (this.Termination_CallingRegion != null)
            {
                context.Termination_CallingRegions = new List<System.String>(this.Termination_CallingRegion);
            }
            if (this.Termination_CidrAllowedList != null)
            {
                context.Termination_CidrAllowedList = new List<System.String>(this.Termination_CidrAllowedList);
            }
            if (ParameterWasBound("Termination_CpsLimit"))
                context.Termination_CpsLimit = this.Termination_CpsLimit;
            context.Termination_DefaultPhoneNumber = this.Termination_DefaultPhoneNumber;
            if (ParameterWasBound("Termination_Disabled"))
                context.Termination_Disabled = this.Termination_Disabled;
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorTerminationRequest();
            
            
             // populate Termination
            bool requestTerminationIsNull = true;
            request.Termination = new Amazon.Chime.Model.Termination();
            List<System.String> requestTermination_termination_CallingRegion = null;
            if (cmdletContext.Termination_CallingRegions != null)
            {
                requestTermination_termination_CallingRegion = cmdletContext.Termination_CallingRegions;
            }
            if (requestTermination_termination_CallingRegion != null)
            {
                request.Termination.CallingRegions = requestTermination_termination_CallingRegion;
                requestTerminationIsNull = false;
            }
            List<System.String> requestTermination_termination_CidrAllowedList = null;
            if (cmdletContext.Termination_CidrAllowedList != null)
            {
                requestTermination_termination_CidrAllowedList = cmdletContext.Termination_CidrAllowedList;
            }
            if (requestTermination_termination_CidrAllowedList != null)
            {
                request.Termination.CidrAllowedList = requestTermination_termination_CidrAllowedList;
                requestTerminationIsNull = false;
            }
            System.Int32? requestTermination_termination_CpsLimit = null;
            if (cmdletContext.Termination_CpsLimit != null)
            {
                requestTermination_termination_CpsLimit = cmdletContext.Termination_CpsLimit.Value;
            }
            if (requestTermination_termination_CpsLimit != null)
            {
                request.Termination.CpsLimit = requestTermination_termination_CpsLimit.Value;
                requestTerminationIsNull = false;
            }
            System.String requestTermination_termination_DefaultPhoneNumber = null;
            if (cmdletContext.Termination_DefaultPhoneNumber != null)
            {
                requestTermination_termination_DefaultPhoneNumber = cmdletContext.Termination_DefaultPhoneNumber;
            }
            if (requestTermination_termination_DefaultPhoneNumber != null)
            {
                request.Termination.DefaultPhoneNumber = requestTermination_termination_DefaultPhoneNumber;
                requestTerminationIsNull = false;
            }
            System.Boolean? requestTermination_termination_Disabled = null;
            if (cmdletContext.Termination_Disabled != null)
            {
                requestTermination_termination_Disabled = cmdletContext.Termination_Disabled.Value;
            }
            if (requestTermination_termination_Disabled != null)
            {
                request.Termination.Disabled = requestTermination_termination_Disabled.Value;
                requestTerminationIsNull = false;
            }
             // determine if request.Termination should be set to null
            if (requestTerminationIsNull)
            {
                request.Termination = null;
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
                object pipelineOutput = response.Termination;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorTerminationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorTerminationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorTermination");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorTermination(request);
                #elif CORECLR
                return client.PutVoiceConnectorTerminationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Termination_CallingRegions { get; set; }
            public List<System.String> Termination_CidrAllowedList { get; set; }
            public System.Int32? Termination_CpsLimit { get; set; }
            public System.String Termination_DefaultPhoneNumber { get; set; }
            public System.Boolean? Termination_Disabled { get; set; }
            public System.String VoiceConnectorId { get; set; }
        }
        
    }
}
