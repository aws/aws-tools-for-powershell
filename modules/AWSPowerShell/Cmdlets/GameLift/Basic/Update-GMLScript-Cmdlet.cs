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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Updates Realtime script metadata and content.
    /// 
    ///  
    /// <para>
    /// To update script metadata, specify the script ID and provide updated name and/or version
    /// values. 
    /// </para><para>
    /// To update script content, provide an updated zip file by pointing to either a local
    /// file or an Amazon S3 bucket location. You can use either method regardless of how
    /// the original script was uploaded. Use the <i>Version</i> parameter to track updates
    /// to the script.
    /// </para><para>
    /// If the call is successful, the updated metadata is stored in the script record and
    /// a revised script is uploaded to the Amazon GameLift service. Once the script is updated
    /// and acquired by a fleet instance, the new version is used for all new game sessions.
    /// 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/realtime-intro.html">Amazon
    /// GameLift Realtime Servers</a></para><para><b>Related actions</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLScript", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.Script")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateScript API operation.", Operation = new[] {"UpdateScript"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateScriptResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.Script or Amazon.GameLift.Model.UpdateScriptResponse",
        "This cmdlet returns an Amazon.GameLift.Model.Script object.",
        "The service call response (type Amazon.GameLift.Model.UpdateScriptResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLScriptCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StorageLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 bucket identifier. Thename of the S3 bucket.</para><note><para>Amazon GameLift doesn't support uploading from Amazon S3 buckets with names that contain
        /// a dot (.).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter StorageLocation_Key
        /// <summary>
        /// <para>
        /// <para>The name of the zip file that contains the build files or script files. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLocation_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a script. Script names don't need to be
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StorageLocation_ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the file, if object versioning is turned on for the bucket. Amazon
        /// GameLift uses this information when retrieving files from an S3 bucket that you own.
        /// Use this parameter to specify a specific version of the file. If not set, the latest
        /// version of the file is retrieved. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLocation_ObjectVersion { get; set; }
        #endregion
        
        #region Parameter StorageLocation_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// for an IAM role that allows Amazon GameLift to access the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLocation_RoleArn { get; set; }
        #endregion
        
        #region Parameter ScriptId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Realtime script to update. You can use either the script
        /// ID or ARN value.</para>
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
        public System.String ScriptId { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>Version information associated with a build or script. Version strings don't need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter ZipFile
        /// <summary>
        /// <para>
        /// <para>A data object containing your Realtime scripts and dependencies as a zip file. The
        /// zip file can have one or multiple files. Maximum size of a zip file is 5 MB.</para><para>When using the Amazon Web Services CLI tool to create a script, this parameter is
        /// set to the zip file name. It must be prepended with the string "fileb://" to indicate
        /// that the file data is a binary object. For example: <code>--zip-file fileb://myRealtimeScript.zip</code>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Script'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateScriptResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateScriptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Script";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScriptId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScriptId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScriptId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScriptId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLScript (UpdateScript)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateScriptResponse, UpdateGMLScriptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScriptId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.ScriptId = this.ScriptId;
            #if MODULAR
            if (this.ScriptId == null && ParameterWasBound(nameof(this.ScriptId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScriptId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLocation_Bucket = this.StorageLocation_Bucket;
            context.StorageLocation_Key = this.StorageLocation_Key;
            context.StorageLocation_ObjectVersion = this.StorageLocation_ObjectVersion;
            context.StorageLocation_RoleArn = this.StorageLocation_RoleArn;
            context.Version = this.Version;
            context.ZipFile = this.ZipFile;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.GameLift.Model.UpdateScriptRequest();
                
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.ScriptId != null)
                {
                    request.ScriptId = cmdletContext.ScriptId;
                }
                
                 // populate StorageLocation
                var requestStorageLocationIsNull = true;
                request.StorageLocation = new Amazon.GameLift.Model.S3Location();
                System.String requestStorageLocation_storageLocation_Bucket = null;
                if (cmdletContext.StorageLocation_Bucket != null)
                {
                    requestStorageLocation_storageLocation_Bucket = cmdletContext.StorageLocation_Bucket;
                }
                if (requestStorageLocation_storageLocation_Bucket != null)
                {
                    request.StorageLocation.Bucket = requestStorageLocation_storageLocation_Bucket;
                    requestStorageLocationIsNull = false;
                }
                System.String requestStorageLocation_storageLocation_Key = null;
                if (cmdletContext.StorageLocation_Key != null)
                {
                    requestStorageLocation_storageLocation_Key = cmdletContext.StorageLocation_Key;
                }
                if (requestStorageLocation_storageLocation_Key != null)
                {
                    request.StorageLocation.Key = requestStorageLocation_storageLocation_Key;
                    requestStorageLocationIsNull = false;
                }
                System.String requestStorageLocation_storageLocation_ObjectVersion = null;
                if (cmdletContext.StorageLocation_ObjectVersion != null)
                {
                    requestStorageLocation_storageLocation_ObjectVersion = cmdletContext.StorageLocation_ObjectVersion;
                }
                if (requestStorageLocation_storageLocation_ObjectVersion != null)
                {
                    request.StorageLocation.ObjectVersion = requestStorageLocation_storageLocation_ObjectVersion;
                    requestStorageLocationIsNull = false;
                }
                System.String requestStorageLocation_storageLocation_RoleArn = null;
                if (cmdletContext.StorageLocation_RoleArn != null)
                {
                    requestStorageLocation_storageLocation_RoleArn = cmdletContext.StorageLocation_RoleArn;
                }
                if (requestStorageLocation_storageLocation_RoleArn != null)
                {
                    request.StorageLocation.RoleArn = requestStorageLocation_storageLocation_RoleArn;
                    requestStorageLocationIsNull = false;
                }
                 // determine if request.StorageLocation should be set to null
                if (requestStorageLocationIsNull)
                {
                    request.StorageLocation = null;
                }
                if (cmdletContext.Version != null)
                {
                    request.Version = cmdletContext.Version;
                }
                if (cmdletContext.ZipFile != null)
                {
                    _ZipFileStream = new System.IO.MemoryStream(cmdletContext.ZipFile);
                    request.ZipFile = _ZipFileStream;
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
            finally
            {
                if( _ZipFileStream != null)
                {
                    _ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GameLift.Model.UpdateScriptResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateScriptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateScript");
            try
            {
                #if DESKTOP
                return client.UpdateScript(request);
                #elif CORECLR
                return client.UpdateScriptAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String ScriptId { get; set; }
            public System.String StorageLocation_Bucket { get; set; }
            public System.String StorageLocation_Key { get; set; }
            public System.String StorageLocation_ObjectVersion { get; set; }
            public System.String StorageLocation_RoleArn { get; set; }
            public System.String Version { get; set; }
            public byte[] ZipFile { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateScriptResponse, UpdateGMLScriptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Script;
        }
        
    }
}
