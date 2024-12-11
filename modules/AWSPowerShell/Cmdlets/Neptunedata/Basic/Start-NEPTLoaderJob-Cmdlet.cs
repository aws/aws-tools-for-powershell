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
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#startloaderjob">neptune-db:StartLoaderJob</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NEPTLoaderJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptunedata.Model.StartLoaderJobResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData StartLoaderJob API operation.", Operation = new[] {"StartLoaderJob"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.StartLoaderJobResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.StartLoaderJobResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.StartLoaderJobResponse object containing multiple properties."
    )]
    public partial class StartNEPTLoaderJobCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Dependency
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter that can make a queued load request contingent on the
        /// successful completion of one or more previous jobs in the queue.</para><para>Neptune can queue up as many as 64 load requests at a time, if their <c>queueRequest</c>
        /// parameters are set to <c>"TRUE"</c>. The <c>dependencies</c> parameter lets you make
        /// execution of such a queued request dependent on the successful completion of one or
        /// more specified previous requests in the queue.</para><para>For example, if load <c>Job-A</c> and <c>Job-B</c> are independent of each other,
        /// but load <c>Job-C</c> needs <c>Job-A</c> and <c>Job-B</c> to be finished before it
        /// begins, proceed as follows:</para><ol><li><para>Submit <c>load-job-A</c> and <c>load-job-B</c> one after another in any order, and
        /// save their load-ids.</para></li><li><para>Submit <c>load-job-C</c> with the load-ids of the two jobs in its <c>dependencies</c>
        /// field:</para></li></ol><para>Because of the <c>dependencies</c> parameter, the bulk loader will not start <c>Job-C</c>
        /// until <c>Job-A</c> and <c>Job-B</c> have completed successfully. If either one of
        /// them fails, Job-C will not be executed, and its status will be set to <c>LOAD_FAILED_BECAUSE_DEPENDENCY_NOT_SATISFIED</c>.</para><para>You can set up multiple levels of dependency in this way, so that the failure of one
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
        /// <para><b><c>failOnError</c></b>   –   A flag to toggle a complete stop on an error.</para><para><i>Allowed values</i>: <c>"TRUE"</c>, <c>"FALSE"</c>.</para><para><i>Default value</i>: <c>"TRUE"</c>.</para><para>When this parameter is set to <c>"FALSE"</c>, the loader tries to load all the data
        /// in the location specified, skipping any entries with errors.</para><para>When this parameter is set to <c>"TRUE"</c>, the loader stops as soon as it encounters
        /// an error. Data loaded up to that point persists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FailOnError { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the data. For more information about data formats for the Neptune <c>Loader</c>
        /// command, see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format.html">Load
        /// Data Formats</a>.</para><para><b>Allowed values</b></para><ul><li><para><b><c>csv</c></b> for the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-gremlin.html">Gremlin
        /// CSV data format</a>.</para></li><li><para><b><c>opencypher</c></b> for the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/bulk-load-tutorial-format-opencypher.html">openCypher
        /// CSV data format</a>.</para></li><li><para><b><c>ntriples</c></b> for the <a href="https://www.w3.org/TR/n-triples/">N-Triples
        /// RDF data format</a>.</para></li><li><para><b><c>nquads</c></b> for the <a href="https://www.w3.org/TR/n-quads/">N-Quads RDF
        /// data format</a>.</para></li><li><para><b><c>rdfxml</c></b> for the <a href="https://www.w3.org/TR/rdf-syntax-grammar/">RDF\XML
        /// RDF data format</a>.</para></li><li><para><b><c>turtle</c></b> for the <a href="https://www.w3.org/TR/turtle/">Turtle RDF
        /// data format</a>.</para></li></ul>
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
        /// <para>The load job mode.</para><para><i>Allowed values</i>: <c>RESUME</c>, <c>NEW</c>, <c>AUTO</c>.</para><para><i>Default value</i>: <c>AUTO</c>.</para><para><b /></para><ul><li><para><c>RESUME</c>   –   In RESUME mode, the loader looks for a previous load from this
        /// source, and if it finds one, resumes that load job. If no previous load job is found,
        /// the loader stops.</para><para>The loader avoids reloading files that were successfully loaded in a previous job.
        /// It only tries to process failed files. If you dropped previously loaded data from
        /// your Neptune cluster, that data is not reloaded in this mode. If a previous load job
        /// loaded all files from the same source successfully, nothing is reloaded, and the loader
        /// returns success.</para></li><li><para><c>NEW</c>   –   In NEW mode, the creates a new load request regardless of any previous
        /// loads. You can use this mode to reload all the data from a source after dropping previously
        /// loaded data from your Neptune cluster, or to load new data available at the same source.</para></li><li><para><c>AUTO</c>   –   In AUTO mode, the loader looks for a previous load job from the
        /// same source, and if it finds one, resumes that job, just as in <c>RESUME</c> mode.</para><para>If the loader doesn't find a previous load job from the same source, it loads all
        /// data from the source, just as in <c>NEW</c> mode.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Mode")]
        public Amazon.Neptunedata.Mode Mode { get; set; }
        #endregion
        
        #region Parameter Parallelism
        /// <summary>
        /// <para>
        /// <para>The optional <c>parallelism</c> parameter can be set to reduce the number of threads
        /// used by the bulk load process.</para><para><i>Allowed values</i>:</para><ul><li><para><c>LOW</c> –   The number of threads used is the number of available vCPUs divided
        /// by 8.</para></li><li><para><c>MEDIUM</c> –   The number of threads used is the number of available vCPUs divided
        /// by 2.</para></li><li><para><c>HIGH</c> –   The number of threads used is the same as the number of available
        /// vCPUs.</para></li><li><para><c>OVERSUBSCRIBE</c> –   The number of threads used is the number of available vCPUs
        /// multiplied by 2. If this value is used, the bulk loader takes up all available resources.</para><para>This does not mean, however, that the <c>OVERSUBSCRIBE</c> setting results in 100%
        /// CPU utilization. Because the load operation is I/O bound, the highest CPU utilization
        /// to expect is in the 60% to 70% range.</para></li></ul><para><i>Default value</i>: <c>HIGH</c></para><para>The <c>parallelism</c> setting can sometimes result in a deadlock between threads
        /// when loading openCypher data. When this happens, Neptune returns the <c>LOAD_DATA_DEADLOCK</c>
        /// error. You can generally fix the issue by setting <c>parallelism</c> to a lower setting
        /// and retrying the load command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Neptunedata.Parallelism")]
        public Amazon.Neptunedata.Parallelism Parallelism { get; set; }
        #endregion
        
        #region Parameter ParserConfiguration
        /// <summary>
        /// <para>
        /// <para><b><c>parserConfiguration</c></b>   –   An optional object with additional parser
        /// configuration values. Each of the child parameters is also optional:</para><para><b /></para><ul><li><para><b><c>namedGraphUri</c></b>   –   The default graph for all RDF formats when no
        /// graph is specified (for non-quads formats and NQUAD entries with no graph).</para><para>The default is <c>https://aws.amazon.com/neptune/vocab/v01/DefaultNamedGraph</c>.</para></li><li><para><b><c>baseUri</c></b>   –   The base URI for RDF/XML and Turtle formats.</para><para>The default is <c>https://aws.amazon.com/neptune/default</c>.</para></li><li><para><b><c>allowEmptyStrings</c></b>   –   Gremlin users need to be able to pass empty
        /// string values("") as node and edge properties when loading CSV data. If <c>allowEmptyStrings</c>
        /// is set to <c>false</c> (the default), such empty strings are treated as nulls and
        /// are not loaded.</para><para>If <c>allowEmptyStrings</c> is set to <c>true</c>, the loader treats empty strings
        /// as valid property values and loads them accordingly.</para></li></ul>
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
        /// Neptune can queue up as many as 64 jobs at a time, provided that their <c>queueRequest</c>
        /// parameters are all set to <c>"TRUE"</c>. The queue order of the jobs will be first-in-first-out
        /// (FIFO).</para><para>If the <c>queueRequest</c> parameter is omitted or set to <c>"FALSE"</c>, the load
        /// request will fail if another load job is already running.</para><para><i>Allowed values</i>: <c>"TRUE"</c>, <c>"FALSE"</c>.</para><para><i>Default value</i>: <c>"FALSE"</c>.</para>
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
        /// <para>The <c>source</c> parameter accepts an S3 URI that identifies a single file, multiple
        /// files, a folder, or multiple folders. Neptune loads every data file in any folder
        /// that is specified.</para><para>The URI can be in any of the following formats.</para><ul><li><para><c>s3://(bucket_name)/(object-key-name)</c></para></li><li><para><c>https://s3.amazonaws.com/(bucket_name)/(object-key-name)</c></para></li><li><para><c>https://s3.us-east-1.amazonaws.com/(bucket_name)/(object-key-name)</c></para></li></ul><para>The <c>object-key-name</c> element of the URI is equivalent to the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjects.html#API_ListObjects_RequestParameters">prefix</a>
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
        /// <para><c>updateSingleCardinalityProperties</c> is an optional parameter that controls how
        /// the bulk loader treats a new value for single-cardinality vertex or edge properties.
        /// This is not supported for loading openCypher data.</para><para><i>Allowed values</i>: <c>"TRUE"</c>, <c>"FALSE"</c>.</para><para><i>Default value</i>: <c>"FALSE"</c>.</para><para>By default, or when <c>updateSingleCardinalityProperties</c> is explicitly set to
        /// <c>"FALSE"</c>, the loader treats a new value as an error, because it violates single
        /// cardinality.</para><para>When <c>updateSingleCardinalityProperties</c> is set to <c>"TRUE"</c>, on the other
        /// hand, the bulk loader replaces the existing value with the new one. If multiple edge
        /// or single-cardinality vertex property values are provided in the source file(s) being
        /// loaded, the final value at the end of the bulk load could be any one of those new
        /// values. The loader only guarantees that the existing value has been replaced by one
        /// of the new ones.</para>
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
        /// IDs. It must be included and set to <c>True</c> when openCypher relationship IDs are
        /// explicitly provided in the load data (recommended).</para><para>When <c>userProvidedEdgeIds</c> is absent or set to <c>True</c>, an <c>:ID</c> column
        /// must be present in every relationship file in the load.</para><para>When <c>userProvidedEdgeIds</c> is present and set to <c>False</c>, relationship files
        /// in the load <b>must not</b> contain an <c>:ID</c> column. Instead, the Neptune loader
        /// automatically generates an ID for each relationship.</para><para>It's useful to provide relationship IDs explicitly so that the loader can resume loading
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
                    context.ParserConfiguration.Add((String)hashKey, (System.String)(this.ParserConfiguration[hashKey]));
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
