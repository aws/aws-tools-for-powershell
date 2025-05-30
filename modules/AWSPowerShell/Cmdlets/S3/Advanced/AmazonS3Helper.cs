﻿/*******************************************************************************
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

using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Amazon.PowerShell.Cmdlets.S3
{
    internal static class AmazonS3Helper
    {
        /// <summary>
        /// 'Cleans' a user-supplied S3 key to ensure it does not start with space, \ or /
        /// and all remaining partitions use / and it does not end with a space.
        /// </summary>
        /// <param name="userKeyOrPrefix">The original user key or key prefix</param>
        /// <returns>Cleaned key</returns>
        public static string CleanKey(string userKeyOrPrefix)
        {
            if (string.IsNullOrEmpty(userKeyOrPrefix))
                return userKeyOrPrefix;

            StringBuilder sb = new StringBuilder(userKeyOrPrefix.TrimStart(new char[] { '/', '\\', ' ' }));
            sb.Replace('\\', '/');
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Returns the appropriate user agent addition string for tracking if an S3 object key was cleaned.
        /// </summary>
        /// <param name="OriginalKey">The original user key or key prefix</param>
        /// /// <param name="RevisedKey">The revised user key or key prefix</param>
        /// <returns>User agent addition string</returns>
        public static string GetCleanKeyUserAgentAdditionString(string OriginalKey, string RevisedKey)
        {
            if (OriginalKey != RevisedKey)
            {
                return "ft/S3Key#cleaned";
            }
            else
            {
                return "ft/S3Key#unmodified";
            }
        }

        /// <summary>
        /// Extracts a bucket name from a supplied parameter object, which should be
        /// a string or S3Bucket instance.
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string BucketNameFromParam(object paramValue, string paramName)
        {
            string bucketName = null;
            if (paramValue is string)
                bucketName = (paramValue as string).Trim();
            else
            {
                PSObject bucketObject = paramValue as PSObject;
                if (bucketObject != null && bucketObject.BaseObject != null)
                {
                    S3Bucket s3Bucket = bucketObject.BaseObject as S3Bucket;
                    if (s3Bucket != null)
                        bucketName = s3Bucket.BucketName;
                }
            }

            if (!string.IsNullOrEmpty(bucketName))
                return bucketName;

            throw new ArgumentException(string.Format("Expected bucket name or S3Bucket instance for {0} parameter", paramName));
        }

        /// <summary>
        /// Extracts the system name of a region for a bucket from parameter value
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string BucketRegionFromParam(object paramValue, string paramName)
        {
            if (paramValue is string)
                return (paramValue as string).Trim();

            PSObject bucketRegionObj = paramValue as PSObject;
            if (bucketRegionObj != null && bucketRegionObj.BaseObject != null)
            {
                AWSRegion awsRegion = bucketRegionObj.BaseObject as AWSRegion;
                if (awsRegion != null)
                    return awsRegion.Region;
            }

            throw new ArgumentException(string.Format("Expected string system name or AWSRegion instance for {0} parameter", paramName));
        }

        /// <summary>
        /// Sets metadata and headers collections for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cmdletContext"></param>
        public static void SetExtraRequestFields(TransferUtilityUploadDirectoryRequest request, WriteS3ObjectCmdlet.CmdletContext cmdletContext)
        {
            request.UploadDirectoryFileRequestEvent += (s, e) =>
            {
                var uploadRequest = e.UploadRequest;
                SetMetadataAndHeaders(uploadRequest, cmdletContext.Metadata, cmdletContext.Headers);

                if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
                    uploadRequest.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
                if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
                    uploadRequest.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
                if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
                    uploadRequest.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

                if (cmdletContext.PartSize != null)
                    uploadRequest.PartSize = cmdletContext.PartSize.Value;
            };
        }

        /// <summary>
        /// Sets metadata and headers collections for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="metadata"></param>
        /// <param name="headers"></param>
        public static void SetMetadataAndHeaders(TransferUtilityUploadRequest request, Hashtable metadata, Hashtable headers)
        {
            SetMetadata(request.Metadata, metadata);
            SetHeaders(request.Headers, headers);
        }

        /// <summary>
        /// Sets metadata and headers collections for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="metadata"></param>
        /// <param name="headers"></param>
        public static void SetMetadataAndHeaders(PutObjectRequest request, Hashtable metadata, Hashtable headers)
        {
            SetMetadata(request.Metadata, metadata);
            SetHeaders(request.Headers, headers);
        }

        /// <summary>
        /// Sets metadata and headers collections for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="metadata"></param>
        /// <param name="headers"></param>
        public static void SetMetadataAndHeaders(CopyObjectRequest request, Hashtable metadata, Hashtable headers)
        {
            SetMetadata(request.Metadata, metadata);
            SetHeaders(request.Headers, headers);
        }

        /// <summary>
        /// Sets metadata and headers collections for the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="metadata"></param>
        /// <param name="headers"></param>
        public static void SetMetadataAndHeaders(InitiateMultipartUploadRequest request, Hashtable metadata, Hashtable headers)
        {
            SetMetadata(request.Metadata, metadata);
            SetHeaders(request.Headers, headers);
        }

        private static void SetMetadata(MetadataCollection mc, Hashtable metadata)
        {
            if (metadata == null || metadata.Count == 0)
                return;

            foreach (var key in metadata.Keys)
            {
                var value = metadata[key];

                var keyString = key as string;
                var valueString = value as string;
                mc[keyString] = valueString;
            }
        }
        private static void SetHeaders(HeadersCollection hc, Hashtable headers)
        {
            if (headers == null || headers.Count == 0)
                return;

            foreach (var key in headers.Keys)
            {
                var value = headers[key];

                var keyString = key as string;
                var valueString = value as string;
                hc[keyString] = valueString;
            }
        }

        public static ServerSideEncryptionMethod Convert(string serverSideEncryption)
        {
            ServerSideEncryptionMethod value = serverSideEncryption;
            if (string.Equals(value.Value, serverSideEncryptionNone.Value, System.StringComparison.OrdinalIgnoreCase))
                value = ServerSideEncryptionMethod.None;
            return value;
        }
        // This method is used to Convert GetObjectMetadataResponse to S3Object for Directory Buckets
        // Only the following Proprties of S3Object will be set.
        // BucketName, Key, ETag, Size, StorageClass, LastModified.
        // This method will not be maintained to add new properties.
        // In a future major version, we will change the return type of Copy-S3Object so that we don't have to do the conversion manually
        public static S3Object Convert(GetObjectMetadataResponse objectMetadata, string bucketName, string key)
        {
            return new S3Object
            {
                BucketName = bucketName,
                Key = key,
                ETag = objectMetadata.ETag,
                Size = objectMetadata.ContentLength,
                StorageClass = objectMetadata.StorageClass,
                LastModified = objectMetadata.LastModified
            };
        }

        private static readonly ServerSideEncryptionMethod serverSideEncryptionNone = "None";
    }
}
