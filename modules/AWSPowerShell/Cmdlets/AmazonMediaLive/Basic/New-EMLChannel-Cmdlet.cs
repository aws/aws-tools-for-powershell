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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Creates a new channel
    /// </summary>
    [Cmdlet("New", "EMLChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Channel")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateChannel API operation.", Operation = new[] {"CreateChannel"})]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Channel",
        "This cmdlet returns a Channel object.",
        "The service call response (type Amazon.MediaLive.Model.CreateChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMLChannelCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter InputSpecification_Codec
        /// <summary>
        /// <para>
        /// Input codec
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaLive.InputCodec")]
        public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.OutputDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter EncoderSetting
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncoderSettings")]
        public Amazon.MediaLive.Model.EncoderSettings EncoderSetting { get; set; }
        #endregion
        
        #region Parameter InputAttachment
        /// <summary>
        /// <para>
        /// List of input attachments for channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputAttachments")]
        public Amazon.MediaLive.Model.InputAttachment[] InputAttachment { get; set; }
        #endregion
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// The log level to write to CloudWatch Logs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaLive.LogLevel")]
        public Amazon.MediaLive.LogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter InputSpecification_MaximumBitrate
        /// <summary>
        /// <para>
        /// Maximum input bitrate, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaLive.InputMaximumBitrate")]
        public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique request ID to be specified. This is needed
        /// to prevent retries fromcreating multiple resources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter InputSpecification_Resolution
        /// <summary>
        /// <para>
        /// Input resolution, categorized coarsely
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("Deprecated field that\'s only usable by whitelisted customers.")]
        public System.String Reserved { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLChannel (CreateChannel)"))
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
            
            if (this.Destination != null)
            {
                context.Destinations = new List<Amazon.MediaLive.Model.OutputDestination>(this.Destination);
            }
            context.EncoderSettings = this.EncoderSetting;
            if (this.InputAttachment != null)
            {
                context.InputAttachments = new List<Amazon.MediaLive.Model.InputAttachment>(this.InputAttachment);
            }
            context.InputSpecification_Codec = this.InputSpecification_Codec;
            context.InputSpecification_MaximumBitrate = this.InputSpecification_MaximumBitrate;
            context.InputSpecification_Resolution = this.InputSpecification_Resolution;
            context.LogLevel = this.LogLevel;
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Reserved = this.Reserved;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.MediaLive.Model.CreateChannelRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            if (cmdletContext.EncoderSettings != null)
            {
                request.EncoderSettings = cmdletContext.EncoderSettings;
            }
            if (cmdletContext.InputAttachments != null)
            {
                request.InputAttachments = cmdletContext.InputAttachments;
            }
            
             // populate InputSpecification
            bool requestInputSpecificationIsNull = true;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Channel;
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
            public List<Amazon.MediaLive.Model.OutputDestination> Destinations { get; set; }
            public Amazon.MediaLive.Model.EncoderSettings EncoderSettings { get; set; }
            public List<Amazon.MediaLive.Model.InputAttachment> InputAttachments { get; set; }
            public Amazon.MediaLive.InputCodec InputSpecification_Codec { get; set; }
            public Amazon.MediaLive.InputMaximumBitrate InputSpecification_MaximumBitrate { get; set; }
            public Amazon.MediaLive.InputResolution InputSpecification_Resolution { get; set; }
            public Amazon.MediaLive.LogLevel LogLevel { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            [System.ObsoleteAttribute]
            public System.String Reserved { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
