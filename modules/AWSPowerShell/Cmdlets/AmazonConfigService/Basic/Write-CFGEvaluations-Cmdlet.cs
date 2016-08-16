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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Used by an AWS Lambda function to deliver evaluation results to AWS Config. This action
    /// is required in every AWS Lambda function that is invoked by an AWS Config rule.
    /// </summary>
    [Cmdlet("Write", "CFGEvaluations", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.Evaluation")]
    [AWSCmdlet("Invokes the PutEvaluations operation against AWS Config.", Operation = new[] {"PutEvaluations"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.Evaluation",
        "This cmdlet returns a collection of Evaluation objects.",
        "The service call response (type Amazon.ConfigService.Model.PutEvaluationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGEvaluationsCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Evaluation
        /// <summary>
        /// <para>
        /// <para>The assessments that the AWS Lambda function performs. Each evaluation identifies
        /// an AWS resource and indicates whether it complies with the AWS Config rule that invokes
        /// the AWS Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Evaluations")]
        public Amazon.ConfigService.Model.Evaluation[] Evaluation { get; set; }
        #endregion
        
        #region Parameter ResultToken
        /// <summary>
        /// <para>
        /// <para>An encrypted token that associates an evaluation with an AWS Config rule. Identifies
        /// the rule and the event that triggered the evaluation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResultToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Evaluation", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGEvaluations (PutEvaluations)"))
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
            
            if (this.Evaluation != null)
            {
                context.Evaluations = new List<Amazon.ConfigService.Model.Evaluation>(this.Evaluation);
            }
            context.ResultToken = this.ResultToken;
            
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
            var request = new Amazon.ConfigService.Model.PutEvaluationsRequest();
            
            if (cmdletContext.Evaluations != null)
            {
                request.Evaluations = cmdletContext.Evaluations;
            }
            if (cmdletContext.ResultToken != null)
            {
                request.ResultToken = cmdletContext.ResultToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedEvaluations;
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
        
        private static Amazon.ConfigService.Model.PutEvaluationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutEvaluationsRequest request)
        {
            #if DESKTOP
            return client.PutEvaluations(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutEvaluationsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.ConfigService.Model.Evaluation> Evaluations { get; set; }
            public System.String ResultToken { get; set; }
        }
        
    }
}
