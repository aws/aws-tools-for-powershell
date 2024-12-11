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
using Amazon.MediaPackageV2;
using Amazon.MediaPackageV2.Model;

namespace Amazon.PowerShell.Cmdlets.MPV2
{
    /// <summary>
    /// Creates a new harvest job to export content from a MediaPackage v2 channel to an S3
    /// bucket.
    /// </summary>
    [Cmdlet("New", "MPV2HarvestJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageV2.Model.CreateHarvestJobResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 CreateHarvestJob API operation.", Operation = new[] {"CreateHarvestJob"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.CreateHarvestJobResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageV2.Model.CreateHarvestJobResponse",
        "This cmdlet returns an Amazon.MediaPackageV2.Model.CreateHarvestJobResponse object containing multiple properties."
    )]
    public partial class NewMPV2HarvestJobCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Destination_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an S3 bucket within which harvested content will be exported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Destination_S3Destination_BucketName")]
        public System.String S3Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter ChannelGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the channel group containing the channel from which to harvest content.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChannelGroupName { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel from which to harvest content.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter HarvestedManifests_DashManifest
        /// <summary>
        /// <para>
        /// <para>A list of harvested DASH manifests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HarvestedManifests_DashManifests")]
        public Amazon.MediaPackageV2.Model.HarvestedDashManifest[] HarvestedManifests_DashManifest { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the harvest job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3Destination_DestinationPath
        /// <summary>
        /// <para>
        /// <para>The path within the specified S3 bucket where the harvested content will be placed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Destination_S3Destination_DestinationPath")]
        public System.String S3Destination_DestinationPath { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the harvest job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ScheduleConfiguration_EndTime { get; set; }
        #endregion
        
        #region Parameter HarvestJobName
        /// <summary>
        /// <para>
        /// <para>A name for the harvest job. This name must be unique within the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HarvestJobName { get; set; }
        #endregion
        
        #region Parameter HarvestedManifests_HlsManifest
        /// <summary>
        /// <para>
        /// <para>A list of harvested HLS manifests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HarvestedManifests_HlsManifests")]
        public Amazon.MediaPackageV2.Model.HarvestedHlsManifest[] HarvestedManifests_HlsManifest { get; set; }
        #endregion
        
        #region Parameter HarvestedManifests_LowLatencyHlsManifest
        /// <summary>
        /// <para>
        /// <para>A list of harvested Low-Latency HLS manifests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HarvestedManifests_LowLatencyHlsManifests")]
        public Amazon.MediaPackageV2.Model.HarvestedLowLatencyHlsManifest[] HarvestedManifests_LowLatencyHlsManifest { get; set; }
        #endregion
        
        #region Parameter OriginEndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the origin endpoint from which to harvest content.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OriginEndpointName { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the harvest job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ScheduleConfiguration_StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of tags associated with the harvest job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.CreateHarvestJobResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageV2.Model.CreateHarvestJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HarvestJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HarvestJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HarvestJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HarvestJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MPV2HarvestJob (CreateHarvestJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.CreateHarvestJobResponse, NewMPV2HarvestJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HarvestJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelGroupName = this.ChannelGroupName;
            #if MODULAR
            if (this.ChannelGroupName == null && ParameterWasBound(nameof(this.ChannelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.S3Destination_BucketName = this.S3Destination_BucketName;
            #if MODULAR
            if (this.S3Destination_BucketName == null && ParameterWasBound(nameof(this.S3Destination_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_DestinationPath = this.S3Destination_DestinationPath;
            #if MODULAR
            if (this.S3Destination_DestinationPath == null && ParameterWasBound(nameof(this.S3Destination_DestinationPath)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_DestinationPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HarvestedManifests_DashManifest != null)
            {
                context.HarvestedManifests_DashManifest = new List<Amazon.MediaPackageV2.Model.HarvestedDashManifest>(this.HarvestedManifests_DashManifest);
            }
            if (this.HarvestedManifests_HlsManifest != null)
            {
                context.HarvestedManifests_HlsManifest = new List<Amazon.MediaPackageV2.Model.HarvestedHlsManifest>(this.HarvestedManifests_HlsManifest);
            }
            if (this.HarvestedManifests_LowLatencyHlsManifest != null)
            {
                context.HarvestedManifests_LowLatencyHlsManifest = new List<Amazon.MediaPackageV2.Model.HarvestedLowLatencyHlsManifest>(this.HarvestedManifests_LowLatencyHlsManifest);
            }
            context.HarvestJobName = this.HarvestJobName;
            context.OriginEndpointName = this.OriginEndpointName;
            #if MODULAR
            if (this.OriginEndpointName == null && ParameterWasBound(nameof(this.OriginEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleConfiguration_EndTime = this.ScheduleConfiguration_EndTime;
            #if MODULAR
            if (this.ScheduleConfiguration_EndTime == null && ParameterWasBound(nameof(this.ScheduleConfiguration_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleConfiguration_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleConfiguration_StartTime = this.ScheduleConfiguration_StartTime;
            #if MODULAR
            if (this.ScheduleConfiguration_StartTime == null && ParameterWasBound(nameof(this.ScheduleConfiguration_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleConfiguration_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.MediaPackageV2.Model.CreateHarvestJobRequest();
            
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.MediaPackageV2.Model.Destination();
            Amazon.MediaPackageV2.Model.S3DestinationConfig requestDestination_destination_S3Destination = null;
            
             // populate S3Destination
            var requestDestination_destination_S3DestinationIsNull = true;
            requestDestination_destination_S3Destination = new Amazon.MediaPackageV2.Model.S3DestinationConfig();
            System.String requestDestination_destination_S3Destination_s3Destination_BucketName = null;
            if (cmdletContext.S3Destination_BucketName != null)
            {
                requestDestination_destination_S3Destination_s3Destination_BucketName = cmdletContext.S3Destination_BucketName;
            }
            if (requestDestination_destination_S3Destination_s3Destination_BucketName != null)
            {
                requestDestination_destination_S3Destination.BucketName = requestDestination_destination_S3Destination_s3Destination_BucketName;
                requestDestination_destination_S3DestinationIsNull = false;
            }
            System.String requestDestination_destination_S3Destination_s3Destination_DestinationPath = null;
            if (cmdletContext.S3Destination_DestinationPath != null)
            {
                requestDestination_destination_S3Destination_s3Destination_DestinationPath = cmdletContext.S3Destination_DestinationPath;
            }
            if (requestDestination_destination_S3Destination_s3Destination_DestinationPath != null)
            {
                requestDestination_destination_S3Destination.DestinationPath = requestDestination_destination_S3Destination_s3Destination_DestinationPath;
                requestDestination_destination_S3DestinationIsNull = false;
            }
             // determine if requestDestination_destination_S3Destination should be set to null
            if (requestDestination_destination_S3DestinationIsNull)
            {
                requestDestination_destination_S3Destination = null;
            }
            if (requestDestination_destination_S3Destination != null)
            {
                request.Destination.S3Destination = requestDestination_destination_S3Destination;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            
             // populate HarvestedManifests
            var requestHarvestedManifestsIsNull = true;
            request.HarvestedManifests = new Amazon.MediaPackageV2.Model.HarvestedManifests();
            List<Amazon.MediaPackageV2.Model.HarvestedDashManifest> requestHarvestedManifests_harvestedManifests_DashManifest = null;
            if (cmdletContext.HarvestedManifests_DashManifest != null)
            {
                requestHarvestedManifests_harvestedManifests_DashManifest = cmdletContext.HarvestedManifests_DashManifest;
            }
            if (requestHarvestedManifests_harvestedManifests_DashManifest != null)
            {
                request.HarvestedManifests.DashManifests = requestHarvestedManifests_harvestedManifests_DashManifest;
                requestHarvestedManifestsIsNull = false;
            }
            List<Amazon.MediaPackageV2.Model.HarvestedHlsManifest> requestHarvestedManifests_harvestedManifests_HlsManifest = null;
            if (cmdletContext.HarvestedManifests_HlsManifest != null)
            {
                requestHarvestedManifests_harvestedManifests_HlsManifest = cmdletContext.HarvestedManifests_HlsManifest;
            }
            if (requestHarvestedManifests_harvestedManifests_HlsManifest != null)
            {
                request.HarvestedManifests.HlsManifests = requestHarvestedManifests_harvestedManifests_HlsManifest;
                requestHarvestedManifestsIsNull = false;
            }
            List<Amazon.MediaPackageV2.Model.HarvestedLowLatencyHlsManifest> requestHarvestedManifests_harvestedManifests_LowLatencyHlsManifest = null;
            if (cmdletContext.HarvestedManifests_LowLatencyHlsManifest != null)
            {
                requestHarvestedManifests_harvestedManifests_LowLatencyHlsManifest = cmdletContext.HarvestedManifests_LowLatencyHlsManifest;
            }
            if (requestHarvestedManifests_harvestedManifests_LowLatencyHlsManifest != null)
            {
                request.HarvestedManifests.LowLatencyHlsManifests = requestHarvestedManifests_harvestedManifests_LowLatencyHlsManifest;
                requestHarvestedManifestsIsNull = false;
            }
             // determine if request.HarvestedManifests should be set to null
            if (requestHarvestedManifestsIsNull)
            {
                request.HarvestedManifests = null;
            }
            if (cmdletContext.HarvestJobName != null)
            {
                request.HarvestJobName = cmdletContext.HarvestJobName;
            }
            if (cmdletContext.OriginEndpointName != null)
            {
                request.OriginEndpointName = cmdletContext.OriginEndpointName;
            }
            
             // populate ScheduleConfiguration
            var requestScheduleConfigurationIsNull = true;
            request.ScheduleConfiguration = new Amazon.MediaPackageV2.Model.HarvesterScheduleConfiguration();
            System.DateTime? requestScheduleConfiguration_scheduleConfiguration_EndTime = null;
            if (cmdletContext.ScheduleConfiguration_EndTime != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_EndTime = cmdletContext.ScheduleConfiguration_EndTime.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_EndTime != null)
            {
                request.ScheduleConfiguration.EndTime = requestScheduleConfiguration_scheduleConfiguration_EndTime.Value;
                requestScheduleConfigurationIsNull = false;
            }
            System.DateTime? requestScheduleConfiguration_scheduleConfiguration_StartTime = null;
            if (cmdletContext.ScheduleConfiguration_StartTime != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_StartTime = cmdletContext.ScheduleConfiguration_StartTime.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_StartTime != null)
            {
                request.ScheduleConfiguration.StartTime = requestScheduleConfiguration_scheduleConfiguration_StartTime.Value;
                requestScheduleConfigurationIsNull = false;
            }
             // determine if request.ScheduleConfiguration should be set to null
            if (requestScheduleConfigurationIsNull)
            {
                request.ScheduleConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MediaPackageV2.Model.CreateHarvestJobResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.CreateHarvestJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "CreateHarvestJob");
            try
            {
                #if DESKTOP
                return client.CreateHarvestJob(request);
                #elif CORECLR
                return client.CreateHarvestJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelGroupName { get; set; }
            public System.String ChannelName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String S3Destination_BucketName { get; set; }
            public System.String S3Destination_DestinationPath { get; set; }
            public List<Amazon.MediaPackageV2.Model.HarvestedDashManifest> HarvestedManifests_DashManifest { get; set; }
            public List<Amazon.MediaPackageV2.Model.HarvestedHlsManifest> HarvestedManifests_HlsManifest { get; set; }
            public List<Amazon.MediaPackageV2.Model.HarvestedLowLatencyHlsManifest> HarvestedManifests_LowLatencyHlsManifest { get; set; }
            public System.String HarvestJobName { get; set; }
            public System.String OriginEndpointName { get; set; }
            public System.DateTime? ScheduleConfiguration_EndTime { get; set; }
            public System.DateTime? ScheduleConfiguration_StartTime { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.CreateHarvestJobResponse, NewMPV2HarvestJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
