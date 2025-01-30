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
    /// Sets the supplied tag-set on an S3 Batch Operations job.
    /// 
    ///  
    /// <para>
    /// A tag is a key-value pair. You can associate S3 Batch Operations tags with any job
    /// by sending a PUT request against the tagging subresource that is associated with the
    /// job. To modify the existing tag set, you can either replace the existing tag set entirely,
    /// or make changes within the existing tag set by retrieving the existing tag set using
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetJobTagging.html">GetJobTagging</a>,
    /// modify that tag set, and use this operation to replace the tag set with the one you
    /// modified. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/batch-ops-managing-jobs.html#batch-ops-job-tags">Controlling
    /// access and labeling jobs using tags</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para><note><ul><li><para>
    /// If you send this request with an empty tag set, Amazon S3 deletes the existing tag
    /// set on the Batch Operations job. If you use this method, you are charged for a Tier
    /// 1 Request (PUT). For more information, see <a href="http://aws.amazon.com/s3/pricing/">Amazon
    /// S3 pricing</a>.
    /// </para></li><li><para>
    /// For deleting existing tags for your Batch Operations job, a <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteJobTagging.html">DeleteJobTagging</a>
    /// request is preferred because it achieves the same result without incurring charges.
    /// </para></li><li><para>
    /// A few things to consider about using tags:
    /// </para><ul><li><para>
    /// Amazon S3 limits the maximum number of tags to 50 tags per job.
    /// </para></li><li><para>
    /// You can associate up to 50 tags with a job as long as they have unique tag keys.
    /// </para></li><li><para>
    /// A tag key can be up to 128 Unicode characters in length, and tag values can be up
    /// to 256 Unicode characters in length.
    /// </para></li><li><para>
    /// The key and values are case sensitive.
    /// </para></li><li><para>
    /// For tagging-related restrictions related to characters and encodings, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/allocation-tag-restrictions.html">User-Defined
    /// Tag Restrictions</a> in the <i>Billing and Cost Management User Guide</i>.
    /// </para></li></ul></li></ul></note><dl><dt>Permissions</dt><dd><para>
    /// To use the <c>PutJobTagging</c> operation, you must have permission to perform the
    /// <c>s3:PutJobTagging</c> action.
    /// </para></dd></dl><para>
    /// Related actions include:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateJob.html">CreateJob</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetJobTagging.html">GetJobTagging</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteJobTagging.html">DeleteJobTagging</a></para></li></ul>
    /// </summary>
    [Cmdlet("Add", "S3CJobTagging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutJobTagging API operation.", Operation = new[] {"PutJobTagging"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutJobTaggingResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutJobTaggingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutJobTaggingResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddS3CJobTaggingCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the S3 Batch Operations job.</para>
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
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The ID for the S3 Batch Operations job whose tags you want to replace.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The set of tags to associate with the S3 Batch Operations job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Tags")]
        public Amazon.S3Control.Model.S3Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutJobTaggingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-S3CJobTagging (PutJobTagging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutJobTaggingResponse, AddS3CJobTaggingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.S3Tag>(this.Tag);
            }
            #if MODULAR
            if (this.Tag == null && ParameterWasBound(nameof(this.Tag)))
            {
                WriteWarning("You are passing $null as a value for parameter Tag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Control.Model.PutJobTaggingRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.S3Control.Model.PutJobTaggingResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutJobTaggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutJobTagging");
            try
            {
                #if DESKTOP
                return client.PutJobTagging(request);
                #elif CORECLR
                return client.PutJobTaggingAsync(request).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.PutJobTaggingResponse, AddS3CJobTaggingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
