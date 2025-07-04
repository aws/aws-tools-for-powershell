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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an SageMaker <i>trial</i>. A trial is a set of steps called <i>trial components</i>
    /// that produce a machine learning model. A trial is part of a single SageMaker <i>experiment</i>.
    /// 
    ///  
    /// <para>
    /// When you use SageMaker Studio or the SageMaker Python SDK, all experiments, trials,
    /// and trial components are automatically tracked, logged, and indexed. When you use
    /// the Amazon Web Services SDK for Python (Boto), you must use the logging APIs provided
    /// by the SDK.
    /// </para><para>
    /// You can add tags to a trial and then use the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Search.html">Search</a>
    /// API to search for the tags.
    /// </para><para>
    /// To get a list of all your trials, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ListTrials.html">ListTrials</a>
    /// API. To view a trial's properties, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeTrial.html">DescribeTrial</a>
    /// API. To create a trial component, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrialComponent.html">CreateTrialComponent</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTrial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrial API operation.", Operation = new[] {"CreateTrial"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTrialResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTrialResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrialResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMTrialCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetadataProperties_CommitId
        /// <summary>
        /// <para>
        /// <para>The commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_CommitId { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of the trial as displayed. The name doesn't need to be unique. If <c>DisplayName</c>
        /// isn't specified, <c>TrialName</c> is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ExperimentName
        /// <summary>
        /// <para>
        /// <para>The name of the experiment to associate the trial with.</para>
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
        public System.String ExperimentName { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_GeneratedBy
        /// <summary>
        /// <para>
        /// <para>The entity this entity was generated by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_GeneratedBy { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_ProjectId
        /// <summary>
        /// <para>
        /// <para>The project ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_ProjectId { get; set; }
        #endregion
        
        #region Parameter MetadataProperties_Repository
        /// <summary>
        /// <para>
        /// <para>The repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataProperties_Repository { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the trial. You can use <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Search.html">Search</a>
        /// API to search on the tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrialName
        /// <summary>
        /// <para>
        /// <para>The name of the trial. The name must be unique in your Amazon Web Services account
        /// and is not case-sensitive.</para>
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
        public System.String TrialName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrialArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTrialResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTrialResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrialArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrialName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrial (CreateTrial)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTrialResponse, NewSMTrialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayName = this.DisplayName;
            context.ExperimentName = this.ExperimentName;
            #if MODULAR
            if (this.ExperimentName == null && ParameterWasBound(nameof(this.ExperimentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataProperties_CommitId = this.MetadataProperties_CommitId;
            context.MetadataProperties_GeneratedBy = this.MetadataProperties_GeneratedBy;
            context.MetadataProperties_ProjectId = this.MetadataProperties_ProjectId;
            context.MetadataProperties_Repository = this.MetadataProperties_Repository;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TrialName = this.TrialName;
            #if MODULAR
            if (this.TrialName == null && ParameterWasBound(nameof(this.TrialName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrialName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SageMaker.Model.CreateTrialRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ExperimentName != null)
            {
                request.ExperimentName = cmdletContext.ExperimentName;
            }
            
             // populate MetadataProperties
            var requestMetadataPropertiesIsNull = true;
            request.MetadataProperties = new Amazon.SageMaker.Model.MetadataProperties();
            System.String requestMetadataProperties_metadataProperties_CommitId = null;
            if (cmdletContext.MetadataProperties_CommitId != null)
            {
                requestMetadataProperties_metadataProperties_CommitId = cmdletContext.MetadataProperties_CommitId;
            }
            if (requestMetadataProperties_metadataProperties_CommitId != null)
            {
                request.MetadataProperties.CommitId = requestMetadataProperties_metadataProperties_CommitId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_GeneratedBy = null;
            if (cmdletContext.MetadataProperties_GeneratedBy != null)
            {
                requestMetadataProperties_metadataProperties_GeneratedBy = cmdletContext.MetadataProperties_GeneratedBy;
            }
            if (requestMetadataProperties_metadataProperties_GeneratedBy != null)
            {
                request.MetadataProperties.GeneratedBy = requestMetadataProperties_metadataProperties_GeneratedBy;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_ProjectId = null;
            if (cmdletContext.MetadataProperties_ProjectId != null)
            {
                requestMetadataProperties_metadataProperties_ProjectId = cmdletContext.MetadataProperties_ProjectId;
            }
            if (requestMetadataProperties_metadataProperties_ProjectId != null)
            {
                request.MetadataProperties.ProjectId = requestMetadataProperties_metadataProperties_ProjectId;
                requestMetadataPropertiesIsNull = false;
            }
            System.String requestMetadataProperties_metadataProperties_Repository = null;
            if (cmdletContext.MetadataProperties_Repository != null)
            {
                requestMetadataProperties_metadataProperties_Repository = cmdletContext.MetadataProperties_Repository;
            }
            if (requestMetadataProperties_metadataProperties_Repository != null)
            {
                request.MetadataProperties.Repository = requestMetadataProperties_metadataProperties_Repository;
                requestMetadataPropertiesIsNull = false;
            }
             // determine if request.MetadataProperties should be set to null
            if (requestMetadataPropertiesIsNull)
            {
                request.MetadataProperties = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrialName != null)
            {
                request.TrialName = cmdletContext.TrialName;
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
        
        private Amazon.SageMaker.Model.CreateTrialResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrial");
            try
            {
                return client.CreateTrialAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public System.String ExperimentName { get; set; }
            public System.String MetadataProperties_CommitId { get; set; }
            public System.String MetadataProperties_GeneratedBy { get; set; }
            public System.String MetadataProperties_ProjectId { get; set; }
            public System.String MetadataProperties_Repository { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TrialName { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTrialResponse, NewSMTrialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrialArn;
        }
        
    }
}
