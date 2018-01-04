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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Updates an existing room profile by room profile ARN.
    /// </summary>
    [Cmdlet("Update", "ALXBProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Alexa For Business UpdateProfile API operation.", Operation = new[] {"UpdateProfile"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Name parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AlexaForBusiness.Model.UpdateProfileResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateALXBProfileCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>The updated address for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Address { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>The updated distance unit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.DistanceUnit")]
        public Amazon.AlexaForBusiness.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter MaxVolumeLimit
        /// <summary>
        /// <para>
        /// <para>The updated maximum volume limit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxVolumeLimit { get; set; }
        #endregion
        
        #region Parameter ProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the room profile to update. Required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProfileArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PSTNEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the PSTN setting of the room profile is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PSTNEnabled { get; set; }
        #endregion
        
        #region Parameter SetupModeDisabled
        /// <summary>
        /// <para>
        /// <para>Whether the setup mode of the profile is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SetupModeDisabled { get; set; }
        #endregion
        
        #region Parameter TemperatureUnit
        /// <summary>
        /// <para>
        /// <para>The updated temperature unit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.TemperatureUnit")]
        public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The updated timezone for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter WakeWord
        /// <summary>
        /// <para>
        /// <para>The updated wake word for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.WakeWord")]
        public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Name parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ALXBProfile (UpdateProfile)"))
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
            
            context.Address = this.Address;
            context.DistanceUnit = this.DistanceUnit;
            if (ParameterWasBound("MaxVolumeLimit"))
                context.MaxVolumeLimit = this.MaxVolumeLimit;
            context.ProfileArn = this.ProfileArn;
            context.Name = this.Name;
            if (ParameterWasBound("PSTNEnabled"))
                context.PSTNEnabled = this.PSTNEnabled;
            if (ParameterWasBound("SetupModeDisabled"))
                context.SetupModeDisabled = this.SetupModeDisabled;
            context.TemperatureUnit = this.TemperatureUnit;
            context.Timezone = this.Timezone;
            context.WakeWord = this.WakeWord;
            
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
            var request = new Amazon.AlexaForBusiness.Model.UpdateProfileRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Address = cmdletContext.Address;
            }
            if (cmdletContext.DistanceUnit != null)
            {
                request.DistanceUnit = cmdletContext.DistanceUnit;
            }
            if (cmdletContext.MaxVolumeLimit != null)
            {
                request.MaxVolumeLimit = cmdletContext.MaxVolumeLimit.Value;
            }
            if (cmdletContext.ProfileArn != null)
            {
                request.ProfileArn = cmdletContext.ProfileArn;
            }
            if (cmdletContext.Name != null)
            {
                request.ProfileName = cmdletContext.Name;
            }
            if (cmdletContext.PSTNEnabled != null)
            {
                request.PSTNEnabled = cmdletContext.PSTNEnabled.Value;
            }
            if (cmdletContext.SetupModeDisabled != null)
            {
                request.SetupModeDisabled = cmdletContext.SetupModeDisabled.Value;
            }
            if (cmdletContext.TemperatureUnit != null)
            {
                request.TemperatureUnit = cmdletContext.TemperatureUnit;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
            }
            if (cmdletContext.WakeWord != null)
            {
                request.WakeWord = cmdletContext.WakeWord;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Name;
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
        
        private Amazon.AlexaForBusiness.Model.UpdateProfileResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.UpdateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "UpdateProfile");
            try
            {
                #if DESKTOP
                return client.UpdateProfile(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateProfileAsync(request);
                return task.Result;
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
            public System.String Address { get; set; }
            public Amazon.AlexaForBusiness.DistanceUnit DistanceUnit { get; set; }
            public System.Int32? MaxVolumeLimit { get; set; }
            public System.String ProfileArn { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PSTNEnabled { get; set; }
            public System.Boolean? SetupModeDisabled { get; set; }
            public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
            public System.String Timezone { get; set; }
            public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
        }
        
    }
}
