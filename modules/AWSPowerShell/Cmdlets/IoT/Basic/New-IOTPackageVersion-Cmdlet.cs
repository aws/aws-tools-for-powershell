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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a new version for an existing IoT software package.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreatePackageVersion</a>
    /// and <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">GetIndexingConfiguration</a>
    /// actions.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTPackageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreatePackageVersionResponse")]
    [AWSCmdlet("Calls the AWS IoT CreatePackageVersion API operation.", Operation = new[] {"CreatePackageVersion"}, SelectReturnType = typeof(Amazon.IoT.Model.CreatePackageVersionResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreatePackageVersionResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreatePackageVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTPackageVersionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to define a package version’s configuration. For example,
        /// the S3 file location, configuration options that are being sent to the device or fleet.</para><para>The combined size of all the attributes on a package version is limited to 3KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Artifact_S3Location_Bucket")]
        public System.String S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A summary of the package version being created. This can be used to outline the package's
        /// contents or purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3Location_Key
        /// <summary>
        /// <para>
        /// <para>The S3 key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Artifact_S3Location_Key")]
        public System.String S3Location_Key { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>The name of the associated software package.</para>
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
        public System.String PackageName { get; set; }
        #endregion
        
        #region Parameter Recipe
        /// <summary>
        /// <para>
        /// <para>The inline job document associated with a software package version used for a quick
        /// job deployment via IoT Jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recipe { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the package version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter S3Location_Version
        /// <summary>
        /// <para>
        /// <para>The S3 bucket version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Artifact_S3Location_Version")]
        public System.String S3Location_Version { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>The name of the new package version.</para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreatePackageVersionResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreatePackageVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VersionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VersionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VersionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VersionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTPackageVersion (CreatePackageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreatePackageVersionResponse, NewIOTPackageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VersionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3Location_Bucket = this.S3Location_Bucket;
            context.S3Location_Key = this.S3Location_Key;
            context.S3Location_Version = this.S3Location_Version;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.PackageName = this.PackageName;
            #if MODULAR
            if (this.PackageName == null && ParameterWasBound(nameof(this.PackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Recipe = this.Recipe;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.CreatePackageVersionRequest();
            
            
             // populate Artifact
            var requestArtifactIsNull = true;
            request.Artifact = new Amazon.IoT.Model.PackageVersionArtifact();
            Amazon.IoT.Model.S3Location requestArtifact_artifact_S3Location = null;
            
             // populate S3Location
            var requestArtifact_artifact_S3LocationIsNull = true;
            requestArtifact_artifact_S3Location = new Amazon.IoT.Model.S3Location();
            System.String requestArtifact_artifact_S3Location_s3Location_Bucket = null;
            if (cmdletContext.S3Location_Bucket != null)
            {
                requestArtifact_artifact_S3Location_s3Location_Bucket = cmdletContext.S3Location_Bucket;
            }
            if (requestArtifact_artifact_S3Location_s3Location_Bucket != null)
            {
                requestArtifact_artifact_S3Location.Bucket = requestArtifact_artifact_S3Location_s3Location_Bucket;
                requestArtifact_artifact_S3LocationIsNull = false;
            }
            System.String requestArtifact_artifact_S3Location_s3Location_Key = null;
            if (cmdletContext.S3Location_Key != null)
            {
                requestArtifact_artifact_S3Location_s3Location_Key = cmdletContext.S3Location_Key;
            }
            if (requestArtifact_artifact_S3Location_s3Location_Key != null)
            {
                requestArtifact_artifact_S3Location.Key = requestArtifact_artifact_S3Location_s3Location_Key;
                requestArtifact_artifact_S3LocationIsNull = false;
            }
            System.String requestArtifact_artifact_S3Location_s3Location_Version = null;
            if (cmdletContext.S3Location_Version != null)
            {
                requestArtifact_artifact_S3Location_s3Location_Version = cmdletContext.S3Location_Version;
            }
            if (requestArtifact_artifact_S3Location_s3Location_Version != null)
            {
                requestArtifact_artifact_S3Location.Version = requestArtifact_artifact_S3Location_s3Location_Version;
                requestArtifact_artifact_S3LocationIsNull = false;
            }
             // determine if requestArtifact_artifact_S3Location should be set to null
            if (requestArtifact_artifact_S3LocationIsNull)
            {
                requestArtifact_artifact_S3Location = null;
            }
            if (requestArtifact_artifact_S3Location != null)
            {
                request.Artifact.S3Location = requestArtifact_artifact_S3Location;
                requestArtifactIsNull = false;
            }
             // determine if request.Artifact should be set to null
            if (requestArtifactIsNull)
            {
                request.Artifact = null;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            if (cmdletContext.Recipe != null)
            {
                request.Recipe = cmdletContext.Recipe;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.IoT.Model.CreatePackageVersionResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreatePackageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreatePackageVersion");
            try
            {
                #if DESKTOP
                return client.CreatePackageVersion(request);
                #elif CORECLR
                return client.CreatePackageVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Location_Bucket { get; set; }
            public System.String S3Location_Key { get; set; }
            public System.String S3Location_Version { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String PackageName { get; set; }
            public System.String Recipe { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.IoT.Model.CreatePackageVersionResponse, NewIOTPackageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
