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
    /// Adds origination settings for the specified Amazon Chime Voice Connector.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorOrigination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.Origination")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorOrigination API operation.", Operation = new[] {"PutVoiceConnectorOrigination"})]
    [AWSCmdletOutput("Amazon.Chime.Model.Origination",
        "This cmdlet returns a Origination object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorOriginationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCHMVoiceConnectorOriginationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter Origination_Disabled
        /// <summary>
        /// <para>
        /// <para>When origination settings are disabled, inbound calls are not enabled for your Amazon
        /// Chime Voice Connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Origination_Disabled { get; set; }
        #endregion
        
        #region Parameter Origination_Route
        /// <summary>
        /// <para>
        /// <para>The call distribution properties defined for your SIP hosts. Valid range: Minimum
        /// value of 1. Maximum value of 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Origination_Routes")]
        public Amazon.Chime.Model.OriginationRoute[] Origination_Route { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorOrigination (PutVoiceConnectorOrigination)"))
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
            
            if (ParameterWasBound("Origination_Disabled"))
                context.Origination_Disabled = this.Origination_Disabled;
            if (this.Origination_Route != null)
            {
                context.Origination_Routes = new List<Amazon.Chime.Model.OriginationRoute>(this.Origination_Route);
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorOriginationRequest();
            
            
             // populate Origination
            bool requestOriginationIsNull = true;
            request.Origination = new Amazon.Chime.Model.Origination();
            System.Boolean? requestOrigination_origination_Disabled = null;
            if (cmdletContext.Origination_Disabled != null)
            {
                requestOrigination_origination_Disabled = cmdletContext.Origination_Disabled.Value;
            }
            if (requestOrigination_origination_Disabled != null)
            {
                request.Origination.Disabled = requestOrigination_origination_Disabled.Value;
                requestOriginationIsNull = false;
            }
            List<Amazon.Chime.Model.OriginationRoute> requestOrigination_origination_Route = null;
            if (cmdletContext.Origination_Routes != null)
            {
                requestOrigination_origination_Route = cmdletContext.Origination_Routes;
            }
            if (requestOrigination_origination_Route != null)
            {
                request.Origination.Routes = requestOrigination_origination_Route;
                requestOriginationIsNull = false;
            }
             // determine if request.Origination should be set to null
            if (requestOriginationIsNull)
            {
                request.Origination = null;
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
                object pipelineOutput = response.Origination;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorOriginationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorOriginationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorOrigination");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorOrigination(request);
                #elif CORECLR
                return client.PutVoiceConnectorOriginationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Origination_Disabled { get; set; }
            public List<Amazon.Chime.Model.OriginationRoute> Origination_Routes { get; set; }
            public System.String VoiceConnectorId { get; set; }
        }
        
    }
}
