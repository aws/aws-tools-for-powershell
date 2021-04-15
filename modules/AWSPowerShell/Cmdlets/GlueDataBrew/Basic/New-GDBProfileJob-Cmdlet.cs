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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Creates a new job to analyze a dataset and create its data profile.
    /// </summary>
    [Cmdlet("New", "GDBProfileJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue DataBrew CreateProfileJob API operation.", Operation = new[] {"CreateProfileJob"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.CreateProfileJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.GlueDataBrew.Model.CreateProfileJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GlueDataBrew.Model.CreateProfileJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGDBProfileJobCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        #region Parameter OutputLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket name.</para>
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
        public System.String OutputLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset that this job is to act upon.</para>
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
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an encryption key that is used to protect the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode for the job, which can be one of the following:</para><ul><li><para><code>SSE-KMS</code> - <code>SSE-KMS</code> - Server-side encryption with AWS KMS-managed
        /// keys.</para></li><li><para><code>SSE-S3</code> - Server-side encryption with keys managed by Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.EncryptionMode")]
        public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
        #endregion
        
        #region Parameter OutputLocation_Key
        /// <summary>
        /// <para>
        /// <para>The unique name of the object in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation_Key { get; set; }
        #endregion
        
        #region Parameter LogSubscription
        /// <summary>
        /// <para>
        /// <para>Enables or disables Amazon CloudWatch logging for the job. If logging is enabled,
        /// CloudWatch writes one log stream for each job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.LogSubscription")]
        public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes that DataBrew can use when the job processes data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry the job after a job run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetries")]
        public System.Int32? MaxRetry { get; set; }
        #endregion
        
        #region Parameter JobSample_Mode
        /// <summary>
        /// <para>
        /// <para>A value that determines whether the profile job is run on the entire dataset or a
        /// specified number of rows. This value must be one of the following:</para><ul><li><para>FULL_DATASET - The profile job is run on the entire dataset.</para></li><li><para>CUSTOM_ROWS - The profile job is run on the number of rows specified in the <code>Size</code>
        /// parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.SampleMode")]
        public Amazon.GlueDataBrew.SampleMode JobSample_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the job to be created. Valid characters are alphanumeric (A-Z, a-z, 0-9),
        /// hyphen (-), period (.), and space.</para>
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
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// to be assumed when DataBrew runs the job.</para>
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
        
        #region Parameter JobSample_Size
        /// <summary>
        /// <para>
        /// <para>The <code>Size</code> parameter is only required when the mode is CUSTOM_ROWS. The
        /// profile job is run on the specified number of rows. The maximum value for size is
        /// Long.MAX_VALUE.</para><para>Long.MAX_VALUE = 9223372036854775807</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? JobSample_Size { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata tags to apply to this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The job's timeout in minutes. A job that attempts to run longer than this timeout
        /// period ends with a status of <code>TIMEOUT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.CreateProfileJobResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.CreateProfileJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDBProfileJob (CreateProfileJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.CreateProfileJobResponse, NewGDBProfileJobCmdlet>(Select) ??
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
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            context.EncryptionMode = this.EncryptionMode;
            context.JobSample_Mode = this.JobSample_Mode;
            context.JobSample_Size = this.JobSample_Size;
            context.LogSubscription = this.LogSubscription;
            context.MaxCapacity = this.MaxCapacity;
            context.MaxRetry = this.MaxRetry;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputLocation_Bucket = this.OutputLocation_Bucket;
            #if MODULAR
            if (this.OutputLocation_Bucket == null && ParameterWasBound(nameof(this.OutputLocation_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputLocation_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputLocation_Key = this.OutputLocation_Key;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.GlueDataBrew.Model.CreateProfileJobRequest();
            
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            if (cmdletContext.EncryptionMode != null)
            {
                request.EncryptionMode = cmdletContext.EncryptionMode;
            }
            
             // populate JobSample
            var requestJobSampleIsNull = true;
            request.JobSample = new Amazon.GlueDataBrew.Model.JobSample();
            Amazon.GlueDataBrew.SampleMode requestJobSample_jobSample_Mode = null;
            if (cmdletContext.JobSample_Mode != null)
            {
                requestJobSample_jobSample_Mode = cmdletContext.JobSample_Mode;
            }
            if (requestJobSample_jobSample_Mode != null)
            {
                request.JobSample.Mode = requestJobSample_jobSample_Mode;
                requestJobSampleIsNull = false;
            }
            System.Int64? requestJobSample_jobSample_Size = null;
            if (cmdletContext.JobSample_Size != null)
            {
                requestJobSample_jobSample_Size = cmdletContext.JobSample_Size.Value;
            }
            if (requestJobSample_jobSample_Size != null)
            {
                request.JobSample.Size = requestJobSample_jobSample_Size.Value;
                requestJobSampleIsNull = false;
            }
             // determine if request.JobSample should be set to null
            if (requestJobSampleIsNull)
            {
                request.JobSample = null;
            }
            if (cmdletContext.LogSubscription != null)
            {
                request.LogSubscription = cmdletContext.LogSubscription;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MaxRetry != null)
            {
                request.MaxRetries = cmdletContext.MaxRetry.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.GlueDataBrew.Model.S3Location();
            System.String requestOutputLocation_outputLocation_Bucket = null;
            if (cmdletContext.OutputLocation_Bucket != null)
            {
                requestOutputLocation_outputLocation_Bucket = cmdletContext.OutputLocation_Bucket;
            }
            if (requestOutputLocation_outputLocation_Bucket != null)
            {
                request.OutputLocation.Bucket = requestOutputLocation_outputLocation_Bucket;
                requestOutputLocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_Key = null;
            if (cmdletContext.OutputLocation_Key != null)
            {
                requestOutputLocation_outputLocation_Key = cmdletContext.OutputLocation_Key;
            }
            if (requestOutputLocation_outputLocation_Key != null)
            {
                request.OutputLocation.Key = requestOutputLocation_outputLocation_Key;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
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
        
        private Amazon.GlueDataBrew.Model.CreateProfileJobResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.CreateProfileJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "CreateProfileJob");
            try
            {
                #if DESKTOP
                return client.CreateProfileJob(request);
                #elif CORECLR
                return client.CreateProfileJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetName { get; set; }
            public System.String EncryptionKeyArn { get; set; }
            public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
            public Amazon.GlueDataBrew.SampleMode JobSample_Mode { get; set; }
            public System.Int64? JobSample_Size { get; set; }
            public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? MaxRetry { get; set; }
            public System.String Name { get; set; }
            public System.String OutputLocation_Bucket { get; set; }
            public System.String OutputLocation_Key { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.CreateProfileJobResponse, NewGDBProfileJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
