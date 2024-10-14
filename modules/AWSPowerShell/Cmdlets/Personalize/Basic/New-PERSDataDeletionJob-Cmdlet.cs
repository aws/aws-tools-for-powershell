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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Creates a batch job that deletes all references to specific users from an Amazon Personalize
    /// dataset group in batches. You specify the users to delete in a CSV file of userIds
    /// in an Amazon S3 bucket. After a job completes, Amazon Personalize no longer trains
    /// on the users’ data and no longer considers the users when generating user segments.
    /// For more information about creating a data deletion job, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/delete-records.html">Deleting
    /// users</a>.
    /// 
    ///  <ul><li><para>
    /// Your input file must be a CSV file with a single USER_ID column that lists the users
    /// IDs. For more information about preparing the CSV file, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/prepare-deletion-input-file.html">Preparing
    /// your data deletion file and uploading it to Amazon S3</a>.
    /// </para></li><li><para>
    /// To give Amazon Personalize permission to access your input CSV file of userIds, you
    /// must specify an IAM service role that has permission to read from the data source.
    /// This role needs <c>GetObject</c> and <c>ListBucket</c> permissions for the bucket
    /// and its content. These permissions are the same as importing data. For information
    /// on granting access to your Amazon S3 bucket, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/granting-personalize-s3-access.html">Giving
    /// Amazon Personalize Access to Amazon S3 Resources</a>. 
    /// </para></li></ul><para>
    ///  After you create a job, it can take up to a day to delete all references to the users
    /// from datasets and models. Until the job completes, Amazon Personalize continues to
    /// use the data when training. And if you use a User Segmentation recipe, the users might
    /// appear in user segments. 
    /// </para><para><b>Status</b></para><para>
    /// A data deletion job can have one of the following statuses:
    /// </para><ul><li><para>
    /// PENDING &gt; IN_PROGRESS &gt; COMPLETED -or- FAILED
    /// </para></li></ul><para>
    /// To get the status of the data deletion job, call <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeDataDeletionJob.html">DescribeDataDeletionJob</a>
    /// API operation and specify the Amazon Resource Name (ARN) of the job. If the status
    /// is FAILED, the response includes a <c>failureReason</c> key, which describes why the
    /// job failed.
    /// </para><para><b>Related APIs</b></para><ul><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListDataDeletionJobs.html">ListDataDeletionJobs</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeDataDeletionJob.html">DescribeDataDeletionJob</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PERSDataDeletionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateDataDeletionJob API operation.", Operation = new[] {"CreateDataDeletionJob"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateDataDeletionJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateDataDeletionJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateDataDeletionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPERSDataDeletionJobCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSource_DataLocation
        /// <summary>
        /// <para>
        /// <para>For dataset import jobs, the path to the Amazon S3 bucket where the data that you
        /// want to upload to your dataset is stored. For data deletion jobs, the path to the
        /// Amazon S3 bucket that stores the list of records to delete. </para><para> For example: </para><para><c>s3://bucket-name/folder-name/fileName.csv</c></para><para>If your CSV files are in a folder in your Amazon S3 bucket and you want your import
        /// job or data deletion job to consider multiple files, you can specify the path to the
        /// folder. With a data deletion job, Amazon Personalize uses all files in the folder
        /// and any sub folder. Use the following syntax with a <c>/</c> after the folder name:</para><para><c>s3://bucket-name/folder-name/</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_DataLocation { get; set; }
        #endregion
        
        #region Parameter DatasetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset group that has the datasets you want
        /// to delete records from.</para>
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
        public System.String DatasetGroupArn { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name for the data deletion job.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that has permissions to read from the
        /// Amazon S3 data source.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/personalize/latest/dg/tagging-resources.html">tags</a>
        /// to apply to the data deletion job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Personalize.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataDeletionJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateDataDeletionJobResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateDataDeletionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataDeletionJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetGroupArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetGroupArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetGroupArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSDataDeletionJob (CreateDataDeletionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateDataDeletionJobResponse, NewPERSDataDeletionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetGroupArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetGroupArn = this.DatasetGroupArn;
            #if MODULAR
            if (this.DatasetGroupArn == null && ParameterWasBound(nameof(this.DatasetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSource_DataLocation = this.DataSource_DataLocation;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Personalize.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Personalize.Model.CreateDataDeletionJobRequest();
            
            if (cmdletContext.DatasetGroupArn != null)
            {
                request.DatasetGroupArn = cmdletContext.DatasetGroupArn;
            }
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.Personalize.Model.DataSource();
            System.String requestDataSource_dataSource_DataLocation = null;
            if (cmdletContext.DataSource_DataLocation != null)
            {
                requestDataSource_dataSource_DataLocation = cmdletContext.DataSource_DataLocation;
            }
            if (requestDataSource_dataSource_DataLocation != null)
            {
                request.DataSource.DataLocation = requestDataSource_dataSource_DataLocation;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Personalize.Model.CreateDataDeletionJobResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateDataDeletionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateDataDeletionJob");
            try
            {
                #if DESKTOP
                return client.CreateDataDeletionJob(request);
                #elif CORECLR
                return client.CreateDataDeletionJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetGroupArn { get; set; }
            public System.String DataSource_DataLocation { get; set; }
            public System.String JobName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.Personalize.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateDataDeletionJobResponse, NewPERSDataDeletionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataDeletionJobArn;
        }
        
    }
}
