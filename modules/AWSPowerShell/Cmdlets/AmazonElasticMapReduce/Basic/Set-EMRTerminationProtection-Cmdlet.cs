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
    /// SetTerminationProtection locks a job flow so the Amazon EC2 instances in the cluster
    /// cannot be terminated by user intervention, an API call, or in the event of a job-flow
    /// error. The cluster still terminates upon successful completion of the job flow. Calling
    /// SetTerminationProtection on a job flow is analogous to calling the Amazon EC2 DisableAPITermination
    /// API on all of the EC2 instances in a cluster.
    /// 
    ///  
    /// <para>
    /// SetTerminationProtection is used to prevent accidental termination of a job flow and
    /// to ensure that in the event of an error, the instances will persist so you can recover
    /// any data stored in their ephemeral instance storage.
    /// </para><para>
    ///  To terminate a job flow that has been locked by setting SetTerminationProtection
    /// to <code>true</code>, you must first unlock the job flow by a subsequent call to SetTerminationProtection
    /// in which you set the value to <code>false</code>. 
    /// </para><para>
    ///  For more information, go to <a href="http://docs.aws.amazon.com/ElasticMapReduce/latest/DeveloperGuide/UsingEMR_TerminationProtection.html">Protecting
    /// a Job Flow from Termination</a> in the <i>Amazon Elastic MapReduce Developer's Guide.</i></para>
    /// </summary>
    [Cmdlet("Set", "EMRTerminationProtection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetTerminationProtection operation against Amazon Elastic MapReduce.", Operation = new[] {"SetTerminationProtection"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobFlowId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticMapReduce.Model.SetTerminationProtectionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetEMRTerminationProtectionCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para> A list of strings that uniquely identify the job flows to protect. This identifier
        /// is returned by <a>RunJobFlow</a> and can also be obtained from <a>DescribeJobFlows</a>
        /// . </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("JobFlowIds")]
        public System.String[] JobFlowId { get; set; }
        #endregion
        
        #region Parameter TerminationProtected
        /// <summary>
        /// <para>
        /// <para>A Boolean that indicates whether to protect the job flow and prevent the Amazon EC2
        /// instances in the cluster from shutting down due to API calls, user intervention, or
        /// job-flow error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Boolean TerminationProtected { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the JobFlowId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobFlowId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EMRTerminationProtection (SetTerminationProtection)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.JobFlowId != null)
            {
                context.JobFlowIds = new List<System.String>(this.JobFlowId);
            }
            if (ParameterWasBound("TerminationProtected"))
                context.TerminationProtected = this.TerminationProtected;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticMapReduce.Model.SetTerminationProtectionRequest();
            
            if (cmdletContext.JobFlowIds != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowIds;
            }
            if (cmdletContext.TerminationProtected != null)
            {
                request.TerminationProtected = cmdletContext.TerminationProtected.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.JobFlowId;
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
        
        private static Amazon.ElasticMapReduce.Model.SetTerminationProtectionResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.SetTerminationProtectionRequest request)
        {
            return client.SetTerminationProtection(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> JobFlowIds { get; set; }
            public System.Boolean? TerminationProtected { get; set; }
        }
        
    }
}
