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
    /// AddJobFlowSteps adds new steps to a running cluster. A maximum of 256 steps are allowed
    /// in each job flow.
    /// 
    ///  
    /// <para>
    /// If your cluster is long-running (such as a Hive data warehouse) or complex, you may
    /// require more than 256 steps to process your data. You can bypass the 256-step limitation
    /// in various ways, including using SSH to connect to the master node and submitting
    /// queries directly to the software running on the master node, such as Hive and Hadoop.
    /// </para><para>
    /// A step specifies the location of a JAR file stored either on the master node of the
    /// cluster or in Amazon S3. Each step is performed by the main function of the main class
    /// of the JAR file. The main class can be specified either in the manifest of the JAR
    /// or by using the MainFunction parameter of the step.
    /// </para><para>
    /// Amazon EMR executes each step in the order listed. For a step to be considered complete,
    /// the main function must exit with a zero exit code and all Hadoop jobs started while
    /// the step was running must have completed and run successfully.
    /// </para><para>
    /// You can only add steps to a cluster that is in one of the following states: STARTING,
    /// BOOTSTRAPPING, RUNNING, or WAITING.
    /// </para><note><para>
    /// The string values passed into <code>HadoopJarStep</code> object cannot exceed a total
    /// of 10240 characters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "EMRJobFlowStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce AddJobFlowSteps API operation.", Operation = new[] {"AddJobFlowSteps"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEMRJobFlowStepCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the runtime role for a step on the cluster. The
        /// runtime role can be a cross-account IAM role. The runtime role ARN is a combination
        /// of account ID, role name, and role type using the following format: <code>arn:partition:service:region:account:resource</code>.
        /// </para><para>For example, <code>arn:aws:IAM::1234567890:role/ReadOnly</code> is a correctly formatted
        /// runtime role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para>A string that uniquely identifies the job flow. This identifier is returned by <a>RunJobFlow</a>
        /// and can also be obtained from <a>ListClusters</a>. </para>
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
        public System.String JobFlowId { get; set; }
        #endregion
        
        #region Parameter Step
        /// <summary>
        /// <para>
        /// <para> A list of <a>StepConfig</a> to be executed by the job flow. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Steps")]
        public Amazon.ElasticMapReduce.Model.StepConfig[] Step { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StepIds'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StepIds";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobFlowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobFlowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobFlowId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMRJobFlowStep (AddJobFlowSteps)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse, AddEMRJobFlowStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobFlowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.JobFlowId = this.JobFlowId;
            #if MODULAR
            if (this.JobFlowId == null && ParameterWasBound(nameof(this.JobFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Step != null)
            {
                context.Step = new List<Amazon.ElasticMapReduce.Model.StepConfig>(this.Step);
            }
            #if MODULAR
            if (this.Step == null && ParameterWasBound(nameof(this.Step)))
            {
                WriteWarning("You are passing $null as a value for parameter Step which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.AddJobFlowStepsRequest();
            
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.JobFlowId != null)
            {
                request.JobFlowId = cmdletContext.JobFlowId;
            }
            if (cmdletContext.Step != null)
            {
                request.Steps = cmdletContext.Step;
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
        
        private Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.AddJobFlowStepsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "AddJobFlowSteps");
            try
            {
                #if DESKTOP
                return client.AddJobFlowSteps(request);
                #elif CORECLR
                return client.AddJobFlowStepsAsync(request).GetAwaiter().GetResult();
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
            public System.String ExecutionRoleArn { get; set; }
            public System.String JobFlowId { get; set; }
            public List<Amazon.ElasticMapReduce.Model.StepConfig> Step { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse, AddEMRJobFlowStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StepIds;
        }
        
    }
}
