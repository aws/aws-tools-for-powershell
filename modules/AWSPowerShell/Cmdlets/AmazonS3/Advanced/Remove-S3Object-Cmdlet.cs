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
using System.Collections.Generic;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3.Model;
using Amazon.PowerShell.Properties;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Deletes the specified object, object version or set of objects from S3.
    /// 
    /// The DeleteObject operation removes the specified object from Amazon S3.
    /// Once deleted, there is no method to restore or undelete an object.
    /// </summary>
    [Cmdlet("Remove", "S3Object", DefaultParameterSetName = ParamSet_SingleObject, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new Type[] { typeof(DeleteObjectResponse), typeof(DeleteObjectsResponse) })]
    [AWSCmdlet("Invokes the DeleteObjects operation against Amazon S3.", Operation = new [] {"DeleteObjects"})]
    [AWSCmdletOutput("Amazon.S3.Model.DeleteObjectResponse instance if deleting a single object or Amazon.S3.Model.DeleteObjectsResponse instance for multi-object delete.")]
    public class RemoveS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_SingleObject = "SingleObjDeleteSet";
        const string Paramset_MultipleObject = "MultiObjDeleteSet";

        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket containing the object(s) to be removed.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion

        #region Single Object Delete Parameters

        #region Parameter Key
        /// <summary>
        /// Key value identifying a single object in S3 to remove.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_SingleObject, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// If specified, the specific version of the S3 object is removed.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_SingleObject)]
        public System.String VersionId { get; set; }
        #endregion

        #endregion

        #region Multi-Object Delete Parameters

        #region Parameter VersionKey
        /// <summary>
        /// Collection of KeyVersion objects describing the S3 objects to be deleted.
        /// </summary>
        [Parameter(ParameterSetName = Paramset_MultipleObject)]
        [Alias("VersionKeys")]
        public Amazon.S3.Model.KeyVersion[] VersionKey { get; set; }
        #endregion

        #region Parameter InputObject
        /// <summary>
        /// Collection of S3Object instances describing the S3 objects to be deleted.
        /// </summary>
        [Parameter(ParameterSetName = Paramset_MultipleObject, ValueFromPipeline = true)]
        [Alias("InputObjects")]
        public Amazon.S3.Model.S3Object[] InputObject { get; set; }
        #endregion

        #region Parameter KeyCollection
        /// <summary>
        /// Collection of key names describing the S3 objects to be deleted.
        /// </summary>
        [Parameter(ParameterSetName = Paramset_MultipleObject)]
        [Alias("Keys")]
        public System.String[] KeyCollection { get; set; }
        #endregion

        #region Parameter ReportErrorsOnly
        /// <summary>
        /// <para>
        /// If set when deleting multiple objects the service response will include only those 
        /// keys for objects on which the delete operation failed. By default this switch is not 
        /// set and keys for both successful multi-object deletes and failures are returned in the 
        /// response.
        /// </para>
        /// <para>
        /// This parameter is used only when deleting multiple objects using the <code>-KeyCollection</code>
        /// parameter.
        /// </para>
        /// </summary>
        [Alias("Quiet")]
        [Parameter(ParameterSetName = Paramset_MultipleObject)]
        public SwitchParameter ReportErrorsOnly { get; set; }
        #endregion

        #endregion

        #region Shared Parameters

        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// Specifies the serial number of the multi-factor authentication device 
        /// associated with your AWS Account. 
        /// </para>
        /// <para>
        /// This is a required property for this request if:<br />
        /// 1. EnableMfaDelete was configured on the bucket containing this object's version.<br />
        /// 2. You are deleting an object's version
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("MfaCodes_First")]
        public System.String SerialNumber { get; set; }
        #endregion

        #region Parameter AuthenticationValue
        /// <summary>
        /// <para>
        /// Specifies the current token/code displayed on the multi-factor authentication device 
        /// associated with your AWS Account. 
        /// </para>
        /// <para>
        /// This is a required property for this request if:<br />
        /// 1. EnableMfaDelete was configured on the bucket containing this object's version.<br />
        /// 2. You are deleting an object's version
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("MfaCodes_Second")]
        public System.String AuthenticationValue { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }

        #endregion

        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var isSingleObjectDelete = this.ParameterSetName == ParamSet_SingleObject;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName
            };

            string resourceIdentifiersText;
            if (isSingleObjectDelete)
            {
                resourceIdentifiersText = context.Key;

                context.Key = AmazonS3Helper.CleanKey(this.Key);
                context.VersionId = this.VersionId;
            }
            else
            {
                resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyCollection", MyInvocation.BoundParameters);

                if (this.KeyCollection != null && this.KeyCollection.Length > 0)
                    context.Keys = new List<string>(this.KeyCollection);
                if (this.VersionKey != null && this.VersionKey.Length > 0)
                    context.VersionKeys = new List<KeyVersion>(this.VersionKey);
                if (this.InputObject != null && this.InputObject.Length > 0)
                    context.InputObjects = new List<S3Object>(this.InputObject);

                if (this.ReportErrorsOnly.IsPresent)
                    context.Quiet = true;
            }

            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-S3Object (DeleteObjects)"))
                return;

            context.SerialNumber = this.SerialNumber;
            context.AuthenticationValue = this.AuthenticationValue;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            if (!string.IsNullOrEmpty(cmdletContext.Key))
                return DeleteSingleS3Object(cmdletContext);
            else
                return DeleteMultiS3Object(cmdletContext);
        }

        CmdletOutput DeleteSingleS3Object(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DeleteObjectRequest();

            request.BucketName = cmdletContext.BucketName;
            request.Key = cmdletContext.Key;
            if (!string.IsNullOrEmpty(cmdletContext.VersionId))
                request.VersionId = cmdletContext.VersionId;

            if (!string.IsNullOrEmpty(cmdletContext.SerialNumber)
                    && !string.IsNullOrEmpty(cmdletContext.AuthenticationValue))
            {
                request.MfaCodes = new MfaCodes
                {
                    SerialNumber = cmdletContext.SerialNumber,
                    AuthenticationValue = cmdletContext.AuthenticationValue
                };
            }

            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);

                    output = new CmdletOutput
                    {
                        PipelineOutput = response,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                return output;
            }
        }

        CmdletOutput DeleteMultiS3Object(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DeleteObjectsRequest {BucketName = cmdletContext.BucketName, Quiet = cmdletContext.Quiet};

            if (cmdletContext.Keys != null)
            {
                foreach (var key in cmdletContext.Keys)
                {
                    request.AddKey(key);
                }
            }
            else if (cmdletContext.VersionKeys != null)
            {
                foreach (var key in cmdletContext.VersionKeys)
                {
                    request.AddKey(key.Key, key.VersionId);
                }
            }
            else if (cmdletContext.InputObjects != null)
            {
                foreach (var s3Object in cmdletContext.InputObjects)
                {
                    request.AddKey(s3Object.Key);
                }
            }

            if (!string.IsNullOrEmpty(cmdletContext.SerialNumber)
                    && !string.IsNullOrEmpty(cmdletContext.AuthenticationValue))
            {
                request.MfaCodes = new MfaCodes
                {
                    SerialNumber = cmdletContext.SerialNumber,
                    AuthenticationValue = cmdletContext.AuthenticationValue
                };
            }

            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);

                    output = new CmdletOutput
                    {
                        PipelineOutput = response.DeletedObjects,
                        ServiceResponse = response,
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                return output;
            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private static Amazon.S3.Model.DeleteObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteObjectRequest request)
        {
            return client.DeleteObject(request);
        }

        private static Amazon.S3.Model.DeleteObjectsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteObjectsRequest request)
        {
            return client.DeleteObjects(request);
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String VersionId { get; set; }
            
            public Boolean Quiet { get; set; }
            public List<KeyVersion> VersionKeys { get; set; }
            public List<S3Object> InputObjects { get; set; }
            public List<string> Keys { get; set; }

            public String SerialNumber { get; set; }
            public String AuthenticationValue { get; set; }
        }
    }
}
