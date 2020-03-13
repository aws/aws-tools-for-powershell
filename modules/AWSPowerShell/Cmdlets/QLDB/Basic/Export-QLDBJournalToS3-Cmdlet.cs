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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Exports journal contents within a date and time range from a ledger into a specified
    /// Amazon Simple Storage Service (Amazon S3) bucket. The data is written as files in
    /// Amazon Ion format.
    /// 
    ///  
    /// <para>
    /// If the ledger with the given <code>Name</code> doesn't exist, then throws <code>ResourceNotFoundException</code>.
    /// </para><para>
    /// If the ledger with the given <code>Name</code> is in <code>CREATING</code> status,
    /// then throws <code>ResourcePreconditionNotMetException</code>.
    /// </para><para>
    /// You can initiate up to two concurrent journal export requests for each ledger. Beyond
    /// this limit, journal export requests throw <code>LimitExceededException</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Export", "QLDBJournalToS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QLDB ExportJournalToS3 API operation.", Operation = new[] {"ExportJournalToS3"}, SelectReturnType = typeof(Amazon.QLDB.Model.ExportJournalToS3Response))]
    [AWSCmdletOutput("System.String or Amazon.QLDB.Model.ExportJournalToS3Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QLDB.Model.ExportJournalToS3Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ExportQLDBJournalToS3Cmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        #region Parameter S3ExportConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name in which a journal export job writes the journal contents.</para><para>The bucket name must comply with the Amazon S3 bucket naming conventions. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/BucketRestrictions.html">Bucket
        /// Restrictions and Limitations</a> in the <i>Amazon S3 Developer Guide</i>.</para>
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
        public System.String S3ExportConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter ExclusiveEndTime
        /// <summary>
        /// <para>
        /// <para>The exclusive end date and time for the range of journal contents that you want to
        /// export.</para><para>The <code>ExclusiveEndTime</code> must be in <code>ISO 8601</code> date and time format
        /// and in Universal Coordinated Time (UTC). For example: <code>2019-06-13T21:36:34Z</code></para><para>The <code>ExclusiveEndTime</code> must be less than or equal to the current UTC date
        /// and time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ExclusiveEndTime { get; set; }
        #endregion
        
        #region Parameter InclusiveStartTime
        /// <summary>
        /// <para>
        /// <para>The inclusive start date and time for the range of journal contents that you want
        /// to export.</para><para>The <code>InclusiveStartTime</code> must be in <code>ISO 8601</code> date and time
        /// format and in Universal Coordinated Time (UTC). For example: <code>2019-06-13T21:36:34Z</code></para><para>The <code>InclusiveStartTime</code> must be before <code>ExclusiveEndTime</code>.</para><para>If you provide an <code>InclusiveStartTime</code> that is before the ledger's <code>CreationDateTime</code>,
        /// Amazon QLDB defaults it to the ledger's <code>CreationDateTime</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? InclusiveStartTime { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for a symmetric customer master key (CMK) in AWS Key
        /// Management Service (AWS KMS). Amazon QLDB does not support asymmetric CMKs.</para><para>You must provide a <code>KmsKeyArn</code> if you specify <code>SSE_KMS</code> as the
        /// <code>ObjectEncryptionType</code>.</para><para><code>KmsKeyArn</code> is not required if you specify <code>SSE_S3</code> as the
        /// <code>ObjectEncryptionType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3ExportConfiguration_EncryptionConfiguration_KmsKeyArn")]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_ObjectEncryptionType
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object encryption type.</para><para>To learn more about server-side encryption options in Amazon S3, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/serv-side-encryption.html">Protecting
        /// Data Using Server-Side Encryption</a> in the <i>Amazon S3 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("S3ExportConfiguration_EncryptionConfiguration_ObjectEncryptionType")]
        [AWSConstantClassSource("Amazon.QLDB.S3ObjectEncryptionType")]
        public Amazon.QLDB.S3ObjectEncryptionType EncryptionConfiguration_ObjectEncryptionType { get; set; }
        #endregion
        
        #region Parameter S3ExportConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the Amazon S3 bucket in which a journal export job writes the journal
        /// contents.</para><para>The prefix must comply with Amazon S3 key naming rules and restrictions. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html">Object
        /// Key and Metadata</a> in the <i>Amazon S3 Developer Guide</i>.</para><para>The following are examples of valid <code>Prefix</code> values:</para><ul><li><para><code>JournalExports-ForMyLedger/Testing/</code></para></li><li><para><code>JournalExports</code></para></li><li><para><code>My:Tests/</code></para></li></ul>
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
        public System.String S3ExportConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants QLDB permissions for a
        /// journal export job to do the following:</para><ul><li><para>Write objects into your Amazon Simple Storage Service (Amazon S3) bucket.</para></li><li><para>(Optional) Use your customer master key (CMK) in AWS Key Management Service (AWS KMS)
        /// for server-side encryption of your exported data.</para></li></ul>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.ExportJournalToS3Response).
        /// Specifying the name of a property of type Amazon.QLDB.Model.ExportJournalToS3Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-QLDBJournalToS3 (ExportJournalToS3)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.ExportJournalToS3Response, ExportQLDBJournalToS3Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExclusiveEndTime = this.ExclusiveEndTime;
            #if MODULAR
            if (this.ExclusiveEndTime == null && ParameterWasBound(nameof(this.ExclusiveEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ExclusiveEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InclusiveStartTime = this.InclusiveStartTime;
            #if MODULAR
            if (this.InclusiveStartTime == null && ParameterWasBound(nameof(this.InclusiveStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter InclusiveStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3ExportConfiguration_Bucket = this.S3ExportConfiguration_Bucket;
            #if MODULAR
            if (this.S3ExportConfiguration_Bucket == null && ParameterWasBound(nameof(this.S3ExportConfiguration_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3ExportConfiguration_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_ObjectEncryptionType = this.EncryptionConfiguration_ObjectEncryptionType;
            #if MODULAR
            if (this.EncryptionConfiguration_ObjectEncryptionType == null && ParameterWasBound(nameof(this.EncryptionConfiguration_ObjectEncryptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionConfiguration_ObjectEncryptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3ExportConfiguration_Prefix = this.S3ExportConfiguration_Prefix;
            #if MODULAR
            if (this.S3ExportConfiguration_Prefix == null && ParameterWasBound(nameof(this.S3ExportConfiguration_Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter S3ExportConfiguration_Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.ExportJournalToS3Request();
            
            if (cmdletContext.ExclusiveEndTime != null)
            {
                request.ExclusiveEndTime = cmdletContext.ExclusiveEndTime.Value;
            }
            if (cmdletContext.InclusiveStartTime != null)
            {
                request.InclusiveStartTime = cmdletContext.InclusiveStartTime.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate S3ExportConfiguration
            var requestS3ExportConfigurationIsNull = true;
            request.S3ExportConfiguration = new Amazon.QLDB.Model.S3ExportConfiguration();
            System.String requestS3ExportConfiguration_s3ExportConfiguration_Bucket = null;
            if (cmdletContext.S3ExportConfiguration_Bucket != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_Bucket = cmdletContext.S3ExportConfiguration_Bucket;
            }
            if (requestS3ExportConfiguration_s3ExportConfiguration_Bucket != null)
            {
                request.S3ExportConfiguration.Bucket = requestS3ExportConfiguration_s3ExportConfiguration_Bucket;
                requestS3ExportConfigurationIsNull = false;
            }
            System.String requestS3ExportConfiguration_s3ExportConfiguration_Prefix = null;
            if (cmdletContext.S3ExportConfiguration_Prefix != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_Prefix = cmdletContext.S3ExportConfiguration_Prefix;
            }
            if (requestS3ExportConfiguration_s3ExportConfiguration_Prefix != null)
            {
                request.S3ExportConfiguration.Prefix = requestS3ExportConfiguration_s3ExportConfiguration_Prefix;
                requestS3ExportConfigurationIsNull = false;
            }
            Amazon.QLDB.Model.S3EncryptionConfiguration requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfigurationIsNull = true;
            requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration = new Amazon.QLDB.Model.S3EncryptionConfiguration();
            System.String requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration.KmsKeyArn = requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.QLDB.S3ObjectEncryptionType requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_ObjectEncryptionType = null;
            if (cmdletContext.EncryptionConfiguration_ObjectEncryptionType != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_ObjectEncryptionType = cmdletContext.EncryptionConfiguration_ObjectEncryptionType;
            }
            if (requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_ObjectEncryptionType != null)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration.ObjectEncryptionType = requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration_encryptionConfiguration_ObjectEncryptionType;
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration should be set to null
            if (requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfigurationIsNull)
            {
                requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration = null;
            }
            if (requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration != null)
            {
                request.S3ExportConfiguration.EncryptionConfiguration = requestS3ExportConfiguration_s3ExportConfiguration_EncryptionConfiguration;
                requestS3ExportConfigurationIsNull = false;
            }
             // determine if request.S3ExportConfiguration should be set to null
            if (requestS3ExportConfigurationIsNull)
            {
                request.S3ExportConfiguration = null;
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
        
        private Amazon.QLDB.Model.ExportJournalToS3Response CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.ExportJournalToS3Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "ExportJournalToS3");
            try
            {
                #if DESKTOP
                return client.ExportJournalToS3(request);
                #elif CORECLR
                return client.ExportJournalToS3Async(request).GetAwaiter().GetResult();
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
            public System.DateTime? ExclusiveEndTime { get; set; }
            public System.DateTime? InclusiveStartTime { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String S3ExportConfiguration_Bucket { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.QLDB.S3ObjectEncryptionType EncryptionConfiguration_ObjectEncryptionType { get; set; }
            public System.String S3ExportConfiguration_Prefix { get; set; }
            public System.Func<Amazon.QLDB.Model.ExportJournalToS3Response, ExportQLDBJournalToS3Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportId;
        }
        
    }
}
