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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Starts a notebook execution.
    /// </summary>
    [Cmdlet("Start", "EMRNotebookExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce StartNotebookExecution API operation.", Operation = new[] {"StartNotebookExecution"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartEMRNotebookExecutionCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NotebookS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that stores the notebook execution input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter OutputNotebookS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that stores the notebook execution output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputNotebookS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter EditorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon EMR Notebook to use for notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EditorId { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The environment variables associated with the notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ExecutionEngine_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN required for the notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionEngine_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ExecutionEngine_Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the execution engine. For an Amazon EMR cluster, this is
        /// the cluster ID.</para>
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
        public System.String ExecutionEngine_Id { get; set; }
        #endregion
        
        #region Parameter NotebookS3Location_Key
        /// <summary>
        /// <para>
        /// <para>The key to the Amazon S3 location that stores the notebook execution input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookS3Location_Key { get; set; }
        #endregion
        
        #region Parameter OutputNotebookS3Location_Key
        /// <summary>
        /// <para>
        /// <para>The key to the Amazon S3 location that stores the notebook execution output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputNotebookS3Location_Key { get; set; }
        #endregion
        
        #region Parameter ExecutionEngine_MasterInstanceSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An optional unique ID of an Amazon EC2 security group to associate with the master
        /// instance of the Amazon EMR cluster for this notebook execution. For more information
        /// see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-managed-notebooks-security-groups.html">Specifying
        /// Amazon EC2 Security Groups for Amazon EMR Notebooks</a> in the <i>EMR Management Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionEngine_MasterInstanceSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NotebookExecutionName
        /// <summary>
        /// <para>
        /// <para>An optional name for the notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookExecutionName { get; set; }
        #endregion
        
        #region Parameter NotebookInstanceSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon EC2 security group to associate with the Amazon
        /// EMR Notebook for this notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookInstanceSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NotebookParam
        /// <summary>
        /// <para>
        /// <para>Input parameters in JSON format passed to the Amazon EMR Notebook at runtime for execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotebookParams")]
        public System.String NotebookParam { get; set; }
        #endregion
        
        #region Parameter OutputNotebookFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OutputNotebookFormat")]
        public Amazon.ElasticMapReduce.OutputNotebookFormat OutputNotebookFormat { get; set; }
        #endregion
        
        #region Parameter RelativePath
        /// <summary>
        /// <para>
        /// <para>The path and file name of the notebook file for this execution, relative to the path
        /// specified for the Amazon EMR Notebook. For example, if you specify a path of <c>s3://MyBucket/MyNotebooks</c>
        /// when you create an Amazon EMR Notebook for a notebook with an ID of <c>e-ABCDEFGHIJK1234567890ABCD</c>
        /// (the <c>EditorID</c> of this request), and you specify a <c>RelativePath</c> of <c>my_notebook_executions/notebook_execution.ipynb</c>,
        /// the location of the file for the notebook execution is <c>s3://MyBucket/MyNotebooks/e-ABCDEFGHIJK1234567890ABCD/my_notebook_executions/notebook_execution.ipynb</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelativePath { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the IAM role that is used as the service role for Amazon EMR (the
        /// Amazon EMR role) for the notebook execution.</para>
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
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags associated with a notebook execution. Tags are user-defined key-value
        /// pairs that consist of a required key string with a maximum of 128 characters and an
        /// optional value string with a maximum of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ExecutionEngine_Type
        /// <summary>
        /// <para>
        /// <para>The type of execution engine. A value of <c>EMR</c> specifies an Amazon EMR cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.ExecutionEngineType")]
        public Amazon.ElasticMapReduce.ExecutionEngineType ExecutionEngine_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotebookExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotebookExecutionId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EditorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRNotebookExecution (StartNotebookExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse, StartEMRNotebookExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EditorId = this.EditorId;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.ExecutionEngine_ExecutionRoleArn = this.ExecutionEngine_ExecutionRoleArn;
            context.ExecutionEngine_Id = this.ExecutionEngine_Id;
            #if MODULAR
            if (this.ExecutionEngine_Id == null && ParameterWasBound(nameof(this.ExecutionEngine_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionEngine_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionEngine_MasterInstanceSecurityGroupId = this.ExecutionEngine_MasterInstanceSecurityGroupId;
            context.ExecutionEngine_Type = this.ExecutionEngine_Type;
            context.NotebookExecutionName = this.NotebookExecutionName;
            context.NotebookInstanceSecurityGroupId = this.NotebookInstanceSecurityGroupId;
            context.NotebookParam = this.NotebookParam;
            context.NotebookS3Location_Bucket = this.NotebookS3Location_Bucket;
            context.NotebookS3Location_Key = this.NotebookS3Location_Key;
            context.OutputNotebookFormat = this.OutputNotebookFormat;
            context.OutputNotebookS3Location_Bucket = this.OutputNotebookS3Location_Bucket;
            context.OutputNotebookS3Location_Key = this.OutputNotebookS3Location_Key;
            context.RelativePath = this.RelativePath;
            context.ServiceRole = this.ServiceRole;
            #if MODULAR
            if (this.ServiceRole == null && ParameterWasBound(nameof(this.ServiceRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticMapReduce.Model.Tag>(this.Tag);
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
            var request = new Amazon.ElasticMapReduce.Model.StartNotebookExecutionRequest();
            
            if (cmdletContext.EditorId != null)
            {
                request.EditorId = cmdletContext.EditorId;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            
             // populate ExecutionEngine
            var requestExecutionEngineIsNull = true;
            request.ExecutionEngine = new Amazon.ElasticMapReduce.Model.ExecutionEngineConfig();
            System.String requestExecutionEngine_executionEngine_ExecutionRoleArn = null;
            if (cmdletContext.ExecutionEngine_ExecutionRoleArn != null)
            {
                requestExecutionEngine_executionEngine_ExecutionRoleArn = cmdletContext.ExecutionEngine_ExecutionRoleArn;
            }
            if (requestExecutionEngine_executionEngine_ExecutionRoleArn != null)
            {
                request.ExecutionEngine.ExecutionRoleArn = requestExecutionEngine_executionEngine_ExecutionRoleArn;
                requestExecutionEngineIsNull = false;
            }
            System.String requestExecutionEngine_executionEngine_Id = null;
            if (cmdletContext.ExecutionEngine_Id != null)
            {
                requestExecutionEngine_executionEngine_Id = cmdletContext.ExecutionEngine_Id;
            }
            if (requestExecutionEngine_executionEngine_Id != null)
            {
                request.ExecutionEngine.Id = requestExecutionEngine_executionEngine_Id;
                requestExecutionEngineIsNull = false;
            }
            System.String requestExecutionEngine_executionEngine_MasterInstanceSecurityGroupId = null;
            if (cmdletContext.ExecutionEngine_MasterInstanceSecurityGroupId != null)
            {
                requestExecutionEngine_executionEngine_MasterInstanceSecurityGroupId = cmdletContext.ExecutionEngine_MasterInstanceSecurityGroupId;
            }
            if (requestExecutionEngine_executionEngine_MasterInstanceSecurityGroupId != null)
            {
                request.ExecutionEngine.MasterInstanceSecurityGroupId = requestExecutionEngine_executionEngine_MasterInstanceSecurityGroupId;
                requestExecutionEngineIsNull = false;
            }
            Amazon.ElasticMapReduce.ExecutionEngineType requestExecutionEngine_executionEngine_Type = null;
            if (cmdletContext.ExecutionEngine_Type != null)
            {
                requestExecutionEngine_executionEngine_Type = cmdletContext.ExecutionEngine_Type;
            }
            if (requestExecutionEngine_executionEngine_Type != null)
            {
                request.ExecutionEngine.Type = requestExecutionEngine_executionEngine_Type;
                requestExecutionEngineIsNull = false;
            }
             // determine if request.ExecutionEngine should be set to null
            if (requestExecutionEngineIsNull)
            {
                request.ExecutionEngine = null;
            }
            if (cmdletContext.NotebookExecutionName != null)
            {
                request.NotebookExecutionName = cmdletContext.NotebookExecutionName;
            }
            if (cmdletContext.NotebookInstanceSecurityGroupId != null)
            {
                request.NotebookInstanceSecurityGroupId = cmdletContext.NotebookInstanceSecurityGroupId;
            }
            if (cmdletContext.NotebookParam != null)
            {
                request.NotebookParams = cmdletContext.NotebookParam;
            }
            
             // populate NotebookS3Location
            var requestNotebookS3LocationIsNull = true;
            request.NotebookS3Location = new Amazon.ElasticMapReduce.Model.NotebookS3LocationFromInput();
            System.String requestNotebookS3Location_notebookS3Location_Bucket = null;
            if (cmdletContext.NotebookS3Location_Bucket != null)
            {
                requestNotebookS3Location_notebookS3Location_Bucket = cmdletContext.NotebookS3Location_Bucket;
            }
            if (requestNotebookS3Location_notebookS3Location_Bucket != null)
            {
                request.NotebookS3Location.Bucket = requestNotebookS3Location_notebookS3Location_Bucket;
                requestNotebookS3LocationIsNull = false;
            }
            System.String requestNotebookS3Location_notebookS3Location_Key = null;
            if (cmdletContext.NotebookS3Location_Key != null)
            {
                requestNotebookS3Location_notebookS3Location_Key = cmdletContext.NotebookS3Location_Key;
            }
            if (requestNotebookS3Location_notebookS3Location_Key != null)
            {
                request.NotebookS3Location.Key = requestNotebookS3Location_notebookS3Location_Key;
                requestNotebookS3LocationIsNull = false;
            }
             // determine if request.NotebookS3Location should be set to null
            if (requestNotebookS3LocationIsNull)
            {
                request.NotebookS3Location = null;
            }
            if (cmdletContext.OutputNotebookFormat != null)
            {
                request.OutputNotebookFormat = cmdletContext.OutputNotebookFormat;
            }
            
             // populate OutputNotebookS3Location
            var requestOutputNotebookS3LocationIsNull = true;
            request.OutputNotebookS3Location = new Amazon.ElasticMapReduce.Model.OutputNotebookS3LocationFromInput();
            System.String requestOutputNotebookS3Location_outputNotebookS3Location_Bucket = null;
            if (cmdletContext.OutputNotebookS3Location_Bucket != null)
            {
                requestOutputNotebookS3Location_outputNotebookS3Location_Bucket = cmdletContext.OutputNotebookS3Location_Bucket;
            }
            if (requestOutputNotebookS3Location_outputNotebookS3Location_Bucket != null)
            {
                request.OutputNotebookS3Location.Bucket = requestOutputNotebookS3Location_outputNotebookS3Location_Bucket;
                requestOutputNotebookS3LocationIsNull = false;
            }
            System.String requestOutputNotebookS3Location_outputNotebookS3Location_Key = null;
            if (cmdletContext.OutputNotebookS3Location_Key != null)
            {
                requestOutputNotebookS3Location_outputNotebookS3Location_Key = cmdletContext.OutputNotebookS3Location_Key;
            }
            if (requestOutputNotebookS3Location_outputNotebookS3Location_Key != null)
            {
                request.OutputNotebookS3Location.Key = requestOutputNotebookS3Location_outputNotebookS3Location_Key;
                requestOutputNotebookS3LocationIsNull = false;
            }
             // determine if request.OutputNotebookS3Location should be set to null
            if (requestOutputNotebookS3LocationIsNull)
            {
                request.OutputNotebookS3Location = null;
            }
            if (cmdletContext.RelativePath != null)
            {
                request.RelativePath = cmdletContext.RelativePath;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
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
        
        private Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.StartNotebookExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "StartNotebookExecution");
            try
            {
                #if DESKTOP
                return client.StartNotebookExecution(request);
                #elif CORECLR
                return client.StartNotebookExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String EditorId { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.String ExecutionEngine_ExecutionRoleArn { get; set; }
            public System.String ExecutionEngine_Id { get; set; }
            public System.String ExecutionEngine_MasterInstanceSecurityGroupId { get; set; }
            public Amazon.ElasticMapReduce.ExecutionEngineType ExecutionEngine_Type { get; set; }
            public System.String NotebookExecutionName { get; set; }
            public System.String NotebookInstanceSecurityGroupId { get; set; }
            public System.String NotebookParam { get; set; }
            public System.String NotebookS3Location_Bucket { get; set; }
            public System.String NotebookS3Location_Key { get; set; }
            public Amazon.ElasticMapReduce.OutputNotebookFormat OutputNotebookFormat { get; set; }
            public System.String OutputNotebookS3Location_Bucket { get; set; }
            public System.String OutputNotebookS3Location_Key { get; set; }
            public System.String RelativePath { get; set; }
            public System.String ServiceRole { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.StartNotebookExecutionResponse, StartEMRNotebookExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotebookExecutionId;
        }
        
    }
}
