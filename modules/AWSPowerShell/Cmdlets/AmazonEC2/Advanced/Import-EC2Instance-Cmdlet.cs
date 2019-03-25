#if DESKTOP
/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.EC2.Import;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// <b>NOTE: This cmdlet has been deprecated and will be removed in a future release. Importing virtual machines and disk images
    /// to Amazon EC2 is now supported with the following cmdlets:</b>
    /// <ul>
    /// <li>Import-EC2Image</li>
    /// <li>Import-EC2Snapshot</li>
    /// <li>Get-EC2ImportImageTask</li>
    /// <li>Get-EC2ImportSnapshotTask</li>
    /// <li>Stop-EC2ImportTask</li>
    /// </ul>
    /// <br/>
    /// </para>
    /// <para>
    /// Uploads and converts a virtual machine image into a new Amazon EC2 instance or uploads the 
    /// virtual image artifacts and generated import manifest, pending a request to begin import conversion at a later time.
    /// </para>
    /// <para>
    /// With its default settings the cmdlet uploads the virtual machine image file to Amazon S3 as a series of individual
    /// S3 objects and creates a manifest to control the subsequent image conversion yielding an EC2 instance. 
    /// Once upload of the artifacts is complete the cmdlet sends a request to EC2 to begin the image conversion. 
    /// This mode yields a ConversionTask object that can be used to monitor conversion progress using the 
    /// Get-EC2ConversionTask cmdlet or stop the in-flight conversion with Stop-EC2ConversionTask.
    /// </para>
    /// <para>
    /// If run with the -UploadOnly switch the cmdlet creates the import manifest for the machine image and uploads it together 
    /// with the series of parts representing the virtual machine image file into Amazon S3, but does not initiate the conversion. 
    /// In this mode the S3 object key of the uploaded manifest is output. Import conversion of the artifacts to an EC2 instance 
    /// can be started at a later time by re-executing the cmdlet with the -ManifestFileKey parameter and the name of the bucket 
    /// holding the artifacts.
    /// </para>
    /// <para>
    /// Note that if the upload of the image file fails, any successfully upload content together with the import manifest is retained
    /// by default in the specified bucket. This enables the cmdlet to be re-executed in 'resume' mode with the -Resume
    /// parameter to continue upload of the image file. If this behavior is not desired and content uploaded to the bucket before
    /// the failure occurred should be deleted, use the -RollbackOnUploadFailure switch.
    /// </para>
    /// <para>
    /// For more information about importing machine images and disk volumes into Amazon EC2, see 
    /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instances_of_your_vm.html">Importing and Exporting Instances</a>
    /// in the Amazon EC2 User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "EC2Instance", DefaultParameterSetName = ParamSet_Default)]
    [OutputType("Amazon.EC2.Model.ConversionTask", "System.String")]
    [AWSCmdlet("Uploads a virtual machine image file to Amazon S3 and optionally requests import conversion to an Amazon EC2 instance.")]
    [AWSClientCmdlet("Amazon Elastic Compute Cloud", "EC2", "2014-06-15")]
    [AWSCmdletOutput("Amazon.EC2.Model.ConversionTask",
        "This object contains the conversion task id of the import, assigned by Amazon EC2. "
            + "This can be used to monitor the conversion or subsequently cancel it using Cancel-EC2ConversionTask.",
        "The service call response (type Amazon.EC2.Model.ImportInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack (if only one manifest or image was imported).")]
    [AWSCmdletOutput("System.String",
        "Contains the Amazon S3 object key of the import manifest file that was created and uploaded by the cmdlet. "
            + "This value is returned when the cmdlet is executed with the -UploadOnly switch. "
            + "Use this value with the -ManifestFileKey parameter to request conversion to an Amazon EC2 instance at a later time."
    )]
    public class ImportEC2InstanceCmdlet : EC2ImportCmdletsBase, IExecutor
    {
        #region Parameter ImageFile
        /// <summary>
        /// Filename of the virtual machine disk image file to uploaded to
        /// Amazon S3 and imported into Amazon EC2. The cmdlet will perform the upload,
        /// manifest creation and presigned url generation and subsequent launch of the
        /// import conversion task returning a ConversionTask instance for progress
        /// monitoring to the pipeline.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ParamSet_Default)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ParamSet_UploadOnly)]
        public System.String ImageFile { get; set; }
        #endregion

        #region Parameter UploadOnly
        /// <summary>
        /// If set the cmdlet constructs the import manifest and uploads it plus the image
        /// file artifacts to Amazon S3 but does not request import conversion be started. 
        /// The S3 key of the uploaded manifest file is output to the pipeline. This key can 
        /// be used subsequently as the value for the -ManifestFileKey parameter.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_UploadOnly)]
        public SwitchParameter UploadOnly { get; set; }
        #endregion

        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// The file format of the disk image. If a value is not specified the cmdlet
        /// will attempt to infer it from the extension of the image file.
        /// </para>
        /// <para>
        /// Valid values: VMDK, RAW, VHD.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public System.String FileFormat { get; set; }
        #endregion

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the Amazon S3 bucket that will, or does, contain the manifest and image 
        /// file artifacts. If the bucket does not exist an attempt will be made to create it
        /// before the artifacts are uploaded.
        /// </para>
        /// <para>
        /// For bucket creation to succeed, the bucket name must not already exist (bucket names
        /// are global).
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter KeyPrefix
        /// <summary>
        /// Optional prefix for the manifest and image file objects within the Amazon S3 bucket.
        /// The manifest and image file artifacts will be uploaded using keys consisting of this
        /// prefix and a generated GUID.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public System.String KeyPrefix { get; set; }
        #endregion

        #region Parameter ManifestFileKey
        /// <summary>
        /// <para>
        /// If specified, the import process will be be started using a collection of
        /// manifests and image file artifacts that have been successfully uploaded 
        /// previously to Amazon S3 (using the -UploadOnly switch). The collection of 
        /// ConversionTask objects resulting from the operation are emitted to the pipeline.
        /// </para>
        /// <para>
        /// The parameter value is a collection of S3 object keys to existing manifest files.
        /// These keys are output when the cmdlet is run specifying the -UploadOnly switch
        /// or if an error occurrs when requesting import conversion be started (this allows
        /// you to re-start a conversion that failed due to a parameter error without uploading
        /// the image file(s) again.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromManifest)]
        public System.String[] ManifestFileKey { get; set; }
        #endregion

        #region Parameter Description
        /// <summary>
        /// <para>
        /// An optional comment describing the image. This comment is returned with the associated 
        /// conversion task during enumeration with the Get-EC2ConversionTask cmdlet.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public System.String Description { get; set; }
        #endregion

        #region Parameter VolumeSize
        /// <summary>
        /// <para>
        /// The size of the Amazon EBS volume, in GiB (2^30 bytes), that will hold the converted image. If not 
        /// specified it will be calculated from the size of the image file, rounded up to the nearest GiB.
        /// </para>
        /// <para>
        /// Note: images intended for use as Amazon EC2 boot volumes must be a minimum of 8GiB in size.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public System.Int32 VolumeSize { get; set; }
        #endregion

        #region Parameter UploadThreadCount
        /// <summary>
        /// Specifies the maximum number of threads to use to upload the image file parts to
        /// Amazon S3. Each thread will consume a minimum of 10MB of memory to handle the part
        /// data.
        /// Default: 10. Maximum: 30.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        [ValidateRange(1, DiskImageImporter.MaxUploadThreads)]
        [Alias("UploadThreads")]
        public System.Int32 UploadThreadCount
        {
            get { return _uploadThreads; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Expected value between 1 and " + DiskImageImporter.MaxUploadThreads);

                _uploadThreads = value <= DiskImageImporter.MaxUploadThreads
                                            ? DiskImageImporter.DefaultUploadThreads : value;
            }
        }
        #endregion

        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// The architecture of the image. Using this option ensures that your image is imported as the expected instance type. 
        /// </para>
        /// <para>
        /// <b>Constraints:</b>
        /// <list type="definition"><item><term>Allowed Values </term><description>i386, x86_64</description></item></list>
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_Architecture")]
        public Amazon.EC2.ArchitectureValues Architecture { get; set; }
        #endregion

        #region Parameter AvailabilityZone
        /// <summary>
        /// The Availability Zone to launch the instance into.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_Placement_AvailabilityZone")]
        public System.String AvailabilityZone { get; set; }
        #endregion

        #region Parameter Group
        /// <summary>
        /// The security group within which the instances should be run. Determines the ingress firewall rules that are
        /// applied to the launched instances.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_SecurityGroup", "LaunchSpecification_GroupNames")]
        public System.String[] Group { get; set; }
        #endregion

        #region Parameter InstanceInitiatedShutdownBehavior
        /// <summary>
        /// <para>
        /// Indicates whether an instance stops or terminates when you initiate shutdown from the within the instance 
        /// (using the operating system command for system shutdown).        
        /// </para>
        /// <para>
        /// <b>Constraints:</b>
        /// <list type="definition"><item><term>Allowed Values </term><description>stop, terminate</description></item></list>
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_InstanceInitiatedShutdownBehavior")]
        public System.String InstanceInitiatedShutdownBehavior { get; set; }
        #endregion

        #region Parameter InstanceType
        /// <summary>
        /// The type of instance to be launched. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance Types</a>
        /// in the Amazon Elastic Compute Cloud User Guide. For more information about the Linux instance types you can import, see
        /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/VMImportPrerequisites.html">Before You Get Started</a> in the Amazon Elastic Compute Cloud User Guide.        
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_Default)]
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_InstanceType")]
        public Amazon.EC2.InstanceType InstanceType { get; set; }
        #endregion

        #region Parameter Monitor
        /// <summary>
        /// Enables monitoring of the specified instances.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_Monitoring_Enabled", "LaunchSpecification_Monitoring")]
        public SwitchParameter Monitor { get; set; }
        #endregion

        string _platform = "Windows";

        #region Parameter Platform
        /// <summary>
        /// <para>
        /// The operating system of the instance. Default: Windows.
        /// </para>
        /// <para>
        /// <b>Constraints:</b>
        /// <list type="definition"><item><term>Allowed Values </term><description>Windows, Linux</description></item></list>
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        public System.String Platform
        {
            get { return _platform; } 
            set { _platform = value; }
        }
        #endregion

        #region Parameter PrivateIpAddress
        /// <summary>
        /// [EC2-VPC] The specific IP address within subnet to use for the instance.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_PrivateIpAddress")]
        public System.String PrivateIpAddress { get; set; }
        #endregion

        #region Parameter SubnetId
        /// <summary>
        /// [EC2-VPC] The ID of the subnet into which you're launching the instance.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        [Alias("LaunchSpecification_SubnetId")]
        public System.String SubnetId { get; set; }
        #endregion

        #region Parameter AdditionalInfo
        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_FromManifest)]
        public System.String AdditionalInfo { get; set; }
        #endregion

        #region Parameter Resume
        /// <summary>
        /// <para>
        /// If set, resumes a previous upload that was abandoned due to failure to upload one or
        /// more parts of the image file. Resuming an import applies only to the upload of the
        /// image artifacts. If Amazon EC2 returns an error from the resulting conversion you
        /// must start a new upload request to correct the issue.
        /// </para>
        /// <para>
        /// Note that if the cmdlet is run with the -RollbackOnUploadError switch set, resumption 
        /// of the upload is not possible since the bucket contents will have been rolled back to
        /// delete the partially uploaded artifacts.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public SwitchParameter Resume { get; set; }
        #endregion

        #region Parameter RollbackOnUploadError
        /// <summary>
        /// If set and the image file fails to upload, the successfully uploaded parts
        /// and the manifest are removed automatically from S3 to avoid storage charges
        /// for potentially orphaned objects. By default the uploaded content is retained
        /// after error so that the cmdlet can be re-executed with the Resume
        /// parameter to resume upload of the failed content.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        public SwitchParameter RollbackOnUploadError { get; set; }
        #endregion

        #region Parameter UrlExpiration
        /// <summary>
        /// <para>
        /// The validity period (in days) for the signed Amazon S3 URLs that allow Amazon EC2 to 
        /// access the manifest.
        /// Default: 30 days.
        /// </para>
        /// <remarks>
        /// Note that for AWS regions requiring Signature Version 4 request signing, the maximum 
        /// period is 7 days. Parameter values exceeding 7 are ignored for these regions.
        /// </remarks>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Default)]
        [Parameter(ParameterSetName = ParamSet_UploadOnly)]
        [Alias("Expires,UrlExpirationInDays")] // 'Expires' for compat with EC2 CLI 
        public System.Int32 UrlExpiration
        {
            get { return _urlExpiryInDays; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("UrlExpiration", "Expected a value of 1 or greater.");
                _urlExpiryInDays = value;
            }
        }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            WriteWarning("This cmdlet has been deprecated and will be removed in a future release. Please use the replacement Import-EC2Image cmdlet.");

            var output = Execute(CreateContext()) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            return ParameterSetName.Equals(ParamSet_FromManifest)
                ? ImportFromExistingArtifacts(context as ImportInstanceCmdletContext)
                : ImportFromNewArtifacts(context as ImportInstanceCmdletContext, UploadOnly.IsPresent);
        }

        private CmdletOutput ImportFromExistingArtifacts(ImportInstanceCmdletContext context)
        {
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            try
            {
                var conversionTasks = new List<ConversionTask>();
                ImportInstanceResponse response = null; // only output if one manifest file was specified

                foreach (var manifestFileKey in context.ManifestFileKey)
                {
                    var importHelper = DiskImageImporter.FromManifest(context.Credentials,
                                                                      context.Region,
                                                                      context.BucketName,
                                                                      manifestFileKey,
                                                                      false);

                    var diskImage = importHelper.PopulateDiskImage(manifestFileKey, context.Description);
                    var launchSpecification
                        = DiskImageImporter.PopulateLaunchSpecificationInstance(context.PopulateLaunchConfiguration());

                    var request = new ImportInstanceRequest
                    {
                        Description = string.IsNullOrEmpty(context.Description) ? null : context.Description,
                        LaunchSpecification = launchSpecification,
                        Platform = string.IsNullOrEmpty(context.Platform) ? null : context.Platform
                    };

                    request.DiskImages.Add(diskImage);

                    response = CallAWSServiceOperation(client, request);
                    conversionTasks.Add(response.ConversionTask);
                }

                output = new CmdletOutput
                {
                    PipelineOutput = conversionTasks,
                    ServiceResponse = context.ManifestFileKey.Length == 1 ? response : null
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }

            return output;
        }

        private CmdletOutput ImportFromNewArtifacts(ImportInstanceCmdletContext context, bool uploadOnly)
        {
            var errorsDetected = false;
            CmdletOutput output = null;
            try
            {
                DiskImageImporter importHelper;
                if (!context.Resume)
                {
                    importHelper = new DiskImageImporter(context.Credentials, context.Region, context.BucketName)
                    {
                        UrlExpirationInDays = context.UrlExpirationInDays
                    };
                }
                else
                {
                    var manifestKey = ReadManifestKeyFromMemo(context.ImageFile, context.BucketName);
                    importHelper = DiskImageImporter.FromManifest(context.Credentials,
                                                                  context.Region,
                                                                  context.BucketName,
                                                                  manifestKey,
                                                                  true);
                }

                importHelper.UploadThreads = context.UploadThreads;
                importHelper.RollbackOnUploadError = context.RollbackOnUploadError;

                try
                {
                    var manifestKey 
                        = importHelper.Upload(context.ImageFile,
                                              context.FileFormat,
                                              context.VolumeSize,
                                              context.KeyPrefix,
                                              UpdateImportProgress,
                                              context.Resume);
                    if (uploadOnly)
                    {
                        output = new CmdletOutput
                        {
                            PipelineOutput = manifestKey
                        };
                    }
                    else
                    {
                        var response = importHelper.StartInstanceConversion(context.PopulateLaunchConfiguration());
                        output = new CmdletOutput
                        {
                            PipelineOutput = response.ConversionTask,
                            ServiceResponse = response
                        };
                    }

                    CleanManifestMemoFile(context.ImageFile, context.BucketName);
                }
                catch (DiskImageImporterException e)
                {
                    var msg = HandleImportError(importHelper, e, context.RollbackOnUploadError);
                    throw new Exception(msg, e);
                }
            }
            catch (Exception e)
            {
                output = new CmdletOutput {ErrorResponse = e};
                errorsDetected = true;
            }
            finally
            {
                var msg = errorsDetected
                    ? GenericFailedWithErrors
                    : uploadOnly ? GenericUploadOnlySucceeded : GenericUploadAndConvertSucceeded;

                this.WriteProgressCompleteRecord(ProgressActivity, msg);
            }

            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            this.ImageFile = ResolveImageFilePath(this.ImageFile);
            ValidateArguments();

            var context = new ImportInstanceCmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName,
                ImageFile = this.ImageFile,
                KeyPrefix = this.KeyPrefix,
                ManifestFileKey = this.ManifestFileKey,
                Architecture = this.Architecture,
                AvailabilityZone = this.AvailabilityZone,
                Group = this.Group,
                InstanceType = this.InstanceType,
                Monitor = this.Monitor.IsPresent,
                Platform = this.Platform,
                PrivateIpAddress = this.PrivateIpAddress,
                SubnetId = this.SubnetId,
                FileFormat = this.FileFormat,
                Description = this.Description,
                UploadThreads = this.UploadThreadCount,
                Resume = this.Resume.IsPresent,
                RollbackOnUploadError = this.RollbackOnUploadError.IsPresent,
                AdditionalInfo = this.AdditionalInfo,
                UrlExpirationInDays = this.UrlExpiration
            };


            if (this.VolumeSize > 0)
                context.VolumeSize = this.VolumeSize;

            if (!string.IsNullOrEmpty(this.InstanceInitiatedShutdownBehavior))
                context.InstanceInitiatedShutdownBehavior = this.InstanceInitiatedShutdownBehavior;
            /*
            try
            {
                context.UserData = AmazonEC2Helper.LoadUserData(this.UserData, this.UserDataFile, this.EncodeUserData);
            }
            catch (IOException e)
            {
                ThrowArgumentError("Error attempting to access UserDataFile.", UserDataFile, e);
            }
            */
            return context;
        }

        protected override void ValidateArguments()
        {
            if (!this.ParameterSetName.Equals(ParamSet_FromManifest, StringComparison.Ordinal))
            {
                if (!File.Exists(this.ImageFile))
                    ThrowArgumentError("Specified image file could not be found.", this.ImageFile);

                this.FileFormat = ValidateFileFormat(this.ImageFile, this.FileFormat);
            }
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.EC2.Model.ImportInstanceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "ImportInstance");

            try
            {
#if DESKTOP
                return client.ImportInstance(request);
#elif CORECLR
                return client.ImportInstanceAsync(request).GetAwaiter().GetResult();
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

        internal class ImportInstanceCmdletContext : ImportCmdletContextBase
        {
            public ArchitectureValues Architecture { get; set; }
            public String[] Group { get; set; }
            public ShutdownBehavior InstanceInitiatedShutdownBehavior { get; set; }
            public InstanceType InstanceType { get; set; }
            public bool Monitor { get; set; }
            public PlatformValues Platform { get; set; }
            public String PrivateIpAddress { get; set; }
            public String SubnetId { get; set; }
            public String UserData { get; set; }
            public String AdditionalInfo { get; set; }

            internal ImportLaunchConfiguration PopulateLaunchConfiguration()
            {
                return new ImportLaunchConfiguration
                {
                    InstanceType = this.InstanceType,
                    Platform = this.Platform,
                    Architecture = this.Architecture,
                    AvailabilityZone = this.AvailabilityZone,
                    Description = this.Description,
                    SecurityGroupNames = this.Group,
                    PrivateIpAddress = this.PrivateIpAddress,
                    SubnetId = this.SubnetId,
                    //UserData = this.UserData,
                    EnableMonitoring = this.Monitor,
                    InstanceInitiatedShutdownBehavior = this.InstanceInitiatedShutdownBehavior,
                    AdditionalInfo = this.AdditionalInfo
                };
            }
        }
    }
}
#endif
