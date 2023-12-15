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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a flow definition.
    /// </summary>
    [Cmdlet("New", "SMFlowDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateFlowDefinition API operation.", Operation = new[] {"CreateFlowDefinition"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateFlowDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateFlowDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateFlowDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMFlowDefinitionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HumanLoopRequestSource_AwsManagedHumanLoopRequestSource
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Rekognition or Amazon Textract are used as the integration
        /// source. The default field settings and JSON parsing rules are different based on the
        /// integration source. Valid values:</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AwsManagedHumanLoopRequestSource")]
        public Amazon.SageMaker.AwsManagedHumanLoopRequestSource HumanLoopRequestSource_AwsManagedHumanLoopRequestSource { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_Cent
        /// <summary>
        /// <para>
        /// <para>The fractional portion, in cents, of the amount. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents")]
        public System.Int32? AmountInUsd_Cent { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_Dollar
        /// <summary>
        /// <para>
        /// <para>The whole number of dollars in the amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars")]
        public System.Int32? AmountInUsd_Dollar { get; set; }
        #endregion
        
        #region Parameter FlowDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of your flow definition.</para>
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
        public System.String FlowDefinitionName { get; set; }
        #endregion
        
        #region Parameter HumanLoopActivationConditionsConfig_HumanLoopActivationCondition
        /// <summary>
        /// <para>
        /// <para>JSON expressing use-case specific conditions declaratively. If any condition is matched,
        /// atomic tasks are created against the configured work team. The set of conditions is
        /// different for Rekognition and Textract. For more information about how to structure
        /// the JSON, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/a2i-human-fallback-conditions-json-schema.html">JSON
        /// Schema for Human Loop Activation Conditions in Amazon Augmented AI</a> in the <i>Amazon
        /// SageMaker Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopActivationConfig_HumanLoopActivationConditionsConfig_HumanLoopActivationConditions")]
        public System.String HumanLoopActivationConditionsConfig_HumanLoopActivationCondition { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_HumanTaskUiArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the human task user interface.</para><para>You can use standard HTML and Crowd HTML Elements to create a custom worker task template.
        /// You use this template to create a human task UI.</para><para>To learn how to create a custom HTML template, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/a2i-custom-templates.html">Create
        /// Custom Worker Task Template</a>.</para><para>To learn how to create a human task UI, which is a worker task template that can be
        /// used in a flow definition, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/a2i-worker-template-console.html">Create
        /// and Delete a Worker Task Templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_HumanTaskUiArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Key Management Service (KMS) key ID for server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role needed to call other services on your behalf.
        /// For example, <code>arn:aws:iam::1234567890:role/service-role/AmazonSageMaker-ExecutionRole-20180111T151298</code>.</para>
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
        
        #region Parameter OutputConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path where the object containing human output will be made available.</para><para>To learn more about the format of Amazon A2I output data, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/a2i-output-data.html">Amazon
        /// A2I Output Data</a>.</para>
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
        public System.String OutputConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that contain metadata to help you categorize and organize
        /// a flow definition. Each tag consists of a key and a value, both of which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskAvailabilityLifetimeInSecond
        /// <summary>
        /// <para>
        /// <para>The length of time that a task remains available for review by human workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_TaskAvailabilityLifetimeInSeconds")]
        public System.Int32? HumanLoopConfig_TaskAvailabilityLifetimeInSecond { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskCount
        /// <summary>
        /// <para>
        /// <para>The number of distinct workers who will perform the same task on each object. For
        /// example, if <code>TaskCount</code> is set to <code>3</code> for an image classification
        /// labeling job, three workers will classify each input image. Increasing <code>TaskCount</code>
        /// can improve label accuracy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HumanLoopConfig_TaskCount { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskDescription
        /// <summary>
        /// <para>
        /// <para>A description for the human worker task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_TaskDescription { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskKeyword
        /// <summary>
        /// <para>
        /// <para>Keywords used to describe the task so that workers can discover the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_TaskKeywords")]
        public System.String[] HumanLoopConfig_TaskKeyword { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskTimeLimitInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time that a worker has to complete a task. The default value is 3,600
        /// seconds (1 hour).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_TaskTimeLimitInSeconds")]
        public System.Int32? HumanLoopConfig_TaskTimeLimitInSecond { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_TaskTitle
        /// <summary>
        /// <para>
        /// <para>A title for the human worker task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_TaskTitle { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_TenthFractionsOfACent
        /// <summary>
        /// <para>
        /// <para>Fractions of a cent, in tenths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent")]
        public System.Int32? AmountInUsd_TenthFractionsOfACent { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_WorkteamArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of a team of workers. To learn more about the types of
        /// workforces and work teams you can create and use with Amazon A2I, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sms-workforce-management.html">Create
        /// and Manage Workforces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_WorkteamArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlowDefinitionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateFlowDefinitionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateFlowDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlowDefinitionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowDefinitionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowDefinitionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowDefinitionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowDefinitionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMFlowDefinition (CreateFlowDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateFlowDefinitionResponse, NewSMFlowDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowDefinitionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FlowDefinitionName = this.FlowDefinitionName;
            #if MODULAR
            if (this.FlowDefinitionName == null && ParameterWasBound(nameof(this.FlowDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HumanLoopActivationConditionsConfig_HumanLoopActivationCondition = this.HumanLoopActivationConditionsConfig_HumanLoopActivationCondition;
            context.HumanLoopConfig_HumanTaskUiArn = this.HumanLoopConfig_HumanTaskUiArn;
            context.AmountInUsd_Cent = this.AmountInUsd_Cent;
            context.AmountInUsd_Dollar = this.AmountInUsd_Dollar;
            context.AmountInUsd_TenthFractionsOfACent = this.AmountInUsd_TenthFractionsOfACent;
            context.HumanLoopConfig_TaskAvailabilityLifetimeInSecond = this.HumanLoopConfig_TaskAvailabilityLifetimeInSecond;
            context.HumanLoopConfig_TaskCount = this.HumanLoopConfig_TaskCount;
            context.HumanLoopConfig_TaskDescription = this.HumanLoopConfig_TaskDescription;
            if (this.HumanLoopConfig_TaskKeyword != null)
            {
                context.HumanLoopConfig_TaskKeyword = new List<System.String>(this.HumanLoopConfig_TaskKeyword);
            }
            context.HumanLoopConfig_TaskTimeLimitInSecond = this.HumanLoopConfig_TaskTimeLimitInSecond;
            context.HumanLoopConfig_TaskTitle = this.HumanLoopConfig_TaskTitle;
            context.HumanLoopConfig_WorkteamArn = this.HumanLoopConfig_WorkteamArn;
            context.HumanLoopRequestSource_AwsManagedHumanLoopRequestSource = this.HumanLoopRequestSource_AwsManagedHumanLoopRequestSource;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.OutputConfig_S3OutputPath = this.OutputConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateFlowDefinitionRequest();
            
            if (cmdletContext.FlowDefinitionName != null)
            {
                request.FlowDefinitionName = cmdletContext.FlowDefinitionName;
            }
            
             // populate HumanLoopActivationConfig
            var requestHumanLoopActivationConfigIsNull = true;
            request.HumanLoopActivationConfig = new Amazon.SageMaker.Model.HumanLoopActivationConfig();
            Amazon.SageMaker.Model.HumanLoopActivationConditionsConfig requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig = null;
            
             // populate HumanLoopActivationConditionsConfig
            var requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfigIsNull = true;
            requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig = new Amazon.SageMaker.Model.HumanLoopActivationConditionsConfig();
            System.String requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig_humanLoopActivationConditionsConfig_HumanLoopActivationCondition = null;
            if (cmdletContext.HumanLoopActivationConditionsConfig_HumanLoopActivationCondition != null)
            {
                requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig_humanLoopActivationConditionsConfig_HumanLoopActivationCondition = cmdletContext.HumanLoopActivationConditionsConfig_HumanLoopActivationCondition;
            }
            if (requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig_humanLoopActivationConditionsConfig_HumanLoopActivationCondition != null)
            {
                requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig.HumanLoopActivationConditions = requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig_humanLoopActivationConditionsConfig_HumanLoopActivationCondition;
                requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfigIsNull = false;
            }
             // determine if requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig should be set to null
            if (requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfigIsNull)
            {
                requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig = null;
            }
            if (requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig != null)
            {
                request.HumanLoopActivationConfig.HumanLoopActivationConditionsConfig = requestHumanLoopActivationConfig_humanLoopActivationConfig_HumanLoopActivationConditionsConfig;
                requestHumanLoopActivationConfigIsNull = false;
            }
             // determine if request.HumanLoopActivationConfig should be set to null
            if (requestHumanLoopActivationConfigIsNull)
            {
                request.HumanLoopActivationConfig = null;
            }
            
             // populate HumanLoopConfig
            var requestHumanLoopConfigIsNull = true;
            request.HumanLoopConfig = new Amazon.SageMaker.Model.HumanLoopConfig();
            System.String requestHumanLoopConfig_humanLoopConfig_HumanTaskUiArn = null;
            if (cmdletContext.HumanLoopConfig_HumanTaskUiArn != null)
            {
                requestHumanLoopConfig_humanLoopConfig_HumanTaskUiArn = cmdletContext.HumanLoopConfig_HumanTaskUiArn;
            }
            if (requestHumanLoopConfig_humanLoopConfig_HumanTaskUiArn != null)
            {
                request.HumanLoopConfig.HumanTaskUiArn = requestHumanLoopConfig_humanLoopConfig_HumanTaskUiArn;
                requestHumanLoopConfigIsNull = false;
            }
            System.Int32? requestHumanLoopConfig_humanLoopConfig_TaskAvailabilityLifetimeInSecond = null;
            if (cmdletContext.HumanLoopConfig_TaskAvailabilityLifetimeInSecond != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskAvailabilityLifetimeInSecond = cmdletContext.HumanLoopConfig_TaskAvailabilityLifetimeInSecond.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskAvailabilityLifetimeInSecond != null)
            {
                request.HumanLoopConfig.TaskAvailabilityLifetimeInSeconds = requestHumanLoopConfig_humanLoopConfig_TaskAvailabilityLifetimeInSecond.Value;
                requestHumanLoopConfigIsNull = false;
            }
            System.Int32? requestHumanLoopConfig_humanLoopConfig_TaskCount = null;
            if (cmdletContext.HumanLoopConfig_TaskCount != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskCount = cmdletContext.HumanLoopConfig_TaskCount.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskCount != null)
            {
                request.HumanLoopConfig.TaskCount = requestHumanLoopConfig_humanLoopConfig_TaskCount.Value;
                requestHumanLoopConfigIsNull = false;
            }
            System.String requestHumanLoopConfig_humanLoopConfig_TaskDescription = null;
            if (cmdletContext.HumanLoopConfig_TaskDescription != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskDescription = cmdletContext.HumanLoopConfig_TaskDescription;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskDescription != null)
            {
                request.HumanLoopConfig.TaskDescription = requestHumanLoopConfig_humanLoopConfig_TaskDescription;
                requestHumanLoopConfigIsNull = false;
            }
            List<System.String> requestHumanLoopConfig_humanLoopConfig_TaskKeyword = null;
            if (cmdletContext.HumanLoopConfig_TaskKeyword != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskKeyword = cmdletContext.HumanLoopConfig_TaskKeyword;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskKeyword != null)
            {
                request.HumanLoopConfig.TaskKeywords = requestHumanLoopConfig_humanLoopConfig_TaskKeyword;
                requestHumanLoopConfigIsNull = false;
            }
            System.Int32? requestHumanLoopConfig_humanLoopConfig_TaskTimeLimitInSecond = null;
            if (cmdletContext.HumanLoopConfig_TaskTimeLimitInSecond != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskTimeLimitInSecond = cmdletContext.HumanLoopConfig_TaskTimeLimitInSecond.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskTimeLimitInSecond != null)
            {
                request.HumanLoopConfig.TaskTimeLimitInSeconds = requestHumanLoopConfig_humanLoopConfig_TaskTimeLimitInSecond.Value;
                requestHumanLoopConfigIsNull = false;
            }
            System.String requestHumanLoopConfig_humanLoopConfig_TaskTitle = null;
            if (cmdletContext.HumanLoopConfig_TaskTitle != null)
            {
                requestHumanLoopConfig_humanLoopConfig_TaskTitle = cmdletContext.HumanLoopConfig_TaskTitle;
            }
            if (requestHumanLoopConfig_humanLoopConfig_TaskTitle != null)
            {
                request.HumanLoopConfig.TaskTitle = requestHumanLoopConfig_humanLoopConfig_TaskTitle;
                requestHumanLoopConfigIsNull = false;
            }
            System.String requestHumanLoopConfig_humanLoopConfig_WorkteamArn = null;
            if (cmdletContext.HumanLoopConfig_WorkteamArn != null)
            {
                requestHumanLoopConfig_humanLoopConfig_WorkteamArn = cmdletContext.HumanLoopConfig_WorkteamArn;
            }
            if (requestHumanLoopConfig_humanLoopConfig_WorkteamArn != null)
            {
                request.HumanLoopConfig.WorkteamArn = requestHumanLoopConfig_humanLoopConfig_WorkteamArn;
                requestHumanLoopConfigIsNull = false;
            }
            Amazon.SageMaker.Model.PublicWorkforceTaskPrice requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice = null;
            
             // populate PublicWorkforceTaskPrice
            var requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPriceIsNull = true;
            requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice = new Amazon.SageMaker.Model.PublicWorkforceTaskPrice();
            Amazon.SageMaker.Model.USD requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd = null;
            
             // populate AmountInUsd
            var requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = true;
            requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd = new Amazon.SageMaker.Model.USD();
            System.Int32? requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent = null;
            if (cmdletContext.AmountInUsd_Cent != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent = cmdletContext.AmountInUsd_Cent.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd.Cents = requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent.Value;
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
            System.Int32? requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar = null;
            if (cmdletContext.AmountInUsd_Dollar != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar = cmdletContext.AmountInUsd_Dollar.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd.Dollars = requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar.Value;
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
            System.Int32? requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent = null;
            if (cmdletContext.AmountInUsd_TenthFractionsOfACent != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent = cmdletContext.AmountInUsd_TenthFractionsOfACent.Value;
            }
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd.TenthFractionsOfACent = requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent.Value;
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
             // determine if requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd should be set to null
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd = null;
            }
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd != null)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice.AmountInUsd = requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice_humanLoopConfig_PublicWorkforceTaskPrice_AmountInUsd;
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPriceIsNull = false;
            }
             // determine if requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice should be set to null
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPriceIsNull)
            {
                requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice = null;
            }
            if (requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice != null)
            {
                request.HumanLoopConfig.PublicWorkforceTaskPrice = requestHumanLoopConfig_humanLoopConfig_PublicWorkforceTaskPrice;
                requestHumanLoopConfigIsNull = false;
            }
             // determine if request.HumanLoopConfig should be set to null
            if (requestHumanLoopConfigIsNull)
            {
                request.HumanLoopConfig = null;
            }
            
             // populate HumanLoopRequestSource
            var requestHumanLoopRequestSourceIsNull = true;
            request.HumanLoopRequestSource = new Amazon.SageMaker.Model.HumanLoopRequestSource();
            Amazon.SageMaker.AwsManagedHumanLoopRequestSource requestHumanLoopRequestSource_humanLoopRequestSource_AwsManagedHumanLoopRequestSource = null;
            if (cmdletContext.HumanLoopRequestSource_AwsManagedHumanLoopRequestSource != null)
            {
                requestHumanLoopRequestSource_humanLoopRequestSource_AwsManagedHumanLoopRequestSource = cmdletContext.HumanLoopRequestSource_AwsManagedHumanLoopRequestSource;
            }
            if (requestHumanLoopRequestSource_humanLoopRequestSource_AwsManagedHumanLoopRequestSource != null)
            {
                request.HumanLoopRequestSource.AwsManagedHumanLoopRequestSource = requestHumanLoopRequestSource_humanLoopRequestSource_AwsManagedHumanLoopRequestSource;
                requestHumanLoopRequestSourceIsNull = false;
            }
             // determine if request.HumanLoopRequestSource should be set to null
            if (requestHumanLoopRequestSourceIsNull)
            {
                request.HumanLoopRequestSource = null;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.FlowDefinitionOutputConfig();
            System.String requestOutputConfig_outputConfig_KmsKeyId = null;
            if (cmdletContext.OutputConfig_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_KmsKeyId = cmdletContext.OutputConfig_KmsKeyId;
            }
            if (requestOutputConfig_outputConfig_KmsKeyId != null)
            {
                request.OutputConfig.KmsKeyId = requestOutputConfig_outputConfig_KmsKeyId;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3OutputPath = null;
            if (cmdletContext.OutputConfig_S3OutputPath != null)
            {
                requestOutputConfig_outputConfig_S3OutputPath = cmdletContext.OutputConfig_S3OutputPath;
            }
            if (requestOutputConfig_outputConfig_S3OutputPath != null)
            {
                request.OutputConfig.S3OutputPath = requestOutputConfig_outputConfig_S3OutputPath;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateFlowDefinitionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateFlowDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateFlowDefinition");
            try
            {
                #if DESKTOP
                return client.CreateFlowDefinition(request);
                #elif CORECLR
                return client.CreateFlowDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowDefinitionName { get; set; }
            public System.String HumanLoopActivationConditionsConfig_HumanLoopActivationCondition { get; set; }
            public System.String HumanLoopConfig_HumanTaskUiArn { get; set; }
            public System.Int32? AmountInUsd_Cent { get; set; }
            public System.Int32? AmountInUsd_Dollar { get; set; }
            public System.Int32? AmountInUsd_TenthFractionsOfACent { get; set; }
            public System.Int32? HumanLoopConfig_TaskAvailabilityLifetimeInSecond { get; set; }
            public System.Int32? HumanLoopConfig_TaskCount { get; set; }
            public System.String HumanLoopConfig_TaskDescription { get; set; }
            public List<System.String> HumanLoopConfig_TaskKeyword { get; set; }
            public System.Int32? HumanLoopConfig_TaskTimeLimitInSecond { get; set; }
            public System.String HumanLoopConfig_TaskTitle { get; set; }
            public System.String HumanLoopConfig_WorkteamArn { get; set; }
            public Amazon.SageMaker.AwsManagedHumanLoopRequestSource HumanLoopRequestSource_AwsManagedHumanLoopRequestSource { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String OutputConfig_S3OutputPath { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateFlowDefinitionResponse, NewSMFlowDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlowDefinitionArn;
        }
        
    }
}
