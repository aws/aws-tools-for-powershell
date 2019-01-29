/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a job that uses workers to label the data objects in your input dataset. You
    /// can use the labeled data to train machine learning models.
    /// 
    ///  
    /// <para>
    /// You can select your workforce from one of three providers:
    /// </para><ul><li><para>
    /// A private workforce that you create. It can include employees, contractors, and outside
    /// experts. Use a private workforce when want the data to stay within your organization
    /// or when a specific set of skills is required.
    /// </para></li><li><para>
    /// One or more vendors that you select from the AWS Marketplace. Vendors provide expertise
    /// in specific areas. 
    /// </para></li><li><para>
    /// The Amazon Mechanical Turk workforce. This is the largest workforce, but it should
    /// only be used for public data or data that has been stripped of any personally identifiable
    /// information.
    /// </para></li></ul><para>
    /// You can also use <i>automated data labeling</i> to reduce the number of data objects
    /// that need to be labeled by a human. Automated data labeling uses <i>active learning</i>
    /// to determine if a data object can be labeled by machine or if it needs to be sent
    /// to a human worker. For more information, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sms-automated-labeling.html">Using
    /// Automated Data Labeling</a>.
    /// </para><para>
    /// The data objects to be labeled are contained in an Amazon S3 bucket. You create a
    /// <i>manifest file</i> that describes the location of each object. For more information,
    /// see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sms-data.html">Using Input
    /// and Output Data</a>.
    /// </para><para>
    /// The output can be used as the manifest file for another labeling job or as training
    /// data for your machine learning models.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMLabelingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateLabelingJob API operation.", Operation = new[] {"CreateLabelingJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateLabelingJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMLabelingJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Lambda function implements the logic for annotation
        /// consolidation.</para><para>For the built-in bounding box, image classification, semantic segmentation, and text
        /// classification task types, Amazon SageMaker Ground Truth provides the following Lambda
        /// functions:</para><ul><li><para><i>Bounding box</i> - Finds the most similar boxes from different workers based on
        /// the Jaccard index of the boxes.</para><para><code>arn:aws:lambda:us-east-1:432418664414:function:ACS-BoundingBox</code></para><para><code>arn:aws:lambda:us-east-2:266458841044:function:ACS-BoundingBox</code></para><para><code>arn:aws:lambda:us-west-2:081040173940:function:ACS-BoundingBox</code></para><para><code>arn:aws:lambda:eu-west-1:568282634449:function:ACS-BoundingBox</code></para><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:ACS-BoundingBox</code></para></li><li><para><i>Image classification</i> - Uses a variant of the Expectation Maximization approach
        /// to estimate the true class of an image based on annotations from individual workers.</para><para><code>arn:aws:lambda:us-east-1:432418664414:function:ACS-ImageMultiClass</code></para><para><code>arn:aws:lambda:us-east-2:266458841044:function:ACS-ImageMultiClass</code></para><para><code>arn:aws:lambda:us-west-2:081040173940:function:ACS-ImageMultiClass</code></para><para><code>arn:aws:lambda:eu-west-1:568282634449:function:ACS-ImageMultiClass</code></para><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:ACS-ImageMultiClass</code></para></li><li><para><i>Semantic segmentation</i> - Treats each pixel in an image as a multi-class classification
        /// and treats pixel annotations from workers as "votes" for the correct label.</para><para><code>arn:aws:lambda:us-east-1:432418664414:function:ACS-SemanticSegmentation</code></para><para><code>arn:aws:lambda:us-east-2:266458841044:function:ACS-SemanticSegmentation</code></para><para><code>arn:aws:lambda:us-west-2:081040173940:function:ACS-SemanticSegmentation</code></para><para><code>arn:aws:lambda:eu-west-1:568282634449:function:ACS-SemanticSegmentation</code></para><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:ACS-SemanticSegmentation</code></para></li><li><para><i>Text classification</i> - Uses a variant of the Expectation Maximization approach
        /// to estimate the true class of text based on annotations from individual workers.</para><para><code>arn:aws:lambda:us-east-1:432418664414:function:ACS-TextMultiClass</code></para><para><code>arn:aws:lambda:us-east-2:266458841044:function:ACS-TextMultiClass</code></para><para><code>arn:aws:lambda:us-west-2:081040173940:function:ACS-TextMultiClass</code></para><para><code>arn:aws:lambda:eu-west-1:568282634449:function:ACS-TextMultiClass</code></para><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:ACS-TextMultiClass</code></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sms-annotation-consolidation.html">Annotation
        /// Consolidation</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn")]
        public System.String AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_Cent
        /// <summary>
        /// <para>
        /// <para>The fractional portion, in cents, of the amount. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents")]
        public System.Int32 AmountInUsd_Cent { get; set; }
        #endregion
        
        #region Parameter DataAttributes_ContentClassifier
        /// <summary>
        /// <para>
        /// <para>Declares that your content is free of personally identifiable information or adult
        /// content. Amazon SageMaker may restrict the Amazon Mechanical Turk workers that can
        /// view your task based on this information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputConfig_DataAttributes_ContentClassifiers")]
        public System.String[] DataAttributes_ContentClassifier { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_Dollar
        /// <summary>
        /// <para>
        /// <para>The whole number of dollars in the amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars")]
        public System.Int32 AmountInUsd_Dollar { get; set; }
        #endregion
        
        #region Parameter LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn
        /// <summary>
        /// <para>
        /// <para>At the end of an auto-label job Amazon SageMaker Ground Truth sends the Amazon Resource
        /// Nam (ARN) of the final model used for auto-labeling. You can use this model as the
        /// starting point for subsequent similar jobs by providing the ARN of the model here.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service ID of the key used to encrypt the output data, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LabelAttributeName
        /// <summary>
        /// <para>
        /// <para>The attribute name to use for the label in the output manifest file. This is the key
        /// for the key/value pair formed with the label that a worker assigns to the object.
        /// The name can't end with "-metadata". If you are running a semantic segmentation labeling
        /// job, the attribute name must end with "-ref". If you are running any other kind of
        /// labeling job, the attribute name must not end with "-ref".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LabelAttributeName { get; set; }
        #endregion
        
        #region Parameter LabelCategoryConfigS3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URL of the file that defines the categories used to label the data objects.</para><para>The file is a JSON structure in the following format:</para><para><code>{</code></para><para><code> "document-version": "2018-11-28"</code></para><para><code> "labels": [</code></para><para><code> {</code></para><para><code> "label": "<i>label 1</i>"</code></para><para><code> },</code></para><para><code> {</code></para><para><code> "label": "<i>label 2</i>"</code></para><para><code> },</code></para><para><code> ...</code></para><para><code> {</code></para><para><code> "label": "<i>label n</i>"</code></para><para><code> }</code></para><para><code> ]</code></para><para><code>}</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LabelCategoryConfigS3Uri { get; set; }
        #endregion
        
        #region Parameter LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the algorithm used for auto-labeling.
        /// You must select one of the following ARNs:</para><ul><li><para><i>Image classification</i></para><para><code>arn:aws:sagemaker:<i>region</i>:027400017018:labeling-job-algorithm-specification/image-classification</code></para></li><li><para><i>Text classification</i></para><para><code>arn:aws:sagemaker:<i>region</i>:027400017018:labeling-job-algorithm-specification/text-classification</code></para></li><li><para><i>Object detection</i></para><para><code>arn:aws:sagemaker:<i>region</i>:027400017018:labeling-job-algorithm-specification/object-detection</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn { get; set; }
        #endregion
        
        #region Parameter LabelingJobName
        /// <summary>
        /// <para>
        /// <para>The name of the labeling job. This name is used to identify the job in a list of labeling
        /// jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LabelingJobName { get; set; }
        #endregion
        
        #region Parameter S3DataSource_ManifestS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the manifest file that describes the input data objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputConfig_DataSource_S3DataSource_ManifestS3Uri")]
        public System.String S3DataSource_ManifestS3Uri { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_MaxConcurrentTaskCount
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of data objects that can be labeled by human workers at
        /// the same time. Each object may have more than one worker at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HumanTaskConfig_MaxConcurrentTaskCount { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_MaxHumanLabeledObjectCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that can be labeled by human workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 StoppingConditions_MaxHumanLabeledObjectCount { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_MaxPercentageOfInputDatasetLabeled
        /// <summary>
        /// <para>
        /// <para>The maximum number of input data objects that should be labeled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 StoppingConditions_MaxPercentageOfInputDatasetLabeled { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_NumberOfHumanWorkersPerDataObject
        /// <summary>
        /// <para>
        /// <para>The number of human workers that will label an object. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HumanTaskConfig_NumberOfHumanWorkersPerDataObject { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_PreHumanTaskLambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Lambda function that is run before a data object
        /// is sent to a human worker. Use this function to provide input to a custom labeling
        /// job.</para><para>For the built-in bounding box, image classification, semantic segmentation, and text
        /// classification task types, Amazon SageMaker Ground Truth provides the following Lambda
        /// functions:</para><para><b>US East (Northern Virginia) (us-east-1):</b></para><ul><li><para><code>arn:aws:lambda:us-east-1:432418664414:function:PRE-BoundingBox</code></para></li><li><para><code>arn:aws:lambda:us-east-1:432418664414:function:PRE-ImageMultiClass</code></para></li><li><para><code>arn:aws:lambda:us-east-1:432418664414:function:PRE-SemanticSegmentation</code></para></li><li><para><code>arn:aws:lambda:us-east-1:432418664414:function:PRE-TextMultiClass</code></para></li></ul><para><b>US East (Ohio) (us-east-2):</b></para><ul><li><para><code>arn:aws:lambda:us-east-2:266458841044:function:PRE-BoundingBox</code></para></li><li><para><code>arn:aws:lambda:us-east-2:266458841044:function:PRE-ImageMultiClass</code></para></li><li><para><code>arn:aws:lambda:us-east-2:266458841044:function:PRE-SemanticSegmentation</code></para></li><li><para><code>arn:aws:lambda:us-east-2:266458841044:function:PRE-TextMultiClass</code></para></li></ul><para><b>US West (Oregon) (us-west-2):</b></para><ul><li><para><code>arn:aws:lambda:us-west-2:081040173940:function:PRE-BoundingBox</code></para></li><li><para><code>arn:aws:lambda:us-west-2:081040173940:function:PRE-ImageMultiClass</code></para></li><li><para><code>arn:aws:lambda:us-west-2:081040173940:function:PRE-SemanticSegmentation</code></para></li><li><para><code>arn:aws:lambda:us-west-2:081040173940:function:PRE-TextMultiClass</code></para></li></ul><para><b>EU (Ireland) (eu-west-1):</b></para><ul><li><para><code>arn:aws:lambda:eu-west-1:568282634449:function:PRE-BoundingBox</code></para></li><li><para><code>arn:aws:lambda:eu-west-1:568282634449:function:PRE-ImageMultiClass</code></para></li><li><para><code>arn:aws:lambda:eu-west-1:568282634449:function:PRE-SemanticSegmentation</code></para></li><li><para><code>arn:aws:lambda:eu-west-1:568282634449:function:PRE-TextMultiClass</code></para></li></ul><para><b>Asia Pacific (Tokyo (ap-northeast-1):</b></para><ul><li><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:PRE-BoundingBox</code></para></li><li><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:PRE-ImageMultiClass</code></para></li><li><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:PRE-SemanticSegmentation</code></para></li><li><para><code>arn:aws:lambda:ap-northeast-1:477331159723:function:PRE-TextMultiClass</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HumanTaskConfig_PreHumanTaskLambdaArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) that Amazon SageMaker assumes to perform tasks on
        /// your behalf during data labeling. You must grant this role the necessary permissions
        /// so that Amazon SageMaker can successfully complete data labeling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location to write output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key/value pairs. For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>AWS Billing and Cost Management User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_TaskAvailabilityLifetimeInSecond
        /// <summary>
        /// <para>
        /// <para>The length of time that a task remains available for labelling by human workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_TaskAvailabilityLifetimeInSeconds")]
        public System.Int32 HumanTaskConfig_TaskAvailabilityLifetimeInSecond { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_TaskDescription
        /// <summary>
        /// <para>
        /// <para>A description of the task for your human workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HumanTaskConfig_TaskDescription { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_TaskKeyword
        /// <summary>
        /// <para>
        /// <para>Keywords used to describe the task so that workers on Amazon Mechanical Turk can discover
        /// the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_TaskKeywords")]
        public System.String[] HumanTaskConfig_TaskKeyword { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_TaskTimeLimitInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time that a worker has to complete a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_TaskTimeLimitInSeconds")]
        public System.Int32 HumanTaskConfig_TaskTimeLimitInSecond { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_TaskTitle
        /// <summary>
        /// <para>
        /// <para>A title for the task for your human workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HumanTaskConfig_TaskTitle { get; set; }
        #endregion
        
        #region Parameter AmountInUsd_TenthFractionsOfACent
        /// <summary>
        /// <para>
        /// <para>Fractions of a cent, in tenths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent")]
        public System.Int32 AmountInUsd_TenthFractionsOfACent { get; set; }
        #endregion
        
        #region Parameter UiConfig_UiTemplateS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket location of the UI template. For more information about the contents
        /// of a UI template, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sms-custom-templates-step2.html">
        /// Creating Your Custom Labeling Task Template</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HumanTaskConfig_UiConfig_UiTemplateS3Uri")]
        public System.String UiConfig_UiTemplateS3Uri { get; set; }
        #endregion
        
        #region Parameter LabelingJobResourceConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service key ID for the key used to encrypt the output data,
        /// if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LabelingJobAlgorithmsConfig_LabelingJobResourceConfig_VolumeKmsKeyId")]
        public System.String LabelingJobResourceConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter HumanTaskConfig_WorkteamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the work team assigned to complete the tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HumanTaskConfig_WorkteamArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LabelingJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMLabelingJob (CreateLabelingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HumanTaskConfig_AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn = this.AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn;
            if (ParameterWasBound("HumanTaskConfig_MaxConcurrentTaskCount"))
                context.HumanTaskConfig_MaxConcurrentTaskCount = this.HumanTaskConfig_MaxConcurrentTaskCount;
            if (ParameterWasBound("HumanTaskConfig_NumberOfHumanWorkersPerDataObject"))
                context.HumanTaskConfig_NumberOfHumanWorkersPerDataObject = this.HumanTaskConfig_NumberOfHumanWorkersPerDataObject;
            context.HumanTaskConfig_PreHumanTaskLambdaArn = this.HumanTaskConfig_PreHumanTaskLambdaArn;
            if (ParameterWasBound("AmountInUsd_Cent"))
                context.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents = this.AmountInUsd_Cent;
            if (ParameterWasBound("AmountInUsd_Dollar"))
                context.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars = this.AmountInUsd_Dollar;
            if (ParameterWasBound("AmountInUsd_TenthFractionsOfACent"))
                context.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent = this.AmountInUsd_TenthFractionsOfACent;
            if (ParameterWasBound("HumanTaskConfig_TaskAvailabilityLifetimeInSecond"))
                context.HumanTaskConfig_TaskAvailabilityLifetimeInSeconds = this.HumanTaskConfig_TaskAvailabilityLifetimeInSecond;
            context.HumanTaskConfig_TaskDescription = this.HumanTaskConfig_TaskDescription;
            if (this.HumanTaskConfig_TaskKeyword != null)
            {
                context.HumanTaskConfig_TaskKeywords = new List<System.String>(this.HumanTaskConfig_TaskKeyword);
            }
            if (ParameterWasBound("HumanTaskConfig_TaskTimeLimitInSecond"))
                context.HumanTaskConfig_TaskTimeLimitInSeconds = this.HumanTaskConfig_TaskTimeLimitInSecond;
            context.HumanTaskConfig_TaskTitle = this.HumanTaskConfig_TaskTitle;
            context.HumanTaskConfig_UiConfig_UiTemplateS3Uri = this.UiConfig_UiTemplateS3Uri;
            context.HumanTaskConfig_WorkteamArn = this.HumanTaskConfig_WorkteamArn;
            if (this.DataAttributes_ContentClassifier != null)
            {
                context.InputConfig_DataAttributes_ContentClassifiers = new List<System.String>(this.DataAttributes_ContentClassifier);
            }
            context.InputConfig_DataSource_S3DataSource_ManifestS3Uri = this.S3DataSource_ManifestS3Uri;
            context.LabelAttributeName = this.LabelAttributeName;
            context.LabelCategoryConfigS3Uri = this.LabelCategoryConfigS3Uri;
            context.LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn = this.LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn;
            context.LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn = this.LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn;
            context.LabelingJobAlgorithmsConfig_LabelingJobResourceConfig_VolumeKmsKeyId = this.LabelingJobResourceConfig_VolumeKmsKeyId;
            context.LabelingJobName = this.LabelingJobName;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.OutputConfig_S3OutputPath = this.OutputConfig_S3OutputPath;
            context.RoleArn = this.RoleArn;
            if (ParameterWasBound("StoppingConditions_MaxHumanLabeledObjectCount"))
                context.StoppingConditions_MaxHumanLabeledObjectCount = this.StoppingConditions_MaxHumanLabeledObjectCount;
            if (ParameterWasBound("StoppingConditions_MaxPercentageOfInputDatasetLabeled"))
                context.StoppingConditions_MaxPercentageOfInputDatasetLabeled = this.StoppingConditions_MaxPercentageOfInputDatasetLabeled;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateLabelingJobRequest();
            
            
             // populate HumanTaskConfig
            bool requestHumanTaskConfigIsNull = true;
            request.HumanTaskConfig = new Amazon.SageMaker.Model.HumanTaskConfig();
            System.Int32? requestHumanTaskConfig_humanTaskConfig_MaxConcurrentTaskCount = null;
            if (cmdletContext.HumanTaskConfig_MaxConcurrentTaskCount != null)
            {
                requestHumanTaskConfig_humanTaskConfig_MaxConcurrentTaskCount = cmdletContext.HumanTaskConfig_MaxConcurrentTaskCount.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_MaxConcurrentTaskCount != null)
            {
                request.HumanTaskConfig.MaxConcurrentTaskCount = requestHumanTaskConfig_humanTaskConfig_MaxConcurrentTaskCount.Value;
                requestHumanTaskConfigIsNull = false;
            }
            System.Int32? requestHumanTaskConfig_humanTaskConfig_NumberOfHumanWorkersPerDataObject = null;
            if (cmdletContext.HumanTaskConfig_NumberOfHumanWorkersPerDataObject != null)
            {
                requestHumanTaskConfig_humanTaskConfig_NumberOfHumanWorkersPerDataObject = cmdletContext.HumanTaskConfig_NumberOfHumanWorkersPerDataObject.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_NumberOfHumanWorkersPerDataObject != null)
            {
                request.HumanTaskConfig.NumberOfHumanWorkersPerDataObject = requestHumanTaskConfig_humanTaskConfig_NumberOfHumanWorkersPerDataObject.Value;
                requestHumanTaskConfigIsNull = false;
            }
            System.String requestHumanTaskConfig_humanTaskConfig_PreHumanTaskLambdaArn = null;
            if (cmdletContext.HumanTaskConfig_PreHumanTaskLambdaArn != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PreHumanTaskLambdaArn = cmdletContext.HumanTaskConfig_PreHumanTaskLambdaArn;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PreHumanTaskLambdaArn != null)
            {
                request.HumanTaskConfig.PreHumanTaskLambdaArn = requestHumanTaskConfig_humanTaskConfig_PreHumanTaskLambdaArn;
                requestHumanTaskConfigIsNull = false;
            }
            System.Int32? requestHumanTaskConfig_humanTaskConfig_TaskAvailabilityLifetimeInSecond = null;
            if (cmdletContext.HumanTaskConfig_TaskAvailabilityLifetimeInSeconds != null)
            {
                requestHumanTaskConfig_humanTaskConfig_TaskAvailabilityLifetimeInSecond = cmdletContext.HumanTaskConfig_TaskAvailabilityLifetimeInSeconds.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_TaskAvailabilityLifetimeInSecond != null)
            {
                request.HumanTaskConfig.TaskAvailabilityLifetimeInSeconds = requestHumanTaskConfig_humanTaskConfig_TaskAvailabilityLifetimeInSecond.Value;
                requestHumanTaskConfigIsNull = false;
            }
            System.String requestHumanTaskConfig_humanTaskConfig_TaskDescription = null;
            if (cmdletContext.HumanTaskConfig_TaskDescription != null)
            {
                requestHumanTaskConfig_humanTaskConfig_TaskDescription = cmdletContext.HumanTaskConfig_TaskDescription;
            }
            if (requestHumanTaskConfig_humanTaskConfig_TaskDescription != null)
            {
                request.HumanTaskConfig.TaskDescription = requestHumanTaskConfig_humanTaskConfig_TaskDescription;
                requestHumanTaskConfigIsNull = false;
            }
            List<System.String> requestHumanTaskConfig_humanTaskConfig_TaskKeyword = null;
            if (cmdletContext.HumanTaskConfig_TaskKeywords != null)
            {
                requestHumanTaskConfig_humanTaskConfig_TaskKeyword = cmdletContext.HumanTaskConfig_TaskKeywords;
            }
            if (requestHumanTaskConfig_humanTaskConfig_TaskKeyword != null)
            {
                request.HumanTaskConfig.TaskKeywords = requestHumanTaskConfig_humanTaskConfig_TaskKeyword;
                requestHumanTaskConfigIsNull = false;
            }
            System.Int32? requestHumanTaskConfig_humanTaskConfig_TaskTimeLimitInSecond = null;
            if (cmdletContext.HumanTaskConfig_TaskTimeLimitInSeconds != null)
            {
                requestHumanTaskConfig_humanTaskConfig_TaskTimeLimitInSecond = cmdletContext.HumanTaskConfig_TaskTimeLimitInSeconds.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_TaskTimeLimitInSecond != null)
            {
                request.HumanTaskConfig.TaskTimeLimitInSeconds = requestHumanTaskConfig_humanTaskConfig_TaskTimeLimitInSecond.Value;
                requestHumanTaskConfigIsNull = false;
            }
            System.String requestHumanTaskConfig_humanTaskConfig_TaskTitle = null;
            if (cmdletContext.HumanTaskConfig_TaskTitle != null)
            {
                requestHumanTaskConfig_humanTaskConfig_TaskTitle = cmdletContext.HumanTaskConfig_TaskTitle;
            }
            if (requestHumanTaskConfig_humanTaskConfig_TaskTitle != null)
            {
                request.HumanTaskConfig.TaskTitle = requestHumanTaskConfig_humanTaskConfig_TaskTitle;
                requestHumanTaskConfigIsNull = false;
            }
            System.String requestHumanTaskConfig_humanTaskConfig_WorkteamArn = null;
            if (cmdletContext.HumanTaskConfig_WorkteamArn != null)
            {
                requestHumanTaskConfig_humanTaskConfig_WorkteamArn = cmdletContext.HumanTaskConfig_WorkteamArn;
            }
            if (requestHumanTaskConfig_humanTaskConfig_WorkteamArn != null)
            {
                request.HumanTaskConfig.WorkteamArn = requestHumanTaskConfig_humanTaskConfig_WorkteamArn;
                requestHumanTaskConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AnnotationConsolidationConfig requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig = null;
            
             // populate AnnotationConsolidationConfig
            bool requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfigIsNull = true;
            requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig = new Amazon.SageMaker.Model.AnnotationConsolidationConfig();
            System.String requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig_annotationConsolidationConfig_AnnotationConsolidationLambdaArn = null;
            if (cmdletContext.HumanTaskConfig_AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn != null)
            {
                requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig_annotationConsolidationConfig_AnnotationConsolidationLambdaArn = cmdletContext.HumanTaskConfig_AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn;
            }
            if (requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig_annotationConsolidationConfig_AnnotationConsolidationLambdaArn != null)
            {
                requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig.AnnotationConsolidationLambdaArn = requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig_annotationConsolidationConfig_AnnotationConsolidationLambdaArn;
                requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfigIsNull = false;
            }
             // determine if requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig should be set to null
            if (requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfigIsNull)
            {
                requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig = null;
            }
            if (requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig != null)
            {
                request.HumanTaskConfig.AnnotationConsolidationConfig = requestHumanTaskConfig_humanTaskConfig_AnnotationConsolidationConfig;
                requestHumanTaskConfigIsNull = false;
            }
            Amazon.SageMaker.Model.PublicWorkforceTaskPrice requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice = null;
            
             // populate PublicWorkforceTaskPrice
            bool requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPriceIsNull = true;
            requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice = new Amazon.SageMaker.Model.PublicWorkforceTaskPrice();
            Amazon.SageMaker.Model.USD requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd = null;
            
             // populate AmountInUsd
            bool requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = true;
            requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd = new Amazon.SageMaker.Model.USD();
            System.Int32? requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent = null;
            if (cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent = cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd.Cents = requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Cent.Value;
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
            System.Int32? requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar = null;
            if (cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar = cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd.Dollars = requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_Dollar.Value;
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
            System.Int32? requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent = null;
            if (cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent = cmdletContext.HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent.Value;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd.TenthFractionsOfACent = requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_amountInUsd_TenthFractionsOfACent.Value;
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull = false;
            }
             // determine if requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd should be set to null
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsdIsNull)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd = null;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd != null)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice.AmountInUsd = requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice_humanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd;
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPriceIsNull = false;
            }
             // determine if requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice should be set to null
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPriceIsNull)
            {
                requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice = null;
            }
            if (requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice != null)
            {
                request.HumanTaskConfig.PublicWorkforceTaskPrice = requestHumanTaskConfig_humanTaskConfig_PublicWorkforceTaskPrice;
                requestHumanTaskConfigIsNull = false;
            }
            Amazon.SageMaker.Model.UiConfig requestHumanTaskConfig_humanTaskConfig_UiConfig = null;
            
             // populate UiConfig
            bool requestHumanTaskConfig_humanTaskConfig_UiConfigIsNull = true;
            requestHumanTaskConfig_humanTaskConfig_UiConfig = new Amazon.SageMaker.Model.UiConfig();
            System.String requestHumanTaskConfig_humanTaskConfig_UiConfig_uiConfig_UiTemplateS3Uri = null;
            if (cmdletContext.HumanTaskConfig_UiConfig_UiTemplateS3Uri != null)
            {
                requestHumanTaskConfig_humanTaskConfig_UiConfig_uiConfig_UiTemplateS3Uri = cmdletContext.HumanTaskConfig_UiConfig_UiTemplateS3Uri;
            }
            if (requestHumanTaskConfig_humanTaskConfig_UiConfig_uiConfig_UiTemplateS3Uri != null)
            {
                requestHumanTaskConfig_humanTaskConfig_UiConfig.UiTemplateS3Uri = requestHumanTaskConfig_humanTaskConfig_UiConfig_uiConfig_UiTemplateS3Uri;
                requestHumanTaskConfig_humanTaskConfig_UiConfigIsNull = false;
            }
             // determine if requestHumanTaskConfig_humanTaskConfig_UiConfig should be set to null
            if (requestHumanTaskConfig_humanTaskConfig_UiConfigIsNull)
            {
                requestHumanTaskConfig_humanTaskConfig_UiConfig = null;
            }
            if (requestHumanTaskConfig_humanTaskConfig_UiConfig != null)
            {
                request.HumanTaskConfig.UiConfig = requestHumanTaskConfig_humanTaskConfig_UiConfig;
                requestHumanTaskConfigIsNull = false;
            }
             // determine if request.HumanTaskConfig should be set to null
            if (requestHumanTaskConfigIsNull)
            {
                request.HumanTaskConfig = null;
            }
            
             // populate InputConfig
            bool requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMaker.Model.LabelingJobInputConfig();
            Amazon.SageMaker.Model.LabelingJobDataAttributes requestInputConfig_inputConfig_DataAttributes = null;
            
             // populate DataAttributes
            bool requestInputConfig_inputConfig_DataAttributesIsNull = true;
            requestInputConfig_inputConfig_DataAttributes = new Amazon.SageMaker.Model.LabelingJobDataAttributes();
            List<System.String> requestInputConfig_inputConfig_DataAttributes_dataAttributes_ContentClassifier = null;
            if (cmdletContext.InputConfig_DataAttributes_ContentClassifiers != null)
            {
                requestInputConfig_inputConfig_DataAttributes_dataAttributes_ContentClassifier = cmdletContext.InputConfig_DataAttributes_ContentClassifiers;
            }
            if (requestInputConfig_inputConfig_DataAttributes_dataAttributes_ContentClassifier != null)
            {
                requestInputConfig_inputConfig_DataAttributes.ContentClassifiers = requestInputConfig_inputConfig_DataAttributes_dataAttributes_ContentClassifier;
                requestInputConfig_inputConfig_DataAttributesIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_DataAttributes should be set to null
            if (requestInputConfig_inputConfig_DataAttributesIsNull)
            {
                requestInputConfig_inputConfig_DataAttributes = null;
            }
            if (requestInputConfig_inputConfig_DataAttributes != null)
            {
                request.InputConfig.DataAttributes = requestInputConfig_inputConfig_DataAttributes;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.LabelingJobDataSource requestInputConfig_inputConfig_DataSource = null;
            
             // populate DataSource
            bool requestInputConfig_inputConfig_DataSourceIsNull = true;
            requestInputConfig_inputConfig_DataSource = new Amazon.SageMaker.Model.LabelingJobDataSource();
            Amazon.SageMaker.Model.LabelingJobS3DataSource requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource = null;
            
             // populate S3DataSource
            bool requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSourceIsNull = true;
            requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource = new Amazon.SageMaker.Model.LabelingJobS3DataSource();
            System.String requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource_s3DataSource_ManifestS3Uri = null;
            if (cmdletContext.InputConfig_DataSource_S3DataSource_ManifestS3Uri != null)
            {
                requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource_s3DataSource_ManifestS3Uri = cmdletContext.InputConfig_DataSource_S3DataSource_ManifestS3Uri;
            }
            if (requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource_s3DataSource_ManifestS3Uri != null)
            {
                requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource.ManifestS3Uri = requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource_s3DataSource_ManifestS3Uri;
                requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSourceIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource should be set to null
            if (requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSourceIsNull)
            {
                requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource = null;
            }
            if (requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource != null)
            {
                requestInputConfig_inputConfig_DataSource.S3DataSource = requestInputConfig_inputConfig_DataSource_inputConfig_DataSource_S3DataSource;
                requestInputConfig_inputConfig_DataSourceIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_DataSource should be set to null
            if (requestInputConfig_inputConfig_DataSourceIsNull)
            {
                requestInputConfig_inputConfig_DataSource = null;
            }
            if (requestInputConfig_inputConfig_DataSource != null)
            {
                request.InputConfig.DataSource = requestInputConfig_inputConfig_DataSource;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            if (cmdletContext.LabelAttributeName != null)
            {
                request.LabelAttributeName = cmdletContext.LabelAttributeName;
            }
            if (cmdletContext.LabelCategoryConfigS3Uri != null)
            {
                request.LabelCategoryConfigS3Uri = cmdletContext.LabelCategoryConfigS3Uri;
            }
            
             // populate LabelingJobAlgorithmsConfig
            bool requestLabelingJobAlgorithmsConfigIsNull = true;
            request.LabelingJobAlgorithmsConfig = new Amazon.SageMaker.Model.LabelingJobAlgorithmsConfig();
            System.String requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_InitialActiveLearningModelArn = null;
            if (cmdletContext.LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn != null)
            {
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_InitialActiveLearningModelArn = cmdletContext.LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn;
            }
            if (requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_InitialActiveLearningModelArn != null)
            {
                request.LabelingJobAlgorithmsConfig.InitialActiveLearningModelArn = requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_InitialActiveLearningModelArn;
                requestLabelingJobAlgorithmsConfigIsNull = false;
            }
            System.String requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn = null;
            if (cmdletContext.LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn != null)
            {
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn = cmdletContext.LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn;
            }
            if (requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn != null)
            {
                request.LabelingJobAlgorithmsConfig.LabelingJobAlgorithmSpecificationArn = requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn;
                requestLabelingJobAlgorithmsConfigIsNull = false;
            }
            Amazon.SageMaker.Model.LabelingJobResourceConfig requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig = null;
            
             // populate LabelingJobResourceConfig
            bool requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfigIsNull = true;
            requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig = new Amazon.SageMaker.Model.LabelingJobResourceConfig();
            System.String requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig_labelingJobResourceConfig_VolumeKmsKeyId = null;
            if (cmdletContext.LabelingJobAlgorithmsConfig_LabelingJobResourceConfig_VolumeKmsKeyId != null)
            {
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig_labelingJobResourceConfig_VolumeKmsKeyId = cmdletContext.LabelingJobAlgorithmsConfig_LabelingJobResourceConfig_VolumeKmsKeyId;
            }
            if (requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig_labelingJobResourceConfig_VolumeKmsKeyId != null)
            {
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig.VolumeKmsKeyId = requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig_labelingJobResourceConfig_VolumeKmsKeyId;
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfigIsNull = false;
            }
             // determine if requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig should be set to null
            if (requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfigIsNull)
            {
                requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig = null;
            }
            if (requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig != null)
            {
                request.LabelingJobAlgorithmsConfig.LabelingJobResourceConfig = requestLabelingJobAlgorithmsConfig_labelingJobAlgorithmsConfig_LabelingJobResourceConfig;
                requestLabelingJobAlgorithmsConfigIsNull = false;
            }
             // determine if request.LabelingJobAlgorithmsConfig should be set to null
            if (requestLabelingJobAlgorithmsConfigIsNull)
            {
                request.LabelingJobAlgorithmsConfig = null;
            }
            if (cmdletContext.LabelingJobName != null)
            {
                request.LabelingJobName = cmdletContext.LabelingJobName;
            }
            
             // populate OutputConfig
            bool requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.LabelingJobOutputConfig();
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
            
             // populate StoppingConditions
            bool requestStoppingConditionsIsNull = true;
            request.StoppingConditions = new Amazon.SageMaker.Model.LabelingJobStoppingConditions();
            System.Int32? requestStoppingConditions_stoppingConditions_MaxHumanLabeledObjectCount = null;
            if (cmdletContext.StoppingConditions_MaxHumanLabeledObjectCount != null)
            {
                requestStoppingConditions_stoppingConditions_MaxHumanLabeledObjectCount = cmdletContext.StoppingConditions_MaxHumanLabeledObjectCount.Value;
            }
            if (requestStoppingConditions_stoppingConditions_MaxHumanLabeledObjectCount != null)
            {
                request.StoppingConditions.MaxHumanLabeledObjectCount = requestStoppingConditions_stoppingConditions_MaxHumanLabeledObjectCount.Value;
                requestStoppingConditionsIsNull = false;
            }
            System.Int32? requestStoppingConditions_stoppingConditions_MaxPercentageOfInputDatasetLabeled = null;
            if (cmdletContext.StoppingConditions_MaxPercentageOfInputDatasetLabeled != null)
            {
                requestStoppingConditions_stoppingConditions_MaxPercentageOfInputDatasetLabeled = cmdletContext.StoppingConditions_MaxPercentageOfInputDatasetLabeled.Value;
            }
            if (requestStoppingConditions_stoppingConditions_MaxPercentageOfInputDatasetLabeled != null)
            {
                request.StoppingConditions.MaxPercentageOfInputDatasetLabeled = requestStoppingConditions_stoppingConditions_MaxPercentageOfInputDatasetLabeled.Value;
                requestStoppingConditionsIsNull = false;
            }
             // determine if request.StoppingConditions should be set to null
            if (requestStoppingConditionsIsNull)
            {
                request.StoppingConditions = null;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LabelingJobArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.SageMaker.Model.CreateLabelingJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateLabelingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateLabelingJob");
            try
            {
                #if DESKTOP
                return client.CreateLabelingJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLabelingJobAsync(request);
                return task.Result;
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
            public System.String HumanTaskConfig_AnnotationConsolidationConfig_AnnotationConsolidationLambdaArn { get; set; }
            public System.Int32? HumanTaskConfig_MaxConcurrentTaskCount { get; set; }
            public System.Int32? HumanTaskConfig_NumberOfHumanWorkersPerDataObject { get; set; }
            public System.String HumanTaskConfig_PreHumanTaskLambdaArn { get; set; }
            public System.Int32? HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Cents { get; set; }
            public System.Int32? HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_Dollars { get; set; }
            public System.Int32? HumanTaskConfig_PublicWorkforceTaskPrice_AmountInUsd_TenthFractionsOfACent { get; set; }
            public System.Int32? HumanTaskConfig_TaskAvailabilityLifetimeInSeconds { get; set; }
            public System.String HumanTaskConfig_TaskDescription { get; set; }
            public List<System.String> HumanTaskConfig_TaskKeywords { get; set; }
            public System.Int32? HumanTaskConfig_TaskTimeLimitInSeconds { get; set; }
            public System.String HumanTaskConfig_TaskTitle { get; set; }
            public System.String HumanTaskConfig_UiConfig_UiTemplateS3Uri { get; set; }
            public System.String HumanTaskConfig_WorkteamArn { get; set; }
            public List<System.String> InputConfig_DataAttributes_ContentClassifiers { get; set; }
            public System.String InputConfig_DataSource_S3DataSource_ManifestS3Uri { get; set; }
            public System.String LabelAttributeName { get; set; }
            public System.String LabelCategoryConfigS3Uri { get; set; }
            public System.String LabelingJobAlgorithmsConfig_InitialActiveLearningModelArn { get; set; }
            public System.String LabelingJobAlgorithmsConfig_LabelingJobAlgorithmSpecificationArn { get; set; }
            public System.String LabelingJobAlgorithmsConfig_LabelingJobResourceConfig_VolumeKmsKeyId { get; set; }
            public System.String LabelingJobName { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String OutputConfig_S3OutputPath { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingConditions_MaxHumanLabeledObjectCount { get; set; }
            public System.Int32? StoppingConditions_MaxPercentageOfInputDatasetLabeled { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tags { get; set; }
        }
        
    }
}
