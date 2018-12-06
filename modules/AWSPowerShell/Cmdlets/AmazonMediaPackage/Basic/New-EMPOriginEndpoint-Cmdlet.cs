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
using Amazon.MediaPackage;
using Amazon.MediaPackage.Model;

namespace Amazon.PowerShell.Cmdlets.EMP
{
    /// <summary>
    /// Creates a new OriginEndpoint record.
    /// </summary>
    [Cmdlet("New", "EMPOriginEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackage.Model.CreateOriginEndpointResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage CreateOriginEndpoint API operation.", Operation = new[] {"CreateOriginEndpoint"})]
    [AWSCmdletOutput("Amazon.MediaPackage.Model.CreateOriginEndpointResponse",
        "This cmdlet returns a Amazon.MediaPackage.Model.CreateOriginEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMPOriginEndpointCmdlet : AmazonMediaPackageClientCmdlet, IExecutor
    {
        
        #region Parameter SpekeKeyProvider_CertificateArn
        /// <summary>
        /// <para>
        /// An Amazon Resource Name (ARN) of a Certificate
        /// Manager certificatethat MediaPackage will use for enforcing secure end-to-end datatransfer
        /// with the key provider service.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_SpekeKeyProvider_CertificateArn")]
        public System.String SpekeKeyProvider_CertificateArn { get; set; }
        #endregion
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// The ID of the Channel that the OriginEndpoint
        /// will be associated with.This cannot be changed after the OriginEndpoint is created.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter DashPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.DashPackage DashPackage { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A short text description of the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CmafPackage_HlsManifest
        /// <summary>
        /// <para>
        /// A list of HLS manifest configurations
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_HlsManifests")]
        public Amazon.MediaPackage.Model.HlsManifestCreateOrUpdateParameters[] CmafPackage_HlsManifest { get; set; }
        #endregion
        
        #region Parameter HlsPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.HlsPackage HlsPackage { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The ID of the OriginEndpoint.  The ID must be unique
        /// within the regionand it cannot be changed after the OriginEndpoint is created.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Encryption_KeyRotationIntervalSecond
        /// <summary>
        /// <para>
        /// Time (in seconds) between each
        /// encryption key rotation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_KeyRotationIntervalSeconds")]
        public System.Int32 Encryption_KeyRotationIntervalSecond { get; set; }
        #endregion
        
        #region Parameter ManifestName
        /// <summary>
        /// <para>
        /// A short string that will be used as the filename
        /// of the OriginEndpoint URL (defaults to "index").
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ManifestName { get; set; }
        #endregion
        
        #region Parameter StreamSelection_MaxVideoBitsPerSecond
        /// <summary>
        /// <para>
        /// The maximum video bitrate (bps)
        /// to include in output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_StreamSelection_MaxVideoBitsPerSecond")]
        public System.Int32 StreamSelection_MaxVideoBitsPerSecond { get; set; }
        #endregion
        
        #region Parameter StreamSelection_MinVideoBitsPerSecond
        /// <summary>
        /// <para>
        /// The minimum video bitrate (bps)
        /// to include in output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_StreamSelection_MinVideoBitsPerSecond")]
        public System.Int32 StreamSelection_MinVideoBitsPerSecond { get; set; }
        #endregion
        
        #region Parameter MssPackage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaPackage.Model.MssPackage MssPackage { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_ResourceId
        /// <summary>
        /// <para>
        /// The resource ID to include in key requests.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_SpekeKeyProvider_ResourceId")]
        public System.String SpekeKeyProvider_ResourceId { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_RoleArn
        /// <summary>
        /// <para>
        /// An Amazon Resource Name (ARN) of an IAM role that
        /// AWS ElementalMediaPackage will assume when accessing the key provider service.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_SpekeKeyProvider_RoleArn")]
        public System.String SpekeKeyProvider_RoleArn { get; set; }
        #endregion
        
        #region Parameter CmafPackage_SegmentDurationSecond
        /// <summary>
        /// <para>
        /// Duration (in seconds) of each segment.
        /// Actual segments will berounded to the nearest multiple of the source segment duration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_SegmentDurationSeconds")]
        public System.Int32 CmafPackage_SegmentDurationSecond { get; set; }
        #endregion
        
        #region Parameter CmafPackage_SegmentPrefix
        /// <summary>
        /// <para>
        /// An optional custom string that is prepended
        /// to the name of each segment. If not specified, it defaults to the ChannelId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CmafPackage_SegmentPrefix { get; set; }
        #endregion
        
        #region Parameter StartoverWindowSecond
        /// <summary>
        /// <para>
        /// Maximum duration (seconds) of content
        /// to retain for startover playback.If not specified, startover playback will be disabled
        /// for the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StartoverWindowSeconds")]
        public System.Int32 StartoverWindowSecond { get; set; }
        #endregion
        
        #region Parameter StreamSelection_StreamOrder
        /// <summary>
        /// <para>
        /// A directive that determines the order of streams
        /// in the output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_StreamSelection_StreamOrder")]
        [AWSConstantClassSource("Amazon.MediaPackage.StreamOrder")]
        public Amazon.MediaPackage.StreamOrder StreamSelection_StreamOrder { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_SystemId
        /// <summary>
        /// <para>
        /// The system IDs to include in key requests.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_SpekeKeyProvider_SystemIds")]
        public System.String[] SpekeKeyProvider_SystemId { get; set; }
        #endregion
        
        #region Parameter TimeDelaySecond
        /// <summary>
        /// <para>
        /// Amount of delay (seconds) to enforce
        /// on the playback of live content.If not specified, there will be no time delay in effect
        /// for the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeDelaySeconds")]
        public System.Int32 TimeDelaySecond { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_Url
        /// <summary>
        /// <para>
        /// The URL of the external key provider service.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CmafPackage_Encryption_SpekeKeyProvider_Url")]
        public System.String SpekeKeyProvider_Url { get; set; }
        #endregion
        
        #region Parameter Whitelist
        /// <summary>
        /// <para>
        /// A list of source IP CIDR blocks that will be
        /// allowed to access the OriginEndpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Whitelist { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMPOriginEndpoint (CreateOriginEndpoint)"))
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
            
            context.ChannelId = this.ChannelId;
            if (ParameterWasBound("Encryption_KeyRotationIntervalSecond"))
                context.CmafPackage_Encryption_KeyRotationIntervalSeconds = this.Encryption_KeyRotationIntervalSecond;
            context.CmafPackage_Encryption_SpekeKeyProvider_CertificateArn = this.SpekeKeyProvider_CertificateArn;
            context.CmafPackage_Encryption_SpekeKeyProvider_ResourceId = this.SpekeKeyProvider_ResourceId;
            context.CmafPackage_Encryption_SpekeKeyProvider_RoleArn = this.SpekeKeyProvider_RoleArn;
            if (this.SpekeKeyProvider_SystemId != null)
            {
                context.CmafPackage_Encryption_SpekeKeyProvider_SystemIds = new List<System.String>(this.SpekeKeyProvider_SystemId);
            }
            context.CmafPackage_Encryption_SpekeKeyProvider_Url = this.SpekeKeyProvider_Url;
            if (this.CmafPackage_HlsManifest != null)
            {
                context.CmafPackage_HlsManifests = new List<Amazon.MediaPackage.Model.HlsManifestCreateOrUpdateParameters>(this.CmafPackage_HlsManifest);
            }
            if (ParameterWasBound("CmafPackage_SegmentDurationSecond"))
                context.CmafPackage_SegmentDurationSeconds = this.CmafPackage_SegmentDurationSecond;
            context.CmafPackage_SegmentPrefix = this.CmafPackage_SegmentPrefix;
            if (ParameterWasBound("StreamSelection_MaxVideoBitsPerSecond"))
                context.CmafPackage_StreamSelection_MaxVideoBitsPerSecond = this.StreamSelection_MaxVideoBitsPerSecond;
            if (ParameterWasBound("StreamSelection_MinVideoBitsPerSecond"))
                context.CmafPackage_StreamSelection_MinVideoBitsPerSecond = this.StreamSelection_MinVideoBitsPerSecond;
            context.CmafPackage_StreamSelection_StreamOrder = this.StreamSelection_StreamOrder;
            context.DashPackage = this.DashPackage;
            context.Description = this.Description;
            context.HlsPackage = this.HlsPackage;
            context.Id = this.Id;
            context.ManifestName = this.ManifestName;
            context.MssPackage = this.MssPackage;
            if (ParameterWasBound("StartoverWindowSecond"))
                context.StartoverWindowSeconds = this.StartoverWindowSecond;
            if (ParameterWasBound("TimeDelaySecond"))
                context.TimeDelaySeconds = this.TimeDelaySecond;
            if (this.Whitelist != null)
            {
                context.Whitelist = new List<System.String>(this.Whitelist);
            }
            
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
            var request = new Amazon.MediaPackage.Model.CreateOriginEndpointRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            
             // populate CmafPackage
            bool requestCmafPackageIsNull = true;
            request.CmafPackage = new Amazon.MediaPackage.Model.CmafPackageCreateOrUpdateParameters();
            List<Amazon.MediaPackage.Model.HlsManifestCreateOrUpdateParameters> requestCmafPackage_cmafPackage_HlsManifest = null;
            if (cmdletContext.CmafPackage_HlsManifests != null)
            {
                requestCmafPackage_cmafPackage_HlsManifest = cmdletContext.CmafPackage_HlsManifests;
            }
            if (requestCmafPackage_cmafPackage_HlsManifest != null)
            {
                request.CmafPackage.HlsManifests = requestCmafPackage_cmafPackage_HlsManifest;
                requestCmafPackageIsNull = false;
            }
            System.Int32? requestCmafPackage_cmafPackage_SegmentDurationSecond = null;
            if (cmdletContext.CmafPackage_SegmentDurationSeconds != null)
            {
                requestCmafPackage_cmafPackage_SegmentDurationSecond = cmdletContext.CmafPackage_SegmentDurationSeconds.Value;
            }
            if (requestCmafPackage_cmafPackage_SegmentDurationSecond != null)
            {
                request.CmafPackage.SegmentDurationSeconds = requestCmafPackage_cmafPackage_SegmentDurationSecond.Value;
                requestCmafPackageIsNull = false;
            }
            System.String requestCmafPackage_cmafPackage_SegmentPrefix = null;
            if (cmdletContext.CmafPackage_SegmentPrefix != null)
            {
                requestCmafPackage_cmafPackage_SegmentPrefix = cmdletContext.CmafPackage_SegmentPrefix;
            }
            if (requestCmafPackage_cmafPackage_SegmentPrefix != null)
            {
                request.CmafPackage.SegmentPrefix = requestCmafPackage_cmafPackage_SegmentPrefix;
                requestCmafPackageIsNull = false;
            }
            Amazon.MediaPackage.Model.CmafEncryption requestCmafPackage_cmafPackage_Encryption = null;
            
             // populate Encryption
            bool requestCmafPackage_cmafPackage_EncryptionIsNull = true;
            requestCmafPackage_cmafPackage_Encryption = new Amazon.MediaPackage.Model.CmafEncryption();
            System.Int32? requestCmafPackage_cmafPackage_Encryption_encryption_KeyRotationIntervalSecond = null;
            if (cmdletContext.CmafPackage_Encryption_KeyRotationIntervalSeconds != null)
            {
                requestCmafPackage_cmafPackage_Encryption_encryption_KeyRotationIntervalSecond = cmdletContext.CmafPackage_Encryption_KeyRotationIntervalSeconds.Value;
            }
            if (requestCmafPackage_cmafPackage_Encryption_encryption_KeyRotationIntervalSecond != null)
            {
                requestCmafPackage_cmafPackage_Encryption.KeyRotationIntervalSeconds = requestCmafPackage_cmafPackage_Encryption_encryption_KeyRotationIntervalSecond.Value;
                requestCmafPackage_cmafPackage_EncryptionIsNull = false;
            }
            Amazon.MediaPackage.Model.SpekeKeyProvider requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider = null;
            
             // populate SpekeKeyProvider
            bool requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = true;
            requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider = new Amazon.MediaPackage.Model.SpekeKeyProvider();
            System.String requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_CertificateArn = null;
            if (cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_CertificateArn != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_CertificateArn = cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_CertificateArn;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_CertificateArn != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider.CertificateArn = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_CertificateArn;
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId = null;
            if (cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_ResourceId != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId = cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_ResourceId;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider.ResourceId = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId;
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn = null;
            if (cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_RoleArn != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn = cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_RoleArn;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider.RoleArn = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn;
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = false;
            }
            List<System.String> requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_SystemId = null;
            if (cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_SystemIds != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_SystemId = cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_SystemIds;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_SystemId != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider.SystemIds = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_SystemId;
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_Url = null;
            if (cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_Url != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_Url = cmdletContext.CmafPackage_Encryption_SpekeKeyProvider_Url;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_Url != null)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider.Url = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider_spekeKeyProvider_Url;
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull = false;
            }
             // determine if requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider should be set to null
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProviderIsNull)
            {
                requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider = null;
            }
            if (requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider != null)
            {
                requestCmafPackage_cmafPackage_Encryption.SpekeKeyProvider = requestCmafPackage_cmafPackage_Encryption_cmafPackage_Encryption_SpekeKeyProvider;
                requestCmafPackage_cmafPackage_EncryptionIsNull = false;
            }
             // determine if requestCmafPackage_cmafPackage_Encryption should be set to null
            if (requestCmafPackage_cmafPackage_EncryptionIsNull)
            {
                requestCmafPackage_cmafPackage_Encryption = null;
            }
            if (requestCmafPackage_cmafPackage_Encryption != null)
            {
                request.CmafPackage.Encryption = requestCmafPackage_cmafPackage_Encryption;
                requestCmafPackageIsNull = false;
            }
            Amazon.MediaPackage.Model.StreamSelection requestCmafPackage_cmafPackage_StreamSelection = null;
            
             // populate StreamSelection
            bool requestCmafPackage_cmafPackage_StreamSelectionIsNull = true;
            requestCmafPackage_cmafPackage_StreamSelection = new Amazon.MediaPackage.Model.StreamSelection();
            System.Int32? requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MaxVideoBitsPerSecond = null;
            if (cmdletContext.CmafPackage_StreamSelection_MaxVideoBitsPerSecond != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MaxVideoBitsPerSecond = cmdletContext.CmafPackage_StreamSelection_MaxVideoBitsPerSecond.Value;
            }
            if (requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MaxVideoBitsPerSecond != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection.MaxVideoBitsPerSecond = requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MaxVideoBitsPerSecond.Value;
                requestCmafPackage_cmafPackage_StreamSelectionIsNull = false;
            }
            System.Int32? requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MinVideoBitsPerSecond = null;
            if (cmdletContext.CmafPackage_StreamSelection_MinVideoBitsPerSecond != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MinVideoBitsPerSecond = cmdletContext.CmafPackage_StreamSelection_MinVideoBitsPerSecond.Value;
            }
            if (requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MinVideoBitsPerSecond != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection.MinVideoBitsPerSecond = requestCmafPackage_cmafPackage_StreamSelection_streamSelection_MinVideoBitsPerSecond.Value;
                requestCmafPackage_cmafPackage_StreamSelectionIsNull = false;
            }
            Amazon.MediaPackage.StreamOrder requestCmafPackage_cmafPackage_StreamSelection_streamSelection_StreamOrder = null;
            if (cmdletContext.CmafPackage_StreamSelection_StreamOrder != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection_streamSelection_StreamOrder = cmdletContext.CmafPackage_StreamSelection_StreamOrder;
            }
            if (requestCmafPackage_cmafPackage_StreamSelection_streamSelection_StreamOrder != null)
            {
                requestCmafPackage_cmafPackage_StreamSelection.StreamOrder = requestCmafPackage_cmafPackage_StreamSelection_streamSelection_StreamOrder;
                requestCmafPackage_cmafPackage_StreamSelectionIsNull = false;
            }
             // determine if requestCmafPackage_cmafPackage_StreamSelection should be set to null
            if (requestCmafPackage_cmafPackage_StreamSelectionIsNull)
            {
                requestCmafPackage_cmafPackage_StreamSelection = null;
            }
            if (requestCmafPackage_cmafPackage_StreamSelection != null)
            {
                request.CmafPackage.StreamSelection = requestCmafPackage_cmafPackage_StreamSelection;
                requestCmafPackageIsNull = false;
            }
             // determine if request.CmafPackage should be set to null
            if (requestCmafPackageIsNull)
            {
                request.CmafPackage = null;
            }
            if (cmdletContext.DashPackage != null)
            {
                request.DashPackage = cmdletContext.DashPackage;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HlsPackage != null)
            {
                request.HlsPackage = cmdletContext.HlsPackage;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.ManifestName != null)
            {
                request.ManifestName = cmdletContext.ManifestName;
            }
            if (cmdletContext.MssPackage != null)
            {
                request.MssPackage = cmdletContext.MssPackage;
            }
            if (cmdletContext.StartoverWindowSeconds != null)
            {
                request.StartoverWindowSeconds = cmdletContext.StartoverWindowSeconds.Value;
            }
            if (cmdletContext.TimeDelaySeconds != null)
            {
                request.TimeDelaySeconds = cmdletContext.TimeDelaySeconds.Value;
            }
            if (cmdletContext.Whitelist != null)
            {
                request.Whitelist = cmdletContext.Whitelist;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.MediaPackage.Model.CreateOriginEndpointResponse CallAWSServiceOperation(IAmazonMediaPackage client, Amazon.MediaPackage.Model.CreateOriginEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage", "CreateOriginEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateOriginEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateOriginEndpointAsync(request);
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
            public System.String ChannelId { get; set; }
            public System.Int32? CmafPackage_Encryption_KeyRotationIntervalSeconds { get; set; }
            public System.String CmafPackage_Encryption_SpekeKeyProvider_CertificateArn { get; set; }
            public System.String CmafPackage_Encryption_SpekeKeyProvider_ResourceId { get; set; }
            public System.String CmafPackage_Encryption_SpekeKeyProvider_RoleArn { get; set; }
            public List<System.String> CmafPackage_Encryption_SpekeKeyProvider_SystemIds { get; set; }
            public System.String CmafPackage_Encryption_SpekeKeyProvider_Url { get; set; }
            public List<Amazon.MediaPackage.Model.HlsManifestCreateOrUpdateParameters> CmafPackage_HlsManifests { get; set; }
            public System.Int32? CmafPackage_SegmentDurationSeconds { get; set; }
            public System.String CmafPackage_SegmentPrefix { get; set; }
            public System.Int32? CmafPackage_StreamSelection_MaxVideoBitsPerSecond { get; set; }
            public System.Int32? CmafPackage_StreamSelection_MinVideoBitsPerSecond { get; set; }
            public Amazon.MediaPackage.StreamOrder CmafPackage_StreamSelection_StreamOrder { get; set; }
            public Amazon.MediaPackage.Model.DashPackage DashPackage { get; set; }
            public System.String Description { get; set; }
            public Amazon.MediaPackage.Model.HlsPackage HlsPackage { get; set; }
            public System.String Id { get; set; }
            public System.String ManifestName { get; set; }
            public Amazon.MediaPackage.Model.MssPackage MssPackage { get; set; }
            public System.Int32? StartoverWindowSeconds { get; set; }
            public System.Int32? TimeDelaySeconds { get; set; }
            public List<System.String> Whitelist { get; set; }
        }
        
    }
}
