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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This operation sets the versioning state for S3 on Outposts buckets only. To set the
    /// versioning state for an S3 bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketVersioning.html">PutBucketVersioning</a>
    /// in the <i>Amazon S3 API Reference</i>. 
    /// </para></note><para>
    /// Sets the versioning state for an S3 on Outposts bucket. With S3 Versioning, you can
    /// save multiple distinct copies of your objects and recover from unintended user actions
    /// and application failures.
    /// </para><para>
    /// You can set the versioning state to one of the following:
    /// </para><ul><li><para><b>Enabled</b> - Enables versioning for the objects in the bucket. All objects added
    /// to the bucket receive a unique version ID.
    /// </para></li><li><para><b>Suspended</b> - Suspends versioning for the objects in the bucket. All objects
    /// added to the bucket receive the version ID <c>null</c>.
    /// </para></li></ul><para>
    /// If you've never set versioning on your bucket, it has no versioning state. In that
    /// case, a <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketVersioning.html">
    /// GetBucketVersioning</a> request does not return a versioning state value.
    /// </para><para>
    /// When you enable S3 Versioning, for each object in your bucket, you have a current
    /// version and zero or more noncurrent versions. You can configure your bucket S3 Lifecycle
    /// rules to expire noncurrent versions after a specified time period. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3OutpostsLifecycleManaging.html">
    /// Creating and managing a lifecycle configuration for your S3 on Outposts bucket</a>
    /// in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If you have an object expiration lifecycle configuration in your non-versioned bucket
    /// and you want to maintain the same permanent delete behavior when you enable versioning,
    /// you must add a noncurrent expiration policy. The noncurrent expiration lifecycle configuration
    /// will manage the deletes of the noncurrent object versions in the version-enabled bucket.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/Versioning.html">Versioning</a>
    /// in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// All Amazon S3 on Outposts REST API requests for this action require an additional
    /// parameter of <c>x-amz-outpost-id</c> to be passed with the request. In addition, you
    /// must use an S3 on Outposts endpoint hostname prefix instead of <c>s3-control</c>.
    /// For an example of the request syntax for Amazon S3 on Outposts that uses the S3 on
    /// Outposts endpoint hostname prefix and the <c>x-amz-outpost-id</c> derived by using
    /// the access point ARN, see the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_PutBucketVersioning.html#API_control_PutBucketVersioning_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// The following operations are related to <c>PutBucketVersioning</c> for S3 on Outposts.
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketVersioning.html">GetBucketVersioning</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_PutBucketLifecycleConfiguration.html">PutBucketLifecycleConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketLifecycleConfiguration.html">GetBucketLifecycleConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3CBucketVersioning", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutBucketVersioning API operation.", Operation = new[] {"PutBucketVersioning"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutBucketVersioningResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutBucketVersioningResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutBucketVersioningResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3CBucketVersioningCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the S3 on Outposts bucket.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 on Outposts bucket to set the versioning state for.</para>
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
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter MFA
        /// <summary>
        /// <para>
        /// <para>The concatenation of the authentication device's serial number, a space, and the value
        /// that is displayed on your authentication device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MFA { get; set; }
        #endregion
        
        #region Parameter VersioningConfiguration_MFADelete
        /// <summary>
        /// <para>
        /// <para>Specifies whether MFA delete is enabled or disabled in the bucket versioning configuration
        /// for the S3 on Outposts bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.MFADelete")]
        public Amazon.S3Control.MFADelete VersioningConfiguration_MFADelete { get; set; }
        #endregion
        
        #region Parameter VersioningConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>Sets the versioning state of the S3 on Outposts bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.BucketVersioningStatus")]
        public Amazon.S3Control.BucketVersioningStatus VersioningConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutBucketVersioningResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CBucketVersioning (PutBucketVersioning)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutBucketVersioningResponse, WriteS3CBucketVersioningCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Bucket = this.Bucket;
            #if MODULAR
            if (this.Bucket == null && ParameterWasBound(nameof(this.Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MFA = this.MFA;
            context.VersioningConfiguration_MFADelete = this.VersioningConfiguration_MFADelete;
            context.VersioningConfiguration_Status = this.VersioningConfiguration_Status;
            
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
            var request = new Amazon.S3Control.Model.PutBucketVersioningRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            if (cmdletContext.MFA != null)
            {
                request.MFA = cmdletContext.MFA;
            }
            
             // populate VersioningConfiguration
            var requestVersioningConfigurationIsNull = true;
            request.VersioningConfiguration = new Amazon.S3Control.Model.VersioningConfiguration();
            Amazon.S3Control.MFADelete requestVersioningConfiguration_versioningConfiguration_MFADelete = null;
            if (cmdletContext.VersioningConfiguration_MFADelete != null)
            {
                requestVersioningConfiguration_versioningConfiguration_MFADelete = cmdletContext.VersioningConfiguration_MFADelete;
            }
            if (requestVersioningConfiguration_versioningConfiguration_MFADelete != null)
            {
                request.VersioningConfiguration.MFADelete = requestVersioningConfiguration_versioningConfiguration_MFADelete;
                requestVersioningConfigurationIsNull = false;
            }
            Amazon.S3Control.BucketVersioningStatus requestVersioningConfiguration_versioningConfiguration_Status = null;
            if (cmdletContext.VersioningConfiguration_Status != null)
            {
                requestVersioningConfiguration_versioningConfiguration_Status = cmdletContext.VersioningConfiguration_Status;
            }
            if (requestVersioningConfiguration_versioningConfiguration_Status != null)
            {
                request.VersioningConfiguration.Status = requestVersioningConfiguration_versioningConfiguration_Status;
                requestVersioningConfigurationIsNull = false;
            }
             // determine if request.VersioningConfiguration should be set to null
            if (requestVersioningConfigurationIsNull)
            {
                request.VersioningConfiguration = null;
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
        
        private Amazon.S3Control.Model.PutBucketVersioningResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutBucketVersioningRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutBucketVersioning");
            try
            {
                #if DESKTOP
                return client.PutBucketVersioning(request);
                #elif CORECLR
                return client.PutBucketVersioningAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String Bucket { get; set; }
            public System.String MFA { get; set; }
            public Amazon.S3Control.MFADelete VersioningConfiguration_MFADelete { get; set; }
            public Amazon.S3Control.BucketVersioningStatus VersioningConfiguration_Status { get; set; }
            public System.Func<Amazon.S3Control.Model.PutBucketVersioningResponse, WriteS3CBucketVersioningCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
