/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Amazon.EC2.Import;
using Amazon.PowerShell.Common;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    public class EC2ImportCmdletsBase : AmazonEC2ClientCmdlet
    {
        /// <summary>
        /// The default parameter set for the cmdlet causes the local artifacts to be uploaded to 
        /// a named bucket, with optional key prefix, in Amazon S3 and an ImportInstance request be
        /// submitted to Amazon EC2. The conversion task object returned by EC2 is output.
        /// </summary>
        protected const string ParamSet_Default = "DefaultParameterSet";

        /// <summary>
        /// Use of this parameter set causes the local artifacts to be uploaded to a named
        /// bucket, with optional key prefix, in Amazon S3. No import is requested and the
        /// key of the uploaded manifest is returned.
        /// </summary>
        protected const string ParamSet_UploadOnly = "UploadOnlyParameterSet";

        /// <summary>
        /// Use of this parameter set causes an ImportInstance request to be sent to Amazon EC2
        /// using the manifest and image file artifacts previously uploaded. The conversion task 
        /// object returned by EC2 is output.
        /// </summary>
        protected const string ParamSet_FromManifest = "FromManifestParameterSet";

        protected const string ProgressActivity = "Importing";

        // some common error messages; the newlines are then to try and get the resumption instructions etc
        // out in the clear where users can see them
        protected const string GeneratingManifestErrorMsg 
            = "The import operation failed to generate an import manifest."
            + "\r\n"
            + "No artifacts were uploaded that require manual removal."
            + "\r\n";

        protected const string UploadingManifestErrorMsg
            = "The import operation failed to create the bucket and/or upload the generated import manifest."
            + "\r\n"
            + "Bucket creation can fail if the bucket name is not unique, or a bucket with the name exists and is not owned by you."
            + "\r\n";

        protected const string ManifestInspectionErrorMsg
            = "The import operation failed to download and re-use the specified import manifest."
            + "\r\n"
            + "To remove uploaded artifacts: "
            + "\r\n"
            + "    use the Remove-EC2DiskImage cmdlet supplying the bucket name and use '{0}' for the -ManifestFileKey parameter."
            + "\r\n";

        protected const string UploadingImageFileErrorMsg
            = "The import operation failed to upload one or more image file parts."
            + "\r\n";

        protected const string UploadingImageFileErrorMsg_Retain
            = "To continue: re-run the cmdlet with the -Resume switch."
              + "\r\n"
              + "To cancel and remove uploaded artifacts: "
              + "\r\n"
              + "    use the Remove-EC2DiskImage cmdlet supplying the bucket name and use '{0}' for the -ManifestFileKey parameter."
              + "\r\n";

        protected const string UploadingImageFileErrorMsg_NoRetain
            = "The manifest and image file artifacts that had been successfully uploaded have been removed from the S3 bucket."
            + "\r\n";

        protected const string ResumeUploadErrorMsg_NoMemo
            = "Unable to determine the location of the import manifest for the image file."
              + "\r\n"
              + "Unable to resume upload for this image."
              + "\r\n";

        protected const string SendingImportRequestMsg
            = "The import operation failed sending the conversion request to EC2." 
              + "\r\n"
              + "The import manifest and image file parts still exist in the S3 bucket."
              + "\r\n"
              + "To retry: Check the instance type and launch specification parameters and re-execute the cmdlet with parameter changes,"
              + "\r\n"
              + "    remove any -ImageFile parameter and value, add the -ManifestFileKey parameter with value '{0}'." 
              + "\r\n"
              + "To cancel and remove uploaded artifacts:"
              + "\r\n"
              + "    use the Remove-EC2DiskImage cmdlet supplying the bucket name and use '{1}' for the -ManifestFileKey parameter."
              + "\r\n";

        protected const string GenericFailedWithErrors
            = "Image artifact upload and/or import failed with errors";

        protected const string GenericUploadOnlySucceeded
            = "Image artifact upload completed.";
        
        protected const string GenericUploadAndConvertSucceeded = 
            "Image artifact upload completed, import conversion requested.";

        protected static readonly string[] ValidFileFormats = { "VMDK", "RAW", "VHD" };

        protected int _urlExpiryInDays = DiskImageImporter.DefaultUrlExpirationInDays;
        protected int _uploadThreads = DiskImageImporter.DefaultUploadThreads;

        protected virtual void ValidateArguments()
        {
            
        }

        protected void UpdateImportProgress(string message, int? percentComplete = null)
        {
            WriteProgressRecord(ProgressActivity, message, percentComplete);
        }

        protected string ResolveImageFilePath(string imageFile)
        {
            if (Path.IsPathRooted(imageFile) || string.IsNullOrEmpty(imageFile))
                return imageFile;

            // note that Environment.CurrentDirectory is unreliably and in some shells,
            // shows where we started, not where we are
            var referencePath = this.SessionState.Path.CurrentFileSystemLocation.Path;
            return Path.GetFullPath(Path.Combine(referencePath, imageFile));
        }

        /// <summary>
        /// Returns what should be a predictable and unique name for the image file
        /// that we can use to hold temporary memo data between cmdlet executions.
        /// As it is unlikely that a user will try and upload two images with the same
        /// name but different paths at the same time, and both uploads fail, a simple
        /// MD5 hash onto the image filename and path should be sufficient.
        /// </summary>
        /// <remarks>
        /// As we only know the user key prefix at the time we write the memo and not
        /// when reading due to detecting the -Resume switch, we cannot include the
        /// prefix in the hash.
        /// </remarks>
        /// <param name="imageFilePath">The resolved path to the image file</param>
        /// <param name="bucketName">The name of the bucket containing the manifest</param>
        /// <returns></returns>
        static string ConstructMemoFilename(string imageFilePath, string bucketName)
        {
            var data = string.Concat(imageFilePath, ".", bucketName).ToLowerInvariant();
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(data));
            var hex = BitConverter.ToString(hash).Replace("-", string.Empty);

            var filename = Path.GetFileName(imageFilePath);
            return string.Format("{0}.{1}",
                                 filename,
                                 hex.Length > 8 ? hex.Substring(0, 8) : hex);
        }


        /// <summary>
        /// Reads the previously stashed S3 object key to a manifest associated
        /// with the image file. The key was stored when an upload error was detected.
        /// </summary>
        /// <param name="imageFilePath">The resolved path to the image file</param>
        /// <param name="bucketName">The name of the bucket containing the manifest</param>
        /// <returns>The stored S3 object key</returns>
        /// <remarks>
        /// We leave the memo file present after reading in case a continued network loss 
        /// means we don't exit the cmdlet through normal handling. The 'clean path'
        /// through the import cmdlets will delete the memo if no error occurs.
        /// </remarks>
        protected string ReadManifestKeyFromMemo(string imageFilePath, string bucketName)
        {
            string manifestKey = null;
            try
            {
                var awspsAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                               AWSPowerShellAppDataSubPath);
                if (Directory.Exists(awspsAppDataPath))
                {
                    var memoFile = Path.Combine(awspsAppDataPath, ConstructMemoFilename(imageFilePath, bucketName));
                    manifestKey = File.ReadAllText(memoFile, Encoding.UTF8);
                }
                else
                {
                    throw new InvalidOperationException("AppData path for AWSPowerShell does not exist; a memo file could not have been written.");
                }
            }
            catch
            {
                ThrowExecutionError(ResumeUploadErrorMsg_NoMemo, this);
            }

            return manifestKey;  
        }

        /// <summary>
        /// Writes a memo-ization file to a subfolder of the user's appdata folder
        /// containing the S3 object key to the manifest we just failed to complete
        /// upload for. We'll read this file if the -Resume switch is set on next run.
        /// to save the user neededing to remember it or paste it manually into the
        /// new command.
        /// </summary>
        /// <param name="imageFilePath">The resolved path to the image file</param>
        /// <param name="bucketName">The name of the bucket containing the manifest</param>
        /// <param name="manifestFileKey">The S3 key of the manifest</param>
        /// <remarks>
        /// Although it's highly unlikely a user might upload two images with the same
        /// base name at the same time, we take a leaf out of Git's book and hash the
        /// path+filename of the image to append to the image name we use for the memo
        /// file -- this pretty much guarantees we correctly match the image and memo
        /// file in resume mode.
        /// </remarks>
        protected void WriteManifestMemoFile(string imageFilePath, 
                                             string bucketName,
                                             string manifestFileKey)
        {
            try
            {
                var awspsAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                               AWSPowerShellAppDataSubPath);
                if (!Directory.Exists(awspsAppDataPath))
                    Directory.CreateDirectory(awspsAppDataPath);

                var memoFile = Path.Combine(awspsAppDataPath, ConstructMemoFilename(imageFilePath, bucketName));
                File.WriteAllText(memoFile, manifestFileKey, Encoding.UTF8);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes any memo-ization file for an image file on successful completion of processing.
        /// </summary>
        /// <param name="imageFilePath">The resolved path to the image file</param>
        /// <param name="bucketName">The name of the bucket containing the manifest</param>
        protected void CleanManifestMemoFile(string imageFilePath, string bucketName)
        {
            try
            {
                var awspsAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                               AWSPowerShellAppDataSubPath);
                if (Directory.Exists(awspsAppDataPath))
                {
                    var memoFile = Path.Combine(awspsAppDataPath, ConstructMemoFilename(imageFilePath, bucketName));
                    if (File.Exists(memoFile))
                        File.Delete(memoFile);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Constructs an appropriate error message depending on where the import
        /// error occurred. If rollback is not enabled (so we are leaving whatever
        /// artifacts were uploaded to S3 in place), we write a temporary memo file
        /// to a folder in the user's appdata that contains the S3 key of the manifest.
        /// If the cmdlet is restarted with the -Resume switch, we'll read the manifest
        /// key from there, analyze the manifest and continue uploaded.
        /// </summary>
        /// <param name="importHelper"></param>
        /// <param name="exc"></param>
        /// <param name="rollbackEnabled"></param>
        /// <returns></returns>
        protected string HandleImportError(DiskImageImporter importHelper,
                                           DiskImageImporterException exc,
                                           bool rollbackEnabled)
        {
            var msg = new StringBuilder();
            switch (exc.Stage)
            {
                case DiskImportErrorStage.GeneratingManifest:
                    msg.Append(GeneratingManifestErrorMsg);
                    break;

                case DiskImportErrorStage.UploadingManifest:
                    msg.Append(UploadingManifestErrorMsg);
                    break;

                case DiskImportErrorStage.ManifestInspection:
                    msg.AppendFormat(ManifestInspectionErrorMsg, importHelper.ManifestFileKey);
                    break;

                case DiskImportErrorStage.UploadingImageFile:
                    msg.Append(UploadingImageFileErrorMsg);
                    if (rollbackEnabled)
                        msg.Append(UploadingImageFileErrorMsg_NoRetain);
                    else
                    {
                        WriteManifestMemoFile(importHelper.ImageFilePath, 
                                              importHelper.BucketName, 
                                              importHelper.ManifestFileKey);
                        msg.AppendFormat(UploadingImageFileErrorMsg_Retain, importHelper.ManifestFileKey);
                    }
                    break;

                case DiskImportErrorStage.SendingImportRequest:
                    msg.AppendFormat(SendingImportRequestMsg, importHelper.ManifestFileKey,
                        importHelper.ArtifactsKeyPrefix);
                    break;
            }

            return msg.ToString();
        }

        protected string ValidateFileFormat(string imageFile, string specifiedFormat)
        {
            string fileFormat;
            if (string.IsNullOrEmpty(specifiedFormat))
            {
                var ext = Path.GetExtension(imageFile);
                if (string.IsNullOrEmpty(ext))
                    ThrowArgumentError("The image file has no extension, so the format cannot be determined automatically. Use the -FileFormat parameter.", imageFile);

                fileFormat = ext.TrimStart('.');
            }
            else
                fileFormat = specifiedFormat;

            var matched = ValidFileFormats.Any(s => s.Equals(fileFormat, StringComparison.OrdinalIgnoreCase));
            if (!matched)
            {
                var msg =
                    string.Format(
                        "The image file format, '{0}' (obtained from the -FileFormat parameter or the image file extension) does not "
                        + "\r\n"
                        + "match the image types known to be compatible with EC2 import.", fileFormat);
                DisplayWarning(msg);
            }

            return fileFormat;
        }

        internal class ImportCmdletContextBase : ExecutorContext
        {
            public string ImageFile { get; set; }
            public string BucketName { get; set; }
            public string KeyPrefix { get; set; }
            public string[] ManifestFileKey { get; set; }
            public string AvailabilityZone { get; set; }
            public string FileFormat { get; set; }
            public String Description { get; set; }
            public int? VolumeSize { get; set; }
            public int UploadThreads { get; set; }
            public bool Resume { get; set; }
            public bool RollbackOnUploadError { get; set; }
            public int UrlExpirationInDays { get; set; }
        }
    }
}
