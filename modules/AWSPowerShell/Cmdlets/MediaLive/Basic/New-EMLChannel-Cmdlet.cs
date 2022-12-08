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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Creates a new channel
    /// </summary>
    [Cmdlet("New", "EMLChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Channel")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateChannelResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Channel or Amazon.MediaLive.Model.CreateChannelResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Channel object.",
        "The service call response (type Amazon.MediaLive.Model.CreateChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMLChannelCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelClass
        /// <summary>
        /// <para>
        /// The class for this channel. STANDARD for
        /// a channel with two pipelines or SINGLE_PIPELINE for a channel with one pipeline.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.ChannelClass")]
        public Amazon.MediaLive.ChannelClass ChannelClass { get; set; }
        #endregion
        
        #region Parameter InputSpecification_Codec
        /// <summary>
        /// <para>
        /// Input codec
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputCodec")]
        public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.OutputDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter EncoderSetting
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncoderSettings")]
        public Amazon.MediaLive.Model.EncoderSettings EncoderSetting { get; set; }
        #endregion
        
        #region Parameter InputAttachment
        /// <summary>
        /// <para>
        /// List of input attachments for channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputAttachments")]
        public Amazon.MediaLive.Model.InputAttachment[] InputAttachment { get; set; }
        #endregion
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// The log level to write to CloudWatch Logs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.LogLevel")]
        public Amazon.MediaLive.LogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceDay
        /// <summary>
        /// <para>
        /// Choose one day of the week for maintenance.
        /// The chosen day is used for all future maintenance windows.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.MaintenanceDay")]
        public Amazon.MediaLive.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceStartTime
        /// <summary>
        /// <para>
        /// Choose the hour that maintenance
        /// will start. The chosen time is used for all future maintenance windows.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Maintenance_MaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter InputSpecification_MaximumBitrate
        /// <summary>
        /// <para>
        /// Maximum input bitrate, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputMaximumBitrate")]
        public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Vpc_PublicAddressAllocationId
        /// <summary>
        /// <para>
        /// List of public address allocation
        /// ids to associate with ENIs that will be created in Output VPC.Must specify one for
        /// SINGLE_PIPELINE, two for STANDARD channels
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Vpc_PublicAddressAllocationIds")]
        public System.String[] Vpc_PublicAddressAllocationId { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique request ID to be specified. This is needed
        /// to prevent retries fromcreating multiple resources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter CdiInputSpecification_Resolution
        /// <summary>
        /// <para>
        /// Maximum CDI input resolution
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.CdiInputResolution")]
        public Amazon.MediaLive.CdiInputResolution CdiInputSpecification_Resolution { get; set; }
        #endregion
        
        #region Parameter InputSpecification_Resolution
        /// <summary>
        /// <para>
        /// Input resolution, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputResolution")]
        public Amazon.MediaLive.InputResolution InputSpecification_Resolution { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// An optional Amazon Resource Name (ARN) of the
        /// role to assume when running the Channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// A list of up to 5 EC2 VPC security group
        /// IDs to attach to the Output VPC network interfaces.If none are specified then the
        /// VPC default security group will be used
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Vpc_SecurityGroupIds")]
        public System.String[] Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Vpc_SubnetId
        /// <summary>
        /// <para>
        /// A list of VPC subnet IDs from the same VPC.If
        /// STANDARD channel, subnet IDs must be mapped to two unique availability zones (AZ).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Vpc_SubnetIds")]
        public System.String[] Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Reserved
        /// <summary>
        /// <para>
        /// Deprecated field that's only usable by whitelisted
        /// customers.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated field that\u0027s only usable by whitelisted customers.")]
        public System.String Reserved { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channel";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLChannel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateChannelResponse, NewEMLChannelCmdlet>(Select) ??
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
            context.CdiInputSpecification_Resolution = this.CdiInputSpecification_Resolution;
            context.ChannelClass = this.ChannelClass;
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.MediaLive.Model.OutputDestination>(this.Destination);
            }
            context.EncoderSetting = this.EncoderSetting;
            if (this.InputAttachment != null)
            {
                context.InputAttachment = new List<Amazon.MediaLive.Model.InputAttachment>(this.InputAttachment);
            }
            context.InputSpecification_Codec = this.InputSpecification_Codec;
            context.InputSpecification_MaximumBitrate = this.InputSpecification_MaximumBitrate;
            context.InputSpecification_Resolution = this.InputSpecification_Resolution;
            context.LogLevel = this.LogLevel;
            context.Maintenance_MaintenanceDay = this.Maintenance_MaintenanceDay;
            context.Maintenance_MaintenanceStartTime = this.Maintenance_MaintenanceStartTime;
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Reserved = this.Reserved;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            if (this.Vpc_PublicAddressAllocationId != null)
            {
                context.Vpc_PublicAddressAllocationId = new List<System.String>(this.Vpc_PublicAddressAllocationId);
            }
            if (this.Vpc_SecurityGroupId != null)
            {
                context.Vpc_SecurityGroupId = new List<System.String>(this.Vpc_SecurityGroupId);
            }
            if (this.Vpc_SubnetId != null)
            {
                context.Vpc_SubnetId = new List<System.String>(this.Vpc_SubnetId);
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
            var request = new Amazon.MediaLive.Model.CreateChannelRequest();
            
            
             // populate CdiInputSpecification
            var requestCdiInputSpecificationIsNull = true;
            request.CdiInputSpecification = new Amazon.MediaLive.Model.CdiInputSpecification();
            Amazon.MediaLive.CdiInputResolution requestCdiInputSpecification_cdiInputSpecification_Resolution = null;
            if (cmdletContext.CdiInputSpecification_Resolution != null)
            {
                requestCdiInputSpecification_cdiInputSpecification_Resolution = cmdletContext.CdiInputSpecification_Resolution;
            }
            if (requestCdiInputSpecification_cdiInputSpecification_Resolution != null)
            {
                request.CdiInputSpecification.Resolution = requestCdiInputSpecification_cdiInputSpecification_Resolution;
                requestCdiInputSpecificationIsNull = false;
            }
             // determine if request.CdiInputSpecification should be set to null
            if (requestCdiInputSpecificationIsNull)
            {
                request.CdiInputSpecification = null;
            }
            if (cmdletContext.ChannelClass != null)
            {
                request.ChannelClass = cmdletContext.ChannelClass;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.EncoderSetting != null)
            {
                request.EncoderSettings = cmdletContext.EncoderSetting;
            }
            if (cmdletContext.InputAttachment != null)
            {
                request.InputAttachments = cmdletContext.InputAttachment;
            }
            
             // populate InputSpecification
            var requestInputSpecificationIsNull = true;
            request.InputSpecification = new Amazon.MediaLive.Model.InputSpecification();
            Amazon.MediaLive.InputCodec requestInputSpecification_inputSpecification_Codec = null;
            if (cmdletContext.InputSpecification_Codec != null)
            {
                requestInputSpecification_inputSpecification_Codec = cmdletContext.InputSpecification_Codec;
            }
            if (requestInputSpecification_inputSpecification_Codec != null)
            {
                request.InputSpecification.Codec = requestInputSpecification_inputSpecification_Codec;
                requestInputSpecificationIsNull = false;
            }
            Amazon.MediaLive.InputMaximumBitrate requestInputSpecification_inputSpecification_MaximumBitrate = null;
            if (cmdletContext.InputSpecification_MaximumBitrate != null)
            {
                requestInputSpecification_inputSpecification_MaximumBitrate = cmdletContext.InputSpecification_MaximumBitrate;
            }
            if (requestInputSpecification_inputSpecification_MaximumBitrate != null)
            {
                request.InputSpecification.MaximumBitrate = requestInputSpecification_inputSpecification_MaximumBitrate;
                requestInputSpecificationIsNull = false;
            }
            Amazon.MediaLive.InputResolution requestInputSpecification_inputSpecification_Resolution = null;
            if (cmdletContext.InputSpecification_Resolution != null)
            {
                requestInputSpecification_inputSpecification_Resolution = cmdletContext.InputSpecification_Resolution;
            }
            if (requestInputSpecification_inputSpecification_Resolution != null)
            {
                request.InputSpecification.Resolution = requestInputSpecification_inputSpecification_Resolution;
                requestInputSpecificationIsNull = false;
            }
             // determine if request.InputSpecification should be set to null
            if (requestInputSpecificationIsNull)
            {
                request.InputSpecification = null;
            }
            if (cmdletContext.LogLevel != null)
            {
                request.LogLevel = cmdletContext.LogLevel;
            }
            
             // populate Maintenance
            var requestMaintenanceIsNull = true;
            request.Maintenance = new Amazon.MediaLive.Model.MaintenanceCreateSettings();
            Amazon.MediaLive.MaintenanceDay requestMaintenance_maintenance_MaintenanceDay = null;
            if (cmdletContext.Maintenance_MaintenanceDay != null)
            {
                requestMaintenance_maintenance_MaintenanceDay = cmdletContext.Maintenance_MaintenanceDay;
            }
            if (requestMaintenance_maintenance_MaintenanceDay != null)
            {
                request.Maintenance.MaintenanceDay = requestMaintenance_maintenance_MaintenanceDay;
                requestMaintenanceIsNull = false;
            }
            System.String requestMaintenance_maintenance_MaintenanceStartTime = null;
            if (cmdletContext.Maintenance_MaintenanceStartTime != null)
            {
                requestMaintenance_maintenance_MaintenanceStartTime = cmdletContext.Maintenance_MaintenanceStartTime;
            }
            if (requestMaintenance_maintenance_MaintenanceStartTime != null)
            {
                request.Maintenance.MaintenanceStartTime = requestMaintenance_maintenance_MaintenanceStartTime;
                requestMaintenanceIsNull = false;
            }
             // determine if request.Maintenance should be set to null
            if (requestMaintenanceIsNull)
            {
                request.Maintenance = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Reserved != null)
            {
                request.Reserved = cmdletContext.Reserved;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Vpc
            var requestVpcIsNull = true;
            request.Vpc = new Amazon.MediaLive.Model.VpcOutputSettings();
            List<System.String> requestVpc_vpc_PublicAddressAllocationId = null;
            if (cmdletContext.Vpc_PublicAddressAllocationId != null)
            {
                requestVpc_vpc_PublicAddressAllocationId = cmdletContext.Vpc_PublicAddressAllocationId;
            }
            if (requestVpc_vpc_PublicAddressAllocationId != null)
            {
                request.Vpc.PublicAddressAllocationIds = requestVpc_vpc_PublicAddressAllocationId;
                requestVpcIsNull = false;
            }
            List<System.String> requestVpc_vpc_SecurityGroupId = null;
            if (cmdletContext.Vpc_SecurityGroupId != null)
            {
                requestVpc_vpc_SecurityGroupId = cmdletContext.Vpc_SecurityGroupId;
            }
            if (requestVpc_vpc_SecurityGroupId != null)
            {
                request.Vpc.SecurityGroupIds = requestVpc_vpc_SecurityGroupId;
                requestVpcIsNull = false;
            }
            List<System.String> requestVpc_vpc_SubnetId = null;
            if (cmdletContext.Vpc_SubnetId != null)
            {
                requestVpc_vpc_SubnetId = cmdletContext.Vpc_SubnetId;
            }
            if (requestVpc_vpc_SubnetId != null)
            {
                request.Vpc.SubnetIds = requestVpc_vpc_SubnetId;
                requestVpcIsNull = false;
            }
             // determine if request.Vpc should be set to null
            if (requestVpcIsNull)
            {
                request.Vpc = null;
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
        
        private Amazon.MediaLive.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateChannel");
            try
            {
                #if DESKTOP
                return client.CreateChannel(request);
                #elif CORECLR
                return client.CreateChannelAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.CdiInputResolution CdiInputSpecification_Resolution { get; set; }
            public Amazon.MediaLive.ChannelClass ChannelClass { get; set; }
            public List<Amazon.MediaLive.Model.OutputDestination> Destination { get; set; }
            public Amazon.MediaLive.Model.EncoderSettings EncoderSetting { get; set; }
            public List<Amazon.MediaLive.Model.InputAttachment> InputAttachment { get; set; }
            public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
            public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
            public Amazon.MediaLive.InputResolution InputSpecification_Resolution { get; set; }
            public Amazon.MediaLive.LogLevel LogLevel { get; set; }
            public Amazon.MediaLive.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
            public System.String Maintenance_MaintenanceStartTime { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            [System.ObsoleteAttribute]
            public System.String Reserved { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> Vpc_PublicAddressAllocationId { get; set; }
            public List<System.String> Vpc_SecurityGroupId { get; set; }
            public List<System.String> Vpc_SubnetId { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateChannelResponse, NewEMLChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channel;
        }
        
    }
}
