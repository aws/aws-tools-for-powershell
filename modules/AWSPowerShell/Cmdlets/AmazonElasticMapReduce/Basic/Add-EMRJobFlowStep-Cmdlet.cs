/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// AddJobFlowSteps adds new steps to a running job flow. A maximum of 256 steps are
    /// allowed in each job flow. 
    /// 
    ///  
    /// <para>
    /// If your job flow is long-running (such as a Hive data warehouse) or complex, you may
    /// require more than 256 steps to process your data. You can bypass the 256-step limitation
    /// in various ways, including using the SSH shell to connect to the master node and submitting
    /// queries directly to the software running on the master node, such as Hive and Hadoop.
    /// For more information on how to do this, go to <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/AddMoreThan256Steps.html">Add
    /// More than 256 Steps to a Job Flow</a> in the <i>Amazon Elastic MapReduce Developer's
    /// Guide</i>.
    /// </para><para>
    ///  A step specifies the location of a JAR file stored either on the master node of the
    /// job flow or in Amazon S3. Each step is performed by the main function of the main
    /// class of the JAR file. The main class can be specified either in the manifest of the
    /// JAR or by using the MainFunction parameter of the step. 
    /// </para><para>
    ///  Elastic MapReduce executes each step in the order listed. For a step to be considered
    /// complete, the main function must exit with a zero exit code and all Hadoop jobs started
    /// while the step was running must have completed and run successfully. 
    /// </para><para>
    ///  You can only add steps to a job flow that is in one of the following states: STARTING,
    /// BOOTSTRAPPING, RUNNING, or WAITING.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "EMRJobFlowStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the AddJobFlowSteps operation against Amazon Elastic MapReduce.", Operation = new[] {"AddJobFlowSteps"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.AddJobFlowStepsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class AddEMRJobFlowStepCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A string that uniquely identifies the job flow. This identifier is returned by <a>RunJobFlow</a>
        /// and can also be obtained from <a>ListClusters</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobFlowId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of <a>StepConfig</a> to be executed by the job flow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Steps")]
        public Amazon.ElasticMapReduce.Model.StepConfig[] Step { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobFlowId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMRJobFlowStep (AddJobFlowSteps)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.JobFlowId = this.JobFlowId;
            if (this.Step != null)
            {
                context.Steps = new List<Amazon.ElasticMapReduce.Model.StepConfig>(this.Step);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticMapReduce.Model.AddJobFlowStepsRequest();
            
            if (cmdletContext.JobFlowId != null)
            {
                request.JobFlowId = cmdletContext.JobFlowId;
            }
            if (cmdletContext.Steps != null)
            {
                request.Steps = cmdletContext.Steps;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AddJobFlowSteps(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StepIds;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String JobFlowId { get; set; }
            public List<Amazon.ElasticMapReduce.Model.StepConfig> Steps { get; set; }
        }
        
    }
}
