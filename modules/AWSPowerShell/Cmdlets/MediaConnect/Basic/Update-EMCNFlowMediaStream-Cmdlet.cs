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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates an existing media stream.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowMediaStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowMediaStream API operation.", Operation = new[] {"UpdateFlowMediaStream"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMCNFlowMediaStreamCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Fmtp_ChannelOrder
        /// <summary>
        /// <para>
        /// The format of the audio channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_ChannelOrder")]
        public System.String Fmtp_ChannelOrder { get; set; }
        #endregion
        
        #region Parameter ClockRate
        /// <summary>
        /// <para>
        /// The sample rate (in Hz) for the stream. If the
        /// media stream type is video or ancillary data, set this value to 90000. If the media
        /// stream type is audio, set this value to either 48000 or 96000.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ClockRate { get; set; }
        #endregion
        
        #region Parameter Fmtp_Colorimetry
        /// <summary>
        /// <para>
        /// The format that is used for the representation
        /// of color.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_Colorimetry")]
        [AWSConstantClassSource("Amazon.MediaConnect.Colorimetry")]
        public Amazon.MediaConnect.Colorimetry Fmtp_Colorimetry { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// Description
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Fmtp_ExactFramerate
        /// <summary>
        /// <para>
        /// The frame rate for the video stream, in
        /// frames/second. For example: 60000/1001. If you specify a whole number, MediaConnect
        /// uses a ratio of N/1. For example, if you specify 60, MediaConnect uses 60/1 as the
        /// exactFramerate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_ExactFramerate")]
        public System.String Fmtp_ExactFramerate { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the flow.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Attributes_Lang
        /// <summary>
        /// <para>
        /// The audio language, in a format that is recognized
        /// by the receiver.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attributes_Lang { get; set; }
        #endregion
        
        #region Parameter MediaStreamName
        /// <summary>
        /// <para>
        /// The name of the media stream that you
        /// want to update.
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
        public System.String MediaStreamName { get; set; }
        #endregion
        
        #region Parameter MediaStreamType
        /// <summary>
        /// <para>
        /// The type of media stream.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.MediaStreamType")]
        public Amazon.MediaConnect.MediaStreamType MediaStreamType { get; set; }
        #endregion
        
        #region Parameter Fmtp_Par
        /// <summary>
        /// <para>
        /// The pixel aspect ratio (PAR) of the video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_Par")]
        public System.String Fmtp_Par { get; set; }
        #endregion
        
        #region Parameter Fmtp_Range
        /// <summary>
        /// <para>
        /// The encoding range of the video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_Range")]
        [AWSConstantClassSource("Amazon.MediaConnect.Range")]
        public Amazon.MediaConnect.Range Fmtp_Range { get; set; }
        #endregion
        
        #region Parameter Fmtp_ScanMode
        /// <summary>
        /// <para>
        /// The type of compression that was used to smooth
        /// the video’s appearance.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_ScanMode")]
        [AWSConstantClassSource("Amazon.MediaConnect.ScanMode")]
        public Amazon.MediaConnect.ScanMode Fmtp_ScanMode { get; set; }
        #endregion
        
        #region Parameter Fmtp_Tc
        /// <summary>
        /// <para>
        /// The transfer characteristic system (TCS) that is used
        /// in the video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_Fmtp_Tcs")]
        [AWSConstantClassSource("Amazon.MediaConnect.Tcs")]
        public Amazon.MediaConnect.Tcs Fmtp_Tc { get; set; }
        #endregion
        
        #region Parameter VideoFormat
        /// <summary>
        /// <para>
        /// The resolution of the video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VideoFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowMediaStream (UpdateFlowMediaStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse, UpdateEMCNFlowMediaStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Fmtp_ChannelOrder = this.Fmtp_ChannelOrder;
            context.Fmtp_Colorimetry = this.Fmtp_Colorimetry;
            context.Fmtp_ExactFramerate = this.Fmtp_ExactFramerate;
            context.Fmtp_Par = this.Fmtp_Par;
            context.Fmtp_Range = this.Fmtp_Range;
            context.Fmtp_ScanMode = this.Fmtp_ScanMode;
            context.Fmtp_Tc = this.Fmtp_Tc;
            context.Attributes_Lang = this.Attributes_Lang;
            context.ClockRate = this.ClockRate;
            context.Description = this.Description;
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaStreamName = this.MediaStreamName;
            #if MODULAR
            if (this.MediaStreamName == null && ParameterWasBound(nameof(this.MediaStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaStreamType = this.MediaStreamType;
            context.VideoFormat = this.VideoFormat;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowMediaStreamRequest();
            
            
             // populate Attributes
            var requestAttributesIsNull = true;
            request.Attributes = new Amazon.MediaConnect.Model.MediaStreamAttributesRequest();
            System.String requestAttributes_attributes_Lang = null;
            if (cmdletContext.Attributes_Lang != null)
            {
                requestAttributes_attributes_Lang = cmdletContext.Attributes_Lang;
            }
            if (requestAttributes_attributes_Lang != null)
            {
                request.Attributes.Lang = requestAttributes_attributes_Lang;
                requestAttributesIsNull = false;
            }
            Amazon.MediaConnect.Model.FmtpRequest requestAttributes_attributes_Fmtp = null;
            
             // populate Fmtp
            var requestAttributes_attributes_FmtpIsNull = true;
            requestAttributes_attributes_Fmtp = new Amazon.MediaConnect.Model.FmtpRequest();
            System.String requestAttributes_attributes_Fmtp_fmtp_ChannelOrder = null;
            if (cmdletContext.Fmtp_ChannelOrder != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_ChannelOrder = cmdletContext.Fmtp_ChannelOrder;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_ChannelOrder != null)
            {
                requestAttributes_attributes_Fmtp.ChannelOrder = requestAttributes_attributes_Fmtp_fmtp_ChannelOrder;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            Amazon.MediaConnect.Colorimetry requestAttributes_attributes_Fmtp_fmtp_Colorimetry = null;
            if (cmdletContext.Fmtp_Colorimetry != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_Colorimetry = cmdletContext.Fmtp_Colorimetry;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_Colorimetry != null)
            {
                requestAttributes_attributes_Fmtp.Colorimetry = requestAttributes_attributes_Fmtp_fmtp_Colorimetry;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            System.String requestAttributes_attributes_Fmtp_fmtp_ExactFramerate = null;
            if (cmdletContext.Fmtp_ExactFramerate != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_ExactFramerate = cmdletContext.Fmtp_ExactFramerate;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_ExactFramerate != null)
            {
                requestAttributes_attributes_Fmtp.ExactFramerate = requestAttributes_attributes_Fmtp_fmtp_ExactFramerate;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            System.String requestAttributes_attributes_Fmtp_fmtp_Par = null;
            if (cmdletContext.Fmtp_Par != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_Par = cmdletContext.Fmtp_Par;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_Par != null)
            {
                requestAttributes_attributes_Fmtp.Par = requestAttributes_attributes_Fmtp_fmtp_Par;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            Amazon.MediaConnect.Range requestAttributes_attributes_Fmtp_fmtp_Range = null;
            if (cmdletContext.Fmtp_Range != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_Range = cmdletContext.Fmtp_Range;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_Range != null)
            {
                requestAttributes_attributes_Fmtp.Range = requestAttributes_attributes_Fmtp_fmtp_Range;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            Amazon.MediaConnect.ScanMode requestAttributes_attributes_Fmtp_fmtp_ScanMode = null;
            if (cmdletContext.Fmtp_ScanMode != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_ScanMode = cmdletContext.Fmtp_ScanMode;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_ScanMode != null)
            {
                requestAttributes_attributes_Fmtp.ScanMode = requestAttributes_attributes_Fmtp_fmtp_ScanMode;
                requestAttributes_attributes_FmtpIsNull = false;
            }
            Amazon.MediaConnect.Tcs requestAttributes_attributes_Fmtp_fmtp_Tc = null;
            if (cmdletContext.Fmtp_Tc != null)
            {
                requestAttributes_attributes_Fmtp_fmtp_Tc = cmdletContext.Fmtp_Tc;
            }
            if (requestAttributes_attributes_Fmtp_fmtp_Tc != null)
            {
                requestAttributes_attributes_Fmtp.Tcs = requestAttributes_attributes_Fmtp_fmtp_Tc;
                requestAttributes_attributes_FmtpIsNull = false;
            }
             // determine if requestAttributes_attributes_Fmtp should be set to null
            if (requestAttributes_attributes_FmtpIsNull)
            {
                requestAttributes_attributes_Fmtp = null;
            }
            if (requestAttributes_attributes_Fmtp != null)
            {
                request.Attributes.Fmtp = requestAttributes_attributes_Fmtp;
                requestAttributesIsNull = false;
            }
             // determine if request.Attributes should be set to null
            if (requestAttributesIsNull)
            {
                request.Attributes = null;
            }
            if (cmdletContext.ClockRate != null)
            {
                request.ClockRate = cmdletContext.ClockRate.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.MediaStreamName != null)
            {
                request.MediaStreamName = cmdletContext.MediaStreamName;
            }
            if (cmdletContext.MediaStreamType != null)
            {
                request.MediaStreamType = cmdletContext.MediaStreamType;
            }
            if (cmdletContext.VideoFormat != null)
            {
                request.VideoFormat = cmdletContext.VideoFormat;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowMediaStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowMediaStream");
            try
            {
                #if DESKTOP
                return client.UpdateFlowMediaStream(request);
                #elif CORECLR
                return client.UpdateFlowMediaStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String Fmtp_ChannelOrder { get; set; }
            public Amazon.MediaConnect.Colorimetry Fmtp_Colorimetry { get; set; }
            public System.String Fmtp_ExactFramerate { get; set; }
            public System.String Fmtp_Par { get; set; }
            public Amazon.MediaConnect.Range Fmtp_Range { get; set; }
            public Amazon.MediaConnect.ScanMode Fmtp_ScanMode { get; set; }
            public Amazon.MediaConnect.Tcs Fmtp_Tc { get; set; }
            public System.String Attributes_Lang { get; set; }
            public System.Int32? ClockRate { get; set; }
            public System.String Description { get; set; }
            public System.String FlowArn { get; set; }
            public System.String MediaStreamName { get; set; }
            public Amazon.MediaConnect.MediaStreamType MediaStreamType { get; set; }
            public System.String VideoFormat { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowMediaStreamResponse, UpdateEMCNFlowMediaStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
