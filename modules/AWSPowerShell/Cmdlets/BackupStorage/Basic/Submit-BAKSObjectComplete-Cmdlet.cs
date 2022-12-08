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
using Amazon.BackupStorage;
using Amazon.BackupStorage.Model;

namespace Amazon.PowerShell.Cmdlets.BAKS
{
    /// <summary>
    /// Complete upload
    /// </summary>
    [Cmdlet("Submit", "BAKSObjectComplete", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BackupStorage.Model.NotifyObjectCompleteResponse")]
    [AWSCmdlet("Calls the AWS Backup Storage NotifyObjectComplete API operation.", Operation = new[] {"NotifyObjectComplete"}, SelectReturnType = typeof(Amazon.BackupStorage.Model.NotifyObjectCompleteResponse))]
    [AWSCmdletOutput("Amazon.BackupStorage.Model.NotifyObjectCompleteResponse",
        "This cmdlet returns an Amazon.BackupStorage.Model.NotifyObjectCompleteResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitBAKSObjectCompleteCmdlet : AmazonBackupStorageClientCmdlet, IExecutor
    {
        
        #region Parameter BackupJobId
        /// <summary>
        /// <para>
        /// Backup job Id for the in-progress backup
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
        public System.String BackupJobId { get; set; }
        #endregion
        
        #region Parameter MetadataBlob
        /// <summary>
        /// <para>
        /// Optional metadata associated with an Object.
        /// Maximum length is 4MB.
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public object MetadataBlob { get; set; }
        #endregion
        
        #region Parameter MetadataBlobChecksum
        /// <summary>
        /// <para>
        /// Checksum of MetadataBlob.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataBlobChecksum { get; set; }
        #endregion
        
        #region Parameter MetadataBlobChecksumAlgorithm
        /// <summary>
        /// <para>
        /// Checksum algorithm.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BackupStorage.DataChecksumAlgorithm")]
        public Amazon.BackupStorage.DataChecksumAlgorithm MetadataBlobChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter MetadataBlobLength
        /// <summary>
        /// <para>
        /// The size of MetadataBlob.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MetadataBlobLength { get; set; }
        #endregion
        
        #region Parameter MetadataString
        /// <summary>
        /// <para>
        /// Optional metadata associated with an Object.
        /// Maximum string length is 256 bytes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataString { get; set; }
        #endregion
        
        #region Parameter ObjectChecksum
        /// <summary>
        /// <para>
        /// Object checksum
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
        public System.String ObjectChecksum { get; set; }
        #endregion
        
        #region Parameter ObjectChecksumAlgorithm
        /// <summary>
        /// <para>
        /// Checksum algorithm
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BackupStorage.SummaryChecksumAlgorithm")]
        public Amazon.BackupStorage.SummaryChecksumAlgorithm ObjectChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// Upload Id for the in-progress upload
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupStorage.Model.NotifyObjectCompleteResponse).
        /// Specifying the name of a property of type Amazon.BackupStorage.Model.NotifyObjectCompleteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UploadId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UploadId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UploadId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UploadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-BAKSObjectComplete (NotifyObjectComplete)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupStorage.Model.NotifyObjectCompleteResponse, SubmitBAKSObjectCompleteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UploadId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupJobId = this.BackupJobId;
            #if MODULAR
            if (this.BackupJobId == null && ParameterWasBound(nameof(this.BackupJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataBlob = this.MetadataBlob;
            context.MetadataBlobChecksum = this.MetadataBlobChecksum;
            context.MetadataBlobChecksumAlgorithm = this.MetadataBlobChecksumAlgorithm;
            context.MetadataBlobLength = this.MetadataBlobLength;
            context.MetadataString = this.MetadataString;
            context.ObjectChecksum = this.ObjectChecksum;
            #if MODULAR
            if (this.ObjectChecksum == null && ParameterWasBound(nameof(this.ObjectChecksum)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectChecksum which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectChecksumAlgorithm = this.ObjectChecksumAlgorithm;
            #if MODULAR
            if (this.ObjectChecksumAlgorithm == null && ParameterWasBound(nameof(this.ObjectChecksumAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectChecksumAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.Stream _MetadataBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BackupStorage.Model.NotifyObjectCompleteRequest();
                
                if (cmdletContext.BackupJobId != null)
                {
                    request.BackupJobId = cmdletContext.BackupJobId;
                }
                if (cmdletContext.MetadataBlob != null)
                {
                    _MetadataBlobStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.MetadataBlob);
                    request.MetadataBlob = _MetadataBlobStream;
                }
                if (cmdletContext.MetadataBlobChecksum != null)
                {
                    request.MetadataBlobChecksum = cmdletContext.MetadataBlobChecksum;
                }
                if (cmdletContext.MetadataBlobChecksumAlgorithm != null)
                {
                    request.MetadataBlobChecksumAlgorithm = cmdletContext.MetadataBlobChecksumAlgorithm;
                }
                if (cmdletContext.MetadataBlobLength != null)
                {
                    request.MetadataBlobLength = cmdletContext.MetadataBlobLength.Value;
                }
                if (cmdletContext.MetadataString != null)
                {
                    request.MetadataString = cmdletContext.MetadataString;
                }
                if (cmdletContext.ObjectChecksum != null)
                {
                    request.ObjectChecksum = cmdletContext.ObjectChecksum;
                }
                if (cmdletContext.ObjectChecksumAlgorithm != null)
                {
                    request.ObjectChecksumAlgorithm = cmdletContext.ObjectChecksumAlgorithm;
                }
                if (cmdletContext.UploadId != null)
                {
                    request.UploadId = cmdletContext.UploadId;
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
                if( _MetadataBlobStream != null)
                {
                    _MetadataBlobStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BackupStorage.Model.NotifyObjectCompleteResponse CallAWSServiceOperation(IAmazonBackupStorage client, Amazon.BackupStorage.Model.NotifyObjectCompleteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Storage", "NotifyObjectComplete");
            try
            {
                #if DESKTOP
                return client.NotifyObjectComplete(request);
                #elif CORECLR
                return client.NotifyObjectCompleteAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupJobId { get; set; }
            public object MetadataBlob { get; set; }
            public System.String MetadataBlobChecksum { get; set; }
            public Amazon.BackupStorage.DataChecksumAlgorithm MetadataBlobChecksumAlgorithm { get; set; }
            public System.Int64? MetadataBlobLength { get; set; }
            public System.String MetadataString { get; set; }
            public System.String ObjectChecksum { get; set; }
            public Amazon.BackupStorage.SummaryChecksumAlgorithm ObjectChecksumAlgorithm { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.BackupStorage.Model.NotifyObjectCompleteResponse, SubmitBAKSObjectCompleteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
