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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Starts a Neptune bulk loader job to load data from an Amazon S3 bucket into a Neptune
    /// DB instance. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load.html">Using
    /// the Amazon Neptune Bulk Loader to Ingest Data</a>.
    /// </summary>
    [Cmdlet("Start", "NEPTLoaderJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptunedata.Model.StartLoaderJobResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData StartLoaderJob API operation.", Operation = new[] {"StartLoaderJob"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.StartLoaderJobResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.StartLoaderJobResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.StartLoaderJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartNEPTLoaderJobCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        #region Parameter Dependency
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter that can make a queued load request contingent on the
        /// successful completion of one or more previous jobs in the queue.</para><para>Neptune can queue up as many as 64 load requests at a time, if their <code>queueRequest</code>
        /// parameters are set to <code>"TRUE"</code>. The <code>dependencies</code> parameter
        /// lets you make execution of such a queued request dependent on the successful completion
        /// of one or more specified previous requests in the queue.</para><para>For example, if load <code>Job-A</code> and <code>Job-B</code> are independent of
        /// each other, but load <code>Job-C</code> needs <code>Job-A</code> and <code>Job-B</code>
        /// to be finished before it begins, proceed as follows:</para><ol><li><para>Submit <code>load-job-A</code> and <code>load-job-B</code> one after another in any
        /// order, and save their load-ids.</para></li><li><para>Submit <code>load-job-C</code> with the load-ids of the two jobs in its <code>dependencies</code>
        /// field:</para></li></ol><para>Because of the <code>dependencies</code> parameter, the bulk loader will not start
        /// <code>Job-C</code> until <code>Job-A</code> and <code>Job-B</code> have completed
        /// successfully. If either one of them fails, Job-C will not be executed, and its status
        /// will be set to <code>LOAD_FAILED_BECAUSE_DEPENDENCY_NOT_SATISFIED</code>.</para><para>You can set up multiple levels of dependency in this way, so that the failure of one
        /// job will cause all requests that are directly or indirectly dependent on it to be
        /// cancelled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dependencies")]
        public System.String[] Dependency { get; set; }
        #endregion
        
        #region Parameter FailOnError
        /// <summary>
        /// <para>
        /// <para><b><code>failOnError</code></b>   –   A flag to toggle a complete stop on an error.</para><para><i>Allowed values</i>: <code>"TRUE"</code>, <code>"FALSE"</code>.</para><para><i>Default value</i>: <code>"TRUE"</code>.</para><para>When this parameter is set to <code>"FALSE"</code>, the loader tries to load all the
        /// data in the location specified, skipping any entries with errors.</para><para>When this parameter is set to <code>"TRUE"</code>, the loader stops as soon as it
        /// encounters an error. Data loaded up to that point persists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FailOnError { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// Amazon.Neptunedata.Model.StartLoaderJobRequest.Format
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Neptunedata.Format")]
        public Amazon.Neptunedata.Format Format { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for an IAM role to be assumed by the Neptune DB instance
        /// for access to the S3 bucket. The IAM role ARN provided here should be attached to
        /// the DB cluster (see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-IAM-add-role-cluster.html">Adding
        /// the IAM Role to an Amazon Neptune Cluster</a>.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// Amazon.Neptunedata.Model.StartLoaderJobRequest.Mode
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Mode")]
        public Amazon.Neptunedata.Mode Mode { get; set; }
        #endregion
        
        #region Parameter Parallelism
        /// <summary>
        /// <para>
        /// <para>The optional <code>parallelism</code> parameter can be set to reduce the number of
        /// threads used by the bulk load process.</para><para><i>Allowed values</i>:</para><ul><li><para><code>LOW</code> –   The number of threads used is the number of available vCPUs
        /// divided by 8.</para></li><li><para><code>MEDIUM</code> –   The number of threads used is the number of available vCPUs
        /// divided by 2.</para></li><li><para><code>HIGH</code> –   The number of threads used is the same as the number of available
        /// vCPUs.</para></li><li><para><code>OVERSUBSCRIBE</code> –   The number of threads used is the number of available
        /// vCPUs multiplied by 2. If this value is used, the bulk loader takes up all available
        /// resources.</para><para>This does not mean, however, that the <code>OVERSUBSCRIBE</code> setting results in
        /// 100% CPU utilization. Because the load operation is I/O bound, the highest CPU utilization
        /// to expect is in the 60% to 70% range.</para></li></ul><para><i>Default value</i>: <code>HIGH</code></para><para>The <code>parallelism</code> setting can sometimes result in a deadlock between threads
        /// when loading openCypher data. When this happens, Neptune returns the <code>LOAD_DATA_DEADLOCK</code>
        /// error. You can generally fix the issue by setting <code>parallelism</code> to a lower
        /// setting and retrying the load command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Parallelism")]
        public Amazon.Neptunedata.Parallelism Parallelism { get; set; }
        #endregion
        
        #region Parameter ParserConfiguration
        /// <summary>
        /// <para>
        /// Amazon.Neptunedata.Model.StartLoaderJobRequest.ParserConfiguration
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ParserConfiguration { get; set; }
        #endregion
        
        #region Parameter QueueRequest
        /// <summary>
        /// <para>
        /// <para>This is an optional flag parameter that indicates whether the load request can be
        /// queued up or not. </para><para>You don't have to wait for one load job to complete before issuing the next one, because
        /// Neptune can queue up as many as 64 jobs at a time, provided that their <code>queueRequest</code>
        /// parameters are all set to <code>"TRUE"</code>.</para><para>If the <code>queueRequest</code> parameter is omitted or set to <code>"FALSE"</code>,
        /// the load request will fail if another load job is already running.</para><para><i>Allowed values</i>: <code>"TRUE"</code>, <code>"FALSE"</code>.</para><para><i>Default value</i>: <code>"FALSE"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? QueueRequest { get; set; }
        #endregion
        
        #region Parameter S3BucketRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon region of the S3 bucket. This must match the Amazon Region of the DB cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Neptunedata.S3BucketRegion")]
        public Amazon.Neptunedata.S3BucketRegion S3BucketRegion { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The <code>source</code> parameter accepts an S3 URI that identifies a single file,
        /// multiple files, a folder, or multiple folders. Neptune loads every data file in any
        /// folder that is specified.</para><para>The URI can be in any of the following formats.</para><ul><li><para><code>s3://(bucket_name)/(object-key-name)</code></para></li><li><para><code>https://s3.amazonaws.com/(bucket_name)/(object-key-name)</code></para></li><li><para><code>https://s3.us-east-1.amazonaws.com/(bucket_name)/(object-key-name)</code></para></li></ul><para>The <code>object-key-name</code> element of the URI is equivalent to the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjects.html#API_ListObjects_RequestParameters">prefix</a>
        /// parameter in an S3 <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjects.html">ListObjects</a>
        /// API call. It identifies all the objects in the specified S3 bucket whose names begin
        /// with that prefix. That can be a single file or folder, or multiple files and/or folders.</para><para>The specified folder or folders can contain multiple vertex files and multiple edge
        /// files.</para>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter UpdateSingleCardinalityProperty
        /// <summary>
        /// <para>
        /// <para><code>updateSingleCardinalityProperties</code> is an optional parameter that controls
        /// how the bulk loader treats a new value for single-cardinality vertex or edge properties.
        /// This is not supported for loading openCypher data.</para><para><i>Allowed values</i>: <code>"TRUE"</code>, <code>"FALSE"</code>.</para><para><i>Default value</i>: <code>"FALSE"</code>.</para><para>By default, or when <code>updateSingleCardinalityProperties</code> is explicitly set
        /// to <code>"FALSE"</code>, the loader treats a new value as an error, because it violates
        /// single cardinality.</para><para>When <code>updateSingleCardinalityProperties</code> is set to <code>"TRUE"</code>,
        /// on the other hand, the bulk loader replaces the existing value with the new one. If
        /// multiple edge or single-cardinality vertex property values are provided in the source
        /// file(s) being loaded, the final value at the end of the bulk load could be any one
        /// of those new values. The loader only guarantees that the existing value has been replaced
        /// by one of the new ones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateSingleCardinalityProperties")]
        public System.Boolean? UpdateSingleCardinalityProperty { get; set; }
        #endregion
        
        #region Parameter UserProvidedEdgeId
        /// <summary>
        /// <para>
        /// <para>This parameter is required only when loading openCypher data that contains relationship
        /// IDs. It must be included and set to <code>True</code> when openCypher relationship
        /// IDs are explicitly provided in the load data (recommended).</para><para>When <code>userProvidedEdgeIds</code> is absent or set to <code>True</code>, an <code>:ID</code>
        /// column must be present in every relationship file in the load.</para><para>When <code>userProvidedEdgeIds</code> is present and set to <code>False</code>, relationship
        /// files in the load <b>must not</b> contain an <code>:ID</code> column. Instead, the
        /// Neptune loader automatically generates an ID for each relationship.</para><para>It's useful to provide relationship IDs explicitly so that the loader can resume loading
        /// after error in the CSV data have been fixed, without having to reload any relationships
        /// that have already been loaded. If relationship IDs have not been explicitly assigned,
        /// the loader cannot resume a failed load if any relationship file has had to be corrected,
        /// and must instead reload all the relationships.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserProvidedEdgeIds")]
        public System.Boolean? UserProvidedEdgeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.StartLoaderJobResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.StartLoaderJobResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NEPTLoaderJob (StartLoaderJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.StartLoaderJobResponse, StartNEPTLoaderJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Dependency != null)
            {
                context.Dependency = new List<System.String>(this.Dependency);
            }
            context.FailOnError = this.FailOnError;
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mode = this.Mode;
            context.Parallelism = this.Parallelism;
            if (this.ParserConfiguration != null)
            {
                context.ParserConfiguration = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ParserConfiguration.Keys)
                {
                    context.ParserConfiguration.Add((String)hashKey, (String)(this.ParserConfiguration[hashKey]));
                }
            }
            context.QueueRequest = this.QueueRequest;
            context.S3BucketRegion = this.S3BucketRegion;
            #if MODULAR
            if (this.S3BucketRegion == null && ParameterWasBound(nameof(this.S3BucketRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateSingleCardinalityProperty = this.UpdateSingleCardinalityProperty;
            context.UserProvidedEdgeId = this.UserProvidedEdgeId;
            
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
            var request = new Amazon.Neptunedata.Model.StartLoaderJobRequest();
            
            if (cmdletContext.Dependency != null)
            {
                request.Dependencies = cmdletContext.Dependency;
            }
            if (cmdletContext.FailOnError != null)
            {
                request.FailOnError = cmdletContext.FailOnError.Value;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.Parallelism != null)
            {
                request.Parallelism = cmdletContext.Parallelism;
            }
            if (cmdletContext.ParserConfiguration != null)
            {
                request.ParserConfiguration = cmdletContext.ParserConfiguration;
            }
            if (cmdletContext.QueueRequest != null)
            {
                request.QueueRequest = cmdletContext.QueueRequest.Value;
            }
            if (cmdletContext.S3BucketRegion != null)
            {
                request.S3BucketRegion = cmdletContext.S3BucketRegion;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.UpdateSingleCardinalityProperty != null)
            {
                request.UpdateSingleCardinalityProperties = cmdletContext.UpdateSingleCardinalityProperty.Value;
            }
            if (cmdletContext.UserProvidedEdgeId != null)
            {
                request.UserProvidedEdgeIds = cmdletContext.UserProvidedEdgeId.Value;
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
        
        private Amazon.Neptunedata.Model.StartLoaderJobResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.StartLoaderJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "StartLoaderJob");
            try
            {
                #if DESKTOP
                return client.StartLoaderJob(request);
                #elif CORECLR
                return client.StartLoaderJobAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Dependency { get; set; }
            public System.Boolean? FailOnError { get; set; }
            public Amazon.Neptunedata.Format Format { get; set; }
            public System.String IamRoleArn { get; set; }
            public Amazon.Neptunedata.Mode Mode { get; set; }
            public Amazon.Neptunedata.Parallelism Parallelism { get; set; }
            public Dictionary<System.String, System.String> ParserConfiguration { get; set; }
            public System.Boolean? QueueRequest { get; set; }
            public Amazon.Neptunedata.S3BucketRegion S3BucketRegion { get; set; }
            public System.String Source { get; set; }
            public System.Boolean? UpdateSingleCardinalityProperty { get; set; }
            public System.Boolean? UserProvidedEdgeId { get; set; }
            public System.Func<Amazon.Neptunedata.Model.StartLoaderJobResponse, StartNEPTLoaderJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
