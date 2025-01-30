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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a membership for a specific collaboration identifier and joins the collaboration.
    /// </summary>
    [Cmdlet("New", "CRSMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.Membership")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateMembership API operation.", Operation = new[] {"CreateMembership"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateMembershipResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.Membership or Amazon.CleanRooms.Model.CreateMembershipResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.Membership object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateMembershipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSMembershipCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter CollaborationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique ID for the associated collaboration.</para>
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
        public System.String CollaborationIdentifier { get; set; }
        #endregion
        
        #region Parameter ModelInference_IsResponsible
        /// <summary>
        /// <para>
        /// <para>Indicates whether the collaboration member has accepted to pay for model inference
        /// costs (<c>TRUE</c>) or has not accepted to pay for model inference costs (<c>FALSE</c>).</para><para>If the collaboration creator has not specified anyone to pay for model inference costs,
        /// then the member who can query is the default payer. </para><para>An error message is returned for the following reasons: </para><ul><li><para>If you set the value to <c>FALSE</c> but you are responsible to pay for model inference
        /// costs. </para></li><li><para>If you set the value to <c>TRUE</c> but you are not responsible to pay for model inference
        /// costs. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PaymentConfiguration_MachineLearning_ModelInference_IsResponsible")]
        public System.Boolean? ModelInference_IsResponsible { get; set; }
        #endregion
        
        #region Parameter ModelTraining_IsResponsible
        /// <summary>
        /// <para>
        /// <para>Indicates whether the collaboration member has accepted to pay for model training
        /// costs (<c>TRUE</c>) or has not accepted to pay for model training costs (<c>FALSE</c>).</para><para>If the collaboration creator has not specified anyone to pay for model training costs,
        /// then the member who can query is the default payer. </para><para>An error message is returned for the following reasons: </para><ul><li><para>If you set the value to <c>FALSE</c> but you are responsible to pay for model training
        /// costs. </para></li><li><para>If you set the value to <c>TRUE</c> but you are not responsible to pay for model training
        /// costs. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PaymentConfiguration_MachineLearning_ModelTraining_IsResponsible")]
        public System.Boolean? ModelTraining_IsResponsible { get; set; }
        #endregion
        
        #region Parameter QueryCompute_IsResponsible
        /// <summary>
        /// <para>
        /// <para>Indicates whether the collaboration member has accepted to pay for query compute costs
        /// (<c>TRUE</c>) or has not accepted to pay for query compute costs (<c>FALSE</c>).</para><para>If the collaboration creator has not specified anyone to pay for query compute costs,
        /// then the member who can query is the default payer. </para><para>An error message is returned for the following reasons: </para><ul><li><para>If you set the value to <c>FALSE</c> but you are responsible to pay for query compute
        /// costs. </para></li><li><para>If you set the value to <c>TRUE</c> but you are not responsible to pay for query compute
        /// costs. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PaymentConfiguration_QueryCompute_IsResponsible")]
        public System.Boolean? QueryCompute_IsResponsible { get; set; }
        #endregion
        
        #region Parameter S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 prefix to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_KeyPrefix")]
        public System.String S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter QueryLogStatus
        /// <summary>
        /// <para>
        /// <para>An indicator as to whether query logging has been enabled or disabled for the membership.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.MembershipQueryLogStatus")]
        public Amazon.CleanRooms.MembershipQueryLogStatus QueryLogStatus { get; set; }
        #endregion
        
        #region Parameter S3_ResultFormat
        /// <summary>
        /// <para>
        /// <para>Intended file format of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_ResultFormat")]
        [AWSConstantClassSource("Amazon.CleanRooms.ResultFormat")]
        public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
        #endregion
        
        #region Parameter DefaultResultConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The unique ARN for an IAM role that is used by Clean Rooms to write protected query
        /// results to the result location, given by the member who can receive results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultResultConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3_SingleFileOutput
        /// <summary>
        /// <para>
        /// <para>Indicates whether files should be output as a single file (<c>TRUE</c>) or output
        /// as multiple files (<c>FALSE</c>). This parameter is only supported for analyses with
        /// the Spark analytics engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_SingleFileOutput")]
        public System.Boolean? S3_SingleFileOutput { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Membership'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateMembershipResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateMembershipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Membership";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CollaborationIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CollaborationIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CollaborationIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollaborationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSMembership (CreateMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateMembershipResponse, NewCRSMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CollaborationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CollaborationIdentifier = this.CollaborationIdentifier;
            #if MODULAR
            if (this.CollaborationIdentifier == null && ParameterWasBound(nameof(this.CollaborationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaborationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3_Bucket = this.S3_Bucket;
            context.S3_KeyPrefix = this.S3_KeyPrefix;
            context.S3_ResultFormat = this.S3_ResultFormat;
            context.S3_SingleFileOutput = this.S3_SingleFileOutput;
            context.DefaultResultConfiguration_RoleArn = this.DefaultResultConfiguration_RoleArn;
            context.ModelInference_IsResponsible = this.ModelInference_IsResponsible;
            context.ModelTraining_IsResponsible = this.ModelTraining_IsResponsible;
            context.QueryCompute_IsResponsible = this.QueryCompute_IsResponsible;
            context.QueryLogStatus = this.QueryLogStatus;
            #if MODULAR
            if (this.QueryLogStatus == null && ParameterWasBound(nameof(this.QueryLogStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryLogStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CleanRooms.Model.CreateMembershipRequest();
            
            if (cmdletContext.CollaborationIdentifier != null)
            {
                request.CollaborationIdentifier = cmdletContext.CollaborationIdentifier;
            }
            
             // populate DefaultResultConfiguration
            var requestDefaultResultConfigurationIsNull = true;
            request.DefaultResultConfiguration = new Amazon.CleanRooms.Model.MembershipProtectedQueryResultConfiguration();
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn = null;
            if (cmdletContext.DefaultResultConfiguration_RoleArn != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn = cmdletContext.DefaultResultConfiguration_RoleArn;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn != null)
            {
                request.DefaultResultConfiguration.RoleArn = requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn;
                requestDefaultResultConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.MembershipProtectedQueryOutputConfiguration requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = null;
            
             // populate OutputConfiguration
            var requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull = true;
            requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = new Amazon.CleanRooms.Model.MembershipProtectedQueryOutputConfiguration();
            Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = null;
            
             // populate S3
            var requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = true;
            requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = new Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration();
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.Bucket = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = null;
            if (cmdletContext.S3_KeyPrefix != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = cmdletContext.S3_KeyPrefix;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.KeyPrefix = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            Amazon.CleanRooms.ResultFormat requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat = null;
            if (cmdletContext.S3_ResultFormat != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat = cmdletContext.S3_ResultFormat;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.ResultFormat = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.Boolean? requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput = null;
            if (cmdletContext.S3_SingleFileOutput != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput = cmdletContext.S3_SingleFileOutput.Value;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.SingleFileOutput = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput.Value;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
             // determine if requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 should be set to null
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = null;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration.S3 = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull = false;
            }
             // determine if requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration should be set to null
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = null;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration != null)
            {
                request.DefaultResultConfiguration.OutputConfiguration = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration;
                requestDefaultResultConfigurationIsNull = false;
            }
             // determine if request.DefaultResultConfiguration should be set to null
            if (requestDefaultResultConfigurationIsNull)
            {
                request.DefaultResultConfiguration = null;
            }
            
             // populate PaymentConfiguration
            var requestPaymentConfigurationIsNull = true;
            request.PaymentConfiguration = new Amazon.CleanRooms.Model.MembershipPaymentConfiguration();
            Amazon.CleanRooms.Model.MembershipQueryComputePaymentConfig requestPaymentConfiguration_paymentConfiguration_QueryCompute = null;
            
             // populate QueryCompute
            var requestPaymentConfiguration_paymentConfiguration_QueryComputeIsNull = true;
            requestPaymentConfiguration_paymentConfiguration_QueryCompute = new Amazon.CleanRooms.Model.MembershipQueryComputePaymentConfig();
            System.Boolean? requestPaymentConfiguration_paymentConfiguration_QueryCompute_queryCompute_IsResponsible = null;
            if (cmdletContext.QueryCompute_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_QueryCompute_queryCompute_IsResponsible = cmdletContext.QueryCompute_IsResponsible.Value;
            }
            if (requestPaymentConfiguration_paymentConfiguration_QueryCompute_queryCompute_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_QueryCompute.IsResponsible = requestPaymentConfiguration_paymentConfiguration_QueryCompute_queryCompute_IsResponsible.Value;
                requestPaymentConfiguration_paymentConfiguration_QueryComputeIsNull = false;
            }
             // determine if requestPaymentConfiguration_paymentConfiguration_QueryCompute should be set to null
            if (requestPaymentConfiguration_paymentConfiguration_QueryComputeIsNull)
            {
                requestPaymentConfiguration_paymentConfiguration_QueryCompute = null;
            }
            if (requestPaymentConfiguration_paymentConfiguration_QueryCompute != null)
            {
                request.PaymentConfiguration.QueryCompute = requestPaymentConfiguration_paymentConfiguration_QueryCompute;
                requestPaymentConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.MembershipMLPaymentConfig requestPaymentConfiguration_paymentConfiguration_MachineLearning = null;
            
             // populate MachineLearning
            var requestPaymentConfiguration_paymentConfiguration_MachineLearningIsNull = true;
            requestPaymentConfiguration_paymentConfiguration_MachineLearning = new Amazon.CleanRooms.Model.MembershipMLPaymentConfig();
            Amazon.CleanRooms.Model.MembershipModelInferencePaymentConfig requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference = null;
            
             // populate ModelInference
            var requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInferenceIsNull = true;
            requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference = new Amazon.CleanRooms.Model.MembershipModelInferencePaymentConfig();
            System.Boolean? requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference_modelInference_IsResponsible = null;
            if (cmdletContext.ModelInference_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference_modelInference_IsResponsible = cmdletContext.ModelInference_IsResponsible.Value;
            }
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference_modelInference_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference.IsResponsible = requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference_modelInference_IsResponsible.Value;
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInferenceIsNull = false;
            }
             // determine if requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference should be set to null
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInferenceIsNull)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference = null;
            }
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning.ModelInference = requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelInference;
                requestPaymentConfiguration_paymentConfiguration_MachineLearningIsNull = false;
            }
            Amazon.CleanRooms.Model.MembershipModelTrainingPaymentConfig requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining = null;
            
             // populate ModelTraining
            var requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTrainingIsNull = true;
            requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining = new Amazon.CleanRooms.Model.MembershipModelTrainingPaymentConfig();
            System.Boolean? requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining_modelTraining_IsResponsible = null;
            if (cmdletContext.ModelTraining_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining_modelTraining_IsResponsible = cmdletContext.ModelTraining_IsResponsible.Value;
            }
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining_modelTraining_IsResponsible != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining.IsResponsible = requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining_modelTraining_IsResponsible.Value;
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTrainingIsNull = false;
            }
             // determine if requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining should be set to null
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTrainingIsNull)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining = null;
            }
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining != null)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning.ModelTraining = requestPaymentConfiguration_paymentConfiguration_MachineLearning_paymentConfiguration_MachineLearning_ModelTraining;
                requestPaymentConfiguration_paymentConfiguration_MachineLearningIsNull = false;
            }
             // determine if requestPaymentConfiguration_paymentConfiguration_MachineLearning should be set to null
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearningIsNull)
            {
                requestPaymentConfiguration_paymentConfiguration_MachineLearning = null;
            }
            if (requestPaymentConfiguration_paymentConfiguration_MachineLearning != null)
            {
                request.PaymentConfiguration.MachineLearning = requestPaymentConfiguration_paymentConfiguration_MachineLearning;
                requestPaymentConfigurationIsNull = false;
            }
             // determine if request.PaymentConfiguration should be set to null
            if (requestPaymentConfigurationIsNull)
            {
                request.PaymentConfiguration = null;
            }
            if (cmdletContext.QueryLogStatus != null)
            {
                request.QueryLogStatus = cmdletContext.QueryLogStatus;
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
        
        private Amazon.CleanRooms.Model.CreateMembershipResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateMembership");
            try
            {
                #if DESKTOP
                return client.CreateMembership(request);
                #elif CORECLR
                return client.CreateMembershipAsync(request).GetAwaiter().GetResult();
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
            public System.String CollaborationIdentifier { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_KeyPrefix { get; set; }
            public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
            public System.Boolean? S3_SingleFileOutput { get; set; }
            public System.String DefaultResultConfiguration_RoleArn { get; set; }
            public System.Boolean? ModelInference_IsResponsible { get; set; }
            public System.Boolean? ModelTraining_IsResponsible { get; set; }
            public System.Boolean? QueryCompute_IsResponsible { get; set; }
            public Amazon.CleanRooms.MembershipQueryLogStatus QueryLogStatus { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateMembershipResponse, NewCRSMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Membership;
        }
        
    }
}
