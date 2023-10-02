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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates a playback configuration. For information about MediaTailor configurations,
    /// see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/configurations.html">Working
    /// with configurations in AWS Elemental MediaTailor</a>.
    /// </summary>
    [Cmdlet("Set", "EMTPlaybackConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor PutPlaybackConfiguration API operation.", Operation = new[] {"PutPlaybackConfiguration"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEMTPlaybackConfigurationCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdDecisionServerUrl
        /// <summary>
        /// <para>
        /// <para>The URL for the ad decision server (ADS). This includes the specification of static
        /// parameters and placeholders for dynamic parameters. AWS Elemental MediaTailor substitutes
        /// player-specific and session-specific parameters as needed when calling the ADS. Alternately,
        /// for testing you can provide a static VAST URL. The maximum length is 25,000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdDecisionServerUrl { get; set; }
        #endregion
        
        #region Parameter LivePreRollConfiguration_AdDecisionServerUrl
        /// <summary>
        /// <para>
        /// <para>The URL for the ad decision server (ADS) for pre-roll ads. This includes the specification
        /// of static parameters and placeholders for dynamic parameters. AWS Elemental MediaTailor
        /// substitutes player-specific and session-specific parameters as needed when calling
        /// the ADS. Alternately, for testing, you can provide a static VAST URL. The maximum
        /// length is 25,000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LivePreRollConfiguration_AdDecisionServerUrl { get; set; }
        #endregion
        
        #region Parameter CdnConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for using a content delivery network (CDN), like Amazon CloudFront,
        /// for content and ad segment management.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaTailor.Model.CdnConfiguration CdnConfiguration { get; set; }
        #endregion
        
        #region Parameter ConfigurationAlias
        /// <summary>
        /// <para>
        /// <para>The player parameters and aliases used as dynamic variables during session initialization.
        /// For more information, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/variables-domain.html">Domain
        /// Variables</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationAliases")]
        public System.Collections.Hashtable ConfigurationAlias { get; set; }
        #endregion
        
        #region Parameter DashConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for DASH content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaTailor.Model.DashConfigurationForPut DashConfiguration { get; set; }
        #endregion
        
        #region Parameter AdMarkerPassthrough_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables ad marker passthrough for your configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestProcessingRules_AdMarkerPassthrough_Enabled")]
        public System.Boolean? AdMarkerPassthrough_Enabled { get; set; }
        #endregion
        
        #region Parameter Bumper_EndUrl
        /// <summary>
        /// <para>
        /// <para>The URL for the end bumper asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Bumper_EndUrl { get; set; }
        #endregion
        
        #region Parameter AvailSuppression_FillPolicy
        /// <summary>
        /// <para>
        /// <para>Defines the policy to apply to the avail suppression mode. <code>BEHIND_LIVE_EDGE</code>
        /// will always use the full avail suppression policy. <code>AFTER_LIVE_EDGE</code> mode
        /// can be used to invoke partial ad break fills when a session starts mid-break.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.FillPolicy")]
        public Amazon.MediaTailor.FillPolicy AvailSuppression_FillPolicy { get; set; }
        #endregion
        
        #region Parameter LivePreRollConfiguration_MaxDurationSecond
        /// <summary>
        /// <para>
        /// <para>The maximum allowed duration for the pre-roll ad avail. AWS Elemental MediaTailor
        /// won't play pre-roll ads to exceed this duration, regardless of the total duration
        /// of ads that the ADS returns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LivePreRollConfiguration_MaxDurationSeconds")]
        public System.Int32? LivePreRollConfiguration_MaxDurationSecond { get; set; }
        #endregion
        
        #region Parameter AvailSuppression_Mode
        /// <summary>
        /// <para>
        /// <para>Sets the ad suppression mode. By default, ad suppression is off and all ad breaks
        /// are filled with ads or slate. When Mode is set to <code>BEHIND_LIVE_EDGE</code>, ad
        /// suppression is active and MediaTailor won't fill ad breaks on or behind the ad suppression
        /// Value time in the manifest lookback window. When Mode is set to <code>AFTER_LIVE_EDGE</code>,
        /// ad suppression is active and MediaTailor won't fill ad breaks that are within the
        /// live edge plus the avail suppression value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.Mode")]
        public Amazon.MediaTailor.Mode AvailSuppression_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The identifier for the playback configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PersonalizationThresholdSecond
        /// <summary>
        /// <para>
        /// <para>Defines the maximum duration of underfilled ad time (in seconds) allowed in an ad
        /// break. If the duration of underfilled ad time exceeds the personalization threshold,
        /// then the personalization of the ad break is abandoned and the underlying content is
        /// shown. This feature applies to <i>ad replacement</i> in live and VOD streams, rather
        /// than ad insertion, because it relies on an underlying content stream. For more information
        /// about ad break behavior, including ad replacement and insertion, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/ad-behavior.html">Ad
        /// Behavior in AWS Elemental MediaTailor</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PersonalizationThresholdSeconds")]
        public System.Int32? PersonalizationThresholdSecond { get; set; }
        #endregion
        
        #region Parameter SlateAdUrl
        /// <summary>
        /// <para>
        /// <para>The URL for a high-quality video asset to transcode and use to fill in time that's
        /// not used by ads. AWS Elemental MediaTailor shows the slate to fill in gaps in media
        /// content. Configuring the slate is optional for non-VPAID configurations. For VPAID,
        /// the slate is required because MediaTailor provides it in the slots that are designated
        /// for dynamic ad content. The slate must be a high-quality asset that contains both
        /// audio and video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SlateAdUrl { get; set; }
        #endregion
        
        #region Parameter Bumper_StartUrl
        /// <summary>
        /// <para>
        /// <para>The URL for the start bumper asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Bumper_StartUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the playback configuration. Tags are key-value pairs that you
        /// can associate with Amazon resources to help with organization, access control, and
        /// cost tracking. For more information, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/tagging.html">Tagging
        /// AWS Elemental MediaTailor Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TranscodeProfileName
        /// <summary>
        /// <para>
        /// <para>The name that is used to associate this playback configuration with a custom transcode
        /// profile. This overrides the dynamic transcoding defaults of MediaTailor. Use this
        /// only if you have already set up custom profiles with the help of AWS Support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TranscodeProfileName { get; set; }
        #endregion
        
        #region Parameter AvailSuppression_Value
        /// <summary>
        /// <para>
        /// <para>A live edge offset time in HH:MM:SS. MediaTailor won't fill ad breaks on or behind
        /// this time in the manifest lookback window. If Value is set to 00:00:00, it is in sync
        /// with the live edge, and MediaTailor won't fill any ad breaks on or behind the live
        /// edge. If you set a Value time, MediaTailor won't fill any ad breaks on or behind this
        /// time in the manifest lookback window. For example, if you set 00:45:00, then MediaTailor
        /// will fill ad breaks that occur within 45 minutes behind the live edge, but won't fill
        /// ad breaks on or behind 45 minutes behind the live edge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailSuppression_Value { get; set; }
        #endregion
        
        #region Parameter VideoContentSourceUrl
        /// <summary>
        /// <para>
        /// <para>The URL prefix for the parent manifest for the stream, minus the asset ID. The maximum
        /// length is 512 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VideoContentSourceUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EMTPlaybackConfiguration (PutPlaybackConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse, SetEMTPlaybackConfigurationCmdlet>(Select) ??
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
            context.AdDecisionServerUrl = this.AdDecisionServerUrl;
            context.AvailSuppression_FillPolicy = this.AvailSuppression_FillPolicy;
            context.AvailSuppression_Mode = this.AvailSuppression_Mode;
            context.AvailSuppression_Value = this.AvailSuppression_Value;
            context.Bumper_EndUrl = this.Bumper_EndUrl;
            context.Bumper_StartUrl = this.Bumper_StartUrl;
            context.CdnConfiguration = this.CdnConfiguration;
            if (this.ConfigurationAlias != null)
            {
                context.ConfigurationAlias = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ConfigurationAlias.Keys)
                {
                    context.ConfigurationAlias.Add((String)hashKey, (Dictionary<String,String>)(this.ConfigurationAlias[hashKey]));
                }
            }
            context.DashConfiguration = this.DashConfiguration;
            context.LivePreRollConfiguration_AdDecisionServerUrl = this.LivePreRollConfiguration_AdDecisionServerUrl;
            context.LivePreRollConfiguration_MaxDurationSecond = this.LivePreRollConfiguration_MaxDurationSecond;
            context.AdMarkerPassthrough_Enabled = this.AdMarkerPassthrough_Enabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersonalizationThresholdSecond = this.PersonalizationThresholdSecond;
            context.SlateAdUrl = this.SlateAdUrl;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.TranscodeProfileName = this.TranscodeProfileName;
            context.VideoContentSourceUrl = this.VideoContentSourceUrl;
            
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
            var request = new Amazon.MediaTailor.Model.PutPlaybackConfigurationRequest();
            
            if (cmdletContext.AdDecisionServerUrl != null)
            {
                request.AdDecisionServerUrl = cmdletContext.AdDecisionServerUrl;
            }
            
             // populate AvailSuppression
            var requestAvailSuppressionIsNull = true;
            request.AvailSuppression = new Amazon.MediaTailor.Model.AvailSuppression();
            Amazon.MediaTailor.FillPolicy requestAvailSuppression_availSuppression_FillPolicy = null;
            if (cmdletContext.AvailSuppression_FillPolicy != null)
            {
                requestAvailSuppression_availSuppression_FillPolicy = cmdletContext.AvailSuppression_FillPolicy;
            }
            if (requestAvailSuppression_availSuppression_FillPolicy != null)
            {
                request.AvailSuppression.FillPolicy = requestAvailSuppression_availSuppression_FillPolicy;
                requestAvailSuppressionIsNull = false;
            }
            Amazon.MediaTailor.Mode requestAvailSuppression_availSuppression_Mode = null;
            if (cmdletContext.AvailSuppression_Mode != null)
            {
                requestAvailSuppression_availSuppression_Mode = cmdletContext.AvailSuppression_Mode;
            }
            if (requestAvailSuppression_availSuppression_Mode != null)
            {
                request.AvailSuppression.Mode = requestAvailSuppression_availSuppression_Mode;
                requestAvailSuppressionIsNull = false;
            }
            System.String requestAvailSuppression_availSuppression_Value = null;
            if (cmdletContext.AvailSuppression_Value != null)
            {
                requestAvailSuppression_availSuppression_Value = cmdletContext.AvailSuppression_Value;
            }
            if (requestAvailSuppression_availSuppression_Value != null)
            {
                request.AvailSuppression.Value = requestAvailSuppression_availSuppression_Value;
                requestAvailSuppressionIsNull = false;
            }
             // determine if request.AvailSuppression should be set to null
            if (requestAvailSuppressionIsNull)
            {
                request.AvailSuppression = null;
            }
            
             // populate Bumper
            var requestBumperIsNull = true;
            request.Bumper = new Amazon.MediaTailor.Model.Bumper();
            System.String requestBumper_bumper_EndUrl = null;
            if (cmdletContext.Bumper_EndUrl != null)
            {
                requestBumper_bumper_EndUrl = cmdletContext.Bumper_EndUrl;
            }
            if (requestBumper_bumper_EndUrl != null)
            {
                request.Bumper.EndUrl = requestBumper_bumper_EndUrl;
                requestBumperIsNull = false;
            }
            System.String requestBumper_bumper_StartUrl = null;
            if (cmdletContext.Bumper_StartUrl != null)
            {
                requestBumper_bumper_StartUrl = cmdletContext.Bumper_StartUrl;
            }
            if (requestBumper_bumper_StartUrl != null)
            {
                request.Bumper.StartUrl = requestBumper_bumper_StartUrl;
                requestBumperIsNull = false;
            }
             // determine if request.Bumper should be set to null
            if (requestBumperIsNull)
            {
                request.Bumper = null;
            }
            if (cmdletContext.CdnConfiguration != null)
            {
                request.CdnConfiguration = cmdletContext.CdnConfiguration;
            }
            if (cmdletContext.ConfigurationAlias != null)
            {
                request.ConfigurationAliases = cmdletContext.ConfigurationAlias;
            }
            if (cmdletContext.DashConfiguration != null)
            {
                request.DashConfiguration = cmdletContext.DashConfiguration;
            }
            
             // populate LivePreRollConfiguration
            var requestLivePreRollConfigurationIsNull = true;
            request.LivePreRollConfiguration = new Amazon.MediaTailor.Model.LivePreRollConfiguration();
            System.String requestLivePreRollConfiguration_livePreRollConfiguration_AdDecisionServerUrl = null;
            if (cmdletContext.LivePreRollConfiguration_AdDecisionServerUrl != null)
            {
                requestLivePreRollConfiguration_livePreRollConfiguration_AdDecisionServerUrl = cmdletContext.LivePreRollConfiguration_AdDecisionServerUrl;
            }
            if (requestLivePreRollConfiguration_livePreRollConfiguration_AdDecisionServerUrl != null)
            {
                request.LivePreRollConfiguration.AdDecisionServerUrl = requestLivePreRollConfiguration_livePreRollConfiguration_AdDecisionServerUrl;
                requestLivePreRollConfigurationIsNull = false;
            }
            System.Int32? requestLivePreRollConfiguration_livePreRollConfiguration_MaxDurationSecond = null;
            if (cmdletContext.LivePreRollConfiguration_MaxDurationSecond != null)
            {
                requestLivePreRollConfiguration_livePreRollConfiguration_MaxDurationSecond = cmdletContext.LivePreRollConfiguration_MaxDurationSecond.Value;
            }
            if (requestLivePreRollConfiguration_livePreRollConfiguration_MaxDurationSecond != null)
            {
                request.LivePreRollConfiguration.MaxDurationSeconds = requestLivePreRollConfiguration_livePreRollConfiguration_MaxDurationSecond.Value;
                requestLivePreRollConfigurationIsNull = false;
            }
             // determine if request.LivePreRollConfiguration should be set to null
            if (requestLivePreRollConfigurationIsNull)
            {
                request.LivePreRollConfiguration = null;
            }
            
             // populate ManifestProcessingRules
            var requestManifestProcessingRulesIsNull = true;
            request.ManifestProcessingRules = new Amazon.MediaTailor.Model.ManifestProcessingRules();
            Amazon.MediaTailor.Model.AdMarkerPassthrough requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough = null;
            
             // populate AdMarkerPassthrough
            var requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthroughIsNull = true;
            requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough = new Amazon.MediaTailor.Model.AdMarkerPassthrough();
            System.Boolean? requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough_adMarkerPassthrough_Enabled = null;
            if (cmdletContext.AdMarkerPassthrough_Enabled != null)
            {
                requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough_adMarkerPassthrough_Enabled = cmdletContext.AdMarkerPassthrough_Enabled.Value;
            }
            if (requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough_adMarkerPassthrough_Enabled != null)
            {
                requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough.Enabled = requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough_adMarkerPassthrough_Enabled.Value;
                requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthroughIsNull = false;
            }
             // determine if requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough should be set to null
            if (requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthroughIsNull)
            {
                requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough = null;
            }
            if (requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough != null)
            {
                request.ManifestProcessingRules.AdMarkerPassthrough = requestManifestProcessingRules_manifestProcessingRules_AdMarkerPassthrough;
                requestManifestProcessingRulesIsNull = false;
            }
             // determine if request.ManifestProcessingRules should be set to null
            if (requestManifestProcessingRulesIsNull)
            {
                request.ManifestProcessingRules = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PersonalizationThresholdSecond != null)
            {
                request.PersonalizationThresholdSeconds = cmdletContext.PersonalizationThresholdSecond.Value;
            }
            if (cmdletContext.SlateAdUrl != null)
            {
                request.SlateAdUrl = cmdletContext.SlateAdUrl;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TranscodeProfileName != null)
            {
                request.TranscodeProfileName = cmdletContext.TranscodeProfileName;
            }
            if (cmdletContext.VideoContentSourceUrl != null)
            {
                request.VideoContentSourceUrl = cmdletContext.VideoContentSourceUrl;
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
        
        private Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.PutPlaybackConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "PutPlaybackConfiguration");
            try
            {
                #if DESKTOP
                return client.PutPlaybackConfiguration(request);
                #elif CORECLR
                return client.PutPlaybackConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AdDecisionServerUrl { get; set; }
            public Amazon.MediaTailor.FillPolicy AvailSuppression_FillPolicy { get; set; }
            public Amazon.MediaTailor.Mode AvailSuppression_Mode { get; set; }
            public System.String AvailSuppression_Value { get; set; }
            public System.String Bumper_EndUrl { get; set; }
            public System.String Bumper_StartUrl { get; set; }
            public Amazon.MediaTailor.Model.CdnConfiguration CdnConfiguration { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> ConfigurationAlias { get; set; }
            public Amazon.MediaTailor.Model.DashConfigurationForPut DashConfiguration { get; set; }
            public System.String LivePreRollConfiguration_AdDecisionServerUrl { get; set; }
            public System.Int32? LivePreRollConfiguration_MaxDurationSecond { get; set; }
            public System.Boolean? AdMarkerPassthrough_Enabled { get; set; }
            public System.String Name { get; set; }
            public System.Int32? PersonalizationThresholdSecond { get; set; }
            public System.String SlateAdUrl { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TranscodeProfileName { get; set; }
            public System.String VideoContentSourceUrl { get; set; }
            public System.Func<Amazon.MediaTailor.Model.PutPlaybackConfigurationResponse, SetEMTPlaybackConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
