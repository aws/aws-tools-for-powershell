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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Updates the <code>EvaluationName</code> of an <code>Evaluation</code>.
    /// 
    ///  
    /// <para>
    /// You can use the <a>GetEvaluation</a> operation to view the contents of the updated
    /// data element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MLEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateEvaluation operation against Amazon Machine Learning.", Operation = new[] {"UpdateEvaluation"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.UpdateEvaluationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateMLEvaluationCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter EvaluationId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>Evaluation</code> during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EvaluationId { get; set; }
        #endregion
        
        #region Parameter EvaluationName
        /// <summary>
        /// <para>
        /// <para>A new user-supplied name or description of the <code>Evaluation</code> that will replace
        /// the current content. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Name")]
        public System.String EvaluationName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EvaluationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MLEvaluation (UpdateEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EvaluationId = this.EvaluationId;
            context.EvaluationName = this.EvaluationName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MachineLearning.Model.UpdateEvaluationRequest();
            
            if (cmdletContext.EvaluationId != null)
            {
                request.EvaluationId = cmdletContext.EvaluationId;
            }
            if (cmdletContext.EvaluationName != null)
            {
                request.EvaluationName = cmdletContext.EvaluationName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateEvaluation(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EvaluationId;
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
            public System.String EvaluationId { get; set; }
            public System.String EvaluationName { get; set; }
        }
        
    }
}
