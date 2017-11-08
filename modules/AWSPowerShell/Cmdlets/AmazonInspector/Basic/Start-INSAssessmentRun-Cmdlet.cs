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
    /// Starts the assessment run specified by the ARN of the assessment template. For this
    /// API to function properly, you must not exceed the limit of running up to 500 concurrent
    /// agents per AWS account.
    /// </summary>
    [Cmdlet("Start", "INSAssessmentRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector StartAssessmentRun API operation.", Operation = new[] {"StartAssessmentRun"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Inspector.Model.StartAssessmentRunResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartINSAssessmentRunCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AssessmentRunName
        /// <summary>
        /// <para>
        /// <para>You can specify the name for the assessment run. The name must be unique for the assessment
        /// template whose ARN is used to start the assessment run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentRunName { get; set; }
        #endregion
        
        #region Parameter AssessmentTemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the assessment template of the assessment run that you want to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentTemplateArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AssessmentTemplateArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-INSAssessmentRun (StartAssessmentRun)"))
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
            
            context.AssessmentRunName = this.AssessmentRunName;
            context.AssessmentTemplateArn = this.AssessmentTemplateArn;
            
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
            var request = new Amazon.Inspector.Model.StartAssessmentRunRequest();
            
            if (cmdletContext.AssessmentRunName != null)
            {
                request.AssessmentRunName = cmdletContext.AssessmentRunName;
            }
            if (cmdletContext.AssessmentTemplateArn != null)
            {
                request.AssessmentTemplateArn = cmdletContext.AssessmentTemplateArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AssessmentRunArn;
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
        
        private Amazon.Inspector.Model.StartAssessmentRunResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.StartAssessmentRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "StartAssessmentRun");
            try
            {
                #if DESKTOP
                return client.StartAssessmentRun(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartAssessmentRunAsync(request);
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
            public System.String AssessmentRunName { get; set; }
            public System.String AssessmentTemplateArn { get; set; }
        }
        
    }
}
