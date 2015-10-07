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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Starts the analysis of the application’s behavior against selected rule packages for
    /// the assessment specified by the assessment ARN.
    /// </summary>
    [Cmdlet("Start", "INSAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RunAssessment operation against Amazon Inspector.", Operation = new[] {"RunAssessment"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type RunAssessmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StartINSAssessmentCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ARN of the assessment that you want to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String AssessmentArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A name specifying the run of the assessment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RunName { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AssessmentArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-INSAssessment (RunAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AssessmentArn = this.AssessmentArn;
            context.RunName = this.RunName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RunAssessmentRequest();
            
            if (cmdletContext.AssessmentArn != null)
            {
                request.AssessmentArn = cmdletContext.AssessmentArn;
            }
            if (cmdletContext.RunName != null)
            {
                request.RunName = cmdletContext.RunName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RunAssessment(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RunArn;
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
            public String AssessmentArn { get; set; }
            public String RunName { get; set; }
        }
        
    }
}
