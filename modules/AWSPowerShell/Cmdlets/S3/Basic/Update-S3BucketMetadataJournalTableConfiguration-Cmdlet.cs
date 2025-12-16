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
using System.Threading;
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Enables or disables journal table record expiration for an S3 Metadata configuration
    /// on a general purpose bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the <c>s3:UpdateBucketMetadataJournalTableConfiguration</c>
    /// permission. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    /// </para></dd></dl><para>
    /// The following operations are related to <c>UpdateBucketMetadataJournalTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataConfiguration.html">DeleteBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataConfiguration.html">GetBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UpdateBucketMetadataInventoryTableConfiguration.html">UpdateBucketMetadataInventoryTableConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "S3BucketMetadataJournalTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) UpdateBucketMetadataJournalTableConfiguration API operation.", Operation = new[] {"UpdateBucketMetadataJournalTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3BucketMetadataJournalTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para> The general purpose bucket that corresponds to the metadata configuration that you
        /// want to enable or disable journal table record expiration for. </para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para> The checksum algorithm to use with your journal table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para> The <c>Content-MD5</c> header for the journal table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter JournalTableConfiguration_RecordExpiration_Day
        /// <summary>
        /// <para>
        /// <para> If you enable journal table record expiration, you can set the number of days to
        /// retain your journal table records. Journal table records must be retained for a minimum
        /// of 7 days. To set this value, specify any whole number from <c>7</c> to <c>2147483647</c>.
        /// For example, to retain your journal table records for one year, set this value to
        /// <c>365</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JournalTableConfiguration_RecordExpiration_Days")]
        public System.Int32? JournalTableConfiguration_RecordExpiration_Day { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para> The expected owner of the general purpose bucket that corresponds to the metadata
        /// table configuration that you want to enable or disable journal table record expiration
        /// for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter JournalTableConfiguration_RecordExpiration_Expiration
        /// <summary>
        /// <para>
        /// <para> Specifies whether journal table record expiration is enabled or disabled. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3.ExpirationState")]
        public Amazon.S3.ExpirationState JournalTableConfiguration_RecordExpiration_Expiration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3BucketMetadataJournalTableConfiguration (UpdateBucketMetadataJournalTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse, UpdateS3BucketMetadataJournalTableConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.JournalTableConfiguration_RecordExpiration_Day = this.JournalTableConfiguration_RecordExpiration_Day;
            context.JournalTableConfiguration_RecordExpiration_Expiration = this.JournalTableConfiguration_RecordExpiration_Expiration;
            #if MODULAR
            if (this.JournalTableConfiguration_RecordExpiration_Expiration == null && ParameterWasBound(nameof(this.JournalTableConfiguration_RecordExpiration_Expiration)))
            {
                WriteWarning("You are passing $null as a value for parameter JournalTableConfiguration_RecordExpiration_Expiration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            
             // populate JournalTableConfiguration
            var requestJournalTableConfigurationIsNull = true;
            request.JournalTableConfiguration = new Amazon.S3.Model.JournalTableConfigurationUpdates();
            Amazon.S3.Model.RecordExpiration requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration = null;
            
             // populate RecordExpiration
            var requestJournalTableConfiguration_journalTableConfiguration_RecordExpirationIsNull = true;
            requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration = new Amazon.S3.Model.RecordExpiration();
            System.Int32? requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Day = null;
            if (cmdletContext.JournalTableConfiguration_RecordExpiration_Day != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Day = cmdletContext.JournalTableConfiguration_RecordExpiration_Day.Value;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Day != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration.Days = requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Day.Value;
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpirationIsNull = false;
            }
            Amazon.S3.ExpirationState requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Expiration = null;
            if (cmdletContext.JournalTableConfiguration_RecordExpiration_Expiration != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Expiration = cmdletContext.JournalTableConfiguration_RecordExpiration_Expiration;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Expiration != null)
            {
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration.Expiration = requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration_journalTableConfiguration_RecordExpiration_Expiration;
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpirationIsNull = false;
            }
             // determine if requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration should be set to null
            if (requestJournalTableConfiguration_journalTableConfiguration_RecordExpirationIsNull)
            {
                requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration = null;
            }
            if (requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration != null)
            {
                request.JournalTableConfiguration.RecordExpiration = requestJournalTableConfiguration_journalTableConfiguration_RecordExpiration;
                requestJournalTableConfigurationIsNull = false;
            }
             // determine if request.JournalTableConfiguration should be set to null
            if (requestJournalTableConfigurationIsNull)
            {
                request.JournalTableConfiguration = null;
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
        
        private Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "UpdateBucketMetadataJournalTableConfiguration");
            try
            {
                return client.UpdateBucketMetadataJournalTableConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Int32? JournalTableConfiguration_RecordExpiration_Day { get; set; }
            public Amazon.S3.ExpirationState JournalTableConfiguration_RecordExpiration_Expiration { get; set; }
            public System.Func<Amazon.S3.Model.UpdateBucketMetadataJournalTableConfigurationResponse, UpdateS3BucketMetadataJournalTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
