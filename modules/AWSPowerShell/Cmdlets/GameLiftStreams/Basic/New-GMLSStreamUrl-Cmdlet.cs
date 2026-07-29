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
using System.Threading;
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Creates a stream URL that grants temporary access to a stream session in a web browser
    /// without requiring an Amazon Web Services account or client integration.
    /// 
    ///  
    /// <para>
    /// You can use the stream URL to start a stream session up to the number of times set
    /// by <c>UsageLimit</c>, until it expires after <c>UrlExpiresAfterMinutes</c>. Each successful
    /// use starts a new stream session.
    /// </para><para>
    /// To make the request idempotent, provide a <c>ClientToken</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLSStreamUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.CreateStreamUrlResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams CreateStreamUrl API operation.", Operation = new[] {"CreateStreamUrl"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.CreateStreamUrlResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.CreateStreamUrlResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.CreateStreamUrlResponse object containing multiple properties."
    )]
    public partial class NewGMLSStreamUrlCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalEnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>A set of options that you can use to control the stream session runtime environment,
        /// expressed as a set of key-value pairs. You can use this to configure the application
        /// or stream session details. You can also provide custom environment variables that
        /// Amazon GameLift Streams passes to your game client.</para><note><para>If you want to debug your application with environment variables, we recommend that
        /// you do so in a local environment outside of Amazon GameLift Streams. For more information,
        /// refer to the Compatibility Guidance in the troubleshooting section of the Developer
        /// Guide.</para></note><para><c>AdditionalEnvironmentVariables</c> and <c>AdditionalLaunchArgs</c> have similar
        /// purposes. <c>AdditionalEnvironmentVariables</c> passes data using environment variables;
        /// while <c>AdditionalLaunchArgs</c> passes data using command-line arguments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalEnvironmentVariables")]
        public System.Collections.Hashtable AdditionalEnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter AdditionalLaunchArg
        /// <summary>
        /// <para>
        /// <para>A list of CLI arguments that are sent to the streaming server when a stream session
        /// launches. You can use this to configure the application or stream session details.
        /// You can also provide custom arguments that Amazon GameLift Streams passes to your
        /// game client.</para><para><c>AdditionalEnvironmentVariables</c> and <c>AdditionalLaunchArgs</c> have similar
        /// purposes. <c>AdditionalEnvironmentVariables</c> passes data using environment variables;
        /// while <c>AdditionalLaunchArgs</c> passes data using command-line arguments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalLaunchArgs")]
        public System.String[] AdditionalLaunchArg { get; set; }
        #endregion
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the application resource. Example
        /// ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:application/a-9ZY8X7Wv6</c>.
        /// Example ID: <c>a-9ZY8X7Wv6</c>. </para><para>This application must be associated with the stream group.</para>
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
        public System.String ApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A descriptive label for the stream URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayConfiguration_Resolution_Height
        /// <summary>
        /// <para>
        /// <para>The height of the stream session's virtual monitor, in pixels. The value must be an
        /// even number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DisplayConfiguration_Resolution_Height { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para><para>The stream session runs in this stream group.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A list of locations, in order of preference, where Amazon GameLift Streams can place
        /// the stream session. Specify each location by its Amazon Web Services Region code,
        /// for example <c>us-east-1</c>. For a complete list of locations that Amazon GameLift
        /// Streams supports, refer to <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/regions-quotas.html">Regions,
        /// quotas, and limitations</a> in the <i>Amazon GameLift Streams Developer Guide</i>.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Locations")]
        public System.String[] Location { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The data transport protocol for the stream session. Amazon GameLift Streams supports
        /// <c>WebRTC</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLiftStreams.Protocol")]
        public Amazon.GameLiftStreams.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon GameLift Streams assumes
        /// during stream sessions started from this stream URL. For more information, see <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/session-credentials.html">Provide
        /// AWS credentials to your streaming application</a> in the <i>Amazon GameLift Streams
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SessionLengthSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a stream session started from this stream
        /// URL can run. Valid values are 1-86400 seconds (1 second to 24 hours). The default
        /// is 43200 seconds (12 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLengthSeconds")]
        public System.Int32? SessionLengthSecond { get; set; }
        #endregion
        
        #region Parameter UrlExpiresAfterMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes after creation that the stream URL remains valid. After this
        /// period, the status of the stream URL changes to <c>EXPIRED</c> and it can no longer
        /// start stream sessions. The minimum is 1 minute. For the maximum, see <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/regions-quotas.html">Regions,
        /// quotas, and limitations</a> in the <i>Amazon GameLift Streams Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UrlExpiresAfterMinutes")]
        public System.Int32? UrlExpiresAfterMinute { get; set; }
        #endregion
        
        #region Parameter UsageLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of times the stream URL can start a stream session. Each successful
        /// use reduces the remaining uses by one. The minimum is 1, and the default is 1. For
        /// the maximum, see <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/regions-quotas.html">Regions,
        /// quotas, and limitations</a> in the <i>Amazon GameLift Streams Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UsageLimit { get; set; }
        #endregion
        
        #region Parameter DisplayConfiguration_Resolution_Width
        /// <summary>
        /// <para>
        /// <para>The width of the stream session's virtual monitor, in pixels. The value must be an
        /// even number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DisplayConfiguration_Resolution_Width { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure this request is idempotent.
        /// If you retry a request with the same <c>ClientToken</c>, Amazon GameLift Streams returns
        /// the original response without performing the operation again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.CreateStreamUrlResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.CreateStreamUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.ApplicationIdentifier),
                nameof(this.Identifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLSStreamUrl (CreateStreamUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.CreateStreamUrlResponse, NewGMLSStreamUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalEnvironmentVariable != null)
            {
                context.AdditionalEnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalEnvironmentVariable.Keys)
                {
                    context.AdditionalEnvironmentVariable.Add((String)hashKey, (System.String)(this.AdditionalEnvironmentVariable[hashKey]));
                }
            }
            if (this.AdditionalLaunchArg != null)
            {
                context.AdditionalLaunchArg = new List<System.String>(this.AdditionalLaunchArg);
            }
            context.ApplicationIdentifier = this.ApplicationIdentifier;
            #if MODULAR
            if (this.ApplicationIdentifier == null && ParameterWasBound(nameof(this.ApplicationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DisplayConfiguration_Resolution_Height = this.DisplayConfiguration_Resolution_Height;
            context.DisplayConfiguration_Resolution_Width = this.DisplayConfiguration_Resolution_Width;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Location != null)
            {
                context.Location = new List<System.String>(this.Location);
            }
            #if MODULAR
            if (this.Location == null && ParameterWasBound(nameof(this.Location)))
            {
                WriteWarning("You are passing $null as a value for parameter Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.SessionLengthSecond = this.SessionLengthSecond;
            context.UrlExpiresAfterMinute = this.UrlExpiresAfterMinute;
            #if MODULAR
            if (this.UrlExpiresAfterMinute == null && ParameterWasBound(nameof(this.UrlExpiresAfterMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter UrlExpiresAfterMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UsageLimit = this.UsageLimit;
            
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
            var request = new Amazon.GameLiftStreams.Model.CreateStreamUrlRequest();
            
            if (cmdletContext.AdditionalEnvironmentVariable != null)
            {
                request.AdditionalEnvironmentVariables = cmdletContext.AdditionalEnvironmentVariable;
            }
            if (cmdletContext.AdditionalLaunchArg != null)
            {
                request.AdditionalLaunchArgs = cmdletContext.AdditionalLaunchArg;
            }
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DisplayConfiguration
            var requestDisplayConfigurationIsNull = true;
            request.DisplayConfiguration = new Amazon.GameLiftStreams.Model.DisplayConfiguration();
            Amazon.GameLiftStreams.Model.Resolution requestDisplayConfiguration_displayConfiguration_Resolution = null;
            
             // populate Resolution
            var requestDisplayConfiguration_displayConfiguration_ResolutionIsNull = true;
            requestDisplayConfiguration_displayConfiguration_Resolution = new Amazon.GameLiftStreams.Model.Resolution();
            System.Int32? requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Height = null;
            if (cmdletContext.DisplayConfiguration_Resolution_Height != null)
            {
                requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Height = cmdletContext.DisplayConfiguration_Resolution_Height.Value;
            }
            if (requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Height != null)
            {
                requestDisplayConfiguration_displayConfiguration_Resolution.Height = requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Height.Value;
                requestDisplayConfiguration_displayConfiguration_ResolutionIsNull = false;
            }
            System.Int32? requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Width = null;
            if (cmdletContext.DisplayConfiguration_Resolution_Width != null)
            {
                requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Width = cmdletContext.DisplayConfiguration_Resolution_Width.Value;
            }
            if (requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Width != null)
            {
                requestDisplayConfiguration_displayConfiguration_Resolution.Width = requestDisplayConfiguration_displayConfiguration_Resolution_displayConfiguration_Resolution_Width.Value;
                requestDisplayConfiguration_displayConfiguration_ResolutionIsNull = false;
            }
             // determine if requestDisplayConfiguration_displayConfiguration_Resolution should be set to null
            if (requestDisplayConfiguration_displayConfiguration_ResolutionIsNull)
            {
                requestDisplayConfiguration_displayConfiguration_Resolution = null;
            }
            if (requestDisplayConfiguration_displayConfiguration_Resolution != null)
            {
                request.DisplayConfiguration.Resolution = requestDisplayConfiguration_displayConfiguration_Resolution;
                requestDisplayConfigurationIsNull = false;
            }
             // determine if request.DisplayConfiguration should be set to null
            if (requestDisplayConfigurationIsNull)
            {
                request.DisplayConfiguration = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Location != null)
            {
                request.Locations = cmdletContext.Location;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SessionLengthSecond != null)
            {
                request.SessionLengthSeconds = cmdletContext.SessionLengthSecond.Value;
            }
            if (cmdletContext.UrlExpiresAfterMinute != null)
            {
                request.UrlExpiresAfterMinutes = cmdletContext.UrlExpiresAfterMinute.Value;
            }
            if (cmdletContext.UsageLimit != null)
            {
                request.UsageLimit = cmdletContext.UsageLimit.Value;
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
        
        private Amazon.GameLiftStreams.Model.CreateStreamUrlResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.CreateStreamUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "CreateStreamUrl");
            try
            {
                return client.CreateStreamUrlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalEnvironmentVariable { get; set; }
            public List<System.String> AdditionalLaunchArg { get; set; }
            public System.String ApplicationIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Int32? DisplayConfiguration_Resolution_Height { get; set; }
            public System.Int32? DisplayConfiguration_Resolution_Width { get; set; }
            public System.String Identifier { get; set; }
            public List<System.String> Location { get; set; }
            public Amazon.GameLiftStreams.Protocol Protocol { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? SessionLengthSecond { get; set; }
            public System.Int32? UrlExpiresAfterMinute { get; set; }
            public System.Int32? UsageLimit { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateStreamUrlResponse, NewGMLSStreamUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
