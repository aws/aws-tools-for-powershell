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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Imports a node package.
    /// </summary>
    [Cmdlet("New", "PANPackageImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Panorama CreatePackageImportJob API operation.", Operation = new[] {"CreatePackageImportJob"}, SelectReturnType = typeof(Amazon.Panorama.Model.CreatePackageImportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Panorama.Model.CreatePackageImportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Panorama.Model.CreatePackageImportJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPANPackageImportJobCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Location_BucketName
        /// <summary>
        /// <para>
        /// <para>A bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_PackageVersionInputConfig_S3Location_BucketName")]
        public System.String S3Location_BucketName { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Tags for the package import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Panorama.Model.JobResourceTags[] JobTag { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>A job type for the package import job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Panorama.PackageImportJobType")]
        public Amazon.Panorama.PackageImportJobType JobType { get; set; }
        #endregion
        
        #region Parameter PackageVersionOutputConfig_MarkLatest
        /// <summary>
        /// <para>
        /// <para>Indicates that the version is recommended for all users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_PackageVersionOutputConfig_MarkLatest")]
        public System.Boolean? PackageVersionOutputConfig_MarkLatest { get; set; }
        #endregion
        
        #region Parameter S3Location_ObjectKey
        /// <summary>
        /// <para>
        /// <para>An object key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_PackageVersionInputConfig_S3Location_ObjectKey")]
        public System.String S3Location_ObjectKey { get; set; }
        #endregion
        
        #region Parameter PackageVersionOutputConfig_PackageName
        /// <summary>
        /// <para>
        /// <para>The output's package name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_PackageVersionOutputConfig_PackageName")]
        public System.String PackageVersionOutputConfig_PackageName { get; set; }
        #endregion
        
        #region Parameter PackageVersionOutputConfig_PackageVersion
        /// <summary>
        /// <para>
        /// <para>The output's package version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_PackageVersionOutputConfig_PackageVersion")]
        public System.String PackageVersionOutputConfig_PackageVersion { get; set; }
        #endregion
        
        #region Parameter S3Location_Region
        /// <summary>
        /// <para>
        /// <para>The bucket's Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_PackageVersionInputConfig_S3Location_Region")]
        public System.String S3Location_Region { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client token for the package import job.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.CreatePackageImportJobResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.CreatePackageImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PANPackageImportJob (CreatePackageImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.CreatePackageImportJobResponse, NewPANPackageImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Location_BucketName = this.S3Location_BucketName;
            context.S3Location_ObjectKey = this.S3Location_ObjectKey;
            context.S3Location_Region = this.S3Location_Region;
            if (this.JobTag != null)
            {
                context.JobTag = new List<Amazon.Panorama.Model.JobResourceTags>(this.JobTag);
            }
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageVersionOutputConfig_MarkLatest = this.PackageVersionOutputConfig_MarkLatest;
            context.PackageVersionOutputConfig_PackageName = this.PackageVersionOutputConfig_PackageName;
            context.PackageVersionOutputConfig_PackageVersion = this.PackageVersionOutputConfig_PackageVersion;
            
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
            var request = new Amazon.Panorama.Model.CreatePackageImportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate InputConfig
            request.InputConfig = new Amazon.Panorama.Model.PackageImportJobInputConfig();
            Amazon.Panorama.Model.PackageVersionInputConfig requestInputConfig_inputConfig_PackageVersionInputConfig = null;
            
             // populate PackageVersionInputConfig
            var requestInputConfig_inputConfig_PackageVersionInputConfigIsNull = true;
            requestInputConfig_inputConfig_PackageVersionInputConfig = new Amazon.Panorama.Model.PackageVersionInputConfig();
            Amazon.Panorama.Model.S3Location requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location = null;
            
             // populate S3Location
            var requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3LocationIsNull = true;
            requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location = new Amazon.Panorama.Model.S3Location();
            System.String requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_BucketName = null;
            if (cmdletContext.S3Location_BucketName != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_BucketName = cmdletContext.S3Location_BucketName;
            }
            if (requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_BucketName != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location.BucketName = requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_BucketName;
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3LocationIsNull = false;
            }
            System.String requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_ObjectKey = null;
            if (cmdletContext.S3Location_ObjectKey != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_ObjectKey = cmdletContext.S3Location_ObjectKey;
            }
            if (requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_ObjectKey != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location.ObjectKey = requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_ObjectKey;
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3LocationIsNull = false;
            }
            System.String requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_Region = null;
            if (cmdletContext.S3Location_Region != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_Region = cmdletContext.S3Location_Region;
            }
            if (requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_Region != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location.Region = requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location_s3Location_Region;
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3LocationIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location should be set to null
            if (requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3LocationIsNull)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location = null;
            }
            if (requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location != null)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig.S3Location = requestInputConfig_inputConfig_PackageVersionInputConfig_inputConfig_PackageVersionInputConfig_S3Location;
                requestInputConfig_inputConfig_PackageVersionInputConfigIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_PackageVersionInputConfig should be set to null
            if (requestInputConfig_inputConfig_PackageVersionInputConfigIsNull)
            {
                requestInputConfig_inputConfig_PackageVersionInputConfig = null;
            }
            if (requestInputConfig_inputConfig_PackageVersionInputConfig != null)
            {
                request.InputConfig.PackageVersionInputConfig = requestInputConfig_inputConfig_PackageVersionInputConfig;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTags = cmdletContext.JobTag;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            
             // populate OutputConfig
            request.OutputConfig = new Amazon.Panorama.Model.PackageImportJobOutputConfig();
            Amazon.Panorama.Model.PackageVersionOutputConfig requestOutputConfig_outputConfig_PackageVersionOutputConfig = null;
            
             // populate PackageVersionOutputConfig
            var requestOutputConfig_outputConfig_PackageVersionOutputConfigIsNull = true;
            requestOutputConfig_outputConfig_PackageVersionOutputConfig = new Amazon.Panorama.Model.PackageVersionOutputConfig();
            System.Boolean? requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_MarkLatest = null;
            if (cmdletContext.PackageVersionOutputConfig_MarkLatest != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_MarkLatest = cmdletContext.PackageVersionOutputConfig_MarkLatest.Value;
            }
            if (requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_MarkLatest != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig.MarkLatest = requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_MarkLatest.Value;
                requestOutputConfig_outputConfig_PackageVersionOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageName = null;
            if (cmdletContext.PackageVersionOutputConfig_PackageName != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageName = cmdletContext.PackageVersionOutputConfig_PackageName;
            }
            if (requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageName != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig.PackageName = requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageName;
                requestOutputConfig_outputConfig_PackageVersionOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageVersion = null;
            if (cmdletContext.PackageVersionOutputConfig_PackageVersion != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageVersion = cmdletContext.PackageVersionOutputConfig_PackageVersion;
            }
            if (requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageVersion != null)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig.PackageVersion = requestOutputConfig_outputConfig_PackageVersionOutputConfig_packageVersionOutputConfig_PackageVersion;
                requestOutputConfig_outputConfig_PackageVersionOutputConfigIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_PackageVersionOutputConfig should be set to null
            if (requestOutputConfig_outputConfig_PackageVersionOutputConfigIsNull)
            {
                requestOutputConfig_outputConfig_PackageVersionOutputConfig = null;
            }
            if (requestOutputConfig_outputConfig_PackageVersionOutputConfig != null)
            {
                request.OutputConfig.PackageVersionOutputConfig = requestOutputConfig_outputConfig_PackageVersionOutputConfig;
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
        
        private Amazon.Panorama.Model.CreatePackageImportJobResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.CreatePackageImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "CreatePackageImportJob");
            try
            {
                #if DESKTOP
                return client.CreatePackageImportJob(request);
                #elif CORECLR
                return client.CreatePackageImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String S3Location_BucketName { get; set; }
            public System.String S3Location_ObjectKey { get; set; }
            public System.String S3Location_Region { get; set; }
            public List<Amazon.Panorama.Model.JobResourceTags> JobTag { get; set; }
            public Amazon.Panorama.PackageImportJobType JobType { get; set; }
            public System.Boolean? PackageVersionOutputConfig_MarkLatest { get; set; }
            public System.String PackageVersionOutputConfig_PackageName { get; set; }
            public System.String PackageVersionOutputConfig_PackageVersion { get; set; }
            public System.Func<Amazon.Panorama.Model.CreatePackageImportJobResponse, NewPANPackageImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
