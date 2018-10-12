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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Imports a disk into an EBS snapshot.
    /// </summary>
    [Cmdlet("Import", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ImportSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ImportSnapshot API operation.", Operation = new[] {"ImportSnapshot"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ImportSnapshotResponse",
        "This cmdlet returns a Amazon.EC2.Model.ImportSnapshotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Token to enable idempotency for VM import requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ClientData_Comment
        /// <summary>
        /// <para>
        /// <para>A user-defined comment about the disk upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientData_Comment { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description string for the import snapshot task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiskContainer_Description
        /// <summary>
        /// <para>
        /// <para>The description of the disk image being imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DiskContainer_Description { get; set; }
        #endregion
        
        #region Parameter DiskContainer_Format
        /// <summary>
        /// <para>
        /// <para>The format of the disk image being imported.</para><para>Valid values: <code>VHD</code> | <code>VMDK</code> | <code>OVA</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DiskContainer_Format { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role to use when not using the default role, 'vmimport'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter DiskContainer_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where the disk image is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DiskContainer_UserBucket_S3Bucket")]
        public System.String DiskContainer_S3Bucket { get; set; }
        #endregion
        
        #region Parameter DiskContainer_S3Key
        /// <summary>
        /// <para>
        /// <para>The file name of the disk image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DiskContainer_UserBucket_S3Key")]
        public System.String DiskContainer_S3Key { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadEnd
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UploadEndUtc instead. Setting either UploadEnd or
        /// UploadEndUtc results in both UploadEnd and UploadEndUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. UploadEnd
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The time that the disk upload ends.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use ClientData_UtcUploadEnd instead.")]
        public System.DateTime ClientData_UploadEnd { get; set; }
        #endregion
        
        #region Parameter ClientData_UtcUploadEnd
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ClientData_UtcUploadEnd { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadSize
        /// <summary>
        /// <para>
        /// <para>The size of the uploaded disk image, in GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double ClientData_UploadSize { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadStart
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UploadStartUtc instead. Setting either UploadStart
        /// or UploadStartUtc results in both UploadStart and UploadStartUtc being assigned, the
        /// latest assignment to either one of the two property is reflected in the value of both.
        /// UploadStart is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para><para>The time that the disk upload starts.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use ClientData_UtcUploadStart instead.")]
        public System.DateTime ClientData_UploadStart { get; set; }
        #endregion
        
        #region Parameter ClientData_UtcUploadStart
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ClientData_UtcUploadStart { get; set; }
        #endregion
        
        #region Parameter DiskContainer_Url
        /// <summary>
        /// <para>
        /// <para>The URL to the Amazon S3-based disk image being imported. It can either be a https
        /// URL (https://..) or an Amazon S3 URL (s3://..).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DiskContainer_Url { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-EC2Snapshot (ImportSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientData_Comment = this.ClientData_Comment;
            if (ParameterWasBound("ClientData_UtcUploadEnd"))
                context.ClientData_UtcUploadEnd = this.ClientData_UtcUploadEnd;
            if (ParameterWasBound("ClientData_UploadSize"))
                context.ClientData_UploadSize = this.ClientData_UploadSize;
            if (ParameterWasBound("ClientData_UtcUploadStart"))
                context.ClientData_UtcUploadStart = this.ClientData_UtcUploadStart;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ClientData_UploadEnd"))
                context.ClientData_UploadEnd = this.ClientData_UploadEnd;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ClientData_UploadStart"))
                context.ClientData_UploadStart = this.ClientData_UploadStart;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DiskContainer_Description = this.DiskContainer_Description;
            context.DiskContainer_Format = this.DiskContainer_Format;
            context.DiskContainer_Url = this.DiskContainer_Url;
            context.DiskContainer_S3Bucket = this.DiskContainer_S3Bucket;
            context.DiskContainer_S3Key = this.DiskContainer_S3Key;
            context.RoleName = this.RoleName;
            
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
            var request = new Amazon.EC2.Model.ImportSnapshotRequest();
            
            
             // populate ClientData
            bool requestClientDataIsNull = true;
            request.ClientData = new Amazon.EC2.Model.ClientData();
            System.String requestClientData_clientData_Comment = null;
            if (cmdletContext.ClientData_Comment != null)
            {
                requestClientData_clientData_Comment = cmdletContext.ClientData_Comment;
            }
            if (requestClientData_clientData_Comment != null)
            {
                request.ClientData.Comment = requestClientData_clientData_Comment;
                requestClientDataIsNull = false;
            }
            System.DateTime? requestClientData_clientData_UtcUploadEnd = null;
            if (cmdletContext.ClientData_UtcUploadEnd != null)
            {
                requestClientData_clientData_UtcUploadEnd = cmdletContext.ClientData_UtcUploadEnd.Value;
            }
            if (requestClientData_clientData_UtcUploadEnd != null)
            {
                request.ClientData.UploadEndUtc = requestClientData_clientData_UtcUploadEnd.Value;
                requestClientDataIsNull = false;
            }
            System.Double? requestClientData_clientData_UploadSize = null;
            if (cmdletContext.ClientData_UploadSize != null)
            {
                requestClientData_clientData_UploadSize = cmdletContext.ClientData_UploadSize.Value;
            }
            if (requestClientData_clientData_UploadSize != null)
            {
                request.ClientData.UploadSize = requestClientData_clientData_UploadSize.Value;
                requestClientDataIsNull = false;
            }
            System.DateTime? requestClientData_clientData_UtcUploadStart = null;
            if (cmdletContext.ClientData_UtcUploadStart != null)
            {
                requestClientData_clientData_UtcUploadStart = cmdletContext.ClientData_UtcUploadStart.Value;
            }
            if (requestClientData_clientData_UtcUploadStart != null)
            {
                request.ClientData.UploadStartUtc = requestClientData_clientData_UtcUploadStart.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestClientData_clientData_UploadEnd = null;
            if (cmdletContext.ClientData_UploadEnd != null)
            {
                if (cmdletContext.ClientData_UtcUploadEnd != null)
                {
                    throw new ArgumentException("Parameters ClientData_UploadEnd and ClientData_UtcUploadEnd are mutually exclusive.");
                }
                requestClientData_clientData_UploadEnd = cmdletContext.ClientData_UploadEnd.Value;
            }
            if (requestClientData_clientData_UploadEnd != null)
            {
                request.ClientData.UploadEnd = requestClientData_clientData_UploadEnd.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestClientData_clientData_UploadStart = null;
            if (cmdletContext.ClientData_UploadStart != null)
            {
                if (cmdletContext.ClientData_UtcUploadStart != null)
                {
                    throw new ArgumentException("Parameters ClientData_UploadStart and ClientData_UtcUploadStart are mutually exclusive.");
                }
                requestClientData_clientData_UploadStart = cmdletContext.ClientData_UploadStart.Value;
            }
            if (requestClientData_clientData_UploadStart != null)
            {
                request.ClientData.UploadStart = requestClientData_clientData_UploadStart.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.ClientData should be set to null
            if (requestClientDataIsNull)
            {
                request.ClientData = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DiskContainer
            bool requestDiskContainerIsNull = true;
            request.DiskContainer = new Amazon.EC2.Model.SnapshotDiskContainer();
            System.String requestDiskContainer_diskContainer_Description = null;
            if (cmdletContext.DiskContainer_Description != null)
            {
                requestDiskContainer_diskContainer_Description = cmdletContext.DiskContainer_Description;
            }
            if (requestDiskContainer_diskContainer_Description != null)
            {
                request.DiskContainer.Description = requestDiskContainer_diskContainer_Description;
                requestDiskContainerIsNull = false;
            }
            System.String requestDiskContainer_diskContainer_Format = null;
            if (cmdletContext.DiskContainer_Format != null)
            {
                requestDiskContainer_diskContainer_Format = cmdletContext.DiskContainer_Format;
            }
            if (requestDiskContainer_diskContainer_Format != null)
            {
                request.DiskContainer.Format = requestDiskContainer_diskContainer_Format;
                requestDiskContainerIsNull = false;
            }
            System.String requestDiskContainer_diskContainer_Url = null;
            if (cmdletContext.DiskContainer_Url != null)
            {
                requestDiskContainer_diskContainer_Url = cmdletContext.DiskContainer_Url;
            }
            if (requestDiskContainer_diskContainer_Url != null)
            {
                request.DiskContainer.Url = requestDiskContainer_diskContainer_Url;
                requestDiskContainerIsNull = false;
            }
            Amazon.EC2.Model.UserBucket requestDiskContainer_diskContainer_UserBucket = null;
            
             // populate UserBucket
            bool requestDiskContainer_diskContainer_UserBucketIsNull = true;
            requestDiskContainer_diskContainer_UserBucket = new Amazon.EC2.Model.UserBucket();
            System.String requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Bucket = null;
            if (cmdletContext.DiskContainer_S3Bucket != null)
            {
                requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Bucket = cmdletContext.DiskContainer_S3Bucket;
            }
            if (requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Bucket != null)
            {
                requestDiskContainer_diskContainer_UserBucket.S3Bucket = requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Bucket;
                requestDiskContainer_diskContainer_UserBucketIsNull = false;
            }
            System.String requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Key = null;
            if (cmdletContext.DiskContainer_S3Key != null)
            {
                requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Key = cmdletContext.DiskContainer_S3Key;
            }
            if (requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Key != null)
            {
                requestDiskContainer_diskContainer_UserBucket.S3Key = requestDiskContainer_diskContainer_UserBucket_diskContainer_S3Key;
                requestDiskContainer_diskContainer_UserBucketIsNull = false;
            }
             // determine if requestDiskContainer_diskContainer_UserBucket should be set to null
            if (requestDiskContainer_diskContainer_UserBucketIsNull)
            {
                requestDiskContainer_diskContainer_UserBucket = null;
            }
            if (requestDiskContainer_diskContainer_UserBucket != null)
            {
                request.DiskContainer.UserBucket = requestDiskContainer_diskContainer_UserBucket;
                requestDiskContainerIsNull = false;
            }
             // determine if request.DiskContainer should be set to null
            if (requestDiskContainerIsNull)
            {
                request.DiskContainer = null;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
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
        
        private Amazon.EC2.Model.ImportSnapshotResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ImportSnapshot");
            try
            {
                #if DESKTOP
                return client.ImportSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportSnapshotAsync(request);
                return task.Result;
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
            public System.String ClientData_Comment { get; set; }
            public System.DateTime? ClientData_UtcUploadEnd { get; set; }
            public System.Double? ClientData_UploadSize { get; set; }
            public System.DateTime? ClientData_UtcUploadStart { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ClientData_UploadEnd { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ClientData_UploadStart { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DiskContainer_Description { get; set; }
            public System.String DiskContainer_Format { get; set; }
            public System.String DiskContainer_Url { get; set; }
            public System.String DiskContainer_S3Bucket { get; set; }
            public System.String DiskContainer_S3Key { get; set; }
            public System.String RoleName { get; set; }
        }
        
    }
}
