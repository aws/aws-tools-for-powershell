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
using Amazon.AppStream;
using Amazon.AppStream.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates an app block.
    /// 
    ///  
    /// <para>
    /// App blocks are an Amazon AppStream 2.0 resource that stores the details about the
    /// virtual hard disk in an S3 bucket. It also stores the setup script with details about
    /// how to mount the virtual hard disk. The virtual hard disk includes the application
    /// binaries and other files necessary to launch your applications. Multiple applications
    /// can be assigned to a single app block.
    /// </para><para>
    /// This is only supported for Elastic fleets.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APSAppBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.AppBlock")]
    [AWSCmdlet("Calls the Amazon AppStream CreateAppBlock API operation.", Operation = new[] {"CreateAppBlock"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateAppBlockResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.AppBlock or Amazon.AppStream.Model.CreateAppBlockResponse",
        "This cmdlet returns an Amazon.AppStream.Model.AppBlock object.",
        "The service call response (type Amazon.AppStream.Model.CreateAppBlockResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAPSAppBlockCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the app block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the app block. This is not displayed to the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter PostSetupScriptDetails_ExecutableParameter
        /// <summary>
        /// <para>
        /// <para>The runtime parameters passed to the run path for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostSetupScriptDetails_ExecutableParameters")]
        public System.String PostSetupScriptDetails_ExecutableParameter { get; set; }
        #endregion
        
        #region Parameter SetupScriptDetails_ExecutableParameter
        /// <summary>
        /// <para>
        /// <para>The runtime parameters passed to the run path for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SetupScriptDetails_ExecutableParameters")]
        public System.String SetupScriptDetails_ExecutableParameter { get; set; }
        #endregion
        
        #region Parameter PostSetupScriptDetails_ExecutablePath
        /// <summary>
        /// <para>
        /// <para>The run path for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostSetupScriptDetails_ExecutablePath { get; set; }
        #endregion
        
        #region Parameter SetupScriptDetails_ExecutablePath
        /// <summary>
        /// <para>
        /// <para>The run path for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SetupScriptDetails_ExecutablePath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the app block.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PackagingType
        /// <summary>
        /// <para>
        /// <para>The packaging type of the app block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.PackagingType")]
        public Amazon.AppStream.PackagingType PackagingType { get; set; }
        #endregion
        
        #region Parameter PostSetupScriptDetails_ScriptS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostSetupScriptDetails_ScriptS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ScriptS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SetupScriptDetails_ScriptS3Location_S3Bucket")]
        public System.String ScriptS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter SourceS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
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
        public System.String SourceS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter PostSetupScriptDetails_ScriptS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>CUSTOM</c> PackagingType (Actions:
        /// CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>APPSTREAM2</c> PackagingType,
        /// and using an existing application package (VHD file). In this case, <c>S3Key</c> refers
        /// to the VHD file. If a new application package is required, then <c>S3Key</c> is not
        /// required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostSetupScriptDetails_ScriptS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter ScriptS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>CUSTOM</c> PackagingType (Actions:
        /// CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>APPSTREAM2</c> PackagingType,
        /// and using an existing application package (VHD file). In this case, <c>S3Key</c> refers
        /// to the VHD file. If a new application package is required, then <c>S3Key</c> is not
        /// required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SetupScriptDetails_ScriptS3Location_S3Key")]
        public System.String ScriptS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter SourceS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>CUSTOM</c> PackagingType (Actions:
        /// CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>APPSTREAM2</c> PackagingType,
        /// and using an existing application package (VHD file). In this case, <c>S3Key</c> refers
        /// to the VHD file. If a new application package is required, then <c>S3Key</c> is not
        /// required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the app block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PostSetupScriptDetails_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The run timeout, in seconds, for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostSetupScriptDetails_TimeoutInSeconds")]
        public System.Int32? PostSetupScriptDetails_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter SetupScriptDetails_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The run timeout, in seconds, for the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SetupScriptDetails_TimeoutInSeconds")]
        public System.Int32? SetupScriptDetails_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppBlock'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateAppBlockResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateAppBlockResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppBlock";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSAppBlock (CreateAppBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateAppBlockResponse, NewAPSAppBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackagingType = this.PackagingType;
            context.PostSetupScriptDetails_ExecutableParameter = this.PostSetupScriptDetails_ExecutableParameter;
            context.PostSetupScriptDetails_ExecutablePath = this.PostSetupScriptDetails_ExecutablePath;
            context.PostSetupScriptDetails_ScriptS3Location_S3Bucket = this.PostSetupScriptDetails_ScriptS3Location_S3Bucket;
            context.PostSetupScriptDetails_ScriptS3Location_S3Key = this.PostSetupScriptDetails_ScriptS3Location_S3Key;
            context.PostSetupScriptDetails_TimeoutInSecond = this.PostSetupScriptDetails_TimeoutInSecond;
            context.SetupScriptDetails_ExecutableParameter = this.SetupScriptDetails_ExecutableParameter;
            context.SetupScriptDetails_ExecutablePath = this.SetupScriptDetails_ExecutablePath;
            context.ScriptS3Location_S3Bucket = this.ScriptS3Location_S3Bucket;
            context.ScriptS3Location_S3Key = this.ScriptS3Location_S3Key;
            context.SetupScriptDetails_TimeoutInSecond = this.SetupScriptDetails_TimeoutInSecond;
            context.SourceS3Location_S3Bucket = this.SourceS3Location_S3Bucket;
            #if MODULAR
            if (this.SourceS3Location_S3Bucket == null && ParameterWasBound(nameof(this.SourceS3Location_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceS3Location_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceS3Location_S3Key = this.SourceS3Location_S3Key;
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
            var request = new Amazon.AppStream.Model.CreateAppBlockRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PackagingType != null)
            {
                request.PackagingType = cmdletContext.PackagingType;
            }
            
             // populate PostSetupScriptDetails
            var requestPostSetupScriptDetailsIsNull = true;
            request.PostSetupScriptDetails = new Amazon.AppStream.Model.ScriptDetails();
            System.String requestPostSetupScriptDetails_postSetupScriptDetails_ExecutableParameter = null;
            if (cmdletContext.PostSetupScriptDetails_ExecutableParameter != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ExecutableParameter = cmdletContext.PostSetupScriptDetails_ExecutableParameter;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ExecutableParameter != null)
            {
                request.PostSetupScriptDetails.ExecutableParameters = requestPostSetupScriptDetails_postSetupScriptDetails_ExecutableParameter;
                requestPostSetupScriptDetailsIsNull = false;
            }
            System.String requestPostSetupScriptDetails_postSetupScriptDetails_ExecutablePath = null;
            if (cmdletContext.PostSetupScriptDetails_ExecutablePath != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ExecutablePath = cmdletContext.PostSetupScriptDetails_ExecutablePath;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ExecutablePath != null)
            {
                request.PostSetupScriptDetails.ExecutablePath = requestPostSetupScriptDetails_postSetupScriptDetails_ExecutablePath;
                requestPostSetupScriptDetailsIsNull = false;
            }
            System.Int32? requestPostSetupScriptDetails_postSetupScriptDetails_TimeoutInSecond = null;
            if (cmdletContext.PostSetupScriptDetails_TimeoutInSecond != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_TimeoutInSecond = cmdletContext.PostSetupScriptDetails_TimeoutInSecond.Value;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_TimeoutInSecond != null)
            {
                request.PostSetupScriptDetails.TimeoutInSeconds = requestPostSetupScriptDetails_postSetupScriptDetails_TimeoutInSecond.Value;
                requestPostSetupScriptDetailsIsNull = false;
            }
            Amazon.AppStream.Model.S3Location requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location = null;
            
             // populate ScriptS3Location
            var requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3LocationIsNull = true;
            requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Bucket = null;
            if (cmdletContext.PostSetupScriptDetails_ScriptS3Location_S3Bucket != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Bucket = cmdletContext.PostSetupScriptDetails_ScriptS3Location_S3Bucket;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Bucket != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location.S3Bucket = requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Bucket;
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3LocationIsNull = false;
            }
            System.String requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Key = null;
            if (cmdletContext.PostSetupScriptDetails_ScriptS3Location_S3Key != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Key = cmdletContext.PostSetupScriptDetails_ScriptS3Location_S3Key;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Key != null)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location.S3Key = requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location_postSetupScriptDetails_ScriptS3Location_S3Key;
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3LocationIsNull = false;
            }
             // determine if requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location should be set to null
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3LocationIsNull)
            {
                requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location = null;
            }
            if (requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location != null)
            {
                request.PostSetupScriptDetails.ScriptS3Location = requestPostSetupScriptDetails_postSetupScriptDetails_ScriptS3Location;
                requestPostSetupScriptDetailsIsNull = false;
            }
             // determine if request.PostSetupScriptDetails should be set to null
            if (requestPostSetupScriptDetailsIsNull)
            {
                request.PostSetupScriptDetails = null;
            }
            
             // populate SetupScriptDetails
            var requestSetupScriptDetailsIsNull = true;
            request.SetupScriptDetails = new Amazon.AppStream.Model.ScriptDetails();
            System.String requestSetupScriptDetails_setupScriptDetails_ExecutableParameter = null;
            if (cmdletContext.SetupScriptDetails_ExecutableParameter != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ExecutableParameter = cmdletContext.SetupScriptDetails_ExecutableParameter;
            }
            if (requestSetupScriptDetails_setupScriptDetails_ExecutableParameter != null)
            {
                request.SetupScriptDetails.ExecutableParameters = requestSetupScriptDetails_setupScriptDetails_ExecutableParameter;
                requestSetupScriptDetailsIsNull = false;
            }
            System.String requestSetupScriptDetails_setupScriptDetails_ExecutablePath = null;
            if (cmdletContext.SetupScriptDetails_ExecutablePath != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ExecutablePath = cmdletContext.SetupScriptDetails_ExecutablePath;
            }
            if (requestSetupScriptDetails_setupScriptDetails_ExecutablePath != null)
            {
                request.SetupScriptDetails.ExecutablePath = requestSetupScriptDetails_setupScriptDetails_ExecutablePath;
                requestSetupScriptDetailsIsNull = false;
            }
            System.Int32? requestSetupScriptDetails_setupScriptDetails_TimeoutInSecond = null;
            if (cmdletContext.SetupScriptDetails_TimeoutInSecond != null)
            {
                requestSetupScriptDetails_setupScriptDetails_TimeoutInSecond = cmdletContext.SetupScriptDetails_TimeoutInSecond.Value;
            }
            if (requestSetupScriptDetails_setupScriptDetails_TimeoutInSecond != null)
            {
                request.SetupScriptDetails.TimeoutInSeconds = requestSetupScriptDetails_setupScriptDetails_TimeoutInSecond.Value;
                requestSetupScriptDetailsIsNull = false;
            }
            Amazon.AppStream.Model.S3Location requestSetupScriptDetails_setupScriptDetails_ScriptS3Location = null;
            
             // populate ScriptS3Location
            var requestSetupScriptDetails_setupScriptDetails_ScriptS3LocationIsNull = true;
            requestSetupScriptDetails_setupScriptDetails_ScriptS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Bucket = null;
            if (cmdletContext.ScriptS3Location_S3Bucket != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Bucket = cmdletContext.ScriptS3Location_S3Bucket;
            }
            if (requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Bucket != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ScriptS3Location.S3Bucket = requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Bucket;
                requestSetupScriptDetails_setupScriptDetails_ScriptS3LocationIsNull = false;
            }
            System.String requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Key = null;
            if (cmdletContext.ScriptS3Location_S3Key != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Key = cmdletContext.ScriptS3Location_S3Key;
            }
            if (requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Key != null)
            {
                requestSetupScriptDetails_setupScriptDetails_ScriptS3Location.S3Key = requestSetupScriptDetails_setupScriptDetails_ScriptS3Location_scriptS3Location_S3Key;
                requestSetupScriptDetails_setupScriptDetails_ScriptS3LocationIsNull = false;
            }
             // determine if requestSetupScriptDetails_setupScriptDetails_ScriptS3Location should be set to null
            if (requestSetupScriptDetails_setupScriptDetails_ScriptS3LocationIsNull)
            {
                requestSetupScriptDetails_setupScriptDetails_ScriptS3Location = null;
            }
            if (requestSetupScriptDetails_setupScriptDetails_ScriptS3Location != null)
            {
                request.SetupScriptDetails.ScriptS3Location = requestSetupScriptDetails_setupScriptDetails_ScriptS3Location;
                requestSetupScriptDetailsIsNull = false;
            }
             // determine if request.SetupScriptDetails should be set to null
            if (requestSetupScriptDetailsIsNull)
            {
                request.SetupScriptDetails = null;
            }
            
             // populate SourceS3Location
            var requestSourceS3LocationIsNull = true;
            request.SourceS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestSourceS3Location_sourceS3Location_S3Bucket = null;
            if (cmdletContext.SourceS3Location_S3Bucket != null)
            {
                requestSourceS3Location_sourceS3Location_S3Bucket = cmdletContext.SourceS3Location_S3Bucket;
            }
            if (requestSourceS3Location_sourceS3Location_S3Bucket != null)
            {
                request.SourceS3Location.S3Bucket = requestSourceS3Location_sourceS3Location_S3Bucket;
                requestSourceS3LocationIsNull = false;
            }
            System.String requestSourceS3Location_sourceS3Location_S3Key = null;
            if (cmdletContext.SourceS3Location_S3Key != null)
            {
                requestSourceS3Location_sourceS3Location_S3Key = cmdletContext.SourceS3Location_S3Key;
            }
            if (requestSourceS3Location_sourceS3Location_S3Key != null)
            {
                request.SourceS3Location.S3Key = requestSourceS3Location_sourceS3Location_S3Key;
                requestSourceS3LocationIsNull = false;
            }
             // determine if request.SourceS3Location should be set to null
            if (requestSourceS3LocationIsNull)
            {
                request.SourceS3Location = null;
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
        
        private Amazon.AppStream.Model.CreateAppBlockResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateAppBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateAppBlock");
            try
            {
                return client.CreateAppBlockAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppStream.PackagingType PackagingType { get; set; }
            public System.String PostSetupScriptDetails_ExecutableParameter { get; set; }
            public System.String PostSetupScriptDetails_ExecutablePath { get; set; }
            public System.String PostSetupScriptDetails_ScriptS3Location_S3Bucket { get; set; }
            public System.String PostSetupScriptDetails_ScriptS3Location_S3Key { get; set; }
            public System.Int32? PostSetupScriptDetails_TimeoutInSecond { get; set; }
            public System.String SetupScriptDetails_ExecutableParameter { get; set; }
            public System.String SetupScriptDetails_ExecutablePath { get; set; }
            public System.String ScriptS3Location_S3Bucket { get; set; }
            public System.String ScriptS3Location_S3Key { get; set; }
            public System.Int32? SetupScriptDetails_TimeoutInSecond { get; set; }
            public System.String SourceS3Location_S3Bucket { get; set; }
            public System.String SourceS3Location_S3Key { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateAppBlockResponse, NewAPSAppBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppBlock;
        }
        
    }
}
