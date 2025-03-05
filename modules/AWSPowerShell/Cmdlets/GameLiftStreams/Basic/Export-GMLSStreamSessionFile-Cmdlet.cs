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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Export the files that your application modifies or generates in a stream session,
    /// which can help you debug or verify your application. When your application runs, it
    /// generates output files such as logs, diagnostic information, crash dumps, save files,
    /// user data, screenshots, and so on. The files can be defined by the engine or frameworks
    /// that your application uses, or information that you've programmed your application
    /// to output. 
    /// 
    ///  
    /// <para>
    ///  You can only call this action on a stream session that is in progress, specifically
    /// in one of the following statuses <c>ACTIVE</c>, <c>CONNECTED</c>, <c>PENDING_CLIENT_RECONNECTION</c>,
    /// and <c>RECONNECTING</c>. You must provide an Amazon Simple Storage Service (Amazon
    /// S3) bucket to store the files in. When the session ends, Amazon GameLift Streams produces
    /// a compressed folder that contains all of the files and directories that were modified
    /// or created by the application during the stream session. AWS uses your security credentials
    /// to authenticate and authorize access to your Amazon S3 bucket. 
    /// </para><para>
    /// Amazon GameLift Streams collects the following generated and modified files. Find
    /// them in the corresponding folders in the <c>.zip</c> archive.
    /// </para><ul><li><para><c>application/</c>: The folder where your application or game is stored. 
    /// </para></li></ul><ul><li><para><c>profile/</c>: The user profile folder.
    /// </para></li><li><para><c>temp/</c>: The system temp folder.
    /// </para></li></ul><para>
    /// To verify the status of the exported files, use GetStreamSession. 
    /// </para><para>
    /// To delete the files, delete the object in the S3 bucket. 
    /// </para>
    /// </summary>
    [Cmdlet("Export", "GMLSStreamSessionFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams ExportStreamSessionFiles API operation.", Operation = new[] {"ExportStreamSessionFiles"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse))]
    [AWSCmdletOutput("None or Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse) be returned by specifying '-Select *'."
    )]
    public partial class ExportGMLSStreamSessionFileCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Format example: ARN-<c>arn:aws:gameliftstreams:us-west-2:123456789012:streamgroup/1AB2C3De4</c>
        /// or ID-<c>1AB2C3De4</c>. </para>
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
        
        #region Parameter OutputUri
        /// <summary>
        /// <para>
        /// <para> The S3 bucket URI where Amazon GameLift Streams uploads the set of compressed exported
        /// files for this stream session. Amazon GameLift Streams generates a ZIP file name based
        /// on the stream session metadata. Alternatively, you can provide a custom file name
        /// with a <c>.zip</c> file extension.</para><para> Example 1: If you provide an S3 URI called <c>s3://MyBucket/MyGame_Session1.zip</c>,
        /// then Amazon GameLift Streams will save the files at that location. </para><para> Example 2: If you provide an S3 URI called <c>s3://MyBucket/MyGameSessions_ExportedFiles/</c>,
        /// then Amazon GameLift Streams will save the files at <c>s3://MyBucket/MyGameSessions_ExportedFiles/YYYYMMDD-HHMMSS-appId-sg-Id-sessionId.zip</c>
        /// or another similar name. </para>
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
        public System.String OutputUri { get; set; }
        #endregion
        
        #region Parameter StreamSessionIdentifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream session resource.
        /// Format example: <c>1AB2C3De4</c>. </para>
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
        public System.String StreamSessionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-GMLSStreamSessionFile (ExportStreamSessionFiles)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse, ExportGMLSStreamSessionFileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputUri = this.OutputUri;
            #if MODULAR
            if (this.OutputUri == null && ParameterWasBound(nameof(this.OutputUri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamSessionIdentifier = this.StreamSessionIdentifier;
            #if MODULAR
            if (this.StreamSessionIdentifier == null && ParameterWasBound(nameof(this.StreamSessionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamSessionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GameLiftStreams.Model.ExportStreamSessionFilesRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.OutputUri != null)
            {
                request.OutputUri = cmdletContext.OutputUri;
            }
            if (cmdletContext.StreamSessionIdentifier != null)
            {
                request.StreamSessionIdentifier = cmdletContext.StreamSessionIdentifier;
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
        
        private Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.ExportStreamSessionFilesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "ExportStreamSessionFiles");
            try
            {
                #if DESKTOP
                return client.ExportStreamSessionFiles(request);
                #elif CORECLR
                return client.ExportStreamSessionFilesAsync(request).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.String OutputUri { get; set; }
            public System.String StreamSessionIdentifier { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.ExportStreamSessionFilesResponse, ExportGMLSStreamSessionFileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
