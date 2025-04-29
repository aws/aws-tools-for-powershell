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
    /// Creates an application resource in Amazon GameLift Streams, which specifies the application
    /// content you want to stream, such as a game build or other software, and configures
    /// the settings to run it.
    /// 
    ///  
    /// <para>
    ///  Before you create an application, upload your application content files to an Amazon
    /// Simple Storage Service (Amazon S3) bucket. For more information, see <b>Getting Started</b>
    /// in the Amazon GameLift Streams Developer Guide. 
    /// </para><important><para>
    ///  Make sure that your files in the Amazon S3 bucket are the correct version you want
    /// to use. As soon as you create a Amazon GameLift Streams application, you cannot change
    /// the files at a later time. 
    /// </para></important><para>
    ///  If the request is successful, Amazon GameLift Streams begins to create an application
    /// and sets the status to <c>INITIALIZED</c>. When an application reaches <c>READY</c>
    /// status, you can use the application to set up stream groups and start streams. To
    /// track application status, call <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_GetApplication.html">GetApplication</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.CreateApplicationResponse object containing multiple properties."
    )]
    public partial class NewGMLSApplicationCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationLogOutputUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI to a bucket where you would like Amazon GameLift Streams to save
        /// application logs. Required if you specify one or more <c>ApplicationLogPaths</c>.</para><note><para>The log bucket must have permissions that give Amazon GameLift Streams access to write
        /// the log files. For more information, see <b>Getting Started</b> in the Amazon GameLift
        /// Streams Developer Guide. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationLogOutputUri { get; set; }
        #endregion
        
        #region Parameter ApplicationLogPath
        /// <summary>
        /// <para>
        /// <para>Locations of log files that your content generates during a stream session. Enter
        /// path values that are relative to the <c>ApplicationSourceUri</c> location. You can
        /// specify up to 10 log paths. Amazon GameLift Streams uploads designated log files to
        /// the Amazon S3 bucket that you specify in <c>ApplicationLogOutputUri</c> at the end
        /// of a stream session. To retrieve stored log files, call <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_GetStreamSession.html">GetStreamSession</a>
        /// and get the <c>LogFileLocationUri</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationLogPaths")]
        public System.String[] ApplicationLogPath { get; set; }
        #endregion
        
        #region Parameter ApplicationSourceUri
        /// <summary>
        /// <para>
        /// <para>The location of the content that you want to stream. Enter an Amazon S3 URI to a bucket
        /// that contains your game or other application. The location can have a multi-level
        /// prefix structure, but it must include all the files needed to run the content. Amazon
        /// GameLift Streams copies everything under the specified location.</para><para>This value is immutable. To designate a different content location, create a new application.</para><note><para>The Amazon S3 bucket and the Amazon GameLift Streams application must be in the same
        /// Amazon Web Services Region.</para></note>
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
        public System.String ApplicationSourceUri { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable label for the application. You can update this value later.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutablePath
        /// <summary>
        /// <para>
        /// <para>The path and file name of the executable file that launches the content for streaming.
        /// Enter a path value that is relative to the location set in <c>ApplicationSourceUri</c>.</para>
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
        public System.String ExecutablePath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new application resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources is useful for resource management,
        /// access management and cost allocation. See <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.
        /// You can use <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_TagResource.html">TagResource</a>
        /// to add tags, <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_UntagResource.html">UntagResource</a>
        /// to remove tags, and <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_ListTagsForResource.html">ListTagsForResource</a>
        /// to view tags on existing resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RuntimeEnvironment_Type
        /// <summary>
        /// <para>
        /// <para>The operating system and other drivers. For Proton, this also includes the Proton
        /// compatibility layer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLiftStreams.RuntimeEnvironmentType")]
        public Amazon.GameLiftStreams.RuntimeEnvironmentType RuntimeEnvironment_Type { get; set; }
        #endregion
        
        #region Parameter RuntimeEnvironment_Version
        /// <summary>
        /// <para>
        /// <para>Versioned container environment for the application operating system.</para>
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
        public System.String RuntimeEnvironment_Version { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.CreateApplicationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLSApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.CreateApplicationResponse, NewGMLSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationLogOutputUri = this.ApplicationLogOutputUri;
            if (this.ApplicationLogPath != null)
            {
                context.ApplicationLogPath = new List<System.String>(this.ApplicationLogPath);
            }
            context.ApplicationSourceUri = this.ApplicationSourceUri;
            #if MODULAR
            if (this.ApplicationSourceUri == null && ParameterWasBound(nameof(this.ApplicationSourceUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationSourceUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutablePath = this.ExecutablePath;
            #if MODULAR
            if (this.ExecutablePath == null && ParameterWasBound(nameof(this.ExecutablePath)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutablePath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeEnvironment_Type = this.RuntimeEnvironment_Type;
            #if MODULAR
            if (this.RuntimeEnvironment_Type == null && ParameterWasBound(nameof(this.RuntimeEnvironment_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeEnvironment_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeEnvironment_Version = this.RuntimeEnvironment_Version;
            #if MODULAR
            if (this.RuntimeEnvironment_Version == null && ParameterWasBound(nameof(this.RuntimeEnvironment_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeEnvironment_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLiftStreams.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationLogOutputUri != null)
            {
                request.ApplicationLogOutputUri = cmdletContext.ApplicationLogOutputUri;
            }
            if (cmdletContext.ApplicationLogPath != null)
            {
                request.ApplicationLogPaths = cmdletContext.ApplicationLogPath;
            }
            if (cmdletContext.ApplicationSourceUri != null)
            {
                request.ApplicationSourceUri = cmdletContext.ApplicationSourceUri;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutablePath != null)
            {
                request.ExecutablePath = cmdletContext.ExecutablePath;
            }
            
             // populate RuntimeEnvironment
            var requestRuntimeEnvironmentIsNull = true;
            request.RuntimeEnvironment = new Amazon.GameLiftStreams.Model.RuntimeEnvironment();
            Amazon.GameLiftStreams.RuntimeEnvironmentType requestRuntimeEnvironment_runtimeEnvironment_Type = null;
            if (cmdletContext.RuntimeEnvironment_Type != null)
            {
                requestRuntimeEnvironment_runtimeEnvironment_Type = cmdletContext.RuntimeEnvironment_Type;
            }
            if (requestRuntimeEnvironment_runtimeEnvironment_Type != null)
            {
                request.RuntimeEnvironment.Type = requestRuntimeEnvironment_runtimeEnvironment_Type;
                requestRuntimeEnvironmentIsNull = false;
            }
            System.String requestRuntimeEnvironment_runtimeEnvironment_Version = null;
            if (cmdletContext.RuntimeEnvironment_Version != null)
            {
                requestRuntimeEnvironment_runtimeEnvironment_Version = cmdletContext.RuntimeEnvironment_Version;
            }
            if (requestRuntimeEnvironment_runtimeEnvironment_Version != null)
            {
                request.RuntimeEnvironment.Version = requestRuntimeEnvironment_runtimeEnvironment_Version;
                requestRuntimeEnvironmentIsNull = false;
            }
             // determine if request.RuntimeEnvironment should be set to null
            if (requestRuntimeEnvironmentIsNull)
            {
                request.RuntimeEnvironment = null;
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
        
        private Amazon.GameLiftStreams.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationLogOutputUri { get; set; }
            public List<System.String> ApplicationLogPath { get; set; }
            public System.String ApplicationSourceUri { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutablePath { get; set; }
            public Amazon.GameLiftStreams.RuntimeEnvironmentType RuntimeEnvironment_Type { get; set; }
            public System.String RuntimeEnvironment_Version { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateApplicationResponse, NewGMLSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
