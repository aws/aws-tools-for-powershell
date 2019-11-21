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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Updates an existing room profile by room profile ARN.
    /// </summary>
    [Cmdlet("Update", "ALXBProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Alexa For Business UpdateProfile API operation.", Operation = new[] {"UpdateProfile"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.UpdateProfileResponse))]
    [AWSCmdletOutput("None or Amazon.AlexaForBusiness.Model.UpdateProfileResponse",
        "This cmdlet does not generate any output." +
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>The updated distance unit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.DistanceUnit")]
        public Amazon.AlexaForBusiness.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter IsDefault
        /// <summary>
        /// <para>
        /// <para>Sets the profile as default if selected. If this is missing, no update is done to
        /// the default status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsDefault { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The updated locale for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter MaxVolumeLimit
        /// <summary>
        /// <para>
        /// <para>The updated maximum volume limit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxVolumeLimit { get; set; }
        #endregion
        
        #region Parameter ProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the room profile to update. Required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PSTNEnabled
        /// <summary>
        /// <para>
        /// <para>Whether the PSTN setting of the room profile is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PSTNEnabled { get; set; }
        #endregion
        
        #region Parameter SetupModeDisabled
        /// <summary>
        /// <para>
        /// <para>Whether the setup mode of the profile is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SetupModeDisabled { get; set; }
        #endregion
        
        #region Parameter TemperatureUnit
        /// <summary>
        /// <para>
        /// <para>The updated temperature unit for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.TemperatureUnit")]
        public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The updated timezone for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter WakeWord
        /// <summary>
        /// <para>
        /// <para>The updated wake word for the room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.WakeWord")]
        public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.UpdateProfileResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ALXBProfile (UpdateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.UpdateProfileResponse, UpdateALXBProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Address = this.Address;
            context.DistanceUnit = this.DistanceUnit;
            context.IsDefault = this.IsDefault;
            context.Locale = this.Locale;
            context.MaxVolumeLimit = this.MaxVolumeLimit;
            context.ProfileArn = this.ProfileArn;
            context.Name = this.Name;
            context.PSTNEnabled = this.PSTNEnabled;
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
            if (cmdletContext.IsDefault != null)
            {
                request.IsDefault = cmdletContext.IsDefault.Value;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
        
        private Amazon.AlexaForBusiness.Model.UpdateProfileResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.UpdateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "UpdateProfile");
            try
            {
                #if DESKTOP
                return client.UpdateProfile(request);
                #elif CORECLR
                return client.UpdateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IsDefault { get; set; }
            public System.String Locale { get; set; }
            public System.Int32? MaxVolumeLimit { get; set; }
            public System.String ProfileArn { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PSTNEnabled { get; set; }
            public System.Boolean? SetupModeDisabled { get; set; }
            public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
            public System.String Timezone { get; set; }
            public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.UpdateProfileResponse, UpdateALXBProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
