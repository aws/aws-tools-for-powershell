/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// The HEAD operation retrieves metadata from an object without returning the object
    /// itself. This operation is useful if you're only interested in an object's metadata.
    /// To use HEAD, you must have READ access to the object.
    /// </summary>
    [Cmdlet("Get", "S3ObjectMetadata")]
    [OutputType("Amazon.S3.Model.GetObjectMetadataResponse")]
    [AWSCmdlet("Invokes the GetObjectMetadata operation against Amazon Simple Storage Service.", Operation = new[] {"GetObjectMetadata"})]
    [AWSCmdletOutput("Amazon.S3.Model.GetObjectMetadataResponse",
        "This cmdlet returns a Amazon.S3.Model.GetObjectMetadataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetS3ObjectMetadataCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket that contains the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter EtagToMatch
        /// <summary>
        /// <para>
        /// ETag to be matched as a pre-condition for returning the object,
        /// otherwise a PreconditionFailed signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EtagToMatch { get; set; }
        #endregion
        
        #region Parameter EtagToNotMatch
        /// <summary>
        /// <para>
        /// ETag that should not be matched as a pre-condition for returning the object,
        /// otherwise a PreconditionFailed signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EtagToNotMatch { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The key of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter ModifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// <para>
        /// The Server-side encryption algorithm to be used with the customer provided key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// <para>
        /// The base64-encoded encryption key for Amazon S3 to use to decrypt the object
        /// <para>Using the encryption key you provide as part of your request Amazon S3 manages both the encryption, as it writes 
        /// to disks, and decryption, when you access your objects. Therefore, you don't need to maintain any data encryption code. The only 
        /// thing you do is manage the encryption keys you provide.</para><para>When you retrieve an object, you must provide the same encryption key as part of your request. Amazon S3 first verifies 
        /// the encryption key you provided matches, and then decrypts the object before returning the object data to you.</para><para>Important: Amazon S3 does not store the encryption key you provide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// <para>
        /// The MD5 of the customer encryption key specified in the ServerSideEncryptionCustomerProvidedKey property. The MD5 is
        /// base 64 encoded. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has not been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// VersionId used to reference a specific version of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            context.EtagToMatch = this.EtagToMatch;
            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            context.EtagToNotMatch = this.EtagToNotMatch;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;
            context.Key = this.Key;
            context.VersionId = this.VersionId;
            context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;
            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.GetObjectMetadataRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.EtagToMatch != null)
            {
                request.EtagToMatch = cmdletContext.EtagToMatch;
            }
            if (cmdletContext.ModifiedSinceDate != null)
            {
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.EtagToNotMatch != null)
            {
                request.EtagToNotMatch = cmdletContext.EtagToNotMatch;
            }
            if (cmdletContext.UnmodifiedSinceDate != null)
            {
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
            {
                request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
            {
                request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
            {
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.S3.Model.GetObjectMetadataResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetObjectMetadataRequest request)
        {
            return client.GetObjectMetadata(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BucketName { get; set; }
            public System.String EtagToMatch { get; set; }
            public System.DateTime? ModifiedSinceDate { get; set; }
            public System.String EtagToNotMatch { get; set; }
            public System.DateTime? UnmodifiedSinceDate { get; set; }
            public System.String Key { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        }
        
    }
}
