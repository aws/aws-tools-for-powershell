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
using Amazon.Personalize;
using Amazon.Personalize.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Creates a batch segment job. The operation can handle up to 50 million records and
    /// the input file must be in JSON format. For more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/recommendations-batch.html">Getting
    /// batch recommendations and user segments</a>.
    /// </summary>
    [Cmdlet("New", "PERSBatchSegmentJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateBatchSegmentJob API operation.", Operation = new[] {"CreateBatchSegmentJob"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateBatchSegmentJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateBatchSegmentJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateBatchSegmentJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPERSBatchSegmentJobCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the filter to apply to the batch segment job. For more information on using
        /// filters, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/filter-batch.html">Filtering
        /// batch recommendations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterArn { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the batch segment job to create.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter S3DataSource_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key that Amazon
        /// Personalize uses to encrypt or decrypt the input and output files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobInput_S3DataSource_KmsKeyArn")]
        public System.String S3DataSource_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key that Amazon
        /// Personalize uses to encrypt or decrypt the input and output files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobOutput_S3DataDestination_KmsKeyArn")]
        public System.String S3DataDestination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter NumResult
        /// <summary>
        /// <para>
        /// <para>The number of predicted users generated by the batch segment job for each line of
        /// input data. The maximum number of users per segment is 5 million.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumResults")]
        public System.Int32? NumResult { get; set; }
        #endregion
        
        #region Parameter S3DataSource_Path
        /// <summary>
        /// <para>
        /// <para>The file path of the Amazon S3 bucket.</para>
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
        [Alias("JobInput_S3DataSource_Path")]
        public System.String S3DataSource_Path { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_Path
        /// <summary>
        /// <para>
        /// <para>The file path of the Amazon S3 bucket.</para>
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
        [Alias("JobOutput_S3DataDestination_Path")]
        public System.String S3DataDestination_Path { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Identity and Access Management role that has permissions to
        /// read and write to your input and output Amazon S3 buckets respectively.</para>
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
        
        #region Parameter SolutionVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the solution version you want the batch segment
        /// job to use to generate batch segments.</para>
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
        public System.String SolutionVersionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/personalize/latest/dg/tagging-resources.html">tags</a>
        /// to apply to the batch segment job.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Personalize.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchSegmentJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateBatchSegmentJobResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateBatchSegmentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchSegmentJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSBatchSegmentJob (CreateBatchSegmentJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateBatchSegmentJobResponse, NewPERSBatchSegmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterArn = this.FilterArn;
            context.S3DataSource_KmsKeyArn = this.S3DataSource_KmsKeyArn;
            context.S3DataSource_Path = this.S3DataSource_Path;
            #if MODULAR
            if (this.S3DataSource_Path == null && ParameterWasBound(nameof(this.S3DataSource_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter S3DataSource_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3DataDestination_KmsKeyArn = this.S3DataDestination_KmsKeyArn;
            context.S3DataDestination_Path = this.S3DataDestination_Path;
            #if MODULAR
            if (this.S3DataDestination_Path == null && ParameterWasBound(nameof(this.S3DataDestination_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter S3DataDestination_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumResult = this.NumResult;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SolutionVersionArn = this.SolutionVersionArn;
            #if MODULAR
            if (this.SolutionVersionArn == null && ParameterWasBound(nameof(this.SolutionVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SolutionVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.CreateBatchSegmentJobRequest();
            
            if (cmdletContext.FilterArn != null)
            {
                request.FilterArn = cmdletContext.FilterArn;
            }
            
             // populate JobInput
            var requestJobInputIsNull = true;
            request.JobInput = new Amazon.Personalize.Model.BatchSegmentJobInput();
            Amazon.Personalize.Model.S3DataConfig requestJobInput_jobInput_S3DataSource = null;
            
             // populate S3DataSource
            var requestJobInput_jobInput_S3DataSourceIsNull = true;
            requestJobInput_jobInput_S3DataSource = new Amazon.Personalize.Model.S3DataConfig();
            System.String requestJobInput_jobInput_S3DataSource_s3DataSource_KmsKeyArn = null;
            if (cmdletContext.S3DataSource_KmsKeyArn != null)
            {
                requestJobInput_jobInput_S3DataSource_s3DataSource_KmsKeyArn = cmdletContext.S3DataSource_KmsKeyArn;
            }
            if (requestJobInput_jobInput_S3DataSource_s3DataSource_KmsKeyArn != null)
            {
                requestJobInput_jobInput_S3DataSource.KmsKeyArn = requestJobInput_jobInput_S3DataSource_s3DataSource_KmsKeyArn;
                requestJobInput_jobInput_S3DataSourceIsNull = false;
            }
            System.String requestJobInput_jobInput_S3DataSource_s3DataSource_Path = null;
            if (cmdletContext.S3DataSource_Path != null)
            {
                requestJobInput_jobInput_S3DataSource_s3DataSource_Path = cmdletContext.S3DataSource_Path;
            }
            if (requestJobInput_jobInput_S3DataSource_s3DataSource_Path != null)
            {
                requestJobInput_jobInput_S3DataSource.Path = requestJobInput_jobInput_S3DataSource_s3DataSource_Path;
                requestJobInput_jobInput_S3DataSourceIsNull = false;
            }
             // determine if requestJobInput_jobInput_S3DataSource should be set to null
            if (requestJobInput_jobInput_S3DataSourceIsNull)
            {
                requestJobInput_jobInput_S3DataSource = null;
            }
            if (requestJobInput_jobInput_S3DataSource != null)
            {
                request.JobInput.S3DataSource = requestJobInput_jobInput_S3DataSource;
                requestJobInputIsNull = false;
            }
             // determine if request.JobInput should be set to null
            if (requestJobInputIsNull)
            {
                request.JobInput = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate JobOutput
            var requestJobOutputIsNull = true;
            request.JobOutput = new Amazon.Personalize.Model.BatchSegmentJobOutput();
            Amazon.Personalize.Model.S3DataConfig requestJobOutput_jobOutput_S3DataDestination = null;
            
             // populate S3DataDestination
            var requestJobOutput_jobOutput_S3DataDestinationIsNull = true;
            requestJobOutput_jobOutput_S3DataDestination = new Amazon.Personalize.Model.S3DataConfig();
            System.String requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn = null;
            if (cmdletContext.S3DataDestination_KmsKeyArn != null)
            {
                requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn = cmdletContext.S3DataDestination_KmsKeyArn;
            }
            if (requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn != null)
            {
                requestJobOutput_jobOutput_S3DataDestination.KmsKeyArn = requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn;
                requestJobOutput_jobOutput_S3DataDestinationIsNull = false;
            }
            System.String requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path = null;
            if (cmdletContext.S3DataDestination_Path != null)
            {
                requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path = cmdletContext.S3DataDestination_Path;
            }
            if (requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path != null)
            {
                requestJobOutput_jobOutput_S3DataDestination.Path = requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path;
                requestJobOutput_jobOutput_S3DataDestinationIsNull = false;
            }
             // determine if requestJobOutput_jobOutput_S3DataDestination should be set to null
            if (requestJobOutput_jobOutput_S3DataDestinationIsNull)
            {
                requestJobOutput_jobOutput_S3DataDestination = null;
            }
            if (requestJobOutput_jobOutput_S3DataDestination != null)
            {
                request.JobOutput.S3DataDestination = requestJobOutput_jobOutput_S3DataDestination;
                requestJobOutputIsNull = false;
            }
             // determine if request.JobOutput should be set to null
            if (requestJobOutputIsNull)
            {
                request.JobOutput = null;
            }
            if (cmdletContext.NumResult != null)
            {
                request.NumResults = cmdletContext.NumResult.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SolutionVersionArn != null)
            {
                request.SolutionVersionArn = cmdletContext.SolutionVersionArn;
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
        
        private Amazon.Personalize.Model.CreateBatchSegmentJobResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateBatchSegmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateBatchSegmentJob");
            try
            {
                return client.CreateBatchSegmentJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FilterArn { get; set; }
            public System.String S3DataSource_KmsKeyArn { get; set; }
            public System.String S3DataSource_Path { get; set; }
            public System.String JobName { get; set; }
            public System.String S3DataDestination_KmsKeyArn { get; set; }
            public System.String S3DataDestination_Path { get; set; }
            public System.Int32? NumResult { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SolutionVersionArn { get; set; }
            public List<Amazon.Personalize.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateBatchSegmentJobResponse, NewPERSBatchSegmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchSegmentJobArn;
        }
        
    }
}
