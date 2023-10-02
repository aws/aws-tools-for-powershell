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
    /// Upload object that can store object metadata String and data blob in single API call
    /// using inline chunk field.
    /// </summary>
    [Cmdlet("Write", "BAKSObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BackupStorage.Model.PutObjectResponse")]
    [AWSCmdlet("Calls the AWS Backup Storage PutObject API operation.", Operation = new[] {"PutObject"}, SelectReturnType = typeof(Amazon.BackupStorage.Model.PutObjectResponse))]
    [AWSCmdletOutput("Amazon.BackupStorage.Model.PutObjectResponse",
        "This cmdlet returns an Amazon.BackupStorage.Model.PutObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteBAKSObjectCmdlet : AmazonBackupStorageClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupJobId
        /// <summary>
        /// <para>
        /// Backup job Id for the in-progress backup.
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
        
        #region Parameter InlineChunk
        /// <summary>
        /// <para>
        /// Inline chunk data to be uploaded.
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public object InlineChunk { get; set; }
        #endregion
        
        #region Parameter InlineChunkChecksum
        /// <summary>
        /// <para>
        /// Inline chunk checksum
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InlineChunkChecksum { get; set; }
        #endregion
        
        #region Parameter InlineChunkChecksumAlgorithm
        /// <summary>
        /// <para>
        /// Inline chunk checksum algorithm
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InlineChunkChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter InlineChunkLength
        /// <summary>
        /// <para>
        /// Length of the inline chunk data.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? InlineChunkLength { get; set; }
        #endregion
        
        #region Parameter MetadataString
        /// <summary>
        /// <para>
        /// Store user defined metadata like backup
        /// checksum, disk ids, restore metadata etc.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataString { get; set; }
        #endregion
        
        #region Parameter ObjectChecksum
        /// <summary>
        /// <para>
        /// object checksum
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectChecksum { get; set; }
        #endregion
        
        #region Parameter ObjectChecksumAlgorithm
        /// <summary>
        /// <para>
        /// object checksum algorithm
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BackupStorage.SummaryChecksumAlgorithm")]
        public Amazon.BackupStorage.SummaryChecksumAlgorithm ObjectChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ObjectName
        /// <summary>
        /// <para>
        /// The name of the Object to be uploaded.
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
        public System.String ObjectName { get; set; }
        #endregion
        
        #region Parameter ThrowOnDuplicate
        /// <summary>
        /// <para>
        /// Throw an exception if Object name is
        /// already exist.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ThrowOnDuplicate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupStorage.Model.PutObjectResponse).
        /// Specifying the name of a property of type Amazon.BackupStorage.Model.PutObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ObjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ObjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ObjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ObjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BAKSObject (PutObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupStorage.Model.PutObjectResponse, WriteBAKSObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ObjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupJobId = this.BackupJobId;
            #if MODULAR
            if (this.BackupJobId == null && ParameterWasBound(nameof(this.BackupJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InlineChunk = this.InlineChunk;
            context.InlineChunkChecksum = this.InlineChunkChecksum;
            context.InlineChunkChecksumAlgorithm = this.InlineChunkChecksumAlgorithm;
            context.InlineChunkLength = this.InlineChunkLength;
            context.MetadataString = this.MetadataString;
            context.ObjectChecksum = this.ObjectChecksum;
            context.ObjectChecksumAlgorithm = this.ObjectChecksumAlgorithm;
            context.ObjectName = this.ObjectName;
            #if MODULAR
            if (this.ObjectName == null && ParameterWasBound(nameof(this.ObjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThrowOnDuplicate = this.ThrowOnDuplicate;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _InlineChunkStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BackupStorage.Model.PutObjectRequest();
                
                if (cmdletContext.BackupJobId != null)
                {
                    request.BackupJobId = cmdletContext.BackupJobId;
                }
                if (cmdletContext.InlineChunk != null)
                {
                    _InlineChunkStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.InlineChunk);
                    request.InlineChunk = _InlineChunkStream;
                }
                if (cmdletContext.InlineChunkChecksum != null)
                {
                    request.InlineChunkChecksum = cmdletContext.InlineChunkChecksum;
                }
                if (cmdletContext.InlineChunkChecksumAlgorithm != null)
                {
                    request.InlineChunkChecksumAlgorithm = cmdletContext.InlineChunkChecksumAlgorithm;
                }
                if (cmdletContext.InlineChunkLength != null)
                {
                    request.InlineChunkLength = cmdletContext.InlineChunkLength.Value;
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
                if (cmdletContext.ObjectName != null)
                {
                    request.ObjectName = cmdletContext.ObjectName;
                }
                if (cmdletContext.ThrowOnDuplicate != null)
                {
                    request.ThrowOnDuplicate = cmdletContext.ThrowOnDuplicate.Value;
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
                if( _InlineChunkStream != null)
                {
                    _InlineChunkStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BackupStorage.Model.PutObjectResponse CallAWSServiceOperation(IAmazonBackupStorage client, Amazon.BackupStorage.Model.PutObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Storage", "PutObject");
            try
            {
                #if DESKTOP
                return client.PutObject(request);
                #elif CORECLR
                return client.PutObjectAsync(request).GetAwaiter().GetResult();
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
            public object InlineChunk { get; set; }
            public System.String InlineChunkChecksum { get; set; }
            public System.String InlineChunkChecksumAlgorithm { get; set; }
            public System.Int64? InlineChunkLength { get; set; }
            public System.String MetadataString { get; set; }
            public System.String ObjectChecksum { get; set; }
            public Amazon.BackupStorage.SummaryChecksumAlgorithm ObjectChecksumAlgorithm { get; set; }
            public System.String ObjectName { get; set; }
            public System.Boolean? ThrowOnDuplicate { get; set; }
            public System.Func<Amazon.BackupStorage.Model.PutObjectResponse, WriteBAKSObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
