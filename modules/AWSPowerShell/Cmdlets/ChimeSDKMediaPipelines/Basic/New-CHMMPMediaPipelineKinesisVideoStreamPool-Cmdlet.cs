/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ChimeSDKMediaPipelines;
using Amazon.ChimeSDKMediaPipelines.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMP
{
    /// <summary>
    /// Creates an Amazon Kinesis Video Stream pool for use with media stream pipelines.
    /// 
    ///  <note><para>
    /// If a meeting uses an opt-in Region as its <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_meeting-chime_CreateMeeting.html#chimesdk-meeting-chime_CreateMeeting-request-MediaRegion">MediaRegion</a>,
    /// the KVS stream must be in that same Region. For example, if a meeting uses the <c>af-south-1</c>
    /// Region, the KVS stream must also be in <c>af-south-1</c>. However, if the meeting
    /// uses a Region that AWS turns on by default, the KVS stream can be in any available
    /// Region, including an opt-in Region. For example, if the meeting uses <c>ca-central-1</c>,
    /// the KVS stream can be in <c>eu-west-2</c>, <c>us-east-1</c>, <c>af-south-1</c>, or
    /// any other Region that the Amazon Chime SDK supports.
    /// </para><para>
    /// To learn which AWS Region a meeting uses, call the <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_meeting-chime_GetMeeting.html">GetMeeting</a>
    /// API and use the <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_meeting-chime_CreateMeeting.html#chimesdk-meeting-chime_CreateMeeting-request-MediaRegion">MediaRegion</a>
    /// parameter from the response.
    /// </para><para>
    /// For more information about opt-in Regions, refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/sdk-available-regions.html">Available
    /// Regions</a> in the <i>Amazon Chime SDK Developer Guide</i>, and <a href="https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-regions.html#rande-manage-enable.html">Specify
    /// which AWS Regions your account can use</a>, in the <i>AWS Account Management Reference
    /// Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CHMMPMediaPipelineKinesisVideoStreamPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamPoolConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Media Pipelines CreateMediaPipelineKinesisVideoStreamPool API operation.", Operation = new[] {"CreateMediaPipelineKinesisVideoStreamPool"}, SelectReturnType = typeof(Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamPoolConfiguration or Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse",
        "This cmdlet returns an Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamPoolConfiguration object.",
        "The service call response (type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMMPMediaPipelineKinesisVideoStreamPoolCmdlet : AmazonChimeSDKMediaPipelinesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The token assigned to the client making the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_DataRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The amount of time that data is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_DataRetentionInHours")]
        public System.Int32? StreamConfiguration_DataRetentionInHour { get; set; }
        #endregion
        
        #region Parameter PoolName
        /// <summary>
        /// <para>
        /// <para>The name of the pool.</para>
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
        public System.String PoolName { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the video stream.</para>
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
        public System.String StreamConfiguration_Region { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the stream pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMediaPipelines.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KinesisVideoStreamPoolConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KinesisVideoStreamPoolConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMPMediaPipelineKinesisVideoStreamPool (CreateMediaPipelineKinesisVideoStreamPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse, NewCHMMPMediaPipelineKinesisVideoStreamPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.PoolName = this.PoolName;
            #if MODULAR
            if (this.PoolName == null && ParameterWasBound(nameof(this.PoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamConfiguration_DataRetentionInHour = this.StreamConfiguration_DataRetentionInHour;
            context.StreamConfiguration_Region = this.StreamConfiguration_Region;
            #if MODULAR
            if (this.StreamConfiguration_Region == null && ParameterWasBound(nameof(this.StreamConfiguration_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfiguration_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMediaPipelines.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.PoolName != null)
            {
                request.PoolName = cmdletContext.PoolName;
            }
            
             // populate StreamConfiguration
            var requestStreamConfigurationIsNull = true;
            request.StreamConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamConfiguration();
            System.Int32? requestStreamConfiguration_streamConfiguration_DataRetentionInHour = null;
            if (cmdletContext.StreamConfiguration_DataRetentionInHour != null)
            {
                requestStreamConfiguration_streamConfiguration_DataRetentionInHour = cmdletContext.StreamConfiguration_DataRetentionInHour.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_DataRetentionInHour != null)
            {
                request.StreamConfiguration.DataRetentionInHours = requestStreamConfiguration_streamConfiguration_DataRetentionInHour.Value;
                requestStreamConfigurationIsNull = false;
            }
            System.String requestStreamConfiguration_streamConfiguration_Region = null;
            if (cmdletContext.StreamConfiguration_Region != null)
            {
                requestStreamConfiguration_streamConfiguration_Region = cmdletContext.StreamConfiguration_Region;
            }
            if (requestStreamConfiguration_streamConfiguration_Region != null)
            {
                request.StreamConfiguration.Region = requestStreamConfiguration_streamConfiguration_Region;
                requestStreamConfigurationIsNull = false;
            }
             // determine if request.StreamConfiguration should be set to null
            if (requestStreamConfigurationIsNull)
            {
                request.StreamConfiguration = null;
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
        
        private Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse CallAWSServiceOperation(IAmazonChimeSDKMediaPipelines client, Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Media Pipelines", "CreateMediaPipelineKinesisVideoStreamPool");
            try
            {
                #if DESKTOP
                return client.CreateMediaPipelineKinesisVideoStreamPool(request);
                #elif CORECLR
                return client.CreateMediaPipelineKinesisVideoStreamPoolAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String PoolName { get; set; }
            public System.Int32? StreamConfiguration_DataRetentionInHour { get; set; }
            public System.String StreamConfiguration_Region { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaPipelineKinesisVideoStreamPoolResponse, NewCHMMPMediaPipelineKinesisVideoStreamPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KinesisVideoStreamPoolConfiguration;
        }
        
    }
}
