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
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// This operation initiates a job of the specified type, which can be a select, an archival
    /// retrieval, or a vault retrieval. For more information about using this operation,
    /// see the documentation for the underlying REST API <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/api-initiate-job-post.html">Initiate
    /// a Job</a>.
    /// </summary>
    [Cmdlet("Start", "GLCJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glacier.Model.InitiateJobResponse")]
    [AWSCmdlet("Calls the Amazon Glacier InitiateJob API operation.", Operation = new[] {"InitiateJob"}, SelectReturnType = typeof(Amazon.Glacier.Model.InitiateJobResponse))]
    [AWSCmdletOutput("Amazon.Glacier.Model.InitiateJobResponse",
        "This cmdlet returns an Amazon.Glacier.Model.InitiateJobResponse object containing multiple properties."
    )]
    public partial class StartGLCJobCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>AccountId</c> value is the AWS account ID of the account that owns the vault.
        /// You can either specify an AWS account ID or optionally a single '<c>-</c>' (hyphen),
        /// in which case Amazon Glacier uses the AWS account ID associated with the credentials
        /// used to sign the request. If you use an account ID, do not include any hyphens ('-')
        /// in the ID.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ArchiveId
        /// <summary>
        /// <para>
        /// <para>The ID of the archive that you want to retrieve. This field is required only if <c>Type</c>
        /// is set to <c>select</c> or <c>archive-retrieval</c>code&gt;. An error occurs if you
        /// specify this request parameter for an inventory retrieval job request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_ArchiveId")]
        public System.String ArchiveId { get; set; }
        #endregion
        
        #region Parameter JobDescription
        /// <summary>
        /// <para>
        /// <para>The optional description for the job. The description must be less than or equal to
        /// 1,024 bytes. The allowable characters are 7-bit ASCII without control codes-specifically,
        /// ASCII values 32-126 decimal or 0x20-0x7E hexadecimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_Description")]
        public System.String JobDescription { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>When initiating a job to retrieve a vault inventory, you can optionally add this parameter
        /// to your request to specify the output format. If you are initiating an inventory job
        /// and do not specify a Format field, JSON is the default format. Valid values are "CSV"
        /// and "JSON".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_Format")]
        public System.String OutputFormat { get; set; }
        #endregion
        
        #region Parameter InventoryRetrieval
        /// <summary>
        /// <para>
        /// <para>Input parameters used for range inventory retrieval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_InventoryRetrievalParameters")]
        public Amazon.Glacier.Model.InventoryRetrievalJobInput InventoryRetrieval { get; set; }
        #endregion
        
        #region Parameter OutputLocation
        /// <summary>
        /// <para>
        /// <para>Contains information about the location where the select job results are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_OutputLocation")]
        public Amazon.Glacier.Model.OutputLocation OutputLocation { get; set; }
        #endregion
        
        #region Parameter RetrievalByteRange
        /// <summary>
        /// <para>
        /// <para>The byte range to retrieve for an archive retrieval. in the form "<i>StartByteValue</i>-<i>EndByteValue</i>"
        /// If not specified, the whole archive is retrieved. If specified, the byte range must
        /// be megabyte (1024*1024) aligned which means that <i>StartByteValue</i> must be divisible
        /// by 1 MB and <i>EndByteValue</i> plus 1 must be divisible by 1 MB or be the end of
        /// the archive specified as the archive byte size value minus 1. If RetrievalByteRange
        /// is not megabyte aligned, this operation returns a 400 response. </para><para>An error occurs if you specify this field for an inventory retrieval job request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_RetrievalByteRange")]
        public System.String RetrievalByteRange { get; set; }
        #endregion
        
        #region Parameter SelectParameter
        /// <summary>
        /// <para>
        /// <para>Contains the parameters that define a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_SelectParameters")]
        public Amazon.Glacier.Model.SelectParameters SelectParameter { get; set; }
        #endregion
        
        #region Parameter SNSTopic
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic ARN to which Amazon Glacier sends a notification when the job
        /// is completed and the output is ready for you to download. The specified topic publishes
        /// the notification to its subscribers. The SNS topic must exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_SNSTopic")]
        public System.String SNSTopic { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The tier to use for a select or an archive retrieval job. Valid values are <c>Expedited</c>,
        /// <c>Standard</c>, or <c>Bulk</c>. <c>Standard</c> is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_Tier")]
        public System.String Tier { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>The job type. You can initiate a job to perform a select query on an archive, retrieve
        /// an archive, or get an inventory of a vault. Valid values are "select", "archive-retrieval"
        /// and "inventory-retrieval".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParameters_Type")]
        public System.String JobType { get; set; }
        #endregion
        
        #region Parameter VaultName
        /// <summary>
        /// <para>
        /// <para>The name of the vault.</para>
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
        public System.String VaultName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glacier.Model.InitiateJobResponse).
        /// Specifying the name of a property of type Amazon.Glacier.Model.InitiateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VaultName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VaultName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VaultName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GLCJob (InitiateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glacier.Model.InitiateJobResponse, StartGLCJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VaultName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            if (!ParameterWasBound(nameof(this.AccountId)))
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArchiveId = this.ArchiveId;
            context.JobDescription = this.JobDescription;
            context.OutputFormat = this.OutputFormat;
            context.InventoryRetrieval = this.InventoryRetrieval;
            context.OutputLocation = this.OutputLocation;
            context.RetrievalByteRange = this.RetrievalByteRange;
            context.SelectParameter = this.SelectParameter;
            context.SNSTopic = this.SNSTopic;
            context.Tier = this.Tier;
            context.JobType = this.JobType;
            context.VaultName = this.VaultName;
            #if MODULAR
            if (this.VaultName == null && ParameterWasBound(nameof(this.VaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter VaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glacier.Model.InitiateJobRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate JobParameters
            var requestJobParametersIsNull = true;
            request.JobParameters = new Amazon.Glacier.Model.JobParameters();
            System.String requestJobParameters_archiveId = null;
            if (cmdletContext.ArchiveId != null)
            {
                requestJobParameters_archiveId = cmdletContext.ArchiveId;
            }
            if (requestJobParameters_archiveId != null)
            {
                request.JobParameters.ArchiveId = requestJobParameters_archiveId;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_jobDescription = null;
            if (cmdletContext.JobDescription != null)
            {
                requestJobParameters_jobDescription = cmdletContext.JobDescription;
            }
            if (requestJobParameters_jobDescription != null)
            {
                request.JobParameters.Description = requestJobParameters_jobDescription;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_outputFormat = null;
            if (cmdletContext.OutputFormat != null)
            {
                requestJobParameters_outputFormat = cmdletContext.OutputFormat;
            }
            if (requestJobParameters_outputFormat != null)
            {
                request.JobParameters.Format = requestJobParameters_outputFormat;
                requestJobParametersIsNull = false;
            }
            Amazon.Glacier.Model.InventoryRetrievalJobInput requestJobParameters_inventoryRetrieval = null;
            if (cmdletContext.InventoryRetrieval != null)
            {
                requestJobParameters_inventoryRetrieval = cmdletContext.InventoryRetrieval;
            }
            if (requestJobParameters_inventoryRetrieval != null)
            {
                request.JobParameters.InventoryRetrievalParameters = requestJobParameters_inventoryRetrieval;
                requestJobParametersIsNull = false;
            }
            Amazon.Glacier.Model.OutputLocation requestJobParameters_outputLocation = null;
            if (cmdletContext.OutputLocation != null)
            {
                requestJobParameters_outputLocation = cmdletContext.OutputLocation;
            }
            if (requestJobParameters_outputLocation != null)
            {
                request.JobParameters.OutputLocation = requestJobParameters_outputLocation;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_retrievalByteRange = null;
            if (cmdletContext.RetrievalByteRange != null)
            {
                requestJobParameters_retrievalByteRange = cmdletContext.RetrievalByteRange;
            }
            if (requestJobParameters_retrievalByteRange != null)
            {
                request.JobParameters.RetrievalByteRange = requestJobParameters_retrievalByteRange;
                requestJobParametersIsNull = false;
            }
            Amazon.Glacier.Model.SelectParameters requestJobParameters_selectParameter = null;
            if (cmdletContext.SelectParameter != null)
            {
                requestJobParameters_selectParameter = cmdletContext.SelectParameter;
            }
            if (requestJobParameters_selectParameter != null)
            {
                request.JobParameters.SelectParameters = requestJobParameters_selectParameter;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_sNSTopic = null;
            if (cmdletContext.SNSTopic != null)
            {
                requestJobParameters_sNSTopic = cmdletContext.SNSTopic;
            }
            if (requestJobParameters_sNSTopic != null)
            {
                request.JobParameters.SNSTopic = requestJobParameters_sNSTopic;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_tier = null;
            if (cmdletContext.Tier != null)
            {
                requestJobParameters_tier = cmdletContext.Tier;
            }
            if (requestJobParameters_tier != null)
            {
                request.JobParameters.Tier = requestJobParameters_tier;
                requestJobParametersIsNull = false;
            }
            System.String requestJobParameters_jobType = null;
            if (cmdletContext.JobType != null)
            {
                requestJobParameters_jobType = cmdletContext.JobType;
            }
            if (requestJobParameters_jobType != null)
            {
                request.JobParameters.Type = requestJobParameters_jobType;
                requestJobParametersIsNull = false;
            }
             // determine if request.JobParameters should be set to null
            if (requestJobParametersIsNull)
            {
                request.JobParameters = null;
            }
            if (cmdletContext.VaultName != null)
            {
                request.VaultName = cmdletContext.VaultName;
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
        
        private Amazon.Glacier.Model.InitiateJobResponse CallAWSServiceOperation(IAmazonGlacier client, Amazon.Glacier.Model.InitiateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Glacier", "InitiateJob");
            try
            {
                #if DESKTOP
                return client.InitiateJob(request);
                #elif CORECLR
                return client.InitiateJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ArchiveId { get; set; }
            public System.String JobDescription { get; set; }
            public System.String OutputFormat { get; set; }
            public Amazon.Glacier.Model.InventoryRetrievalJobInput InventoryRetrieval { get; set; }
            public Amazon.Glacier.Model.OutputLocation OutputLocation { get; set; }
            public System.String RetrievalByteRange { get; set; }
            public Amazon.Glacier.Model.SelectParameters SelectParameter { get; set; }
            public System.String SNSTopic { get; set; }
            public System.String Tier { get; set; }
            public System.String JobType { get; set; }
            public System.String VaultName { get; set; }
            public System.Func<Amazon.Glacier.Model.InitiateJobResponse, StartGLCJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
