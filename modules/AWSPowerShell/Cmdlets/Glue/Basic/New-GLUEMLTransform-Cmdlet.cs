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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates an Glue machine learning transform. This operation creates the transform and
    /// all the necessary parameters to train it.
    /// 
    ///  
    /// <para>
    /// Call this operation as the first step in the process of using a machine learning transform
    /// (such as the <code>FindMatches</code> transform) for deduplicating data. You can provide
    /// an optional <code>Description</code>, in addition to the parameters that you want
    /// to use for your algorithm.
    /// </para><para>
    /// You must also specify certain parameters for the tasks that Glue runs on your behalf
    /// as part of learning from your data and creating a high-quality machine learning transform.
    /// These parameters include <code>Role</code>, and optionally, <code>AllocatedCapacity</code>,
    /// <code>Timeout</code>, and <code>MaxRetries</code>. For more information, see <a href="https://docs.aws.amazon.com/glue/latest/dg/aws-glue-api-jobs-job.html">Jobs</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GLUEMLTransform", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue CreateMLTransform API operation.", Operation = new[] {"CreateMLTransform"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateMLTransformResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.CreateMLTransformResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.CreateMLTransformResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEMLTransformCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FindMatchesParameters_AccuracyCostTradeoff
        /// <summary>
        /// <para>
        /// <para>The value that is selected when tuning your transform for a balance between accuracy
        /// and cost. A value of 0.5 means that the system balances accuracy and cost concerns.
        /// A value of 1.0 means a bias purely for accuracy, which typically results in a higher
        /// cost, sometimes substantially higher. A value of 0.0 means a bias purely for cost,
        /// which results in a less accurate <code>FindMatches</code> transform, sometimes with
        /// unacceptable accuracy.</para><para>Accuracy measures how well the transform finds true positives and true negatives.
        /// Increasing accuracy requires more machine resources and cost. But it also results
        /// in increased recall. </para><para>Cost measures how many compute resources, and thus money, are consumed to run the
        /// transform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_FindMatchesParameters_AccuracyCostTradeoff")]
        public System.Double? FindMatchesParameters_AccuracyCostTradeoff { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the machine learning transform that is being defined. The default
        /// is an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FindMatchesParameters_EnforceProvidedLabel
        /// <summary>
        /// <para>
        /// <para>The value to switch on or off to force the output to match the provided labels from
        /// users. If the value is <code>True</code>, the <code>find matches</code> transform
        /// forces the output to match the provided labels. The results override the normal conflation
        /// results. If the value is <code>False</code>, the <code>find matches</code> transform
        /// does not ensure all the labels provided are respected, and the results rely on the
        /// trained model.</para><para>Note that setting this value to true may increase the conflation execution time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_FindMatchesParameters_EnforceProvidedLabels")]
        public System.Boolean? FindMatchesParameters_EnforceProvidedLabel { get; set; }
        #endregion
        
        #region Parameter GlueVersion
        /// <summary>
        /// <para>
        /// <para>This value determines which version of Glue this machine learning transform is compatible
        /// with. Glue 1.0 is recommended for most customers. If the value is not set, the Glue
        /// compatibility defaults to Glue 0.9. For more information, see <a href="https://docs.aws.amazon.com/glue/latest/dg/release-notes.html#release-notes-versions">Glue
        /// Versions</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlueVersion { get; set; }
        #endregion
        
        #region Parameter InputRecordTable
        /// <summary>
        /// <para>
        /// <para>A list of Glue table definitions used by the transform.</para>
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
        [Alias("InputRecordTables")]
        public Amazon.Glue.Model.GlueTable[] InputRecordTable { get; set; }
        #endregion
        
        #region Parameter MlUserDataEncryption_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID for the customer-provided KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransformEncryption_MlUserDataEncryption_KmsKeyId")]
        public System.String MlUserDataEncryption_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Glue data processing units (DPUs) that are allocated to task runs for
        /// this transform. You can allocate from 2 to 100 DPUs; the default is 10. A DPU is a
        /// relative measure of processing power that consists of 4 vCPUs of compute capacity
        /// and 16 GB of memory. For more information, see the <a href="https://aws.amazon.com/glue/pricing/">Glue
        /// pricing page</a>. </para><para><code>MaxCapacity</code> is a mutually exclusive option with <code>NumberOfWorkers</code>
        /// and <code>WorkerType</code>.</para><ul><li><para>If either <code>NumberOfWorkers</code> or <code>WorkerType</code> is set, then <code>MaxCapacity</code>
        /// cannot be set.</para></li><li><para>If <code>MaxCapacity</code> is set then neither <code>NumberOfWorkers</code> or <code>WorkerType</code>
        /// can be set.</para></li><li><para>If <code>WorkerType</code> is set, then <code>NumberOfWorkers</code> is required (and
        /// vice versa).</para></li><li><para><code>MaxCapacity</code> and <code>NumberOfWorkers</code> must both be at least 1.</para></li></ul><para>When the <code>WorkerType</code> field is set to a value other than <code>Standard</code>,
        /// the <code>MaxCapacity</code> field is set automatically and becomes read-only.</para><para>When the <code>WorkerType</code> field is set to a value other than <code>Standard</code>,
        /// the <code>MaxCapacity</code> field is set automatically and becomes read-only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry a task for this transform after a task run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetries")]
        public System.Int32? MaxRetry { get; set; }
        #endregion
        
        #region Parameter MlUserDataEncryption_MlUserDataEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode applied to user data. Valid values are:</para><ul><li><para>DISABLED: encryption is disabled</para></li><li><para>SSEKMS: use of server-side encryption with Key Management Service (SSE-KMS) for user
        /// data stored in Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransformEncryption_MlUserDataEncryption_MlUserDataEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.MLUserDataEncryptionModeString")]
        public Amazon.Glue.MLUserDataEncryptionModeString MlUserDataEncryption_MlUserDataEncryptionMode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name that you give the transform when you create it.</para>
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
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of workers of a defined <code>workerType</code> that are allocated when
        /// this task runs.</para><para>If <code>WorkerType</code> is set, then <code>NumberOfWorkers</code> is required (and
        /// vice versa).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter FindMatchesParameters_PrecisionRecallTradeoff
        /// <summary>
        /// <para>
        /// <para>The value selected when tuning your transform for a balance between precision and
        /// recall. A value of 0.5 means no preference; a value of 1.0 means a bias purely for
        /// precision, and a value of 0.0 means a bias for recall. Because this is a tradeoff,
        /// choosing values close to 1.0 means very low recall, and choosing values close to 0.0
        /// results in very low precision.</para><para>The precision metric indicates how often your model is correct when it predicts a
        /// match. </para><para>The recall metric indicates that for an actual match, how often your model predicts
        /// the match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_FindMatchesParameters_PrecisionRecallTradeoff")]
        public System.Double? FindMatchesParameters_PrecisionRecallTradeoff { get; set; }
        #endregion
        
        #region Parameter FindMatchesParameters_PrimaryKeyColumnName
        /// <summary>
        /// <para>
        /// <para>The name of a column that uniquely identifies rows in the source table. Used to help
        /// identify matching records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_FindMatchesParameters_PrimaryKeyColumnName")]
        public System.String FindMatchesParameters_PrimaryKeyColumnName { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the IAM role with the required permissions.
        /// The required permissions include both Glue service role permissions to Glue resources,
        /// and Amazon S3 permissions required by the transform. </para><ul><li><para>This role needs Glue service role permissions to allow access to resources in Glue.
        /// See <a href="https://docs.aws.amazon.com/glue/latest/dg/attach-policy-iam-user.html">Attach
        /// a Policy to IAM Users That Access Glue</a>.</para></li><li><para>This role needs permission to your Amazon Simple Storage Service (Amazon S3) sources,
        /// targets, temporary directory, scripts, and any libraries used by the task run for
        /// this transform.</para></li></ul>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to use with this machine learning transform. You may use tags to limit access
        /// to the machine learning transform. For more information about tags in Glue, see <a href="https://docs.aws.amazon.com/glue/latest/dg/monitor-tags.html">Amazon Web Services
        /// Tags in Glue</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TransformEncryption_TaskRunSecurityConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the security configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformEncryption_TaskRunSecurityConfigurationName { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout of the task run for this transform in minutes. This is the maximum time
        /// that a task run for this transform can consume resources before it is terminated and
        /// enters <code>TIMEOUT</code> status. The default is 2,880 minutes (48 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Parameters_TransformType
        /// <summary>
        /// <para>
        /// <para>The type of machine learning transform.</para><para>For information about the types of machine learning transforms, see <a href="https://docs.aws.amazon.com/glue/latest/dg/add-job-machine-learning-transform.html">Creating
        /// Machine Learning Transforms</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.TransformType")]
        public Amazon.Glue.TransformType Parameters_TransformType { get; set; }
        #endregion
        
        #region Parameter WorkerType
        /// <summary>
        /// <para>
        /// <para>The type of predefined worker that is allocated when this task runs. Accepts a value
        /// of Standard, G.1X, or G.2X.</para><ul><li><para>For the <code>Standard</code> worker type, each worker provides 4 vCPU, 16 GB of memory
        /// and a 50GB disk, and 2 executors per worker.</para></li><li><para>For the <code>G.1X</code> worker type, each worker provides 4 vCPU, 16 GB of memory
        /// and a 64GB disk, and 1 executor per worker.</para></li><li><para>For the <code>G.2X</code> worker type, each worker provides 8 vCPU, 32 GB of memory
        /// and a 128GB disk, and 1 executor per worker.</para></li></ul><para><code>MaxCapacity</code> is a mutually exclusive option with <code>NumberOfWorkers</code>
        /// and <code>WorkerType</code>.</para><ul><li><para>If either <code>NumberOfWorkers</code> or <code>WorkerType</code> is set, then <code>MaxCapacity</code>
        /// cannot be set.</para></li><li><para>If <code>MaxCapacity</code> is set then neither <code>NumberOfWorkers</code> or <code>WorkerType</code>
        /// can be set.</para></li><li><para>If <code>WorkerType</code> is set, then <code>NumberOfWorkers</code> is required (and
        /// vice versa).</para></li><li><para><code>MaxCapacity</code> and <code>NumberOfWorkers</code> must both be at least 1.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.WorkerType")]
        public Amazon.Glue.WorkerType WorkerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransformId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateMLTransformResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateMLTransformResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransformId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEMLTransform (CreateMLTransform)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateMLTransformResponse, NewGLUEMLTransformCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.GlueVersion = this.GlueVersion;
            if (this.InputRecordTable != null)
            {
                context.InputRecordTable = new List<Amazon.Glue.Model.GlueTable>(this.InputRecordTable);
            }
            #if MODULAR
            if (this.InputRecordTable == null && ParameterWasBound(nameof(this.InputRecordTable)))
            {
                WriteWarning("You are passing $null as a value for parameter InputRecordTable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxCapacity = this.MaxCapacity;
            context.MaxRetry = this.MaxRetry;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfWorker = this.NumberOfWorker;
            context.FindMatchesParameters_AccuracyCostTradeoff = this.FindMatchesParameters_AccuracyCostTradeoff;
            context.FindMatchesParameters_EnforceProvidedLabel = this.FindMatchesParameters_EnforceProvidedLabel;
            context.FindMatchesParameters_PrecisionRecallTradeoff = this.FindMatchesParameters_PrecisionRecallTradeoff;
            context.FindMatchesParameters_PrimaryKeyColumnName = this.FindMatchesParameters_PrimaryKeyColumnName;
            context.Parameters_TransformType = this.Parameters_TransformType;
            #if MODULAR
            if (this.Parameters_TransformType == null && ParameterWasBound(nameof(this.Parameters_TransformType)))
            {
                WriteWarning("You are passing $null as a value for parameter Parameters_TransformType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.MlUserDataEncryption_KmsKeyId = this.MlUserDataEncryption_KmsKeyId;
            context.MlUserDataEncryption_MlUserDataEncryptionMode = this.MlUserDataEncryption_MlUserDataEncryptionMode;
            context.TransformEncryption_TaskRunSecurityConfigurationName = this.TransformEncryption_TaskRunSecurityConfigurationName;
            context.WorkerType = this.WorkerType;
            
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
            var request = new Amazon.Glue.Model.CreateMLTransformRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GlueVersion != null)
            {
                request.GlueVersion = cmdletContext.GlueVersion;
            }
            if (cmdletContext.InputRecordTable != null)
            {
                request.InputRecordTables = cmdletContext.InputRecordTable;
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
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.Glue.Model.TransformParameters();
            Amazon.Glue.TransformType requestParameters_parameters_TransformType = null;
            if (cmdletContext.Parameters_TransformType != null)
            {
                requestParameters_parameters_TransformType = cmdletContext.Parameters_TransformType;
            }
            if (requestParameters_parameters_TransformType != null)
            {
                request.Parameters.TransformType = requestParameters_parameters_TransformType;
                requestParametersIsNull = false;
            }
            Amazon.Glue.Model.FindMatchesParameters requestParameters_parameters_FindMatchesParameters = null;
            
             // populate FindMatchesParameters
            var requestParameters_parameters_FindMatchesParametersIsNull = true;
            requestParameters_parameters_FindMatchesParameters = new Amazon.Glue.Model.FindMatchesParameters();
            System.Double? requestParameters_parameters_FindMatchesParameters_findMatchesParameters_AccuracyCostTradeoff = null;
            if (cmdletContext.FindMatchesParameters_AccuracyCostTradeoff != null)
            {
                requestParameters_parameters_FindMatchesParameters_findMatchesParameters_AccuracyCostTradeoff = cmdletContext.FindMatchesParameters_AccuracyCostTradeoff.Value;
            }
            if (requestParameters_parameters_FindMatchesParameters_findMatchesParameters_AccuracyCostTradeoff != null)
            {
                requestParameters_parameters_FindMatchesParameters.AccuracyCostTradeoff = requestParameters_parameters_FindMatchesParameters_findMatchesParameters_AccuracyCostTradeoff.Value;
                requestParameters_parameters_FindMatchesParametersIsNull = false;
            }
            System.Boolean? requestParameters_parameters_FindMatchesParameters_findMatchesParameters_EnforceProvidedLabel = null;
            if (cmdletContext.FindMatchesParameters_EnforceProvidedLabel != null)
            {
                requestParameters_parameters_FindMatchesParameters_findMatchesParameters_EnforceProvidedLabel = cmdletContext.FindMatchesParameters_EnforceProvidedLabel.Value;
            }
            if (requestParameters_parameters_FindMatchesParameters_findMatchesParameters_EnforceProvidedLabel != null)
            {
                requestParameters_parameters_FindMatchesParameters.EnforceProvidedLabels = requestParameters_parameters_FindMatchesParameters_findMatchesParameters_EnforceProvidedLabel.Value;
                requestParameters_parameters_FindMatchesParametersIsNull = false;
            }
            System.Double? requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrecisionRecallTradeoff = null;
            if (cmdletContext.FindMatchesParameters_PrecisionRecallTradeoff != null)
            {
                requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrecisionRecallTradeoff = cmdletContext.FindMatchesParameters_PrecisionRecallTradeoff.Value;
            }
            if (requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrecisionRecallTradeoff != null)
            {
                requestParameters_parameters_FindMatchesParameters.PrecisionRecallTradeoff = requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrecisionRecallTradeoff.Value;
                requestParameters_parameters_FindMatchesParametersIsNull = false;
            }
            System.String requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrimaryKeyColumnName = null;
            if (cmdletContext.FindMatchesParameters_PrimaryKeyColumnName != null)
            {
                requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrimaryKeyColumnName = cmdletContext.FindMatchesParameters_PrimaryKeyColumnName;
            }
            if (requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrimaryKeyColumnName != null)
            {
                requestParameters_parameters_FindMatchesParameters.PrimaryKeyColumnName = requestParameters_parameters_FindMatchesParameters_findMatchesParameters_PrimaryKeyColumnName;
                requestParameters_parameters_FindMatchesParametersIsNull = false;
            }
             // determine if requestParameters_parameters_FindMatchesParameters should be set to null
            if (requestParameters_parameters_FindMatchesParametersIsNull)
            {
                requestParameters_parameters_FindMatchesParameters = null;
            }
            if (requestParameters_parameters_FindMatchesParameters != null)
            {
                request.Parameters.FindMatchesParameters = requestParameters_parameters_FindMatchesParameters;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            
             // populate TransformEncryption
            var requestTransformEncryptionIsNull = true;
            request.TransformEncryption = new Amazon.Glue.Model.TransformEncryption();
            System.String requestTransformEncryption_transformEncryption_TaskRunSecurityConfigurationName = null;
            if (cmdletContext.TransformEncryption_TaskRunSecurityConfigurationName != null)
            {
                requestTransformEncryption_transformEncryption_TaskRunSecurityConfigurationName = cmdletContext.TransformEncryption_TaskRunSecurityConfigurationName;
            }
            if (requestTransformEncryption_transformEncryption_TaskRunSecurityConfigurationName != null)
            {
                request.TransformEncryption.TaskRunSecurityConfigurationName = requestTransformEncryption_transformEncryption_TaskRunSecurityConfigurationName;
                requestTransformEncryptionIsNull = false;
            }
            Amazon.Glue.Model.MLUserDataEncryption requestTransformEncryption_transformEncryption_MlUserDataEncryption = null;
            
             // populate MlUserDataEncryption
            var requestTransformEncryption_transformEncryption_MlUserDataEncryptionIsNull = true;
            requestTransformEncryption_transformEncryption_MlUserDataEncryption = new Amazon.Glue.Model.MLUserDataEncryption();
            System.String requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_KmsKeyId = null;
            if (cmdletContext.MlUserDataEncryption_KmsKeyId != null)
            {
                requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_KmsKeyId = cmdletContext.MlUserDataEncryption_KmsKeyId;
            }
            if (requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_KmsKeyId != null)
            {
                requestTransformEncryption_transformEncryption_MlUserDataEncryption.KmsKeyId = requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_KmsKeyId;
                requestTransformEncryption_transformEncryption_MlUserDataEncryptionIsNull = false;
            }
            Amazon.Glue.MLUserDataEncryptionModeString requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_MlUserDataEncryptionMode = null;
            if (cmdletContext.MlUserDataEncryption_MlUserDataEncryptionMode != null)
            {
                requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_MlUserDataEncryptionMode = cmdletContext.MlUserDataEncryption_MlUserDataEncryptionMode;
            }
            if (requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_MlUserDataEncryptionMode != null)
            {
                requestTransformEncryption_transformEncryption_MlUserDataEncryption.MlUserDataEncryptionMode = requestTransformEncryption_transformEncryption_MlUserDataEncryption_mlUserDataEncryption_MlUserDataEncryptionMode;
                requestTransformEncryption_transformEncryption_MlUserDataEncryptionIsNull = false;
            }
             // determine if requestTransformEncryption_transformEncryption_MlUserDataEncryption should be set to null
            if (requestTransformEncryption_transformEncryption_MlUserDataEncryptionIsNull)
            {
                requestTransformEncryption_transformEncryption_MlUserDataEncryption = null;
            }
            if (requestTransformEncryption_transformEncryption_MlUserDataEncryption != null)
            {
                request.TransformEncryption.MlUserDataEncryption = requestTransformEncryption_transformEncryption_MlUserDataEncryption;
                requestTransformEncryptionIsNull = false;
            }
             // determine if request.TransformEncryption should be set to null
            if (requestTransformEncryptionIsNull)
            {
                request.TransformEncryption = null;
            }
            if (cmdletContext.WorkerType != null)
            {
                request.WorkerType = cmdletContext.WorkerType;
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
        
        private Amazon.Glue.Model.CreateMLTransformResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateMLTransformRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateMLTransform");
            try
            {
                #if DESKTOP
                return client.CreateMLTransform(request);
                #elif CORECLR
                return client.CreateMLTransformAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String GlueVersion { get; set; }
            public List<Amazon.Glue.Model.GlueTable> InputRecordTable { get; set; }
            public System.Double? MaxCapacity { get; set; }
            public System.Int32? MaxRetry { get; set; }
            public System.String Name { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.Double? FindMatchesParameters_AccuracyCostTradeoff { get; set; }
            public System.Boolean? FindMatchesParameters_EnforceProvidedLabel { get; set; }
            public System.Double? FindMatchesParameters_PrecisionRecallTradeoff { get; set; }
            public System.String FindMatchesParameters_PrimaryKeyColumnName { get; set; }
            public Amazon.Glue.TransformType Parameters_TransformType { get; set; }
            public System.String Role { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.String MlUserDataEncryption_KmsKeyId { get; set; }
            public Amazon.Glue.MLUserDataEncryptionModeString MlUserDataEncryption_MlUserDataEncryptionMode { get; set; }
            public System.String TransformEncryption_TaskRunSecurityConfigurationName { get; set; }
            public Amazon.Glue.WorkerType WorkerType { get; set; }
            public System.Func<Amazon.Glue.Model.CreateMLTransformResponse, NewGLUEMLTransformCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransformId;
        }
        
    }
}
