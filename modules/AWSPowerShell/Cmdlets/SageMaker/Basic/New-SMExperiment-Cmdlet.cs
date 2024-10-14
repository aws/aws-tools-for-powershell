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
    /// Creates a SageMaker <i>experiment</i>. An experiment is a collection of <i>trials</i>
    /// that are observed, compared and evaluated as a group. A trial is a set of steps, called
    /// <i>trial components</i>, that produce a machine learning model.
    /// 
    ///  <note><para>
    /// In the Studio UI, trials are referred to as <i>run groups</i> and trial components
    /// are referred to as <i>runs</i>.
    /// </para></note><para>
    /// The goal of an experiment is to determine the components that produce the best model.
    /// Multiple trials are performed, each one isolating and measuring the impact of a change
    /// to one or more inputs, while keeping the remaining inputs constant.
    /// </para><para>
    /// When you use SageMaker Studio or the SageMaker Python SDK, all experiments, trials,
    /// and trial components are automatically tracked, logged, and indexed. When you use
    /// the Amazon Web Services SDK for Python (Boto), you must use the logging APIs provided
    /// by the SDK.
    /// </para><para>
    /// You can add tags to experiments, trials, trial components and then use the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Search.html">Search</a>
    /// API to search for the tags.
    /// </para><para>
    /// To add a description to an experiment, specify the optional <c>Description</c> parameter.
    /// To add a description later, or to change the description, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_UpdateExperiment.html">UpdateExperiment</a>
    /// API.
    /// </para><para>
    /// To get a list of all your experiments, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ListExperiments.html">ListExperiments</a>
    /// API. To view an experiment's properties, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeExperiment.html">DescribeExperiment</a>
    /// API. To get a list of all the trials associated with an experiment, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ListTrials.html">ListTrials</a>
    /// API. To create a trial call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrial.html">CreateTrial</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateExperiment API operation.", Operation = new[] {"CreateExperiment"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateExperimentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateExperimentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateExperimentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMExperimentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of the experiment as displayed. The name doesn't need to be unique. If you
        /// don't specify <c>DisplayName</c>, the value in <c>ExperimentName</c> is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ExperimentName
        /// <summary>
        /// <para>
        /// <para>The name of the experiment. The name must be unique in your Amazon Web Services account
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
        public System.String ExperimentName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the experiment. You can use <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Search.html">Search</a>
        /// API to search on the tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExperimentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateExperimentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateExperimentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExperimentArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExperimentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExperimentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExperimentName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExperimentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMExperiment (CreateExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateExperimentResponse, NewSMExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExperimentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.ExperimentName = this.ExperimentName;
            #if MODULAR
            if (this.ExperimentName == null && ParameterWasBound(nameof(this.ExperimentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateExperimentRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ExperimentName != null)
            {
                request.ExperimentName = cmdletContext.ExperimentName;
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
        
        private Amazon.SageMaker.Model.CreateExperimentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateExperiment");
            try
            {
                #if DESKTOP
                return client.CreateExperiment(request);
                #elif CORECLR
                return client.CreateExperimentAsync(request).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public System.String ExperimentName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateExperimentResponse, NewSMExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExperimentArn;
        }
        
    }
}
