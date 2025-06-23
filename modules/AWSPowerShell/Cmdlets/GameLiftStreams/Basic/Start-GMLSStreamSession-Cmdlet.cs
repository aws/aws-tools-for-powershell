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
    /// This action initiates a new stream session and outputs connection information that
    /// clients can use to access the stream. A stream session refers to an instance of a
    /// stream that Amazon GameLift Streams transmits from the server to the end-user. A stream
    /// session runs on a compute resource that a stream group has allocated. 
    /// 
    ///  
    /// <para>
    /// To start a new stream session, specify a stream group and application ID, along with
    /// the transport protocol and signal request settings to use with the stream. You must
    /// have associated at least one application to the stream group before starting a stream
    /// session, either when creating the stream group, or by using <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_AssociateApplications.html">AssociateApplications</a>.
    /// </para><para>
    ///  For stream groups that have multiple locations, provide a set of locations ordered
    /// by priority using a <c>Locations</c> parameter. Amazon GameLift Streams will start
    /// a single stream session in the next available location. An application must be finished
    /// replicating in a remote location before the remote location can host a stream. 
    /// </para><para>
    ///  If the request is successful, Amazon GameLift Streams begins to prepare the stream.
    /// Amazon GameLift Streams assigns an Amazon Resource Name (ARN) value to the stream
    /// session resource and sets the status to <c>ACTIVATING</c>. During the stream preparation
    /// process, Amazon GameLift Streams queues the request and searches for available stream
    /// capacity to run the stream. This results in one of the following: 
    /// </para><ul><li><para>
    ///  Amazon GameLift Streams identifies an available compute resource to run the application
    /// content and start the stream. When the stream is ready, the stream session's status
    /// changes to <c>ACTIVE</c> and includes stream connection information. Provide the connection
    /// information to the requesting client to join the stream session.
    /// </para></li><li><para>
    ///  Amazon GameLift Streams doesn't identify an available resource within a certain time,
    /// set by <c>ClientToken</c>. In this case, Amazon GameLift Streams stops processing
    /// the request, and the stream session object status changes to <c>ERROR</c> with status
    /// reason <c>placementTimeout</c>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "GMLSStreamSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.StartStreamSessionResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams StartStreamSession API operation.", Operation = new[] {"StartStreamSession"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.StartStreamSessionResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.StartStreamSessionResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.StartStreamSessionResponse object containing multiple properties."
    )]
    public partial class StartGMLSStreamSessionCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
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
        /// Example ID: <c>a-9ZY8X7Wv6</c>. </para>
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
        
        #region Parameter ConnectionTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Length of time (in seconds) that Amazon GameLift Streams should wait for a client
        /// to connect to the stream session. This time span starts when the stream session reaches
        /// <c>ACTIVE</c> status. If no client connects before the timeout, Amazon GameLift Streams
        /// stops the stream session with status of <c>TERMINATED</c>. Default value is 120.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionTimeoutSeconds")]
        public System.Int32? ConnectionTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable label for the stream session. You can update this value later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The stream group to run this stream session with.</para><para>This value is an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para>
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
        /// <para> A list of locations, in order of priority, where you want Amazon GameLift Streams
        /// to start a stream from. Amazon GameLift Streams selects the location with the next
        /// available capacity to start a single stream session in. If this value is empty, Amazon
        /// GameLift Streams attempts to start a stream session in the primary location. </para><para> This value is A set of location names. For example, <c>us-east-1</c>. For a complete
        /// list of locations that Amazon GameLift Streams supports, refer to <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/regions-quotas.html">Regions,
        /// quotas, and limitations</a> in the <i>Amazon GameLift Streams Developer Guide</i>.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Locations")]
        public System.String[] Location { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The data transport protocol to use for the stream session.</para>
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
        
        #region Parameter SessionLengthSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time (in seconds) that Amazon GameLift Streams keeps the stream
        /// session open. At this point, Amazon GameLift Streams ends the stream session regardless
        /// of any existing client connections. Default value is 43200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLengthSeconds")]
        public System.Int32? SessionLengthSecond { get; set; }
        #endregion
        
        #region Parameter SignalRequest
        /// <summary>
        /// <para>
        /// <para>A WebRTC ICE offer string to use when initializing a WebRTC connection. Typically,
        /// the offer is a very long JSON string. Provide the string as a text value in quotes.</para><para>Amazon GameLift Streams also supports setting the field to "NO_CLIENT_CONNECTION".
        /// This will create a session without needing any browser request or Web SDK integration.
        /// The session starts up as usual and waits for a reconnection from a browser, which
        /// is accomplished using <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_CreateStreamSessionConnection.html">CreateStreamSessionConnection</a>.</para>
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
        public System.String SignalRequest { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para> An opaque, unique identifier for an end-user, defined by the developer. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier that represents a client request. The request is idempotent,
        /// which ensures that an API request completes only once. When users send a request,
        /// Amazon GameLift Streams automatically populates this field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.StartStreamSessionResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.StartStreamSessionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLSStreamSession (StartStreamSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.StartStreamSessionResponse, StartGMLSStreamSessionCmdlet>(Select) ??
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
            context.ConnectionTimeoutSecond = this.ConnectionTimeoutSecond;
            context.Description = this.Description;
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
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionLengthSecond = this.SessionLengthSecond;
            context.SignalRequest = this.SignalRequest;
            #if MODULAR
            if (this.SignalRequest == null && ParameterWasBound(nameof(this.SignalRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            
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
            var request = new Amazon.GameLiftStreams.Model.StartStreamSessionRequest();
            
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
            if (cmdletContext.ConnectionTimeoutSecond != null)
            {
                request.ConnectionTimeoutSeconds = cmdletContext.ConnectionTimeoutSecond.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.SessionLengthSecond != null)
            {
                request.SessionLengthSeconds = cmdletContext.SessionLengthSecond.Value;
            }
            if (cmdletContext.SignalRequest != null)
            {
                request.SignalRequest = cmdletContext.SignalRequest;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.GameLiftStreams.Model.StartStreamSessionResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.StartStreamSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "StartStreamSession");
            try
            {
                return client.StartStreamSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ConnectionTimeoutSecond { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public List<System.String> Location { get; set; }
            public Amazon.GameLiftStreams.Protocol Protocol { get; set; }
            public System.Int32? SessionLengthSecond { get; set; }
            public System.String SignalRequest { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.StartStreamSessionResponse, StartGMLSStreamSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
